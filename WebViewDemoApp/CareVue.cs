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
    public partial class CareVue : Form
    {
        public CareVue()
        {
            InitializeComponent();
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
    }
}
