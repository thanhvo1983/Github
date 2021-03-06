#pragma warning disable 0618
using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Permissions;
using Kvics.PInvoke;

[assembly: SecurityPermission(SecurityAction.RequestMinimum, UnmanagedCode = true)]
namespace Kvics.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class MessageBoxHook
    {
        /// <summary>
        /// 
        /// </summary>
        public enum HookButtons
        {
            OK = 0x00000001,
            Cancel = 0x00000002,
            Abort = 0x00000003,
            Retry = 0x00000004,
            Ignore = 0x00000005,
            Yes = 0x00000006,
            No = 0x00000007
        }

        /// <summary>
        /// 
        /// </summary>
        public class HookCaptions
        {
            public String OK = "&OK";
            public String Cancel = "&Cancel";
            public String Abort = "&Abort";
            public String Retry = "&Retry";
            public String Ignore = "&Ignore";
            public String Yes = "&Yes";
            public String No = "&No";
        }

        /// <summary>
        /// 
        /// </summary>
        public class HookData
        {
            public Int32 Type = User32.WH_CBT;
            public User32.HookProc Proc = (User32.HookProc)CBTProc;
            public IntPtr Hook = IntPtr.Zero;
        }

        /// <summary>
        /// 
        /// </summary>
        public static HookCaptions Captions = new HookCaptions();

        /// <summary>
        /// 
        /// </summary>
        public static HookData Data = new HookData();

        /// <summary>
        /// 
        /// </summary>
        public static String IconFile = "";

        /// <summary>
        /// 
        /// </summary>
        public static Int32 IconIndex = 0;        

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Boolean Install()
        {
            if (Data.Hook == IntPtr.Zero)
            {
                try
                {
                    Data.Hook = User32.SetWindowsHookEx(Data.Type, Data.Proc,
                        IntPtr.Zero, Kernel32.GetCurrentThreadId());
                }
                catch
                {

                }
            }
            else
            {
                throw new NotSupportedException("One hook per thread allowed.");
            }

            if (Data.Hook != IntPtr.Zero)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Boolean Uninstall()
        {
            Boolean bRet = false;
            if (Data.Hook != IntPtr.Zero)
            {
                bRet = User32.UnhookWindowsHookEx(Data.Hook);
                Data.Hook = IntPtr.Zero;
            }
            return bRet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public static Int32 CBTProc(Int32 nCode, IntPtr wParam, IntPtr lParam)
        {
	        if (nCode == User32.HCBT_ACTIVATE) {
                if (User32.GetDlgItem(wParam, (Int32)HookButtons.OK) != IntPtr.Zero)
                {
                    User32.SetDlgItemText(wParam, (Int32)HookButtons.OK, Captions.OK);
		        }

                if (User32.GetDlgItem(wParam, (Int32)HookButtons.Cancel) != IntPtr.Zero)
                {
                    User32.SetDlgItemText(wParam, (Int32)HookButtons.Cancel, Captions.Cancel);
		        }

                if (User32.GetDlgItem(wParam, (Int32)HookButtons.Abort) != IntPtr.Zero)
                {
                    User32.SetDlgItemText(wParam, (Int32)HookButtons.Abort, Captions.Abort);
		        }

                if (User32.GetDlgItem(wParam, (Int32)HookButtons.Retry) != IntPtr.Zero)
                {
                    User32.SetDlgItemText(wParam, (Int32)HookButtons.Retry, Captions.Retry);
		        }

                if (User32.GetDlgItem(wParam, (Int32)HookButtons.Ignore) != IntPtr.Zero)
                {
                    User32.SetDlgItemText(wParam, (Int32)HookButtons.Ignore, Captions.Ignore);
		        }

                if (User32.GetDlgItem(wParam, (Int32)HookButtons.Yes) != IntPtr.Zero)
                {
                    User32.SetDlgItemText(wParam, (Int32)HookButtons.Yes, Captions.Yes);
		        }

                if (User32.GetDlgItem(wParam, (Int32)HookButtons.No) != IntPtr.Zero)
                {
                    User32.SetDlgItemText(wParam, (Int32)HookButtons.No, Captions.No);
		        }

                if (IconFile.Length > 0)
                {
                    IntPtr hwndIcon = User32.GetDlgItem(wParam, 0x0014);
                    IntPtr hIcon = Shell32.ExtractIcon(IntPtr.Zero, IconFile, IconIndex);
                    if (!(hwndIcon == IntPtr.Zero || hIcon == IntPtr.Zero))
                    {
                        User32.SendMessage(new System.Runtime.InteropServices.HandleRef(null, hwndIcon), User32.STM_SETICON, hIcon, IntPtr.Zero);
                    }
                }

                Uninstall();
	        }

            return User32.CallNextHookEx(Data.Hook, nCode, wParam, lParam);
        }
    }
}
