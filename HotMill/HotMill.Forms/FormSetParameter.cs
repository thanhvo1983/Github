using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Kvics.HotMill.BL;

namespace Kvics.HotMill.Forms
{
    public partial class FormSetParameter : SubFormFullScreen
    {
        #region Static
        private static readonly string PARAMETER_1 = "ÉpÉâÉÅÅ[É^_ÇP";
        private static readonly string PARAMETER_2 = "ÉpÉâÉÅÅ[É^_ÇQ";
        private static readonly string PARAMETER_3 = "ÉpÉâÉÅÅ[É^_ÇR";
        private static readonly string PARAMETER_4 = "ÉpÉâÉÅÅ[É^_ÇS";
        private static readonly string PARAMETER_5 = "ÉpÉâÉÅÅ[É^_ÇT";
        private static readonly string PARAMETER_6 = "ÉpÉâÉÅÅ[É^_ÇU";
        private static readonly string METHOD_A = "ï˚ñ@_Ç`";
        private static readonly string METHOD_B = "ï˚ñ@_Ça";
        private static readonly string METHOD_C = "ï˚ñ@_Çb";
        private static readonly string METHOD_D = "ï˚ñ@_Çc";
        private static readonly string METHOD_E = "ï˚ñ@_Çd";
        private static readonly string METHOD_F = "ï˚ñ@_Çe";
        private static readonly string FLAG_1 = "ÉtÉâÉO_ÇP";
        private static readonly string FLAG_2 = "ÉtÉâÉO_ÇQ";
        private static readonly string FLAG_3 = "ÉtÉâÉO_ÇR";
        #endregion

        #region Private
        TConfig _tCfg = new TConfig();
        ArrayList _lID = new ArrayList();
        #endregion

        public FormSetParameter()
        {
            InitializeComponent();
        }
        private void Init()
        {
            try
            {
                DataSet dt_Set = _tCfg.GetAll();

                if (dt_Set.Tables[0].Rows.Count == 0)
                {
                    this.TConfigInit();
                    dt_Set = _tCfg.GetAll();
                    foreach (DataRow r in dt_Set.Tables[0].Rows)
                    {
                        _lID.Add((int)r[0]);
                    }
                }
                else
                {
                    foreach (DataRow r in dt_Set.Tables[0].Rows)
                    {
                        _lID.Add((int)r[0]);
                    }
                }

                this.txtParameter1.Text = dt_Set.Tables[0].Rows[0][2].ToString();
                this.txtParameter2.Text = dt_Set.Tables[0].Rows[1][2].ToString();
                this.txtParameter3.Text = dt_Set.Tables[0].Rows[2][2].ToString();
                this.txtParameter4.Text = dt_Set.Tables[0].Rows[3][2].ToString();
                this.txtParameter5.Text = dt_Set.Tables[0].Rows[4][2].ToString();
                this.txtParameter6.Text = dt_Set.Tables[0].Rows[5][2].ToString();

                if (int.Parse(dt_Set.Tables[0].Rows[6][2].ToString()) == 1)
                {
                    this.rdbMethodA.Checked = true;
                }
                if (int.Parse(dt_Set.Tables[0].Rows[7][2].ToString()) == 1)
                {
                    this.rdbMethodB.Checked = true;
                }
                if (int.Parse(dt_Set.Tables[0].Rows[8][2].ToString()) == 1)
                {
                    this.rdbMethodC.Checked = true;
                }
                if (int.Parse(dt_Set.Tables[0].Rows[9][2].ToString()) == 1)
                {
                    this.rdbMethodD.Checked = true;
                }
                if (int.Parse(dt_Set.Tables[0].Rows[10][2].ToString()) == 1)
                {
                    this.rdbMethodE.Checked = true;
                }
                if (int.Parse(dt_Set.Tables[0].Rows[11][2].ToString()) == 1)
                {
                    this.rdbMethodF.Checked = true;
                }

                if (int.Parse(dt_Set.Tables[0].Rows[12][2].ToString()) == 1)
                {
                    this.ckbFlag1.Checked = true;
                }

                if (int.Parse(dt_Set.Tables[0].Rows[13][2].ToString()) == 1)
                {
                    this.ckbFlag2.Checked = true;
                }

                if (int.Parse(dt_Set.Tables[0].Rows[14][2].ToString()) == 1)
                {
                    this.ckbFlag3.Checked = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                // Set parameter 1
                _tCfg.ID = int.Parse(_lID[0].ToString());
                _tCfg.Name = PARAMETER_1;
                _tCfg.Value = txtParameter1.Text;
                _tCfg.Update();

                // Set parameter 2
                _tCfg.ID = int.Parse(_lID[1].ToString());
                _tCfg.Name = PARAMETER_2;
                _tCfg.Value = txtParameter2.Text;
                _tCfg.Update();

                // Set parameter 3
                _tCfg.ID = int.Parse(_lID[2].ToString());
                _tCfg.Name = PARAMETER_3;
                _tCfg.Value = txtParameter3.Text;
                _tCfg.Update();

                // Set parameter 4
                _tCfg.ID = int.Parse(_lID[3].ToString());
                _tCfg.Name = PARAMETER_4;
                _tCfg.Value = txtParameter4.Text;
                _tCfg.Update();

                // Set parameter 5
                _tCfg.ID = int.Parse(_lID[4].ToString());
                _tCfg.Name = PARAMETER_5;
                _tCfg.Value = txtParameter5.Text;
                _tCfg.Update();

                // Set parameter 6
                _tCfg.ID = int.Parse(_lID[5].ToString());
                _tCfg.Name = PARAMETER_6;
                _tCfg.Value = txtParameter6.Text;
                _tCfg.Update();

                // Set method 1
                _tCfg.ID = int.Parse(_lID[6].ToString());
                _tCfg.Name = METHOD_A;
                _tCfg.Value = (0).ToString();
                if (rdbMethodA.Checked)
                {
                    _tCfg.Value = (1).ToString();
                }
                _tCfg.Update();

                // Set method 2
                _tCfg.ID = int.Parse(_lID[7].ToString());
                _tCfg.Name = METHOD_B;
                _tCfg.Value = (0).ToString();
                if (rdbMethodB.Checked)
                {
                    _tCfg.Value = (1).ToString();
                }
                _tCfg.Update();

                // Set method 3
                _tCfg.ID = int.Parse(_lID[8].ToString());
                _tCfg.Name = METHOD_C;
                _tCfg.Value = (0).ToString();
                if (rdbMethodC.Checked)
                {
                    _tCfg.Value = (1).ToString();
                }
                _tCfg.Update();

                // Set method 4
                _tCfg.ID = int.Parse(_lID[9].ToString());
                _tCfg.Name = METHOD_D;
                _tCfg.Value = (0).ToString();
                if (rdbMethodD.Checked)
                {
                    _tCfg.Value = (1).ToString();
                }
                _tCfg.Update();

                // Set method 5
                _tCfg.ID = int.Parse(_lID[10].ToString());
                _tCfg.Name = METHOD_E;
                _tCfg.Value = (0).ToString();
                if (rdbMethodE.Checked)
                {
                    _tCfg.Value = (1).ToString();
                }
                _tCfg.Update();

                // Set method 6
                _tCfg.ID = int.Parse(_lID[11].ToString());
                _tCfg.Name = METHOD_F;
                _tCfg.Value = (0).ToString();
                if (rdbMethodF.Checked)
                {
                    _tCfg.Value = (1).ToString();
                }
                _tCfg.Update();

                // Set flag 1
                _tCfg.ID = int.Parse(_lID[12].ToString());
                _tCfg.Name = FLAG_1;
                _tCfg.Value = (0).ToString();
                if (ckbFlag1.Checked)
                {
                    _tCfg.Value = (1).ToString();
                }
                _tCfg.Update();

                // Set flag 2
                _tCfg.ID = int.Parse(_lID[13].ToString());
                _tCfg.Name = FLAG_2;
                _tCfg.Value = (0).ToString();
                if (ckbFlag2.Checked)
                {
                    _tCfg.Value = (1).ToString();
                }
                _tCfg.Update();

                // Set flag 3
                _tCfg.ID = int.Parse(_lID[14].ToString());
                _tCfg.Name = FLAG_3;
                _tCfg.Value = (0).ToString();
                if (ckbFlag3.Checked)
                {
                    _tCfg.Value = (1).ToString();
                }
                _tCfg.Update();

                this.Close();
            }
            catch (Exception)
            {
            }
        }
        private void TConfigInit()
        {
            try
            {
                // Set parameter 1
                _tCfg.Name = PARAMETER_1;
                _tCfg.Value = txtParameter1.Text;
                _tCfg.Insert();

                // Set parameter 2
                _tCfg.Name = PARAMETER_2;
                _tCfg.Value = txtParameter2.Text;
                _tCfg.Insert();

                // Set parameter 3
                _tCfg.Name = PARAMETER_3;
                _tCfg.Value = txtParameter3.Text;
                _tCfg.Insert();

                // Set parameter 4
                _tCfg.Name = PARAMETER_4;
                _tCfg.Value = txtParameter4.Text;
                _tCfg.Insert();

                // Set parameter 5
                _tCfg.Name = PARAMETER_5;
                _tCfg.Value = txtParameter5.Text;
                _tCfg.Insert();

                // Set parameter 6
                _tCfg.Name = PARAMETER_6;
                _tCfg.Value = txtParameter6.Text;
                _tCfg.Insert();

                // Set method 1
                _tCfg.Name = METHOD_A;
                _tCfg.Value = (0).ToString();
                if (rdbMethodA.Checked)
                {
                    _tCfg.Value = (1).ToString();
                }
                _tCfg.Insert();

                // Set method 2
                _tCfg.Name = METHOD_B;
                _tCfg.Value = (0).ToString();
                if (rdbMethodB.Checked)
                {
                    _tCfg.Value = (1).ToString();
                }
                _tCfg.Insert();

                // Set method 3
                _tCfg.Name = METHOD_C;
                _tCfg.Value = (0).ToString();
                if (rdbMethodC.Checked)
                {
                    _tCfg.Value = (1).ToString();
                }
                _tCfg.Insert();

                // Set method 4
                _tCfg.Name = METHOD_D;
                _tCfg.Value = (0).ToString();
                if (rdbMethodD.Checked)
                {
                    _tCfg.Value = (1).ToString();
                }
                _tCfg.Insert();

                // Set method 5
                _tCfg.Name = METHOD_E;
                _tCfg.Value = (0).ToString();
                if (rdbMethodE.Checked)
                {
                    _tCfg.Value = (1).ToString();
                }
                _tCfg.Insert();

                // Set method 6
                _tCfg.Name = METHOD_F;
                _tCfg.Value = (0).ToString();
                if (rdbMethodF.Checked)
                {
                    _tCfg.Value = (1).ToString();
                }
                _tCfg.Insert();

                // Set flag 1
                _tCfg.Name = FLAG_1;
                _tCfg.Value = (0).ToString();
                if (ckbFlag1.Checked)
                {
                    _tCfg.Value = (1).ToString();
                }
                _tCfg.Insert();

                // Set flag 2
                _tCfg.Name = FLAG_2;
                _tCfg.Value = (0).ToString();
                if (ckbFlag2.Checked)
                {
                    _tCfg.Value = (1).ToString();
                }
                _tCfg.Insert();

                // Set flag 3
                _tCfg.Name = FLAG_3;
                _tCfg.Value = (0).ToString();
                if (ckbFlag3.Checked)
                {
                    _tCfg.Value = (1).ToString();
                }
                _tCfg.Insert();
            }
            catch (Exception)
            {
            }
        }

        private void FormSetParameter_Load(object sender, EventArgs e)
        {
            try
            {
                this.Init();
            }
            catch (Exception)
            {
                MainForm.ShowError(HotMillErrorType.DATABASE_ERROR);
                this.Close();
            }
        }
    }
}