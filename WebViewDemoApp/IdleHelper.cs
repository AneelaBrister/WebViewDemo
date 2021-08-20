using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebViewDemoApp
{

    public class IdleHelper
    {
        Timer _timer;
        IntPtr _keyHook;
        IntPtr _mouseHook;
        WindowHandler.HookProc _hookCallback;
        Locked _locked;

        public IdleHelper()
        {
            _timer = new Timer();
            _timer.Tick += _timer_Tick;
            StartIdleTimer();
        }

        void StartIdleTimer()
        {
            _timer.Interval = 30000;
            _timer.Start();
            var tid = AppDomain.GetCurrentThreadId();
            _hookCallback = new WindowHandler.HookProc(UIHookProc);
            _keyHook = WindowHandler.SetWindowsHookEx(WindowHandler.WH_KEYBOARD, _hookCallback, IntPtr.Zero, (uint)tid);
            _mouseHook = WindowHandler.SetWindowsHookEx(WindowHandler.WH_MOUSE, _hookCallback, IntPtr.Zero, (uint)tid);
        }

        void StopIdleTimer()
        {
            _timer.Stop();
            WindowHandler.UnhookWindowsHookEx(_keyHook);
            WindowHandler.UnhookWindowsHookEx(_mouseHook);
            _keyHook = IntPtr.Zero; _mouseHook = IntPtr.Zero;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            StopIdleTimer();
            Lock();
        }

        public int UIHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            _timer.Stop();
            _timer.Start();
            return WindowHandler.CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        public void Lock()
        {
            var callback = new WindowHandler.EnumThreadWindowsProc(HideWindows);
            var tid = AppDomain.GetCurrentThreadId();
            WindowHandler.EnumThreadWindows((uint)tid, callback, 0);

            _locked = new Locked(this);
            _locked.Show();
        }

        public void Unlock()
        {
            var callback = new WindowHandler.EnumThreadWindowsProc(ShowWindows);
            var tid = AppDomain.GetCurrentThreadId();
            WindowHandler.EnumThreadWindows((uint)tid, callback, 0);
            StartIdleTimer();
        }

        private static bool ShowWindows(IntPtr handle, int param)
        {
            if (!WindowHandler.IsWindowVisible(handle))
            {
                var length = WindowHandler.GetWindowTextLength(handle);
                var caption = new StringBuilder(length + 1);
                WindowHandler.GetWindowText(handle, caption, caption.Capacity);

                if (caption.ToString() == "CareVue" || caption.ToString() == "PopOut")
                {
                    Console.WriteLine("Shwing a hidden window: {0}", caption);
                    WindowHandler.ShowWindow(handle.ToInt32(), WindowHandler.SW_SHOW);
                }
            }
            return true;
        }

        private static bool HideWindows(IntPtr handle, int param)
        {
            if (WindowHandler.IsWindowVisible(handle))
            {
                var length = WindowHandler.GetWindowTextLength(handle);
                var caption = new StringBuilder(length + 1);
                WindowHandler.GetWindowText(handle, caption, caption.Capacity);

                if (caption.ToString() == "CareVue" || caption.ToString() == "PopOut")
                {
                    Console.WriteLine("Hiding a visible window: {0}", caption);
                    WindowHandler.ShowWindow(handle.ToInt32(), WindowHandler.SW_HIDE);
                }
            }
            return true;
        }
    }
}
