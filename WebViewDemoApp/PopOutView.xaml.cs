using System;
using System.Collections.Generic;
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
    /// Interaction logic for PopOutView.xaml
    /// </summary>
    public partial class PopOutView : Window
    {
        public PopOutView()
        {
            InitializeComponent();
        }

        private async void OnClose(object sender, RoutedEventArgs e)
        {
            Task<bool> thas = this.AppBrowser.HasUnsavedChanges();
            bool has = await thas;
            if (!has) this.Close();
            else
            {
                var prompt =
                       MessageBox.Show(
                           "You have unsaved changes.  Are you sure you want to close and lose those changes?",
                           "Unsaved Changes",
                           MessageBoxButton.YesNo);

                if (prompt == MessageBoxResult.Yes)
                {
                    this.Close();
                }

            }
        }
    }
}
