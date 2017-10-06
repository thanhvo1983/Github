using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using Kvics.PInvoke;

namespace Hotmill.Test
{
    public partial class FormDatabaseConfig : Form
    {
        public string HotMillDatabaseConnectionString = "";
        public string DatabaseName = "";

        public FormDatabaseConfig()
        {
            InitializeComponent();
        }

        private void SQLStringBuilder_Load(object sender, EventArgs e)
        {
            this.Focus();
            if (HotMillDatabaseConnectionString.Length > 0)
            {
                ParseSQLString(HotMillDatabaseConnectionString);
            }
            else
            {
                txtServerName.Text = Environment.MachineName;
            }
            txtServerName.Focus();

            rdbUser_CheckedChanged(null, null);
        }

        private void rdbUser_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbUser.Checked)
            {
                txtUserName.Enabled = txtPassword.Enabled = true;
            }
            else
            {
                txtUserName.Enabled = txtPassword.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtServerName.Text.Trim().Length < 1)
            {
                MessageBox.Show("Please input server name or server IP address.");
                this.txtServerName.SelectAll();
                this.txtServerName.Focus();
                return;
            }
            if (txtDatabase.Text.Trim().Length < 1)
            {
                MessageBox.Show("Please input HotMill database name.");
                this.txtDatabase.SelectAll();
                this.txtDatabase.Focus();
                return;
            }
            if ((rdbUser.Checked ? true : false))
            {
                if (txtUserName.Text.Trim().Length < 1)
                {
                    MessageBox.Show("Please input user name.");
                    this.txtUserName.SelectAll();
                    this.txtUserName.Focus();
                    return;
                }
            }

            string SQLConnectionString = BuildConnectionString(txtServerName.Text.Trim(),
                    (rdbUser.Checked ? true : false), txtUserName.Text.Trim(),
                    txtPassword.Text.Trim(), txtDatabase.Text.Trim());

            SqlConnection Connection = null;
            try
            {
                Connection = new SqlConnection(SQLConnectionString);
                Connection.Open();
                
                this.DatabaseName = txtDatabase.Text;
                this.HotMillDatabaseConnectionString = 
                    BuildConnectionString(txtServerName.Text.Trim(), 
                    (rdbUser.Checked ? true : false), txtUserName.Text.Trim(), 
                    txtPassword.Text.Trim(), txtDatabase.Text.Trim());

                //ApplyConnectionString(HotMillDatabaseConnectionString);

                this.DialogResult = DialogResult.OK;
            }
            catch
            {
                MessageBox.Show(this, "データベースに接続出来ません”" + this.txtDatabase.Text + "”。", "接続エラー", MessageBoxButtons.OK);
            }
            finally
            {
                if (Connection != null)
                    if (Connection.State == ConnectionState.Open)
                        Connection.Close();
            }
        }

        private string BuildConnectionString(string dataSource, 
                bool persistSecurityInfo, 
                string userName, 
                string password, 
                string databaseName)
        {
            string strReturn = "";
            strReturn += "Data Source=" + dataSource;
            strReturn += ";Initial Catalog=" + databaseName;
            strReturn += ";Persist Security Info=" + (persistSecurityInfo ? "true" : "false");
            if (persistSecurityInfo)
            {
                strReturn += ";User ID=" + userName;
                strReturn += ";Password=" + password;
            }
            else
            {
                strReturn += ";Integrated Security=SSPI";
                strReturn += ";User ID=sa";
            }
            return strReturn;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ParseSQLString(string _ConnectionString)
        {
            string DataSourceStr = "(local)";
            string InitialCatalogStr = "";
            string PersistSecurityInfoStr = "true";
            string UserIDStr = "sa";
            string PasswordStr = "";

            string[] parseStrings = null;
            string[] separator = { ";" };
            string[] separatorEqual = { "=" };
            parseStrings = _ConnectionString.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            foreach (string param in parseStrings)
            {
                string[] perParams = param.Split(separatorEqual, StringSplitOptions.RemoveEmptyEntries);
                if (perParams.Length == 2)
                {
                    if (perParams[0].Trim().Equals("Data Source", StringComparison.OrdinalIgnoreCase))
                    {
                        DataSourceStr = perParams[1].Trim();
                    }
                    else if (perParams[0].Trim().Equals("Initial Catalog", StringComparison.OrdinalIgnoreCase))
                    {
                        InitialCatalogStr = perParams[1].Trim();
                    }
                    else if (perParams[0].Trim().Equals("Persist Security Info", StringComparison.OrdinalIgnoreCase))
                    {
                        PersistSecurityInfoStr = perParams[1].Trim();
                    }
                    else if (perParams[0].Trim().Equals("User ID", StringComparison.OrdinalIgnoreCase))
                    {
                        UserIDStr = perParams[1].Trim();
                    }
                    else if (perParams[0].Trim().Equals("Password", StringComparison.OrdinalIgnoreCase))
                    {
                        PasswordStr = perParams[1].Trim();
                    }
                    else
                    { }
                }
            }

            txtServerName.Text = DataSourceStr;
            txtDatabase.Text = InitialCatalogStr;
            txtUserName.Text = UserIDStr;
            txtPassword.Text = PasswordStr;
            rdbUser.Checked = (PersistSecurityInfoStr.Equals("false", StringComparison.OrdinalIgnoreCase) ? false : true);
        }

        private static void ConfigureDatabase(string connectionString)
        {
            Configuration config = null;
            ConnectionStringSettings appDatabase = null;

            try
            {
                // Open Application's Config file
                config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Cannot open application config file. Exception: " + ex.Message);
                throw ex;
            }

            try
            {
                // Add new connection string setting for Application's Config file
                appDatabase = new ConnectionStringSettings();
                appDatabase.Name = "ConnectionString";

                StringBuilder plain = new StringBuilder(connectionString);
                StringBuilder pass = new StringBuilder("kvics.com.vn");

                StringBuilder encrypt = CryptUtil.EncryptString(plain, pass, CryptUtil.CALG_3DES);
                appDatabase.ConnectionString = encrypt.ToString();

                config.ConnectionStrings.ConnectionStrings.Remove(appDatabase.Name);
                config.ConnectionStrings.ConnectionStrings.Add(appDatabase);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Cannot edit config file. Exception: " + ex.Message);
                throw ex;
            }

            try
            {
                // Persist Application's Config file settings
                config.Save();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Cannot save config file. Exception: " + ex.Message);
                throw ex;
            }
        }

        public static bool ApplyConnectionString(string connectionString)
        {
            try
            {
                Kvics.DBAccess.DBAccessor.DefaultConnectionString = connectionString;
                ConfigureDatabase(connectionString);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}