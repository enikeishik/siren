/*
 * Created by SharpDevelop.
 * User: Enikeishik
 * Date: 19.12.2017
 * Time: 15:08
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
    /// Siren event edit form.
    /// </summary>
    public partial class SirenEventForm : Form
    {
        public SirenEventForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }
        
        public int Timestamp
        {
            get; set;
        }
        
        void Btn5minClick(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddMinutes(5);
        }
        
        void Btn30minClick(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddMinutes(30);
        }
        
        void Btn2hourClick(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddHours(2);
        }
        
        void Btn6hourClick(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddHours(6);
        }
        
        void BtnSaveClick(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value <= DateTime.Now) {
                DialogResult result = 
                    MessageBox.Show(
                        "Event already expired! Continue?", 
                        "Event expired", 
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question
                    );
                if (result == DialogResult.Cancel)
                    return;
            }
                
            DialogResult = DialogResult.OK;
            Close();
        }
        
        void BtnCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
