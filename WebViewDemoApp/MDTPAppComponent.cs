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
    public partial class MDTPAppComponent : Form
    {
        public MDTPAppComponent()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var view = new MainView();
            view.DataContext = view;
            elementHost1.Child = view;
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
            if (elementHost1 != null)
            {
                elementHost1.Dispose();
                this.tabPage1.Controls.Remove(elementHost1);
                elementHost1 = null;
            }
        }

    }
}
