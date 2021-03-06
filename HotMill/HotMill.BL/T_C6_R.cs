using System;
using System.Data;

using Kvics.DBAccess;

namespace Kvics.HotMill.BL
{
	/// <summary>
	/// Summary description for T_C6_R.
	/// </summary>
    public class T_C6_R : T_R
    {
        #region Protected
        protected String[] _Rows;
        #endregion

        #region Property
        public String[] Rows
        {
            get
            {
                return _Rows;
            }
        }        
        #endregion

        #region Constructors
        protected T_C6_R()
        {
        }

        protected T_C6_R(DBAccessor dbAccessor)
        {
            this.DBAccessor = dbAccessor;
        }

        protected T_C6_R(int parentId, int rowID, String[] rows)
        {
            this.ParentID = parentId;
            this._RowID = rowID;
            this._Rows = rows;
        }

        protected T_C6_R(int parentId, int rowID, String[] rows, DBAccessor dbAccessor)
        {
            this.ParentID = parentId;
            this._RowID = rowID;
            this._Rows = rows;
            this.DBAccessor = dbAccessor;
        }

        #endregion

        public Byte[] GetBytes()
        {
            Byte[] data = null;

            data = new Byte[_Rows.Length * 6];

            for (int i = 0; i < _Rows.Length; i++)
            {
                Buffer.BlockCopy(Common.GetBytes(_Rows[i]), 0, data, i * 6, 6);
            }

            return data;
        }

        protected static T_C6_R Parse(Byte[] data, int startIndex, ref T_C6_R ins)
        {
            ins.ParentID = 0;

            for (int i = 0, size = ins.Rows.Length; i < size; i++)
            {
                ins.Rows[i] = Common.GetString(data, startIndex + i * 6, 6);
            }

            return ins;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is T_C6_R))
                return base.Equals(obj);
            T_C6_R tc2 = (T_C6_R)obj;

            if (tc2 == null || tc2.Rows.Length != this._Rows.Length)
            {
                return false;
            }

            for (int i = 0; i < _Rows.Length; i++)
            {
                if ((tc2.Rows[i] == null && _Rows[i] != null) || (tc2.Rows[i] != null && _Rows[i] == null))
                {
                    return false;
                }
                else if (tc2.Rows[i] != null && _Rows[i] != null && !Rows[i].Equals(tc2.Rows[i], StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
