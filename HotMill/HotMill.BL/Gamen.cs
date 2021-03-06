using System;
using System.Data;
using Kvics.DBAccess;
using log4net;

namespace Kvics.HotMill.BL
{
	/// <summary>
	/// Summary description for Gamen.
	/// </summary>
    public class Gamen : BaseBL
    {
        private static readonly ILog log = Kvics.DBAccess.Log.Instance.GetLogger(typeof(Gamen));

		#region Static	
		public static readonly string	TABLE_NAME = "Gamen";
		public static readonly string	ID__COLUMN_NAME = "ID";
		public static readonly string	MASTERID__COLUMN_NAME = "MasterID";
		public static readonly string	MASTERTYPE__COLUMN_NAME = "MasterType";
		public static readonly string	VALUES__COLUMN_NAME = "Values";
        // HSS4 or older
        //public static readonly int      VALUE__COUNT = 784;
        // HSS5
        public static readonly int      VALUE__COUNT = 916;
        // End
        public static readonly string   VALUES__SEPARATOR = ";";
		#endregion
        
		#region Protected	
		protected int	_ID;
		protected int	_MasterID;
		protected int	_MasterType;
		protected string	_Values;
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

		public int MasterID
		{
			get
			{
				return _MasterID;
			}
			set
			{
				_MasterID = value;
			}
		}

		public int MasterType
		{
			get
			{
				return _MasterType;
			}
			set
			{
				_MasterType = value;
			}
		}

		public string Values
		{
			get
			{
				return _Values;
			}
			set
			{
				_Values = value;
			}
		}

		#endregion
        
		#region Constructors
		public Gamen()
		{
            _ID = -1;
		}
        public Gamen(int id)
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

        public Gamen(int masterID, int masterType)
        {
            WhereParameterCollection whereColl = new WhereParameterCollection();
            whereColl.Add(MASTERID__COLUMN_NAME, masterID, CompareType.Equal);
            whereColl.Add(MASTERTYPE__COLUMN_NAME, masterType, CompareType.Equal);

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
			coll.Add(MASTERID__COLUMN_NAME, _MasterID);
			coll.Add(MASTERTYPE__COLUMN_NAME, _MasterType);
			coll.Add(VALUES__COLUMN_NAME, _Values);

			DBAccessor db = null;
			try 
			{
				db = new DBAccessor();
                object obj = db.InsertWithIdentity(TABLE_NAME, coll);
                _ID = Int32.Parse(obj.ToString());
                return _ID;
			}
			catch(Exception ex)
			{
                log.Error("An error occurred while inserting Gamen data.", ex);
                log.Debug("Values is: " + (_Values == null ? "null" : _Values));
				return -1;
			}
			finally
			{
				if (db != null)
					db.Dispose();
			}
		}

		public int Update()
		{
			ParameterCollection coll = new ParameterCollection(); 
			coll.Add(MASTERID__COLUMN_NAME, _MasterID);
			coll.Add(MASTERTYPE__COLUMN_NAME, _MasterType);
			coll.Add(VALUES__COLUMN_NAME, _Values);

			WhereParameterCollection whereColl = new WhereParameterCollection();
			whereColl.Add(ID__COLUMN_NAME, _ID, CompareType.Equal);

			DBAccessor db = null;
			try 
			{
				db = new DBAccessor(); 
				return db.Update( TABLE_NAME, coll, whereColl);  
			}
			catch(Exception)
			{
				return -1;
			}
			finally
			{
				if (db != null)
					db.Dispose();
			}
		}

		public int Delete()
		{
			WhereParameterCollection whereColl = new WhereParameterCollection();
			whereColl.Add(ID__COLUMN_NAME, _ID, CompareType.Equal);

			DBAccessor db = null;
			try 
			{
				db = new DBAccessor(); 
				return db.Delete( TABLE_NAME, whereColl); 
			}
			catch(Exception)
			{
				return -1;
			}
			finally
			{
				if (db != null)
					db.Dispose();
			}
		}

		public DataSet GetAll()
		{
			DBAccessor db = null;
			try 
			{
				db = new DBAccessor(); 
				return db.GetTable(TABLE_NAME); 
			}
			catch(Exception)
			{
				return null;
			}
			finally
			{
				if (db != null)
					db.Dispose();
			}
		}
        #endregion

        protected void FromDataRow(DataRow row)
        {
            _ID = (int)row[ID__COLUMN_NAME];
            _MasterID = (int)row[MASTERID__COLUMN_NAME];
            _MasterType = (int)row[MASTERTYPE__COLUMN_NAME];
            _Values = row[VALUES__COLUMN_NAME] == DBNull.Value ? null : row[VALUES__COLUMN_NAME].ToString();
        }

        public double[] GetValues()
        {   
            return ParseValues(_Values);
        }

        public double[] GetValues(int id)
        {
            Gamen gamen = new Gamen(id);
            return gamen.ID > 0 ? gamen.GetValues() : null;
        }

        public static double[] ParseValues(string values)
        {
            if (values == null)
            {
                return null;
            }
            string[] strValues = values.Split(new string[] { VALUES__SEPARATOR }, StringSplitOptions.None);

            double[] retValues = new double[VALUE__COUNT];

            for (int i = 0; i < retValues.Length; i++)
            {
                if (i >= strValues.Length)
                {
                    retValues[i] = Double.MinValue;
                }
                else
                {
                    try
                    {
                        retValues[i] = Double.Parse(strValues[i].Trim());
                    }
                    catch (Exception)
                    {
                        retValues[i] = Double.MinValue;
                    }
                }
            }

            return retValues;
        }

        public string[] GetValuesInString()
        {
            return ParseValuesInString(_Values);
        }

        public static string[] ParseValuesInString(string values)
        {
            if (values == null)
            {
                return null;
            }
            string[] strValues = values.Split(new string[] { VALUES__SEPARATOR }, StringSplitOptions.None);
            string[] retValues = new string[VALUE__COUNT];

            for (int i = 0; i < retValues.Length; i++)
            {
                if (i >= strValues.Length)
                {
                    retValues[i] = String.Empty;
                }
                else
                {
                    try
                    {
                        retValues[i] = strValues[i].Trim();
                    }
                    catch (Exception)
                    {
                        retValues[i] = String.Empty;
                    }
                }
            }

            return retValues;
        }

        public string[] GetValuesInString(int id)
        {
            Gamen gamen = new Gamen(id);
            return gamen.ID > 0 ? gamen.GetValuesInString() : null;
        }

        public static DataSet GetLast101CoilList(int masterType)
        {
            string strSQL = "";
            switch (masterType)
            {
                case 1:
                    // this is a good SQL Query, but performance is not good
                    //strSQL = "select top 101 [gm].*, [T900].[R025_コイルＮｏ] from  [Gamen] as [gm] inner join [T900_仕上予備計算情報] as [T900] on [gm].[MasterID] = [T900].[ID] where [gm].[MasterType] = 1 and 1 > (select count([ID])  from [T900_仕上予備計算情報] as [T900_1]  where [T900_1].[R025_コイルＮｏ] = [T900].[R025_コイルＮｏ]  and [T900_1].[ID] > [T900].[ID]) order by [gm].[ID] desc";
                    // and this is updated SQL Query for fast performance
                    //strSQL = "IF OBJECT_ID('tempdb..#abc') IS NOT NULL BEGIN DROP TABLE #abc END ; select top 101 [T900].[R025_コイルＮｏ] , [T900].[ID] into #abc from  [T900_仕上予備計算情報] as [T900]  where not exists  (select [ID]  from [T900_仕上予備計算情報] as [T900_1]   where [T900_1].[R025_コイルＮｏ] = [T900].[R025_コイルＮｏ] and [T900_1].[R033_圧延日_年] = [T900].[R033_圧延日_年] and [T900_1].[ID] > [T900].[ID]) order by [T900].[ID] desc ; select [Gamen].*, #abc.[R025_コイルＮｏ]  from [Gamen] inner join #abc on [Gamen].[MasterID] = #abc.[ID] where [Gamen].[MasterType] = 1";
                    strSQL = "EXEC Top101GamenT900;";
                    //strSQL = @"IF OBJECT_ID('tempdb..#abc') IS NOT NULL BEGIN DROP TABLE #abc END ; select top 101 [T900].[R025_コイルＮｏ] , [T900].[ID] into #abc from  [T900_仕上予備計算情報] as [T900]  where not exists  (select [ID]  from [T900_仕上予備計算情報] as [T900_1]   where [T900_1].[R025_コイルＮｏ] = [T900].[R025_コイルＮｏ] and [T900_1].[R033_圧延日_年] = [T900].[R033_圧延日_年] and [T900_1].[ID] > [T900].[ID]) order by [T900].[ID] desc ; select *  from [Gamen] inner join #abc on [Gamen].[MasterID] = #abc.[ID] where [Gamen].[MasterType] = 1";
                    break;
                case 2:
                    strSQL = "select top 101 [gm].* from  [Gamen] as [gm] where [gm].[MasterType] = 2 order by [gm].[ID] desc";
                    strSQL = "select * from (" + strSQL + ") as [gm] order by [gm].[ID]";
                    break;
                case 3:
                    strSQL = "select top 101 [gm].* from  [Gamen] as [gm] where [gm].[MasterType] = 3 order by [gm].[ID] desc";
                    strSQL = "select * from (" + strSQL + ") as [gm] order by [gm].[ID]";
                    break;
                case 4:
                    strSQL = "select top 101 [gm].* from  [Gamen] as [gm] where [gm].[MasterType] = 4 order by [gm].[ID] desc";
                    strSQL = "select * from (" + strSQL + ") as [gm] order by [gm].[ID]";
                    break;
                default:
                    return null;
            }

            //strSQL = "select * from (" + strSQL + ") as [gm] order by [gm].[ID]";

            DBAccessor _DBAccessor = null;
            try
            {
                _DBAccessor = new DBAccessor();
                DataSet ds = _DBAccessor.ExecuteQueryString(strSQL);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _DBAccessor.Dispose();
            }
        }

        public DataSet GetLast101CoilList()
        {
            return Gamen.GetLast101CoilList(this._MasterType);
        }

        public static bool RemoveOldCoil(int masterType, int skip)
        {
            DBAccessor db = null;
            try
            {
                db = new DBAccessor();

                ParameterCollection paramColl = new ParameterCollection();
                paramColl.Add("MasterType", masterType);
                paramColl.Add("MasterType2", masterType);

                string strSQL = "delete from [" + TABLE_NAME + "] where [" + MASTERTYPE__COLUMN_NAME + "] = @MasterType and ID not in (select top " + skip.ToString("###;-###;0") + " [ID] from [" + TABLE_NAME + "] as GM where GM.[" + MASTERTYPE__COLUMN_NAME + "] = @MasterType2 order by ID desc)";

                db.ExecuteNonQueryString(strSQL, paramColl);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (db != null)
                    db.Dispose();
            }
        }
	}
}
