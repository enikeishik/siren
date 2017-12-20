/*
 * Created by SharpDevelop.
 * User: pl
 * Date: 19.12.2017
 * Time: 15:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Siren
{
    /// <summary>
    /// Description of SirenEventForm.
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
        
        void BtnSaveClick(object sender, EventArgs e)
        {
            Close();
        }
        
        void BtnCancelClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
