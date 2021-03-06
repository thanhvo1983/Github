using System;
using System.Data;
using Kvics.DBAccess;

namespace Kvics.HotMill.BL
{
	/// <summary>
	/// Summary description for Config.
	/// </summary>
	public class TConfig : BaseBL
	{
		#region Static	
		public static readonly string	TABLE_NAME = "TConfig";
		public static readonly string	ID__COLUMN_NAME = "ID";
		public static readonly string	NAME__COLUMN_NAME = "Name";
		public static readonly string	VALUE__COLUMN_NAME = "Value";

        public static readonly string PARAMETER_1 = "パラメータ_１";
        public static readonly string PARAMETER_2 = "パラメータ_２";
        public static readonly string PARAMETER_3 = "パラメータ_３";
        public static readonly string PARAMETER_4 = "パラメータ_４";
        public static readonly string PARAMETER_5 = "パラメータ_５";
        public static readonly string PARAMETER_6 = "パラメータ_６";
        public static readonly string METHOD_A = "方法_Ａ";
        public static readonly string METHOD_B = "方法_Ｂ";
        public static readonly string METHOD_C = "方法_Ｃ";
        public static readonly string METHOD_D = "方法_Ｄ";
        public static readonly string METHOD_E = "方法_Ｅ";
        public static readonly string METHOD_F = "方法_Ｆ";
        public static readonly string FLAG_1 = "フラグ_１";
        public static readonly string FLAG_2 = "フラグ_２";
        public static readonly string FLAG_3 = "フラグ_３";
        public static readonly string FINISHSUPPORTFORM_MAX = "FINISHSUPPORTFORM_MAX";
		#endregion
        
		#region Protected	
		protected int	_ID = 0;
		protected string	_Name;
		protected string	_Value;
		#endregion
        
		#region Property	
		public int ID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
			}
		}

		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}

		public string Value
		{
			get
			{
				return _Value;
			}
			set
			{
				_Value = value;
			}
		}

		#endregion
        
		#region Constructors
		public TConfig()
		{
		}
        public TConfig(int id)
        {
            WhereParameterCollection whereColl = new WhereParameterCollection();
            whereColl.Add(ID__COLUMN_NAME, id, CompareType.Equal);

            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                DataSet ds = _DBAccessor.GetTable(TABLE_NAME, whereColl);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    FromDataRow(row);
                }
                else
                {
                    _ID = -1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!this.db_Set)
                {
                    _DBAccessor.Dispose();
                }
            }
        }
        public TConfig(string name)
        {
            WhereParameterCollection whereColl = new WhereParameterCollection();
            whereColl.Add(NAME__COLUMN_NAME, name, CompareType.Like);

            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                DataSet ds = _DBAccessor.GetTable(TABLE_NAME, whereColl);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    FromDataRow(row);
                }
                else
                {
                    _ID = -1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!this.db_Set)
                {
                    _DBAccessor.Dispose();
                }
            }
        }
		#endregion
		
		#region Insert/Update/Delete
		public int Insert()
		{
			ParameterCollection coll = new ParameterCollection(); 
			coll.Add(NAME__COLUMN_NAME, _Name);
			coll.Add(VALUE__COLUMN_NAME, _Value);

			
			try 
			{
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                object obj = _DBAccessor.InsertWithIdentity(TABLE_NAME, coll);
                if (obj != null)
                {
                    _ID = Convert.ToInt32(obj);
                }
                return _ID;
			}
			catch(Exception ex)
			{
                throw new Exception(ex.Message, ex);
			}
			finally
			{
                if (!this.db_Set)
                {
                    _DBAccessor.Dispose();
                }
			}
		}

		public int Update()
		{
			ParameterCollection coll = new ParameterCollection(); 
			coll.Add(NAME__COLUMN_NAME, _Name);
			coll.Add(VALUE__COLUMN_NAME, _Value);

			WhereParameterCollection whereColl = new WhereParameterCollection();
			whereColl.Add(ID__COLUMN_NAME, _ID, CompareType.Equal);

			
			try 
			{
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                return _DBAccessor.Update(TABLE_NAME, coll, whereColl);  
			}
			catch(Exception ex)
			{
                throw new Exception(ex.Message, ex);
			}
			finally
			{
                if (!this.db_Set && _DBAccessor != null)
                {
                    _DBAccessor.Dispose();
                }
			}
		}

		public int Delete()
		{
			WhereParameterCollection whereColl = new WhereParameterCollection();
			whereColl.Add(ID__COLUMN_NAME, _ID, CompareType.Equal);

			
			try 
			{
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                return _DBAccessor.Delete(TABLE_NAME, whereColl); 
			}
			catch(Exception ex)
			{
                throw new Exception(ex.Message, ex);
			}
			finally
			{
                if (!this.db_Set && _DBAccessor != null)
                {
                    _DBAccessor.Dispose();
                }
			}
		}
		#endregion

        protected void FromDataRow(DataRow row)
        {
            _ID = (int)row[ID__COLUMN_NAME];
            _Name = row[NAME__COLUMN_NAME] == DBNull.Value ? "" : (string)(row[NAME__COLUMN_NAME]);
            _Value = row[VALUE__COLUMN_NAME] == DBNull.Value ? "" : (string)(row[VALUE__COLUMN_NAME]);
        }

        public DataSet GetAll()
        {
            
            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                return _DBAccessor.GetTable(TABLE_NAME);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                if (!this.db_Set && _DBAccessor != null)
                {
                    _DBAccessor.Dispose();
                }
            }
        }
    }
}
