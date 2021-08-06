using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WebViewDemoApp
{
    /// <summary>
    /// Interaction logic for WebViewControl.xaml
    /// </summary>
    public partial class WebViewControl : UserControl
    {
        public WebViewControl()
        {
            InitializeComponent();
        }

        public void DisposeWebview()
        {
            this.webView.Dispose();
        }
    }
}
