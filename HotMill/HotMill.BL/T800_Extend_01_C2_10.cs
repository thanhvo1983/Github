using System;
using System.Data;

using Kvics.DBAccess;

namespace Kvics.HotMill.BL
{
    public class T800_Extend_01_C2_10 : T_C2_10
    {
        public static readonly string TABLE_NAME = "T800_Extend_01_C2_10";

        #region Constructors
        public T800_Extend_01_C2_10()
            : base()
        {
        }

        public T800_Extend_01_C2_10(DBAccessor dbAccessor)
            : base(dbAccessor)
        {
        }

        public T800_Extend_01_C2_10(int parentID, int rowID,
            String r1, String r2, String r3, String r4, String r5, String r6, String r7, String r8, String r9, String r10)
            : base(parentID, rowID, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10)
        {
        }

        public T800_Extend_01_C2_10(DBAccessor dbAccessor, int parentID, int rowID,
            String r1, String r2, String r3, String r4, String r5, String r6, String r7, String r8, String r9, String r10)
            : base(dbAccessor, parentID, rowID, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10)
        {
            
        }

        public T800_Extend_01_C2_10(int parentID, int rowID)
            : base(parentID, rowID, TABLE_NAME)
        {
        }

        public T800_Extend_01_C2_10(DBAccessor dbAccessor, int parentID, int rowID)
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

        public static T800_Extend_01_C2_10 Parse(Byte[] data, int startIndex)
        {
            T_C2_R ret = new T800_Extend_01_C2_10();

            return (T800_Extend_01_C2_10)Parse(data, startIndex, ref ret);
        }
    }
}
