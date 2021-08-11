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
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public ICommand PopoutCommand { get; private set; }

        public MainView()
        {
            InitializeComponent();
            PopoutCommand = new MyPopoutCommand();
        }

        class MyPopoutCommand : ICommand
        {
            public MyPopoutCommand()
            {
            }

            public void Execute(object parameter)
            {
                var view = new PopOutView();
                view.DataContext = view;
                view.ShowDialog();

            }

            public bool CanExecute(object parameter)
            {
                return true;  //what should we check for here???
            }

            public event EventHandler CanExecuteChanged;
        }
    }
}
