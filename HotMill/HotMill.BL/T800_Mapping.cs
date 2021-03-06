using System;
using System.Data;
using System.Collections.Specialized;

namespace Kvics.HotMill.BL
{
    public class T800_Mapping
    {
        public static readonly string MASTER_TABLE = "T800";

        //public static readonly string[] RowsName = new string[] { "gbú_Þ_Þ_9{Ú", "gb_Þ_Þ_9{Ú", "ItZbg_OFFSETi", "VtgÊu_gbÂ", "X^hÔ£Í", "x_[Í", "[¬x", "[N[VtgÊ_1", "[N[VtgÊ_10", "[N[VtgÊ_2", "[N[VtgÊ_3", "[N[VtgÊ_4", "[N[VtgÊ_5", "[N[VtgÊ_6", "[N[VtgÊ_7", "[N[VtgÊ_8", "[N[VtgÊ_9", "[N[VtgÊ_SWR", "³gNä_%", "³×d", "³×dÌ[hZâ³_fL", "³×dÌcÝ¬xâ³_dot", "³ºÊu_Si", "³ºÊuwKW_SCOR", "eX^ho¤·x", "eX^hü¤·x", "c¯cÝ_Ã1", "c¯cÝ¦_É", "o¤Âú", "æi¦", "MÔ­x_Þ_Þ_9{Ú", "Â¬x", "Ï`ïR_Ðm", "Ï`ïRÌ|íâ³_f|í", "Ï`ïRÌÏÔâ³_f", "CW_Ê", "ÚWNE_vZl", "ÚW³ºÊu·_¢dSi", "ÚW³ºÊu·îüÊ_¢dSgi" };
        public static readonly string[] RowsName = new string[] { 
            "eX^hü¤·x", 
            "eX^ho¤·x", 
            "o¤Âú", 
            "æi¦", 
            "[¬x", 
            "Â¬x", 
            "³×d", 
            "³×dÌ[hZâ³_fL", 
            "³×dÌcÝ¬xâ³_dot", 
            "Ï`ïR_Ðm", 
            "Ï`ïRÌ|íâ³_f|í", 
            "Ï`ïRÌÏÔâ³_f", 
            "c¯cÝ_Ã1", 
            "c¯cÝ¦_É", 
            "CW_Ê", 
            "³gNä_%", 
            "ÚW³ºÊu·_¢dSi", 
            "ÚW³ºÊu·îüÊ_¢dSgi", 
            "³ºÊu_Si", 
            "ItZbg_OFFSETi", 
            "³ºÊuwKW_SCOR", 
            "[N[VtgÊ_SWR", 
            "VtgÊu_gbÂ", 
            "x_[Í", 
            "X^hÔ£Í", 
            "gb_Þ_Þ_9{Ú", 
            "gbú_Þ_Þ_9{Ú", 
            "MÔ­x_Þ_Þ_9{Ú", 
            "[N[VtgÊ_1", 
            "[N[VtgÊ_2", 
            "[N[VtgÊ_3", 
            "[N[VtgÊ_4", 
            "[N[VtgÊ_5", 
            "[N[VtgÊ_6", 
            "[N[VtgÊ_7", 
            "[N[VtgÊ_8", 
            "[N[VtgÊ_9", 
            "[N[VtgÊ_10", 
            "ÚWNE_vZl", 
            "VtgÊu_gbÂ_1", 
            "VtgÊu_gbÂ_2", 
            "VtgÊu_gbÂ_3", 
            "VtgÊu_gbÂ_4", 
            "VtgÊu_gbÂ_5", 
            "VtgÊu_gbÂ_6", 
            "VtgÊu_gbÂ_7", 
            "VtgÊu_gbÂ_8", 
            "VtgÊu_gbÂ_9", 
            "VtgÊu_gbÂ_10",
            // HSS 4
            "º²Ù·³",
            "ãiVtgû@",
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
