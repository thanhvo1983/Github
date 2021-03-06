using System;
using System.Data;

using Kvics.DBAccess;

namespace Kvics.HotMill.BL
{
	/// <summary>
    /// Summary description for T_I2_44.
	/// </summary>
    public class T_I2_44 : T_I2_R
    {
        #region Static
        public static readonly string R01__COLUMN_NAME = "R1661_ｺｲﾙ長";
        public static readonly string R02__COLUMN_NAME = "R1663_ｺｲﾙ重量";
        public static readonly string R03__COLUMN_NAME = "R1665_F1ｵﾝ時刻_時";
        public static readonly string R04__COLUMN_NAME = "R1667_F1ｵﾝ時刻_分";
        public static readonly string R05__COLUMN_NAME = "R1669_F1ｵﾝ時刻_秒";
        public static readonly string R06__COLUMN_NAME = "R1671_F1ｵﾌ時刻_時";
        public static readonly string R07__COLUMN_NAME = "R1673_F1ｵﾌ時刻_分";
        public static readonly string R08__COLUMN_NAME = "R1675_F1ｵﾌ時刻_秒";
        public static readonly string R09__COLUMN_NAME = "R1677_F2ｵﾝ時刻_時";
        public static readonly string R10__COLUMN_NAME = "R1679_F2ｵﾝ時刻_分";
        public static readonly string R11__COLUMN_NAME = "R1681_F2ｵﾝ時刻_秒";
        public static readonly string R12__COLUMN_NAME = "R1683_F2ｵﾌ時刻_時";
        public static readonly string R13__COLUMN_NAME = "R1685_F2ｵﾌ時刻_分";
        public static readonly string R14__COLUMN_NAME = "R1687_F2ｵﾌ時刻_秒";
        public static readonly string R15__COLUMN_NAME = "R1689_F3ｵﾝ時刻_時";
        public static readonly string R16__COLUMN_NAME = "R1691_F3ｵﾝ時刻_分";
        public static readonly string R17__COLUMN_NAME = "R1693_F3ｵﾝ時刻_秒";
        public static readonly string R18__COLUMN_NAME = "R1695_F3ｵﾌ時刻_時";
        public static readonly string R19__COLUMN_NAME = "R1697_F3ｵﾌ時刻_分";
        public static readonly string R20__COLUMN_NAME = "R1699_F3ｵﾌ時刻_秒";
        public static readonly string R21__COLUMN_NAME = "R1701_F4ｵﾝ時刻_時";
        public static readonly string R22__COLUMN_NAME = "R1703_F4ｵﾝ時刻_分";
        public static readonly string R23__COLUMN_NAME = "R1705_F4ｵﾝ時刻_秒";
        public static readonly string R24__COLUMN_NAME = "R1707_F4ｵﾌ時刻_時";
        public static readonly string R25__COLUMN_NAME = "R1709_F4ｵﾌ時刻_分";
        public static readonly string R26__COLUMN_NAME = "R1711_F4ｵﾌ時刻_秒";
        public static readonly string R27__COLUMN_NAME = "R1713_F5ｵﾝ時刻_時";
        public static readonly string R28__COLUMN_NAME = "R1715_F5ｵﾝ時刻_分";
        public static readonly string R29__COLUMN_NAME = "R1717_F5ｵﾝ時刻_秒";
        public static readonly string R30__COLUMN_NAME = "R1719_F5ｵﾌ時刻_時";
        public static readonly string R31__COLUMN_NAME = "R1721_F5ｵﾌ時刻_分";
        public static readonly string R32__COLUMN_NAME = "R1723_F5ｵﾌ時刻_秒";
        public static readonly string R33__COLUMN_NAME = "R1725_F6ｵﾝ時刻_時";
        public static readonly string R34__COLUMN_NAME = "R1727_F6ｵﾝ時刻_分";
        public static readonly string R35__COLUMN_NAME = "R1729_F6ｵﾝ時刻_秒";
        public static readonly string R36__COLUMN_NAME = "R1731_F6ｵﾌ時刻_時";
        public static readonly string R37__COLUMN_NAME = "R1733_F6ｵﾌ時刻_分";
        public static readonly string R38__COLUMN_NAME = "R1735_F6ｵﾌ時刻_秒";
        public static readonly string R39__COLUMN_NAME = "R1737_F7ｵﾝ時刻_時";
        public static readonly string R40__COLUMN_NAME = "R1739_F7ｵﾝ時刻_分";
        public static readonly string R41__COLUMN_NAME = "R1741_F7ｵﾝ時刻_秒";
        public static readonly string R42__COLUMN_NAME = "R1743_F7ｵﾌ時刻_時";
        public static readonly string R43__COLUMN_NAME = "R1745_F7ｵﾌ時刻_分";
        public static readonly string R44__COLUMN_NAME = "R1747_F7ｵﾌ時刻_秒";
        /*
        public static readonly string R1661__COLUMN_NAME = "R1661_ｺｲﾙ長";
        public static readonly string R1663__COLUMN_NAME = "R1663_ｺｲﾙ重量";
        public static readonly string R1665__COLUMN_NAME = "R1665_F1ｵﾝ時刻_時";
        public static readonly string R1667__COLUMN_NAME = "R1667_F1ｵﾝ時刻_分";
        public static readonly string R1669__COLUMN_NAME = "R1669_F1ｵﾝ時刻_秒";
        public static readonly string R1671__COLUMN_NAME = "R1671_F1ｵﾌ時刻_時";
        public static readonly string R1673__COLUMN_NAME = "R1673_F1ｵﾌ時刻_分";
        public static readonly string R1675__COLUMN_NAME = "R1675_F1ｵﾌ時刻_秒";
        public static readonly string R1677__COLUMN_NAME = "R1677_F2ｵﾝ時刻_時";
        public static readonly string R1679__COLUMN_NAME = "R1679_F2ｵﾝ時刻_分";
        public static readonly string R1681__COLUMN_NAME = "R1681_F2ｵﾝ時刻_秒";
        public static readonly string R1683__COLUMN_NAME = "R1683_F2ｵﾌ時刻_時";
        public static readonly string R1685__COLUMN_NAME = "R1685_F2ｵﾌ時刻_分";
        public static readonly string R1687__COLUMN_NAME = "R1687_F2ｵﾌ時刻_秒";
        public static readonly string R1689__COLUMN_NAME = "R1689_F3ｵﾝ時刻_時";
        public static readonly string R1691__COLUMN_NAME = "R1691_F3ｵﾝ時刻_分";
        public static readonly string R1693__COLUMN_NAME = "R1693_F3ｵﾝ時刻_秒";
        public static readonly string R1695__COLUMN_NAME = "R1695_F3ｵﾌ時刻_時";
        public static readonly string R1697__COLUMN_NAME = "R1697_F3ｵﾌ時刻_分";
        public static readonly string R1699__COLUMN_NAME = "R1699_F3ｵﾌ時刻_秒";
        public static readonly string R1701__COLUMN_NAME = "R1701_F4ｵﾝ時刻_時";
        public static readonly string R1703__COLUMN_NAME = "R1703_F4ｵﾝ時刻_分";
        public static readonly string R1705__COLUMN_NAME = "R1705_F4ｵﾝ時刻_秒";
        public static readonly string R1707__COLUMN_NAME = "R1707_F4ｵﾌ時刻_時";
        public static readonly string R1709__COLUMN_NAME = "R1709_F4ｵﾌ時刻_分";
        public static readonly string R1711__COLUMN_NAME = "R1711_F4ｵﾌ時刻_秒";
        public static readonly string R1713__COLUMN_NAME = "R1713_F5ｵﾝ時刻_時";
        public static readonly string R1715__COLUMN_NAME = "R1715_F5ｵﾝ時刻_分";
        public static readonly string R1717__COLUMN_NAME = "R1717_F5ｵﾝ時刻_秒";
        public static readonly string R1719__COLUMN_NAME = "R1719_F5ｵﾌ時刻_時";
        public static readonly string R1721__COLUMN_NAME = "R1721_F5ｵﾌ時刻_分";
        public static readonly string R1723__COLUMN_NAME = "R1723_F5ｵﾌ時刻_秒";
        public static readonly string R1725__COLUMN_NAME = "R1725_F6ｵﾝ時刻_時";
        public static readonly string R1727__COLUMN_NAME = "R1727_F6ｵﾝ時刻_分";
        public static readonly string R1729__COLUMN_NAME = "R1729_F6ｵﾝ時刻_秒";
        public static readonly string R1731__COLUMN_NAME = "R1731_F6ｵﾌ時刻_時";
        public static readonly string R1733__COLUMN_NAME = "R1733_F6ｵﾌ時刻_分";
        public static readonly string R1735__COLUMN_NAME = "R1735_F6ｵﾌ時刻_秒";
        public static readonly string R1737__COLUMN_NAME = "R1737_F7ｵﾝ時刻_時";
        public static readonly string R1739__COLUMN_NAME = "R1739_F7ｵﾝ時刻_分";
        public static readonly string R1741__COLUMN_NAME = "R1741_F7ｵﾝ時刻_秒";
        public static readonly string R1743__COLUMN_NAME = "R1743_F7ｵﾌ時刻_時";
        public static readonly string R1745__COLUMN_NAME = "R1745_F7ｵﾌ時刻_分";
        public static readonly string R1747__COLUMN_NAME = "R1747_F7ｵﾌ時刻_秒";
        */
        #endregion

        #region Property
        public Int16 R01
        {
            get
            {
                return _Rows[0];
            }
            set
            {
                _Rows[0] = value;
            }
        }

        public Int16 R02
        {
            get
            {
                return _Rows[1];
            }
            set
            {
                _Rows[1] = value;
            }
        }

        public Int16 R03
        {
            get
            {
                return _Rows[2];
            }
            set
            {
                _Rows[2] = value;
            }
        }

        public Int16 R04
        {
            get
            {
                return _Rows[3];
            }
            set
            {
                _Rows[3] = value;
            }
        }

        public Int16 R05
        {
            get
            {
                return _Rows[4];
            }
            set
            {
                _Rows[4] = value;
            }
        }

        public Int16 R06
        {
            get
            {
                return _Rows[5];
            }
            set
            {
                _Rows[5] = value;
            }
        }

        public Int16 R07
        {
            get
            {
                return _Rows[6];
            }
            set
            {
                _Rows[6] = value;
            }
        }

        public Int16 R08
        {
            get
            {
                return _Rows[7];
            }
            set
            {
                _Rows[7] = value;
            }
        }

        public Int16 R09
        {
            get
            {
                return _Rows[8];
            }
            set
            {
                _Rows[8] = value;
            }
        }

        public Int16 R10
        {
            get
            {
                return _Rows[9];
            }
            set
            {
                _Rows[9] = value;
            }
        }

        public Int16 R11
        {
            get
            {
                return _Rows[10];
            }
            set
            {
                _Rows[10] = value;
            }
        }

        public Int16 R12
        {
            get
            {
                return _Rows[11];
            }
            set
            {
                _Rows[11] = value;
            }
        }

        public Int16 R13
        {
            get
            {
                return _Rows[12];
            }
            set
            {
                _Rows[12] = value;
            }
        }

        public Int16 R14
        {
            get
            {
                return _Rows[13];
            }
            set
            {
                _Rows[13] = value;
            }
        }
        
        public Int16 R15
        {
            get
            {
                return _Rows[14];
            }
            set
            {
                _Rows[14] = value;
            }
        }

        public Int16 R16
        {
            get
            {
                return _Rows[15];
            }
            set
            {
                _Rows[15] = value;
            }
        }

        public Int16 R17
        {
            get
            {
                return _Rows[16];
            }
            set
            {
                _Rows[16] = value;
            }
        }

        public Int16 R18
        {
            get
            {
                return _Rows[17];
            }
            set
            {
                _Rows[17] = value;
            }
        }

        public Int16 R19
        {
            get
            {
                return _Rows[18];
            }
            set
            {
                _Rows[18] = value;
            }
        }

        public Int16 R20
        {
            get
            {
                return _Rows[19];
            }
            set
            {
                _Rows[19] = value;
            }
        }

        public Int16 R21
        {
            get
            {
                return _Rows[20];
            }
            set
            {
                _Rows[20] = value;
            }
        }

        public Int16 R22
        {
            get
            {
                return _Rows[21];
            }
            set
            {
                _Rows[21] = value;
            }
        }

        public Int16 R23
        {
            get
            {
                return _Rows[22];
            }
            set
            {
                _Rows[22] = value;
            }
        }

        public Int16 R24
        {
            get
            {
                return _Rows[23];
            }
            set
            {
                _Rows[23] = value;
            }
        }

        public Int16 R25
        {
            get
            {
                return _Rows[24];
            }
            set
            {
                _Rows[24] = value;
            }
        }

        public Int16 R26
        {
            get
            {
                return _Rows[25];
            }
            set
            {
                _Rows[25] = value;
            }
        }

        public Int16 R27
        {
            get
            {
                return _Rows[26];
            }
            set
            {
                _Rows[26] = value;
            }
        }

        public Int16 R28
        {
            get
            {
                return _Rows[27];
            }
            set
            {
                _Rows[27] = value;
            }
        }

        public Int16 R29
        {
            get
            {
                return _Rows[28];
            }
            set
            {
                _Rows[28] = value;
            }
        }

        public Int16 R30
        {
            get
            {
                return _Rows[29];
            }
            set
            {
                _Rows[29] = value;
            }
        }

        public Int16 R31
        {
            get
            {
                return _Rows[30];
            }
            set
            {
                _Rows[30] = value;
            }
        }

        public Int16 R32
        {
            get
            {
                return _Rows[31];
            }
            set
            {
                _Rows[31] = value;
            }
        }

        public Int16 R33
        {
            get
            {
                return _Rows[32];
            }
            set
            {
                _Rows[32] = value;
            }
        }

        public Int16 R34
        {
            get
            {
                return _Rows[33];
            }
            set
            {
                _Rows[33] = value;
            }
        }

        public Int16 R35
        {
            get
            {
                return _Rows[34];
            }
            set
            {
                _Rows[34] = value;
            }
        }

        public Int16 R36
        {
            get
            {
                return _Rows[35];
            }
            set
            {
                _Rows[35] = value;
            }
        }

        public Int16 R37
        {
            get
            {
                return _Rows[36];
            }
            set
            {
                _Rows[36] = value;
            }
        }

        public Int16 R38
        {
            get
            {
                return _Rows[37];
            }
            set
            {
                _Rows[37] = value;
            }
        }

        public Int16 R39
        {
            get
            {
                return _Rows[38];
            }
            set
            {
                _Rows[38] = value;
            }
        }

        public Int16 R40
        {
            get
            {
                return _Rows[39];
            }
            set
            {
                _Rows[39] = value;
            }
        }

        public Int16 R41
        {
            get
            {
                return _Rows[40];
            }
            set
            {
                _Rows[40] = value;
            }
        }

        public Int16 R42
        {
            get
            {
                return _Rows[41];
            }
            set
            {
                _Rows[41] = value;
            }
        }

        public Int16 R43
        {
            get
            {
                return _Rows[42];
            }
            set
            {
                _Rows[42] = value;
            }
        }

        public Int16 R44
        {
            get
            {
                return _Rows[43];
            }
            set
            {
                _Rows[43] = value;
            }
        }

        public Int16 R45
        {
            get
            {
                return _Rows[44];
            }
            set
            {
                _Rows[44] = value;
            }
        }
        #endregion

        #region Constructors
        protected T_I2_44() : base()
        {
            this._Rows = new Int16[44];
        }

        protected T_I2_44(DBAccessor dbAccessor) : base(dbAccessor)
        {
            this._Rows = new Int16[44];
        }

        protected T_I2_44(int parentID, int rowID,
            Int16 r1, Int16 r2, Int16 r3, Int16 r4, Int16 r5, 
            Int16 r6, Int16 r7, Int16 r8, Int16 r9, Int16 r10,
            Int16 r11, Int16 r12, Int16 r13, Int16 r14, Int16 r15,
            Int16 r16, Int16 r17, Int16 r18, Int16 r19, Int16 r20,
            Int16 r21, Int16 r22, Int16 r23, Int16 r24, Int16 r25,
            Int16 r26, Int16 r27, Int16 r28, Int16 r29, Int16 r30,
            Int16 r31, Int16 r32, Int16 r33, Int16 r34, Int16 r35,
            Int16 r36, Int16 r37, Int16 r38, Int16 r39, Int16 r40,
            Int16 r41, Int16 r42, Int16 r43, Int16 r44)
            : base(parentID, rowID,
            new Int16[] { r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, 
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r15, r26, r27, r28, r29, r30,
                r31, r32, r33, r34, r35, r36, r37, r38, r39, r40,
                r41, r42, r43, r44 })
        {
        }

        protected T_I2_44(DBAccessor dbAccessor, int parentID, int rowID,
            Int16 r1, Int16 r2, Int16 r3, Int16 r4, Int16 r5, 
            Int16 r6, Int16 r7, Int16 r8, Int16 r9, Int16 r10,
            Int16 r11, Int16 r12, Int16 r13, Int16 r14, Int16 r15,
            Int16 r16, Int16 r17, Int16 r18, Int16 r19, Int16 r20,
            Int16 r21, Int16 r22, Int16 r23, Int16 r24, Int16 r25,
            Int16 r26, Int16 r27, Int16 r28, Int16 r29, Int16 r30,
            Int16 r31, Int16 r32, Int16 r33, Int16 r34, Int16 r35,
            Int16 r36, Int16 r37, Int16 r38, Int16 r39, Int16 r40,
            Int16 r41, Int16 r42, Int16 r43, Int16 r44)
            : base(parentID, rowID,
            new Int16[] { r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, 
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r15, r26, r27, r28, r29, r30,
                r31, r32, r33, r34, r35, r36, r37, r38, r39, r40,
                r41, r42, r43, r44  }, dbAccessor)
        {
            
        }

        protected T_I2_44(int parentID, int rowID, string TableName)
            : base()
        {
            WhereParameterCollection whereColl = new WhereParameterCollection();
            whereColl.Add(PARENTID__COLUMN_NAME, parentID, CompareType.Equal);
            whereColl.Add(ROWID__COLUMN_NAME, rowID, CompareType.Equal);

            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                DataSet ds = _DBAccessor.GetTable(TableName, whereColl);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    FromDataRow(row);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!this.db_Set)
                {
                    _DBAccessor.Dispose();
                }
            }
        }

        protected T_I2_44(DBAccessor dbAccessor, int parentID, int rowID, string TableName)
            : base(dbAccessor)
        {
            WhereParameterCollection whereColl = new WhereParameterCollection();
            whereColl.Add(PARENTID__COLUMN_NAME, parentID, CompareType.Equal);
            whereColl.Add(ROWID__COLUMN_NAME, rowID, CompareType.Equal);

            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                DataSet ds = _DBAccessor.GetTable(TableName, whereColl);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    FromDataRow(row);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!this.db_Set)
                {
                    _DBAccessor.Dispose();
                }
            }
        }
        #endregion

        protected void FromDataRow(DataRow row)
        {
            _Rows = new Int16[44];

            _ID = (int)row[ID__COLUMN_NAME];
            _ParentID = (int)row[PARENTID__COLUMN_NAME];
            _RowID = (int)row[ROWID__COLUMN_NAME];
            _Rows[0] = row[R01__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R01__COLUMN_NAME]);
            _Rows[1] = row[R02__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R02__COLUMN_NAME]);
            _Rows[2] = row[R03__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R03__COLUMN_NAME]);
            _Rows[3] = row[R04__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R04__COLUMN_NAME]);
            _Rows[4] = row[R05__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R05__COLUMN_NAME]);
            _Rows[5] = row[R06__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R06__COLUMN_NAME]);
            _Rows[6] = row[R07__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R07__COLUMN_NAME]);
            _Rows[7] = row[R08__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R08__COLUMN_NAME]);
            _Rows[8] = row[R09__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R09__COLUMN_NAME]);
            _Rows[9] = row[R10__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R10__COLUMN_NAME]);
            _Rows[10] = row[R11__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R11__COLUMN_NAME]);
            _Rows[11] = row[R12__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R12__COLUMN_NAME]);
            _Rows[12] = row[R13__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R13__COLUMN_NAME]);
            _Rows[13] = row[R14__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R14__COLUMN_NAME]);
            _Rows[14] = row[R15__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R15__COLUMN_NAME]);
            _Rows[15] = row[R16__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R16__COLUMN_NAME]);
            _Rows[16] = row[R17__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R17__COLUMN_NAME]);
            _Rows[17] = row[R18__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R18__COLUMN_NAME]);
            _Rows[18] = row[R19__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R19__COLUMN_NAME]);
            _Rows[19] = row[R20__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R20__COLUMN_NAME]);
            _Rows[20] = row[R21__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R21__COLUMN_NAME]);
            _Rows[21] = row[R22__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R22__COLUMN_NAME]);
            _Rows[22] = row[R23__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R23__COLUMN_NAME]);
            _Rows[23] = row[R24__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R24__COLUMN_NAME]);
            _Rows[24] = row[R25__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R25__COLUMN_NAME]);
            _Rows[25] = row[R26__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R26__COLUMN_NAME]);
            _Rows[26] = row[R27__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R27__COLUMN_NAME]);
            _Rows[27] = row[R28__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R28__COLUMN_NAME]);
            _Rows[28] = row[R29__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R29__COLUMN_NAME]);
            _Rows[29] = row[R30__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R30__COLUMN_NAME]);
            _Rows[30] = row[R31__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R31__COLUMN_NAME]);
            _Rows[31] = row[R32__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R32__COLUMN_NAME]);
            _Rows[32] = row[R33__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R33__COLUMN_NAME]);
            _Rows[33] = row[R34__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R34__COLUMN_NAME]);
            _Rows[34] = row[R35__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R35__COLUMN_NAME]);
            _Rows[35] = row[R36__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R36__COLUMN_NAME]);
            _Rows[36] = row[R37__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R37__COLUMN_NAME]);
            _Rows[37] = row[R38__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R38__COLUMN_NAME]);
            _Rows[38] = row[R39__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R39__COLUMN_NAME]);
            _Rows[39] = row[R40__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R40__COLUMN_NAME]);
            _Rows[40] = row[R41__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R41__COLUMN_NAME]);
            _Rows[41] = row[R42__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R42__COLUMN_NAME]);
            _Rows[42] = row[R43__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R43__COLUMN_NAME]);
            _Rows[43] = row[R44__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[R44__COLUMN_NAME]);
        }

        #region Insert/Update/Delete
        protected int Insert(string TableName)
        {
            ParameterCollection coll = new ParameterCollection();
            coll.Add(new Parameter(PARENTID__COLUMN_NAME, _ParentID));
            coll.Add(new Parameter(ROWID__COLUMN_NAME, _RowID));
            coll.Add(new Parameter(R01__COLUMN_NAME, _Rows[0]));
            coll.Add(new Parameter(R02__COLUMN_NAME, _Rows[1]));
            coll.Add(new Parameter(R03__COLUMN_NAME, _Rows[2]));
            coll.Add(new Parameter(R04__COLUMN_NAME, _Rows[3]));
            coll.Add(new Parameter(R05__COLUMN_NAME, _Rows[4]));
            coll.Add(new Parameter(R06__COLUMN_NAME, _Rows[5]));
            coll.Add(new Parameter(R07__COLUMN_NAME, _Rows[6]));
            coll.Add(new Parameter(R08__COLUMN_NAME, _Rows[7]));
            coll.Add(new Parameter(R09__COLUMN_NAME, _Rows[8]));
            coll.Add(new Parameter(R10__COLUMN_NAME, _Rows[9]));
            coll.Add(new Parameter(R11__COLUMN_NAME, _Rows[10]));
            coll.Add(new Parameter(R12__COLUMN_NAME, _Rows[11]));
            coll.Add(new Parameter(R13__COLUMN_NAME, _Rows[12]));
            coll.Add(new Parameter(R14__COLUMN_NAME, _Rows[13]));
            coll.Add(new Parameter(R15__COLUMN_NAME, _Rows[14]));
            coll.Add(new Parameter(R16__COLUMN_NAME, _Rows[15]));
            coll.Add(new Parameter(R17__COLUMN_NAME, _Rows[16]));
            coll.Add(new Parameter(R18__COLUMN_NAME, _Rows[17]));
            coll.Add(new Parameter(R19__COLUMN_NAME, _Rows[18]));
            coll.Add(new Parameter(R20__COLUMN_NAME, _Rows[19]));
            coll.Add(new Parameter(R21__COLUMN_NAME, _Rows[20]));
            coll.Add(new Parameter(R22__COLUMN_NAME, _Rows[21]));
            coll.Add(new Parameter(R23__COLUMN_NAME, _Rows[22]));
            coll.Add(new Parameter(R24__COLUMN_NAME, _Rows[23]));
            coll.Add(new Parameter(R25__COLUMN_NAME, _Rows[24]));
            coll.Add(new Parameter(R26__COLUMN_NAME, _Rows[25]));
            coll.Add(new Parameter(R27__COLUMN_NAME, _Rows[26]));
            coll.Add(new Parameter(R28__COLUMN_NAME, _Rows[27]));
            coll.Add(new Parameter(R29__COLUMN_NAME, _Rows[28]));
            coll.Add(new Parameter(R30__COLUMN_NAME, _Rows[29]));
            coll.Add(new Parameter(R31__COLUMN_NAME, _Rows[30]));
            coll.Add(new Parameter(R32__COLUMN_NAME, _Rows[31]));
            coll.Add(new Parameter(R33__COLUMN_NAME, _Rows[32]));
            coll.Add(new Parameter(R34__COLUMN_NAME, _Rows[33]));
            coll.Add(new Parameter(R35__COLUMN_NAME, _Rows[34]));
            coll.Add(new Parameter(R36__COLUMN_NAME, _Rows[35]));
            coll.Add(new Parameter(R37__COLUMN_NAME, _Rows[36]));
            coll.Add(new Parameter(R38__COLUMN_NAME, _Rows[37]));
            coll.Add(new Parameter(R39__COLUMN_NAME, _Rows[38]));
            coll.Add(new Parameter(R40__COLUMN_NAME, _Rows[39]));
            coll.Add(new Parameter(R41__COLUMN_NAME, _Rows[40]));
            coll.Add(new Parameter(R42__COLUMN_NAME, _Rows[41]));
            coll.Add(new Parameter(R43__COLUMN_NAME, _Rows[42]));
            coll.Add(new Parameter(R44__COLUMN_NAME, _Rows[43]));

            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                return _DBAccessor.Insert(TableName, coll);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!this.db_Set)
                {
                    _DBAccessor.Dispose();
                }
            }
        }

        protected int Update(string TableName)
        {
            ParameterCollection coll = new ParameterCollection();
            coll.Add(new Parameter(R01__COLUMN_NAME, _Rows[0]));
            coll.Add(new Parameter(R02__COLUMN_NAME, _Rows[1]));
            coll.Add(new Parameter(R03__COLUMN_NAME, _Rows[2]));
            coll.Add(new Parameter(R04__COLUMN_NAME, _Rows[3]));
            coll.Add(new Parameter(R05__COLUMN_NAME, _Rows[4]));
            coll.Add(new Parameter(R06__COLUMN_NAME, _Rows[5]));
            coll.Add(new Parameter(R07__COLUMN_NAME, _Rows[6]));
            coll.Add(new Parameter(R08__COLUMN_NAME, _Rows[7]));
            coll.Add(new Parameter(R09__COLUMN_NAME, _Rows[8]));
            coll.Add(new Parameter(R10__COLUMN_NAME, _Rows[9]));
            coll.Add(new Parameter(R11__COLUMN_NAME, _Rows[10]));
            coll.Add(new Parameter(R12__COLUMN_NAME, _Rows[11]));
            coll.Add(new Parameter(R13__COLUMN_NAME, _Rows[12]));
            coll.Add(new Parameter(R14__COLUMN_NAME, _Rows[13]));
            coll.Add(new Parameter(R15__COLUMN_NAME, _Rows[14]));
            coll.Add(new Parameter(R16__COLUMN_NAME, _Rows[15]));
            coll.Add(new Parameter(R17__COLUMN_NAME, _Rows[16]));
            coll.Add(new Parameter(R18__COLUMN_NAME, _Rows[17]));
            coll.Add(new Parameter(R19__COLUMN_NAME, _Rows[18]));
            coll.Add(new Parameter(R20__COLUMN_NAME, _Rows[19]));
            coll.Add(new Parameter(R21__COLUMN_NAME, _Rows[20]));
            coll.Add(new Parameter(R22__COLUMN_NAME, _Rows[21]));
            coll.Add(new Parameter(R23__COLUMN_NAME, _Rows[22]));
            coll.Add(new Parameter(R24__COLUMN_NAME, _Rows[23]));
            coll.Add(new Parameter(R25__COLUMN_NAME, _Rows[24]));
            coll.Add(new Parameter(R26__COLUMN_NAME, _Rows[25]));
            coll.Add(new Parameter(R27__COLUMN_NAME, _Rows[26]));
            coll.Add(new Parameter(R28__COLUMN_NAME, _Rows[27]));
            coll.Add(new Parameter(R29__COLUMN_NAME, _Rows[28]));
            coll.Add(new Parameter(R30__COLUMN_NAME, _Rows[29]));
            coll.Add(new Parameter(R31__COLUMN_NAME, _Rows[30]));
            coll.Add(new Parameter(R32__COLUMN_NAME, _Rows[31]));
            coll.Add(new Parameter(R33__COLUMN_NAME, _Rows[32]));
            coll.Add(new Parameter(R34__COLUMN_NAME, _Rows[33]));
            coll.Add(new Parameter(R35__COLUMN_NAME, _Rows[34]));
            coll.Add(new Parameter(R36__COLUMN_NAME, _Rows[35]));
            coll.Add(new Parameter(R37__COLUMN_NAME, _Rows[36]));
            coll.Add(new Parameter(R38__COLUMN_NAME, _Rows[37]));
            coll.Add(new Parameter(R39__COLUMN_NAME, _Rows[38]));
            coll.Add(new Parameter(R40__COLUMN_NAME, _Rows[39]));
            coll.Add(new Parameter(R41__COLUMN_NAME, _Rows[40]));
            coll.Add(new Parameter(R42__COLUMN_NAME, _Rows[41]));
            coll.Add(new Parameter(R43__COLUMN_NAME, _Rows[42]));
            coll.Add(new Parameter(R44__COLUMN_NAME, _Rows[43]));

            WhereParameterCollection whereColl = new WhereParameterCollection();
            whereColl.Add(new WhereParameter(PARENTID__COLUMN_NAME, _ParentID, CompareType.Equal));
            whereColl.Add(ROWID__COLUMN_NAME, _RowID, CompareType.Equal);

            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                return _DBAccessor.Update(TableName, coll, whereColl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!this.db_Set)
                {
                    _DBAccessor.Dispose();
                }
            }
        }

        protected int Delete(string TableName)
        {
            WhereParameterCollection whereColl = new WhereParameterCollection();
            whereColl.Add(new WhereParameter(PARENTID__COLUMN_NAME, _ParentID, CompareType.Equal));
            whereColl.Add(ROWID__COLUMN_NAME, _RowID, CompareType.Equal);

            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                return _DBAccessor.Delete(TableName, whereColl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!this.db_Set)
                {
                    _DBAccessor.Dispose();
                }
            }
        }
        #endregion
    }
}
