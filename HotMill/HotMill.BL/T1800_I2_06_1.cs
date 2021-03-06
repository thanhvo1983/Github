using System;
using System.Data;

using Kvics.DBAccess;

namespace Kvics.HotMill.BL
{
    public class T1800_I2_06_1 : T_I2_06_1
    {
        public static readonly string TABLE_NAME = "T1800_I2_06_�g�b�N���E��";

        #region Constructors
        public T1800_I2_06_1()
            : base()
        {
        }

        public T1800_I2_06_1(DBAccessor dbAccessor)
            : base(dbAccessor)
        {
        }

        public T1800_I2_06_1(int parentID, int rowID,
            Int16 r1, Int16 r2, Int16 r3, Int16 r4, Int16 r5, Int16 r6) 
            : base(parentID, rowID, r1, r2, r3, r4, r5, r6)
        {
        }

        public T1800_I2_06_1(DBAccessor dbAccessor, int parentID, int rowID,
            Int16 r1, Int16 r2, Int16 r3, Int16 r4, Int16 r5, Int16 r6)
            : base(dbAccessor, parentID, rowID, r1, r2, r3, r4, r5, r6)
        {
            
        }

        public T1800_I2_06_1(int parentID, int rowID)
            : base(parentID, rowID, TABLE_NAME)
        {
        }

        public T1800_I2_06_1(DBAccessor dbAccessor, int parentID, int rowID)
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

        public static T1800_I2_06_1 Parse(Byte[] data, int startIndex)
        {
            T_I2_R ret = new T1800_I2_06_1();

            return (T1800_I2_06_1)Parse(data, startIndex, ref ret);
        }

        public static T1800_I2_06_1 NewObject(int parentID, int rowID)
        {
            return new T1800_I2_06_1(parentID, rowID, 0, 0, 0, 0, 0, 0);
        }
    }
}
