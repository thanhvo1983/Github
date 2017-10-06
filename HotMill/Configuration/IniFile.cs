using System;
using System.Collections.Generic;
using System.Text;
using Kvics.PInvoke;

namespace Kvics.Configuration
{
    public sealed class IniFile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        private const Int32 MAX_BUFFER = 1024;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fn"></param>
        public IniFile(String fn)
            : base(fn)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ini"></param>
        public IniFile(IniFile ini)
            : base(ini)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Object Clone()
        {
            return new IniFile(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public override void SetValue(String section, String key, Object value)
        {
            // If the value is null, remove the key
            if (value == null)
            {
                RemoveKey(section, key);
                return;
            }

            VerifyNotReadOnly();
            VerifyFileName();
            VerifyAndSanitizeSection(ref section);
            VerifyAndSanitizeKey(ref key);

            if (!RaiseChangeEvent(true, ProfileChangeType.SetValue, section, key, value))
            {
                return;
            }

            if (!Kernel32.WritePrivateProfileString(section, key, value.ToString(), this._FileName))
            {
                throw new System.ComponentModel.Win32Exception();
            }

            RaiseChangeEvent(false, ProfileChangeType.SetValue, section, key, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public override Object GetValue(String section, String key)
        {
            VerifyFileName();
            VerifyAndSanitizeSection(ref section);
            VerifyAndSanitizeKey(ref key);

            StringBuilder retval = new StringBuilder(MAX_BUFFER);
            UInt32 retsize = Kernel32.GetPrivateProfileString(section, key, "", retval, MAX_BUFFER, this._FileName);

            if (retsize < MAX_BUFFER - 1)
            {
                // Is empty string and key not exists
                if (retsize == 0 && !HasKey(section, key))
                {
                    return null;
                }

                return retval.ToString();
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>    
        public override void RemoveKey(String section, String key)
        {
            // Verify the key exists
            if (!HasKey(section, key))
            {
                return;
            }

            VerifyNotReadOnly();
            VerifyFileName();
            VerifyAndSanitizeSection(ref section);
            VerifyAndSanitizeKey(ref key);

            if (!RaiseChangeEvent(true, ProfileChangeType.RemoveKey, section, key, null))
            {
                return;
            }

            if (!Kernel32.WritePrivateProfileString(section, key, null, this._FileName))
            {
                throw new System.ComponentModel.Win32Exception();
            }

            RaiseChangeEvent(false, ProfileChangeType.RemoveKey, section, key, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        public override void RemoveSection(string section)
        {
            // Verify the section exists
            if (!HasSection(section))
            {
                return;
            }

            VerifyNotReadOnly();
            VerifyFileName();
            VerifyAndSanitizeSection(ref section);

            if (!RaiseChangeEvent(true, ProfileChangeType.RemoveSection, section, null, null))
            {
                return;
            }

            if (!Kernel32.WritePrivateProfileString(section, null, "", this._FileName))
            {
                throw new System.ComponentModel.Win32Exception();
            }

            RaiseChangeEvent(false, ProfileChangeType.RemoveSection, section, null, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public override string[] GetKeys(string section)
        {
            // Verify the section exists
            if (!HasSection(section))
            {
                return null;
            }

            VerifyAndSanitizeSection(ref section);

            IntPtr ptr = IntPtr.Zero;
            String[] retval = null;
            UInt32 retsize = 0;
            try
            {
                ptr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(MAX_BUFFER);
                retsize = Kernel32.GetPrivateProfileString(section, null, "", ptr, MAX_BUFFER, this._FileName);
                if (retsize < MAX_BUFFER - 2)
                {
                    String buff = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(ptr, (Int32)retsize - 1);
                    retval = buff.Split('\0');                                          
                }
                else
                {
                    retval = new String[0];
                }
            }
            catch (OutOfMemoryException)
            {

            }
            catch (ArgumentNullException)
            {

            }
            catch (ArgumentException)
            {

            }
            finally
            {
                // Free the buffer
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(ptr);
            }

            return retval;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String[] GetSections()
        {
            // Verify the file exists
            if (!System.IO.File.Exists(this._FileName))
            {
                return null;
            }

            IntPtr ptr = IntPtr.Zero;
            String[] retval = null;
            UInt32 retsize = 0;
            try
            {
                ptr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(MAX_BUFFER);
                retsize = Kernel32.GetPrivateProfileSectionNames(ptr, MAX_BUFFER, this._FileName);
                if (retsize == 0)
                {
                    retval = new String[0];
                }
                else
                {
                    String buff = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(ptr, (Int32)retsize - 1);
                    retval = buff.Split('\0');
                }
            }
            catch (OutOfMemoryException)
            {

            }
            catch (ArgumentNullException)
            {

            }
            catch (ArgumentException)
            {

            }
            finally
            {
                // Free the buffer
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(ptr);
            }

            return retval;
        }
    }
}
