using System;
using System.Data;

using Kvics.DBAccess;

namespace Kvics.HotMill.BL
{
    public class T900_C6_14 : T_C6_14
    {
        public static readonly string TABLE_NAME = "T900_C6_14_ÇaÇtÇqî‘çÜ";

        #region Constructors
        public T900_C6_14()
            : base()
        {
        }

        public T900_C6_14(DBAccessor dbAccessor)
            : base(dbAccessor)
        {
        }

        public T900_C6_14(int parentID, int rowID,
            String r1, String r2, String r3, String r4, String r5,
            String r6, String r7, String r8, String r9, String r10,
            String r11, String r12, String r13, String r14)
            : base(parentID, rowID, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14)
        {
        }

        public T900_C6_14(DBAccessor dbAccessor, int parentID, int rowID,
            String r1, String r2, String r3, String r4, String r5,
            String r6, String r7, String r8, String r9, String r10,
            String r11, String r12, String r13, String r14)
            : base(dbAccessor, parentID, rowID, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14)
        {
            
        }

        public T900_C6_14(int parentID, int rowID)
            : base(parentID, rowID, TABLE_NAME)
        {
        }

        public T900_C6_14(DBAccessor dbAccessor, int parentID, int rowID)
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

        public static T900_C6_14 Parse(Byte[] data, int startIndex)
        {
            T_C6_R ret = new T900_C6_14();

            return (T900_C6_14)Parse(data, startIndex, ref ret);
        }
    }
}
