using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Kvics.PInvoke
{
    public class Kernel32 
    {
        /// <summary>
        /// The GetProcessId function retrieves the process identifier of the specified process.
        /// 
        /// DWORD GetProcessId(
        ///     HANDLE Process
        /// );
        /// </summary>
        /// <param name="Process">
        /// [in] Handle to the process. The handle must have the PROCESS_QUERY_INFORMATION access right.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the process identifier of the specified process.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        /// <remarks>
        /// Until a process terminates, its process identifier uniquely identifies it on the system. 
        /// For more information about access rights, see Process Security and Access Rights.
        /// </remarks>
        [DllImport("kernel32.dll")]
        public static extern Int32 GetProcessId(IntPtr Process);

        [DllImport("kernel32.dll")]
        public static extern UInt32 GetCurrentThreadId();


        #region INI File Functions

        /// <summary>
        /// The GetPrivateProfileInt function retrieves an integer associated with a key in the 
        /// specified section of an initialization file.
        /// 
        /// UINT GetPrivateProfileInt(
        ///     LPCTSTR lpAppName,
        ///     LPCTSTR lpKeyName,
        ///     INT nDefault,
        ///     LPCTSTR lpFileName
        /// );
        /// </summary>
        /// <param name="lpAppName">
        /// [in] Pointer to a null-terminated string specifying the name of the section in the initialization file. 
        /// </param>
        /// <param name="lpKeyName">
        /// [in] Pointer to the null-terminated string specifying the name of the key 
        /// whose value is to be retrieved. This value is in the form of a string; 
        /// the GetPrivateProfileInt function converts the string into an integer and returns the integer. 
        /// </param>
        /// <param name="nDefault">
        /// [in] Default value to return if the key name cannot be found in the initialization file. 
        /// </param>
        /// <param name="lpFileName">
        /// [in] Pointer to a null-terminated string that specifies the name of the initialization file. 
        /// If this parameter does not contain a full path to the file, 
        /// the system searches for the file in the Windows directory. 
        /// </param>
        /// <returns>
        /// The return value is the integer equivalent of the string following the specified key name 
        /// in the specified initialization file. If the key is not found, the return value is the specified default value. 
        /// </returns>
        [DllImport("kernel32.dll")]
        public static extern UInt32 GetPrivateProfileInt(String lpAppName, String lpKeyName,
          Int32 nDefault, String lpFileName);

        [DllImport("kernel32.dll")]
        public static extern UInt32 GetPrivateProfileSection(String lpAppName,
          IntPtr lpReturnedString, UInt32 nSize, String lpFileName);

        [DllImport("kernel32.dll")]
        public static extern UInt32 GetPrivateProfileSectionNames(IntPtr lpszReturnBuffer,
          UInt32 nSize, String lpFileName);

        [DllImport("kernel32.dll")]
        public static extern UInt32 GetPrivateProfileString(
            String lpAppName, String lpKeyName, String lpDefault,
            StringBuilder lpReturnedString, UInt32 nSize, String lpFileName);

        [DllImport("kernel32.dll")]
        public static extern UInt32 GetPrivateProfileString(
           String lpAppName, String lpKeyName, String lpDefault,
           [In, Out] Char[] lpReturnedString, UInt32 nSize, String lpFileName);

        [DllImport("kernel32.dll")]
        public static extern UInt32 GetPrivateProfileString(
           String lpAppName, String lpKeyName, String lpDefault,
           IntPtr lpReturnedString, UInt32 nSize, String lpFileName);

        [DllImport("kernel32.dll")]
        public static extern Boolean GetPrivateProfileStruct(String lpszSection, String lpszKey,
            IntPtr lpStruct, UInt32 uSizeStruct, String szFile);

        [DllImport("kernel32.dll")]
        public static extern UInt32 GetProfileInt(String lpAppName, String lpKeyName,
            Int32 nDefault);

        [DllImport("kernel32.dll")]
        public static extern UInt32 GetProfileSection(String lpAppName, IntPtr lpReturnedString,
            UInt32 nSize);

        [DllImport("kernel32.dll")]
        public static extern UInt32 GetProfileString(String lpAppName, String lpKeyName,
            String lpDefault, [Out] StringBuilder lpReturnedString, UInt32 nSize);

        [DllImport("kernel32.dll")]
        public static extern Boolean WritePrivateProfileSection(String lpAppName,
            String lpString, String lpFileName);

        [DllImport("kernel32.dll")]
        public static extern Boolean WritePrivateProfileString(String lpAppName,
            String lpKeyName, String lpString, String lpFileName);

        [DllImport("kernel32.dll")]
        public static extern Boolean WritePrivateProfileStruct(String lpszSection,
            String lpszKey, IntPtr lpStruct, UInt32 uSizeStruct, String szFile);

        [DllImport("kernel32.dll")]
        public static extern Boolean WriteProfileSection(String lpAppName, String lpString);

        [DllImport("kernel32.dll")]
        public static extern Boolean WriteProfileString(String lpAppName, String lpKeyName,
            String lpString);

        #endregion
    }

    public class Advapi32
    {
        /// <summary>
        /// The SID_IDENTIFIER_AUTHORITY structure represents the top-level authority of a security identifier (SID).
        /// typedef struct _SID_IDENTIFIER_AUTHORITY {  
        ///     BYTE Value[6];
        /// } SID_IDENTIFIER_AUTHORITY, *PSID_IDENTIFIER_AUTHORITY;
        /// 
        /// An array of 6 bytes specifying a SID's top-level authority. 
        /// </summary>
        /// <remarks>
        /// SECURITY_NULL_SID_AUTHORITY     0 
        /// SECURITY_WORLD_SID_AUTHORITY    1 
        /// SECURITY_LOCAL_SID_AUTHORITY    2 
        /// SECURITY_CREATOR_SID_AUTHORITY  3 
        /// SECURITY_NT_AUTHORITY           5 
        /// A SID must contain a top-level authority and at least one relative identifier (RID) value.
        /// </remarks>
        public struct SID_IDENTIFIER_AUTHORITY
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public Byte[] Value;

            public SID_IDENTIFIER_AUTHORITY(Byte[] value)
            {
                Value = value;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ACE_HEADER
        {
            public Byte AceType;
            public Byte AceFlags;
            public Int16 AceSize;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ACCESS_ALLOWED_ACE
        {
            public ACE_HEADER Header;
            public Int32 Mask;
            public Int32 SidStart;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ACL
        {
            public Byte AclRevision;
            public Byte Sbz1;
            public UInt16 AclSize;
            public UInt16 AceCount;
            public UInt16 Sbz2;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SECURITY_DESCRIPTOR
        {
            public Byte Revision;
            public Byte Sbz1;
            public Int16 Control;
            public IntPtr Owner;
            public IntPtr Group;
            public IntPtr Sacl;
            public IntPtr Dacl;
        }

        public const Int32 SECURITY_DIALUP_RID = 0x00000001;
        public const Int32 SECURITY_NETWORK_RID = 0x00000002;
        public const Int32 SECURITY_BATCH_RID = 0x00000003;
        public const Int32 SECURITY_INTERACTIVE_RID = 0x00000004;
        public const Int32 SECURITY_SERVICE_RID = 0x00000006;
        public const Int32 SECURITY_ANONYMOUS_LOGON_RID = 0x00000007;
        public const Int32 SECURITY_PROXY_RID = 0x00000008;
        public const Int32 SECURITY_ENTERPRISE_CONTROLLERS_RID = 0x00000009;
        public const Int32 SECURITY_SERVER_LOGON_RID = SECURITY_ENTERPRISE_CONTROLLERS_RID;
        public const Int32 SECURITY_PRINCIPAL_SELF_RID = 0x0000000A;
        public const Int32 SECURITY_AUTHENTICATED_USER_RID = 0x0000000B;
        public const Int32 SECURITY_RESTRICTED_CODE_RID = 0x0000000C;

        public const Int32 SECURITY_LOGON_IDS_RID = 0x00000005;
        public const Int32 SECURITY_LOGON_IDS_RID_COUNT = 3;

        public const Int32 SECURITY_LOCAL_SYSTEM_RID = 0x00000012;
        public const Int32 SECURITY_NT_NON_UNIQUE = 0x00000015;
        public const Int32 SECURITY_BUILTIN_DOMAIN_RID = 0x00000020;

        public const Int32 DACL_SECURITY_INFORMATION = 0x00000004;
        public const Int32 ERROR_INSUFFICIENT_BUFFER = 122;
        public const Int32 SECURITY_DESCRIPTOR_REVISION = 1;
        public const Int32 ACL_REVISION = 2;
        public const Int32 INHERITED_ACE = 0x10;

        public const UInt32 MAXDWORD = 0xffffffff;
        public const UInt32 GENERIC_READ = 0x80000000;
		public const UInt32 GENERIC_WRITE = 0x40000000;
        public const UInt32 GENERIC_EXECUTE = 0x20000000;

        public const Int32 OBJECT_INHERIT_ACE = 0x1;
        public const Int32 CONTAINER_INHERIT_ACE = 0x2;
        public const Int32 SE_DACL_AUTO_INHERIT_REQ = 0x0100;
        public const Int32 SE_DACL_AUTO_INHERITED = 0x0400;
        public const Int32 SE_DACL_PROTECTED = 0x1000;

        public const Byte SECURITY_NT_AUTHORITY_BYTE_0 = 0;
        public const Byte SECURITY_NT_AUTHORITY_BYTE_1 = 0;
        public const Byte SECURITY_NT_AUTHORITY_BYTE_2 = 0;
        public const Byte SECURITY_NT_AUTHORITY_BYTE_3 = 0;
        public const Byte SECURITY_NT_AUTHORITY_BYTE_4 = 0;
        public const Byte SECURITY_NT_AUTHORITY_BYTE_5 = 5;

        public const Int32 DOMAIN_ALIAS_RID_ADMINS = 0x00000220;
        public const Int32 DOMAIN_ALIAS_RID_USERS = 0x00000221;
        public const Int32 DOMAIN_ALIAS_RID_GUESTS = 0x00000222;
        public const Int32 DOMAIN_ALIAS_RID_POWER_USERS = 0x00000223;

        public const Int32 DOMAIN_ALIAS_RID_ACCOUNT_OPS = 0x00000224;
        public const Int32 DOMAIN_ALIAS_RID_SYSTEM_OPS = 0x00000225;
        public const Int32 DOMAIN_ALIAS_RID_PRINT_OPS = 0x00000226;
        public const Int32 DOMAIN_ALIAS_RID_BACKUP_OPS = 0x00000227;

        public const Int32 DOMAIN_ALIAS_RID_REPLICATOR = 0x00000228;

        /// <summary>
        /// The AllocateAndInitializeSid function allocates and initializes a security 
        /// identifier (SID) with up to eight sub authorities.
        /// 
        /// BOOL AllocateAndInitializeSid(
        ///     PSID_IDENTIFIER_AUTHORITY pIdentifierAuthority,
        ///     BYTE nSubAuthorityCount,
        ///     DWORD dwSubAuthority0,
        ///     DWORD dwSubAuthority1,
        ///     DWORD dwSubAuthority2,
        ///     DWORD dwSubAuthority3,
        ///     DWORD dwSubAuthority4,
        ///     DWORD dwSubAuthority5,
        ///     DWORD dwSubAuthority6,
        ///     DWORD dwSubAuthority7,
        ///     PSID* pSid
        /// );
        /// </summary>
        /// <param name="pIdentifierAuthority">
        /// [in] Pointer to a SID_IDENTIFIER_AUTHORITY structure. 
        /// This structure provides the top-level identifier 
        /// authority value to set in the SID.</param>
        /// <param name="nSubAuthorityCount">
        /// [in] Specifies the number of sub authorities to place in the SID. 
        /// This parameter also identifies how many of the sub authority 
        /// parameters have meaningful values. This parameter must contain a value from 1 to 8. 
        /// For example, a value of 3 indicates that the sub authority values specified
        /// by the dwSubAuthority0, dwSubAuthority1, and dwSubAuthority2 parameters
        /// have meaningful values and to ignore the remainder.  
        /// </param>
        /// <param name="dwSubAuthority0">[in] Sub authority value to place in the SID.</param>
        /// <param name="dwSubAuthority1">[in] Sub authority value to place in the SID.</param>
        /// <param name="dwSubAuthority2">[in] Sub authority value to place in the SID.</param>
        /// <param name="dwSubAuthority3">[in] Sub authority value to place in the SID.</param>
        /// <param name="dwSubAuthority4">[in] Sub authority value to place in the SID.</param>
        /// <param name="dwSubAuthority5">[in] Sub authority value to place in the SID.</param>
        /// <param name="dwSubAuthority6">[in] Sub authority value to place in the SID.</param>
        /// <param name="dwSubAuthority7">[in] Sub authority value to place in the SID.</param>
        /// <param name="pSid">
        /// [out] Pointer to a variable that receives the pointer to the allocated 
        /// and initialized SID structure.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        /// <remarks>
        /// A SID allocated with the AllocateAndInitializeSid function must be freed by using the FreeSid function.
        /// 
        /// typedef struct _SID_IDENTIFIER_AUTHORITY {  
        ///     BYTE Value[6];
        /// } SID_IDENTIFIER_AUTHORITY, *PSID_IDENTIFIER_AUTHORITY;   
        /// </remarks>                                    
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern Boolean AllocateAndInitializeSid(
            ref SID_IDENTIFIER_AUTHORITY pIdentifierAuthority,
            Byte nSubAuthorityCount,
            Int32 dwSubAuthority0, Int32 dwSubAuthority1,
            Int32 dwSubAuthority2, Int32 dwSubAuthority3,
            Int32 dwSubAuthority4, Int32 dwSubAuthority5,
            Int32 dwSubAuthority6, Int32 dwSubAuthority7,
            out IntPtr pSid);

        /// <summary>
        /// The CheckTokenMembership function determines whether a 
        /// specified security identifier (SID) is enabled in an access token.
        /// 
        /// BOOL CheckTokenMembership(
        ///     HANDLE TokenHandle,
        ///     PSID SidToCheck,
        ///     PBOOL IsMember
        /// ); 
        /// </summary>
        /// <param name="TokenHandle">
        /// [in] Handle to an access token. The handle must have TOKEN_QUERY access to the token. 
        /// The token must be an impersonation token. 
        /// If TokenHandle is NULL, CheckTokenMembership uses the impersonation token of 
        /// the calling thread. If the thread is not impersonating, the function 
        /// duplicates the thread's primary token to create an impersonation token.
        /// </param>
        /// <param name="SidToCheck">
        /// [in] Pointer to a SID structure. The CheckTokenMembership function checks for 
        /// the presence of this SID in the user and group SIDs of the access token.
        /// </param>
        /// <param name="IsMember">
        /// [out] Pointer to a variable that receives the results of the check. 
        /// If the SID is present and has the SE_GROUP_ENABLED attribute, 
        /// IsMember returns TRUE; otherwise, it returns FALSE.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        /// <remarks>
        /// The CheckTokenMembership function simplifies the process of determining whether a SID is 
        /// both present and enabled in an access token. Even if a SID is present in the token, 
        /// the system may not use the SID in an access check. The SID may be disabled or have the
        /// SE_GROUP_USE_FOR_DENY_ONLY attribute. The system uses only enabled SIDs to
        /// grant access when performing an access check. For more information, see SID Attributes in an Access Token.
        /// If TokenHandle is a restricted token, or if TokenHandle is NULL and the current effective
        /// token of the calling thread is a restricted token, CheckTokenMembership also checks whether
        /// the SID is present in the list of restricting SIDs.
        /// </remarks>
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern Boolean CheckTokenMembership(IntPtr TokenHandle, IntPtr SidToCheck, out Boolean IsMember);

        /// <summary>
        /// The FreeSid function frees a security identifier (SID) 
        /// previously allocated by using the AllocateAndInitializeSid function.
        /// 
        /// PVOID FreeSid(
        ///     PSID pSid
        /// );
        /// </summary>
        /// <param name="pSid">
        /// [in] A pointer to the SID structure to free. 
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns NULL.
        /// If the function fails, it returns a pointer to the SID structure represented by the pSid parameter.
        /// </returns>
        [DllImport("advapi32.dll", SetLastError = true)]
        public extern static IntPtr FreeSid(IntPtr pSid);
    }

    public class User32
    {
        #region SetWindowsHookEx() codes
        public const Int32 WH_MIN = -1;
        public const Int32 WH_MSGFILTER = -1;
        public const Int32 WH_JOURNALRECORD = 0;
        public const Int32 WH_JOURNALPLAYBACK = 1;
        public const Int32 WH_KEYBOARD = 2;
        public const Int32 WH_GETMESSAGE = 3;
        public const Int32 WH_CALLWNDPROC = 4;
        public const Int32 WH_CBT = 5;
        public const Int32 WH_SYSMSGFILTER = 6;
        public const Int32 WH_MOUSE = 7;
        public const Int32 WH_HARDWARE = 8;
        public const Int32 WH_DEBUG = 9;
        public const Int32 WH_SHELL = 10;
        public const Int32 WH_FOREGROUNDIDLE = 11;
        public const Int32 WH_CALLWNDPROCRET = 12;
        public const Int32 WH_KEYBOARD_LL = 13;
        public const Int32 WH_MOUSE_LL = 14;
        #endregion

        #region CBT Hook Codes
        public const Int32 HCBT_MOVESIZE = 0;
        public const Int32 HCBT_MINMAX = 1;
        public const Int32 HCBT_QS = 2;
        public const Int32 HCBT_CREATEWND = 3;
        public const Int32 HCBT_DESTROYWND = 4;
        public const Int32 HCBT_ACTIVATE = 5;
        public const Int32 HCBT_CLICKSKIPPED = 6;
        public const Int32 HCBT_KEYSKIPPED = 7;
        public const Int32 HCBT_SYSCOMMAND = 8;
        public const Int32 HCBT_SETFOCUS = 9;
        #endregion

        #region Edit Control Styles
        public const Int32 ES_LEFT = 0x0000;
        public const Int32 ES_CENTER = 0x0001;
        public const Int32 ES_RIGHT = 0x0002;
        public const Int32 ES_MULTILINE = 0x0004;
        public const Int32 ES_UPPERCASE = 0x0008;
        public const Int32 ES_LOWERCASE = 0x0010;
        public const Int32 ES_PASSWORD = 0x0020;
        public const Int32 ES_AUTOVSCROLL = 0x0040;
        public const Int32 ES_AUTOHSCROLL = 0x0080;
        public const Int32 ES_NOHIDESEL = 0x0100;
        public const Int32 ES_OEMCONVERT = 0x0400;
        public const Int32 ES_READONLY = 0x0800;
        public const Int32 ES_WANTRETURN = 0x1000;
        public const Int32 ES_NUMBER = 0x2000;
        #endregion

        #region Static Control Messages
        public const Int32 STM_SETICON = 0x0170;
        public const Int32 STM_GETICON = 0x0171;
        public const Int32 STM_SETIMAGE = 0x0172;
        public const Int32 STM_GETIMAGE = 0x0173;
        public const Int32 STN_CLICKED = 0;
        public const Int32 STN_DBLCLK = 1;
        public const Int32 STN_ENABLE = 2;
        public const Int32 STN_DISABLE = 3;
        public const Int32 STM_MSGMAX = 0x0174;
        #endregion

        #region Window field offsets for GetWindowLong()
        public const Int32 GWL_WNDPROC = -4;
        public const Int32 GWL_HINSTANCE = -6;
        public const Int32 GWL_HWNDPARENT = -8;
        public const Int32 GWL_STYLE = -16;
        public const Int32 GWL_EXSTYLE = -20;
        public const Int32 GWL_USERDATA = -21;
        public const Int32 GWL_ID = -12;
        #endregion

        /// <summary>
        /// Hook procedure is an application-defined or library-defined callback 
        /// function used with the SetWindowsHookEx function
        /// </summary>
        /// <param name="nCode">
        /// [in] Specifies a code that the hook procedure uses to determine how to process the message. 
        /// If nCode is less than zero, the hook procedure must pass the message to the CallNextHookEx 
        /// function without further processing and should return the value returned by CallNextHookEx.
        /// </param>
        /// <param name="wParam">[in] Depends on the nCode parameter.</param>
        /// <param name="lParam">[in] Depends on the nCode parameter.</param>
        /// <returns>
        /// The value returned by the hook procedure determines whether the 
        /// system allows or prevents one of these operations.
        /// </returns>
        public delegate Int32 HookProc(Int32 nCode, IntPtr wParam, IntPtr lParam);

        [Serializable, StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public Int32 Left;
            public Int32 Top;
            public Int32 Right;
            public Int32 Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }

        /// <summary>
        /// The SetWindowsHookEx function installs an application-defined hook procedure 
        /// into a hook chain. You would install a hook procedure to monitor the 
        /// system for certain types of events. These events are associated either 
        /// with a specific thread or with all threads in the same desktop as the calling thread. 
        /// 
        /// HHOOK SetWindowsHookEx(int idHook,
        ///     HOOKPROC lpfn,
        ///     HINSTANCE hMod,
        ///     DWORD dwThreadId
        /// );
        /// </summary>
        /// <param name="hook">[in] Specifies the type of hook procedure to be installed.</param>
        /// <param name="lpfn">
        /// [in] Pointer to the hook procedure. If the dwThreadId parameter is zero or 
        /// specifies the identifier of a thread created by a different process, the lpfn 
        /// parameter must point to a hook procedure in a dynamic-link library (DLL). 
        /// Otherwise, lpfn can point to a hook procedure in the code associated with the current process.
        /// </param>
        /// <param name="hMod">
        /// [in] Handle to the DLL containing the hook procedure pointed to by the lpfn parameter. 
        /// The hMod parameter must be set to NULL if the dwThreadId parameter specifies a thread 
        /// created by the current process and if the hook procedure is within the code associated 
        /// with the current process.
        /// </param>
        /// <param name="dwThreadId">
        /// [in] Specifies the identifier of the thread with which the hook procedure is to be associated. 
        /// If this parameter is zero, the hook procedure is associated with all existing threads 
        /// running in the same desktop as the calling thread. 
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the hook procedure.
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(Int32 hook, HookProc lpfn,
            IntPtr hMod, UInt32 dwThreadId);

        /// <summary>
        /// The UnhookWindowsHookEx function removes a hook procedure installed 
        /// in a hook chain by the SetWindowsHookEx function. 
        /// 
        /// BOOL UnhookWindowsHookEx(
        ///     HHOOK hhk
        /// );
        /// </summary>
        /// <param name="hhk">
        /// [in] Handle to the hook to be removed. This parameter is a hook 
        /// handle obtained by a previous call to SetWindowsHookEx. 
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport("user32.dll")]
        public static extern Boolean UnhookWindowsHookEx(IntPtr hhk);

        /// <summary>
        /// The CallNextHookEx function passes the hook information to the next hook procedure 
        /// in the current hook chain. A hook procedure can call this function either before or 
        /// after processing the hook information. 
        /// 
        /// LRESULT CallNextHookEx(          HHOOK hhk,
        ///     int nCode,
        ///     WPARAM wParam,
        ///     LPARAM lParam
        /// );
        /// </summary>
        /// <param name="hhk">
        /// Ignored.
        /// </param>
        /// <param name="nCode">
        /// [in] Specifies the hook code passed to the current hook procedure. 
        /// The next hook procedure uses this code to determine how to process the hook information. 
        /// </param>
        /// <param name="wParam">
        /// [in] Specifies the wParam value passed to the current hook procedure. 
        /// The meaning of this parameter depends on the type of hook associated with the current hook chain. 
        /// </param>
        /// <param name="lParam">
        /// [in] Specifies the lParam value passed to the current hook procedure. 
        /// The meaning of this parameter depends on the type of hook associated with the current hook chain. 
        /// </param>
        /// <returns>
        /// This value is returned by the next hook procedure in the chain. 
        /// The current hook procedure must also return this value. 
        /// The meaning of the return value depends on the hook type. 
        /// For more information, see the descriptions of the individual hook procedures.
        /// </returns>
        [DllImport("user32.dll")]
        public static extern Int32 CallNextHookEx(IntPtr hhk, Int32 nCode, IntPtr wParam,
           IntPtr lParam);

        /// <summary>
        /// The GetClassName function retrieves the name of the class to which the specified window belongs. 
        /// int GetClassName(          HWND hWnd,
        ///     LPTSTR lpClassName,
        ///     int nMaxCount
        /// );
        /// 
        /// </summary>
        /// <param name="hWnd">
        /// [in] Handle to the window and, indirectly, the class to which the window belongs. 
        /// </param>
        /// <param name="lpClassName">
        /// [out] Pointer to the buffer that is to receive the class name string.
        /// </param>
        /// <param name="nMaxCount">
        /// [in] Specifies the length, in TCHAR, of the buffer pointed to by the lpClassName parameter. 
        /// The class name string is truncated if it is longer than the buffer and is always null-terminated. 
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the number of TCHAR copied to the specified buffer.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError. 
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern Int32 GetClassName(IntPtr hWnd, StringBuilder lpClassName, Int32 nMaxCount);

        /// <summary>
        /// The GetDlgCtrlID function retrieves the identifier of the specified control.
        /// 
        /// int GetDlgCtrlID(          
        ///     HWND hwndCtl
        /// );
        /// </summary>
        /// <param name="hwndCtl">[in] Handle to the control. </param>
        /// <returns>
        /// If the function succeeds, the return value is the identifier of the control.
        /// If the function fails, the return value is zero. An invalid value for the hwndCtl parameter, 
        /// for example, will cause the function to fail. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport("user32.dll")]
        public static extern int GetDlgCtrlID(IntPtr hwndCtl);

        /// <summary>
        /// The GetDlgItem function retrieves a handle to a control in the specified dialog box. 
        /// 
        /// HWND GetDlgItem(     
        ///     HWND hDlg,
        ///     int nIDDlgItem
        /// );
        /// </summary>
        /// <param name="hDlg">
        /// [in] Handle to the dialog box that contains the control. 
        /// </param>
        /// <param name="nIDDlgItem">
        /// [in] Specifies the identifier of the control to be retrieved. 
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the window handle of the specified control. 
        /// If the function fails, the return value is NULL, indicating an invalid dialog box handle 
        /// or a nonexistent control. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetDlgItem(IntPtr hDlg, Int32 nIDDlgItem);

        /// <summary>
        /// The GetDlgItemText function retrieves the title or text associated with a control in a dialog box. 
        /// 
        /// UINT GetDlgItemText(      
        ///     HWND hDlg,
        ///     int nIDDlgItem,
        ///     LPTSTR lpString,
        ///     int nMaxCount
        /// );
        /// </summary>
        /// <param name="hDlg">[in] Handle to the dialog box that contains the control.</param>
        /// <param name="nIDDlgItem">
        /// [in] Specifies the identifier of the control whose title or text is to be retrieved.
        /// </param>
        /// <param name="lpString">[out] Pointer to the buffer to receive the title or text.</param>
        /// <param name="nMaxCount">
        /// [in] Specifies the maximum length, in TCHARs, of the string to be copied to the 
        /// buffer pointed to by lpString. If the length of the string, including the NULL character, 
        /// exceeds the limit, the string is truncated.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the number of TCHARs copied to the buffer, 
        /// not including the terminating NULL character.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern UInt32 GetDlgItemText(IntPtr hDlg, Int32 nIDDlgItem,
            [Out] StringBuilder lpString, Int32 nMaxCount);

        /// <summary>
        /// The SetDlgItemText function sets the title or text of a control in a dialog box. 
        /// BOOL SetDlgItemText(          
        ///     HWND hDlg,
        ///     int nIDDlgItem,
        ///     LPCTSTR lpString
        /// );
        /// </summary>
        /// <param name="hDlg">
        /// [in] Handle to the dialog box that contains the control. 
        /// </param>
        /// <param name="nIDDlgItem">
        /// [in] Specifies the control with a title or text to be set. 
        /// </param>
        /// <param name="lpString">
        /// [in] Pointer to the null-terminated string that contains the text to be copied to the control. 
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError. 
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern Boolean SetDlgItemText(IntPtr hDlg, Int32 nIDDlgItem, String lpString);

        /// <summary>
        /// The GetWindowText function copies the text of the specified window's title 
        /// bar (if it has one) into a buffer. If the specified window is a control, 
        /// the text of the control is copied. However, GetWindowText cannot 
        /// retrieve the text of a control in another application.
        /// 
        /// int GetWindowText(          
        ///     HWND hWnd,
        ///     LPTSTR lpString,
        ///     int nMaxCount
        /// );
        /// </summary>
        /// <param name="hWnd">
        /// [in] Handle to the window or control containing the text.
        /// </param>
        /// <param name="lpString">
        /// [out] Pointer to the buffer that will receive the text. If the string is as long or longer 
        /// than the buffer, the string is truncated and terminated with a NULL character. 
        /// </param>
        /// <param name="nMaxCount">
        /// [in] Specifies the maximum number of characters to copy to the buffer, 
        /// including the NULL character. If the text exceeds this limit, it is truncated. 
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length, in characters, of the copied string, 
        /// not including the terminating NULL character. If the window has no title bar or text, 
        /// if the title bar is empty, or if the window or control handle is invalid, the return value is zero. 
        /// To get extended error information, call GetLastError. 
        /// This function cannot retrieve the text of an edit control in another application.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern Int32 GetWindowText(IntPtr hWnd, StringBuilder lpString, Int32 nMaxCount);

        /// <summary>
        /// The SetWindowText function changes the text of the specified window's title bar (if it has one). 
        /// If the specified window is a control, the text of the control is changed. However, 
        /// SetWindowText cannot change the text of a control in another application.
        /// 
        /// BOOL SetWindowText(          
        ///     HWND hWnd,
        ///     LPCTSTR lpString
        /// );
        /// </summary>
        /// <param name="hWnd">
        /// [in] Handle to the window or control whose text is to be changed. 
        /// </param>
        /// <param name="lpString">
        /// [in] Pointer to a null-terminated string to be used as the new title or control text. 
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError. 
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern Boolean SetWindowText(IntPtr hWnd, String lpString);

        /// <summary>
        /// The GetWindowRect function retrieves the dimensions of the bounding rectangle of the specified window. 
        /// The dimensions are given in screen coordinates that are relative to the upper-left corner of the screen. 
        /// 
        /// BOOL GetWindowRect(          
        ///     HWND hWnd,
        ///     LPRECT lpRect
        /// ); 
        /// </summary>
        /// <param name="hWnd">[in] Handle to the window.</param>
        /// <param name="lpRect">
        /// [out] Pointer to a structure that receives the screen coordinates of 
        /// the upper-left and lower-right corners of the window. 
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError. 
        /// </returns>
        [DllImport("user32.dll")]
        public static extern Boolean GetWindowRect(IntPtr hWnd, out RECT lpRect);

        /// <summary>
        /// The ScreenToClient function converts the screen coordinates of a specified 
        /// point on the screen to client-area coordinates. 
        /// 
        /// BOOL ScreenToClient(
        ///     HWND hWnd,        // handle to window
        ///     LPPOINT lpPoint   // screen coordinates
        /// );
        /// </summary>
        /// <param name="hWnd">
        /// [in] Handle to the window whose client area will be used for the conversion.
        /// </param>
        /// <param name="lpPoint">
        /// [in] Pointer to a POINT structure that specifies the screen coordinates to be converted. 
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. 
        /// Windows NT/2000/XP: To get extended error information, call GetLastError.
        /// </returns>
        [DllImport("user32.dll")]
        public static extern Boolean ScreenToClient(IntPtr hWnd, ref POINT lpPoint);

        /// <summary>
        /// The GetWindowLong function retrieves information about the specified window. 
        /// The function also retrieves the 32-bit (long) value at the specified 
        /// offset into the extra window memory.
        /// 
        /// If you are retrieving a pointer or a handle, this function has been 
        /// superseded by the GetWindowLongPtr function. (Pointers and handles are 32 bits on 
        /// 32-bit Microsoft Windows and 64 bits on 64-bit Windows.) 
        /// To write code that is compatible with both 32-bit and 64-bit versions of Windows, 
        /// use GetWindowLongPtr.
        /// 
        /// LONG GetWindowLong(     
        ///     HWND hWnd,
        ///     int nIndex
        /// );
        /// </summary>
        /// <param name="hWnd">
        /// [in] Handle to the window and, indirectly, the class to which the window belongs.
        /// </param>
        /// <param name="nIndex">
        /// [in] Specifies the zero-based offset to the value to be retrieved. 
        /// Valid values are in the range zero through the number of bytes of extra 
        /// window memory, minus four; for example, if you specified 12 or more 
        /// bytes of extra memory, a value of 8 would be an index to the third 32-bit integer.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the requested 32-bit value.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError. 
        /// If SetWindowLong has not been called previously, GetWindowLong returns zero 
        /// for values in the extra window or class memory.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern Int32 GetWindowLong(IntPtr hWnd, Int32 nIndex);

        /// <summary>
        /// The SetWindowLong function changes an attribute of the specified window. 
        /// The function also sets the 32-bit (long) value at the specified offset into the extra window memory.
        /// 
        /// Note  This function has been superseded by the SetWindowLongPtr function. 
        /// To write code that is compatible with both 32-bit and 64-bit versions of Microsoft Windows, 
        /// use the SetWindowLongPtr function.
        /// 
        /// LONG SetWindowLong(   
        ///     HWND hWnd,
        ///     int nIndex,
        ///     LONG dwNewLong
        /// );
        /// </summary>
        /// <param name="hWnd">
        /// [in] Handle to the window and, indirectly, the class to which the window belongs.
        /// </param>
        /// <param name="nIndex">
        /// [in] Specifies the zero-based offset to the value to be set. 
        /// Valid values are in the range zero through the number of 
        /// bytes of extra window memory, minus the size of an integer. 
        /// </param>
        /// <param name="dwNewLong">
        /// [in] Specifies the replacement value. 
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the previous value of the specified 32-bit integer.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError. 
        /// If the previous value of the specified 32-bit integer is zero, and the function succeeds, 
        /// the return value is zero, but the function does not clear the last error information. 
        /// This makes it difficult to determine success or failure. To deal with this, you should clear 
        /// the last error information by calling SetLastError(0) before calling SetWindowLong. 
        /// Then, function failure will be indicated by a return value of zero and a GetLastError result that is nonzero.
        /// </returns>
        [DllImport("user32.dll")]
        public static extern Int32 SetWindowLong(IntPtr hWnd, Int32 nIndex, IntPtr dwNewLong);

        /// <summary>
        /// The DestroyWindow function destroys the specified window. 
        /// The function sends WM_DESTROY and WM_NCDESTROY messages to the window to deactivate it 
        /// and remove the keyboard focus from it. The function also destroys the window's menu, 
        /// flushes the thread message queue, destroys timers, removes clipboard ownership, 
        /// and breaks the clipboard viewer chain (if the window is at the top of the viewer chain).
        /// 
        /// If the specified window is a parent or owner window, 
        /// DestroyWindow automatically destroys the associated child or 
        /// owned windows when it destroys the parent or owner window. 
        /// The function first destroys child or owned windows, and then 
        /// it destroys the parent or owner window.
        /// 
        /// DestroyWindow also destroys modeless dialog boxes created by the CreateDialog function.
        /// 
        /// BOOL DestroyWindow(          
        ///     HWND hWnd
        /// );
        /// </summary>
        /// <param name="hWnd">[in] Handle to the window to be destroyed.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport("user32.dll")]
        public static extern Boolean DestroyWindow(IntPtr hWnd);

        /// <summary>
        /// The SendMessage function sends the specified message to a window or windows. 
        /// It calls the window procedure for the specified window and does not return 
        /// until the window procedure has processed the message. 
        /// 
        /// To send a message and return immediately, use the SendMessageCallback or SendNotifyMessage function. 
        /// To post a message to a thread's message queue and return immediately, 
        /// use the PostMessage or PostThreadMessage function.
        /// 
        /// LRESULT SendMessage(          
        ///     HWND hWnd,
        ///     UINT Msg,
        ///     WPARAM wParam,
        ///     LPARAM lParam
        /// );
        /// </summary>
        /// <param name="hWnd">
        /// [in] Handle to the window whose window procedure will receive the message. 
        /// If this parameter is HWND_BROADCAST, the message is sent to all top-level 
        /// windows in the system, including disabled or invisible unowned windows, 
        /// overlapped windows, and pop-up windows; but the message is not sent to child windows.
        /// </param>
        /// <param name="Msg">[in] Specifies the message to be sent.</param>
        /// <param name="wParam">[in] Specifies additional message-specific information.</param>
        /// <param name="lParam">[in] Specifies additional message-specific information.</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SendMessage(HandleRef hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// The GetActiveWindow function retrieves the window handle 
        /// to the active window attached to the calling thread's message queue. 
        /// 
        /// HWND GetActiveWindow(VOID);
        /// </summary>
        /// <returns>
        /// The return value is the handle to the active window attached to 
        /// the calling thread's message queue. Otherwise, the return value is NULL. 
        /// </returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetActiveWindow();

        /// <summary>
        /// The CreateWindowEx function creates an overlapped, pop-up, or child window with 
        /// an extended window style; otherwise, this function is identical to the CreateWindow function. 
        /// For more information about creating a window and for full descriptions of the 
        /// other parameters of CreateWindowEx, see CreateWindow. 
        /// 
        /// HWND CreateWindowEx(          
        ///     DWORD dwExStyle,
        ///     LPCTSTR lpClassName,
        ///     LPCTSTR lpWindowName,
        ///     DWORD dwStyle,
        ///     int x,
        ///     int y,
        ///     int nWidth,
        ///     int nHeight,
        ///     HWND hWndParent,
        ///     HMENU hMenu,
        ///     HINSTANCE hInstance,
        ///     LPVOID lpParam
        /// );
        /// </summary>
        /// <param name="dwExStyle">
        /// [in] Specifies the extended window style of the window being created. 
        /// This parameter can be one or more of the following values.
        /// </param>
        /// <param name="lpClassName">
        /// [in] Pointer to a null-terminated string or a class atom created by a 
        /// previous call to the RegisterClass or RegisterClassEx function. 
        /// The atom must be in the low-order word of lpClassName; the high-order word must be zero. 
        /// If lpClassName is a string, it specifies the window class name. 
        /// The class name can be any name registered with RegisterClass or RegisterClassEx, 
        /// provided that the module that registers the class is also the module that creates the window. 
        /// The class name can also be any of the predefined system class names. 
        /// </param>
        /// <param name="lpWindowName">
        /// [in] Pointer to a null-terminated string that specifies the window name. 
        /// If the window style specifies a title bar, the window title pointed to 
        /// by lpWindowName is displayed in the title bar. When using CreateWindow to create controls, 
        /// such as buttons, check boxes, and static controls, use lpWindowName to specify 
        /// the text of the control. When creating a static control with the SS_ICON style, use 
        /// lpWindowName to specify the icon name or identifier. 
        /// To specify an identifier, use the syntax "#num". 
        /// </param>
        /// <param name="dwStyle">
        /// [in] Specifies the style of the window being created. This parameter can be a combination of 
        /// window styles, plus the control styles indicated in the Remarks section. 
        /// </param>
        /// <param name="x">
        /// [in] Specifies the initial horizontal position of the window. For an overlapped or pop-up window, 
        /// the x parameter is the initial x-coordinate of the window's upper-left corner, 
        /// in screen coordinates. For a child window, x is the x-coordinate of the upper-left corner of 
        /// the window relative to the upper-left corner of the parent window's client area. 
        /// If x is set to CW_USEDEFAULT, the system selects the default position for the window's 
        /// upper-left corner and ignores the y parameter. CW_USEDEFAULT is valid only for 
        /// overlapped windows; if it is specified for a pop-up or child window, 
        /// the x and y parameters are set to zero. 
        /// </param>
        /// <param name="y">
        /// [in] Specifies the initial vertical position of the window. For an overlapped or pop-up window, 
        /// the y parameter is the initial y-coordinate of the window's upper-left corner, 
        /// in screen coordinates. For a child window, y is the initial y-coordinate of the upper-left corner of 
        /// the child window relative to the upper-left corner of the parent window's client area. 
        /// For a list box y is the initial y-coordinate of the upper-left corner of the 
        /// list box's client area relative to the upper-left corner of the parent window's client area. 
        /// If an overlapped window is created with the WS_VISIBLE style bit set and the x parameter 
        /// is set to CW_USEDEFAULT, the system ignores the y parameter. 
        /// </param>
        /// <param name="nWidth">
        /// [in] Specifies the width, in device units, of the window. For overlapped windows, 
        /// nWidth is the window's width, in screen coordinates, or CW_USEDEFAULT. 
        /// If nWidth is CW_USEDEFAULT, the system selects a default width and height for the window; 
        /// the default width extends from the initial x-coordinates to the right edge of the screen; 
        /// the default height extends from the initial y-coordinate to the top of the icon area. 
        /// CW_USEDEFAULT is valid only for overlapped windows; if CW_USEDEFAULT is specified for 
        /// a pop-up or child window, the nWidth and nHeight parameter are set to zero. 
        /// </param>
        /// <param name="nHeight">
        /// [in] Specifies the height, in device units, of the window. For overlapped windows, 
        /// nHeight is the window's height, in screen coordinates. If the nWidth parameter is 
        /// set to CW_USEDEFAULT, the system ignores nHeight. 
        /// </param>
        /// <param name="hWndParent">
        /// [in] Handle to the parent or owner window of the window being created. 
        /// To create a child window or an owned window, supply a valid window handle. 
        /// This parameter is optional for pop-up windows.
        /// 
        /// Windows 2000/XP: To create a message-only window, supply HWND_MESSAGE 
        /// or a handle to an existing message-only window.
        /// </param>
        /// <param name="hMenu">
        /// [in] Handle to a menu, or specifies a child-window identifier, 
        /// depending on the window style. For an overlapped or pop-up window, 
        /// hMenu identifies the menu to be used with the window; it can be NULL 
        /// if the class menu is to be used. For a child window, hMenu specifies 
        /// the child-window identifier, an integer value used by a dialog box control 
        /// to notify its parent about events. The application determines the child-window identifier; 
        /// it must be unique for all child windows with the same parent window. 
        /// </param>
        /// <param name="hInstance">
        /// [in] Windows 95/98/Me: Handle to the instance of the 
        /// module to be associated with the window.
        /// Windows NT/2000/XP: This value is ignored.
        /// </param>
        /// <param name="lpParam">
        /// [in] Pointer to a value to be passed to the window through the CREATESTRUCT structure 
        /// passed in the lpParam parameter the WM_CREATE message. If an application calls 
        /// CreateWindow to create a MDI client window, lpParam must point to 
        /// a CLIENTCREATESTRUCT structure. 
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the new window.
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// 
        /// This function typically fails for one of the following reasons: 
        /// - an invalid parameter value
        /// - the system class was registered by a different module
        /// - the WH_CBT hook is installed and returns a failure code
        /// - the window procedure fails for WM_CREATE or WM_NCCREATE
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateWindowEx(
            UInt32 dwExStyle, String lpClassName, String lpWindowName, UInt32 dwStyle,
            Int32 x, Int32 y, Int32 nWidth, Int32 nHeight,
            IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam
        );
    }

    public class Shell32
    {
        /// <summary>
        /// The ExtractIcon function retrieves a handle to an icon from the specified executable file, 
        /// dynamic-link library (DLL), or icon file.
        /// To retrieve an array of handles to large or small icons, use the ExtractIconEx function.
        /// 
        /// HICON ExtractIcon(          
        ///     HINSTANCE hInst,
        ///     LPCTSTR lpszExeFileName,
        ///     UINT nIconIndex
        /// );
        /// </summary>
        /// <param name="hInst">
        /// [in] Handle to the instance of the application calling the function.
        /// </param>
        /// <param name="lpszExeFileName">
        /// [in] Pointer to a null-terminated string specifying the name of an executable file, DLL, or icon file. 
        /// </param>
        /// <param name="nIconIndex">
        /// [in] Specifies the zero-based index of the icon to retrieve. 
        /// For example, if this value is 0, the function returns a handle to the first icon in the specified file. 
        /// If this value is –1, the function returns the total number of icons in the specified file. 
        /// If the file is an executable file or DLL, the return value is the number of RT_GROUP_ICON resources. 
        /// If the file is an .ICO file, the return value is 1.
        /// </param>
        /// <returns>
        /// The return value is a handle to an icon. If the file specified was not 
        /// an executable file, DLL, or icon file, the return is 1. 
        /// If no icons were found in the file, the return value is NULL. 
        /// </returns>
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr ExtractIcon(IntPtr hInst, String lpszExeFileName, Int32 nIconIndex);

        /// <summary>
        /// The ExtractIconEx function creates an array of handles to large or small icons 
        /// extracted from the specified executable file, dynamic-link library (DLL), or icon file. 
        /// 
        /// UINT ExtractIconEx(          
        ///     LPCTSTR lpszFile,
        ///     int nIconIndex,
        ///     HICON *phiconLarge,
        ///     HICON *phiconSmall,
        ///     UINT nIcons
        /// );
        /// </summary>
        /// <param name="szFileName">
        /// [in] Pointer to a null-terminated string specifying the name of an executable file, DLL, 
        /// or icon file from which icons will be extracted. 
        /// </param>
        /// <param name="nIconIndex">
        /// [in] Specifies the zero-based index of the first icon to extract. 
        /// For example, if this value is zero, the function extracts the first icon in the specified file. 
        /// If this value is –1 and phiconLarge and phiconSmall are both NULL, the function returns 
        /// the total number of icons in the specified file. If the file is an executable file or DLL, 
        /// the return value is the number of RT_GROUP_ICON resources. 
        /// If the file is an .ico file, the return value is 1. 
        /// </param>
        /// <param name="phiconLarge">
        /// [out] Pointer to an array of icon handles that receives handles to the large icons extracted from the file. 
        /// If this parameter is NULL, no large icons are extracted from the file. 
        /// </param>
        /// <param name="phiconSmall">
        /// [out] Pointer to an array of icon handles that receives handles to the small icons extracted from the file. 
        /// If this parameter is NULL, no small icons are extracted from the file. 
        /// </param>
        /// <param name="nIcons">
        /// [in] Specifies the number of icons to extract from the file. 
        /// </param>
        /// <returns>
        /// If the nIconIndex parameter is -1, the phiconLarge parameter is NULL, 
        /// and the phiconSmall parameter is NULL, then the return value is the number of icons 
        /// contained in the specified file. Otherwise, the return value is the number of icons 
        /// successfully extracted from the file. 
        /// </returns>
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern UInt32 ExtractIconEx(String szFileName, Int32 nIconIndex,
            IntPtr[] phiconLarge, IntPtr[] phiconSmall, UInt32 nIcons);
    }

    public class Comctl32 
    {
        /// <summary>
        /// typedef struct tagINITCOMMONCONTROLSEX {
        ///     DWORD dwSize;
        ///     DWORD dwICC;
        /// } INITCOMMONCONTROLSEX, *LPINITCOMMONCONTROLSEX;
        /// </summary>
        [Serializable, StructLayout(LayoutKind.Sequential)]
        public struct INITCOMMONCONTROLSEX 
        {
            public Int32 dwSize;
            public UInt32 dwICC;
        }

        /// <summary>
        /// Registers specific common control classes from the common control dynamic-link library (DLL). 
        /// 
        /// BOOL InitCommonControlsEx(          
        ///     LPINITCOMMONCONTROLSEX lpInitCtrls
        /// );
        /// </summary>
        /// <param name="lpInitCtrls">
        /// Pointer to an INITCOMMONCONTROLSEX structure that contains information specifying which 
        /// control classes will be registered.
        /// </param>
        /// <returns>Returns TRUE if successful, or FALSE otherwise.</returns>
        [DllImport("comctl32.dll")]
        public static extern Boolean InitCommonControlsEx(ref INITCOMMONCONTROLSEX lpInitCtrls);
    }

    public class CryptUtil
    {
        public const Int32 ALG_CLASS_DATA_ENCRYPT = (3 << 13);
        public const Int32 ALG_TYPE_BLOCK = (3 << 9);
        public const Int32 ALG_SID_RC2 = 2;
        public const Int32 ALG_SID_DES = 1;
        public const Int32 ALG_SID_3DES = 3;
        public const Int32 ALG_SID_3DES_112 = 9;

        public const Int32 CALG_DES = (ALG_CLASS_DATA_ENCRYPT | ALG_TYPE_BLOCK | ALG_SID_DES);
        public const Int32 CALG_3DES_112 = (ALG_CLASS_DATA_ENCRYPT | ALG_TYPE_BLOCK | ALG_SID_3DES_112);
        public const Int32 CALG_3DES = (ALG_CLASS_DATA_ENCRYPT | ALG_TYPE_BLOCK | ALG_SID_3DES);
        public const Int32 CALG_RC2 = (ALG_CLASS_DATA_ENCRYPT | ALG_TYPE_BLOCK | ALG_SID_RC2);

        [DllImport("cryptutil.dll", EntryPoint = "EncryptString")]
        public static extern StringBuilder EncryptString(StringBuilder pbString, StringBuilder password, Int32 algID);

        [DllImport("cryptutil.dll", EntryPoint = "DecryptString")]
        public static extern StringBuilder DecryptString(StringBuilder pbString, StringBuilder password, Int32 algID);      
    }
}
