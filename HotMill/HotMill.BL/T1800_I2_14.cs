using System;
using System.Data;

using Kvics.DBAccess;

namespace Kvics.HotMill.BL
{
    public class T1800_I2_14 : T_I2_14
    {
        public static readonly string TABLE_NAME = "T1800_I2_14_各スタンドでの該当情報_2";

        #region Constructors
        public T1800_I2_14()
            : base()
        {
        }

        public T1800_I2_14(DBAccessor dbAccessor)
            : base(dbAccessor)
        {
        }

        public T1800_I2_14(int parentID, int rowID,
            Int16 r1, Int16 r2, Int16 r3, Int16 r4, Int16 r5, 
            Int16 r6, Int16 r7, Int16 r8, Int16 r9, Int16 r10,
            Int16 r11, Int16 r12, Int16 r13, Int16 r14)
            : base(parentID, rowID, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14)
        {
        }

        public T1800_I2_14(DBAccessor dbAccessor, int parentID, int rowID,
            Int16 r1, Int16 r2, Int16 r3, Int16 r4, Int16 r5, 
            Int16 r6, Int16 r7, Int16 r8, Int16 r9, Int16 r10,
            Int16 r11, Int16 r12, Int16 r13, Int16 r14)
            : base(dbAccessor, rowID, parentID, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14)
        {
            
        }

        public T1800_I2_14(int parentID, int rowID)
            : base(parentID, rowID, TABLE_NAME)
        {
        }

        public T1800_I2_14(DBAccessor dbAccessor, int parentID, int rowID)
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

        public static T1800_I2_14 Parse(Byte[] data, int startIndex)
        {
            T_I2_R ret = new T1800_I2_14();

            return (T1800_I2_14)Parse(data, startIndex, ref ret);
        }
        public static T1800_I2_14 NewObject(int parentID, int rowID)
        {
            return new T1800_I2_14(parentID, rowID, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
