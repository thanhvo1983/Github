using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Kvics.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Profile : IProfile
    {
        /// <summary>
        /// 
        /// </summary>
        protected String _FileName;

        /// <summary>
        /// 
        /// </summary>
        protected Boolean _IsReadOnly = false;

        /// <summary>
        /// 
        /// </summary>
        public const Int32 XML_MAX_BUFF = 1024;

        /// <summary>
        /// 
        /// </summary>
        public const String XML_ROOT = "Configuration";

        /// <summary>
        /// 
        /// </summary>
        public String FileName
        {
            get
            {
                return this._FileName;
            }

            set
            {
                VerifyNotReadOnly();
                if (this._FileName == value.Trim())
                {
                    return;
                }

                if (!RaiseChangeEvent(true, ProfileChangeType.FileName, null, null, value))
                {
                    return;
                }

                this._FileName = value.Trim();
                RaiseChangeEvent(false, ProfileChangeType.FileName, null, null, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean IsReadOnly
        {
            get
            {
                return this._IsReadOnly;
            }

			set
			{ 
				VerifyNotReadOnly();
                if (this._IsReadOnly == value)
                {
                    return;
                }

                if (!RaiseChangeEvent(true, ProfileChangeType.ReadOnly, null, null, value))
                {
                    return;
                }

                this._IsReadOnly = value;
				RaiseChangeEvent(false, ProfileChangeType.ReadOnly, null, null, value);
			}
        }

        /// <summary>
        /// 
        /// </summary>
        public event ProfileChangingHandler ChangingHandler;

        /// <summary>
        /// 
        /// </summary>
        public event ProfileChangedHandler ChangedHandler;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profile"></param>
        protected Profile(Profile profile)
        {
            this._FileName = profile.FileName;
            this._IsReadOnly = profile.IsReadOnly;
            ChangedHandler = profile.ChangedHandler;
            ChangingHandler = profile.ChangingHandler;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fn"></param>
        protected Profile(String fn)
        {
            this._FileName = fn;
            VerifyFileName();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void VerifyFileName()
        {
            if (String.IsNullOrEmpty(this._FileName))
            {
                throw new InvalidOperationException("Operation not allowed because invalid file name.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void VerifyNotReadOnly()
        {
            if (this._IsReadOnly)
            {
                throw new InvalidOperationException("Operation not allowed.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        protected virtual void VerifyAndSanitizeKey(ref String key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            key = key.Trim();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        protected virtual void VerifyAndSanitizeSection(ref String section)
		{
            if (section == null)
            {
                throw new ArgumentNullException("section");
            }
			
			section = section.Trim();
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="changing"></param>
        /// <param name="type"></param>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected Boolean RaiseChangeEvent(Boolean changing, ProfileChangeType type, 
            String section, String key, Object value)
        {
            if (changing)
            {
                // If there are no handlers.
                if (ChangingHandler == null)
                {
                    return true;
                }

                ProfileChangingArgs e = new ProfileChangingArgs(type, section, key, value);
                OnChanging(e);
                return !e.Cancel;
            }

            // If there are no handlers.
            if (ChangedHandler != null)
            {
                OnChanged(new ProfileChangedArgs(type, section, key, value));
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnChanging(ProfileChangingArgs e)
        {
            if (ChangingHandler == null)
            {
                return;
            }

            foreach (ProfileChangingHandler handler in ChangingHandler.GetInvocationList())
            {
                handler(this, e);
                // If a particular handler cancels the event, stop
                if (e.Cancel)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnChanged(ProfileChangedArgs e)
        {
            if (ChangedHandler != null)
            {
                ChangedHandler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public virtual String GetValue(String section, String key, String defaultValue)
        {
            Object value = GetValue(section, key);
            return (value == null ? defaultValue : value.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public virtual Int32 GetValue(String section, String key, Int32 defaultValue)
        {
            Object value = GetValue(section, key);
            if (value == null)
            {
                return defaultValue;
            }

            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public virtual Double GetValue(String section, String key, Double defaultValue)
        {
            Object value = GetValue(section, key);
            if (value == null)
            {
                return defaultValue;
            }

            try
            {
                return Convert.ToDouble(value);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public virtual Boolean GetValue(String section, String key, Boolean defaultValue)
        {
            Object value = GetValue(section, key);
            if (value == null)
            {
                return defaultValue;
            }

            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual Boolean HasKey(String section, String key)
        {
            String[] entries = GetKeys(section);

            if (entries == null)
            {
                return false;
            }

            VerifyAndSanitizeKey(ref key);
            return Array.IndexOf(entries, key) >= 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public virtual Boolean HasSection(String section)
        {
            String[] sections = GetSections();

            if (sections == null)
            {
                return false;
            }

            VerifyAndSanitizeSection(ref section);
            return Array.IndexOf(sections, section) >= 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public abstract void SetValue(String section, String key, Object value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public abstract Object GetValue(String section, String key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        public abstract void RemoveKey(String section, String key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        public abstract void RemoveSection(String section);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public abstract String[] GetKeys(String section);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract String[] GetSections();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract Object Clone();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual IReadOnlyProfile CloneReadOnly()
        {
            Profile profile = (Profile)Clone();
            profile.IsReadOnly = true;

            return profile;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual String ToXmlString() 
        {
            Int32 i, j;
            StringBuilder retXml = new StringBuilder("<" + XML_ROOT + ">", XML_MAX_BUFF);
            String[] keys;
            String[] sections;
            Object value;

            sections = GetSections();
            if(sections != null) {
                for (i = 0; i < sections.Length; i++)
                {
                    retXml.Append("<");
                    retXml.Append(sections[i]);
                    retXml.Append(">");

                    keys = GetKeys(sections[i]);
                    if (keys != null) {
                        for (j = 0; j < keys.Length; j++)
                        {
                            value = GetValue(sections[i], keys[j]);
                            if (value != null)
                            {
                                retXml.Append("<");
                                retXml.Append(keys[j]);
                                retXml.Append(">");

                                retXml.Append(value);

                                retXml.Append("</");
                                retXml.Append(keys[j]);
                                retXml.Append(">");
                            }
                        }

                    }

                    retXml.Append("</");
                    retXml.Append(sections[i]);
                    retXml.Append(">");                    
                }
            }
            retXml.Append("</" + XML_ROOT + ">");
            return retXml.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlString"></param>
        public virtual void FromXmlString(String xmlString)  
        {
            throw new NotImplementedException("FromXmlString haven't been implemented");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual DataSet GetDataSet()
        {
            VerifyFileName();
            String[] sections = GetSections();
            if (sections == null)
            {
                return null;
            }

            DataSet ds = new DataSet(this._FileName);

            // Add a table for each section
            foreach (String section in sections)
            {
                DataTable table = ds.Tables.Add(section);

                // Retrieve the column names and values
                String[] keys = GetKeys(section);
                DataColumn[] columns = new DataColumn[keys.Length];
                Object[] values = new Object[keys.Length];

                Int32 i = 0;
                foreach (String key in keys)
                {
                    Object value = GetValue(section, key);

                    columns[i] = new DataColumn(key, value.GetType());
                    values[i ++] = value;
                }

                // Add the columns and values to the table
                table.Columns.AddRange(columns);
                table.Rows.Add(values);
            }

            return ds;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        public virtual void SetDataSet(DataSet ds)
        {
            if (ds == null)
            {
                throw new ArgumentNullException("ds");
            }

            // Create a section for each table
            foreach (DataTable table in ds.Tables)
            {
                String section = table.TableName;
                DataRowCollection rows = table.Rows;
                if (rows.Count == 0)
                {
                    continue;
                }

                // Loop through each column and add it as entry with value of the first row				
                foreach (DataColumn column in table.Columns)
                {
                    String key = column.ColumnName;
                    Object value = rows[0][column];

                    SetValue(section, key, value);
                }
            }
        }
    }
}
