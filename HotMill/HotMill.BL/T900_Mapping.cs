using System;
using System.Data;

namespace Kvics.HotMill.BL
{
    public class T900_Mapping
    {
        public static readonly string MASTER_TABLE = "T900";

        //public static readonly string[] RowsName = new string[] { "atqa", "atqÔ", "vqNEÊ", "vqe[p[³", "vqe[p[·³", "vqa", "vqíÞ", "vqÔ", "ItZbg_OFFSETi", "XN[lë__S0i", "x_[Í", "~LÑ®W_JP1", "~LÑ®W_JP2", "[¬x", "[N[VtgÊ_SWR", "³gNä_%", "³×d", "³×dÌ[hZâ³_k", "³×dÌcÝ¬xâ³_Ãdot", "³ºÊu_Si", "³ºÊuwKW_SCOR", "»w¬ª", "eX^ho¤·x", "eX^hü¤·x", "c¯cÝ_Ã1", "c¯cÝ¦_É", "o¤Âú", "æi¦", "Â¬x", "Ï`ïR_Ðm", "Ï`ïRÌ|íâ³_f|í", "Ï`ïRÌÏÔâ³_f", "CW_Ê", "ÚW³ºÊu·_¢dSi", "ÚW³ºÊu·îüÊ_¢dSgi" };
        public static readonly string[] RowsName = new string[] { 
            "»w¬ª", 
            "eX^hü¤·x", 
            "eX^ho¤·x", 
            "o¤Âú", 
            "æi¦", 
            "[¬x", 
            "Â¬x", 
            "³×d", 
            "³×dÌ[hZâ³_k", 
            "³×dÌcÝ¬xâ³_Ãdot", 
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
            "x_[Í", 
            "vqÔ", 
            "vqíÞ", 
            "vqa", 
            "vqNEÊ", 
            "vqe[p[³", 
            "vqe[p[·³", 
            "atqÔ", 
            "atqa", 
            "~LÑ®W_JP1", 
            "~LÑ®W_JP2", 
            "XN[lë__S0i" };

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
