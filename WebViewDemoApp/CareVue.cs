using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebViewDemoApp
{
    public partial class CareVue : Form
    {
        public CareVue()
        {
            InitializeComponent();
        }

        public DataGridView traceLogGrid {
            get { return this.dataGrid; }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            DisposeChildren();
            base.Dispose(disposing);
        }

        private void DisposeChildren()
        {
            if (mdtpAppComponent != null)
            {
                mdtpAppComponent.Dispose();
                this.Controls.Remove(mdtpAppComponent);
                mdtpAppComponent = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var callback = new WindowHandler.EnumThreadWindowsProc(HideWindows);
            var tid = AppDomain.GetCurrentThreadId();
            WindowHandler.EnumThreadWindows((uint)tid, callback, 0);

            Locked locked = new Locked();
            locked.Show();
        }

        private static bool HideWindows(IntPtr handle, int param)
        {
            if (WindowHandler.IsWindowVisible(handle))
            {
                var length = WindowHandler.GetWindowTextLength(handle);
                var caption = new StringBuilder(length + 1);
                WindowHandler.GetWindowText(handle, caption, caption.Capacity);

                if (caption.ToString() == "CareVue" || caption.ToString() == "PopOut")
                {
                    Console.WriteLine("Hiding a visible window: {0}", caption);
                    WindowHandler.ShowWindow(handle.ToInt32(), WindowHandler.SW_HIDE);
                }
            }
            return true;
        }
    }
}
