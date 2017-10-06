using System;
using System.Data;

namespace Kvics.HotMill.BL
{
    public class T900_Mapping
    {
        public static readonly string MASTER_TABLE = "T900";

        //public static readonly string[] RowsName = new string[] { "ＢＵＲ径", "ＢＵＲ番号", "ＷＲクラウン量", "ＷＲテーパー高さ", "ＷＲテーパー長さ", "ＷＲ径", "ＷＲ種類", "ＷＲ番号", "オフセット_OFFSETi", "スクリュー値零点_S0i", "ベンダー力", "ミル伸び式係数_JP1", "ミル伸び式係数_JP2", "ロール速度", "ワークロールシフト量_SWR", "圧延トルク比_%", "圧延荷重", "圧延荷重のロードセル補正_ｆＬ", "圧延荷重の歪み速度補正_ｆεdot", "圧下位置_Si", "圧下位置学習係数_SCOR", "化学成分", "各スタンド出側温度", "各スタンド入側温度", "残留歪み_ε1", "残留歪み率_λ", "出側板厚", "先進率", "板速度", "変形抵抗_σm", "変形抵抗の鋼種補正項_f鋼種", "変形抵抗の変態補正項_f", "摩擦係数_μ", "目標圧下位置差_ΔdSi", "目標圧下位置差介入量_ΔdSgi" };
        public static readonly string[] RowsName = new string[] { 
            "化学成分", 
            "各スタンド入側温度", 
            "各スタンド出側温度", 
            "出側板厚", 
            "先進率", 
            "ロール速度", 
            "板速度", 
            "圧延荷重", 
            "圧延荷重のロードセル補正_ｆＬ", 
            "圧延荷重の歪み速度補正_ｆεdot", 
            "変形抵抗_σm", 
            "変形抵抗の鋼種補正項_f鋼種", 
            "変形抵抗の変態補正項_f", 
            "残留歪み_ε1", 
            "残留歪み率_λ", 
            "摩擦係数_μ", 
            "圧延トルク比_%", 
            "目標圧下位置差_ΔdSi", 
            "目標圧下位置差介入量_ΔdSgi", 
            "圧下位置_Si", 
            "オフセット_OFFSETi", 
            "圧下位置学習係数_SCOR", 
            "ワークロールシフト量_SWR", 
            "ベンダー力", 
            "ＷＲ番号", 
            "ＷＲ種類", 
            "ＷＲ径", 
            "ＷＲクラウン量", 
            "ＷＲテーパー高さ", 
            "ＷＲテーパー長さ", 
            "ＢＵＲ番号", 
            "ＢＵＲ径", 
            "ミル伸び式係数_JP1", 
            "ミル伸び式係数_JP2", 
            "スクリュー値零点_S0i" };

        public static string R081 { get { return RowsName[0]; } }
        public static string R131 { get { return RowsName[1]; } }
        public static string R145 { get { return RowsName[2]; } }
        public static string R169 { get { return RowsName[3]; } }
        public static string R183 { get { return RowsName[4]; } }
        public static string R197 { get { return RowsName[5]; } }
        public static string R213 { get { return RowsName[6]; } }
        public static string R227 { get { return RowsName[7]; } }
        public static string R241 { get { return RowsName[8]; } }
        public static string R255 { get { return RowsName[9]; } }
        public static string R269 { get { return RowsName[10]; } }
        public static string R283 { get { return RowsName[11]; } }
        public static string R297 { get { return RowsName[12]; } }
        public static string R311 { get { return RowsName[13]; } }
        public static string R325 { get { return RowsName[14]; } }
        public static string R339 { get { return RowsName[15]; } }
        public static string R353 { get { return RowsName[16]; } }
        public static string R367 { get { return RowsName[17]; } }
        public static string R379 { get { return RowsName[18]; } }
        public static string R391 { get { return RowsName[19]; } }
        public static string R405 { get { return RowsName[20]; } }
        public static string R419 { get { return RowsName[21]; } }
        public static string R433 { get { return RowsName[22]; } }
        public static string R447 { get { return RowsName[23]; } }
        public static string R501 { get { return RowsName[24]; } }
        public static string R543 { get { return RowsName[25]; } }
        public static string R557 { get { return RowsName[26]; } }
        public static string R585 { get { return RowsName[27]; } }
        public static string R599 { get { return RowsName[28]; } }
        public static string R613 { get { return RowsName[29]; } }
        public static string R627 { get { return RowsName[30]; } }
        public static string R713 { get { return RowsName[31]; } }
        public static string R801 { get { return RowsName[32]; } }
        public static string R815 { get { return RowsName[33]; } }
        public static string R851 { get { return RowsName[34]; } }

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
