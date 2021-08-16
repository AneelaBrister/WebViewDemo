using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Input;

namespace WebViewDemoApp
{
    public class MainViewModel : AppViewModelBase, IDisposable
    {
        private bool _isPoppedOut = false;

        public ICommand PopoutCommand { get; private set; }
        public ICommand LaunchExternalCommand { get; private set; }

        public MainViewModel()
            : base(false)
        {
            PopoutCommand = new MyPopoutCommand(this);
            LaunchExternalCommand = new MyLaunchExternalCommand(this);

        }


        public void LoadStart()
        {
            Load();
        }

        private void Load()
        {
        
        }

        private string GetPoppedOutHTML()
        {
            var html = "<html><head></head><body> application is popped out.</body></html>";
            return html;
        }

        class MyLaunchExternalCommand : ICommand
        {
            private readonly MainViewModel _vm;

            public MyLaunchExternalCommand(MainViewModel vm)
            {
                _vm = vm;
            }


            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                //var url = _vm.GetExternalURLtoLoad(_vm.CurrentUrl);
                //_vm.UrlToTraceLog(url, "External");
                //Process.Start(url);
            }
        }

        class MyPopoutCommand : ICommand
        {
            //private readonly ICommandExecutor _cmdExec;
            private readonly MainViewModel _vm;

            public MyPopoutCommand(MainViewModel vm)
            {
                //_cmdExec = cmdExec;
                _vm = vm;
            }

            public void Execute(object parameter)
            {
                try
                {
                    //TODO:  create a blank page in the app to navigate to.  Until then, logging out and displaying HTML locally.
                    var html = _vm.GetPoppedOutHTML();
                    //var url = _vm.GetURLToLoad(true, _vm.CurrentUrl);
                    //_vm.NavData = new ContentNavigationData(html, () =>
                    //{
                    //    _cmdExec.Execute(new PopOutAppCommand(url));
                    //});
                    Debug.WriteLine("Popout4");
                    var view = new PopOutView();
                    var viewModel = new PopOutViewModel();
                    view.DataContext = viewModel;
                    view.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            public bool CanExecute(object parameter)
            {
                return true;  //what should we check for here???
            }

            public event EventHandler CanExecuteChanged;
        }

        public void Dispose()
        {
            try
            {
                //Logout();  want to do this here, but getting bad error i can't figure out.   giving up for now
                //if (_eventAggregator != null)
                //{
                //    _eventAggregator.RemoveListener<AppRefreshEvent>(this);
                //    _eventAggregator.RemoveListener<AppResetEvent>(this);
                //    _eventAggregator.RemoveListener<PopOutOpenedEvent>(this);
                //    _eventAggregator.RemoveListener<PopOutClosedEvent>(this);
                //}
            }
            catch (Exception ex)
            {
                //swallow errors on dispose for now
                //MessageBox.Show(ex.Message);

            }
        }
    }
}
