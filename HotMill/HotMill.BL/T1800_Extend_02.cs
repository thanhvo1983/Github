using System;
using Kvics.HotMill.BL;
using Kvics.DBAccess;
using System.Data;

namespace Kvics.HotMill.BL
{
    public class T1800_Extend_02 : T_R
    {
        #region Static
        public static readonly string TABLE_NAME = "T1800_Extend_02";
        public static readonly string R1749__COLUMN_NAME = "R1749_ÇqÇaâ°Ç‘ÇÍó ÇaÇnÇsÇsÇnÇl";
        public static readonly string R1751__COLUMN_NAME = "R1751_ó\îı";
        public static readonly string R1753__COLUMN_NAME = "R1753_ëe–ŸWRà≥âÑtonêî_R4";
        public static readonly string R1757__COLUMN_NAME = "R1757_ëe–ŸWRà≥âÑtonêî_R5";
        public static readonly string R1761__COLUMN_NAME = "R1761_édè„–ŸWRà≥âÑtonêî_F1";
        public static readonly string R1765__COLUMN_NAME = "R1765_édè„–ŸWRà≥âÑtonêî_F2";
        public static readonly string R1769__COLUMN_NAME = "R1769_édè„–ŸWRà≥âÑtonêî_F3";
        public static readonly string R1773__COLUMN_NAME = "R1773_édè„–ŸWRà≥âÑtonêî_F4";
        public static readonly string R1777__COLUMN_NAME = "R1777_édè„–ŸWRà≥âÑtonêî_F5";
        public static readonly string R1781__COLUMN_NAME = "R1781_édè„–ŸWRà≥âÑtonêî_F6";
        public static readonly string R1785__COLUMN_NAME = "R1785_édè„–ŸWRà≥âÑtonêî_F7";

        public static readonly int EXTEND_PAKAGE_LENGTH = 40;
        #endregion

        #region Protected
        protected Int16 _R1749;
        protected string _R1751 = "";
        protected int _R1753;
        protected int _R1757;
        protected int _R1761;
        protected int _R1765;
        protected int _R1769;
        protected int _R1773;
        protected int _R1777;
        protected int _R1781;
        protected int _R1785;
        #endregion

        #region Property
        public Int16 R1749
        {
            get
            {
                return _R1749;
            }
            set
            {
                _R1749 = value;
            }
        }

        public string R1751
        {
            get
            {
                return _R1751;
            }
            set
            {
                _R1751 = Common.GetString(value, 0, 2, ' ', 2);
            }
        }

        public int R1753
        {
            get
            {
                return _R1753;
            }
            set
            {
                _R1753 = value;
            }
        }

        public int R1757
        {
            get
            {
                return _R1757;
            }
            set
            {
                _R1757 = value;
            }
        }

        public int R1761
        {
            get
            {
                return _R1761;
            }
            set
            {
                _R1761 = value;
            }
        }

        public int R1765
        {
            get
            {
                return _R1765;
            }
            set
            {
                _R1765 = value;
            }
        }

        public int R1769
        {
            get
            {
                return _R1769;
            }
            set
            {
                _R1769 = value;
            }
        }

        public int R1773
        {
            get
            {
                return _R1773;
            }
            set
            {
                _R1773 = value;
            }
        }

        public int R1777
        {
            get
            {
                return _R1777;
            }
            set
            {
                _R1777 = value;
            }
        }

        public int R1781
        {
            get
            {
                return _R1781;
            }
            set
            {
                _R1781 = value;
            }
        }

        public int R1785
        {
            get
            {
                return _R1785;
            }
            set
            {
                _R1785 = value;
            }
        }
        #endregion

        #region Constructors
        public T1800_Extend_02()
            : base()
        {
            
        }
        public T1800_Extend_02(int parentID, int rowID)
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

        private void FromDataRow(DataRow row)
        {
            _ID = (int)row[ID__COLUMN_NAME];
            _ParentID = (int)row[PARENTID__COLUMN_NAME];
            _RowID = (int)row[ROWID__COLUMN_NAME];

            _R1749 = row[R1749__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R1749__COLUMN_NAME]);
            _R1751 = row[R1751__COLUMN_NAME] == DBNull.Value ? "" : (row[R1751__COLUMN_NAME]).ToString();
            _R1753 = row[R1753__COLUMN_NAME] == DBNull.Value ? (int)0 : (int)(row[R1753__COLUMN_NAME]);
            _R1757 = row[R1757__COLUMN_NAME] == DBNull.Value ? (int)0 : (int)(row[R1757__COLUMN_NAME]);
            _R1761 = row[R1761__COLUMN_NAME] == DBNull.Value ? (int)0 : (int)(row[R1761__COLUMN_NAME]);
            _R1765 = row[R1765__COLUMN_NAME] == DBNull.Value ? (int)0 : (int)(row[R1765__COLUMN_NAME]);
            _R1769 = row[R1769__COLUMN_NAME] == DBNull.Value ? (int)0 : (int)(row[R1769__COLUMN_NAME]);
            _R1773 = row[R1773__COLUMN_NAME] == DBNull.Value ? (int)0 : (int)(row[R1773__COLUMN_NAME]);
            _R1777 = row[R1777__COLUMN_NAME] == DBNull.Value ? (int)0 : (int)(row[R1777__COLUMN_NAME]);
            _R1781 = row[R1781__COLUMN_NAME] == DBNull.Value ? (int)0 : (int)(row[R1781__COLUMN_NAME]);
            _R1785 = row[R1785__COLUMN_NAME] == DBNull.Value ? (int)0 : (int)(row[R1785__COLUMN_NAME]);
        }
        #endregion

        #region Insert/Update/Delete
        public override int Insert()
        {
            ParameterCollection coll = new ParameterCollection();
            coll.Add(PARENTID__COLUMN_NAME, _ParentID);
            coll.Add(ROWID__COLUMN_NAME, _RowID);
            // ÇqÇaâ°Ç‘ÇÍó Å@ÇaÇnÇsÇsÇnÇl
            coll.Add(R1749__COLUMN_NAME, _R1749);
            // ó\îı
            coll.Add(R1751__COLUMN_NAME, _R1751);
            // ëe–ŸWRà≥âÑtonêî
            coll.Add(R1753__COLUMN_NAME, _R1753);
            coll.Add(R1757__COLUMN_NAME, _R1757);
            // édè„–ŸWRà≥âÑtonêî
            coll.Add(R1761__COLUMN_NAME, _R1761);
            coll.Add(R1765__COLUMN_NAME, _R1765);
            coll.Add(R1769__COLUMN_NAME, _R1769);
            coll.Add(R1773__COLUMN_NAME, _R1773);
            coll.Add(R1777__COLUMN_NAME, _R1777);
            coll.Add(R1781__COLUMN_NAME, _R1781);
            coll.Add(R1785__COLUMN_NAME, _R1785);

            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }

                Object obj = _DBAccessor.InsertWithIdentity(TABLE_NAME, coll);

                _ID = Convert.ToInt32(obj);
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

            // ÇqÇaâ°Ç‘ÇÍó Å@ÇaÇnÇsÇsÇnÇl
            Buffer.BlockCopy(Common.GetBytes(_R1749), 0, data, 0, 2);
            // ó\îı
            Buffer.BlockCopy(Common.GetBytes(_R1751), 0, data, 2, 2);
            // ëe–ŸWRà≥âÑtonêî
            Buffer.BlockCopy(Common.GetBytes(_R1753), 0, data, 4, 4);
            Buffer.BlockCopy(Common.GetBytes(_R1757), 0, data, 8, 4);
            // édè„–ŸWRà≥âÑtonêî
            Buffer.BlockCopy(Common.GetBytes(_R1761), 0, data, 12, 4);
            Buffer.BlockCopy(Common.GetBytes(_R1765), 0, data, 16, 4);
            Buffer.BlockCopy(Common.GetBytes(_R1769), 0, data, 20, 4);
            Buffer.BlockCopy(Common.GetBytes(_R1773), 0, data, 24, 4);
            Buffer.BlockCopy(Common.GetBytes(_R1777), 0, data, 28, 4);
            Buffer.BlockCopy(Common.GetBytes(_R1781), 0, data, 32, 4);
            Buffer.BlockCopy(Common.GetBytes(_R1785), 0, data, 36, 4);

            return data;
        }

        public static T1800_Extend_02 Parse(Byte[] data, int startIndex)
        {
            T1800_Extend_02 ins = new T1800_Extend_02();

            ins.ParentID = 0;
            ins.RowID = 0;

            // ÇqÇaâ°Ç‘ÇÍó Å@ÇaÇnÇsÇsÇnÇl
            ins.R1749 = Common.ToInt16(data, startIndex);
            // ó\îı
            ins.R1751 = Common.GetString(data, startIndex + 2, 2);
            // ëe–ŸWRà≥âÑtonêî
            ins.R1753 = Common.ToInt32(data, startIndex + 4);
            ins.R1757 = Common.ToInt32(data, startIndex + 8);
            // édè„–ŸWRà≥âÑtonêî
            ins.R1761 = Common.ToInt32(data, startIndex + 12);
            ins.R1765 = Common.ToInt32(data, startIndex + 16);
            ins.R1769 = Common.ToInt32(data, startIndex + 20);
            ins.R1773 = Common.ToInt32(data, startIndex + 24);
            ins.R1777 = Common.ToInt32(data, startIndex + 28);
            ins.R1781 = Common.ToInt32(data, startIndex + 32);
            ins.R1785 = Common.ToInt32(data, startIndex + 36);

            return ins;
        }

        public static T1800_Extend_02 NewObject(int parentID, int rowID)
        {
            T1800_Extend_02 obj = new T1800_Extend_02();
            obj.ParentID = parentID;
            obj.RowID = rowID;

            // ÇqÇaâ°Ç‘ÇÍó Å@ÇaÇnÇsÇsÇnÇl
            obj.R1749 = 0;
            // ó\îı
            obj.R1751 = "  ";
            // ëe–ŸWRà≥âÑtonêî
            obj.R1753 = 0;
            obj.R1757 = 0;
            // édè„–ŸWRà≥âÑtonêî
            obj.R1761 = 0;
            obj.R1765 = 0;
            obj.R1769 = 0;
            obj.R1773 = 0;
            obj.R1777 = 0;
            obj.R1781 = 0;
            obj.R1785 = 0;

            return obj;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is T1800_Extend_02))
                return base.Equals(obj);
            T1800_Extend_02 tc2 = (T1800_Extend_02)obj;

            if (
                tc2.R1749 != R1749 || 
                tc2.R1751 != R1751 || 
                tc2.R1753 != R1753 || 
                tc2.R1757 != R1757 || 
                tc2.R1761 != R1761 || 
                tc2.R1765 != R1765 || 
                tc2.R1769 != R1769 || 
                tc2.R1773 != R1773 || 
                tc2.R1777 != R1777 || 
                tc2.R1781 != R1781 || 
                tc2.R1785 != R1785
                ) 
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
