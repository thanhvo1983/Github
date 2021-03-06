using System;
using System.Data;

using Kvics.DBAccess;

namespace Kvics.HotMill.BL
{
	/// <summary>
	/// Summary description for T_I2_R.
	/// </summary>
    public class T_I2_R : T_R
    {
        #region Protected
        protected Int16[] _Rows;
        #endregion

        #region Property
        public Int16[] Rows
        {
            get
            {
                return _Rows;
            }
        }        
        #endregion

        #region Constructors
        protected T_I2_R()
        {
        }

        protected T_I2_R(DBAccessor dbAccessor)
        {
            this.DBAccessor = dbAccessor;
        }

        protected T_I2_R(int parentId, int rowId, Int16[] rows)
        {
            this.ParentID = parentId;
            this._RowID = rowId;
            this._Rows = rows;
        }

        protected T_I2_R(int parentId, int rowId, Int16[] rows, DBAccessor dbAccessor)
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

            data = new Byte[_Rows.Length * 2];

            for (int i = 0; i < _Rows.Length; i++)
            {
                Buffer.BlockCopy(Common.GetBytes(_Rows[i]), 0, data, i * 2, 2);
            }

            return data;
        }

        protected static T_I2_R Parse(Byte[] data, int startIndex, ref T_I2_R ins)
        {
            ins.ParentID = 0;

            for (int i = 0, size = ins.Rows.Length; i < size; i++)
            {
                ins.Rows[i] = Common.ToInt16(data, startIndex + i * 2);
            }

            return ins;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is T_I2_R))
                return base.Equals(obj);
            T_I2_R tc2 = (T_I2_R)obj;
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
