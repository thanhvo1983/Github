using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Kvics.HotMill.BL;
using Kvics.Utility;

namespace DummyProcon
{
    public partial class Data4HSS5Form : Form
    {
        FormDatabaseConfig frmDatabaseConfigHSS4 = null;
        FormDatabaseConfig frmDatabaseConfigHSS5 = null;
        String _HSS4ConnectionString = Kvics.DBAccess.DBAccessor.DefaultConnectionString;
        String _HSS5ConnectionString = "Data Source=ntthao;Initial Catalog=hss5;Persist Security Info=true;User ID=sa;Password=pass123";
        ParseTestingForm frmParseTesting = null;

        public Data4HSS5Form()
        {
            InitializeComponent();
        }

        #region Util
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

        private byte[] GetBytes(string value)
        {
            int discarded = 0;
            byte[] bytes = HexEncoding.GetBytes(value, out discarded);

            return bytes;
        }
        #endregion

        private void Data4HSS5Form_Load(object sender, EventArgs e)
        {
            lblT900_Status.Text = "";
            lblT800_Status.Text = "";
            lblT1800_Status.Text = "";
            lblT200_Status.Text = "";
            lblGamen_Status.Text = "";

            frmDatabaseConfigHSS4 = new FormDatabaseConfig();
            frmDatabaseConfigHSS4.HotMillDatabaseConnectionString = Kvics.DBAccess.DBAccessor.DefaultConnectionString;
        }

        #region Util handler
        private void btnParser_Click(object sender, EventArgs e)
        {
            if (frmParseTesting == null || frmParseTesting.IsDisposed)
            {
                frmParseTesting = new ParseTestingForm();
            }

            frmParseTesting.WindowState = FormWindowState.Normal;
            frmParseTesting.Show();
            frmParseTesting.Focus();
        }

        private void btnDatabaseConfig_Click(object sender, EventArgs e)
        {
            string currentConnectionString = Kvics.DBAccess.DBAccessor.DefaultConnectionString;

            if (frmDatabaseConfigHSS4 == null || frmDatabaseConfigHSS4.IsDisposed)
            {
                frmDatabaseConfigHSS4 = new FormDatabaseConfig();
                frmDatabaseConfigHSS4.HotMillDatabaseConnectionString = Kvics.DBAccess.DBAccessor.DefaultConnectionString;
            }

            while (frmDatabaseConfigHSS4.ShowDialog(this) == DialogResult.OK)
            {
                Kvics.DBAccess.DBAccessor.DefaultConnectionString = frmDatabaseConfigHSS4.HotMillDatabaseConnectionString;
                if (this.CheckData())
                {
                    _HSS4ConnectionString = frmDatabaseConfigHSS4.HotMillDatabaseConnectionString;
                    FormDatabaseConfig.ApplyConnectionString(frmDatabaseConfigHSS4.HotMillDatabaseConnectionString);
                    return;
                }
                else
                {
                    Data4HSS5Form.ShowError(HotMillErrorType.DATABASE_ERROR);
                }
            }
            Kvics.DBAccess.DBAccessor.DefaultConnectionString = null;
        }

        private void btnDatabaseConfigHSS5_Click(object sender, EventArgs e)
        {
            if (frmDatabaseConfigHSS5 == null || frmDatabaseConfigHSS5.IsDisposed)
            {
                frmDatabaseConfigHSS5 = new FormDatabaseConfig();
                frmDatabaseConfigHSS5.HotMillDatabaseConnectionString = _HSS5ConnectionString;
            }

            if (frmDatabaseConfigHSS5.ShowDialog(this) == DialogResult.OK)
            {
                this._HSS5ConnectionString = frmDatabaseConfigHSS5.HotMillDatabaseConnectionString;
            }
        }
        #endregion

        #region Get Data Handler
        private void btnT900_GetData_Click(object sender, EventArgs e)
        {
            try
            {
                lblT900_Status.ForeColor = Color.DarkOrange;
                lblT900_Status.Text = "";

                Kvics.DBAccess.DBAccessor.DefaultConnectionString = _HSS4ConnectionString;

                T900 t900 = T900.GetLast();

                if (t900 == null)
                {
                    throw new Exception("No data. Please connect to HSS4 database.");
                }
                byte[] data = t900.GetBytes();
                string strData = HexEncoding.ToString(data);
                txtT900_Data.Text = strData;
            }
            catch (Exception ex)
            {
                lblT900_Status.Text = "Error: " + ex.Message + System.Environment.NewLine + ex.StackTrace;
                lblT900_Status.ForeColor = Color.Red;
            }
        }

        private void btnT800_GetData_Click(object sender, EventArgs e)
        {
            try
            {
                lblT800_Status.ForeColor = Color.DarkOrange;
                lblT800_Status.Text = "";

                Kvics.DBAccess.DBAccessor.DefaultConnectionString = _HSS5ConnectionString;
                T800_Mapping.ReloadMapping();
                T800_Mapping.GetRowID(T800_Mapping.RowsName[0]);

                Kvics.DBAccess.DBAccessor.DefaultConnectionString = _HSS4ConnectionString;
                T800 t800 = T800.GetLast();

                if (t800 == null)
                {
                    throw new Exception("No data. Please connect to HSS4 database.");
                }

                t800.R451 = new T800_Extend_02();
                t800.R451.R451 = (short)1;
                t800.R451.R453 = (short)30;
                t800.R451.R455 = (short)40;
                t800.R451.R457 = (short)50;
                t800.R451.R459 = (short)60;
                t800.R451.R461 = (short)70;
                t800.R451.R463 = (short)80;
                t800.R451.R465 = (short)99;

                byte[] data = t800.GetBytes();
                string strData = HexEncoding.ToString(data);
                txtT800_Data.Text = strData;
            }
            catch (Exception ex)
            {
                lblT800_Status.Text = "Error: " + ex.Message + System.Environment.NewLine + ex.StackTrace;
                lblT800_Status.ForeColor = Color.Red;
            }
        }

        private void btnT1800_GetData_Click(object sender, EventArgs e)
        {
            try
            {
                lblT1800_Status.ForeColor = Color.DarkOrange;
                lblT1800_Status.Text = "";

                Kvics.DBAccess.DBAccessor.DefaultConnectionString = _HSS5ConnectionString;
                T1800_Mapping.ReloadMapping();
                T1800_Mapping.GetRowID(T1800_Mapping.RowsName[0]);

                Kvics.DBAccess.DBAccessor.DefaultConnectionString = _HSS4ConnectionString;
                T1800 t1800 = T1800.GetLast();

                if (t1800 == null)
                {
                    throw new Exception("No data. Please connect to HSS4 database.");
                }

                t1800.R1749 = new T1800_Extend_02();
                t1800.R1749.R1749 = (short)987;
                t1800.R1749.R1751 = "  ";
                t1800.R1749.R1753 = 12345;
                t1800.R1749.R1757 = 23456;
                t1800.R1749.R1761 = 1111111;
                t1800.R1749.R1765 = 2222222;
                t1800.R1749.R1769 = 3333333;
                t1800.R1749.R1773 = 4444444;
                t1800.R1749.R1777 = 5555555;
                t1800.R1749.R1781 = 6666666;
                t1800.R1749.R1785 = 7777777;

                byte[] data = t1800.GetBytes();
                string strData = HexEncoding.ToString(data);
                txtT1800_Data.Text = strData;
            }
            catch (Exception ex)
            {
                lblT1800_Status.Text = "Error: " + ex.Message + System.Environment.NewLine + ex.StackTrace;
                lblT1800_Status.ForeColor = Color.Red;
            }
        }

        private void btnT200_GetData_Click(object sender, EventArgs e)
        {
            try
            {
                lblT200_Status.ForeColor = Color.DarkOrange;
                lblT200_Status.Text = "";

                Kvics.DBAccess.DBAccessor.DefaultConnectionString = _HSS4ConnectionString;

                T900 t900 = T900.GetLast();
                if (t900 == null)
                {
                    throw new Exception("No data. Please connect to HSS4 database.");
                }

                T200 t200 = new T200();
                t200.R025 = t900.R025;
                t200.R033 = t900.R033;
                t200.R035 = t900.R035;
                t200.R037 = t900.R037;
                t200.R039 = t900.R039;
                t200.R041 = t900.R041;
                t200.R043 = t900.R043;
                t200.R045 = t900.R043_1;
                t200.R055 = t900.R053;
                t200.R061 = t900.R059;
                t200.R063 = t900.R061;
                t200.R065 = t900.R063;
                t200.R067 = t900.R065;
                t200.R069 = t900.R067;
                t200.R071 = t900.R069;
                t200.R073 = t900.R071;
                t200.R081 = t900.R079;
                t200.R083 = 321;
                t200.R085 = 321;
                t200.R087 = 654;
                t200.R089 = 987;
                t200.R091 = 109;
                t200.R093 = 687;
                t200.R095 = 354;
                t200.R097 = 9999;
                t200.R099 = 8888;
                t200.R101 = 7777;
                t200.R103 = 6666;
                t200.R105 = 5555;
                t200.R107 = 4444;
                t200.R109 = 3333;

                byte[] data = t200.GetBytes();
                string strData = HexEncoding.ToString(data);
                txtT200_Data.Text = strData;
            }
            catch (Exception ex)
            {
                lblT200_Status.Text = "Error: " + ex.Message + System.Environment.NewLine + ex.StackTrace;
                lblT200_Status.ForeColor = Color.Red;
            }
        }

        private void btnGamen_GetData_Click(object sender, EventArgs e)
        {
            try
            {
                lblGamen_Status.ForeColor = Color.DarkOrange;
                lblGamen_Status.Text = "";

                Kvics.DBAccess.DBAccessor.DefaultConnectionString = _HSS4ConnectionString;

                T1800 t1800 = T1800.GetLast();
                if (t1800 == null)
                {
                    throw new Exception("No data. Please connect to HSS4 database.");
                }

                Gamen gamen = new Gamen(t1800.ID, 3);

                if (gamen == null)
                {
                    throw new Exception("No data. Please connect to HSS4 database.");
                }

                string[] gamenValues = gamen.GetValuesInString();
                string[] gamenTemp = new string[Gamen.VALUE__COUNT];

                Array.Copy(gamenValues, gamenTemp, gamenValues.Length);

                #region HSS5 values
                string[] expandValues = new string[] {
                            "10",
                            "9",
                            "8",
                            "7",
                            "6",
                            "5",
                            "22",
                            "18",
                            "13",
                            "10",
                            "8",
                            "5",
                            "4",
                            "2500",
                            "2000",
                            "1500",
                            "1000",
                            "1000",
                            "500",
                            "300",
                            "9",
                            "8",
                            "7",
                            "6",
                            "5",
                            "4",
                            "150",
                            "140",
                            "130",
                            "120",
                            "110",
                            "100",
                            "90",
                            "155",
                            "145",
                            "135",
                            "125",
                            "115",
                            "105",
                            "95",
                            "100",
                            "121",
                            "152",
                            "113",
                            "84",
                            "145",
                            "196",
                            "120",
                            "80",
                            "110",
                            "90",
                            "142",
                            "110",
                            "123",
                            "95",
                            "154",
                            "100",
                            "105",
                            "75",
                            "96",
                            "85",
                            "120",
                            "60",
                            "140",
                            "98",
                            "190",
                            "100",
                            "170",
                            "80",
                            "200",
                            "40",
                            "130",
                            "55",
                            "160",
                            "100",
                            "91",
                            "92",
                            "93",
                            "94",
                            "95",
                            "96",
                            "97",
                            "81",
                            "82",
                            "83",
                            "84",
                            "85",
                            "86",
                            "87",
                            "71",
                            "72",
                            "73",
                            "74",
                            "75",
                            "76",
                            "77",
                            "50",
                            "51",
                            "52",
                            "40",
                            "41",
                            "42",
                            "092",
                            "096",
                            "091",
                            "338",
                            "297",
                            "302",
                            "300",
                            "206",
                            "213",
                            "212",
                            "30",
                            "20",
                            "-10",
                            "0",
                            "-10",
                            "-20",
                            "10",
                            "20",
                            "40",
                            "30",
                            "20",
                            "20",
                            "10",
                            "-20",
                            "-10",
                            "-20",
                            "-10",
                            "10",
                            "20",
                            "20"
                        };
                #endregion

                Array.Copy(expandValues, 0, gamenTemp, 784, expandValues.Length);

                StringBuilder strGamenValue = new StringBuilder();
                for (int i = 0; i < gamenTemp.Length; i++)
                {
                    if (i > 0)
                    {
                        strGamenValue.Append(Gamen.VALUES__SEPARATOR);
                    }
                    strGamenValue.Append(gamenTemp[i]);
                }

                txtGamen_Data.Text = strGamenValue.ToString();
            }
            catch (Exception ex)
            {
                lblGamen_Status.Text = "Error: " + ex.Message + System.Environment.NewLine + ex.StackTrace;
                lblGamen_Status.ForeColor = Color.Red;
            }
        }
        #endregion

        #region Insert handler
        private void btnT900_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                lblT900_Status.ForeColor = Color.DarkOrange;
                lblT900_Status.Text = "";

                byte[] bytes = GetBytes(txtT900_Data.Text.Trim());

                Kvics.DBAccess.DBAccessor.DefaultConnectionString = _HSS5ConnectionString;
                T900_Mapping.ReloadMapping();

                T900 t900 = T900.Parse(bytes);
                if (t900 == null)
                {
                    throw new Exception("Parse error. Data is invalid. ");
                }

                t900.Insert();

                lblT900_Status.Text = "Insert successful. CoilNo: " + t900.R025;
            }
            catch (Exception ex)
            {
                lblT900_Status.Text = "Error: " + ex.Message + System.Environment.NewLine + ex.StackTrace;
                lblT900_Status.ForeColor = Color.Red;
            }
        }

        private void btnT800_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                lblT800_Status.ForeColor = Color.DarkOrange;
                lblT800_Status.Text = "";

                byte[] bytes = GetBytes(txtT800_Data.Text.Trim());

                Kvics.DBAccess.DBAccessor.DefaultConnectionString = _HSS5ConnectionString;
                T800_Mapping.ReloadMapping();

                T800 t800 = T800.Parse(bytes);
                if (t800 == null)
                {
                    throw new Exception("Parse error. Data is invalid. ");
                }

                t800.Insert();

                lblT800_Status.Text = "Insert successful. CoilNo: " + t800.R025;
            }
            catch (Exception ex)
            {
                lblT800_Status.Text = "Error: " + ex.Message + System.Environment.NewLine + ex.StackTrace;
                lblT800_Status.ForeColor = Color.Red;
            }
        }

        private void btnT1800_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                lblT1800_Status.ForeColor = Color.DarkOrange;
                lblT1800_Status.Text = "";

                byte[] bytes = GetBytes(txtT1800_Data.Text.Trim());

                Kvics.DBAccess.DBAccessor.DefaultConnectionString = _HSS5ConnectionString;
                T1800_Mapping.ReloadMapping();

                T1800 t1800 = T1800.Parse(bytes);
                if (t1800 == null)
                {
                    throw new Exception("Parse error. Data is invalid. ");
                }

                t1800.Insert();

                lblT1800_Status.Text = "Insert successful. CoilNo: " + t1800.R0025;
            }
            catch (Exception ex)
            {
                lblT1800_Status.Text = "Error: " + ex.Message + System.Environment.NewLine + ex.StackTrace;
                lblT1800_Status.ForeColor = Color.Red;
            }
        }

        private void btnT200_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                lblT200_Status.ForeColor = Color.DarkOrange;
                lblT200_Status.Text = "";

                byte[] bytes = GetBytes(txtT200_Data.Text.Trim());

                Kvics.DBAccess.DBAccessor.DefaultConnectionString = _HSS5ConnectionString;

                T200 t200 = T200.Parse(bytes);
                if (t200 == null)
                {
                    throw new Exception("Parse error. Data is invalid. ");
                }

                t200.Insert();

                lblT200_Status.Text = "Insert successful. CoilNo: " + t200.R025;
            }
            catch (Exception ex)
            {
                lblT200_Status.Text = "Error: " + ex.Message + System.Environment.NewLine + ex.StackTrace;
                lblT200_Status.ForeColor = Color.Red;
            }
        }

        private void btnGamen_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                lblGamen_Status.ForeColor = Color.DarkOrange;
                lblGamen_Status.Text = "";

                if (txtGamen_Data.Text.Trim().Length < 1)
                {
                    throw new Exception("No data. Please connect to HSS4 database.");
                }

                // T900
                {
                    Kvics.DBAccess.DBAccessor.DefaultConnectionString = _HSS4ConnectionString;

                    T900 t900 = T900.GetLast();
                    if (t900 == null)
                    {
                        throw new Exception("No data. Please connect to HSS4 database.");
                    }

                    Kvics.DBAccess.DBAccessor.DefaultConnectionString = _HSS4ConnectionString;

                    Gamen gamen = new Gamen(t900.ID, 1);

                    if (gamen == null)
                    {
                        throw new Exception("No data. Please connect to HSS4 database.");
                    }
                    gamen.Values = txtGamen_Data.Text;

                    Kvics.DBAccess.DBAccessor.DefaultConnectionString = _HSS5ConnectionString;

                    t900 = T900.GetLast();
                    if (t900 == null)
                    {
                        throw new Exception("No data. Please insert data T900 first.");
                    }
                    gamen.MasterID = t900.ID;

                    gamen.Insert();
                }
                // End T900
                // T800
                {
                    Kvics.DBAccess.DBAccessor.DefaultConnectionString = _HSS4ConnectionString;

                    T800 t800 = T800.GetLast();
                    if (t800 == null)
                    {
                        throw new Exception("No data. Please connect to HSS4 database.");
                    }

                    Kvics.DBAccess.DBAccessor.DefaultConnectionString = _HSS4ConnectionString;

                    Gamen gamen = new Gamen(t800.ID, 2);

                    if (gamen == null)
                    {
                        throw new Exception("No data. Please connect to HSS4 database.");
                    }
                    gamen.Values = txtGamen_Data.Text;

                    Kvics.DBAccess.DBAccessor.DefaultConnectionString = _HSS5ConnectionString;
                    
                    t800 = T800.GetLast();
                    if (t800 == null)
                    {
                        throw new Exception("No data. Please insert data T800 first.");
                    }
                    gamen.MasterID = t800.ID;

                    gamen.Insert();
                }
                // End T800
                // T200
                {
                    Kvics.DBAccess.DBAccessor.DefaultConnectionString = _HSS5ConnectionString;
                    T200 t200 = T200.GetLast();
                    if (t200 == null)
                    {
                        throw new Exception("No data. Please insert T200 data.");
                    }
                    Gamen gamen = new Gamen();
                    gamen.MasterID = t200.ID;
                    gamen.MasterType = 4;
                    gamen.Values = txtGamen_Data.Text;

                    Kvics.DBAccess.DBAccessor.DefaultConnectionString = _HSS5ConnectionString;

                    t200 = T200.GetLast();
                    if (t200 == null)
                    {
                        throw new Exception("No data. Please insert data T200 first.");
                    }
                    gamen.MasterID = t200.ID;

                    gamen.Insert();
                }
                // end T200
                // T1800
                {
                    Kvics.DBAccess.DBAccessor.DefaultConnectionString = _HSS4ConnectionString;

                    T1800 t1800 = T1800.GetLast();
                    if (t1800 == null)
                    {
                        throw new Exception("No data. Please connect to HSS4 database.");
                    }

                    Kvics.DBAccess.DBAccessor.DefaultConnectionString = _HSS4ConnectionString;

                    Gamen gamen = new Gamen(t1800.ID, 3);

                    if (gamen == null)
                    {
                        throw new Exception("No data. Please connect to HSS4 database.");
                    }
                    gamen.Values = txtGamen_Data.Text;

                    Kvics.DBAccess.DBAccessor.DefaultConnectionString = _HSS5ConnectionString;

                    t1800 = T1800.GetLast();
                    if (t1800 == null)
                    {
                        throw new Exception("No data. Please insert data T1800 first.");
                    }
                    gamen.MasterID = t1800.ID;

                    gamen.Insert();
                }
                // end T1800

                lblGamen_Status.Text = "Insert successful.";
            }
            catch (Exception ex)
            {
                lblGamen_Status.Text = "Error: " + ex.Message + System.Environment.NewLine + ex.StackTrace;
                lblGamen_Status.ForeColor = Color.Red;
            }
        }
        #endregion

        private void btnGamen_FromFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.CheckFileExists = true;
                dlg.DefaultExt = "*.csv";
                dlg.FileName = "Gamen.csv";
                dlg.Filter = "Gamen file (*.csv)|*.csv";
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    DataTable tb = CSVFileManager.Read(dlg.FileName, System.Text.Encoding.GetEncoding("Shift_JIS"), ",");

                    StringBuilder strBuilder = new StringBuilder();
                    for (int i = 1; i < tb.Rows.Count; i++)
                    {
                        if (tb.Rows[i][1] != null)
                        {
                            string valueiString = tb.Rows[i][1].ToString().Trim();
                            strBuilder.Append(valueiString);
                        }
                        else
                        {
                            strBuilder.Append("0");
                        }
                        if (i < tb.Rows.Count - 1)
                        {
                            strBuilder.Append(Gamen.VALUES__SEPARATOR);
                        }
                    }
                    txtGamen_Data.Text = strBuilder.ToString();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}