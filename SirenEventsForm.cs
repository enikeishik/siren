/**
 * Siren
 * Simple event notifyer
 * 
 * Created by SharpDevelop.
 * User: Enikeishik
 * Date: 19.12.2017
 * Time: 8:15
 * 
 * @copyright   Copyright (C) 2005 - 2017 Enikeishik <enikeishik@gmail.com>. All rights reserved.
 * @author      Enikeishik <enikeishik@gmail.com>
 * @license     GNU General Public License version 2 or later; see LICENSE.txt
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Siren
{
    /// <summary>
    /// Events list form.
    /// </summary>
    public partial class SirenEventsForm : Form
    {
        private int sortColumn = -1;
        
        public SirenEventsForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
            EventsFormInteracted = false;
            EventFormDisplayed = false;
        }
        
        private SirenEvents sirenEvents;
        
        public bool EventsFormInteracted
        {
            get; set;
        }
        
        public bool EventFormDisplayed
        {
            get; set;
        }
        
        public string Title
        {
            get { return Text; }
            set { Text = value; }
        }
        
        private void AddSirenEvent()
        {
            SirenEventForm seForm = new SirenEventForm();
            seForm.Timestamp = SirenEvent.GetCurretnTimestamp();
            seForm.dateTimePicker1.Value = DateTime.Now;
            seForm.textBox1.Text = "";
            EventFormDisplayed = true;
            DialogResult result = seForm.ShowDialog(this);
            EventFormDisplayed = false;
            if (result == DialogResult.Cancel)
                return;
            
            SirenEvent se = new SirenEvent(
                seForm.dateTimePicker1.Value, 
                seForm.textBox1.Text
            );
            
            sirenEvents.Add(se);
            try {
                sirenEvents.Flush();
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
                return;
            }
            
            AddListItem(se);
        }
        
        private void EditSirenEvent()
        {
            ListView.SelectedListViewItemCollection lvs = listView1.SelectedItems;
            if (1 != lvs.Count)
                return;
            
            SirenEvent se;
            try {
                se = sirenEvents.Find(Int32.Parse(lvs[0].Name));
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
                return;
            }
            
            if (null == se)
                MessageBox.Show("Item not found");
            
            SirenEventForm seForm = new SirenEventForm();
            seForm.Timestamp = se.Timestamp;
            seForm.dateTimePicker1.Value = se.DateTimeFromTimestamp;
            seForm.textBox1.Text = se.EventText;
            EventFormDisplayed = true;
            DialogResult result = seForm.ShowDialog(this);
            EventFormDisplayed = false;
            if (result == DialogResult.Cancel)
                return;
            
            SirenEvent newSe = new SirenEvent(
                seForm.dateTimePicker1.Value, 
                seForm.textBox1.Text
            );
            
            sirenEvents.Remove(se.Timestamp);
            sirenEvents.Add(newSe);
            try {
                sirenEvents.Flush();
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
                return;
            }
            
            lvs[0].Remove();
            AddListItem(newSe);
        }
        
        private void RemoveSirenEvent()
        {
            ListView.SelectedListViewItemCollection lvs = listView1.SelectedItems;
            if (1 != lvs.Count)
                return;
            
            try {
                sirenEvents.Remove(Int32.Parse(lvs[0].Name));
                sirenEvents.Flush();
                lvs[0].Remove();
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
                return;
            }
        }
        
        protected void AddListItem(SirenEvent se)
        {
            string key = se.Timestamp.ToString();
            
            ListViewItem lvi =
                listView1.Items.Add(
                    key, 
                    se.DateTimeFromTimestamp.ToString(), 
                    ""
                );
            
            lvi.SubItems.Add(se.EventText);
            
            if (se.Expired) {
                lvi.BackColor = Color.Pink;
            }
            
            listView1.Sort();
            
            listView1.Items[key].Selected = true;
        }
        
        void SirenEventsFormLoad(object sender, EventArgs e)
        {
            Int32 currentTimestamp = SirenEvent.GetCurretnTimestamp();
            
            sirenEvents = NotificationIcon.SirenEvents;
            
            listView1.ListViewItemSorter = 
                new ListViewItemComparer(
                    (-1 != sortColumn ? sortColumn : 0),
                    listView1.Sorting
                );
            
            foreach (SirenEvent se in sirenEvents) {
                AddListItem(se);
            }
        }
        
        void SirenEventsFormActivated(object sender, EventArgs e)
        {
            EventsFormInteracted = true;
        }
        
        void SirenEventsFormResize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                EventsFormInteracted = false;
            else
                EventsFormInteracted = true;
        }
        
        void SirenEventsFormClosed(object sender, FormClosedEventArgs e)
        {
            EventsFormInteracted = false;
            NotificationIcon.EventsFormDisplayed = false;
        }
        
        void ListView1DoubleClick(object sender, EventArgs e)
        {
            EditSirenEvent();
        }
        
        void ContextMenuStrip1Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ListView.SelectedListViewItemCollection lvs = listView1.SelectedItems;
            if (1 != lvs.Count) {
                contextMenuStrip1.Items["removeSelectedEventToolStripMenuItem"].Enabled = false;
                contextMenuStrip1.Items["editSelectedEventToolStripMenuItem"].Enabled = false;
            } else {
                contextMenuStrip1.Items["removeSelectedEventToolStripMenuItem"].Enabled = true;
                contextMenuStrip1.Items["editSelectedEventToolStripMenuItem"].Enabled = true;
            }
        }
        
        void AddEventToolStripMenuItemClick(object sender, EventArgs e)
        {
            AddSirenEvent();
        }
        
        void EditSelectedEventToolStripMenuItemClick(object sender, EventArgs e)
        {
            EditSirenEvent();
        }
        
        void RemoveSelectedEventToolStripMenuItemClick(object sender, EventArgs e)
        {
            RemoveSirenEvent();
        }
        
        void ListView1ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != sortColumn) {
                sortColumn = e.Column;
                listView1.Sorting = SortOrder.Ascending;
            } else {
                if (listView1.Sorting == SortOrder.Ascending)
                    listView1.Sorting = SortOrder.Descending;
                else
                    listView1.Sorting = SortOrder.Ascending;
            }
            this.listView1.ListViewItemSorter = new ListViewItemComparer(e.Column, listView1.Sorting);
            this.listView1.Sort();
        }
        
        void ListView1KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter) {
                EditSirenEvent();
            } else if (e.KeyChar == (char) Keys.Delete) {
                RemoveSirenEvent();
            }
        }
        void SirenEventsFormKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Escape) {
                this.Close();
            }
        }
    }
    
    class ListViewItemComparer : System.Collections.IComparer
    {
        private readonly int col;
        private SortOrder order;
        
        public ListViewItemComparer()
        {
            col = 0;
            order = SortOrder.Ascending;
        }
        
        public ListViewItemComparer(int column, SortOrder order)
        {
            col = column;
            this.order = order;
        }
        
        public int Compare(object x, object y)
        {
            int returnVal;
            try
            {
                System.DateTime firstDate = 
                        DateTime.Parse(((ListViewItem)x).SubItems[col].Text);
                System.DateTime secondDate = 
                        DateTime.Parse(((ListViewItem)y).SubItems[col].Text);
                returnVal = DateTime.Compare(firstDate, secondDate);
            } catch {
                returnVal = String.Compare(
                    ((ListViewItem) x).SubItems[col].Text, 
                    ((ListViewItem) y).SubItems[col].Text
                );
            }
            if (order == SortOrder.Descending)
                returnVal *= -1;
            return returnVal;
        }
    }
}
