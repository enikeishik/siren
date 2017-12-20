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
