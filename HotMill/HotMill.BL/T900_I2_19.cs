using System;
using System.Data;

using Kvics.DBAccess;

namespace Kvics.HotMill.BL
{
    public class T900_I2_19 : T_I2_19
    {
        public static readonly string TABLE_NAME = "T900_I2_19_âªäwê¨ï™";

        #region Constructors
        public T900_I2_19()
            : base()
        {
        }

        public T900_I2_19(DBAccessor dbAccessor)
            : base(dbAccessor)
        {
        }

        public T900_I2_19(int parentID, int rowID,
            Int16 r1, Int16 r2, Int16 r3, Int16 r4, Int16 r5, 
            Int16 r6, Int16 r7, Int16 r8, Int16 r9, Int16 r10,
            Int16 r11, Int16 r12, Int16 r13, Int16 r14, Int16 r15,
            Int16 r16, Int16 r17, Int16 r18, Int16 r19)
            : base(parentID, rowID, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14, r15, r16, r17, r18, r19)
        {
        }

        public T900_I2_19(DBAccessor dbAccessor, int parentID, int rowID,
            Int16 r1, Int16 r2, Int16 r3, Int16 r4, Int16 r5, 
            Int16 r6, Int16 r7, Int16 r8, Int16 r9, Int16 r10,
            Int16 r11, Int16 r12, Int16 r13, Int16 r14, Int16 r15,
            Int16 r16, Int16 r17, Int16 r18, Int16 r19)
            : base(dbAccessor, parentID, rowID, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14, r15, r16, r17, r18, r19)
        {
            
        }

        public T900_I2_19(int parentID, int rowID)
            : base(parentID, rowID, TABLE_NAME)
        {
        }

        public T900_I2_19(DBAccessor dbAccessor, int parentID, int rowID)
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

        public static T900_I2_19 Parse(Byte[] data, int startIndex)
        {
            T_I2_R ret = new T900_I2_19();

            return (T900_I2_19)Parse(data, startIndex, ref ret);
        }
    }
}
