/*
 * Created by SharpDevelop.
 * User: pl
 * Date: 19.12.2017
 * Time: 8:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Siren
{
    partial class SirenEventsForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addEventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedEventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSelectedEventToolStripMenuItem;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SirenEventsForm));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSelectedEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.Size = new System.Drawing.Size(484, 262);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.ListView1DoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "DateTime";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 140;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Text";
            this.columnHeader3.Width = 300;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEventToolStripMenuItem,
            this.editSelectedEventToolStripMenuItem,
            this.removeSelectedEventToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(196, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip1Opening);
            // 
            // addEventToolStripMenuItem
            // 
            this.addEventToolStripMenuItem.Name = "addEventToolStripMenuItem";
            this.addEventToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.addEventToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.addEventToolStripMenuItem.Text = "Add event";
            this.addEventToolStripMenuItem.Click += new System.EventHandler(this.AddEventToolStripMenuItemClick);
            // 
            // editSelectedEventToolStripMenuItem
            // 
            this.editSelectedEventToolStripMenuItem.Name = "editSelectedEventToolStripMenuItem";
            this.editSelectedEventToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.editSelectedEventToolStripMenuItem.Text = "Edit selected event";
            this.editSelectedEventToolStripMenuItem.Click += new System.EventHandler(this.EditSelectedEventToolStripMenuItemClick);
            // 
            // removeSelectedEventToolStripMenuItem
            // 
            this.removeSelectedEventToolStripMenuItem.Name = "removeSelectedEventToolStripMenuItem";
            this.removeSelectedEventToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.removeSelectedEventToolStripMenuItem.Text = "Remove selected event";
            this.removeSelectedEventToolStripMenuItem.Click += new System.EventHandler(this.RemoveSelectedEventToolStripMenuItemClick);
            // 
            // SirenEventsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 262);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SirenEventsForm";
            this.Text = "Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsFormClosed);
            this.Load += new System.EventHandler(this.SirenEventsFormLoad);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
