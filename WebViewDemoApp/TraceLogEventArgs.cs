using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WebViewDemoApp
{
    public class TraceLogEventArgs : RoutedEventArgs
    {
        public TraceLogEventArgs(RoutedEvent rEvent, string type, string title, string messages) : base(rEvent)
        {
            TraceType = type;
            TraceTitle = title;
            TraceMessages = messages;
        }

        public string TraceType { get; private set; }
        public string TraceTitle { get; private set; }
        public string TraceMessages { get; private set; }
    }
}
