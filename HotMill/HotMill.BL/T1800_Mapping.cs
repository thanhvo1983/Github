using System;
using System.Data;

namespace Kvics.HotMill.BL
{
    public class T1800_Mapping
    {
        public static readonly string MASTER_TABLE = "T1800";

        public static readonly string[] RowsName = new string[] { 
            "�e�X�^���h�o�����x", 
            "�o����", 
            "���[�����x", 
            "�����׏d", 
            "���[�^�d��", 
            "�����ʒu_Si", 
            "�v�q�V�t�g��", 
            "�V�t�g�ʒu_�g�b��", 
            "�x���_�[��", 
            "�X�^���h�Ԓ���", 
            "�g�b�N���E��", 
            "�v�q�T�[�}���v���t�B�[��_1", 
            "�v�q�T�[�}���v���t�B�[��_2", 
            "�v�q�T�[�}���v���t�B�[��_3", 
            "�v�q�T�[�}���v���t�B�[��_4", 
            "�v�q�T�[�}���v���t�B�[��_5", 
            "�v�q�T�[�}���v���t�B�[��_6", 
            "�v�q�T�[�}���v���t�B�[��_7", 
            "�v�q���Ճv���t�B�[��_1", 
            "�v�q���Ճv���t�B�[��_2", 
            "�v�q���Ճv���t�B�[��_3", 
            "�v�q���Ճv���t�B�[��_4", 
            "�v�q���Ճv���t�B�[��_5", 
            "�v�q���Ճv���t�B�[��_6", 
            "�v�q���Ճv���t�B�[��_7",
            // HSS 4
            "���ݍ���/�K��������",
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
