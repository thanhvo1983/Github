using System;
using System.Data;

using Kvics.DBAccess;

namespace Kvics.HotMill.BL
{
	/// <summary>
    /// Summary description for T_I2_17.
	/// </summary>
    public class T_I2_19 : T_I2_R
    {
        #region Static
        public static readonly string R01__COLUMN_NAME = "Ｃ";
        public static readonly string R02__COLUMN_NAME = "Ｓｉ";
        public static readonly string R03__COLUMN_NAME = "Mn";
        public static readonly string R04__COLUMN_NAME = "P";
        public static readonly string R05__COLUMN_NAME = "S";
        public static readonly string R06__COLUMN_NAME = "Cu";
        public static readonly string R07__COLUMN_NAME = "Al";
        public static readonly string R08__COLUMN_NAME = "Ni";
        public static readonly string R09__COLUMN_NAME = "Cr";
        public static readonly string R10__COLUMN_NAME = "Mo";
        public static readonly string R11__COLUMN_NAME = "V";
        public static readonly string R12__COLUMN_NAME = "Nb";
        public static readonly string R13__COLUMN_NAME = "Ti";
        public static readonly string R14__COLUMN_NAME = "B";
        public static readonly string R15__COLUMN_NAME = "Sn";
        public static readonly string R16__COLUMN_NAME = "As";
        public static readonly string R17__COLUMN_NAME = "N";
        public static readonly string R18__COLUMN_NAME = "O";
        public static readonly string R19__COLUMN_NAME = "H";
        #endregion

        #region Property
        public Int16 R01
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

        public Int16 R02
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

        public Int16 R03
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

        public Int16 R04
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

        public Int16 R05
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

        public Int16 R06
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

        public Int16 R07
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

        public Int16 R08
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

        public Int16 R09
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

        public Int16 R10
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

        public Int16 R11
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

        public Int16 R12
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

        public Int16 R13
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

        public Int16 R14
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
        
        public Int16 R15
        {
            get
            {
                return _Rows[14];
            }
            set
            {
                _Rows[14] = value;
            }
        }

        public Int16 R16
        {
            get
            {
                return _Rows[15];
            }
            set
            {
                _Rows[15] = value;
            }
        }

        public Int16 R17
        {
            get
            {
                return _Rows[16];
            }
            set
            {
                _Rows[16] = value;
            }
        }

        public Int16 R18
        {
            get
            {
                return _Rows[17];
            }
            set
            {
                _Rows[17] = value;
            }
        }

        public Int16 R19
        {
            get
            {
                return _Rows[18];
            }
            set
            {
                _Rows[18] = value;
            }
        }
        #endregion

        #region Constructors
        protected T_I2_19() : base()
        {
            this._Rows = new Int16[19];
        }

        protected T_I2_19(DBAccessor dbAccessor) : base(dbAccessor)
        {
            this._Rows = new Int16[19];
        }

        protected T_I2_19(int parentID, int rowID,
            Int16 r1, Int16 r2, Int16 r3, Int16 r4, Int16 r5, 
            Int16 r6, Int16 r7, Int16 r8, Int16 r9, Int16 r10,
            Int16 r11, Int16 r12, Int16 r13, Int16 r14, Int16 r15,
            Int16 r16, Int16 r17, Int16 r18, Int16 r19)
            : base(parentID, rowID, 
            new Int16[] { r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14, r15, r16, r17, r18, r19 })
        {
        }

        protected T_I2_19(DBAccessor dbAccessor, int parentID, int rowID,
            Int16 r1, Int16 r2, Int16 r3, Int16 r4, Int16 r5, 
            Int16 r6, Int16 r7, Int16 r8, Int16 r9, Int16 r10,
            Int16 r11, Int16 r12, Int16 r13, Int16 r14, Int16 r15,
            Int16 r16, Int16 r17, Int16 r18, Int16 r19)
            : base(parentID, rowID, 
            new Int16[] { r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14, r15, r16, r17, r18, r19 }, dbAccessor)
        {
            
        }

        protected T_I2_19(int parentID, int rowID, string TableName)
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

        protected T_I2_19(DBAccessor dbAccessor, int parentID, int rowID, string TableName)
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
            _Rows = new Int16[19];

            _ID = (int)row[ID__COLUMN_NAME];
            _ParentID = (int)row[PARENTID__COLUMN_NAME];
            _RowID = (int)row[ROWID__COLUMN_NAME];
            _Rows[0] = row[R01__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R01__COLUMN_NAME]);
            _Rows[1] = row[R02__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R02__COLUMN_NAME]);
            _Rows[2] = row[R03__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R03__COLUMN_NAME]);
            _Rows[3] = row[R04__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R04__COLUMN_NAME]);
            _Rows[4] = row[R05__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R05__COLUMN_NAME]);
            _Rows[5] = row[R06__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R06__COLUMN_NAME]);
            _Rows[6] = row[R07__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R07__COLUMN_NAME]);
            _Rows[7] = row[R08__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R08__COLUMN_NAME]);
            _Rows[8] = row[R09__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R09__COLUMN_NAME]);
            _Rows[9] = row[R10__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R10__COLUMN_NAME]);
            _Rows[10] = row[R11__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R11__COLUMN_NAME]);
            _Rows[11] = row[R12__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R12__COLUMN_NAME]);
            _Rows[12] = row[R13__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R13__COLUMN_NAME]);
            _Rows[13] = row[R14__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R14__COLUMN_NAME]);
            _Rows[14] = row[R15__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R15__COLUMN_NAME]);
            _Rows[15] = row[R16__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R16__COLUMN_NAME]);
            _Rows[16] = row[R17__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R17__COLUMN_NAME]);
            _Rows[17] = row[R18__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R18__COLUMN_NAME]);
            _Rows[18] = row[R19__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R19__COLUMN_NAME]);
        }

        #region Insert/Update/Delete
        protected int Insert(string TableName)
        {
            ParameterCollection coll = new ParameterCollection();
            coll.Add(new Parameter(PARENTID__COLUMN_NAME, _ParentID));
            coll.Add(new Parameter(ROWID__COLUMN_NAME, _RowID));
            coll.Add(new Parameter(R01__COLUMN_NAME, _Rows[0]));
            coll.Add(new Parameter(R02__COLUMN_NAME, _Rows[1]));
            coll.Add(new Parameter(R03__COLUMN_NAME, _Rows[2]));
            coll.Add(new Parameter(R04__COLUMN_NAME, _Rows[3]));
            coll.Add(new Parameter(R05__COLUMN_NAME, _Rows[4]));
            coll.Add(new Parameter(R06__COLUMN_NAME, _Rows[5]));
            coll.Add(new Parameter(R07__COLUMN_NAME, _Rows[6]));
            coll.Add(new Parameter(R08__COLUMN_NAME, _Rows[7]));
            coll.Add(new Parameter(R09__COLUMN_NAME, _Rows[8]));
            coll.Add(new Parameter(R10__COLUMN_NAME, _Rows[9]));
            coll.Add(new Parameter(R11__COLUMN_NAME, _Rows[10]));
            coll.Add(new Parameter(R12__COLUMN_NAME, _Rows[11]));
            coll.Add(new Parameter(R13__COLUMN_NAME, _Rows[12]));
            coll.Add(new Parameter(R14__COLUMN_NAME, _Rows[13]));
            coll.Add(new Parameter(R15__COLUMN_NAME, _Rows[14]));
            coll.Add(new Parameter(R16__COLUMN_NAME, _Rows[15]));
            coll.Add(new Parameter(R17__COLUMN_NAME, _Rows[16]));
            coll.Add(new Parameter(R18__COLUMN_NAME, _Rows[17]));
            coll.Add(new Parameter(R19__COLUMN_NAME, _Rows[18]));

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
            coll.Add(new Parameter(R01__COLUMN_NAME, _Rows[0]));
            coll.Add(new Parameter(R02__COLUMN_NAME, _Rows[1]));
            coll.Add(new Parameter(R03__COLUMN_NAME, _Rows[2]));
            coll.Add(new Parameter(R04__COLUMN_NAME, _Rows[3]));
            coll.Add(new Parameter(R05__COLUMN_NAME, _Rows[4]));
            coll.Add(new Parameter(R06__COLUMN_NAME, _Rows[5]));
            coll.Add(new Parameter(R07__COLUMN_NAME, _Rows[6]));
            coll.Add(new Parameter(R08__COLUMN_NAME, _Rows[7]));
            coll.Add(new Parameter(R09__COLUMN_NAME, _Rows[8]));
            coll.Add(new Parameter(R10__COLUMN_NAME, _Rows[9]));
            coll.Add(new Parameter(R11__COLUMN_NAME, _Rows[10]));
            coll.Add(new Parameter(R12__COLUMN_NAME, _Rows[11]));
            coll.Add(new Parameter(R13__COLUMN_NAME, _Rows[12]));
            coll.Add(new Parameter(R14__COLUMN_NAME, _Rows[13]));
            coll.Add(new Parameter(R15__COLUMN_NAME, _Rows[14]));
            coll.Add(new Parameter(R16__COLUMN_NAME, _Rows[15]));
            coll.Add(new Parameter(R17__COLUMN_NAME, _Rows[16]));
            coll.Add(new Parameter(R18__COLUMN_NAME, _Rows[17]));
            coll.Add(new Parameter(R19__COLUMN_NAME, _Rows[18]));

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
