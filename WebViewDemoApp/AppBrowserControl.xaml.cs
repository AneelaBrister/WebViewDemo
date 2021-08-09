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
    /// Interaction logic for AppBrowserControl.xaml
    /// </summary>
    public partial class AppBrowserControl : UserControl
    {
        public AppBrowserControl()
        {
            InitializeComponent();
            this.Unloaded += AppBrowserControl_Unloaded;
        }

        public void AppBrowserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            if (Browser != null)
            {
                Browser.Dispose();
                Browser = null;
            }
        }
    }
}
