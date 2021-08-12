using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace WebViewDemoApp
{
    public class PopOutViewModel : AppViewModelBase, IDisposable
    {
        public ICommand TraceLogCommand { get; private set; }

        public PopOutViewModel()
            : base(true)
        {
        }
        public void Dispose()
        {
        }

    }
}
