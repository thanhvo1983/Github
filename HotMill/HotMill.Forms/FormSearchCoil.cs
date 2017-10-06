using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;


using Kvics.HotMill.BL;

namespace Kvics.HotMill.Forms
{
    public partial class FormSearchCoil : SubFormFullScreen
    {
        #region Static 
        private static string MSG = " エラー";
        private static string MSG_1 = "検索開始カーボン量が不合理です。";
        private static string MSG_2 = "検索終了カーボン量が不合理です。";
        private static string MSG_3 = "検索開始狙い厚が不合理です。";
        private static string MSG_4 = "検索終了狙い厚が不合理です。";
        private static string MSG_5 = "検索開始狙い幅が不合理です。";
        private static string MSG_6 = "検索終了狙い幅が不合理です。";
        private static string MSG_7 = "検索開始熱間強度が不合理です。";
        private static string MSG_8 = "検索終了熱間強度が不合理です。";
        private static string MSG_9 = "コイルＮｏが不合理です。";
        private static string MSG_10 = "鋼種が不合理です。";
        //private static string MSG_11 = "検索開始圧延日が不合理です。";
        //private static string MSG_12 = "検索終了圧延日が不合理です。";
        #endregion

        public FormSearchCoil()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSearchCoil_Load(object sender, EventArgs e)
        {
            try
            {
                TWorker user = new TWorker();

                WorkerCollection coll = user.GetWorkerCollection();
                foreach (object obj in coll)
                {
                    lstOfficers.Items.Add(obj);
                }

                dtpToDate.Value = DateTime.Now;
                dtpFromDate.Value = DateTime.Now.AddYears(-1);

                return;
            }
            catch (Exception)
            {
                MainForm.ShowError(HotMillErrorType.DATABASE_ERROR);
            }

            this.Close();
        }

        private void btnAddOfficer_Click(object sender, EventArgs e)
        {
            if (lstOfficers.SelectedItem != null)
            {
                for (int i = 0; i < lstOfficers.SelectedItems.Count; )
                {
                    if (lstSearchOfficers.Items.Count == 8)
                    {
                        break;
                    }
                    object var = lstOfficers.SelectedItems[i];

                    lstOfficers.Items.Remove(var);

                    lstSearchOfficers.Items.Add(var);                    
                }
            }
        }

        private void btnRemoveOfficer_Click(object sender, EventArgs e)
        {
            if (lstSearchOfficers.SelectedItem != null)
            {
                for (int i = 0; i < lstSearchOfficers.SelectedItems.Count; )
                {
                    object var = lstSearchOfficers.SelectedItems[i];

                    lstSearchOfficers.Items.Remove(var);

                    lstOfficers.Items.Add(var);
                }
            }
        }

        private void lbxOfficers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                btnAddOfficer_Click(sender, null);
            }
        }

        private void lbxSearchOfficers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnRemoveOfficer_Click(sender, null);
            }
        }

        private void btnSearchCoil_Click(object sender, EventArgs e)
        {
            if (!ValidateControls())
            {
                return;
            }

            CoilSearchStructure searchData = BuildSearchData();

            FormSearchCoilResult form = new FormSearchCoilResult(searchData);
            form.ShowDialog(this.Owner);
        }

        private void btnRollingResultTotal_Click(object sender, EventArgs e)
        {
            if (!ValidateControls())
            {
                return;
            }

            CoilSearchStructure searchData = BuildSearchData();

            FormRollingResultsTotal frm = new FormRollingResultsTotal(searchData);
            frm.ShowDialog(this.Owner);
        }

        private CoilSearchStructure BuildSearchData()
        {
            CoilSearchStructure searchData = new CoilSearchStructure();
            searchData.BeginDate = dtpFromDate.Value.ToString("yy/MM/dd");
            //searchData.BeginDate = txtFromDate.Text;
            //if (txtFromDate.Text == string.Empty)
            //{
            //    DateTime time = DateTime.Now.AddYears(-1);
            //    searchData.BeginDate = time.ToString("yy/MM/dd");
            //}
            searchData.CacbonBegin = this.txtFromCarbonQuantity.Text.Trim().Length > 0 ? double.Parse(this.txtFromCarbonQuantity.Text) * 1000 : -1;
            searchData.CacbonEnd = this.txtToCarbonQuantity.Text.Trim().Length > 0 ? double.Parse(this.txtToCarbonQuantity.Text) * 1000 : -1;
            searchData.CoilNo = this.txtCoilNo.Text.Replace("*", "%");
            searchData.EndDate = dtpToDate.Value.ToString("yy/MM/dd");
            //searchData.EndDate = txtToDate.Text;
            //if (txtToDate.Text == string.Empty)
            //{
            //    DateTime time = DateTime.Now;
            //    searchData.EndDate = time.ToString("yy/MM/dd");
            //}
            searchData.SteelName = this.txtSteelTypeName.Text.Replace("*", "%");
            searchData.TemperatureBegin = this.txtFromHeatIntensity.Text.Trim().Length > 0 ? double.Parse(this.txtFromHeatIntensity.Text) : -1;
            searchData.TemperatureEnd = this.txtToHeatIntensity.Text.Trim().Length > 0 ? double.Parse(this.txtToHeatIntensity.Text) : -1;
            searchData.ThickBegin = this.txtFromThick.Text.Trim().Length > 0 ? double.Parse(this.txtFromThick.Text) * 100 : -1;
            searchData.ThickEnd = this.txtToThick.Text.Trim().Length > 0 ? double.Parse(this.txtToThick.Text) * 100 : -1;
            searchData.WidthBegin = this.txtFromWidth.Text.Trim().Length > 0 ? double.Parse(this.txtFromWidth.Text) : -1;
            searchData.WidthEnd = this.txtToWidth.Text.Trim().Length > 0 ? double.Parse(this.txtToWidth.Text) : -1;


            // material
            if (this.rdbRollMaterialF4Haisu.Checked)
            {
                searchData.F4Material = RollMaterialSearch.Haisu;
            }
            if (this.rdbRollMaterialF4Other.Checked)
            {
                searchData.F4Material = RollMaterialSearch.Other;
            }
            if (this.rdbRollMaterialF4NotAssign.Checked)
            {
                searchData.F4Material = RollMaterialSearch.Unknown;
            }

            if (this.rdbRollMaterialF5Haisu.Checked)
            {
                searchData.F5Material = RollMaterialSearch.Haisu;
            }
            if (this.rdbRollMaterialF5Other.Checked)
            {
                searchData.F5Material = RollMaterialSearch.Other;
            }
            if (this.rdbRollMaterialF5NotAssign.Checked)
            {
                searchData.F5Material = RollMaterialSearch.Unknown;
            }

            if (this.rdbRollMaterialF6Haisu.Checked)
            {
                searchData.F6Material = RollMaterialSearch.Haisu;
            }
            if (this.rdbRollMaterialF6Other.Checked)
            {
                searchData.F6Material = RollMaterialSearch.Other;
            }
            if (this.rdbRollMaterialF6NotAssign.Checked)
            {
                searchData.F6Material = RollMaterialSearch.Unknown;
            }


            if (this.rdbRollMaterialF7Haisu.Checked)
            {
                searchData.F7Material = RollMaterialSearch.Haisu;
            }
            if (this.rdbRollMaterialF7Other.Checked)
            {
                searchData.F7Material = RollMaterialSearch.Other;
            }
            if (this.rdbRollMaterialF7NotAssign.Checked)
            {
                searchData.F7Material = RollMaterialSearch.Unknown;
            }

            //GroupSearch            
            searchData.Group = new GroupSearch(false, false, false, false);
            if (this.ckbGroupA.Checked)
            {
                searchData.Group.A = true;
            }

            if (this.ckbGroupB.Checked)
            {
                searchData.Group.B = true;
            }

            if (this.ckbGroupC.Checked)
            {
                searchData.Group.C = true;
            }

            if (this.ckbGroupD.Checked)
            {
                searchData.Group.D = true;
            }

            //WorkerCollection
            searchData.WorkerList = new WorkerCollection();
            for (int i = 0; i < this.lstSearchOfficers.Items.Count; i++)
            {
                searchData.WorkerList.Add(this.lstSearchOfficers.Items[i] as WorkerParameter);
            }

            return searchData;
        }

        private void txtFromCarbonQuantity_Leave(object sender, EventArgs e)
        {
            txtFromCarbonQuantity_Validate();

        }

        private void txtToCarbonQuantity_Leave(object sender, EventArgs e)
        {
            txtToCarbonQuantity_Validate();

        }

        private void txtFromThick_Leave(object sender, EventArgs e)
        {
            txtFromThick_Validate();

        }

        private void txtToThick_Leave(object sender, EventArgs e)
        {
            txtToThick_Validate();

        }

        private void txtFromWidth_Leave(object sender, EventArgs e)
        {
            txtFromWidth_Validate();

        }

        private void txtToWidth_Leave(object sender, EventArgs e)
        {
            txtToWidth_Validate();

        }

        private void txtFromHeatIntensity_Leave(object sender, EventArgs e)
        {
            txtFromHeatIntensity_Validate();

        }

        private void txtToHeatIntensity_Leave(object sender, EventArgs e)
        {
            txtToHeatIntensity_Validate();

        }

        private void txtCoilNo_Leave(object sender, EventArgs e)
        {
            txtCoilNo_Validate();

        }

        private void txtSteelTypeName_Leave(object sender, EventArgs e)
        {
            txtSteelTypeName_Validate();

        }

        private bool txtFromCarbonQuantity_Validate()
        {
            if (this.txtFromCarbonQuantity.Text == string.Empty || this.txtFromCarbonQuantity.Text == "")
            {
                return true;
            }

            txtFromCarbonQuantity.Text = txtFromCarbonQuantity.Text.Trim();
            string pattern = @"^[0-9]+\.?[0-9]*$";
            if (!Regex.IsMatch(this.txtFromCarbonQuantity.Text, pattern))
            {
                MessageBox.Show(MSG_1, MSG, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtFromCarbonQuantity.Focus();
            }
            else
            {
                return true;
            }

            return false;

        }

        private bool txtToCarbonQuantity_Validate()
        {
            if (this.txtToCarbonQuantity.Text == string.Empty || this.txtToCarbonQuantity.Text == "")
            {
                return true;
            }

            txtToCarbonQuantity.Text = txtToCarbonQuantity.Text.Trim();
            string pattern = @"^[0-9]+\.?[0-9]*$";
            if (!Regex.IsMatch(this.txtToCarbonQuantity.Text, pattern))
            {
                MessageBox.Show(MSG_2, MSG, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtToCarbonQuantity.Focus();
            }
            else
            {
                return true;
            }

            return false;



        }

        private bool txtFromThick_Validate()
        {
            if (this.txtFromThick.Text == string.Empty || this.txtFromThick.Text == "")
            {
                return true;
            }

            txtFromThick.Text = txtFromThick.Text.Trim();
            string pattern = @"^[0-9]+\.?[0-9]*$";
            if (!Regex.IsMatch(this.txtFromThick.Text, pattern))
            {
                MessageBox.Show(MSG_3, MSG, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtFromThick.Focus();
            }
            else
            {
                return true;
            }

            return false;



        }

        private bool txtToThick_Validate()
        {
            if (this.txtToThick.Text == string.Empty || this.txtToThick.Text == "")
            {
                return true;
            }

            txtToThick.Text = txtToThick.Text.Trim();
            string pattern = @"^[0-9]+\.?[0-9]*$";
            if (!Regex.IsMatch(this.txtToThick.Text, pattern))
            {
                MessageBox.Show(MSG_4, MSG, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtToThick.Focus();
            }
            else
            {
                return true;
            }

            return false;



        }

        private bool txtFromWidth_Validate()
        {
            if (this.txtFromWidth.Text == string.Empty || this.txtFromWidth.Text == "")
            {
                return true;
            }

            txtFromWidth.Text = txtFromWidth.Text.Trim();
            string pattern = @"^[0-9]+\.?[0-9]*$";
            if (!Regex.IsMatch(this.txtFromWidth.Text, pattern))
            {
                MessageBox.Show(MSG_5, MSG, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtFromWidth.Focus();
            }
            else
            {
                return true;
            }

            return false;



        }

        private bool txtToWidth_Validate()
        {
            if (this.txtToWidth.Text == string.Empty || this.txtToWidth.Text == "")
            {
                return true;
            }

            txtToWidth.Text = txtToWidth.Text.Trim();
            string pattern = @"^[0-9]+\.?[0-9]*$";
            if (!Regex.IsMatch(this.txtToWidth.Text, pattern))
            {
                MessageBox.Show(MSG_6, MSG, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtToWidth.Focus();
            }
            else
            {
                return true;
            }

            return false;



        }

        private bool txtFromHeatIntensity_Validate()
        {
            if (this.txtFromHeatIntensity.Text == string.Empty || this.txtFromHeatIntensity.Text == "")
            {
                return true;
            }

            txtFromHeatIntensity.Text = txtFromHeatIntensity.Text.Trim();
            string pattern = @"^[0-9]+\.?[0-9]*$";
            if (!Regex.IsMatch(this.txtFromHeatIntensity.Text, pattern))
            {
                MessageBox.Show(MSG_7, MSG, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtFromHeatIntensity.Focus();
            }
            else
            {
                return true;
            }

            return false;



        }

        private bool txtToHeatIntensity_Validate()
        {
            if (this.txtToHeatIntensity.Text == string.Empty || this.txtToHeatIntensity.Text == "")
            {
                return true;
            }

            txtToHeatIntensity.Text = txtToHeatIntensity.Text.Trim();
            string pattern = @"^[0-9]+\.?[0-9]*$";
            if (!Regex.IsMatch(this.txtToHeatIntensity.Text, pattern))
            {
                MessageBox.Show(MSG_8, MSG, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtToHeatIntensity.Focus();
            }
            else
            {
                return true;
            }

            return false;



        }

        private bool txtCoilNo_Validate()
        {
            if (this.txtCoilNo.Text == string.Empty || this.txtCoilNo.Text == "")
            {
                return true;
            }

            txtCoilNo.Text = txtCoilNo.Text.Trim();
            string pattern = @"^\w+\*?$";
            if (!Regex.IsMatch(this.txtCoilNo.Text, pattern))
            {
                MessageBox.Show(MSG_9, MSG, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtCoilNo.Focus();
            }
            else
            {
                return true;
            }

            return false;



        }

        private bool txtSteelTypeName_Validate()
        {
            if (this.txtSteelTypeName.Text == string.Empty || this.txtSteelTypeName.Text == "")
            {
                return true;
            }

            txtSteelTypeName.Text = txtSteelTypeName.Text.Trim();
            string pattern = @"^\w+\*?$";
            if (!Regex.IsMatch(this.txtSteelTypeName.Text, pattern))
            {
                MessageBox.Show(MSG_10, MSG, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtSteelTypeName.Focus();
            }
            else
            {
                return true;
            }

            return false;


        }

        private bool ValidateControls()
        {
            if (!txtCoilNo_Validate())
            {
                return false;
            }
            if (!txtSteelTypeName_Validate())
            {
                return false;
            }
            if (!txtFromCarbonQuantity_Validate())
            {
                return false;
            }
            if (!txtToCarbonQuantity_Validate())
            {
                return false;
            }
            if (!txtFromThick_Validate())
            {
                return false;
            }
            if (!txtToThick_Validate())
            {
                return false;
            }
            if (!txtFromWidth_Validate())
            {
                return false;
            }
            if (!txtToWidth_Validate())
            {
                return false;
            }
            if (!txtFromHeatIntensity_Validate())
            {
                return false;
            }
            if (!txtToHeatIntensity_Validate())
            {
                return false;
            }
            return true;
        }
    }
}