using System;
using System.Data;

using Kvics.DBAccess;

namespace Kvics.HotMill.BL
{
	/// <summary>
    /// Summary description for T_I2_6.
	/// </summary>
    public class T_I2_06_1 : T_I2_R
    {
        #region Static
        public static readonly string R1__COLUMN_NAME = "TC25";
        public static readonly string R2__COLUMN_NAME = "TC75";
        public static readonly string R3__COLUMN_NAME = "位置１";
        public static readonly string R4__COLUMN_NAME = "ｸﾗｳﾝ１";
        public static readonly string R5__COLUMN_NAME = "位置２";
        public static readonly string R6__COLUMN_NAME = "ｸﾗｳﾝ２";
        #endregion

        #region Property
        public Int16 R1
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

        public Int16 R2
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

        public Int16 R3
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

        public Int16 R4
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

        public Int16 R5
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

        public Int16 R6
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
        #endregion

        #region Constructors
        protected T_I2_06_1() : base()
        {
            this._Rows = new Int16[6];
        }

        protected T_I2_06_1(DBAccessor dbAccessor) : base(dbAccessor)
        {
            this._Rows = new Int16[6];
        }

        protected T_I2_06_1(int parentID, int rowID,
            Int16 r1, Int16 r2, Int16 r3, Int16 r4, Int16 r5, Int16 r6) 
            : base(parentID, rowID, new Int16[] {r1, r2, r3, r4, r5, r6})
        {
        }

        protected T_I2_06_1(DBAccessor dbAccessor, int parentID, int rowID,
            Int16 r1, Int16 r2, Int16 r3, Int16 r4, Int16 r5, Int16 r6)
            : base(parentID, rowID, new Int16[] { r1, r2, r3, r4, r5, r6 }, dbAccessor)
        {
            
        }

        protected T_I2_06_1(int parentID, int rowID, string TableName)
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

        protected T_I2_06_1(DBAccessor dbAccessor, int parentID, int rowID, string TableName)
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
            _Rows = new Int16[6];

            _ID = (int)row[ID__COLUMN_NAME];
            _ParentID = (int)row[PARENTID__COLUMN_NAME];
            _RowID = (int)row[ROWID__COLUMN_NAME];
            _Rows[0] = row[R1__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R1__COLUMN_NAME]);
            _Rows[1] = row[R2__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R2__COLUMN_NAME]);
            _Rows[2] = row[R3__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R3__COLUMN_NAME]);
            _Rows[3] = row[R4__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R4__COLUMN_NAME]);
            _Rows[4] = row[R5__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R5__COLUMN_NAME]);
            _Rows[5] = row[R6__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R6__COLUMN_NAME]);
        }

        #region Insert/Update/Delete
        protected int Insert(string TableName)
        {
            ParameterCollection coll = new ParameterCollection();
            coll.Add(new Parameter(PARENTID__COLUMN_NAME, _ParentID));
            coll.Add(new Parameter(ROWID__COLUMN_NAME, _RowID));
            coll.Add(new Parameter(R1__COLUMN_NAME, _Rows[0]));
            coll.Add(new Parameter(R2__COLUMN_NAME, _Rows[1]));
            coll.Add(new Parameter(R3__COLUMN_NAME, _Rows[2]));
            coll.Add(new Parameter(R4__COLUMN_NAME, _Rows[3]));
            coll.Add(new Parameter(R5__COLUMN_NAME, _Rows[4]));
            coll.Add(new Parameter(R6__COLUMN_NAME, _Rows[5]));

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
            coll.Add(new Parameter(R1__COLUMN_NAME, _Rows[0]));
            coll.Add(new Parameter(R2__COLUMN_NAME, _Rows[1]));
            coll.Add(new Parameter(R3__COLUMN_NAME, _Rows[2]));
            coll.Add(new Parameter(R4__COLUMN_NAME, _Rows[3]));
            coll.Add(new Parameter(R5__COLUMN_NAME, _Rows[4]));
            coll.Add(new Parameter(R6__COLUMN_NAME, _Rows[5]));

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
