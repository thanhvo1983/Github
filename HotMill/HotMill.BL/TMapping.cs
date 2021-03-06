using System;
using System.Data;
using Kvics.DBAccess;

namespace Kvics.HotMill.BL
{
	/// <summary>
	/// Summary description for TMapping.
	/// </summary>
	public class TMapping : BaseBL
	{
		#region Static
		public static readonly string	TABLE_NAME = "TMapping";
		public static readonly string	ID__COLUMN_NAME = "ID";
		public static readonly string	MASTERTABLE__COLUMN_NAME = "MasterTable";
		public static readonly string	NAME__COLUMN_NAME = "Name";
		public static readonly string	ROWID__COLUMN_NAME = "RowID";

        // HSS 4 
        //public static readonly int MAPPING_COUNT = T1800_Mapping.RowsName.Length + T800_Mapping.RowsName.Length + T900_Mapping.RowsName.Length;
        public static readonly int MAPPING_COUNT = T1800_Mapping.RowsName.Length + T800_Mapping.RowsName.Length + T900_Mapping.RowsName.Length + T800_Extend_01_Mapping.RowsName.Length;
        // End HSS 4 
		#endregion
        
		#region Protected	
		protected int	_ID;
		protected string	_MasterTable;
		protected string	_Name;
		protected int	_RowID;
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

		public string MasterTable
		{
			get
			{
				return _MasterTable;
			}
			set
			{
				_MasterTable = value;
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

		public int RowID
		{
			get
			{
				return _RowID;
			}
			set
			{
				_RowID = value;
			}
		}

		#endregion
        
		#region Constructors
		public TMapping()
		{
		}
		#endregion
		
		public DataSet GetAll()
		{
			try 
			{
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }

                SortParameterCollection sortColl = new SortParameterCollection();
                sortColl.Add(NAME__COLUMN_NAME, SortType.Increase);

                return _DBAccessor.GetTable(TABLE_NAME, sortColl); 
			}
			catch(Exception)
			{
				return null;
			}
			finally
			{
                if (!this.db_Set)
                {
                    _DBAccessor.Dispose();
                }
			}
		}
        public DataSet GetAllByMasterTable(string masterTable)
        {
            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }

                WhereParameterCollection whereColl = new WhereParameterCollection();
                whereColl.Add(MASTERTABLE__COLUMN_NAME, masterTable, CompareType.Like);

                SortParameterCollection sortColl = new SortParameterCollection();
                sortColl.Add(NAME__COLUMN_NAME, SortType.Increase);

                return _DBAccessor.GetTable(TABLE_NAME, whereColl, sortColl);
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

        public static void ReloadMapping()
        {
            T900_Mapping.ReloadMapping();
            T800_Mapping.ReloadMapping();
            T1800_Mapping.ReloadMapping();
        }
	}
}
