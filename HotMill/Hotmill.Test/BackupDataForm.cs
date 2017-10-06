using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Kvics.HotMill.BL;
using Kvics.Utility;
using System.IO;

namespace Hotmill.Test
{
    public partial class BackupDataForm : Form
    {
        protected FormDatabaseConfig frmDatabaseConfig = null;

        public BackupDataForm()
        {
            InitializeComponent();
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
            if (frmDatabaseConfig.DialogResult != DialogResult.OK)
            {
                frmDatabaseConfig = null;
            }
            Kvics.DBAccess.DBAccessor.DefaultConnectionString = null;
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(BitConverter.ToString(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
            if (this.frmDatabaseConfig == null)
            {
                btnDatabaseConfig_Click(null, null);
                if (frmDatabaseConfig == null)
                {
                    return;
                }
            }

            try
            {
                string coilNo = txtCoinNo.Text.Trim();
                int year = Int32.Parse(txtYear.Text.Trim());
                while (coilNo.Length < 8) { coilNo += " "; }
                T800 t800 = T800.GetCoilDetailOfYear(coilNo, year);
                if (t800 == null)
                {
                    MessageBox.Show("This CoilNo cannot be found. Please try again", "CoilNo not found.");
                    return;
                }

                T900 t900 = T900.GetCoilDetailOfYear(coilNo, year);
                T1800 t1800 = T1800.GetCoilDetailOfYear(coilNo, year);
                Gamen gm800 = new Gamen(t800.ID, 2);
                Gamen gm900 = t900 == null ? null : (new Gamen(t900.ID, 1));
                Gamen gm1800 = t1800 == null ? null : (new Gamen(t1800.ID, 3));

                this.saveFileDialog1.FileName = txtCoinNo.Text.Trim() + ".dat";
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    byte[] t800bytes = t800.GetBytes();
                    string t800bstr = HexEncoding.ToString(t800bytes);

                    byte[] t900bytes = (t900 == null ? null : t900.GetBytes());
                    string t900bstr = (t900 == null ? null : HexEncoding.ToString(t900bytes));

                    byte[] t1800bytes = (t1800 == null ? null : t1800.GetBytes());
                    string t1800bstr = (t1800 == null ? null : HexEncoding.ToString(t1800bytes));

                    string gm800str = gm800.ID > 0 ? gm800.Values : "";
                    string gm900str = (gm900 != null && gm900.ID > 0) ? gm900.Values : "";
                    string gm1800str = (gm1800 != null && gm1800.ID > 0) ? gm1800.Values : "";

                    Stream stream = this.saveFileDialog1.OpenFile();
                    StreamWriter wrt = new StreamWriter(stream);
                    wrt.WriteLine("T900:" + t900bstr);
                    wrt.WriteLine("T800:" + t800bstr);
                    wrt.WriteLine("T1800:" + t1800bstr);
                    wrt.WriteLine("GMT900:" + gm900str);
                    wrt.WriteLine("GMT800:" + gm800str);
                    wrt.WriteLine("GMT1800:" + gm1800str);

                    wrt.Close();
                    stream.Close();

                    MessageBox.Show("Data was saved.", "Successful");
                }
            }
            catch (Exception)
            {
            }
        }
    }
}