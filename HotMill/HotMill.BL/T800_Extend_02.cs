using System;
using System.Data;

using Kvics.DBAccess;

namespace Kvics.HotMill.BL
{
    public class T800_Extend_02 : T_I2_R
    {
        #region Static
        public static readonly string TABLE_NAME = "T800_Extend_02";

        public static readonly string R451__COLUMN_NAME = "R451_ベンダー設定モード";
        public static readonly string R453__COLUMN_NAME = "R453_ベンダーサーマルゲイン_F1";
        public static readonly string R455__COLUMN_NAME = "R455_ベンダーサーマルゲイン_F2";
        public static readonly string R457__COLUMN_NAME = "R457_ベンダーサーマルゲイン_F3";
        public static readonly string R459__COLUMN_NAME = "R459_ベンダーサーマルゲイン_F4";
        public static readonly string R461__COLUMN_NAME = "R461_ベンダーサーマルゲイン_F5";
        public static readonly string R463__COLUMN_NAME = "R463_ベンダーサーマルゲイン_F6";
        public static readonly string R465__COLUMN_NAME = "R465_ベンダーサーマルゲイン_F7";
        
        public static readonly int EXTEND_PAKAGE_LENGTH = 16;
        #endregion

        #region Property
        public Int16 R451
        {
            get
            {
                return _Rows[0];
            }
            set
            {
                _Rows[0] = value;
            }
        }

        public Int16 R453
        {
            get
            {
                return _Rows[1];
            }
            set
            {
                _Rows[1] = value;
            }
        }

        public Int16 R455
        {
            get
            {
                return _Rows[2];
            }
            set
            {
                _Rows[2] = value;
            }
        }

        public Int16 R457
        {
            get
            {
                return _Rows[3];
            }
            set
            {
                _Rows[3] = value;
            }
        }

        public Int16 R459
        {
            get
            {
                return _Rows[4];
            }
            set
            {
                _Rows[4] = value;
            }
        }

        public Int16 R461
        {
            get
            {
                return _Rows[5];
            }
            set
            {
                _Rows[5] = value;
            }
        }

        public Int16 R463
        {
            get
            {
                return _Rows[6];
            }
            set
            {
                _Rows[6] = value;
            }
        }

        public Int16 R465
        {
            get
            {
                return _Rows[7];
            }
            set
            {
                _Rows[7] = value;
            }
        }
        #endregion

        #region Constructors
        public T800_Extend_02()
            : base()
        {
            this._Rows = new Int16[8];
        }

        public T800_Extend_02(DBAccessor dbAccessor)
            : base(dbAccessor)
        {
            this._Rows = new Int16[8];
        }

        public T800_Extend_02(int parentID, int rowID)
            : base()
        {
            WhereParameterCollection whereColl = new WhereParameterCollection();
            whereColl.Add(PARENTID__COLUMN_NAME, parentID, CompareType.Equal);
            whereColl.Add(ROWID__COLUMN_NAME, rowID, CompareType.Equal);

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

        public T800_Extend_02(int parentID, int rowID,
            Int16 r1, Int16 r2, Int16 r3, Int16 r4, Int16 r5, Int16 r6, Int16 r7, Int16 r8)
            : base(parentID, rowID, new Int16[] { r1, r2, r3, r4, r5, r6, r7, r8 })
        {
        }
        #endregion

        protected void FromDataRow(DataRow row)
        {
            _Rows = new Int16[10];

            _ID = (int)row[ID__COLUMN_NAME];
            _ParentID = (int)row[PARENTID__COLUMN_NAME];
            _RowID = (int)row[ROWID__COLUMN_NAME];

            _Rows[0] = row[R451__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R451__COLUMN_NAME]);
            _Rows[1] = row[R453__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R453__COLUMN_NAME]);
            _Rows[2] = row[R455__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R455__COLUMN_NAME]);
            _Rows[3] = row[R457__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R457__COLUMN_NAME]);
            _Rows[4] = row[R459__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R459__COLUMN_NAME]);
            _Rows[5] = row[R461__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R461__COLUMN_NAME]);
            _Rows[6] = row[R463__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R463__COLUMN_NAME]);
            _Rows[7] = row[R465__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R465__COLUMN_NAME]);
        }

        #region Insert/Update/Delete
        public override int Insert()
        {
            ParameterCollection coll = new ParameterCollection();
            coll.Add(new Parameter(PARENTID__COLUMN_NAME, _ParentID));
            coll.Add(new Parameter(ROWID__COLUMN_NAME, _RowID));

            coll.Add(new Parameter(R451__COLUMN_NAME, _Rows[0]));
            coll.Add(new Parameter(R453__COLUMN_NAME, _Rows[1]));
            coll.Add(new Parameter(R455__COLUMN_NAME, _Rows[2]));
            coll.Add(new Parameter(R457__COLUMN_NAME, _Rows[3]));
            coll.Add(new Parameter(R459__COLUMN_NAME, _Rows[4]));
            coll.Add(new Parameter(R461__COLUMN_NAME, _Rows[5]));
            coll.Add(new Parameter(R463__COLUMN_NAME, _Rows[6]));
            coll.Add(new Parameter(R465__COLUMN_NAME, _Rows[7]));

            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                return _DBAccessor.Insert(TABLE_NAME, coll);
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

        public override int Update()
        {
            ParameterCollection coll = new ParameterCollection();
            coll.Add(new Parameter(R451__COLUMN_NAME, _Rows[0]));
            coll.Add(new Parameter(R453__COLUMN_NAME, _Rows[1]));
            coll.Add(new Parameter(R455__COLUMN_NAME, _Rows[2]));
            coll.Add(new Parameter(R457__COLUMN_NAME, _Rows[3]));
            coll.Add(new Parameter(R459__COLUMN_NAME, _Rows[4]));
            coll.Add(new Parameter(R461__COLUMN_NAME, _Rows[5]));
            coll.Add(new Parameter(R463__COLUMN_NAME, _Rows[6]));
            coll.Add(new Parameter(R465__COLUMN_NAME, _Rows[7]));

            WhereParameterCollection whereColl = new WhereParameterCollection();
            whereColl.Add(new WhereParameter(PARENTID__COLUMN_NAME, _ParentID, CompareType.Equal));
            whereColl.Add(ROWID__COLUMN_NAME, _RowID, CompareType.Equal);

            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                return _DBAccessor.Update(TABLE_NAME, coll, whereColl);
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

        public override int Delete()
        {
            WhereParameterCollection whereColl = new WhereParameterCollection();
            whereColl.Add(new WhereParameter(PARENTID__COLUMN_NAME, _ParentID, CompareType.Equal));
            whereColl.Add(ROWID__COLUMN_NAME, _RowID, CompareType.Equal);

            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                return _DBAccessor.Delete(TABLE_NAME, whereColl);
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

        public static T800_Extend_02 Parse(Byte[] data, int startIndex)
        {
            T_I2_R ret = new T800_Extend_02();

            return (T800_Extend_02)Parse(data, startIndex, ref ret);
        }
        public static T800_Extend_02 NewObject(int parentID, int rowID)
        {
            return new T800_Extend_02(parentID, rowID, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
