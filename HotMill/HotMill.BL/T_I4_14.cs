using System;
using System.Data;

using Kvics.DBAccess;

namespace Kvics.HotMill.BL
{
	/// <summary>
    /// Summary description for T_I4_14.
	/// </summary>
    public class T_I4_14 : T_I4_R
    {
        #region Static
        public static readonly string F1_1__COLUMN_NAME = "F1_上";
        public static readonly string F1_2__COLUMN_NAME = "F1_下";
        public static readonly string F2_1__COLUMN_NAME = "F2_上";
        public static readonly string F2_2__COLUMN_NAME = "F2_下";
        public static readonly string F3_1__COLUMN_NAME = "F3_上";
        public static readonly string F3_2__COLUMN_NAME = "F3_下";
        public static readonly string F4_1__COLUMN_NAME = "F4_上";
        public static readonly string F4_2__COLUMN_NAME = "F4_下";
        public static readonly string F5_1__COLUMN_NAME = "F5_上";
        public static readonly string F5_2__COLUMN_NAME = "F5_下";
        public static readonly string F6_1__COLUMN_NAME = "F6_上";
        public static readonly string F6_2__COLUMN_NAME = "F6_下";
        public static readonly string F7_1__COLUMN_NAME = "F7_上";
        public static readonly string F7_2__COLUMN_NAME = "F7_下";
        #endregion

        #region Property
        public Int32 F1_1
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

        public Int32 F1_2
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

        public Int32 F2_1
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

        public Int32 F2_2
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

        public Int32 F3_1
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

        public Int32 F3_2
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

        public Int32 F4_1
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

        public Int32 F4_2
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

        public Int32 F5_1
        {
            get
            {
                return _Rows[8];
            }
            set
            {
                _Rows[8] = value;
            }
        }

        public Int32 F5_2
        {
            get
            {
                return _Rows[9];
            }
            set
            {
                _Rows[9] = value;
            }
        }

        public Int32 F6_1
        {
            get
            {
                return _Rows[10];
            }
            set
            {
                _Rows[10] = value;
            }
        }

        public Int32 F6_2
        {
            get
            {
                return _Rows[11];
            }
            set
            {
                _Rows[11] = value;
            }
        }

        public Int32 F7_1
        {
            get
            {
                return _Rows[12];
            }
            set
            {
                _Rows[12] = value;
            }
        }

        public Int32 F7_2
        {
            get
            {
                return _Rows[13];
            }
            set
            {
                _Rows[13] = value;
            }
        }
        #endregion

        #region Constructors
        protected T_I4_14() : base()
        {
            this._Rows = new Int32[14];
        }

        protected T_I4_14(DBAccessor dbAccessor) : base(dbAccessor)
        {
            this._Rows = new Int32[14];
        }

        protected T_I4_14(int parentID, int rowID,
            Int32 r1, Int32 r2, Int32 r3, Int32 r4, Int32 r5,
            Int32 r6, Int32 r7, Int32 r8, Int32 r9, Int32 r10,
            Int32 r11, Int32 r12, Int32 r13, Int32 r14)
            : base(parentID, rowID, new Int32[] { r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14 })
        {
        }

        protected T_I4_14(DBAccessor dbAccessor, int parentID, int rowID,
            Int32 r1, Int32 r2, Int32 r3, Int32 r4, Int32 r5,
            Int32 r6, Int32 r7, Int32 r8, Int32 r9, Int32 r10,
            Int32 r11, Int32 r12, Int32 r13, Int32 r14)
            : base(parentID, rowID, new Int32[] { r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14 }, dbAccessor)
        {
            
        }

        protected T_I4_14(int parentID, int rowID, string TableName)
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
                DataSet ds = _DBAccessor.GetTable(TableName, whereColl);

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

        protected T_I4_14(DBAccessor dbAccessor, int parentID, int rowID, string TableName)
            : base(dbAccessor)
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
                DataSet ds = _DBAccessor.GetTable(TableName, whereColl);

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
        #endregion

        protected void FromDataRow(DataRow row)
        {
            _Rows = new Int32[14];

            _ID = (int)row[ID__COLUMN_NAME];
            _ParentID = (int)row[PARENTID__COLUMN_NAME];
            _RowID = (int)row[ROWID__COLUMN_NAME];
            _Rows[0] = row[F1_1__COLUMN_NAME] == DBNull.Value ? (Int32)0 : (Int32)(row[F1_1__COLUMN_NAME]);
            _Rows[1] = row[F1_2__COLUMN_NAME] == DBNull.Value ? (Int32)0 : (Int32)(row[F1_2__COLUMN_NAME]);
            _Rows[2] = row[F2_1__COLUMN_NAME] == DBNull.Value ? (Int32)0 : (Int32)(row[F2_1__COLUMN_NAME]);
            _Rows[3] = row[F2_2__COLUMN_NAME] == DBNull.Value ? (Int32)0 : (Int32)(row[F2_2__COLUMN_NAME]);
            _Rows[4] = row[F3_1__COLUMN_NAME] == DBNull.Value ? (Int32)0 : (Int32)(row[F3_1__COLUMN_NAME]);
            _Rows[5] = row[F3_2__COLUMN_NAME] == DBNull.Value ? (Int32)0 : (Int32)(row[F3_2__COLUMN_NAME]);
            _Rows[6] = row[F4_1__COLUMN_NAME] == DBNull.Value ? (Int32)0 : (Int32)(row[F4_1__COLUMN_NAME]);
            _Rows[7] = row[F4_2__COLUMN_NAME] == DBNull.Value ? (Int32)0 : (Int32)(row[F4_2__COLUMN_NAME]);
            _Rows[8] = row[F5_1__COLUMN_NAME] == DBNull.Value ? (Int32)0 : (Int32)(row[F5_1__COLUMN_NAME]);
            _Rows[9] = row[F5_2__COLUMN_NAME] == DBNull.Value ? (Int32)0 : (Int32)(row[F5_2__COLUMN_NAME]);
            _Rows[10] = row[F6_1__COLUMN_NAME] == DBNull.Value ? (Int32)0 : (Int32)(row[F6_1__COLUMN_NAME]);
            _Rows[11] = row[F6_2__COLUMN_NAME] == DBNull.Value ? (Int32)0 : (Int32)(row[F6_2__COLUMN_NAME]);
            _Rows[12] = row[F7_1__COLUMN_NAME] == DBNull.Value ? (Int32)0 : (Int32)(row[F7_1__COLUMN_NAME]);
            _Rows[13] = row[F7_2__COLUMN_NAME] == DBNull.Value ? (Int32)0 : (Int32)(row[F7_2__COLUMN_NAME]);
        }

        #region Insert/Update/Delete
        protected int Insert(string TableName)
        {
            ParameterCollection coll = new ParameterCollection();
            coll.Add(new Parameter(PARENTID__COLUMN_NAME, _ParentID));
            coll.Add(new Parameter(ROWID__COLUMN_NAME, _RowID));
            coll.Add(new Parameter(F1_1__COLUMN_NAME, _Rows[0]));
            coll.Add(new Parameter(F1_2__COLUMN_NAME, _Rows[1]));
            coll.Add(new Parameter(F2_1__COLUMN_NAME, _Rows[2]));
            coll.Add(new Parameter(F2_2__COLUMN_NAME, _Rows[3]));
            coll.Add(new Parameter(F3_1__COLUMN_NAME, _Rows[4]));
            coll.Add(new Parameter(F3_2__COLUMN_NAME, _Rows[5]));
            coll.Add(new Parameter(F4_1__COLUMN_NAME, _Rows[6]));
            coll.Add(new Parameter(F4_2__COLUMN_NAME, _Rows[7]));
            coll.Add(new Parameter(F5_1__COLUMN_NAME, _Rows[8]));
            coll.Add(new Parameter(F5_2__COLUMN_NAME, _Rows[9]));
            coll.Add(new Parameter(F6_1__COLUMN_NAME, _Rows[10]));
            coll.Add(new Parameter(F6_2__COLUMN_NAME, _Rows[11]));
            coll.Add(new Parameter(F7_1__COLUMN_NAME, _Rows[12]));
            coll.Add(new Parameter(F7_2__COLUMN_NAME, _Rows[13]));

            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                return _DBAccessor.Insert(TableName, coll);
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

        protected int Update(string TableName)
        {
            ParameterCollection coll = new ParameterCollection();
            coll.Add(new Parameter(F1_1__COLUMN_NAME, _Rows[0]));
            coll.Add(new Parameter(F1_2__COLUMN_NAME, _Rows[1]));
            coll.Add(new Parameter(F2_1__COLUMN_NAME, _Rows[2]));
            coll.Add(new Parameter(F2_2__COLUMN_NAME, _Rows[3]));
            coll.Add(new Parameter(F3_1__COLUMN_NAME, _Rows[4]));
            coll.Add(new Parameter(F3_2__COLUMN_NAME, _Rows[5]));
            coll.Add(new Parameter(F4_1__COLUMN_NAME, _Rows[6]));
            coll.Add(new Parameter(F4_2__COLUMN_NAME, _Rows[7]));
            coll.Add(new Parameter(F5_1__COLUMN_NAME, _Rows[8]));
            coll.Add(new Parameter(F5_2__COLUMN_NAME, _Rows[9]));
            coll.Add(new Parameter(F6_1__COLUMN_NAME, _Rows[10]));
            coll.Add(new Parameter(F6_2__COLUMN_NAME, _Rows[11]));
            coll.Add(new Parameter(F7_1__COLUMN_NAME, _Rows[12]));
            coll.Add(new Parameter(F7_2__COLUMN_NAME, _Rows[13]));

            WhereParameterCollection whereColl = new WhereParameterCollection();
            whereColl.Add(new WhereParameter(PARENTID__COLUMN_NAME, _ParentID, CompareType.Equal));
            whereColl.Add(ROWID__COLUMN_NAME, _RowID, CompareType.Equal);

            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                return _DBAccessor.Update(TableName, coll, whereColl);
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

        protected int Delete(string TableName)
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
                return _DBAccessor.Delete(TableName, whereColl);
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
    }
}
