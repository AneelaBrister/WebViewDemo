using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;

namespace WebViewDemoApp
{
    public class AppViewModelBase : INotifyPropertyChanged
    {
        private readonly bool _isPopOut;
        private AppBrowserControl _browserControl;

        public ICommand TraceLogCommand { get; private set; }

        private bool _senderIsCommand;

        public AppViewModelBase(bool isPopOut, DataGridView traceLog)
        {
            _isPopOut = isPopOut;
            if (traceLog != null)
            {
                Debug.WriteLine("Received traceLog + for popout: " + isPopOut.ToString());
            }
            TraceLogCommand = new TraceLogEventCommand(traceLog);
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
                       System.Windows.MessageBox.Show(
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

        public bool HasUnsavedChanges
        {
            get { return _browserControl != null /* && _browserControl.HasUnsavedChanges */ ; }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
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
