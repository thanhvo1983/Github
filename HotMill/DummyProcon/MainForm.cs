using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Kvics.HotMill.BL;

namespace DummyProcon
{
    public partial class MainForm : Form
    {
        #region Static
        private static int maxValue = 50;
        //private static string stringValue = "";
        #endregion

        T800 t800Last = null;
        T900 t900Last = null;
        T1800 t1800Last = null;
        FormDatabaseConfig frmDatabaseConfig = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void StartDriver()
        {
            Kvics.Communication.DriverAdapter.StartDriver();
            txtStatus.Text = "ドライバーは起動されました。" + System.Environment.NewLine + txtStatus.Text;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            StartDriver();
        }

        private void StopDriver()
        {
            Kvics.Communication.DriverAdapter.StopDriver();
            txtStatus.Text = "ドライバーはストップしました。" + System.Environment.NewLine + txtStatus.Text;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopDriver();
        }

        private void btn800_Click(object sender, EventArgs e)
        {
            try
            {
                T800 t800 = Get_T800();
                if (chkSameCoilNo800.Checked && t800Last != null)
                {
                    t800.R025 = t800Last.R025;
                }
                Byte[] data = t800.GetBytes();
                bool sendingState = Kvics.Communication.DriverAdapter.SendData(1, data);
                txtStatus.Text = "仕上設定計算情報の送信は" + (sendingState ? "成功です。" : "失敗です。") + "コイルNo：" + t800.R025 + System.Environment.NewLine + txtStatus.Text;
                t800Last = t800;
            }
            catch (Exception)
            {
                ShowError(HotMillErrorType.DATABASE_ERROR);
            }
        }

        private void btn900_Click(object sender, EventArgs e)
        {
            try
            {
                T900 t900 = Get_T900();
                if (chkSameCoilNo900.Checked && t900Last != null)
                {
                    t900.R025 = t900Last.R025;
                }
                Byte[] data = t900.GetBytes();
                //System.IO.File.WriteAllBytes(@"C:\data_Worker1_" + data.Length.ToString() + "_" + DateTime.Now.ToLongTimeString().Replace(":", "_") + "_" + System.DateTime.Now.Millisecond.ToString() + ".dat", data);
                bool sendingState = Kvics.Communication.DriverAdapter.SendData(1, data);
                txtStatus.Text = "仕上予備計算情報の送信は" + (sendingState ? "成功です。" : "失敗です。") + "コイルNo：" + t900.R025 + System.Environment.NewLine + txtStatus.Text;

                t900Last = t900;
            }
            catch (Exception)
            {
                ShowError(HotMillErrorType.DATABASE_ERROR);
            }
        }

        private void btn1800_Click(object sender, EventArgs e)
        {
            try
            {
                T1800 t1800 = Get_T1800();
                if (chkSameCoilNo1800.Checked && t1800Last != null)
                {
                    t1800.R0025 = t1800Last.R0025;
                }
                Byte[] data = t1800.GetBytes();
                bool sendingState = Kvics.Communication.DriverAdapter.SendData(1, data);
                txtStatus.Text = "仕上学習計算情報の送信は" + (sendingState ? "成功です。" : "失敗です。") + "コイルNo：" + t1800.R0025 + System.Environment.NewLine + txtStatus.Text;
                t1800Last = t1800;
            }
            catch (Exception)
            {
                ShowError(HotMillErrorType.DATABASE_ERROR);
            }
        }

        private T800 Get_T800()
        {
            Random ran = new Random();

            T800 t800 = new T800();

            t800.R025 = "A" + Common.GetString(Common.GetString(ran.Next(99999).ToString(), 0, 5, '0', 1), 0, 7, ' ', 2);
            t800.R033 = 2007;
            t800.R035 = (Int16)(ran.Next(11) + 1);
            t800.R037 = (Int16)(ran.Next(30) + 1);
            t800.R039 = (Int16)ran.Next(maxValue);
            t800.R041 = "A ";
            t800.R043_1 = "CD5678901 ";
            t800.R053 = "334567";
            t800.R059 = (Int16)ran.Next(maxValue);
            t800.R061 = (Int16)ran.Next(maxValue);
            t800.R063 = (Int16)ran.Next(maxValue);
            int[] r065Values = new int[] { 0, 5, 6, 7 };
            t800.R065 = (Int16)r065Values[ran.Next(4)];
            t800.R067 = (Int16)ran.Next(6);
            t800.R069 = (Int16)ran.Next(2);
            t800.R071 = (Int16)ran.Next(maxValue);
            t800.R073 = "A3C456F0";
            t800.R073_1 = (Int16)ran.Next(maxValue);
            t800.R075 = (Int16)ran.Next(maxValue);
            t800.R077 = (Int16)ran.Next(maxValue);
            t800.R079 = (Int16)ran.Next(maxValue);
            t800.R081 = (Int16)(ran.Next(2) + 1);
            t800.R081_1 = (Int16)ran.Next(maxValue);            
            t800.R111 = (Int16)ran.Next(maxValue);
            t800.R113 = (Int16)ran.Next(maxValue);
            t800.R115 = (Int16)ran.Next(maxValue);
            t800.R117 = (Int16)(ran.Next(3) + 1);
            t800.R119 = (Int16)(ran.Next(17) + 1);
            t800.R163 = (Int16)ran.Next(maxValue);
            
            t800.R083 = Get_T800_I2_07(T800_Mapping.GetRowID(T800_Mapping.R083), ran);
            t800.R097 = Get_T800_I2_07(T800_Mapping.GetRowID(T800_Mapping.R097), ran);
            t800.R121 = Get_T800_I2_07(T800_Mapping.GetRowID(T800_Mapping.R121), ran);
            t800.R135 = Get_T800_I2_07(T800_Mapping.GetRowID(T800_Mapping.R135), ran);
            t800.R149 = Get_T800_I2_07(T800_Mapping.GetRowID(T800_Mapping.R149), ran);
            t800.R165 = Get_T800_I2_07(T800_Mapping.GetRowID(T800_Mapping.R165), ran);
            t800.R179 = Get_T800_I2_07(T800_Mapping.GetRowID(T800_Mapping.R179), ran);
            t800.R193 = Get_T800_I2_07(T800_Mapping.GetRowID(T800_Mapping.R193), ran);
            t800.R207 = Get_T800_I2_07(T800_Mapping.GetRowID(T800_Mapping.R207), ran);
            t800.R221 = Get_T800_I2_07(T800_Mapping.GetRowID(T800_Mapping.R221), ran);
            t800.R235 = Get_T800_I2_07(T800_Mapping.GetRowID(T800_Mapping.R235), ran);
            t800.R249 = Get_T800_I2_07(T800_Mapping.GetRowID(T800_Mapping.R249), ran);
            t800.R263 = Get_T800_I2_07(T800_Mapping.GetRowID(T800_Mapping.R263), ran);
            t800.R277 = Get_T800_I2_07(T800_Mapping.GetRowID(T800_Mapping.R277), ran);
            t800.R291 = Get_T800_I2_07(T800_Mapping.GetRowID(T800_Mapping.R291), ran);
            t800.R305 = Get_T800_I2_07(T800_Mapping.GetRowID(T800_Mapping.R305), ran);
            t800.R319 = Get_T800_I2_06(T800_Mapping.GetRowID(T800_Mapping.R319), ran);
            t800.R331 = Get_T800_I2_06(T800_Mapping.GetRowID(T800_Mapping.R331), ran);
            t800.R343 = Get_T800_I2_07(T800_Mapping.GetRowID(T800_Mapping.R343), ran);
            t800.R357 = Get_T800_I2_07(T800_Mapping.GetRowID(T800_Mapping.R357), ran);
            t800.R371 = Get_T800_I2_07(T800_Mapping.GetRowID(T800_Mapping.R371), ran);
            t800.R385 = Get_T800_I2_07(T800_Mapping.GetRowID(T800_Mapping.R385), ran);
            t800.R399 = Get_T800_I2_07(T800_Mapping.GetRowID(T800_Mapping.R399), ran);
            t800.R413 = Get_T800_I2_07(T800_Mapping.GetRowID(T800_Mapping.R413), ran);
            t800.R427 = Get_T800_I2_06(T800_Mapping.GetRowID(T800_Mapping.R427), ran);
            t800.R501 = Get_T800_I2_10(T800_Mapping.GetRowID(T800_Mapping.R501), ran);
            t800.R521 = Get_T800_I2_10(T800_Mapping.GetRowID(T800_Mapping.R521), ran);
            t800.R541 = Get_T800_I2_10(T800_Mapping.GetRowID(T800_Mapping.R541), ran);
            t800.R561 = Get_T800_I2_07_10(T800_Mapping.GetRowID(T800_Mapping.R561), ran);
            t800.R575 = Get_T800_I2_07_10(T800_Mapping.GetRowID(T800_Mapping.R575), ran);
            t800.R589 = Get_T800_I2_07_10(T800_Mapping.GetRowID(T800_Mapping.R589), ran);
            t800.R603 = Get_T800_I2_07_10(T800_Mapping.GetRowID(T800_Mapping.R603), ran);
            t800.R617 = Get_T800_I2_07_10(T800_Mapping.GetRowID(T800_Mapping.R617), ran);
            t800.R631 = Get_T800_I2_07_10(T800_Mapping.GetRowID(T800_Mapping.R631), ran);
            t800.R645 = Get_T800_I2_07_10(T800_Mapping.GetRowID(T800_Mapping.R645), ran);
            t800.R659 = Get_T800_I2_07_10(T800_Mapping.GetRowID(T800_Mapping.R659), ran);
            t800.R673 = Get_T800_I2_07_10(T800_Mapping.GetRowID(T800_Mapping.R673), ran);
            t800.R687 = Get_T800_I2_07_10(T800_Mapping.GetRowID(T800_Mapping.R687), ran);
            t800.R701_1 = (Int16)ran.Next(maxValue);
            t800.R703 = Get_T800_I2_07(T800_Mapping.GetRowID(T800_Mapping.R843), ran);
            
            return t800;
        }

        private T800_I2_06 Get_T800_I2_06(int rowID, Random ran)
        {
            
            T800_I2_06 t800_I2_06 = new T800_I2_06();
            t800_I2_06.RowID = rowID;
            for (int i = 0; i < t800_I2_06.Rows.Length; i++)
            {
                t800_I2_06.Rows[i] = (Int16)ran.Next(maxValue);
            }
            return t800_I2_06;
        }
        private T800_I2_07 Get_T800_I2_07(int rowID, Random ran)
        {
            
            T800_I2_07 t800_I2_07 = new T800_I2_07();
            t800_I2_07.RowID = rowID;
            for (int i = 0; i < t800_I2_07.Rows.Length; i++)
            {
                t800_I2_07.Rows[i] = (Int16)ran.Next(maxValue);
            }
            return t800_I2_07;
        }
        private T800_I2_10 Get_T800_I2_10(int rowID, Random ran)
        {
            
            T800_I2_10 t800_I2_10 = new T800_I2_10();
            t800_I2_10.RowID = rowID;
            for (int i = 0; i < t800_I2_10.Rows.Length; i++)
            {
                t800_I2_10.Rows[i] = (Int16)ran.Next(maxValue);
            }
            return t800_I2_10;
        }
        private T800_I2_07_10 Get_T800_I2_07_10(int rowID, Random ran)
        {
            
            T800_I2_07_10 t800_I2_07_10 = new T800_I2_07_10();
            t800_I2_07_10.RowID = rowID;
            for (int i = 0; i < t800_I2_07_10.Rows.Length; i++)
            {
                t800_I2_07_10.Rows[i] = (Int16)ran.Next(maxValue);
            }
            return t800_I2_07_10;
        }

        private T900 Get_T900()
        {
            Random ran = new Random();

            T900 t900 = new T900();

            t900.R025 = "A" + Common.GetString(Common.GetString(ran.Next(99999).ToString(), 0, 5, '0', 1), 0, 7, ' ', 2);
            t900.R033 = 2007;
            t900.R035 = (Int16)(ran.Next(11) + 1);
            t900.R037 = (Int16)(ran.Next(30) + 1);
            t900.R039 = (Int16)ran.Next(maxValue);
            t900.R041 = "A ";
            t900.R043 = (Int16)ran.Next(maxValue);
            t900.R043_1 = "CD5678901 ";
            t900.R053 = "334567";
            t900.R059 = (Int16)ran.Next(maxValue);
            t900.R061 = (Int16)ran.Next(maxValue);
            t900.R063 = (Int16)ran.Next(maxValue);
            int[] r065Values = new int[] { 0, 5, 6, 7 };
            t900.R065 = (Int16)r065Values[ran.Next(4)];
            t900.R067 = (Int16)ran.Next(6);
            t900.R069 = (Int16)ran.Next(2);
            t900.R071 = "ZY9876X ";
            t900.R079 = (Int16)(ran.Next(2) + 1);
            t900.R081 = Get_T900_I2_19(T900_Mapping.GetRowID(T900_Mapping.R081), ran);
            t900.R119 = (Int16)ran.Next(maxValue);
            t900.R121 = (Int16)ran.Next(maxValue);
            t900.R123 = (Int16)ran.Next(maxValue);
            t900.R125 = (Int16)ran.Next(maxValue);
            t900.R127 = (Int16)ran.Next(maxValue);
            t900.R129 = (Int16)ran.Next(maxValue);
            t900.R131 = Get_T900_I2_07(T900_Mapping.GetRowID(T900_Mapping.R131), ran);
            t900.R145 = Get_T900_I2_07(T900_Mapping.GetRowID(T900_Mapping.R145), ran);
            t900.R159 = (Int16)ran.Next(maxValue);
            t900.R161 = (Int16)ran.Next(maxValue);
            t900.R163 = (Int16)ran.Next(maxValue);
            t900.R165 = (Int16)(ran.Next(3) + 1);
            t900.R167 = (Int16)(ran.Next(17) + 1);            
            t900.R169 = Get_T900_I2_07(T900_Mapping.GetRowID(T900_Mapping.R169), ran);
            t900.R183 = Get_T900_I2_07(T900_Mapping.GetRowID(T900_Mapping.R183), ran);
            t900.R197 = Get_T900_I2_07(T900_Mapping.GetRowID(T900_Mapping.R197), ran);
            t900.R211 = (Int16)ran.Next(maxValue);
            t900.R213 = Get_T900_I2_07(T900_Mapping.GetRowID(T900_Mapping.R213), ran);
            t900.R227 = Get_T900_I2_07(T900_Mapping.GetRowID(T900_Mapping.R227), ran);
            t900.R241 = Get_T900_I2_07(T900_Mapping.GetRowID(T900_Mapping.R241), ran);
            t900.R255 = Get_T900_I2_07(T900_Mapping.GetRowID(T900_Mapping.R255), ran);
            t900.R269 = Get_T900_I2_07(T900_Mapping.GetRowID(T900_Mapping.R269), ran);
            t900.R283 = Get_T900_I2_07(T900_Mapping.GetRowID(T900_Mapping.R283), ran);
            t900.R297 = Get_T900_I2_07(T900_Mapping.GetRowID(T900_Mapping.R297), ran);
            t900.R311 = Get_T900_I2_07(T900_Mapping.GetRowID(T900_Mapping.R311), ran);
            t900.R325 = Get_T900_I2_07(T900_Mapping.GetRowID(T900_Mapping.R325), ran);
            t900.R339 = Get_T900_I2_07(T900_Mapping.GetRowID(T900_Mapping.R339), ran);
            t900.R353 = Get_T900_I2_07(T900_Mapping.GetRowID(T900_Mapping.R353), ran);
            t900.R367 = Get_T900_I2_06(T900_Mapping.GetRowID(T900_Mapping.R367), ran);
            t900.R379 = Get_T900_I2_06(T900_Mapping.GetRowID(T900_Mapping.R379), ran);
            t900.R391 = Get_T900_I2_07(T900_Mapping.GetRowID(T900_Mapping.R391), ran);
            t900.R405 = Get_T900_I2_07(T900_Mapping.GetRowID(T900_Mapping.R405), ran);
            t900.R419 = Get_T900_I2_07(T900_Mapping.GetRowID(T900_Mapping.R419), ran);
            t900.R433 = Get_T900_I2_07(T900_Mapping.GetRowID(T900_Mapping.R433), ran);
            t900.R447 = Get_T900_I2_07(T900_Mapping.GetRowID(T900_Mapping.R447), ran);
            t900.R501 = Get_T900_C6_07(T900_Mapping.GetRowID(T900_Mapping.R501), ran);
            t900.R543 = Get_T900_C2_07(T900_Mapping.GetRowID(T900_Mapping.R543), ran);
            t900.R557 = Get_T900_I4_07(T900_Mapping.GetRowID(T900_Mapping.R557), ran);
            t900.R585 = Get_T900_I2_07(T900_Mapping.GetRowID(T900_Mapping.R585), ran);
            t900.R599 = Get_T900_I2_07(T900_Mapping.GetRowID(T900_Mapping.R599), ran);
            t900.R613 = Get_T900_I2_07(T900_Mapping.GetRowID(T900_Mapping.R613), ran);
            t900.R627 = Get_T900_C6_14(T900_Mapping.GetRowID(T900_Mapping.R627), ran);
            t900.R713 = Get_T900_I4_14(T900_Mapping.GetRowID(T900_Mapping.R713), ran);
            t900.R801 = Get_T900_I2_07(T900_Mapping.GetRowID(T900_Mapping.R801), ran);
            t900.R815 = Get_T900_I2_07(T900_Mapping.GetRowID(T900_Mapping.R815), ran);
            t900.R851 = Get_T900_I2_07(T900_Mapping.GetRowID(T900_Mapping.R851), ran);
            return t900;
        }

        private T900_I2_06 Get_T900_I2_06(int rowID, Random ran)
        {
            
            T900_I2_06 t900_I2_06 = new T900_I2_06();
            t900_I2_06.RowID = rowID;
            for (int i = 0; i < t900_I2_06.Rows.Length; i++)
            {
                t900_I2_06.Rows[i] = (Int16)ran.Next(maxValue);
            }
            return t900_I2_06;
        }
        private T900_I2_07 Get_T900_I2_07(int rowID, Random ran)
        {
            
            T900_I2_07 t900_I2_07 = new T900_I2_07();
            t900_I2_07.RowID = rowID;
            for (int i = 0; i < t900_I2_07.Rows.Length; i++)
            {
                t900_I2_07.Rows[i] = (Int16)ran.Next(maxValue);
            }
            return t900_I2_07;
        }
        private T900_I2_19 Get_T900_I2_19(int rowID, Random ran)
        {
            
            T900_I2_19 t900_I2_19 = new T900_I2_19();
            t900_I2_19.RowID = rowID;
            for (int i = 0; i < t900_I2_19.Rows.Length; i++)
            {
                t900_I2_19.Rows[i] = (Int16)ran.Next(maxValue);
            }
            return t900_I2_19;
        }
        private T900_C2_07 Get_T900_C2_07(int rowID, Random ran)
        {
            
            T900_C2_07 t900_C2_07 = new T900_C2_07();
            t900_C2_07.RowID = rowID;
            for (int i = 0; i < t900_C2_07.Rows.Length; i++)
            {
                t900_C2_07.Rows[i] = "0" + (ran.Next(9)+1).ToString();
            }
            return t900_C2_07;
        }
        private T900_C6_07 Get_T900_C6_07(int rowID, Random ran)
        {
            
            T900_C6_07 t900_C6_07 = new T900_C6_07();
            t900_C6_07.RowID = rowID;
            for (int i = 0; i < t900_C6_07.Rows.Length; i++)
            {
                t900_C6_07.Rows[i] = Common.GetString(ran.Next(999999).ToString(), 0, 6, ' ', 2);
            }
            return t900_C6_07;
        }
        private T900_C6_14 Get_T900_C6_14(int rowID, Random ran)
        {
            
            T900_C6_14 t900_C6_14 = new T900_C6_14();
            t900_C6_14.RowID = rowID;
            for (int i = 0; i < t900_C6_14.Rows.Length; i++)
            {
                t900_C6_14.Rows[i] = Common.GetString(ran.Next(999999).ToString(), 0, 6, ' ', 2);
            }
            return t900_C6_14;
        }
        private T900_I4_07 Get_T900_I4_07(int rowID, Random ran)
        {
            
            T900_I4_07 t900_I4_07 = new T900_I4_07();
            t900_I4_07.RowID = rowID;
            for (int i = 0; i < t900_I4_07.Rows.Length; i++)
            {
                t900_I4_07.Rows[i] = ran.Next(Int32.MaxValue);
            }
            return t900_I4_07;
        }
        private T900_I4_14 Get_T900_I4_14(int rowID, Random ran)
        {
            
            T900_I4_14 t900_I4_14 = new T900_I4_14();
            t900_I4_14.RowID = rowID;
            for (int i = 0; i < t900_I4_14.Rows.Length; i++)
            {
                t900_I4_14.Rows[i] = ran.Next(Int32.MaxValue);
            }
            return t900_I4_14;
        }

        private T1800 Get_T1800()
        {
            Random ran = new Random();

            T1800 t1800 = new T1800();

            t1800.R0025 = "A" + Common.GetString(Common.GetString(ran.Next(99999).ToString(), 0, 5, '0', 1), 0, 7, ' ', 2);
            t1800.R0033 = 2007;
            t1800.R0035 = (Int16)(ran.Next(11) + 1);
            t1800.R0037 = (Int16)(ran.Next(30) + 1);
            t1800.R0039 = (Int16)ran.Next(maxValue);
            t1800.R0041 = "A ";
            t1800.R0043 = (Int16)ran.Next(maxValue);
            t1800.R0043_1 = "CD5678901 ";
            t1800.R0053 = "334567";
            t1800.R0059 = (Int16)ran.Next(maxValue);
            t1800.R0061 = (Int16)ran.Next(maxValue);
            t1800.R0063 = (Int16)ran.Next(maxValue);
            int[] r0065Values = new int[] {0, 5, 6, 7};
            t1800.R0065 = (Int16)r0065Values[ran.Next(4)];
            t1800.R0067 = (Int16)ran.Next(6);
            t1800.R0069 = (Int16)ran.Next(2);
            t1800.R0071 = (Int16)ran.Next(maxValue);
            t1800.R0073 = "A3C456F0";
            t1800.R0073_1 = (Int16)ran.Next(maxValue);            

            t1800.R0075 = Get_T1800_I2_07(T1800_Mapping.GetRowID(T1800_Mapping.R0075), ran);
            t1800.R0081 = (Int16)(ran.Next(2)+1);
            t1800.R0089 = (Int16)ran.Next(maxValue);
            t1800.R0091 = (Int16)ran.Next(maxValue);
            t1800.R0093 = (Int16)(ran.Next(3) + 1);
            t1800.R0095 = (Int16)(ran.Next(17) + 1);
            t1800.R0097 = Get_T1800_I2_14(T1800_Mapping.GetRowID(T1800_Mapping.R0097), ran);            
            t1800.R0125 = Get_T1800_I2_07(T1800_Mapping.GetRowID(T1800_Mapping.R0125), ran);
            t1800.R0139 = Get_T1800_I2_14(T1800_Mapping.GetRowID(T1800_Mapping.R0139), ran);
            t1800.R0167 = Get_T1800_I2_14(T1800_Mapping.GetRowID(T1800_Mapping.R0167), ran);
            t1800.R0195 = Get_T1800_I2_14(T1800_Mapping.GetRowID(T1800_Mapping.R0195), ran);
            t1800.R0223 = Get_T1800_I2_07(T1800_Mapping.GetRowID(T1800_Mapping.R0223), ran);
            t1800.R0237 = Get_T1800_I2_07(T1800_Mapping.GetRowID(T1800_Mapping.R0237), ran);
            t1800.R0251 = Get_T1800_I2_14(T1800_Mapping.GetRowID(T1800_Mapping.R0251), ran);
            t1800.R0279 = Get_T1800_I2_06(T1800_Mapping.GetRowID(T1800_Mapping.R0279), ran);
            //t1800.R0291 = Get_T1800_I2_06_1(T1800_Mapping.GetRowID(T1800_Mapping.R0291), ran);
            t1800.R0401 = Get_T1800_I2_45(T1800_Mapping.GetRowID(T1800_Mapping.R0401), ran);
            t1800.R0491 = Get_T1800_I2_45(T1800_Mapping.GetRowID(T1800_Mapping.R0491), ran);
            t1800.R0581 = Get_T1800_I2_45(T1800_Mapping.GetRowID(T1800_Mapping.R0581), ran);
            t1800.R0671 = Get_T1800_I2_45(T1800_Mapping.GetRowID(T1800_Mapping.R0671), ran);
            t1800.R0761 = Get_T1800_I2_45(T1800_Mapping.GetRowID(T1800_Mapping.R0761), ran);
            t1800.R0851 = Get_T1800_I2_45(T1800_Mapping.GetRowID(T1800_Mapping.R0851), ran);
            t1800.R0941 = Get_T1800_I2_45(T1800_Mapping.GetRowID(T1800_Mapping.R0941), ran);
            t1800.R1031 = Get_T1800_I2_45(T1800_Mapping.GetRowID(T1800_Mapping.R1031), ran);
            t1800.R1121 = Get_T1800_I2_45(T1800_Mapping.GetRowID(T1800_Mapping.R1121), ran);
            t1800.R1211 = Get_T1800_I2_45(T1800_Mapping.GetRowID(T1800_Mapping.R1211), ran);
            t1800.R1301 = Get_T1800_I2_45(T1800_Mapping.GetRowID(T1800_Mapping.R1301), ran);
            t1800.R1391 = Get_T1800_I2_45(T1800_Mapping.GetRowID(T1800_Mapping.R1391), ran);
            t1800.R1481 = Get_T1800_I2_45(T1800_Mapping.GetRowID(T1800_Mapping.R1481), ran);
            t1800.R1571 = Get_T1800_I2_45(T1800_Mapping.GetRowID(T1800_Mapping.R1571), ran);
            
            return t1800;
        }
        private T1800_I2_06 Get_T1800_I2_06(int rowID, Random ran)
        {
            
            T1800_I2_06 t1800_I2_06 = new T1800_I2_06();
            t1800_I2_06.RowID = rowID;
            for (int i = 0; i < t1800_I2_06.Rows.Length; i++)
            {
                t1800_I2_06.Rows[i] = (Int16)ran.Next(maxValue);
            }
            return t1800_I2_06;
        }
        private T1800_I2_06_1 Get_T1800_I2_06_1(int rowID, Random ran)
        {

            T1800_I2_06_1 t1800_I2_06_1 = new T1800_I2_06_1();
            t1800_I2_06_1.RowID = rowID;
            for (int i = 0; i < t1800_I2_06_1.Rows.Length; i++)
            {
                t1800_I2_06_1.Rows[i] = (Int16)ran.Next(maxValue);
            }
            return t1800_I2_06_1;
        }
        private T1800_I2_07 Get_T1800_I2_07(int rowID, Random ran)
        {
            
            T1800_I2_07 t1800_I2_07 = new T1800_I2_07();
            t1800_I2_07.RowID = rowID;
            for (int i = 0; i < t1800_I2_07.Rows.Length; i++)
            {
                t1800_I2_07.Rows[i] = (Int16)ran.Next(maxValue);
            }
            return t1800_I2_07;
        }
        private T1800_I2_14 Get_T1800_I2_14(int rowID, Random ran)
        {
            
            T1800_I2_14 t1800_I2_14 = new T1800_I2_14();
            t1800_I2_14.RowID = rowID;
            for (int i = 0; i < t1800_I2_14.Rows.Length; i++)
            {
                t1800_I2_14.Rows[i] = (Int16)ran.Next(maxValue);
            }
            return t1800_I2_14;
        }
        private T1800_I2_45 Get_T1800_I2_45(int rowID, Random ran)
        {
            
            T1800_I2_45 t1800_I2_45 = new T1800_I2_45();
            t1800_I2_45.RowID = rowID;
            for (int i = 0; i < t1800_I2_45.Rows.Length; i++)
            {
                t1800_I2_45.Rows[i] = (Int16)ran.Next(maxValue);
            }
            return t1800_I2_45;
        }

        private bool CheckData()
        {
            try
            {
                TMapping tMapping = new TMapping();
                DataSet ds = tMapping.GetAll();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        private void btnDatabaseConfig_Click(object sender, EventArgs e)
        {
            string currentConnectionString = Kvics.DBAccess.DBAccessor.DefaultConnectionString;

            if (frmDatabaseConfig == null)
            {
                frmDatabaseConfig = new FormDatabaseConfig();
            }

            frmDatabaseConfig.HotMillDatabaseConnectionString = Kvics.DBAccess.DBAccessor.DefaultConnectionString;
            while (frmDatabaseConfig.ShowDialog(this) == DialogResult.OK)
            {
                Kvics.DBAccess.DBAccessor.DefaultConnectionString = frmDatabaseConfig.HotMillDatabaseConnectionString;
                if (CheckData())
                {
                    FormDatabaseConfig.ApplyConnectionString(frmDatabaseConfig.HotMillDatabaseConnectionString);
                    return;
                }
                else
                {
                    ShowError(HotMillErrorType.DATABASE_ERROR);
                }
            }
            Kvics.DBAccess.DBAccessor.DefaultConnectionString = null;
        }
        public static void ShowError(HotMillErrorType errorType)
        {
            switch (errorType)
            {
                case HotMillErrorType.DATABASE_ERROR:
                    MessageBox.Show("データベースに接続出来ません。若しくはデータベースは異常です。データベース又はデータベース構成を確認して下さい。");
                    break;
                case HotMillErrorType.UNKNOWN_ERROR:
                    MessageBox.Show("データベースよりデータを取得している内にエラーが発生しました。管理者にこのエラーを連絡して下さい。");
                    break;
                default:
                    break;
            }
        }
    }
    public enum HotMillErrorType
    {
        DATABASE_ERROR,
        UNKNOWN_ERROR
    }
}