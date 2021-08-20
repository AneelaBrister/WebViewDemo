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
        IdleHelper _idleHelper;

        public Locked(IdleHelper idle)
        {
            InitializeComponent();
            _idleHelper = idle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _idleHelper.Unlock();
            this.Hide();
        }
    }
}
