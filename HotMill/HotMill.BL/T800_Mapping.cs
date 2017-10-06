using System;
using System.Data;
using System.Collections.Specialized;

namespace Kvics.HotMill.BL
{
    public class T800_Mapping
    {
        public static readonly string MASTER_TABLE = "T800";

        //public static readonly string[] RowsName = new string[] { "�g�b��_����_����_9�{��", "�g�b��_����_����_9�{��", "�I�t�Z�b�g_OFFSETi", "�V�t�g�ʒu_�g�b��", "�X�^���h�Ԓ���", "�x���_�[��", "���[�����x", "���[�N���[���V�t�g��_1", "���[�N���[���V�t�g��_10", "���[�N���[���V�t�g��_2", "���[�N���[���V�t�g��_3", "���[�N���[���V�t�g��_4", "���[�N���[���V�t�g��_5", "���[�N���[���V�t�g��_6", "���[�N���[���V�t�g��_7", "���[�N���[���V�t�g��_8", "���[�N���[���V�t�g��_9", "���[�N���[���V�t�g��_SWR", "�����g���N��_%", "�����׏d", "�����׏d�̃��[�h�Z���␳_fL", "�����׏d�̘c�ݑ��x�␳_��dot", "�����ʒu_Si", "�����ʒu�w�K�W��_SCOR", "�e�X�^���h�o�����x", "�e�X�^���h�������x", "�c���c��_��1", "�c���c�ݗ�_��", "�o����", "��i��", "�M�ԋ��x_����_����_9�{��", "���x", "�ό`��R_��m", "�ό`��R�̍|��␳��_f�|��", "�ό`��R�̕ϑԕ␳��_f", "���C�W��_��", "�ڕW�N���E��_�v�Z�l", "�ڕW�����ʒu��_��dSi", "�ڕW�����ʒu�������_��dSgi" };
        public static readonly string[] RowsName = new string[] { 
            "�e�X�^���h�������x", 
            "�e�X�^���h�o�����x", 
            "�o����", 
            "��i��", 
            "���[�����x", 
            "���x", 
            "�����׏d", 
            "�����׏d�̃��[�h�Z���␳_fL", 
            "�����׏d�̘c�ݑ��x�␳_��dot", 
            "�ό`��R_��m", 
            "�ό`��R�̍|��␳��_f�|��", 
            "�ό`��R�̕ϑԕ␳��_f", 
            "�c���c��_��1", 
            "�c���c�ݗ�_��", 
            "���C�W��_��", 
            "�����g���N��_%", 
            "�ڕW�����ʒu��_��dSi", 
            "�ڕW�����ʒu�������_��dSgi", 
            "�����ʒu_Si", 
            "�I�t�Z�b�g_OFFSETi", 
            "�����ʒu�w�K�W��_SCOR", 
            "���[�N���[���V�t�g��_SWR", 
            "�V�t�g�ʒu_�g�b��", 
            "�x���_�[��", 
            "�X�^���h�Ԓ���", 
            "�g�b��_����_����_9�{��", 
            "�g�b��_����_����_9�{��", 
            "�M�ԋ��x_����_����_9�{��", 
            "���[�N���[���V�t�g��_1", 
            "���[�N���[���V�t�g��_2", 
            "���[�N���[���V�t�g��_3", 
            "���[�N���[���V�t�g��_4", 
            "���[�N���[���V�t�g��_5", 
            "���[�N���[���V�t�g��_6", 
            "���[�N���[���V�t�g��_7", 
            "���[�N���[���V�t�g��_8", 
            "���[�N���[���V�t�g��_9", 
            "���[�N���[���V�t�g��_10", 
            "�ڕW�N���E��_�v�Z�l", 
            "�V�t�g�ʒu_�g�b��_1", 
            "�V�t�g�ʒu_�g�b��_2", 
            "�V�t�g�ʒu_�g�b��_3", 
            "�V�t�g�ʒu_�g�b��_4", 
            "�V�t�g�ʒu_�g�b��_5", 
            "�V�t�g�ʒu_�g�b��_6", 
            "�V�t�g�ʒu_�g�b��_7", 
            "�V�t�g�ʒu_�g�b��_8", 
            "�V�t�g�ʒu_�g�b��_9", 
            "�V�t�g�ʒu_�g�b��_10",
            // HSS 4
            "��ْ���",
            "��i�V�t�g���@",
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
