using System;
using System.Data;
using System.Text;
using Kvics.DBAccess;

using log4net;
using log4net.Config;

namespace Kvics.HotMill.BL
{
	/// <summary>
	/// Summary description for T200.
	/// </summary>
	public class T200 : BaseBL
	{
        #region Static
        protected static readonly ILog log = Log.Instance.GetLogger(typeof(T1800));

        public static readonly string   TRANSACTION_CODE = "00030002";
		public static readonly string	TABLE_NAME = "T200_仕上同時点実績情報";
		public static readonly string	ID__COLUMN_NAME = "ID";
		public static readonly string	R025__COLUMN_NAME = "R025_コイルＮｏ";
		public static readonly string	R033__COLUMN_NAME = "R033_圧延日_年";
		public static readonly string	R035__COLUMN_NAME = "R035_圧延日_月";
		public static readonly string	R037__COLUMN_NAME = "R037_圧延日_日";
		public static readonly string	R039__COLUMN_NAME = "R039_勤";
		public static readonly string	R041__COLUMN_NAME = "R041_班";
		public static readonly string	R043__COLUMN_NAME = "R043_圧延順";
        public static readonly string   R045__COLUMN_NAME = "R045_スラブ番号";
        public static readonly string   R055__COLUMN_NAME = "R055_圧延指令番号";
        public static readonly string   R061__COLUMN_NAME = "R061_圧下位置差テーブル層別区分_板厚区分";
        public static readonly string   R063__COLUMN_NAME = "R063_圧下位置差テーブル層別区分_板幅区分";
        public static readonly string   R065__COLUMN_NAME = "R065_圧下位置差テーブル層別区分_強度区分";
        public static readonly string   R067__COLUMN_NAME = "R067_同期スタンド";
        public static readonly string   R069__COLUMN_NAME = "R069_材料判別コード";
        public static readonly string   R071__COLUMN_NAME = "R071_Ｎｉ鋼フラグ";
        public static readonly string   R073__COLUMN_NAME = "R073_鋼種名";
		public static readonly string	R081__COLUMN_NAME = "R081_熱間強度";
		public static readonly string	R083__COLUMN_NAME = "R083_ＲＢ横ぶれ量ＴＯＰ";
		public static readonly string	R085__COLUMN_NAME = "R085_ＨＣクラウン_TC25";
		public static readonly string	R087__COLUMN_NAME = "R087_ＨＣクラウン_TC75";
		public static readonly string	R089__COLUMN_NAME = "R089_ＨＣクラウン_位置１";
		public static readonly string	R091__COLUMN_NAME = "R091_ＨＣクラウン_ｸﾗｳﾝ１";
		public static readonly string	R093__COLUMN_NAME = "R093_ＨＣクラウン_位置２";
		public static readonly string	R095__COLUMN_NAME = "R095_ＨＣクラウン_ｸﾗｳﾝ２";
		public static readonly string	R097__COLUMN_NAME = "R097_ベンダー力同時点_F1";
		public static readonly string	R099__COLUMN_NAME = "R099_ベンダー力同時点_F2";
		public static readonly string	R101__COLUMN_NAME = "R101_ベンダー力同時点_F3";
		public static readonly string	R103__COLUMN_NAME = "R103_ベンダー力同時点_F4";
		public static readonly string	R105__COLUMN_NAME = "R105_ベンダー力同時点_F5";
		public static readonly string	R107__COLUMN_NAME = "R107_ベンダー力同時点_F6";
		public static readonly string	R109__COLUMN_NAME = "R109_ベンダー力同時点_F7";
		public static readonly string	WORKER_ID__COLUMN_NAME = "Worker_ID";
		public static readonly string	LASTUPDATE__COLUMN_NAME = "LastUpdate";
		#endregion
        
		#region Protected	
		protected int	_ID;
		protected string	_R025;
		protected int	_R033;
		protected int	_R035;
		protected int	_R037;
		protected int	_R039;
		protected string	_R041;
		protected int	_R043;
        protected string    _R045;
        protected string    _R055;
        protected int   _R061;
        protected int   _R063;
        protected int   _R065;
        protected int   _R067;
        protected int   _R069;
        protected int   _R071;
        protected string    _R073;
		protected int	_R081;
		protected int	_R083;
		protected int	_R085;
		protected int	_R087;
		protected int	_R089;
		protected int	_R091;
		protected int	_R093;
		protected int	_R095;
		protected int	_R097;
		protected int	_R099;
		protected int	_R101;
		protected int	_R103;
		protected int	_R105;
		protected int	_R107;
		protected int	_R109;
		protected int	_Worker_ID;
		protected DateTime	_LastUpdate;
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

		public string R025
		{
			get
			{
				return _R025;
			}
			set
			{
                _R025 = Common.GetString(value, 0, 8, ' ', 2);
			}
		}

		public int R033
		{
			get
			{
				return _R033;
			}
			set
			{
				_R033 = value;
			}
		}

		public int R035
		{
			get
			{
				return _R035;
			}
			set
			{
				_R035 = value;
			}
		}

		public int R037
		{
			get
			{
				return _R037;
			}
			set
			{
				_R037 = value;
			}
		}

		public int R039
		{
			get
			{
				return _R039;
			}
			set
			{
				_R039 = value;
			}
		}

		public string R041
		{
			get
			{
				return _R041;
			}
			set
			{
                _R041 = Common.GetString(value, 0, 2, ' ', 2);
			}
		}

		public int R043
		{
			get
			{
				return _R043;
			}
			set
			{
				_R043 = value;
			}
		}

        public string R045
        {
            get
            {
                return _R045;
            }
            set
            {
                _R045 = Common.GetString(value, 0, 10, ' ', 2);
            }
        }

        public string R055
        {
            get
            {
                return _R055;
            }
            set
            {
                _R055 = Common.GetString(value, 0, 6, ' ', 2);
            }
        }

        public int R061
        {
            get
            {
                return _R061;
            }
            set
            {
                _R061 = value;
            }
        }

        public int R063
        {
            get
            {
                return _R063;
            }
            set
            {
                _R063 = value;
            }
        }

        public int R065
        {
            get
            {
                return _R065;
            }
            set
            {
                _R065 = value;
            }
        }

        public int R067
        {
            get
            {
                return _R067;
            }
            set
            {
                _R067 = value;
            }
        }

        public int R069
        {
            get
            {
                return _R069;
            }
            set
            {
                _R069 = value;
            }
        }

        public int R071
        {
            get
            {
                return _R071;
            }
            set
            {
                _R071 = value;
            }
        }

        public string R073
        {
            get
            {
                return _R073;
            }
            set
            {
                _R073 = Common.GetString(value, 0, 8, ' ', 2);
            }
        }

		public int R081
		{
			get
			{
				return _R081;
			}
			set
			{
				_R081 = value;
			}
		}

		public int R083
		{
			get
			{
				return _R083;
			}
			set
			{
				_R083 = value;
			}
		}

		public int R085
		{
			get
			{
				return _R085;
			}
			set
			{
				_R085 = value;
			}
		}

		public int R087
		{
			get
			{
				return _R087;
			}
			set
			{
				_R087 = value;
			}
		}

		public int R089
		{
			get
			{
				return _R089;
			}
			set
			{
				_R089 = value;
			}
		}

		public int R091
		{
			get
			{
				return _R091;
			}
			set
			{
				_R091 = value;
			}
		}

		public int R093
		{
			get
			{
				return _R093;
			}
			set
			{
				_R093 = value;
			}
		}

		public int R095
		{
			get
			{
				return _R095;
			}
			set
			{
				_R095 = value;
			}
		}

		public int R097
		{
			get
			{
				return _R097;
			}
			set
			{
				_R097 = value;
			}
		}

		public int R099
		{
			get
			{
				return _R099;
			}
			set
			{
				_R099 = value;
			}
		}

		public int R101
		{
			get
			{
				return _R101;
			}
			set
			{
				_R101 = value;
			}
		}

		public int R103
		{
			get
			{
				return _R103;
			}
			set
			{
				_R103 = value;
			}
		}

		public int R105
		{
			get
			{
				return _R105;
			}
			set
			{
				_R105 = value;
			}
		}

		public int R107
		{
			get
			{
				return _R107;
			}
			set
			{
				_R107 = value;
			}
		}

		public int R109
		{
			get
			{
				return _R109;
			}
			set
			{
				_R109 = value;
			}
		}

		public int Worker_ID
		{
			get
			{
				return _Worker_ID;
			}
			set
			{
				_Worker_ID = value;
			}
		}

		public DateTime LastUpdate
		{
			get
			{
				return _LastUpdate;
			}
			set
			{
				_LastUpdate = value;
			}
		}

		#endregion
        
		#region Constructors
		public T200()
		{
            _ID = 0;
		}
        public T200(int iD)
        {
            if (!this.db_Set)
            {
                _DBAccessor = new DBAccessor();
            }
            WhereParameterCollection whereColl = new WhereParameterCollection();
            whereColl.Add(ID__COLUMN_NAME, iD, CompareType.Equal);
            try
            {
                DataSet ds = _DBAccessor.GetTable(TABLE_NAME, whereColl);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    this.FromDataRow(ds.Tables[0].Rows[0]);
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
			coll.Add(R025__COLUMN_NAME, _R025);
			coll.Add(R033__COLUMN_NAME, _R033);
			coll.Add(R035__COLUMN_NAME, _R035);
			coll.Add(R037__COLUMN_NAME, _R037);
			coll.Add(R039__COLUMN_NAME, _R039);
			coll.Add(R041__COLUMN_NAME, _R041);
			coll.Add(R043__COLUMN_NAME, _R043);
            coll.Add(R045__COLUMN_NAME, _R045);
            coll.Add(R055__COLUMN_NAME, _R055);
            coll.Add(R061__COLUMN_NAME, _R061);
            coll.Add(R063__COLUMN_NAME, _R063);
            coll.Add(R065__COLUMN_NAME, _R065);
            coll.Add(R067__COLUMN_NAME, _R067);
            coll.Add(R069__COLUMN_NAME, _R069);
            coll.Add(R071__COLUMN_NAME, _R071);
            coll.Add(R073__COLUMN_NAME, _R073);
			coll.Add(R081__COLUMN_NAME, _R081);
			coll.Add(R083__COLUMN_NAME, _R083);
			coll.Add(R085__COLUMN_NAME, _R085);
			coll.Add(R087__COLUMN_NAME, _R087);
			coll.Add(R089__COLUMN_NAME, _R089);
			coll.Add(R091__COLUMN_NAME, _R091);
			coll.Add(R093__COLUMN_NAME, _R093);
			coll.Add(R095__COLUMN_NAME, _R095);
			coll.Add(R097__COLUMN_NAME, _R097);
			coll.Add(R099__COLUMN_NAME, _R099);
			coll.Add(R101__COLUMN_NAME, _R101);
			coll.Add(R103__COLUMN_NAME, _R103);
			coll.Add(R105__COLUMN_NAME, _R105);
			coll.Add(R107__COLUMN_NAME, _R107);
			coll.Add(R109__COLUMN_NAME, _R109);
			coll.Add(WORKER_ID__COLUMN_NAME, _Worker_ID);
			coll.Add(LASTUPDATE__COLUMN_NAME, DateTime.Now);

			try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                object obj = _DBAccessor.InsertWithIdentity(TABLE_NAME, coll);
                _ID = Int32.Parse(obj.ToString());
                return _ID;
			}
			catch(Exception)
			{
				return -1;
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
			coll.Add(R025__COLUMN_NAME, _R025);
			coll.Add(R033__COLUMN_NAME, _R033);
			coll.Add(R035__COLUMN_NAME, _R035);
			coll.Add(R037__COLUMN_NAME, _R037);
			coll.Add(R039__COLUMN_NAME, _R039);
			coll.Add(R041__COLUMN_NAME, _R041);
            coll.Add(R043__COLUMN_NAME, _R043);
            coll.Add(R045__COLUMN_NAME, _R045);
            coll.Add(R055__COLUMN_NAME, _R055);
            coll.Add(R061__COLUMN_NAME, _R061);
            coll.Add(R063__COLUMN_NAME, _R063);
            coll.Add(R065__COLUMN_NAME, _R065);
            coll.Add(R067__COLUMN_NAME, _R067);
            coll.Add(R069__COLUMN_NAME, _R069);
            coll.Add(R071__COLUMN_NAME, _R071);
            coll.Add(R073__COLUMN_NAME, _R073);
			coll.Add(R081__COLUMN_NAME, _R081);
			coll.Add(R083__COLUMN_NAME, _R083);
			coll.Add(R085__COLUMN_NAME, _R085);
			coll.Add(R087__COLUMN_NAME, _R087);
			coll.Add(R089__COLUMN_NAME, _R089);
			coll.Add(R091__COLUMN_NAME, _R091);
			coll.Add(R093__COLUMN_NAME, _R093);
			coll.Add(R095__COLUMN_NAME, _R095);
			coll.Add(R097__COLUMN_NAME, _R097);
			coll.Add(R099__COLUMN_NAME, _R099);
			coll.Add(R101__COLUMN_NAME, _R101);
			coll.Add(R103__COLUMN_NAME, _R103);
			coll.Add(R105__COLUMN_NAME, _R105);
			coll.Add(R107__COLUMN_NAME, _R107);
			coll.Add(R109__COLUMN_NAME, _R109);
			coll.Add(WORKER_ID__COLUMN_NAME, _Worker_ID);
			coll.Add(LASTUPDATE__COLUMN_NAME, DateTime.Now);

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
			catch(Exception)
			{
				return -1;
			}
			finally
            {
                if (!this.db_Set)
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
			catch(Exception)
			{
				return -1;
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

        protected void FromDataRow(DataRow row)
        {
            _ID = (int)row[ID__COLUMN_NAME];
            _Worker_ID = row[WORKER_ID__COLUMN_NAME] == DBNull.Value ? (int)0 : (int)(row[WORKER_ID__COLUMN_NAME]);
            _R025 = row[R025__COLUMN_NAME] == DBNull.Value ? null : (string)row[R025__COLUMN_NAME];
            _R033 = row[R033__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R033__COLUMN_NAME];
            _R035 = row[R035__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R035__COLUMN_NAME];
            _R037 = row[R037__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R037__COLUMN_NAME];
            _R039 = row[R039__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R039__COLUMN_NAME];
            _R041 = row[R041__COLUMN_NAME] == DBNull.Value ? null : (string)row[R041__COLUMN_NAME];
            _R043 = row[R043__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R043__COLUMN_NAME];
            _R045 = row[R045__COLUMN_NAME] == DBNull.Value ? null : (string)row[R045__COLUMN_NAME];
            _R055 = row[R055__COLUMN_NAME] == DBNull.Value ? null : (string)row[R055__COLUMN_NAME];
            _R061 = row[R061__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R061__COLUMN_NAME];
            _R063 = row[R063__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R063__COLUMN_NAME];
            _R065 = row[R065__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R065__COLUMN_NAME];
            _R067 = row[R067__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R067__COLUMN_NAME];
            _R069 = row[R069__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R069__COLUMN_NAME];
            _R071 = row[R071__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R071__COLUMN_NAME];
            _R073 = row[R073__COLUMN_NAME] == DBNull.Value ? null : (string)row[R073__COLUMN_NAME];
            _R081 = row[R081__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R081__COLUMN_NAME];
            _R083 = row[R083__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R083__COLUMN_NAME];
            _R085 = row[R085__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R085__COLUMN_NAME];
            _R087 = row[R087__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R087__COLUMN_NAME];
            _R089 = row[R089__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R089__COLUMN_NAME];
            _R091 = row[R091__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R091__COLUMN_NAME];
            _R093 = row[R093__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R093__COLUMN_NAME];
            _R095 = row[R095__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R095__COLUMN_NAME];
            _R097 = row[R097__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R097__COLUMN_NAME];
            _R099 = row[R099__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R099__COLUMN_NAME];
            _R101 = row[R101__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R101__COLUMN_NAME];
            _R103 = row[R103__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R103__COLUMN_NAME];
            _R105 = row[R105__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R105__COLUMN_NAME];
            _R107 = row[R107__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R107__COLUMN_NAME];
            _R109 = row[R109__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)row[R109__COLUMN_NAME];
            _LastUpdate = row[LASTUPDATE__COLUMN_NAME] == DBNull.Value ? DateTime.Now : (DateTime)row[LASTUPDATE__COLUMN_NAME];
        }

        public static T200 GetLast()
        {
            DBAccessor _DBAccessor = null;
            try
            {
                _DBAccessor = new DBAccessor();
                object obj = _DBAccessor.MaxValue(TABLE_NAME, ID__COLUMN_NAME);

                if (obj != null && obj != DBNull.Value)
                {
                    int maxId = Convert.ToInt32(obj);

                    return new T200(maxId);
                }

                return null;
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

        public T200 GetPreviousResult()
        {
            if (_ID > 1)
            {
                WhereParameterCollection whereColl = new WhereParameterCollection();
                whereColl.Add(ID__COLUMN_NAME, _ID, CompareType.Less);

                try
                {
                    if (!this.db_Set)
                    {
                        _DBAccessor = new DBAccessor();
                    }
                    object obj = _DBAccessor.MaxValue(TABLE_NAME, ID__COLUMN_NAME, whereColl);

                    if (obj != null && obj != DBNull.Value)
                    {
                        int preId = Convert.ToInt32(obj);

                        return new T200(preId);
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
            return null;
        }

        public static T200 GetCoilDetailOfYear(string coilNo, int year)
        {
            WhereParameterCollection whereColl = new WhereParameterCollection();
            whereColl.Add(R025__COLUMN_NAME, coilNo, CompareType.Equal);
            whereColl.Add(R033__COLUMN_NAME, year, CompareType.Equal);


            DBAccessor _DBAccessor = null;
            try
            {
                _DBAccessor = new DBAccessor();
                DataSet data_Set = _DBAccessor.GetTable(TABLE_NAME, whereColl);

                if (data_Set != null && data_Set.Tables[0].Rows.Count != 0)
                {
                    DataRow row = data_Set.Tables[0].Rows[0];
                    T200 t200 = new T200();
                    t200.FromDataRow(row);
                    return t200;
                }

                return null;
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

        public static long RecordCount()
        {
            DBAccessor db = null;
            try
            {
                db = new DBAccessor();
                return db.RecordCount(TABLE_NAME);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db != null)
                {
                    db.Dispose();
                }
            }
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
            catch (Exception)
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

        public DataSet GetAll(string sortCollumn, SortType sortType)
        {
            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }

                SortParameterCollection sortColl = new SortParameterCollection();
                sortColl.Add(sortCollumn, sortType);

                return _DBAccessor.GetTable(TABLE_NAME, sortColl);
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

        public static T200 Parse(Byte[] data)
        {
            log.Debug("Begin public static T200 Parse(Byte[] data)");
            if (data == null || data.Length != 184)
            {
                if (data == null)
                {
                    log.Debug("Data is null.");
                }
                else
                {
                    log.Debug("Data error. Data length: " + data.Length.ToString());
                }
                return null;
            }

            T200 t200 = new T200();

            try
            {
                t200.ID = 0;
                t200.R025 = Common.GetString(data, 8, 8);
                t200.R033 = Common.ToInt16(data, 16);
                if (t200.R033 < 100)
                {
                    t200.R033 += 2000;
                    t200.R033 = (Int16)(t200.R033 > DateTime.Now.Year ? (t200.R033 - 100) : t200.R033);
                }
                t200.R035 = Common.ToInt16(data, 18);
                t200.R037 = Common.ToInt16(data, 20);
                t200.R039 = Common.ToInt16(data, 22);
                t200.R041 = Common.GetString(data, 24, 2);
                t200.R043 = Common.ToInt16(data, 26);
                t200.R045 = Common.GetString(data, 28, 10);
                t200.R055 = Common.GetString(data, 38, 6);
                t200.R061 = Common.ToInt16(data, 44);
                t200.R063 = Common.ToInt16(data, 46);
                t200.R065 = Common.ToInt16(data, 48);
                t200.R067 = Common.ToInt16(data, 50);
                t200.R069 = Common.ToInt16(data, 52);
                t200.R071 = Common.ToInt16(data, 54);
                t200.R073 = Common.GetString(data, 56, 8);
                t200.R081 = Common.ToInt16(data, 64);
                t200.R083 = Common.ToInt16(data, 66);

                //ＨＣクラウン
                t200.R085 = Common.ToInt16(data, 68);
                t200.R087 = Common.ToInt16(data, 70);
                t200.R089 = Common.ToInt16(data, 72);
                t200.R091 = Common.ToInt16(data, 74);
                t200.R093 = Common.ToInt16(data, 76);
                t200.R095 = Common.ToInt16(data, 78);

                //ベンダー力　同時点
                t200.R097 = Common.ToInt16(data, 80);
                t200.R099 = Common.ToInt16(data, 82);
                t200.R101 = Common.ToInt16(data, 84);
                t200.R103 = Common.ToInt16(data, 86);
                t200.R105 = Common.ToInt16(data, 88);
                t200.R107 = Common.ToInt16(data, 90);
                t200.R109 = Common.ToInt16(data, 92);

                log.Debug("T200.Parse() finished.");
            }
            catch (Exception ex)
            {
                log.Error("T200.Parse() error.", ex);
                Console.WriteLine(ex.Message);
                return null;
            }
            log.Debug("T200.Parse() successfull.");
            return t200;
        }

        public byte[] GetBytes()
        {
            Byte[] data = new Byte[184];

            try
            {
                Buffer.BlockCopy(Common.GetBytes(TRANSACTION_CODE), 0, data, 0, 8);
                Buffer.BlockCopy(Common.GetBytes(_R025), 0, data, 8, 8);
                Buffer.BlockCopy(Common.GetBytes(((Int16)_R033 % 100)), 0, data, 16, 2);
                Buffer.BlockCopy(Common.GetBytes(_R035), 0, data, 18, 2);
                Buffer.BlockCopy(Common.GetBytes(_R037), 0, data, 20, 2);
                Buffer.BlockCopy(Common.GetBytes(_R039), 0, data, 22, 2);
                Buffer.BlockCopy(Common.GetBytes(_R041), 0, data, 24, 2);
                Buffer.BlockCopy(Common.GetBytes(_R043), 0, data, 26, 2);
                Buffer.BlockCopy(Common.GetBytes(_R045), 0, data, 28, 10);
                Buffer.BlockCopy(Common.GetBytes(_R055), 0, data, 38, 6);
                Buffer.BlockCopy(Common.GetBytes(_R061), 0, data, 44, 2);
                Buffer.BlockCopy(Common.GetBytes(_R063), 0, data, 46, 2);
                Buffer.BlockCopy(Common.GetBytes(_R065), 0, data, 48, 2);
                Buffer.BlockCopy(Common.GetBytes(_R067), 0, data, 50, 2);
                Buffer.BlockCopy(Common.GetBytes(_R069), 0, data, 52, 2);
                Buffer.BlockCopy(Common.GetBytes(_R071), 0, data, 54, 2);
                Buffer.BlockCopy(Common.GetBytes(_R073), 0, data, 56, 8);
                Buffer.BlockCopy(Common.GetBytes(_R081), 0, data, 64, 2);
                Buffer.BlockCopy(Common.GetBytes(_R083), 0, data, 66, 2);
                //ＨＣクラウン
                Buffer.BlockCopy(Common.GetBytes(_R085), 0, data, 68, 2);
                Buffer.BlockCopy(Common.GetBytes(_R087), 0, data, 70, 2);
                Buffer.BlockCopy(Common.GetBytes(_R089), 0, data, 72, 2);
                Buffer.BlockCopy(Common.GetBytes(_R091), 0, data, 74, 2);
                Buffer.BlockCopy(Common.GetBytes(_R093), 0, data, 76, 2);
                Buffer.BlockCopy(Common.GetBytes(_R095), 0, data, 78, 2);
                //ベンダー力　同時点
                Buffer.BlockCopy(Common.GetBytes(_R097), 0, data, 80, 2);
                Buffer.BlockCopy(Common.GetBytes(_R099), 0, data, 82, 2);
                Buffer.BlockCopy(Common.GetBytes(_R101), 0, data, 84, 2);
                Buffer.BlockCopy(Common.GetBytes(_R103), 0, data, 86, 2);
                Buffer.BlockCopy(Common.GetBytes(_R105), 0, data, 88, 2);
                Buffer.BlockCopy(Common.GetBytes(_R107), 0, data, 90, 2);
                Buffer.BlockCopy(Common.GetBytes(_R109), 0, data, 92, 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            return data;
        }

        public bool Equals(T200 t200)
        {
            if (t200 == null)
            {
                return false;
            }
            if (
                !_R025.Equals(t200.R025, StringComparison.OrdinalIgnoreCase) ||
                _R033 != t200.R033 ||
                _R035 != t200.R035 ||
                _R037 != t200.R037 ||
                _R039 != t200.R039 ||
                !_R041.Equals(t200.R041, StringComparison.OrdinalIgnoreCase) ||
                _R043 != t200.R043 ||
                !_R045.Equals(t200.R045, StringComparison.OrdinalIgnoreCase) ||
                !_R055.Equals(t200.R055, StringComparison.OrdinalIgnoreCase) ||
                _R061 != t200.R061 ||
                _R063 != t200.R063 ||
                _R065 != t200.R065 ||
                _R067 != t200.R067 ||
                _R069 != t200.R069 ||
                _R071 != t200.R071 ||
                !_R073.Equals(t200._R073, StringComparison.OrdinalIgnoreCase) ||
                _R081 != t200.R081 ||
                _R083 != t200.R083 ||
                //ＨＣクラウン
                _R085 != t200.R085 ||
                _R087 != t200.R087 ||
                _R089 != t200.R089 ||
                _R091 != t200.R091 ||
                _R093 != t200.R093 ||
                _R095 != t200.R095 ||
                //ベンダー力　同時点
                _R097 != t200.R097 ||
                _R099 != t200.R099 ||
                _R101 != t200.R101 ||
                _R103 != t200.R103 ||
                _R105 != t200.R105 ||
                _R107 != t200.R107 ||
                _R109 != t200.R109
                )
                return false;

            return true;
        }
	}
}
