using System;
using System.Data;
using System.Collections.Specialized;

namespace Kvics.HotMill.BL
{
    public class T800_Mapping
    {
        public static readonly string MASTER_TABLE = "T800";

        //public static readonly string[] RowsName = new string[] { "ＨＣ厚_当材_当材_9本目", "ＨＣ幅_当材_当材_9本目", "オフセット_OFFSETi", "シフト位置_ＨＣδ", "スタンド間張力", "ベンダー力", "ロール速度", "ワークロールシフト量_1", "ワークロールシフト量_10", "ワークロールシフト量_2", "ワークロールシフト量_3", "ワークロールシフト量_4", "ワークロールシフト量_5", "ワークロールシフト量_6", "ワークロールシフト量_7", "ワークロールシフト量_8", "ワークロールシフト量_9", "ワークロールシフト量_SWR", "圧延トルク比_%", "圧延荷重", "圧延荷重のロードセル補正_fL", "圧延荷重の歪み速度補正_ｆdot", "圧下位置_Si", "圧下位置学習係数_SCOR", "各スタンド出側温度", "各スタンド入側温度", "残留歪み_ε1", "残留歪み率_λ", "出側板厚", "先進率", "熱間強度_当材_当材_9本目", "板速度", "変形抵抗_σm", "変形抵抗の鋼種補正項_f鋼種", "変形抵抗の変態補正項_f", "摩擦係数_μ", "目標クラウン_計算値", "目標圧下位置差_ΔdSi", "目標圧下位置差介入量_ΔdSgi" };
        public static readonly string[] RowsName = new string[] { 
            "各スタンド入側温度", 
            "各スタンド出側温度", 
            "出側板厚", 
            "先進率", 
            "ロール速度", 
            "板速度", 
            "圧延荷重", 
            "圧延荷重のロードセル補正_fL", 
            "圧延荷重の歪み速度補正_ｆdot", 
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
            "シフト位置_ＨＣδ", 
            "ベンダー力", 
            "スタンド間張力", 
            "ＨＣ幅_当材_当材_9本目", 
            "ＨＣ厚_当材_当材_9本目", 
            "熱間強度_当材_当材_9本目", 
            "ワークロールシフト量_1", 
            "ワークロールシフト量_2", 
            "ワークロールシフト量_3", 
            "ワークロールシフト量_4", 
            "ワークロールシフト量_5", 
            "ワークロールシフト量_6", 
            "ワークロールシフト量_7", 
            "ワークロールシフト量_8", 
            "ワークロールシフト量_9", 
            "ワークロールシフト量_10", 
            "目標クラウン_計算値", 
            "シフト位置_ＨＣδ_1", 
            "シフト位置_ＨＣδ_2", 
            "シフト位置_ＨＣδ_3", 
            "シフト位置_ＨＣδ_4", 
            "シフト位置_ＨＣδ_5", 
            "シフト位置_ＨＣδ_6", 
            "シフト位置_ＨＣδ_7", 
            "シフト位置_ＨＣδ_8", 
            "シフト位置_ＨＣδ_9", 
            "シフト位置_ＨＣδ_10",
            // HSS 4
            "ｺｲﾙ長さ",
            "後段シフト方法",
            // end HSS 4
            // HSS5
            "Extend_02"
            // end HSS5
        };
        public static string R083 { get { return RowsName[0]; } }
        public static string R097 { get { return RowsName[1]; } }
        public static string R121 { get { return RowsName[2]; } }
        public static string R135 { get { return RowsName[3]; } }
        public static string R149 { get { return RowsName[4]; } }
        public static string R165 { get { return RowsName[5]; } }
        public static string R179 { get { return RowsName[6]; } }
        public static string R193 { get { return RowsName[7]; } }
        public static string R207 { get { return RowsName[8]; } }
        public static string R221 { get { return RowsName[9]; } }
        public static string R235 { get { return RowsName[10]; } }
        public static string R249 { get { return RowsName[11]; } }
        public static string R263 { get { return RowsName[12]; } }
        public static string R277 { get { return RowsName[13]; } }
        public static string R291 { get { return RowsName[14]; } }
        public static string R305 { get { return RowsName[15]; } }
        public static string R319 { get { return RowsName[16]; } }
        public static string R331 { get { return RowsName[17]; } }
        public static string R343 { get { return RowsName[18]; } }
        public static string R357 { get { return RowsName[19]; } }
        public static string R371 { get { return RowsName[20]; } }
        public static string R385 { get { return RowsName[21]; } }
        public static string R399 { get { return RowsName[22]; } }
        public static string R413 { get { return RowsName[23]; } }
        public static string R427 { get { return RowsName[24]; } }
        public static string R501 { get { return RowsName[25]; } }
        public static string R521 { get { return RowsName[26]; } }
        public static string R541 { get { return RowsName[27]; } }
        public static string R561 { get { return RowsName[28]; } }
        public static string R575 { get { return RowsName[29]; } }
        public static string R589 { get { return RowsName[30]; } }
        public static string R603 { get { return RowsName[31]; } }
        public static string R617 { get { return RowsName[32]; } }
        public static string R631 { get { return RowsName[33]; } }
        public static string R645 { get { return RowsName[34]; } }
        public static string R659 { get { return RowsName[35]; } }
        public static string R673 { get { return RowsName[36]; } }
        public static string R687 { get { return RowsName[37]; } }

        public static string R701 { get { return RowsName[39]; } }
        public static string R715 { get { return RowsName[40]; } }
        public static string R729 { get { return RowsName[41]; } }
        public static string R743 { get { return RowsName[42]; } }
        public static string R757 { get { return RowsName[43]; } }
        public static string R771 { get { return RowsName[44]; } }
        public static string R785 { get { return RowsName[45]; } }
        public static string R799 { get { return RowsName[46]; } }
        public static string R813 { get { return RowsName[47]; } }
        public static string R827 { get { return RowsName[48]; } }

        public static string R843 { get { return RowsName[38]; } }

        // HSS 4
        public static string R481 { get { return RowsName[49]; } }
        public static string R857 { get { return RowsName[50]; } }
        // end HSS 4
        // HSS5
        public static string R451 { get { return RowsName[51]; } }
        // end HSS5
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
            T800_Extend_01_Mapping.ReloadMapping();
        }
    }
}
