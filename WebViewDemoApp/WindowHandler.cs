using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WebViewDemoApp
{
    public static class WindowHandler
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public delegate bool EnumThreadWindowsProc(IntPtr handle, int param);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumThreadWindows(uint threadId,
            EnumThreadWindowsProc callback, int param);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowVisible(IntPtr handle);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int GetWindowText(
            IntPtr handle,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder caption,
            int count);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int GetWindowTextLength(IntPtr handle);

        [DllImport("User32.dll")]
        public static extern int ShowWindow(int hwnd, int nCmdShow);

        public const int SW_HIDE = 0;
        public const int SW_SHOW = 5;

    }
}
