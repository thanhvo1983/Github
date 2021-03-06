using System;
using System.Data;

using Kvics.DBAccess;

namespace Kvics.HotMill.BL
{
	/// <summary>
    /// Summary description for T_C2_07.
	/// </summary>
    public class T_C2_07 : T_C2_R
    {
        #region Static
        public static readonly string F1__COLUMN_NAME = "F1WR材質_上";
        public static readonly string F2__COLUMN_NAME = "F2WR材質_上";
        public static readonly string F3__COLUMN_NAME = "F3WR材質_上";
        public static readonly string F4__COLUMN_NAME = "F4WR材質_上";
        public static readonly string F5__COLUMN_NAME = "F5WR材質_上";
        public static readonly string F6__COLUMN_NAME = "F6WR材質_上";
        public static readonly string F7__COLUMN_NAME = "F7WR材質_上";
        #endregion

        #region Property
        public String F1
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

        public String F2
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

        public String F3
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

        public String F4
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

        public String F5
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

        public String F6
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

        public String F7
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
        #endregion

        #region Constructors
        protected T_C2_07() : base()
        {
            this._Rows = new String[7];
        }

        protected T_C2_07(DBAccessor dbAccessor) : base(dbAccessor)
        {
            this._Rows = new String[7];
        }

        protected T_C2_07(int parentID, int rowID,
            String r1, String r2, String r3, String r4, String r5, String r6, String r7)
            : base(parentID, rowID, new String[] { r1, r2, r3, r4, r5, r6, r7 })
        {
        }

        protected T_C2_07(DBAccessor dbAccessor, int parentID, int rowID,
            String r1, String r2, String r3, String r4, String r5, String r6, String r7)
            : base(parentID, rowID, new String[] { r1, r2, r3, r4, r5, r6, r7 }, dbAccessor)
        {
            
        }

        protected T_C2_07(int parentID, int rowID, string TableName)
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

        protected T_C2_07(DBAccessor dbAccessor, int parentID, int rowID, string TableName)
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
            _Rows = new String[7];

            _ID = (int)row[ID__COLUMN_NAME];
            _ParentID = (int)row[PARENTID__COLUMN_NAME];
            _RowID = (int)row[ROWID__COLUMN_NAME];
            _Rows[0] = row[F1__COLUMN_NAME] == DBNull.Value ? (String)"" : (String)(row[F1__COLUMN_NAME]);
            _Rows[1] = row[F2__COLUMN_NAME] == DBNull.Value ? (String)"" : (String)(row[F2__COLUMN_NAME]);
            _Rows[2] = row[F3__COLUMN_NAME] == DBNull.Value ? (String)"" : (String)(row[F3__COLUMN_NAME]);
            _Rows[3] = row[F4__COLUMN_NAME] == DBNull.Value ? (String)"" : (String)(row[F4__COLUMN_NAME]);
            _Rows[4] = row[F5__COLUMN_NAME] == DBNull.Value ? (String)"" : (String)(row[F5__COLUMN_NAME]);
            _Rows[5] = row[F6__COLUMN_NAME] == DBNull.Value ? (String)"" : (String)(row[F6__COLUMN_NAME]);
            _Rows[6] = row[F7__COLUMN_NAME] == DBNull.Value ? (String)"" : (String)(row[F7__COLUMN_NAME]);
        }

        #region Insert/Update/Delete
        protected int Insert(string TableName)
        {
            ValidateData();

            ParameterCollection coll = new ParameterCollection();
            coll.Add(new Parameter(PARENTID__COLUMN_NAME, _ParentID));
            coll.Add(new Parameter(ROWID__COLUMN_NAME, _RowID));
            coll.Add(new Parameter(F1__COLUMN_NAME, _Rows[0]));
            coll.Add(new Parameter(F2__COLUMN_NAME, _Rows[1]));
            coll.Add(new Parameter(F3__COLUMN_NAME, _Rows[2]));
            coll.Add(new Parameter(F4__COLUMN_NAME, _Rows[3]));
            coll.Add(new Parameter(F5__COLUMN_NAME, _Rows[4]));
            coll.Add(new Parameter(F6__COLUMN_NAME, _Rows[5]));
            coll.Add(new Parameter(F7__COLUMN_NAME, _Rows[6]));

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
            ValidateData();

            ParameterCollection coll = new ParameterCollection();
            coll.Add(new Parameter(F1__COLUMN_NAME, _Rows[0]));
            coll.Add(new Parameter(F2__COLUMN_NAME, _Rows[1]));
            coll.Add(new Parameter(F3__COLUMN_NAME, _Rows[2]));
            coll.Add(new Parameter(F4__COLUMN_NAME, _Rows[3]));
            coll.Add(new Parameter(F5__COLUMN_NAME, _Rows[4]));
            coll.Add(new Parameter(F6__COLUMN_NAME, _Rows[5]));
            coll.Add(new Parameter(F7__COLUMN_NAME, _Rows[6]));

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

        protected void ValidateData()
        {
            for (int i = 0; i < _Rows.Length; i++)
            {
                if (_Rows[i] != null)
                {
                    if (_Rows[i].Length > 2)
                    {
                        _Rows[i] = _Rows[i].Substring(0, 2);
                    }
                    else if (_Rows[i].Length < 2)
                    {
                        while (_Rows[i].Length < 2)
                        {
                            _Rows[i] += " ";
                        }
                    }
                }
            }
        }
    }
}
