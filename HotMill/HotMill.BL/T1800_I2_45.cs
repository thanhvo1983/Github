using System;
using System.Data;

using Kvics.DBAccess;

namespace Kvics.HotMill.BL
{
    public class T1800_I2_45 : T_I2_45
    {
        public static readonly string TABLE_NAME = "T1800_I2_45_ÇvÇqÉvÉçÉtÉBÅ[Éã";

        #region Constructors
        public T1800_I2_45()
            : base()
        {
        }

        public T1800_I2_45(DBAccessor dbAccessor)
            : base(dbAccessor)
        {
        }

        public T1800_I2_45(int parentID, int rowID,
            Int16 r1, Int16 r2, Int16 r3, Int16 r4, Int16 r5, 
            Int16 r6, Int16 r7, Int16 r8, Int16 r9, Int16 r10,
            Int16 r11, Int16 r12, Int16 r13, Int16 r14, Int16 r15,
            Int16 r16, Int16 r17, Int16 r18, Int16 r19, Int16 r20,
            Int16 r21, Int16 r22, Int16 r23, Int16 r24, Int16 r25,
            Int16 r26, Int16 r27, Int16 r28, Int16 r29, Int16 r30,
            Int16 r31, Int16 r32, Int16 r33, Int16 r34, Int16 r35,
            Int16 r36, Int16 r37, Int16 r38, Int16 r39, Int16 r40,
            Int16 r41, Int16 r42, Int16 r43, Int16 r44, Int16 r45)
            : base(parentID, rowID,
                r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r15, r26, r27, r28, r29, r30,
                r31, r32, r33, r34, r35, r36, r37, r38, r39, r40,
                r41, r42, r43, r44, r45)
        {
        }

        public T1800_I2_45(DBAccessor dbAccessor, int parentID, int rowID,
            Int16 r1, Int16 r2, Int16 r3, Int16 r4, Int16 r5, 
            Int16 r6, Int16 r7, Int16 r8, Int16 r9, Int16 r10,
            Int16 r11, Int16 r12, Int16 r13, Int16 r14, Int16 r15,
            Int16 r16, Int16 r17, Int16 r18, Int16 r19, Int16 r20,
            Int16 r21, Int16 r22, Int16 r23, Int16 r24, Int16 r25,
            Int16 r26, Int16 r27, Int16 r28, Int16 r29, Int16 r30,
            Int16 r31, Int16 r32, Int16 r33, Int16 r34, Int16 r35,
            Int16 r36, Int16 r37, Int16 r38, Int16 r39, Int16 r40,
            Int16 r41, Int16 r42, Int16 r43, Int16 r44, Int16 r45)
            : base(dbAccessor, parentID, rowID,
                r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r15, r26, r27, r28, r29, r30,
                r31, r32, r33, r34, r35, r36, r37, r38, r39, r40,
                r41, r42, r43, r44, r45)
        {
            
        }

        public T1800_I2_45(int parentID, int rowID)
            : base(parentID, rowID, TABLE_NAME)
        {
        }

        public T1800_I2_45(DBAccessor dbAccessor, int parentID, int rowID)
            : base(dbAccessor, parentID, rowID,TABLE_NAME)
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

        public static T1800_I2_45 Parse(Byte[] data, int startIndex)
        {
            T_I2_R ret = new T1800_I2_45();

            return (T1800_I2_45)Parse(data, startIndex, ref ret);
        }
        public static T1800_I2_45 NewObject(int parentID, int rowID)
        {
            return new T1800_I2_45(parentID, rowID, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0);
        }
    }
}
