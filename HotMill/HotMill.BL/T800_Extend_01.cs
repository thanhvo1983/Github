using System;
using System.Data;

using Kvics.DBAccess;

namespace Kvics.HotMill.BL
{
	/// <summary>
    /// Summary description for T800_Extend_01.
	/// </summary>
    public class T800_Extend_01 : T_R
    {
        #region Static
        public static readonly string TABLE_NAME = "T800_Extend_01";
        public static readonly string R857__COLUMN_NAME = "R857_後段ｼﾌﾄﾓｰﾄﾞ";
        public static readonly string R859__COLUMN_NAME = "R859_定期組替1本目ﾌﾗｸﾞ";
        public static readonly string R861__COLUMN_NAME = "R861_基準ｽﾀﾝﾄﾞ番号";
        public static readonly string R863__COLUMN_NAME = "R863_ｼﾝﾌﾟﾙﾓｰﾄﾞ_ｼﾌﾄﾊﾟﾀｰﾝNO";
        public static readonly string R865__COLUMN_NAME = "R865_ｼﾝﾌﾟﾙﾓｰﾄﾞ_同一位置圧延本数";
        public static readonly string R867__COLUMN_NAME = "R867_ｼﾝﾌﾟﾙﾓｰﾄﾞ_ｼﾝﾌﾟﾙｼﾌﾄ中心位置";
        public static readonly string R869__COLUMN_NAME = "R869_ASCﾓｰﾄﾞ_HCδ制約材ﾌﾗｸﾞ";
        public static readonly string R871__COLUMN_NAME = "R871_ASCﾓｰﾄﾞ_ﾃｰﾊﾟ不可材ﾌﾗｸﾞ";
        public static readonly string R933__COLUMN_NAME = "R933_ASCﾓｰﾄﾞ_ｵﾍﾟﾚｰﾀ介入ﾌﾗｸﾞ";
        public static readonly string R935__COLUMN_NAME = "R935_ASCﾓｰﾄﾞ_HCδ制約_最大値";
        public static readonly string R937__COLUMN_NAME = "R937_ASCﾓｰﾄﾞ_HCδ制約_最小値";
        public static readonly string R939__COLUMN_NAME = "R939_ASCﾓｰﾄﾞ_HCδ制約_ｼﾌﾄﾋﾟｯﾁ";
        public static readonly string R941__COLUMN_NAME = "R941_ASCﾓｰﾄﾞ_HCδ制約_本数";
        public static readonly string R943__COLUMN_NAME = "R943_ASCﾓｰﾄﾞ_定ﾋﾟｯﾁｼﾌﾄﾌﾗｸﾞ";
        public static readonly string R945__COLUMN_NAME = "R945_ASCﾓｰﾄﾞ_定ﾋﾟｯﾁｼﾌﾄ本数";

        public static readonly int EXTEND_PAKAGE_LENGTH = 134;
        #endregion

        #region Protected
        protected Int16[] _Rows = new Int16[15];
        protected T_R_RowSet[] _RowsChild = new T_R_RowSet[T800_Extend_01_Mapping.RowsName.Length];
        #endregion

        #region Property
        public Int16[] Rows
        {
            get
            {
                return _Rows;
            }
        }

        public Int16 R857
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

        public Int16 R859
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

        public Int16 R861
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

        public Int16 R863
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

        public Int16 R865
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

        public Int16 R867
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

        public Int16 R869
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

        public Int16 R871
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

        public Int16 R933
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

        public Int16 R935
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

        public Int16 R937
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

        public Int16 R939
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

        public Int16 R941
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

        public Int16 R943
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

        public Int16 R945
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
        
        public T800_Extend_01_C2_10 R873
        {
            get
            {
                if (!_RowsChild[0].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[0].Row = null;
                    }
                    else
                    {
                        R873 = new T800_Extend_01_C2_10(_ID, T800_Extend_01_Mapping.GetRowID(T800_Extend_01_Mapping.R873));
                    }
                }
                return (T800_Extend_01_C2_10)_RowsChild[0].Row;
            }
            set
            {
                _RowsChild[0].Row = value;
                if (value != null)
                {
                    _RowsChild[0].Row.ParentID = _ID;
                    _RowsChild[0].Row.RowID = T800_Extend_01_Mapping.GetRowID(T800_Extend_01_Mapping.R873);
                }
                _RowsChild[0].R_Set = true;
            }
        }

        public T800_Extend_01_I2_10 R893
        {
            get
            {
                if (!_RowsChild[1].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[1].Row = null;
                    }
                    else
                    {
                        R893 = new T800_Extend_01_I2_10(_ID, T800_Extend_01_Mapping.GetRowID(T800_Extend_01_Mapping.R893));
                    }
                }
                return (T800_Extend_01_I2_10)_RowsChild[1].Row;
            }
            set
            {
                _RowsChild[1].Row = value;
                if (value != null)
                {
                    _RowsChild[1].Row.ParentID = _ID;
                    _RowsChild[1].Row.RowID = T800_Extend_01_Mapping.GetRowID(T800_Extend_01_Mapping.R893);
                }
                _RowsChild[1].R_Set = true;
            }
        }

        public T800_Extend_01_I2_10 R913
        {
            get
            {
                if (!_RowsChild[2].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[2].Row = null;
                    }
                    else
                    {
                        R913 = new T800_Extend_01_I2_10(_ID, T800_Extend_01_Mapping.GetRowID(T800_Extend_01_Mapping.R913));
                    }
                }
                return (T800_Extend_01_I2_10)_RowsChild[2].Row;
            }
            set
            {
                _RowsChild[2].Row = value;
                if (value != null)
                {
                    _RowsChild[2].Row.ParentID = _ID;
                    _RowsChild[2].Row.RowID = T800_Extend_01_Mapping.GetRowID(T800_Extend_01_Mapping.R913);
                }
                _RowsChild[2].R_Set = true;
            }
        }

        public T800_Extend_01_I2_10 R947
        {
            get
            {
                if (!_RowsChild[3].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[3].Row = null;
                    }
                    else
                    {
                        R947 = new T800_Extend_01_I2_10(_ID, T800_Extend_01_Mapping.GetRowID(T800_Extend_01_Mapping.R947));
                    }
                }
                return (T800_Extend_01_I2_10)_RowsChild[3].Row;
            }
            set
            {
                _RowsChild[3].Row = value;
                if (value != null)
                {
                    _RowsChild[3].Row.ParentID = _ID;
                    _RowsChild[3].Row.RowID = T800_Extend_01_Mapping.GetRowID(T800_Extend_01_Mapping.R947);
                }
                _RowsChild[3].R_Set = true;
            }
        }

        public T800_Extend_01_I2_04 R967
        {
            get
            {
                if (!_RowsChild[4].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[4].Row = null;
                    }
                    else
                    {
                        R967 = new T800_Extend_01_I2_04(_ID, T800_Extend_01_Mapping.GetRowID(T800_Extend_01_Mapping.R967));
                    }
                }
                return (T800_Extend_01_I2_04)_RowsChild[4].Row;
            }
            set
            {
                _RowsChild[4].Row = value;
                if (value != null)
                {
                    _RowsChild[4].Row.ParentID = _ID;
                    _RowsChild[4].Row.RowID = T800_Extend_01_Mapping.GetRowID(T800_Extend_01_Mapping.R967);
                }
                _RowsChild[4].R_Set = true;
            }
        }

        public T800_Extend_01_I2_04 R975
        {
            get
            {
                if (!_RowsChild[5].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[5].Row = null;
                    }
                    else
                    {
                        R975 = new T800_Extend_01_I2_04(_ID, T800_Extend_01_Mapping.GetRowID(T800_Extend_01_Mapping.R975));
                    }
                }
                return (T800_Extend_01_I2_04)_RowsChild[5].Row;
            }
            set
            {
                _RowsChild[5].Row = value;
                if (value != null)
                {
                    _RowsChild[5].Row.ParentID = _ID;
                    _RowsChild[5].Row.RowID = T800_Extend_01_Mapping.GetRowID(T800_Extend_01_Mapping.R975);
                }
                _RowsChild[5].R_Set = true;
            }
        }

        public T800_Extend_01_I2_04 R983
        {
            get
            {
                if (!_RowsChild[6].R_Set)
                {
                    if (_ID < 1)
                    {
                        _RowsChild[6].Row = null;
                    }
                    else
                    {
                        R983 = new T800_Extend_01_I2_04(_ID, T800_Extend_01_Mapping.GetRowID(T800_Extend_01_Mapping.R983));
                    }
                }
                return (T800_Extend_01_I2_04)_RowsChild[6].Row;
            }
            set
            {
                _RowsChild[6].Row = value;
                if (value != null)
                {
                    _RowsChild[6].Row.ParentID = _ID;
                    _RowsChild[6].Row.RowID = T800_Extend_01_Mapping.GetRowID(T800_Extend_01_Mapping.R983);
                }
                _RowsChild[6].R_Set = true;
            }
        }        
        #endregion

        protected void NewRowsChild()
        {
            for (int i = 0; i < _RowsChild.Length; i++)
            {
                _RowsChild[i] = new T_R_RowSet();
            }
        }

        #region Constructors
        public T800_Extend_01()
            : base()
        {
            NewRowsChild();
        }

        public T800_Extend_01(DBAccessor dbAccessor)
            : base(dbAccessor)
        {
            NewRowsChild();
        }

        public T800_Extend_01(int parentID, int rowID)
            : base()
        {
            NewRowsChild();

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

        public T800_Extend_01(DBAccessor dbAccessor, int parentID, int rowID)
            : base(dbAccessor)
        {
            NewRowsChild();

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

        private void FromDataRow(DataRow row)
        {
            //_Rows = new Int16[15];

            _ID = (int)row[ID__COLUMN_NAME];
            _ParentID = (int)row[PARENTID__COLUMN_NAME];
            _RowID = (int)row[ROWID__COLUMN_NAME];

            _Rows[0] = row[R857__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R857__COLUMN_NAME]);
            _Rows[1] = row[R859__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R859__COLUMN_NAME]);
            _Rows[2] = row[R861__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R861__COLUMN_NAME]);
            _Rows[3] = row[R863__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R863__COLUMN_NAME]);
            _Rows[4] = row[R865__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R865__COLUMN_NAME]);
            _Rows[5] = row[R867__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R867__COLUMN_NAME]);
            _Rows[6] = row[R869__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R869__COLUMN_NAME]);
            _Rows[7] = row[R871__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R871__COLUMN_NAME]);
            _Rows[8] = row[R933__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R933__COLUMN_NAME]);
            _Rows[9] = row[R935__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R935__COLUMN_NAME]);
            _Rows[10] = row[R937__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R937__COLUMN_NAME]);
            _Rows[11] = row[R939__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R939__COLUMN_NAME]);
            _Rows[12] = row[R941__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R941__COLUMN_NAME]);
            _Rows[13] = row[R943__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R943__COLUMN_NAME]);
            _Rows[14] = row[R945__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R945__COLUMN_NAME]);
        }
        #endregion

        #region Insert/Update/Delete
        public override int Insert()
        {
            ParameterCollection coll = new ParameterCollection();
            coll.Add(new Parameter(PARENTID__COLUMN_NAME, _ParentID));
            coll.Add(new Parameter(ROWID__COLUMN_NAME, _RowID));

            coll.Add(new Parameter(R857__COLUMN_NAME, _Rows[0]));
            coll.Add(new Parameter(R859__COLUMN_NAME, _Rows[1]));
            coll.Add(new Parameter(R861__COLUMN_NAME, _Rows[2]));
            coll.Add(new Parameter(R863__COLUMN_NAME, _Rows[3]));
            coll.Add(new Parameter(R865__COLUMN_NAME, _Rows[4]));
            coll.Add(new Parameter(R867__COLUMN_NAME, _Rows[5]));
            coll.Add(new Parameter(R869__COLUMN_NAME, _Rows[6]));
            coll.Add(new Parameter(R871__COLUMN_NAME, _Rows[7]));
            coll.Add(new Parameter(R933__COLUMN_NAME, _Rows[8]));
            coll.Add(new Parameter(R935__COLUMN_NAME, _Rows[9]));

            coll.Add(new Parameter(R937__COLUMN_NAME, _Rows[10]));
            coll.Add(new Parameter(R939__COLUMN_NAME, _Rows[11]));
            coll.Add(new Parameter(R941__COLUMN_NAME, _Rows[12]));
            coll.Add(new Parameter(R943__COLUMN_NAME, _Rows[13]));
            coll.Add(new Parameter(R945__COLUMN_NAME, _Rows[14]));

            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                
                Object obj = _DBAccessor.InsertWithIdentity(TABLE_NAME, coll);

                _ID = Convert.ToInt32(obj);

                if (_RowsChild[0].Row == null)
                {
                    R873 = new T800_Extend_01_C2_10(0, T800_Extend_01_Mapping.GetRowID(T800_Extend_01_Mapping.R873), "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ");
                }
                _RowsChild[0].Row.ParentID = this.ID;
                _RowsChild[0].Row.DBAccessor = _DBAccessor;
                _RowsChild[0].Row.Insert();

                if (_RowsChild[1].Row == null)
                {
                    R893 = T800_Extend_01_I2_10.NewObject(_ID, T800_Extend_01_Mapping.GetRowID(T800_Extend_01_Mapping.R893));
                }
                _RowsChild[1].Row.ParentID = this.ID;
                _RowsChild[1].Row.DBAccessor = _DBAccessor;
                _RowsChild[1].Row.Insert();

                if (_RowsChild[2].Row == null)
                {
                    R913 = T800_Extend_01_I2_10.NewObject(_ID, T800_Extend_01_Mapping.GetRowID(T800_Extend_01_Mapping.R913));
                }
                _RowsChild[2].Row.ParentID = this.ID;
                _RowsChild[2].Row.DBAccessor = _DBAccessor;
                _RowsChild[2].Row.Insert();

                if (_RowsChild[3].Row == null)
                {
                    R947 = T800_Extend_01_I2_10.NewObject(_ID, T800_Extend_01_Mapping.GetRowID(T800_Extend_01_Mapping.R947));
                }
                _RowsChild[3].Row.ParentID = this.ID;
                _RowsChild[3].Row.DBAccessor = _DBAccessor;
                _RowsChild[3].Row.Insert();

                if (_RowsChild[4].Row == null)
                {
                    R967 = T800_Extend_01_I2_04.NewObject(_ID, T800_Extend_01_Mapping.GetRowID(T800_Extend_01_Mapping.R967));
                }
                _RowsChild[4].Row.ParentID = this.ID;
                _RowsChild[4].Row.DBAccessor = _DBAccessor;
                _RowsChild[4].Row.Insert();

                if (_RowsChild[5].Row == null)
                {
                    R975 = T800_Extend_01_I2_04.NewObject(_ID, T800_Extend_01_Mapping.GetRowID(T800_Extend_01_Mapping.R975));
                }
                _RowsChild[5].Row.ParentID = this.ID;
                _RowsChild[5].Row.DBAccessor = _DBAccessor;
                _RowsChild[5].Row.Insert();

                if (_RowsChild[6].Row == null)
                {
                    R983 = T800_Extend_01_I2_04.NewObject(_ID, T800_Extend_01_Mapping.GetRowID(T800_Extend_01_Mapping.R983));
                }
                _RowsChild[6].Row.ParentID = this.ID;
                _RowsChild[6].Row.DBAccessor = _DBAccessor;
                _RowsChild[6].Row.Insert();
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

            return _ID;
        }
        #endregion

        public Byte[] GetBytes()
        {
            Byte[] data = null;

            data = new Byte[EXTEND_PAKAGE_LENGTH];

            Buffer.BlockCopy(Common.GetBytes(_Rows[0]), 0, data, 0, 2);
            Buffer.BlockCopy(Common.GetBytes(_Rows[1]), 0, data, 2, 2);
            Buffer.BlockCopy(Common.GetBytes(_Rows[2]), 0, data, 4, 2);
            Buffer.BlockCopy(Common.GetBytes(_Rows[3]), 0, data, 6, 2);
            Buffer.BlockCopy(Common.GetBytes(_Rows[4]), 0, data, 8, 2);
            Buffer.BlockCopy(Common.GetBytes(_Rows[5]), 0, data, 10, 2);
            Buffer.BlockCopy(Common.GetBytes(_Rows[6]), 0, data, 12, 2);
            Buffer.BlockCopy(Common.GetBytes(_Rows[7]), 0, data, 14, 2);

            if (this.R873 != null)
            {
                Buffer.BlockCopy(this.R873.GetBytes(), 0, data, 16, 20);
            }
            if (this.R893 != null)
            {
                Buffer.BlockCopy(this.R893.GetBytes(), 0, data, 36, 20);
            }
            if (this.R913 != null)
            {
                Buffer.BlockCopy(this.R913.GetBytes(), 0, data, 56, 20);
            }

            Buffer.BlockCopy(Common.GetBytes(_Rows[8]), 0, data, 76, 2);
            Buffer.BlockCopy(Common.GetBytes(_Rows[9]), 0, data, 78, 2);
            Buffer.BlockCopy(Common.GetBytes(_Rows[10]), 0, data, 80, 2);
            Buffer.BlockCopy(Common.GetBytes(_Rows[11]), 0, data, 82, 2);
            Buffer.BlockCopy(Common.GetBytes(_Rows[12]), 0, data, 84, 2);
            Buffer.BlockCopy(Common.GetBytes(_Rows[13]), 0, data, 86, 2);
            Buffer.BlockCopy(Common.GetBytes(_Rows[14]), 0, data, 88, 2);

            if (this.R947 != null)
            {
                Buffer.BlockCopy(this.R947.GetBytes(), 0, data, 90, 20);
            }
            if (this.R967 != null)
            {
                Buffer.BlockCopy(this.R967.GetBytes(), 0, data, 110, 8);
            }
            if (this.R975 != null)
            {
                Buffer.BlockCopy(this.R975.GetBytes(), 0, data, 118, 8);
            }
            if (this.R983 != null)
            {
                Buffer.BlockCopy(this.R983.GetBytes(), 0, data, 126, 8);
            }

            return data;
        }

        public static T800_Extend_01 Parse(Byte[] data, int startIndex)
        {
            T800_Extend_01 ins = new T800_Extend_01();

            ins.ParentID = 0;

            ins.R857 = Common.ToInt16(data, startIndex);
            ins.R859 = Common.ToInt16(data, startIndex + 2);
            ins.R861 = Common.ToInt16(data, startIndex + 4);
            ins.R863 = Common.ToInt16(data, startIndex + 6);
            ins.R865 = Common.ToInt16(data, startIndex + 8);
            ins.R867 = Common.ToInt16(data, startIndex + 10);
            ins.R869 = Common.ToInt16(data, startIndex + 12);
            ins.R871 = Common.ToInt16(data, startIndex + 14);

            ins.R873 = T800_Extend_01_C2_10.Parse(data, startIndex + 16);
            ins.R893 = T800_Extend_01_I2_10.Parse(data, startIndex + 36);
            ins.R913 = T800_Extend_01_I2_10.Parse(data, startIndex + 56);
            
            ins.R933 = Common.ToInt16(data, startIndex + 76);
            ins.R935 = Common.ToInt16(data, startIndex + 78);
            ins.R937 = Common.ToInt16(data, startIndex + 80);
            ins.R939 = Common.ToInt16(data, startIndex + 82);
            ins.R941 = Common.ToInt16(data, startIndex + 84);
            ins.R943 = Common.ToInt16(data, startIndex + 86);
            ins.R945 = Common.ToInt16(data, startIndex + 88);

            ins.R947 = T800_Extend_01_I2_10.Parse(data, startIndex + 90);
            ins.R967 = T800_Extend_01_I2_04.Parse(data, startIndex + 110);
            ins.R975 = T800_Extend_01_I2_04.Parse(data, startIndex + 118);
            ins.R983 = T800_Extend_01_I2_04.Parse(data, startIndex + 126);
            
            return ins;
        }

        public static T800_Extend_01 NewObject(int parentID, int rowID)
        {
            T800_Extend_01 obj = new T800_Extend_01();
            obj.ParentID = parentID;
            obj.RowID = rowID;
            for (int i = 0; i < obj.Rows.Length; i++)
            {
                obj.Rows[i] = 0;
            }

            return obj;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is T800_Extend_01))
                return base.Equals(obj);
            T800_Extend_01 tc2 = (T800_Extend_01)obj;
            if (tc2 == null || tc2.Rows.Length != this._Rows.Length)
            {
                return false;
            }

            for (int i = 0; i < _Rows.Length; i++)
            {
                if (tc2.Rows[i] != _Rows[i])
                {
                    return false;
                }
            }

            if ((this.R873 == null && tc2.R873 != null) || (this.R873 != null && tc2.R873 == null) || (this.R873 != null && !this.R873.Equals(tc2.R873))) return false;
            if ((this.R893 == null && tc2.R893 != null) || (this.R893 != null && tc2.R893 == null) || (this.R893 != null && !this.R893.Equals(tc2.R893))) return false;
            if ((this.R893 == null && tc2.R893 != null) || (this.R893 != null && tc2.R893 == null) || (this.R893 != null && !this.R893.Equals(tc2.R893))) return false;

            if ((this.R947 == null && tc2.R947 != null) || (this.R947 != null && tc2.R947 == null) || (this.R947 != null && !this.R947.Equals(tc2.R947))) return false;
            if ((this.R967 == null && tc2.R967 != null) || (this.R967 != null && tc2.R967 == null) || (this.R967 != null && !this.R967.Equals(tc2.R967))) return false;
            if ((this.R975 == null && tc2.R975 != null) || (this.R975 != null && tc2.R975 == null) || (this.R975 != null && !this.R975.Equals(tc2.R975))) return false;
            if ((this.R983 == null && tc2.R983 != null) || (this.R983 != null && tc2.R983 == null) || (this.R983 != null && !this.R983.Equals(tc2.R983))) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
