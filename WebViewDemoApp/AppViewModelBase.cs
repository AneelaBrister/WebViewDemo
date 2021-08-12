using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace WebViewDemoApp
{
    public class AppViewModelBase : INotifyPropertyChanged
    {
        private readonly bool _isPopOut;
        private AppBrowserControl _browserControl;

        public ICommand TraceLogCommand { get; private set; }
        public ICommand AuthFailedCommand { get; private set; }
        public ICommand RefreshDataCommand { get; private set; }
        public ICommand CloseCommand { get; protected set; }
        public ICommand ClosingCommand { get; protected set; }
        public ICommand WebAppOperationCommand { get; private set; }
        public ICommand PromptForVisitCommand { get; private set; }
        public ICommand NoteDeletedCommand { get; private set; }

        private bool _senderIsCommand;

        public AppViewModelBase(bool isPopOut)
        {
            _isPopOut = isPopOut;

            if (_isPopOut)
            {
                //CloseCommand = new CommandRelay(o =>
                //{
                //    _senderIsCommand = false;
                //    if (CloseIt())
                //    {
                //        _senderIsCommand = true;  //this is going to fire ClosingCommand, so let it know to ignore the call
                //        DialogResult = true;
                //    }
                //});
                //ClosingCommand = new CommandRelay(o =>
                //{
                //    var args = o as CancelEventArgs;
                //    if (args != null)
                //    {
                //        if (!_senderIsCommand)
                //        {
                //            if (!CloseIt())
                //            {
                //                args.Cancel = true;
                //            }
                //        }
                //        _senderIsCommand = false;
                //    }
                //}, o => true);
            }

            //RefreshDataCommand = new CommandRelay(o =>
            //{
            //    _session.EventFireLocal("REFRESH", "");
            //});

            //WebAppOperationCommand = new CommandRelay(o =>
            //{
            //    var args = o as WebAppOperationEventArgs;
            //    if (_webAppOperationConsumer != null && _webAppOperationConsumer.CanConsume(args.Operation))
            //    {
            //        _webAppOperationConsumer.Consume(args.Operation);
            //    }
            //    else
            //    {
            //        args.Operation.Reject("Not Implemented");
            //    }
            //});

            //PromptForVisitCommand = new CommandRelay(o =>
            //{
            //    _visitContext.EnsureVisit();
            //});

        }

        public void InitBrowser(AppBrowserControl myBrowserControl)
        {
            _browserControl = myBrowserControl;
        }

        private bool CloseIt()
        {
            if (HasUnsavedChanges)
            {
                var prompt =
                       MessageBox.Show(
                           "You have unsaved changes.  Are you sure you want to close and lose those changes?",
                           "Unsaved Changes",
                           MessageBoxButton.YesNo);

                if (prompt != MessageBoxResult.Yes)
                {
                    return false;
                }
            }

            //CleanupApp();

            return true;
        }

        //ChangeNotifier<NavigationData> _navdata;
        //public NavigationData NavData
        //{
        //    get { return _navdata.Value; }
        //    set
        //    {
        //        _navdata.Value = value;
        //    }
        //}

        //ChangeNotifier<string> _currentUrl;
        ////This will ignore you if you try to update the browser's url from here.
        ////Use NavData instead
        //public string CurrentUrl
        //{
        //    get { return _currentUrl.Value; }
        //    set { _currentUrl.Value = value; }
        //}

        //private ChangeNotifier<string> _selectedVisitStr;

        //public string SelectedVisitStr
        //{
        //    get
        //    {
        //        return _selectedVisitStr.Value;
        //    }
        //    set { _selectedVisitStr.Value = value; }
        //}

        //void _visitContext_VisitChanged(object sender, EventArgs e)
        //{
        //    _selectedVisitStr.Value = _visitContext.VisitString;
        //}

        //private ChangeNotifier<OVAuthInfoProvider> _authInfoProviderInstance;

        //public OVAuthInfoProvider AuthInfoProviderInstance
        //{
        //    get { return _authInfoProviderInstance.Value; }
        //    set { _authInfoProviderInstance.Value = value; }
        //}

        public bool HasUnsavedChanges
        {
            get { return _browserControl != null /* && _browserControl.HasUnsavedChanges */ ; }
        }


        //ChangeNotifier<bool?> _dialog_result = null;
        //public bool? DialogResult
        //{
        //    get { return _dialog_result.Value; }
        //    protected set { _dialog_result.Value = value; }
        //}

        //protected void UrlToTraceLog(string url)
        //{
        //    var who = _isPopOut ? "Popout" : "Component";
        //    var args = new TraceLogEventArgs(null, _serviceInfo.DisplayName, who + " URL", url);
        //    TraceLogCommand.Execute(args);
        //}

        //protected void UrlToTraceLog(string url, string who)
        //{
        //    var args = new TraceLogEventArgs(null, _serviceInfo.DisplayName, who + " URL", url);
        //    TraceLogCommand.Execute(args);
        //}

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        //protected void NotifyPropertyChanged ([CallerMemberName] String propertyName = "")
        //{
        //	this.OnPropertyChanged (propertyName);
        //	if (PropertyChanged != null) {
        //		PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
        //	}
        //}

        public virtual void NotifyPropertyChanged(string property_name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property_name));
        }

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        #endregion
    }
}
