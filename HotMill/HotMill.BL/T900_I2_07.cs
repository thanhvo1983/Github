using System;
using System.Data;

using Kvics.DBAccess;

namespace Kvics.HotMill.BL
{
    public class T900_I2_07 : T_I2_07
    {
        public static readonly string TABLE_NAME = "T900_I2_07_各スタンドでの該当情報";

        #region Constructors
        public T900_I2_07()
            : base()
        {
        }

        public T900_I2_07(DBAccessor dbAccessor)
            : base(dbAccessor)
        {
        }

        public T900_I2_07(int parentID, int rowID,
            Int16 r1, Int16 r2, Int16 r3, Int16 r4, Int16 r5, Int16 r6, Int16 r7) 
            : base(parentID, rowID, r1, r2, r3, r4, r5, r6, r7)
        {
        }

        public T900_I2_07(DBAccessor dbAccessor, int parentID, int rowID,
            Int16 r1, Int16 r2, Int16 r3, Int16 r4, Int16 r5, Int16 r6, Int16 r7)
            : base(dbAccessor, parentID, rowID, r1, r2, r3, r4, r5, r6, r7)
        {
            
        }

        public T900_I2_07(int parentID, int rowID)
            : base(parentID, rowID, TABLE_NAME)
        {
        }

        public T900_I2_07(DBAccessor dbAccessor, int parentID, int rowID)
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

        public static T900_I2_07 Parse(Byte[] data, int startIndex)
        {
            T_I2_R ret = new T900_I2_07();

            return (T900_I2_07)Parse(data, startIndex, ref ret);
        }
    }
}
