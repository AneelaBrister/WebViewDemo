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
        IdleHelper _idleHelper;
        public CareVue()
        {
            InitializeComponent();
            _idleHelper = new IdleHelper();
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
            _idleHelper.Lock();
        }
    }
}
