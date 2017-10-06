using System;
using System.Data;

using Kvics.DBAccess;

namespace Kvics.HotMill.BL
{
    public class T900_I4_14 : T_I4_14
    {
        public static readonly string TABLE_NAME = "T900_I4_14_‚a‚t‚qŒa";

        #region Constructors
        public T900_I4_14()
            : base()
        {
        }

        public T900_I4_14(DBAccessor dbAccessor)
            : base(dbAccessor)
        {
        }

        public T900_I4_14(int parentID, int rowID,
            Int32 r1, Int32 r2, Int32 r3, Int32 r4, Int32 r5, 
            Int32 r6, Int32 r7, Int32 r8, Int32 r9, Int32 r10,
            Int32 r11, Int32 r12, Int32 r13, Int32 r14)
            : base(parentID, rowID, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14)
        {
        }

        public T900_I4_14(DBAccessor dbAccessor, int parentID, int rowID,
            Int32 r1, Int32 r2, Int32 r3, Int32 r4, Int32 r5, 
            Int32 r6, Int32 r7, Int32 r8, Int32 r9, Int32 r10,
            Int32 r11, Int32 r12, Int32 r13, Int32 r14)
            : base(dbAccessor, parentID, rowID, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14)
        {
            
        }

        public T900_I4_14(int parentID, int rowID)
            : base(parentID, rowID, TABLE_NAME)
        {
        }

        public T900_I4_14(DBAccessor dbAccessor, int parentID, int rowID)
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

        public static T900_I4_14 Parse(Byte[] data, int startIndex)
        {
            T_I4_R ret = new T900_I4_14();

            return (T900_I4_14)Parse(data, startIndex, ref ret);
        }
    }
}
