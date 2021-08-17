using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WebViewDemoApp
{
    public class AppBrowserBehavior
    {

        public static readonly DependencyProperty PopoutCommand = EventBehaviourFactory
            .CreateCommandExecutionEventBehaviour
            (AppBrowserControl.AppPopOutEvent, "PopoutCommand", typeof(AppBrowserBehavior));

        public static void SetPopoutCommand(DependencyObject o, ICommand value)
        {
            o.SetValue(PopoutCommand, value);
        }

        public static ICommand GetPopoutCommand(DependencyObject o)
        {
            return o.GetValue(PopoutCommand) as ICommand;
        }


        public static readonly DependencyProperty TraceLogCommand = EventBehaviourFactory
            .CreateCommandExecutionEventBehaviour
            (AppBrowserControl.AppTraceEvent, "TraceLogCommand", typeof(AppBrowserBehavior));

        public static void SetTraceLogCommand(DependencyObject o, ICommand value)
        {
            o.SetValue(TraceLogCommand, value);
        }

        public static ICommand GetTraceLogCommand(DependencyObject o)
        {
            return o.GetValue(TraceLogCommand) as ICommand;
        }

    }
}
