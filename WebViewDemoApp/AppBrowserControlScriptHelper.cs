using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Diagnostics;

namespace WebViewDemoApp
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class AppBrowserControlScriptHelper
    {
        private AppBrowserControl _browserControl;
        public AppBrowserControlScriptHelper(AppBrowserControl browserControl)
        {
            this._browserControl = browserControl;
        }


        public void PopOut()
        {
            Debug.WriteLine("Popout1");
            this._browserControl.PopOut();
        }
    }
}
