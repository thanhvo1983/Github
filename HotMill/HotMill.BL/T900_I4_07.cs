using System;
using System.Data;

using Kvics.DBAccess;

namespace Kvics.HotMill.BL
{
    public class T900_I4_07 : T_I4_07
    {
        public static readonly string TABLE_NAME = "T900_I4_07_‚v‚qŒa";

        #region Constructors
        public T900_I4_07()
            : base()
        {
        }

        public T900_I4_07(DBAccessor dbAccessor)
            : base(dbAccessor)
        {
        }

        public T900_I4_07(int parentID, int rowID, 
            Int32 r1, Int32 r2, Int32 r3, Int32 r4, Int32 r5, Int32 r6, Int32 r7)
            : base(parentID, rowID, r1, r2, r3, r4, r5, r6, r7)
        {
        }

        public T900_I4_07(DBAccessor dbAccessor, int parentID, int rowID,
            Int32 r1, Int32 r2, Int32 r3, Int32 r4, Int32 r5, Int32 r6, Int32 r7)
            : base(dbAccessor, parentID, rowID, r1, r2, r3, r4, r5, r6, r7)
        {
            
        }

        public T900_I4_07(int parentID, int rowID)
            : base(parentID, rowID, TABLE_NAME)
        {
        }

        public T900_I4_07(DBAccessor dbAccessor, int parentID, int rowID)
            : base(dbAccessor, parentID, rowID, TABLE_NAME)
        {
        }
        #endregion

        public override int Insert()
        {
            return base.Insert(TABLE_NAME);
        }

        public override int Update()
        {
            return base.Update(TABLE_NAME);
        }

        public override int Delete()
        {
            return base.Delete(TABLE_NAME);
        }

        public static T900_I4_07 Parse(Byte[] data, int startIndex)
        {
            T_I4_R ret = new T900_I4_07();

            return (T900_I4_07)Parse(data, startIndex, ref ret);
        }
    }
}
