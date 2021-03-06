﻿/**
 * Siren
 * Simple event notifyer
 * 
 * Created by SharpDevelop.
 * User: Enikeishik
 * Date: 19.12.2017
 * Time: 15:08
 * 
 * @copyright   Copyright (C) 2005 - 2017 Enikeishik <enikeishik@gmail.com>. All rights reserved.
 * @author      Enikeishik <enikeishik@gmail.com>
 * @license     GNU General Public License version 2 or later; see LICENSE.txt
 */

namespace Siren
{
    partial class SirenEventForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btn5min;
        private System.Windows.Forms.Button btn30min;
        private System.Windows.Forms.Button btn2hours;
        private System.Windows.Forms.Button btn6hours;
        private System.Windows.Forms.Button btn1day;
        
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
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btn5min = new System.Windows.Forms.Button();
            this.btn30min = new System.Windows.Forms.Button();
            this.btn2hours = new System.Windows.Forms.Button();
            this.btn6hours = new System.Windows.Forms.Button();
            this.btn1day = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Event DateTime";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 32);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(260, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "EventText";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 116);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(259, 92);
            this.textBox1.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(65, 227);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(146, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // btn5min
            // 
            this.btn5min.Location = new System.Drawing.Point(13, 58);
            this.btn5min.Name = "btn5min";
            this.btn5min.Size = new System.Drawing.Size(45, 23);
            this.btn5min.TabIndex = 2;
            this.btn5min.Text = "+5m";
            this.btn5min.UseVisualStyleBackColor = true;
            this.btn5min.Click += new System.EventHandler(this.Btn5minClick);
            // 
            // btn30min
            // 
            this.btn30min.Location = new System.Drawing.Point(64, 58);
            this.btn30min.Name = "btn30min";
            this.btn30min.Size = new System.Drawing.Size(45, 23);
            this.btn30min.TabIndex = 3;
            this.btn30min.Text = "+30m";
            this.btn30min.UseVisualStyleBackColor = true;
            this.btn30min.Click += new System.EventHandler(this.Btn30minClick);
            // 
            // btn2hours
            // 
            this.btn2hours.Location = new System.Drawing.Point(115, 58);
            this.btn2hours.Name = "btn2hours";
            this.btn2hours.Size = new System.Drawing.Size(45, 23);
            this.btn2hours.TabIndex = 4;
            this.btn2hours.Text = "+2h";
            this.btn2hours.UseVisualStyleBackColor = true;
            this.btn2hours.Click += new System.EventHandler(this.Btn2hoursClick);
            // 
            // btn6hours
            // 
            this.btn6hours.Location = new System.Drawing.Point(166, 58);
            this.btn6hours.Name = "btn6hours";
            this.btn6hours.Size = new System.Drawing.Size(45, 23);
            this.btn6hours.TabIndex = 5;
            this.btn6hours.Text = "+6h";
            this.btn6hours.UseVisualStyleBackColor = true;
            this.btn6hours.Click += new System.EventHandler(this.Btn6hoursClick);
            // 
            // btn1day
            // 
            this.btn1day.Location = new System.Drawing.Point(217, 58);
            this.btn1day.Name = "btn1day";
            this.btn1day.Size = new System.Drawing.Size(45, 23);
            this.btn1day.TabIndex = 6;
            this.btn1day.Text = "+1d";
            this.btn1day.UseVisualStyleBackColor = true;
            this.btn1day.Click += new System.EventHandler(this.Btn1dayClick);
            // 
            // SirenEventForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.ControlBox = false;
            this.Controls.Add(this.btn1day);
            this.Controls.Add(this.btn6hours);
            this.Controls.Add(this.btn2hours);
            this.Controls.Add(this.btn30min);
            this.Controls.Add(this.btn5min);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SirenEventForm";
            this.ShowInTaskbar = false;
            this.Text = "Event";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
