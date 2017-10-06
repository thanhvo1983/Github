using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using log4net;
using log4net.Config;


using Kvics.HotMill.BL;

namespace Kvics.HotMill.Forms
{
    public partial class FormPressureDifferenceTotal : SubFormFullScreen
    {
        private static readonly ILog log = Log.Instance.GetLogger(typeof(FormPressureDifferenceTotal));

        //private static string MSG_11 = "検索開始圧延日が不合理です。";
        //private static string MSG_12 = "検索終了圧延日が不合理です。";
        //private static string MSG = "エラー";

        public FormPressureDifferenceTotal()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddOfficer_Click(object sender, EventArgs e)
        {
            if (lstOfficers.SelectedItem != null)
            {
                for (int i = 0; i < lstOfficers.SelectedItems.Count;)
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
                for (int i = 0; i < lstSearchOfficers.SelectedItems.Count;)
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
        /*
        private void btnSearchCoil_Click(object sender, EventArgs e)
        {
            //CoilSearchStructure searchData = new CoilSearchStructure();
            //FormSearchCoilResult form = new FormSearchCoilResult(searchData);
            //form.ShowDialog(this.Owner);
        }
        */
        private void btnTotal_Click(object sender, EventArgs e)
        {
            CoilPressureDifferenceTotalStructure searchData = BuildSearchData();
            try
            {
                SaveFileDialog fDialog = new SaveFileDialog();
                fDialog.Filter = "CSV files (*.csv)|*.csv";
                fDialog.RestoreDirectory = true;
                DialogResult result = fDialog.ShowDialog(this);
                
                if (result == DialogResult.Yes || result == DialogResult.OK)
                {
                    T1800 t1800 = new T1800();
                    DataSet ds = t1800.GetCoilList(searchData);

                    if (ds == null)
                    {
                        return;
                    }

                    string fileName = fDialog.FileName;

                    //MessageBox.Show(fileName);
                    ExportToCSV(searchData, ds, fileName);
                }
            }
            catch (Exception ex)
            {
                log.Error("btnTotal_Click error", ex);
                MessageBox.Show("データ検索計算の時にエラーが発生しました。管理者に通知して下さい。", "通知");
            }
        }

        private void ExportToCSV(CoilPressureDifferenceTotalStructure searchData, DataSet data, string fileName)
        {
            System.IO.StreamWriter strmWrt = null;
            try
            {
                strmWrt = new System.IO.StreamWriter(fileName, false, System.Text.Encoding.GetEncoding("Shift_JIS"));
            }
            catch (Exception)
            {
                MessageBox.Show("HSSは「" + fileName + "」ファイルを出力できません。このファイルは他のアプリによって出力されているからです。");
                return;
            }
            try
            {
                //strmWrt = new System.IO.StreamWriter(fileName, false, System.Text.Encoding.GetEncoding("Shift_JIS"));

                StringBuilder strData = new StringBuilder();
                strData.Append("圧下位置差集計結果");
                strData.Append(Environment.NewLine);
                strData.Append(Environment.NewLine);
                strData.Append(",【検索条件】");
                strData.Append(Environment.NewLine);
                strData.Append(",圧延日," + searchData.BeginDate + ",～," + searchData.EndDate);
                strData.Append(Environment.NewLine);
                strData.Append(",材種," + 
                        (searchData.MaterialType == MaterialType.Ni ? "Ｎｉ" :
                        (searchData.MaterialType == MaterialType.Plate ? "縞板" : 
                        (searchData.MaterialType == MaterialType.Steel ? "鋼" :
                        (searchData.MaterialType == MaterialType.Ti ? "Ｔｉ" : "指定無し")))
                    ));
                strData.Append(Environment.NewLine);
                strData.Append(",同期スタンド," +
                        (searchData.Stand == Stand.F5 ? "5" :
                        (searchData.Stand == Stand.F6 ? "6" :
                        (searchData.Stand == Stand.F7 ? "7" : "指定無し")))
                    );
                strData.Append(Environment.NewLine);
                strData.Append(",,F5,F6,F7");
                strData.Append(Environment.NewLine);
                strData.Append(",ロール材質,"
                    + (searchData.F5Material == RollMaterialSearch.Haisu ? "ハイス" : searchData.F5Material == RollMaterialSearch.Other ? "その他" : "指定無し")
                    + ","
                    + (searchData.F6Material == RollMaterialSearch.Haisu ? "ハイス" : searchData.F6Material == RollMaterialSearch.Other ? "その他" : "指定無し")
                    + ","
                    + (searchData.F7Material == RollMaterialSearch.Haisu ? "ハイス" : searchData.F7Material == RollMaterialSearch.Other ? "その他" : "指定無し") 
                    );
                strData.Append(Environment.NewLine);
                strData.Append(",班," 
                    + (searchData.Group.A ? "A," : "") 
                    + (searchData.Group.B ? "B," : "") 
                    + (searchData.Group.C ? "C," : "") 
                    + (searchData.Group.D ? "D," : "")
                    + (!searchData.Group.A && !searchData.Group.B && !searchData.Group.C && !searchData.Group.D ? "指定無し" : "")
                    );
                strData.Append(Environment.NewLine);
                strData.Append(",圧下士,");
                for (int i = 0; i < searchData.WorkerList.Count; i++)
                {
                    strData.Append(searchData.WorkerList[i].Name + ",");
                }
                strData.Append(Environment.NewLine);
                strData.Append(Environment.NewLine);
                strData.Append(",【テーブル情報】");
                strData.Append(Environment.NewLine);

                PressureDifferenceTotalCSVTableDataCollection PressColl = new PressureDifferenceTotalCSVTableDataCollection();

                int materialCodeLast = -1;
                int materialTypeLast = -1;
                int niLast = -1;
                int standLast = -1;
                int strengthLast = -1;
                int widthLast = -1;

                for (int i = 0, size = data.Tables[0].Rows.Count; i < size; i++)
                {
                    DataRow row = data.Tables[0].Rows[i];

                    int materialCode = (Int16)row["R0067"];
                    int ni = (Int16)row["R0069"];
                    int stand = (Int16)row["R0065"];
                    int strength = (Int16)row["R0063"];
                    int width = (Int16)row["R0061"];
                    bool newItem = false;

                    PressureDifferenceTotalCSVTableData pressData;

                    int materialType = 0;
                    if (ni != 0)
                    {
                        materialType = 2;
                    }
                    else if (materialCode == 5)
                    {
                        materialType = 3;
                    }
                    else if (materialCode == 3)
                    {
                        materialType = 4;
                    }
                    else
                    {
                        materialType = 1;
                    }

                    if (materialType != materialTypeLast
                        || stand != standLast
                        || strength != strengthLast
                        || width != widthLast)
                    {
                        pressData = new PressureDifferenceTotalCSVTableData(materialType, stand, strength, width);
                        newItem = true;

                        materialCodeLast = materialCode;
                        materialTypeLast = materialType;
                        niLast = ni;
                        standLast = stand;
                        strengthLast = strength;
                        widthLast = width;
                    }
                    else
                    {
                        pressData = PressColl[PressColl.Count - 1];
                    }

                    int thick = (Int16)row["R0059"];
                    if (thick > 0 && thick < 17)
                    {
                        pressData.Data[thick - 1][0] += (Int16)((Int16)row["R0195_F1"] - (Int16)row["R0195_F2"]);
                        pressData.Data[thick - 1][1] += (Int16)((Int16)row["R0195_F2"] - (Int16)row["R0195_F3"]);
                        pressData.Data[thick - 1][2] += (Int16)((Int16)row["R0195_F3"] - (Int16)row["R0195_F4"]);
                        pressData.Data[thick - 1][3] += (Int16)((Int16)row["R0195_F4"] - (Int16)row["R0195_F5"]);
                        pressData.Data[thick - 1][4] += (Int16)((Int16)row["R0195_F5"] - (Int16)row["R0195_F6"]);
                        pressData.Data[thick - 1][5] += (Int16)((Int16)row["R0195_F6"] - (Int16)row["R0195_F7"]);
                        pressData.Data[thick - 1][6] += 1;
                    }

                    if (newItem)
                    {
                        PressColl.Add(pressData);
                    }
                    else
                    {
                        PressColl[PressColl.Count - 1] = pressData;
                    }
                }

                for (int i = 0; i < PressColl.Count; i += 2)
                {
                    PressureDifferenceTotalCSVTableData pressDataI = PressColl[i];
                    PressureDifferenceTotalCSVTableData pressDataI1 = (i < PressColl.Count - 1) ? PressColl[i + 1] : null;
                    strData.Append(Environment.NewLine);
                    strData.Append(",材種,," +
                        (pressDataI.MaterialType == 0 ? "指定無し" :
                        (pressDataI.MaterialType == 1 ? "鋼" :
                        (pressDataI.MaterialType == 2 ? "Ｎｉ" :
                        (pressDataI.MaterialType == 3 ? "Ｔｉ" : "縞板")))));

                    if (pressDataI1 != null)
                    {
                        strData.Append(",,,,,,,材種,," +
                            (pressDataI1.MaterialType == 0 ? "指定無し" :
                            (pressDataI1.MaterialType == 1 ? "鋼" :
                            (pressDataI1.MaterialType == 2 ? "Ｎｉ" :
                            (pressDataI1.MaterialType == 3 ? "Ｔｉ" : "縞板")))));
                    }
                    strData.Append(Environment.NewLine);
                    strData.Append(",同期スタンド,," + pressDataI.Stand.ToString());
                    if (pressDataI1 != null)
                    {
                        strData.Append(",,,,,,,同期スタンド,," + pressDataI1.Stand.ToString());
                    }
                    strData.Append(Environment.NewLine);
                    strData.Append(",強度区分,," + pressDataI.Strength.ToString());
                    if (pressDataI1 != null)
                    {
                        strData.Append(",,,,,,,強度区分,," + pressDataI1.Strength.ToString());
                    }
                    strData.Append(Environment.NewLine);
                    strData.Append(",板幅区分,," + pressDataI.Width.ToString());
                    if (pressDataI1 != null)
                    {
                        strData.Append(",,,,,,,板幅区分,," + pressDataI1.Width.ToString());
                    }
                    strData.Append(Environment.NewLine);
                    strData.Append(",板厚(区分),F1-F2,F2-F3,F3-F4,F4-F5,F5-F6,F6-F7,N数,");
                    if (pressDataI1 != null)
                    {
                        strData.Append(",板厚(区分),F1-F2,F2-F3,F3-F4,F4-F5,F5-F6,F6-F7,N数");
                    }

                    for (int j = 0; j < pressDataI.Data.Length; j++)
                    {
                        strData.Append(Environment.NewLine);
                        strData.Append("," + (j + 1).ToString());
                        double coilCount = (pressDataI.Data[j][6] * 1.0);
                        if (coilCount > 0)
                        {
                            strData.Append("," + ((pressDataI.Data[j][0] * 1.0) / coilCount).ToString("0.00"));
                            strData.Append("," + ((pressDataI.Data[j][1] * 1.0) / coilCount).ToString("0.00"));
                            strData.Append("," + ((pressDataI.Data[j][2] * 1.0) / coilCount).ToString("0.00"));
                            strData.Append("," + ((pressDataI.Data[j][3] * 1.0) / coilCount).ToString("0.00"));
                            strData.Append("," + ((pressDataI.Data[j][4] * 1.0) / coilCount).ToString("0.00"));
                            strData.Append("," + ((pressDataI.Data[j][5] * 1.0) / coilCount).ToString("0.00"));
                            strData.Append("," + coilCount.ToString());
                        }
                        else
                        {
                            strData.Append(",0.00,0.00,0.00,0.00,0.00,0.00,0");
                        }
                        strData.Append(",");

                        if (pressDataI1 != null)
                        {
                            strData.Append("," + (j + 1).ToString());
                            coilCount = (pressDataI1.Data[j][6] * 1.0);
                            if (coilCount > 0)
                            {
                                strData.Append("," + ((pressDataI1.Data[j][0] * 1.0) / coilCount).ToString("0.00"));
                                strData.Append("," + ((pressDataI1.Data[j][1] * 1.0) / coilCount).ToString("0.00"));
                                strData.Append("," + ((pressDataI1.Data[j][2] * 1.0) / coilCount).ToString("0.00"));
                                strData.Append("," + ((pressDataI1.Data[j][3] * 1.0) / coilCount).ToString("0.00"));
                                strData.Append("," + ((pressDataI1.Data[j][4] * 1.0) / coilCount).ToString("0.00"));
                                strData.Append("," + ((pressDataI1.Data[j][5] * 1.0) / coilCount).ToString("0.00"));
                                strData.Append("," + coilCount.ToString());
                            }
                            else
                            {
                                strData.Append(",0.00,0.00,0.00,0.00,0.00,0.00,0");
                            }
                        }
                    }

                    strData.Append(Environment.NewLine);
                }
                
                strmWrt.Write(strData.ToString());
            }
            catch (Exception ex)
            {
                log.Error("ExportToCSV error", ex);
                MessageBox.Show("データ検索計算の時にエラーが発生しました。管理者に通知して下さい。", "通知");
            }
            finally
            {
                if (strmWrt != null)
                {
                    strmWrt.Close();
                }
            }
        }

        private CoilPressureDifferenceTotalStructure BuildSearchData()
        {
            CoilPressureDifferenceTotalStructure searchData = new CoilPressureDifferenceTotalStructure();

            searchData.BeginDate = dtpFromDate.Value.ToString("yy/MM/dd");
            searchData.EndDate = dtpToDate.Value.ToString("yy/MM/dd");

            if (this.rdbMaterialType_Steel.Checked)
            {
                searchData.MaterialType = MaterialType.Steel;
            }
            else if (this.rdbMaterialType_Ni.Checked)
            {
                searchData.MaterialType = MaterialType.Ni;
            }
            else if (this.rdbMaterialType_Ti.Checked)
            {
                searchData.MaterialType = MaterialType.Ti;
            }
            else if (this.rdbMaterialType_Plate.Checked)
            {
                searchData.MaterialType = MaterialType.Plate;
            }
            else if (this.rdbMaterialType_All.Checked)
            {
                searchData.MaterialType = MaterialType.Unknown;
            }

            if (this.rdbStand_F5.Checked)
            {
                searchData.Stand = Stand.F5;
            }
            else if (this.rdbStand_F6.Checked)
            {
                searchData.Stand = Stand.F6;
            }
            else if (this.rdbStand_F7.Checked)
            {
                searchData.Stand = Stand.F7;
            }
            else if (this.rdbStand_All.Checked)
            {
                searchData.Stand = Stand.Unknown;
            }

            // material
            if (this.rdbRollMaterialF5Haisu.Checked)
            {
                searchData.F5Material = RollMaterialSearch.Haisu;
            }
            else if (this.rdbRollMaterialF5Other.Checked)
            {
                searchData.F5Material = RollMaterialSearch.Other;
            }
            else if (this.rdbRollMaterialF5NotAssign.Checked)
            {
                searchData.F5Material = RollMaterialSearch.Unknown;
            }

            if (this.rdbRollMaterialF6Haisu.Checked)
            {
                searchData.F6Material = RollMaterialSearch.Haisu;
            }
            else if (this.rdbRollMaterialF6Other.Checked)
            {
                searchData.F6Material = RollMaterialSearch.Other;
            }
            else if (this.rdbRollMaterialF6NotAssign.Checked)
            {
                searchData.F6Material = RollMaterialSearch.Unknown;
            }


            if (this.rdbRollMaterialF7Haisu.Checked)
            {
                searchData.F7Material = RollMaterialSearch.Haisu;
            }
            else if (this.rdbRollMaterialF7Other.Checked)
            {
                searchData.F7Material = RollMaterialSearch.Other;
            }
            else if (this.rdbRollMaterialF7NotAssign.Checked)
            {
                searchData.F7Material = RollMaterialSearch.Unknown;
            }

            //GroupSearch            
            searchData.Group = new GroupSearch(this.ckbGroupA.Checked, this.ckbGroupB.Checked, this.ckbGroupC.Checked, this.ckbGroupD.Checked);

            //WorkerCollection
            searchData.WorkerList = new WorkerCollection();
            for (int i = 0; i < this.lstSearchOfficers.Items.Count; i++)
            {
                searchData.WorkerList.Add(this.lstSearchOfficers.Items[i] as WorkerParameter);
            }

            return searchData;
        }

        private void FormPressureDifferenceTotal_Load(object sender, EventArgs e)
        {
            dtpToDate.Value = DateTime.Now;
            dtpFromDate.Value = DateTime.Now.AddYears(-1);

            try
            {
                TWorker user = new TWorker();

                WorkerCollection coll = user.GetWorkerCollection();
                foreach (object obj in coll)
                {
                    lstOfficers.Items.Add(obj);
                }
            }
            catch (Exception)
            {
                MainForm.ShowError(HotMillErrorType.DATABASE_ERROR);
                this.Close();
                return;
            }
        }
    }

    public class PressureDifferenceTotalCSVTableData
    {
        public int MaterialType;
        public int Stand;
        public int Strength;
        public int Width;

        public int[][] Data;

        public PressureDifferenceTotalCSVTableData(int materialType, int stand, int strength, int width)
        {
            this.MaterialType = materialType;
            this.Stand = stand;
            this.Strength = strength;
            this.Width = width;

            this.Data = new int[17][];
            for (int i = 0; i < Data.Length; i++)
            {
                this.Data[i] = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            }
        }
    }

    public class PressureDifferenceTotalCSVTableDataCollection : System.Collections.CollectionBase
    {
        public PressureDifferenceTotalCSVTableDataCollection()
            : base()
        {
        }

        public int Add(PressureDifferenceTotalCSVTableData value)
        {
            return List.Add(value);
        }

        public void Insert(int index, PressureDifferenceTotalCSVTableData value)
        {
            List.Insert(index, value);
        }

        public int IndexOf(PressureDifferenceTotalCSVTableData value)
        {
            return List.IndexOf(value);
        }

        public bool Contains(PressureDifferenceTotalCSVTableData value)
        {
            return List.Contains(value);
        }

        public void CopyTo(PressureDifferenceTotalCSVTableData[] value, int index)
        {
            List.CopyTo(value, index);
        }

        public void Remove(PressureDifferenceTotalCSVTableData value)
        {
            List.Remove(value);
        }
        public PressureDifferenceTotalCSVTableData[] ToArray()
        {
            PressureDifferenceTotalCSVTableData[] array = new PressureDifferenceTotalCSVTableData[List.Count];
            List.CopyTo(array, 0);
            return array;
        }
        public PressureDifferenceTotalCSVTableData this[int index]
        {
            get
            {
                return (PressureDifferenceTotalCSVTableData)List[index];
            }
            set
            {
                List[index] = value;
            }
        }
        public override string ToString()
        {
            return "PressureDifferenceTotalCSVTableDataCollection";
        }

    }

}