/*
 * Created by SharpDevelop.
 * User: Enikeishik
 * Date: 18.12.2017
 * Time: 17:19
 * 
 * @copyright   Copyright (C) 2005 - 2017 Enikeishik <enikeishik@gmail.com>. All rights reserved.
 * @author      Enikeishik <enikeishik@gmail.com>
 * @license     GNU General Public License version 2 or later; see LICENSE.txt
 */
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace Siren
{
    public sealed class NotificationIcon
    {
        private static readonly string eventsFilePath = "events.txt";
        private NotifyIcon notifyIcon;
        private ContextMenu notificationMenu;
        private static System.Windows.Forms.Timer timer;
        private static SirenEventsForm eventsForm;
        
        public static bool EventsFormDisplayed
        {
            get; set;
        }
        
        public static SirenEvents SirenEvents
        {
            get; set;
        }
        
        static NotificationIcon()
        {
            eventsFilePath = Path.Combine(
                Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), 
                eventsFilePath
            );
            EventsFormDisplayed = false;
        }
        
        #region Initialize icon and menu
        public NotificationIcon()
        {
            notifyIcon = new NotifyIcon();
            notificationMenu = new ContextMenu(InitializeMenu());
            
            notifyIcon.DoubleClick += IconDoubleClick;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationIcon));
            notifyIcon.Icon = (Icon) resources.GetObject("$this.Icon");
            notifyIcon.ContextMenu = notificationMenu;
            notifyIcon.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            notifyIcon.BalloonTipText = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
        }
        
        private MenuItem[] InitializeMenu()
        {
            MenuItem[] menu = new MenuItem[] {
                new MenuItem("Events", menuEventsClick),
                new MenuItem("Exit", menuExitClick)
            };
            return menu;
        }
        #endregion
        
        #region Main - Program entry point
        /// <summary>Program entry point.</summary>
        /// <param name="args">Command Line Arguments</param>
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            try {
                SirenEvents = new SirenEvents(eventsFilePath);
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
                Application.Exit();
            }
            
            bool isFirstInstance;
            // Please use a unique name for the mutex to prevent conflicts with other programs
            string appName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            using (Mutex mtx = new Mutex(true, appName, out isFirstInstance)) {
                if (isFirstInstance) {
                    NotificationIcon notificationIcon = new NotificationIcon();
                    notificationIcon.notifyIcon.Visible = true;
                    timer = new System.Windows.Forms.Timer();
                    timer.Tick += new EventHandler(TimerHandler);
                    timer.Interval = 2000;
                    timer.Enabled = true;
                    timer.Start();
                    Application.Run();
                    notificationIcon.notifyIcon.Dispose();
                } else {
                    // The application is already running
                    MessageBox.Show(
                        "Application already running, look at system tray icon", 
                        "Application already running", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Asterisk
                    );
                }
            } // releases the Mutex
        }
        #endregion
        
        private static void TimerHandler(object sender, EventArgs e)
        {
            SirenEvent se = SirenEvents.FindExpired();
            if (null != se) {
                ShowSirenEventsForm(true);
            }
        }
        
        private static void ShowSirenEventsForm(bool minimized = false)
        {
            if (EventsFormDisplayed) {
                if (eventsForm.EventsFormInteracted && !eventsForm.EventFormDisplayed)
                    eventsForm.Activate();
                else
                    FormFlasher.FlashWindowEx(eventsForm);
                return;
            }
            
            if (null != eventsForm)
                eventsForm.Dispose();
            eventsForm = null;
            eventsForm = new SirenEventsForm();
            
            //TODO: place event info in form title
            eventsForm.Text += " alert";
            
            if (minimized)
                eventsForm.WindowState = FormWindowState.Minimized;
            eventsForm.Show();
            if (minimized)
                FormFlasher.FlashWindowEx(eventsForm);
            
            EventsFormDisplayed = true;
        }
        
        #region Event Handlers
        private void menuEventsClick(object sender, EventArgs e)
        {
            ShowSirenEventsForm();
        }
        
        private void menuExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void IconDoubleClick(object sender, EventArgs e)
        {
            ShowSirenEventsForm();
        }
        #endregion
    }
}
