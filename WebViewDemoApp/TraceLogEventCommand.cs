using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace WebViewDemoApp
{
    public class TraceLogEventCommand : ICommand
    {
        DataGridView _traceLog;
        public TraceLogEventCommand(DataGridView traceLog)
        {
            Debug.WriteLine("constrcting TraceLogEventCommand");
            _traceLog = traceLog;
        }

        public void Execute(object parameter)
        {
            var args = parameter as TraceLogEventArgs;
            if (args != null)
            {
                Debug.WriteLine("Trace Execute", args.TraceMessages);
                string[] row = { args.TraceType, args.TraceTitle, args.TraceMessages };
                _traceLog.Rows.Add(row);
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}
