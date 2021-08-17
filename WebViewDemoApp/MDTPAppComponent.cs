using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebViewDemoApp
{
    public partial class MDTPAppComponent : UserControl
    {
        public MDTPAppComponent()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var view = new MainView();
            CareVue parent = this.ParentForm as CareVue;
            DataGridView traceLog = null;
            if (parent != null) traceLog = parent.traceLogGrid;
            var viewModel = new MainViewModel(traceLog);
            view.DataContext = viewModel;
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
                this.Controls.Remove(elementHost1);
                elementHost1 = null;
            }
        }
    }

}
