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
        public SirenEventsForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }
        
        private SirenEvents sirenEvents;
        
        private void AddSirenEvent()
        {
            SirenEventForm seForm = new SirenEventForm();
            seForm.Timestamp = SirenEvent.GetCurretnTimestamp();
            seForm.dateTimePicker1.Value = DateTime.Now;
            seForm.textBox1.Text = "";
            DialogResult result = seForm.ShowDialog(this);
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
            DialogResult result = seForm.ShowDialog(this);
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
            ListViewItem lvi = 
                listView1.Items.Add(
                    se.Timestamp.ToString(), 
                    se.DateTimeFromTimestamp.ToString(), 
                    ""
                );
            
            lvi.SubItems.Add(se.EventText);
            
            if (se.Expired) {
                lvi.BackColor = Color.Pink;
            }
        }
        
        void SirenEventsFormLoad(object sender, EventArgs e)
        {
            Int32 currentTimestamp = SirenEvent.GetCurretnTimestamp();
            
            sirenEvents = NotificationIcon.SirenEvents;
            
            foreach (SirenEvent se in sirenEvents) {
                AddListItem(se);
            }
        }
        
        void SettingsFormClosed(object sender, FormClosedEventArgs e)
        {
            NotificationIcon.FormDisplayed = false;
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
    }
}
