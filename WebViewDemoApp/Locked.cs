using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebViewDemoApp
{
    public partial class Locked : Form
    {
        public Locked()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var callback = new WindowHandler.EnumThreadWindowsProc(ShowWindows);
            var tid = AppDomain.GetCurrentThreadId();
            WindowHandler.EnumThreadWindows((uint)tid, callback, 0);

            this.Hide();
        }

        private static bool ShowWindows(IntPtr handle, int param)
        {
            if (!WindowHandler.IsWindowVisible(handle))
            {
                var length = WindowHandler.GetWindowTextLength(handle);
                var caption = new StringBuilder(length + 1);
                WindowHandler.GetWindowText(handle, caption, caption.Capacity);

                if (caption.ToString() == "CareVue" || caption.ToString() == "PopOut")
                {
                    Console.WriteLine("Shwing a hidden window: {0}", caption);
                    WindowHandler.ShowWindow(handle.ToInt32(), WindowHandler.SW_SHOW);
                }
            }
            return true;
        }
    }
}
