using System;
using System.Data;
using System.Collections.Specialized;

namespace Kvics.HotMill.BL
{
    public class T800_Extend_01_Mapping
    {
        public static readonly string MASTER_TABLE = "T800_Extend_01";

        public static readonly string[] RowsName = new string[] { 
            "ﾃｰﾊﾟ圧延指定ｺｰﾄﾞ", 
            "ｸﾗｳﾝ指令MAX", 
            "ｸﾗｳﾝ指令MIN", 
            "後段ｼﾌﾄﾋﾟｯﾁ", 
            "前段シフト方法_F1", 
            "前段シフト方法_F2", 
            "前段シフト方法_F3"
        };
        public static string R873 { get { return RowsName[0]; } }
        public static string R893 { get { return RowsName[1]; } }
        public static string R913 { get { return RowsName[2]; } }
        public static string R947 { get { return RowsName[3]; } }
        public static string R967 { get { return RowsName[4]; } }
        public static string R975 { get { return RowsName[5]; } }
        public static string R983 { get { return RowsName[6]; } }

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
