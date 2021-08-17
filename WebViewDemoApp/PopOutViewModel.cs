using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Navigation;

namespace WebViewDemoApp
{
    public class PopOutViewModel : AppViewModelBase, IDisposable
    {
        public PopOutViewModel(DataGridView traceLog)
            : base(true, traceLog)
        {
        }
        public void Dispose()
        {
        }

    }
}
