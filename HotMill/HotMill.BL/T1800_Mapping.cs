using System;
using System.Data;

namespace Kvics.HotMill.BL
{
    public class T1800_Mapping
    {
        public static readonly string MASTER_TABLE = "T1800";

        public static readonly string[] RowsName = new string[] { 
            "各スタンド出側温度", 
            "出側板厚", 
            "ロール速度", 
            "圧延荷重", 
            "モータ電力", 
            "圧下位置_Si", 
            "ＷＲシフト量", 
            "シフト位置_ＨＣδ", 
            "ベンダー力", 
            "スタンド間張力", 
            "ＨＣクラウン", 
            "ＷＲサーマルプロフィール_1", 
            "ＷＲサーマルプロフィール_2", 
            "ＷＲサーマルプロフィール_3", 
            "ＷＲサーマルプロフィール_4", 
            "ＷＲサーマルプロフィール_5", 
            "ＷＲサーマルプロフィール_6", 
            "ＷＲサーマルプロフィール_7", 
            "ＷＲ摩耗プロフィール_1", 
            "ＷＲ摩耗プロフィール_2", 
            "ＷＲ摩耗プロフィール_3", 
            "ＷＲ摩耗プロフィール_4", 
            "ＷＲ摩耗プロフィール_5", 
            "ＷＲ摩耗プロフィール_6", 
            "ＷＲ摩耗プロフィール_7",
            // HSS 4
            "噛み込み/尻抜け時刻",
            // End HSS 4
            // HSS 5
            "Extend_02"
            // End HSS 5
        };
        public static string R0075 { get { return RowsName[0]; } }
        public static string R0097 { get { return RowsName[1]; } }
        public static string R0125 { get { return RowsName[2]; } }
        public static string R0139 { get { return RowsName[3]; } }
        public static string R0167 { get { return RowsName[4]; } }
        public static string R0195 { get { return RowsName[5]; } }
        public static string R0223 { get { return RowsName[6]; } }
        public static string R0237 { get { return RowsName[7]; } }
        public static string R0251 { get { return RowsName[8]; } }
        public static string R0279 { get { return RowsName[9]; } }
        public static string R0291 { get { return RowsName[10]; } }
        public static string R0401 { get { return RowsName[11]; } }
        public static string R0491 { get { return RowsName[12]; } }
        public static string R0581 { get { return RowsName[13]; } }
        public static string R0671 { get { return RowsName[14]; } }
        public static string R0761 { get { return RowsName[15]; } }
        public static string R0851 { get { return RowsName[16]; } }
        public static string R0941 { get { return RowsName[17]; } }
        public static string R1031 { get { return RowsName[18]; } }
        public static string R1121 { get { return RowsName[19]; } }
        public static string R1211 { get { return RowsName[20]; } }
        public static string R1301 { get { return RowsName[21]; } }
        public static string R1391 { get { return RowsName[22]; } }
        public static string R1481 { get { return RowsName[23]; } }
        public static string R1571 { get { return RowsName[24]; } }
        // HSS 4
        public static string R1661 { get { return RowsName[25]; } }
        // End HSS 4
        // HSS 5
        public static string R1749 { get { return RowsName[26]; } }
        // End HSS 4
        
        protected static NameObjectCollection _RowsColl = null;

        public static int GetRowID(string RowName)
        {
            if (_RowsColl == null)
            {
                TMapping tMapping = new TMapping();
                DataSet ds = tMapping.GetAllByMasterTable(MASTER_TABLE);
                _RowsColl = new NameObjectCollection();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    _RowsColl.Add(row[TMapping.NAME__COLUMN_NAME].ToString(), (int)row[TMapping.ROWID__COLUMN_NAME]);
                }
            }

            object obj = _RowsColl[RowName];
            return (int)obj;
        }

        public static void ReloadMapping()
        {
            _RowsColl = null;
        }
    }
}
