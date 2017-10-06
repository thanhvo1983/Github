using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Kvics.Configuration
{
    public interface IReadOnlyProfile : ICloneable
    {
        String FileName
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        Object GetValue(String section, String key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        String GetValue(String section, String key, String defaultValue);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        Int32 GetValue(String section, String key, Int32 defaultValue);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        Double GetValue(String section, String key, Double defaultValue);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        Boolean GetValue(String section, String key, Boolean defaultValue);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        Boolean HasSection(String section);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        Boolean HasKey(String section, String key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        String[] GetKeys(String section);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        String[] GetSections();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DataSet GetDataSet();
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IProfile : IReadOnlyProfile
    {
        /// <summary>
        /// 
        /// </summary>
        new String FileName
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        Boolean IsReadOnly
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IReadOnlyProfile CloneReadOnly();

        /// <summary>
        /// 
        /// </summary>
        event ProfileChangingHandler ChangingHandler;

        /// <summary>
        /// 
        /// </summary>
        event ProfileChangedHandler ChangedHandler;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void SetValue(String section, String key, object value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        void RemoveKey(String section, String key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        void RemoveSection(String section);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        String ToXmlString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlString"></param>
        void FromXmlString(String xmlString);

        /// <summary>
        ///
        /// </summary>
        /// <param name="ds"></param>
        void SetDataSet(DataSet ds);
    }

    /// <summary>
    /// 
    /// </summary>
    public enum ProfileChangeType
    {
        FileName,
        ReadOnly,
        SetValue,
        RemoveKey,
        RemoveSection,
        Other
    }

    /// <summary>
    /// 
    /// </summary>
    public class ProfileChangedArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ProfileChangeType _Type;

        /// <summary>
        /// 
        /// </summary>
        private readonly String _Section;

        /// <summary>
        /// 
        /// </summary>
        private readonly String _Key;

        /// <summary>
        /// 
        /// </summary>
        private readonly object _Value;

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public ProfileChangedArgs(ProfileChangeType type, String section, String key, object value)
        {
            this._Type = type;
            this._Section = section;
            this._Key = key;
            this._Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public ProfileChangeType Type
        {
            get
            {
                return this._Type;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public String Section
        {
            get {
                return this._Section;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public String Key
        {
            get
            {
                return this._Key;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public object Value
        {
            get
            {
                return this._Value;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ProfileChangingArgs : ProfileChangedArgs
    {
        /// <summary>
        /// 
        /// </summary>
        private Boolean _Cancel;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public ProfileChangingArgs(ProfileChangeType type, String section, String key, object value)
            : base(type, section, key, value)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean Cancel
        {
            get
            {
                return this._Cancel;
            }
            set
            {
                this._Cancel = value;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ProfileChangingHandler(object sender, ProfileChangingArgs e);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ProfileChangedHandler(object sender, ProfileChangedArgs e);
}
