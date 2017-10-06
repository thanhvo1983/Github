using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Kvics.HotMill.BL;
using Kvics.Controls;

namespace Kvics.HotMill.Forms
{
    public partial class FormPresetCalculator : SubFormFullScreen
    {
        private WorkerCollection userColl;
        private bool shiftKeyDown = false;
        public int SelectedWorkerIndex = -1;
        public Label SelectedType = null;
        //private Color hightLightWorkerColor = Color.LightGreen;
        private Color nomalWorkerColor = Color.Black;

        private Color hightlightBackColor = Color.Green;//LightGreen;
        //private Color nomalBackColor = Color.Transparent;
        public bool LoadingOK = true;
        public MainForm MainForm = null;

        public event Worker_EventHandler OnWorker_Selected;
        private bool _Idle = false;

        public FormPresetCalculator()
        {
            InitializeComponent();
        }

        public bool PreloadAll()
        {
            if (this.grdData.RowCount < 1)
            {
                PresetGrid();
            }
            lblCurrentWorker.Text = "";
            try
            {
                int selectedWorkerID = -1;

                if (this.SelectedWorkerIndex > -1)
                {
                    selectedWorkerID = this.userColl[this.SelectedWorkerIndex].ID;
                }

                TWorker user = new TWorker();
                userColl = user.GetWorkerCollection();
                FillUser(shiftKeyDown);

                if (selectedWorkerID > -1)
                {
                    SelectWorker(selectedWorkerID);
                }
                else
                {
                    SelectWorkerByIndex(0);
                }

                lblType_Click(lblType_All, null);

                LoadingOK = LoadData();
            }
            catch (Exception)
            {
                LoadingOK = false;
            }

            if (!LoadingOK)
            {
                MainForm.ShowError(HotMillErrorType.DATABASE_ERROR);
            }
            return LoadingOK;
        }

        private void PresetGrid()
        {
            this.grdData.SuspendLayout();
            this.SuspendLayout();
            /*
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = this.Font;// new System.Drawing.Font(this.Font.Name, this.Font.Size, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            */
            this.grdData.RowCount = 12;
            this.grdData.ColumnCount = 9;

            Color backColor = Color.Black;//System.Drawing.SystemColors.Control;
            Color foreColor = Color.White; //System.Drawing.SystemColors.ControlText;

            for (int i = 1, size = this.grdData.ColumnCount; i < size; i++)
            {
                this.grdData[i, 0] = new KvicsDataGridViewHeaderCell();
            }
            this.grdData[0, 0] = new KvicsDataGridViewHeaderMergeCell(1, 1, backColor, foreColor);
            for (int i = 1, size = this.grdData.RowCount; i < size; i += 3)
            {
                this.grdData[0, i] = new KvicsDataGridViewHeaderMergeCell(2, 1, backColor, foreColor);
            }

            this.grdData[0, 3] = new KvicsDataGridViewHeaderCell();
            this.grdData[0, 6] = new KvicsDataGridViewHeaderCell();
            this.grdData[0, 9] = new KvicsDataGridViewHeaderCell();

            for (int i = 0, size = this.grdData.RowCount; i < size; i++)
            {
                KvicsDataGridViewHeaderCell cell = new KvicsDataGridViewHeaderCell();
                cell.ForeColor = (i % 3 == 1 ? Color.Lime : Color.Yellow);
                this.grdData[1, i] = cell;
            }

            for (int i = 2, size = this.grdData.ColumnCount; i < size; i++)
            {
                this.grdData[i, 3] = new KvicsDataGridViewHeaderCell();
                this.grdData[i, 6] = new KvicsDataGridViewHeaderCell();
                this.grdData[i, 9] = new KvicsDataGridViewHeaderCell();
            }

            grdData[0, 0].Value = "設定値";
            grdData[0, 1].Value = "圧下位置";
            grdData[0, 4].Value = "ロール速度";
            grdData[0, 7].Value = "シフト量";
            grdData[0, 10].Value = "ベンダー力";
            grdData[2, 0].Value = "Ｆ１";
            grdData[3, 0].Value = "Ｆ２";
            grdData[4, 0].Value = "Ｆ３";
            grdData[5, 0].Value = "Ｆ４";
            grdData[6, 0].Value = "Ｆ５";
            grdData[7, 0].Value = "Ｆ６";
            grdData[8, 0].Value = "Ｆ７";
            grdData[1, 1].Value = "今";
            grdData[1, 2].Value = "前";
            grdData[1, 4].Value = "今";
            grdData[1, 5].Value = "前";
            grdData[1, 7].Value = "今";
            grdData[1, 8].Value = "前";
            grdData[1, 10].Value = "今";
            grdData[1, 11].Value = "前";

            grdData.Columns[0].Width = 250;
            grdData.Columns[1].Width = 60;

            grdData.Rows[0].Height = 60;

            for (int i = 2, size = this.grdData.ColumnCount; i < size; i++)
            {
                this.grdData.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            for (int i = 2; i < this.grdData.RowCount; i+=3)
            {
                this.grdData.Rows[i-1].DefaultCellStyle.ForeColor = Color.Lime;//Color.FromArgb(255, 266, 128);
                this.grdData.Rows[i].DefaultCellStyle.ForeColor = Color.Yellow;//Color.FromArgb(255, 266, 128);
            }

            this.grdData.ResumeLayout(false);
            this.ResumeLayout(false);

            dataGridView1_Resize(null, null);
        }

        private void FormPresetCalculator_Load(object sender, EventArgs e)
        {
            PresetGrid();
            PreloadAll();
        }

        public bool LoadData()
        {
            try
            {
                if (SelectedType == lblType_All)
                {
                    T900 lastPreset = T900.GetLast();
                    T800 lastFinal = T800.GetLast();
                    T1800 lastResult = T1800.GetLast();
                    int final = 1;
                    if (lastFinal != null && lastPreset != null && lastFinal.LastUpdate.CompareTo(lastPreset.LastUpdate) > 0)
                    {
                        final = 2;
                        if (lastResult.LastUpdate.CompareTo(lastFinal.LastUpdate) > 0)
                        {
                            final = 3;
                        }
                    }
                    else if (lastResult != null && lastPreset != null && lastResult.LastUpdate.CompareTo(lastPreset.LastUpdate) > 0)
                    {
                        final = 3;
                    }

                    switch (final)
                    {
                        case 1:
                            T900 previousPreset = lastPreset == null ? null : lastPreset.GetPreviousPreset();
                            FillData(lastPreset, previousPreset);
                            lblType_Current.Text = lblType_Preset.Text;
                            break;
                        case 2:
                            //MessageBox.Show("T800");
                            T800 previousFinal = lastFinal == null ? null : lastFinal.GetPreviousFinal();
                            FillData(lastFinal, previousFinal);
                            lblType_Current.Text = lblType_Final.Text;
                            break;
                        case 3:
                            //MessageBox.Show("T1800");
                            T1800 previousResult = lastResult == null ? null : lastResult.GetPreviousResult();
                            FillData(lastResult, previousResult);
                            lblType_Current.Text = lblType_Result.Text;
                            break;
                        default:
                            break;
                    }

                    
                }
                else if (SelectedType == lblType_Preset)
                {
                    T900 lastPreset = T900.GetLast();
                    T900 previousPreset = lastPreset == null ? null : lastPreset.GetPreviousPreset();
                    FillData(lastPreset, previousPreset);
                    lblType_Current.Text = lblType_Preset.Text;
                }
                else if (SelectedType == lblType_Final)
                {
                    //MessageBox.Show("T800");

                    T800 lastFinal = T800.GetLast();
                    T800 previousFinal = lastFinal == null ? null : lastFinal.GetPreviousFinal();
                    FillData(lastFinal, previousFinal);

                    lblType_Current.Text = lblType_Final.Text;

                    //PresetGrid();
                }
                else if (SelectedType == lblType_Result)
                {
                    //MessageBox.Show("T1800");

                    T1800 lastResult = T1800.GetLast();
                    T1800 previousResult = lastResult == null ? null : lastResult.GetPreviousResult();
                    FillData(lastResult, previousResult);

                    lblType_Current.Text = lblType_Result.Text;

                    //PresetGrid();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        private void FillUser(bool shitf)
        {
            lblWorker01.Text = "";
            lblWorker02.Text = "";
            lblWorker03.Text = "";
            lblWorker04.Text = "";
            lblWorker05.Text = "";
            lblWorker06.Text = "";
            lblWorker07.Text = "";
            lblWorker08.Text = "";
            lblWorker09.Text = "";
            lblWorker10.Text = "";
            lblWorker11.Text = "";
            lblWorker12.Text = "";

            switch ((SelectedWorkerIndex % 12) + 1)
            {
                case 12:
                    lblWorker12.BackColor = nomalWorkerColor;
                    break;
                case 11:
                    lblWorker11.BackColor = nomalWorkerColor;
                    break;
                case 10:
                    lblWorker10.BackColor = nomalWorkerColor;
                    break;
                case 9:
                    lblWorker09.BackColor = nomalWorkerColor;
                    break;
                case 8:
                    lblWorker08.BackColor = nomalWorkerColor;
                    break;
                case 7:
                    lblWorker07.BackColor = nomalWorkerColor;
                    break;
                case 6:
                    lblWorker06.BackColor = nomalWorkerColor;
                    break;
                case 5:
                    lblWorker05.BackColor = nomalWorkerColor;
                    break;
                case 4:
                    lblWorker04.BackColor = nomalWorkerColor;
                    break;
                case 3:
                    lblWorker03.BackColor = nomalWorkerColor;
                    break;
                case 2:
                    lblWorker02.BackColor = nomalWorkerColor;
                    break;
                case 1:
                    lblWorker01.BackColor = nomalWorkerColor;
                    break;
                default:
                    break;
            }

            if (userColl != null)
            {
                if (!shitf)
                {
                    int tempCount = userColl.Count;
                    tempCount = tempCount > 12 ? 12 : tempCount;
                    switch (tempCount)
                    {
                        case 12:
                            lblWorker12.Text = userColl[11].Name + " (F12)";
                            goto case 11;
                        case 11:
                            lblWorker11.Text = userColl[10].Name + " (F11)";
                            goto case 10;
                        case 10:
                            lblWorker10.Text = userColl[9].Name + " (F10)";
                            goto case 9;
                        case 9:
                            lblWorker09.Text = userColl[8].Name + " (F9)";
                            goto case 8;
                        case 8:
                            lblWorker08.Text = userColl[7].Name + " (F8)";
                            goto case 7;
                        case 7:
                            lblWorker07.Text = userColl[6].Name + " (F7)";
                            goto case 6;
                        case 6:
                            lblWorker06.Text = userColl[5].Name + " (F6)";
                            goto case 5;
                        case 5:
                            lblWorker05.Text = userColl[4].Name + " (F5)";
                            goto case 4;
                        case 4:
                            lblWorker04.Text = userColl[3].Name + " (F4)";
                            goto case 3;
                        case 3:
                            lblWorker03.Text = userColl[2].Name + " (F3)";
                            goto case 2;
                        case 2:
                            lblWorker02.Text = userColl[1].Name + " (F2)";
                            goto case 1;
                        case 1:
                            lblWorker01.Text = userColl[0].Name + " (F1)";
                            break;
                        default:
                            break;
                    }

                    switch (SelectedWorkerIndex + 1)
                    {
                        case 12:
                            lblWorker12.BackColor = hightlightBackColor;
                            break;
                        case 11:
                            lblWorker11.BackColor = hightlightBackColor;
                            break;
                        case 10:
                            lblWorker10.BackColor = hightlightBackColor;
                            break;
                        case 9:
                            lblWorker09.BackColor = hightlightBackColor;
                            break;
                        case 8:
                            lblWorker08.BackColor = hightlightBackColor;
                            break;
                        case 7:
                            lblWorker07.BackColor = hightlightBackColor;
                            break;
                        case 6:
                            lblWorker06.BackColor = hightlightBackColor;
                            break;
                        case 5:
                            lblWorker05.BackColor = hightlightBackColor;
                            break;
                        case 4:
                            lblWorker04.BackColor = hightlightBackColor;
                            break;
                        case 3:
                            lblWorker03.BackColor = hightlightBackColor;
                            break;
                        case 2:
                            lblWorker02.BackColor = hightlightBackColor;
                            break;
                        case 1:
                            lblWorker01.BackColor = hightlightBackColor;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    int tempCount = userColl.Count;
                    tempCount = tempCount > 24 ? 24 : tempCount;
                    switch (tempCount)
                    {
                        case 24:
                            lblWorker12.Text = userColl[23].Name + " (F12)";
                            goto case 23;
                        case 23:
                            lblWorker11.Text = userColl[22].Name + " (F11)";
                            goto case 22;
                        case 22:
                            lblWorker10.Text = userColl[21].Name + " (F10)";
                            goto case 21;
                        case 21:
                            lblWorker09.Text = userColl[20].Name + " (F9)";
                            goto case 20;
                        case 20:
                            lblWorker08.Text = userColl[19].Name + " (F8)";
                            goto case 19;
                        case 19:
                            lblWorker07.Text = userColl[18].Name + " (F7)";
                            goto case 18;
                        case 18:
                            lblWorker06.Text = userColl[17].Name + " (F6)";
                            goto case 17;
                        case 17:
                            lblWorker05.Text = userColl[16].Name + " (F5)";
                            goto case 16;
                        case 16:
                            lblWorker04.Text = userColl[15].Name + " (F4)";
                            goto case 15;
                        case 15:
                            lblWorker03.Text = userColl[14].Name + " (F3)";
                            goto case 14;
                        case 14:
                            lblWorker02.Text = userColl[13].Name + " (F2)";
                            goto case 13;
                        case 13:
                            lblWorker01.Text = userColl[12].Name + " (F1)";
                            break;
                        default:
                            break;
                    }

                    switch (SelectedWorkerIndex - 12 + 1)
                    {
                        case 12:
                            lblWorker12.BackColor = hightlightBackColor;
                            break;
                        case 11:
                            lblWorker11.BackColor = hightlightBackColor;
                            break;
                        case 10:
                            lblWorker10.BackColor = hightlightBackColor;
                            break;
                        case 9:
                            lblWorker09.BackColor = hightlightBackColor;
                            break;
                        case 8:
                            lblWorker08.BackColor = hightlightBackColor;
                            break;
                        case 7:
                            lblWorker07.BackColor = hightlightBackColor;
                            break;
                        case 6:
                            lblWorker06.BackColor = hightlightBackColor;
                            break;
                        case 5:
                            lblWorker05.BackColor = hightlightBackColor;
                            break;
                        case 4:
                            lblWorker04.BackColor = hightlightBackColor;
                            break;
                        case 3:
                            lblWorker03.BackColor = hightlightBackColor;
                            break;
                        case 2:
                            lblWorker02.BackColor = hightlightBackColor;
                            break;
                        case 1:
                            lblWorker01.BackColor = hightlightBackColor;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void FillData(T900 presetCurrent, T900 presetPre)
        {
            ResetData();
            lblFDTlbl.Text = "ＦＤＴ指令";
            if (presetCurrent != null)
            {
                lblCoilNo.Text = presetCurrent.R025.Trim();
                lblThick.Text = (presetCurrent.R167 * 0.01).ToString("0.00;-0.00;0.00");
                lblWidth.Text = (presetCurrent.R165).ToString();
                lblSteel.Text = presetCurrent.R071.Trim();
                lblThickRafuba.Text = (presetCurrent.R163 * 0.01).ToString("0.00;-0.00;0.00");
                lblRDT.Text = (presetCurrent.R121 * 0.1).ToString("0.0;-0.0;0.0");
                lblFDT.Text = (presetCurrent.R119 * 0.1).ToString("0.0;-0.0;0.0");

                Int16[] cu_391 = presetCurrent.R391.Rows;
                Int16[] cu_197 = presetCurrent.R197.Rows;
                Int16[] cu_433 = presetCurrent.R433.Rows;
                Int16[] cu_447 = presetCurrent.R447.Rows;
                for (int i = 0; i < 7; i++)
                {
                    this.grdData[i + 2, 1].Value = (cu_391[i] * 0.01).ToString("0.00;-0.00;0.00");
                    this.grdData[i + 2, 4].Value = (cu_197[i] * 0.1).ToString("0.0;-0.0;0.0");
                    this.grdData[i + 2, 7].Value = (cu_433[i]);
                    this.grdData[i + 2, 10].Value = (cu_447[i]);
                }
                if (presetPre != null)
                {
                    Int16[] pre_391 = presetPre.R391.Rows;
                    Int16[] pre_197 = presetPre.R197.Rows;
                    Int16[] pre_433 = presetPre.R433.Rows;
                    Int16[] pre_447 = presetPre.R447.Rows;

                    for (int i = 0; i < 7; i++)
                    {
                        this.grdData[i + 2, 2].Value = (pre_391[i] * 0.01).ToString("0.00;-0.00;0.00");
                        this.grdData[i + 2, 5].Value = (pre_197[i] * 0.1).ToString("0.0;-0.0;0.0");
                        this.grdData[i + 2, 8].Value = (pre_433[i]);
                        this.grdData[i + 2, 11].Value = (pre_447[i]);
                    }
                }
            }
        }

        private void FillData(T800 finalCurrent, T800 finalPre)
        {
            ResetData();
            lblFDTlbl.Text = "ＦＤＴ指令";
            if (finalCurrent != null)
            {
                lblCoilNo.Text = finalCurrent.R025.Trim();
                lblThick.Text = (finalCurrent.R119 * 0.01).ToString("0.00;-0.00;0.00");
                lblWidth.Text = (finalCurrent.R117).ToString();
                lblSteel.Text = finalCurrent.R073.Trim();
                lblThickRafuba.Text = (finalCurrent.R115 * 0.01).ToString("0.00;-0.00;0.00");
                lblRDT.Text = (finalCurrent.R073_1 * 0.1).ToString("0.0;-0.0;0.0");
                lblFDT.Text = (finalCurrent.R071 * 0.1).ToString("0.0;-0.0;0.0");

                Int16[] cu_343 = finalCurrent.R343.Rows;
                Int16[] cu_149 = finalCurrent.R149.Rows;
                Int16[] cu_385 = finalCurrent.R385.Rows;
                Int16[] cu_413 = finalCurrent.R413.Rows;
                for (int i = 0; i < 7; i++)
                {
                    this.grdData[i + 2, 1].Value = (cu_343[i] * 0.01).ToString("0.00;-0.00;0.00");
                    this.grdData[i + 2, 4].Value = (cu_149[i] * 0.1).ToString("0.0;-0.0;0.0");
                    this.grdData[i + 2, 7].Value = (cu_385[i]);
                    this.grdData[i + 2, 10].Value = (cu_413[i]);
                }
                if (finalPre != null)
                {
                    Int16[] pre_343 = finalPre.R343.Rows;
                    Int16[] pre_149 = finalPre.R149.Rows;
                    Int16[] pre_385 = finalPre.R385.Rows;
                    Int16[] pre_413 = finalPre.R413.Rows;

                    for (int i = 0; i < 7; i++)
                    {
                        this.grdData[i + 2, 2].Value = (pre_343[i] * 0.01).ToString("0.00;-0.00;0.00");
                        this.grdData[i + 2, 5].Value = (pre_149[i] * 0.1).ToString("0.0;-0.0;0.0");
                        this.grdData[i + 2, 8].Value = (pre_385[i]);
                        this.grdData[i + 2, 11].Value = (pre_413[i]);
                    }
                }
            }
        }

        private void FillData(T1800 resultCurrent, T1800 resultPre)
        {
            ResetData();
            lblFDTlbl.Text = "ＦＤＴ実績";
            if (resultCurrent != null)
            {
                lblCoilNo.Text = resultCurrent.R0025.Trim();
                lblThick.Text = (resultCurrent.R0095 * 0.01).ToString("0.00;-0.00;0.00");
                lblWidth.Text = (resultCurrent.R0093).ToString();
                lblSteel.Text = resultCurrent.R0073.Trim();
                lblThickRafuba.Text = (resultCurrent.R0091 * 0.01).ToString("0.00;-0.00;0.00");
                //lblRDT.Text = (resultCurrent.R121 * 0.1).ToString();
                lblFDT.Text = (resultCurrent.R0071 * 0.1).ToString("0.0;-0.0;0.0");

                Int16[] cu_0195 = resultCurrent.R0195.Rows;
                Int16[] cu_0125 = resultCurrent.R0125.Rows;
                Int16[] cu_0223 = resultCurrent.R0223.Rows;
                Int16[] cu_0251 = resultCurrent.R0251.Rows;
                for (int i = 0; i < 7; i++)
                {
                    this.grdData[i + 2, 1].Value = (cu_0195[i * 2] * 0.01).ToString("0.00;-0.00;0.00");
                    this.grdData[i + 2, 4].Value = (cu_0125[i] * 0.1).ToString("0.0;-0.0;0.0");
                    this.grdData[i + 2, 7].Value = (cu_0223[i]);
                    this.grdData[i + 2, 10].Value = (cu_0251[i * 2]);
                }
                if (resultPre != null)
                {
                    Int16[] pre_0195 = resultPre.R0195.Rows;
                    Int16[] pre_0125 = resultPre.R0125.Rows;
                    Int16[] pre_0223 = resultPre.R0223.Rows;
                    Int16[] pre_0251 = resultPre.R0251.Rows;

                    for (int i = 0; i < 7; i++)
                    {
                        this.grdData[i + 2, 2].Value = (pre_0195[i * 2] * 0.01).ToString("0.00;-0.00;0.00");
                        this.grdData[i + 2, 5].Value = (pre_0125[i] * 0.1).ToString("0.0;-0.0;0.0");
                        this.grdData[i + 2, 8].Value = (pre_0223[i]);
                        this.grdData[i + 2, 11].Value = (pre_0251[i * 2]);
                    }
                }
            }
        }

        private void ResetData()
        {
            this.tableLayoutPanel1.SuspendLayout();
            this.grdData.SuspendLayout();
            this.SuspendLayout();

            lblCoilNo.Text = "";
            lblThick.Text = "";
            lblWidth.Text = "";
            lblSteel.Text = "";
            lblThickRafuba.Text = "";
            lblRDT.Text = "";
            lblFDT.Text = "";

            for (int i = 1, length1 = this.grdData.Rows.Count; i < length1; i++)
            {
                for (int j = 2, length2 = this.grdData.ColumnCount; j < length2; j++)
                {
                    this.grdData[j, i].Value = "";
                }
            }

            this.tableLayoutPanel1.ResumeLayout(false);
            this.grdData.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        public void SelectWorker(int workerID)
        {
            if (_Idle || userColl == null)
            {
                return;
            }
            for (int i = 0; i < userColl.Count; i++)
            {
                if (userColl[i].ID == workerID)
                {
                    SelectWorkerByIndex(i);
                    return;
                }
            }
        }

        private void SelectWorkerByIndex(int index)
        {
            if (userColl != null && userColl.Count > (index + (shiftKeyDown ? 12 : 0)))
            {
                switch ((SelectedWorkerIndex % 12) + 1)
                {
                    case 12:
                        lblWorker12.BackColor = nomalWorkerColor;
                        break;
                    case 11:
                        lblWorker11.BackColor = nomalWorkerColor;
                        break;
                    case 10:
                        lblWorker10.BackColor = nomalWorkerColor;
                        break;
                    case 9:
                        lblWorker09.BackColor = nomalWorkerColor;
                        break;
                    case 8:
                        lblWorker08.BackColor = nomalWorkerColor;
                        break;
                    case 7:
                        lblWorker07.BackColor = nomalWorkerColor;
                        break;
                    case 6:
                        lblWorker06.BackColor = nomalWorkerColor;
                        break;
                    case 5:
                        lblWorker05.BackColor = nomalWorkerColor;
                        break;
                    case 4:
                        lblWorker04.BackColor = nomalWorkerColor;
                        break;
                    case 3:
                        lblWorker03.BackColor = nomalWorkerColor;
                        break;
                    case 2:
                        lblWorker02.BackColor = nomalWorkerColor;
                        break;
                    case 1:
                        lblWorker01.BackColor = nomalWorkerColor;
                        break;
                    default:
                        break;
                }

                SelectedWorkerIndex = (index + (shiftKeyDown ? 12 : 0));

                if (this.OnWorker_Selected != null)
                {
                    _Idle = true;
                    this.OnWorker_Selected(this, new WorkerEventArgs(new TWorker(userColl[SelectedWorkerIndex].ID)));
                    _Idle = false;
                }

                //if (this.MainForm != null)
                //{
                //    try
                //    {
                //        TWorker worker = new TWorker(userColl[SelectedWorkerIndex].ID);
                //        this.MainForm.OnWorker_Changed(worker);
                //    }
                //    catch (Exception ex)
                //    {
                //        Console.WriteLine(ex.Message);
                //    }
                //}

                lblCurrentWorker.Text = userColl[SelectedWorkerIndex].Name;

                switch ((SelectedWorkerIndex % 12) + 1)
                {
                    case 12:
                        lblWorker12.BackColor = hightlightBackColor;
                        break;
                    case 11:
                        lblWorker11.BackColor = hightlightBackColor;
                        break;
                    case 10:
                        lblWorker10.BackColor = hightlightBackColor;
                        break;
                    case 9:
                        lblWorker09.BackColor = hightlightBackColor;
                        break;
                    case 8:
                        lblWorker08.BackColor = hightlightBackColor;
                        break;
                    case 7:
                        lblWorker07.BackColor = hightlightBackColor;
                        break;
                    case 6:
                        lblWorker06.BackColor = hightlightBackColor;
                        break;
                    case 5:
                        lblWorker05.BackColor = hightlightBackColor;
                        break;
                    case 4:
                        lblWorker04.BackColor = hightlightBackColor;
                        break;
                    case 3:
                        lblWorker03.BackColor = hightlightBackColor;
                        break;
                    case 2:
                        lblWorker02.BackColor = hightlightBackColor;
                        break;
                    case 1:
                        lblWorker01.BackColor = hightlightBackColor;
                        break;
                    default:
                        break;
                }

                //FillUser(shiftKeyDown);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.NumPad0:
                    lblType_Click(lblType_All, null);
                    break;
                case Keys.NumPad1:
                    lblType_Click(lblType_Preset, null);
                    break;
                case Keys.NumPad2:
                    lblType_Click(lblType_Final, null);
                    break;
                case Keys.NumPad3:
                    lblType_Click(lblType_Result, null);
                    break;
                default:
                    break;
            }
            if (keyData == Keys.F10)
            {
                KeyDown_Process(keyData);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected void KeyDown_Process(Keys keyData)
        {
            if (keyData == Keys.ShiftKey)
            {
                if (!shiftKeyDown)
                {
                    shiftKeyDown = true;
                    FillUser(shiftKeyDown);
                }
            }
            else
            {
                switch (keyData)
                {
                    case Keys.F1:
                        SelectWorkerByIndex(0);
                        break;
                    case Keys.F2:
                        SelectWorkerByIndex(1);
                        break;
                    case Keys.F3:
                        SelectWorkerByIndex(2);
                        break;
                    case Keys.F4:
                        SelectWorkerByIndex(3);
                        break;
                    case Keys.F5:
                        SelectWorkerByIndex(4);
                        break;
                    case Keys.F6:
                        SelectWorkerByIndex(5);
                        break;
                    case Keys.F7:
                        SelectWorkerByIndex(6);
                        break;
                    case Keys.F8:
                        SelectWorkerByIndex(7);
                        break;
                    case Keys.F9:
                        SelectWorkerByIndex(8);
                        break;
                    case Keys.F10:
                        SelectWorkerByIndex(9);
                        break;
                    case Keys.F11:
                        SelectWorkerByIndex(10);
                        break;
                    case Keys.F12:
                        SelectWorkerByIndex(11);
                        break;
                    default:
                        break;
                }
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            KeyDown_Process(e.KeyCode);
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                if (shiftKeyDown)
                {
                    shiftKeyDown = false;
                    FillUser(shiftKeyDown);
                }
            }
            base.OnKeyUp(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void dataGridView1_Resize(object sender, EventArgs e)
        {
            if (this.grdData.ColumnCount < 1)
            {
                return;
            }
            if (this.Width < 200)
            {
                return;
            }
            this.grdData.SuspendLayout();
            this.SuspendLayout();

            int verticalScrollBarWidth = 0;
            int innerGridHeight = 0;

            for (int i = 0, length = this.grdData.Rows.Count; i < length; i++)
            {
                innerGridHeight += this.grdData.Rows[i].Height;
            }

            if (innerGridHeight > this.grdData.Height)
            {
                verticalScrollBarWidth = System.Windows.Forms.SystemInformation.VerticalScrollBarWidth;
            }
            int cellWidth = this.grdData.Width
                - this.grdData.Columns[0].Width
                - this.grdData.Columns[1].Width
                - verticalScrollBarWidth;

            cellWidth = Convert.ToInt32(cellWidth / 7);

            if (cellWidth * 7 + this.grdData.Columns[0].Width
                + this.grdData.Columns[1].Width
                + verticalScrollBarWidth
                > this.grdData.Width)
            {
                cellWidth -= 1;
            }

            for (int i = 2, size = this.grdData.ColumnCount; i < size; i++)
            {
                this.grdData.Columns[i].Width = cellWidth;
            }

            int innerGridWidth = 0;

            for (int i = 1, size = grdData.ColumnCount; i < size; i++)
            {
                innerGridWidth += grdData.Columns[i].Width;
            }

            grdData.Columns[0].Width = grdData.Width - 2 - innerGridWidth - verticalScrollBarWidth;

            //if (this.grdData.Height != innerGridHeight + 2)
            //{
            //    //this.grdData.Height = innerGridHeight + 2;

            //    //int tableLayoutPanel2_Top = tableLayoutPanel2.Top;
            //    //this.tableLayoutPanel2.Top = this.grdData.Bottom + 2*(this.grdData.Top - (this.tableLayoutPanel4.Location.Y + this.tableLayoutPanel4.Height));
            //    //this.label96.Top = this.tableLayoutPanel2.Top - Convert.ToInt32(this.label96.Height / 2);
            //    //this.panel12.Top = this.tableLayoutPanel2.Bottom + (this.grdData.Top - (this.tableLayoutPanel4.Location.Y + this.tableLayoutPanel4.Height));
            //    //this.Height += tableLayoutPanel2.Top - tableLayoutPanel2_Top;

            //    //this.panel1.Height = innerGridHeight + 2;

            //    //int tableLayoutPanel2_Top = tableLayoutPanel2.Top;
            //    //this.tableLayoutPanel2.Top = this.panel1.Bottom + 2 * (this.panel1.Top - (this.tableLayoutPanel4.Location.Y + this.tableLayoutPanel4.Height));
            //    //this.label96.Top = this.tableLayoutPanel2.Top - Convert.ToInt32(this.label96.Height / 2);
            //    //this.panel12.Top = this.tableLayoutPanel2.Bottom + (this.panel1.Top - (this.tableLayoutPanel4.Location.Y + this.tableLayoutPanel4.Height));
            //    //this.Height += tableLayoutPanel2.Top - tableLayoutPanel2_Top;
            //}

            //this.tbWarning.Top = this.tableLayoutPanel4.Top; 
            //this.tbWarning.Height += this.grdData.Bottom - this.tbWarning.Bottom;

            this.grdData.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            this.OnKeyDown(e);
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            this.OnKeyUp(e);
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            Point topleft = new Point(0, 0);
            Point topright = new Point(this.grdData.Width - 1, 0);
            Point bottomleft = new Point(0, this.grdData.Height - 1);
            Point bottomfight = new Point(this.grdData.Width - 1, this.grdData.Height - 1);

            e.Graphics.DrawLines(new Pen(this.grdData.GridColor), new Point[] { topleft, topright, bottomfight, bottomleft, topleft });
        }

        private void FormPresetCalculator_Resize(object sender, EventArgs e)
        {
            //int childWidth = this.ClientSize.Width - 2 * this.grdData.Left;
            //this.grdData.Width = this.tableLayoutPanel2.Width = this.tableLayoutPanel4.Width = childWidth;
        }

        private void lblWorker_Click(object sender, EventArgs e)
        {
            if (sender is Label)
            {
                Label workerLabel = (Label)sender;
                string lblIDStr = workerLabel.Name.Substring(workerLabel.Name.Length - 2);
                try
                {
                    int lblID = Convert.ToInt32(lblIDStr);
                    SelectWorkerByIndex(lblID - 1);
                }
                catch (Exception)
                {
                }
            }
        }

        private void lblType_Click(object sender, EventArgs e)
        {
            if (sender is Label)
            {
                if (SelectedType != null)
                {
                    SelectedType.BackColor = nomalWorkerColor;
                }
                Label typeLabel = (Label)sender;
                typeLabel.BackColor = hightlightBackColor;

                if (typeLabel != SelectedType)
                {
                    SelectedType = typeLabel;
                    LoadData();
                }
                /*
                if (SelectedType == lblType_All)
                {
                    
                }
                else if (SelectedType == lblType_Preset)
                {
                    
                }
                else if (SelectedType == lblType_Final)
                {

                }
                else if (SelectedType == lblType_Result)
                {

                }
                 */
                //string lblIDStr = typeLabel.Name.Substring(typeLabel.Name.Length - 2);
                //try
                //{
                //    int lblID = Convert.ToInt32(lblIDStr);
                //    SelectWorkerByIndex(lblID - 1);
                //}
                //catch (Exception)
                //{
                //}
            }
        }

        public int GetSelectedWorkerID()
        {
            return SelectedWorkerIndex > -1 ? userColl[SelectedWorkerIndex].ID : 0;
        }
    }
}