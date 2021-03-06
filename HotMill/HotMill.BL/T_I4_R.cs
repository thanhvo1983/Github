using System;
using System.Data;

using Kvics.DBAccess;

namespace Kvics.HotMill.BL
{
	/// <summary>
	/// Summary description for T_I4_R.
	/// </summary>
    public class T_I4_R : T_R
    {
        #region Protected
        protected Int32[] _Rows;
        #endregion

        #region Property
        public Int32[] Rows
        {
            get
            {
                return _Rows;
            }
            set
            {
                if (value != null && _Rows != null && value.Length == _Rows.Length)
                {
                    _Rows = value;
                }
            }
        }
        #endregion

        #region Constructors
        public T_I4_R()
        {
        }

        protected T_I4_R(DBAccessor dbAccessor)
        {
            this.DBAccessor = dbAccessor;
        }

        protected T_I4_R(int parentId, int rowId, Int32[] rows)
        {
            this.ParentID = parentId;
            this._RowID = rowId;
            this._Rows = rows;
        }

        protected T_I4_R(int parentId, int rowId, Int32[] rows, DBAccessor dbAccessor)
        {
            this.ParentID = parentId;
            this._RowID = rowId;
            this._Rows = rows;
            this.DBAccessor = dbAccessor;
        }

        #endregion

        public Byte[] GetBytes()
        {
            Byte[] data = null;

            data = new Byte[_Rows.Length * 4];

            for (int i = 0, size = _Rows.Length; i < size; i++)
            {
                Buffer.BlockCopy(Common.GetBytes(_Rows[i]), 0, data, i * 4, 4);
            }

            return data;
        }

        protected static T_I4_R Parse(Byte[] data, int startIndex, ref T_I4_R ins)
        {
            ins.ParentID = 0;

            for (int i = 0, size = ins.Rows.Length; i < size; i++)
            {
                ins.Rows[i] = Common.ToInt32(data, startIndex + i * 4);
            }

            return ins;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is T_I4_R))
                return base.Equals(obj);
            T_I4_R tc2 = (T_I4_R)obj;
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

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
