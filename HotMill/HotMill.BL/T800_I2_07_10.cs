using System;
using System.Data;

using Kvics.DBAccess;

namespace Kvics.HotMill.BL
{
    public class T800_I2_07_10 : T_I2_07
    {
        public static readonly string TABLE_NAME = "T800_I2_07_ワークロールシフト量";

        #region Constructors
        public T800_I2_07_10()
            : base()
        {
        }

        public T800_I2_07_10(DBAccessor dbAccessor)
            : base(dbAccessor)
        {
        }

        public T800_I2_07_10(int parentID, int rowID,
            Int16 r1, Int16 r2, Int16 r3, Int16 r4, Int16 r5, Int16 r6, Int16 r7) 
            : base(parentID, rowID, r1, r2, r3, r4, r5, r6, r7)
        {
        }

        public T800_I2_07_10(DBAccessor dbAccessor, int parentID, int rowID,
            Int16 r1, Int16 r2, Int16 r3, Int16 r4, Int16 r5, Int16 r6, Int16 r7)
            : base(dbAccessor, parentID, rowID, r1, r2, r3, r4, r5, r6, r7)
        {
            
        }

        public T800_I2_07_10(int parentID, int rowID)
            : base(parentID, rowID, TABLE_NAME)
        {
        }

        public T800_I2_07_10(DBAccessor dbAccessor, int parentID, int rowID)
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

        public static T800_I2_07_10 Parse(Byte[] data, int startIndex)
        {
            T_I2_R ret = new T800_I2_07_10();

            return (T800_I2_07_10)Parse(data, startIndex, ref ret);
        }
        public static T800_I2_07_10 NewObject(int parentID, int rowID)
        {
            return new T800_I2_07_10(parentID, rowID, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
