using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Kvics.HotMill.BL;
using Kvics.Controls;
using Kvics.Controls.Chart;

using log4net;
using log4net.Config;

namespace Kvics.HotMill.Forms
{
    public partial class FormFinishSupport2 : SubFormFullScreen
    {
        private static readonly ILog log = Kvics.DBAccess.Log.Instance.GetLogger(typeof(FormFinishSupport2));

        private Color _NomalWorkerBackColor = Color.Black;
        private Color _HightlightWorkerBackColor = Color.Green;
        private Label[] _lblWorkerList = new Label[24];
        private int _SelectedWorkerIndex = 0;
        private int _SelectedWorkerID = -1;
        private WorkerCollection _UserColl = null;

        public event Worker_EventHandler OnWorker_Selected;
        //public event FormFinishSupport_KeyEventHandler OnPuPd_Press;
        private bool _Idle = false;
        private bool _IsLoading = true;

        public FormFinishSupport2()
        {
            InitializeComponent();
        }

        public int SelectedWorkerID
        {
            set
            {
                _SelectedWorkerID = value;
            }
        }

        public void PreloadAll()
        {
            _lblWorkerList[0] = lblWorker01;
            _lblWorkerList[1] = lblWorker02;
            _lblWorkerList[2] = lblWorker03;
            _lblWorkerList[3] = lblWorker04;
            _lblWorkerList[4] = lblWorker05;
            _lblWorkerList[5] = lblWorker06;
            _lblWorkerList[6] = lblWorker07;
            _lblWorkerList[7] = lblWorker08;
            _lblWorkerList[8] = lblWorker09;
            _lblWorkerList[9] = lblWorker10;
            _lblWorkerList[10] = lblWorker11;
            _lblWorkerList[11] = lblWorker12;
            _lblWorkerList[12] = lblWorker13;
            _lblWorkerList[13] = lblWorker14;
            _lblWorkerList[14] = lblWorker15;
            _lblWorkerList[15] = lblWorker16;
            _lblWorkerList[16] = lblWorker17;
            _lblWorkerList[17] = lblWorker18;
            _lblWorkerList[18] = lblWorker19;
            _lblWorkerList[19] = lblWorker20;
            _lblWorkerList[20] = lblWorker21;
            _lblWorkerList[21] = lblWorker22;
            _lblWorkerList[22] = lblWorker23;
            _lblWorkerList[23] = lblWorker24;

            for (int i = 0; i < _lblWorkerList.Length; i++)
            {
                Label lbl = _lblWorkerList[i];
                lbl.Click += new EventHandler(lblWorker_Click);
            }

            try
            {
                TWorker user = new TWorker();
                _UserColl = user.GetWorkerCollection();
            }
            catch (Exception)
            {
                MainForm.ShowError(HotMillErrorType.DATABASE_ERROR);
                this.Close();
                return;
            }

            ResetAll();

            FillUser();

            PresetGrid(this.grdData1);
            PresetGrid(this.grdData2);
            PresetGrid(this.grdData3);

            //LoadTempChart1Data(this.lineChart1);
            //LoadTempChart2Data(this.lineChart2);
            //LoadTempChart3Data(this.lineChart3);
            //LoadTempChart4Data(this.lineChart4);
            //LoadTempChart5Data(this.lineChart5);

            this.chtT800_1.Legend.SampeSize = new Size(40, 15);
            this.chtT900_1.Legend.SampeSize = new Size(40, 15);
            this.chtT1800_1.Legend.SampeSize = new Size(40, 15);

            try
            {
                TConfig config = new TConfig(TConfig.FINISHSUPPORTFORM_MAX);
                if (config.ID > 0)
                {
                    this.chtMulti.Max1 = Double.Parse(config.Value);
                    this.chtMulti.Ranger1 = this.chtMulti.Max1 / 5.0;
                }
            }
            catch (Exception ex)
            {
                log.Error("Loag config error. Detail:", ex);
                this.chtMulti.Max1 = 1000;
                this.chtMulti.Ranger1 = this.chtMulti.Max1 / 5.0;
            }

            LoadData(DataPackages.Preset);
            LoadData(DataPackages.FinalSet);
            LoadData(DataPackages.Result);

            _IsLoading = false;
        }

        private void ResetAll()
        {
            lblT1800_CoilNo.Text = "";
            lblT1800_Gamen131.Text = "";
            lblT1800_SteelName.Text = "";
            lblT1800_Thick.Text = "";
            lblT1800_Width.Text = "";
            lblT800_CoilNo.Text = "";
            lblT800_Gamen077.Text = "";
            lblT800_SteelName.Text = "";
            lblT800_Thick.Text = "";
            lblT800_Width.Text = "";
            lblT900_CoilNo.Text = "";
            lblT900_Gamen002.Text = "";
            lblT900_SteelName.Text = "";
            lblT900_Thick.Text = "";
            lblT900_Width.Text = "";
        }

        private void PresetGrid(DataGridView grdPreset)
        {
            if (grdPreset == null)
            {
                return;
            }
            grdPreset.SuspendLayout();
            this.SuspendLayout();
            
            grdPreset.RowCount = 14;
            grdPreset.ColumnCount = 9;

            grdPreset.Columns[0].Width = 60;
            grdPreset.Columns[1].Width = 30;

            Color backColor = grdPreset.BackgroundColor;
            Color foreColor = grdPreset.ForeColor;

            grdPreset[0, 0] = new KvicsDataGridViewTextBoxMergeCell(1, 2, backColor, foreColor);
            grdPreset[0, 1] = new KvicsDataGridViewTextBoxMergeCell(2, 1, backColor, foreColor);
            grdPreset[0, 3] = new KvicsDataGridViewTextBoxMergeCell(1, 2, backColor, Color.LightCoral, H_Align.Right, V_Align.Middle);
            grdPreset[0, 4] = new KvicsDataGridViewTextBoxMergeCell(2, 1, backColor, foreColor);
            grdPreset[0, 6] = new KvicsDataGridViewTextBoxMergeCell(1, 2, backColor, Color.LightCoral, H_Align.Right, V_Align.Middle);
            grdPreset[0, 7] = new KvicsDataGridViewTextBoxMergeCell(2, 1, backColor, foreColor);
            grdPreset[0, 9] = new KvicsDataGridViewTextBoxMergeCell(2, 1, backColor, foreColor);
            grdPreset[0, 11] = new KvicsDataGridViewTextBoxMergeCell(1, 2, backColor, foreColor);
            grdPreset[0, 12] = new KvicsDataGridViewTextBoxMergeCell(2, 1, backColor, foreColor);
            for (int i = 2, size = grdPreset.ColumnCount; i < size; i++)
            {
                grdPreset[i, 0] = new KvicsDataGridViewTextBoxMergeCell(1, 1, backColor, foreColor, H_Align.Center, V_Align.Middle);
                grdPreset[i, 11] = new KvicsDataGridViewTextBoxMergeCell(1, 1, backColor, foreColor, H_Align.Center, V_Align.Middle);
            }
            grdPreset[grdPreset.ColumnCount-1, 11] = new KvicsDataGridViewTextBoxMergeCell(3, 1, backColor, foreColor, H_Align.Center, V_Align.Middle);

            grdPreset[0, 0].Value = "";
            grdPreset[0, 1].Value = "Screw";
            grdPreset[0, 3].Value = "ÉWÉÉÉìÉv";
            grdPreset[0, 4].Value = "Speed";
            grdPreset[0, 6].Value = "ÉWÉÉÉìÉv";
            grdPreset[0, 7].Value = "WRS";
            grdPreset[0, 9].Value = "WRB";
            grdPreset[0, 11].Value = "";
            grdPreset[0, 12].Value = "í£óÕ";

            grdPreset[2, 0].Value = "ÇeÇP";
            grdPreset[3, 0].Value = "ÇeÇQ";
            grdPreset[4, 0].Value = "ÇeÇR";
            grdPreset[5, 0].Value = "ÇeÇS";
            grdPreset[6, 0].Value = "ÇeÇT";
            grdPreset[7, 0].Value = "ÇeÇU";
            grdPreset[8, 0].Value = "ÇeÇV";

            grdPreset[2, 11].Value = "F1-F2";
            grdPreset[3, 11].Value = "F2-F3";
            grdPreset[4, 11].Value = "F3-F4";
            grdPreset[5, 11].Value = "F4-F5";
            grdPreset[6, 11].Value = "F5-F6";
            grdPreset[7, 11].Value = "F6-F7";
            grdPreset[8, 11].Value = "";
            
            grdPreset.Rows[1].DefaultCellStyle.ForeColor = Color.Yellow;
            grdPreset.Rows[4].DefaultCellStyle.ForeColor = Color.Yellow;
            grdPreset.Rows[7].DefaultCellStyle.ForeColor = Color.Yellow;
            grdPreset.Rows[9].DefaultCellStyle.ForeColor = Color.Yellow;
            grdPreset.Rows[12].DefaultCellStyle.ForeColor = Color.Yellow;

            grdPreset.Rows[2].DefaultCellStyle.ForeColor = Color.Cyan;
            grdPreset.Rows[5].DefaultCellStyle.ForeColor = Color.Cyan;
            grdPreset.Rows[8].DefaultCellStyle.ForeColor = Color.Cyan;
            grdPreset.Rows[10].DefaultCellStyle.ForeColor = Color.Cyan;
            grdPreset.Rows[13].DefaultCellStyle.ForeColor = Color.Cyan;

            grdPreset.Rows[3].DefaultCellStyle.ForeColor = Color.LightCoral;
            grdPreset.Rows[6].DefaultCellStyle.ForeColor = Color.LightCoral;

            int[] rIn = new int[] { 1, 2, 4, 5, 7, 8, 9, 10, 12, 13 };

            for (int i = 0; i < rIn.Length; i++)
            {
                grdPreset[1, rIn[i]] = new KvicsDataGridViewTextBoxMergeCell(1, 1, grdPreset.Rows[rIn[i]].DefaultCellStyle.BackColor, grdPreset.Rows[rIn[i]].DefaultCellStyle.ForeColor, H_Align.Center, V_Align.Middle);
                grdPreset[1, rIn[i]].Value = i % 2 == 0 ? "ç°" : "ëO";
            }

            for (int i = 2, size = grdPreset.ColumnCount; i < size; i++)
            {
                grdPreset.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            grdPreset.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grid_KeyDown);

            // Load temp data
            //LoadTempData(grdPreset);

            grdPreset.ResumeLayout(false);
            this.ResumeLayout(false);

            Grid_Resize(grdPreset, null);
        }

        //private void LoadTempChart1Data(CustomChart chart)
        //{
        //    //chart.Series.Add(
        //    LineSeries sr = new LineSeries();
        //    sr.Name = "å˙Ç›";
        //    sr.Marker.Style = MarkerStyle.VUONG;
        //    sr.Marker.Size = 4;
        //    sr.Color = sr.Marker.BackColor = sr.Marker.ForeColor = Color.Fuchsia;
        //    sr.Size = 1;
            
        //    Random rd = new Random();
        //    for (int i = 0; i < 101; i++)
        //    {
        //        sr.Values.Add(rd.Next(15) + 9);
        //    }
        //    chart.ValueAxis1.LineSeries.Add(sr);

        //    sr = new LineSeries();
        //    sr.Name = "ïù";
        //    sr.MarkerStyle = MarkerStyle.Thoi;
        //    sr.MarkerSize = 6;
        //    sr.Color = sr.MarkerBackColor = sr.MarkerForeColor = Color.Cyan;
        //    sr.Size = 1;

        //    for (int i = 0; i < 101; i++)
        //    {
        //        sr.Values.Add(rd.Next(15) + 1);
        //    }
        //    chart.Series.Add(sr);
        //}

        //private void LoadTempChart2Data(CustomChart chart)
        //{
        //    //chart.Series.Add(
        //    LineSeries sr = null;
        //    Random rd = new Random();

        //    sr = new LineSeries();
        //    sr.Name = "ó\îı";
        //    sr.MarkerStyle = MarkerStyle.Thoi;
        //    sr.MarkerSize = 6;
        //    sr.Color = sr.MarkerBackColor = sr.MarkerForeColor = Color.Cyan;
        //    sr.Size = 1;

        //    for (int i = 0; i < 101; i++)
        //    {
        //        sr.Values.Add(rd.Next(500) + 450);
        //    }
        //    chart.Series.Add(sr);

        //    sr = new LineSeries();
        //    sr.Name = "ê›íË";
        //    sr.MarkerStyle = MarkerStyle.Vuong;
        //    sr.MarkerSize = 4;
        //    sr.Color = sr.MarkerBackColor = sr.MarkerForeColor = Color.Fuchsia;
        //    sr.Size = 1;

        //    for (int i = 0; i < 101; i++)
        //    {
        //        sr.Values.Add(rd.Next(500) + 50);
        //    }
        //    chart.Series.Add(sr);

        //    sr = new LineSeries();
        //    sr.Name = "é¿ê—";
        //    sr.MarkerStyle = MarkerStyle.TamGiac;
        //    sr.MarkerSize = 6;
        //    sr.Color = sr.MarkerBackColor = sr.MarkerForeColor = Color.Yellow;
        //    sr.Size = 1;

        //    for (int i = 0; i < 101; i++)
        //    {
        //        sr.Values.Add(rd.Next(500) + 250);
        //    }
        //    chart.Series.Add(sr);
        //    //é¿ê—
        //}

        //private void LoadTempChart3Data(CustomChart chart)
        //{
        //    BarSeri bar = null;

        //    bar = new BarSeri();
        //    bar.Name = "ìñçﬁó\îıåvéZ";
        //    bar.BarBackColor = Color.Red;
        //    bar.BarForeColor = Color.White;
        //    bar.BarBorderSize = 1;
        //    bar.BarSize = 15;

        //    bar.Values.Add(-0.027);
        //    bar.Values.Add(-0.021);
        //    bar.Values.Add(-0.047);
        //    bar.Values.Add(-0.022);
        //    bar.Values.Add(-0.020);
        //    bar.Values.Add(-0.011);
        //    bar.Values.Add(-0.038);

        //    chart.BarSeries.Add(bar);

        //    bar = new BarSeri();
        //    bar.Name = "âﬂãéé¿ê—ïΩãœ";
        //    bar.BarBackColor = Color.Yellow;
        //    bar.BarForeColor = Color.Lime;
        //    bar.BarBorderSize = 1;
        //    bar.BarSize = 15;

        //    bar.Values.Add(-0.008);
        //    bar.Values.Add(-0.006);
        //    bar.Values.Add(-0.018);
        //    bar.Values.Add(-0.028);
        //    bar.Values.Add(-0.022);
        //    bar.Values.Add(-0.010);
        //    bar.Values.Add(-0.040);

        //    chart.BarSeries.Add(bar);
        //}

        //private void LoadTempChart4Data(CustomChart chart)
        //{
        //    BarSeri bar = null;

        //    bar = new BarSeri();
        //    bar.Name = "ìñçﬁó\îıåvéZ";
        //    bar.BarBackColor = Color.Blue;
        //    bar.BarForeColor = Color.White;
        //    bar.BarBorderSize = 1;
        //    bar.BarSize = 15;

        //    bar.Values.Add(-0.027);
        //    bar.Values.Add(-0.021);
        //    bar.Values.Add(-0.047);
        //    bar.Values.Add(-0.022);
        //    bar.Values.Add(-0.020);
        //    bar.Values.Add(-0.011);
        //    bar.Values.Add(-0.038);

        //    chart.BarSeries.Add(bar);

        //    bar = new BarSeri();
        //    bar.Name = "âﬂãéé¿ê—ïΩãœ";
        //    bar.BarBackColor = Color.Yellow;
        //    bar.BarForeColor = Color.Lime;
        //    bar.BarBorderSize = 1;
        //    bar.BarSize = 15;

        //    bar.Values.Add(-0.008);
        //    bar.Values.Add(-0.006);
        //    bar.Values.Add(-0.018);
        //    bar.Values.Add(-0.028);
        //    bar.Values.Add(-0.022);
        //    bar.Values.Add(-0.010);
        //    bar.Values.Add(-0.040);

        //    chart.BarSeries.Add(bar);
        //}

        //private void LoadTempChart5Data(CustomChart chart)
        //{
        //    BarSeri bar = null;

        //    bar = new BarSeri();
        //    bar.Name = "ìñçﬁó\îıåvéZ";
        //    bar.BarBackColor = Color.Lime;
        //    bar.BarForeColor = Color.White;
        //    bar.BarBorderSize = 1;
        //    bar.BarSize = 15;

        //    bar.Values.Add(-0.027);
        //    bar.Values.Add(-0.021);
        //    bar.Values.Add(-0.047);
        //    bar.Values.Add(-0.022);
        //    bar.Values.Add(-0.020);
        //    bar.Values.Add(-0.011);
        //    bar.Values.Add(-0.038);

        //    chart.BarSeries.Add(bar);

        //    bar = new BarSeri();
        //    bar.Name = "âﬂãéé¿ê—ïΩãœ";
        //    bar.BarBackColor = Color.Blue;
        //    bar.BarForeColor = Color.White;
        //    bar.BarBorderSize = 1;
        //    bar.BarSize = 15;

        //    bar.Values.Add(-0.008);
        //    bar.Values.Add(-0.006);
        //    bar.Values.Add(-0.018);
        //    bar.Values.Add(-0.028);
        //    bar.Values.Add(-0.022);
        //    bar.Values.Add(-0.010);
        //    bar.Values.Add(-0.040);

        //    chart.BarSeries.Add(bar);
        //}

        private void Grid_Resize(object sender, EventArgs e)
        {
            if (!(sender is DataGridView))
            {
                return;
            }
            DataGridView grdResized = (DataGridView)sender;
            if (grdResized.ColumnCount < 1)
            {
                return;
            }
            if (this.Width < 100)
            {
                return;
            }
            grdResized.SuspendLayout();
            this.SuspendLayout();

            grdResized.Width = grdResized.Parent.Width;
            grdResized.Height = grdResized.Parent.Height;
            grdResized.Top = 0;
            grdResized.Left = 0;

            int verticalScrollBarWidth = 1;
            int innerGridHeight = 0;

            for (int i = 0, length = grdResized.Rows.Count; i < length; i++)
            {
                innerGridHeight += grdResized.Rows[i].Height;
            }
            
            int cellWidth = grdResized.Width
                - grdResized.Columns[0].Width
                - grdResized.Columns[1].Width
                - verticalScrollBarWidth;

            cellWidth = Convert.ToInt32(cellWidth / 7);

            if (cellWidth * 7 + grdResized.Columns[0].Width
                + grdResized.Columns[1].Width
                + verticalScrollBarWidth
                > grdResized.Width)
            {
                cellWidth -= 1;
            }

            for (int i = 2, size = grdResized.ColumnCount; i < size; i++)
            {
                grdResized.Columns[i].Width = cellWidth;
            }

            int innerGridWidth = 0;

            for (int i = 1, size = grdResized.ColumnCount; i < size; i++)
            {
                innerGridWidth += grdResized.Columns[i].Width;
            }

            grdResized.Columns[0].Width = grdResized.Width - 2 - innerGridWidth - verticalScrollBarWidth;

            int innerGridHeightPerRow = Convert.ToInt32(((grdResized.Height - 1) * 1.0) / (grdResized.RowCount * 1.0));
            
            if (innerGridHeightPerRow * grdResized.Rows.Count > grdResized.Height - 1)
            {
                innerGridHeightPerRow--;
            }
            
            for (int i = 0; i < grdResized.Rows.Count; i++)
            {
                grdResized.Rows[i].Height = innerGridHeightPerRow;
            }

            grdResized.Height = innerGridHeightPerRow * grdResized.Rows.Count + 3;
            grdResized.Top = (grdResized.Parent.Height - grdResized.Height) / 2;
            grdResized.Left = (grdResized.Parent.Width - grdResized.Width) / 2;

            grdResized.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void FillUser()
        {
            foreach (Label lbl in _lblWorkerList)
            {
                lbl.Text = "";
            }
            if (_UserColl != null)
            {
                for (int i = 0; i < _UserColl.Count && i < _lblWorkerList.Length; i++)
                {
                    _lblWorkerList[i].Text = _UserColl[i].Name;
                }
            }

            if (_SelectedWorkerID > 0)
            {
                SelectWorkerByID(_SelectedWorkerID);
            }
            else
            {
                SelectWorker(0);
            }
        }

        private void SelectWorker(int index)
        {
            if (_UserColl != null && index >= 0 && index < _lblWorkerList.Length && index < _UserColl.Count)
            {
                _lblWorkerList[_SelectedWorkerIndex].BackColor = _NomalWorkerBackColor;
                _SelectedWorkerIndex = index;
                if (OnWorker_Selected != null)
                {
                    _Idle = true;
                    OnWorker_Selected(this, new WorkerEventArgs(new TWorker(_UserColl[index].ID)));
                    _Idle = false;
                }
                _lblWorkerList[_SelectedWorkerIndex].BackColor = _HightlightWorkerBackColor;
            }
        }

        public void SelectWorkerByID(int workerID)
        {
            if (_Idle)
            {
                return;
            }
            for (int i = 0; i < _UserColl.Count; i++)
            {
                if (_UserColl[i].ID == workerID)
                {
                    SelectWorker(i);
                    return;
                }
            }
        }

        private void lblWorker_Click(object sender, EventArgs e)
        {
            if (sender is Label)
            {
                Label workerLabel = (Label)sender;
                for (int i = 0; i < _lblWorkerList.Length; i++)
                {
                    Label lbl = _lblWorkerList[i];
                    if (workerLabel == lbl)
                    {
                        SelectWorker(i);
                        return;
                    }
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            int padding = ((keyData & Keys.Shift) == Keys.Shift) ? 12 : 0;

            switch (keyData & (~Keys.Shift))
            {
                case Keys.F1:
                    SelectWorker(padding + 0);
                    break;
                case Keys.F2:
                    SelectWorker(padding + 1);
                    break;
                case Keys.F3:
                    SelectWorker(padding + 2);
                    break;
                case Keys.F4:
                    SelectWorker(padding + 3);
                    break;
                case Keys.F5:
                    SelectWorker(padding + 4);
                    break;
                case Keys.F6:
                    SelectWorker(padding + 5);
                    break;
                case Keys.F7:
                    SelectWorker(padding + 6);
                    break;
                case Keys.F8:
                    SelectWorker(padding + 7);
                    break;
                case Keys.F9:
                    SelectWorker(padding + 8);
                    break;
                case Keys.F10:
                    SelectWorker(padding + 9);
                    return true;
                case Keys.F11:
                    SelectWorker(padding + 10);
                    break;
                case Keys.F12:
                    SelectWorker(padding + 11);
                    break;
                default:
                    break;
            }

            // test for refresh data
            if ((keyData & Keys.Control) == Keys.Control)
            {
                Keys keyPressed = keyData & (~Keys.Control);
                if (keyPressed == Keys.F5)
                {
                    LoadData(DataPackages.Preset);
                }
                else if (keyPressed == Keys.F6)
                {
                    LoadData(DataPackages.FinalSet);
                }
                else if (keyPressed == Keys.F7)
                {
                    LoadData(DataPackages.Result);
                }
                else if (keyPressed == Keys.F8)
                {
                    LoadData(DataPackages.Preset);
                    LoadData(DataPackages.FinalSet);
                    LoadData(DataPackages.Result);
                }
            }
            // end test

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            this.OnKeyDown(e);
        }

        public void LoadData(DataPackages package)
        {
            try
            {
                switch (package)
                {
                    case DataPackages.Preset:
                        T900 t900 = T900.GetLast();
                        if (t900 != null && t900.ID > 0)
                        {
                            FillData(t900);
                        }
                        break;
                    case DataPackages.FinalSet:
                        T800 t800 = T800.GetLast();
                        if (t800 != null && t800.ID > 0)
                        {
                            FillData(t800);
                        }
                        break;
                    case DataPackages.Result:
                        T1800 t1800 = T1800.GetLast();
                        if (t1800 != null && t1800.ID > 0)
                        {
                            FillData(t1800);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                log.Error("LoadData(DataPackages package) error. Loading terminal.", ex);
            }
        }

        protected void FillData(T900 t900)
        {
            HighLightT900();

            this.chtT900_1.ValueAxis1.BarSeries.Clear();
            this.chtT900_1.ValueAxis1.LineSeries.Clear();
            this.chtT900_1.ValueAxis2.BarSeries.Clear();
            this.chtT900_1.ValueAxis2.LineSeries.Clear();

            lblT900_CoilNo.Text = t900.R025;
            lblT900_Thick.Text = (t900.R167 * 0.01).ToString("0.00;-0.00;0.00");
            lblT900_Width.Text = t900.R165.ToString();
            lblT900_SteelName.Text = t900.R071;

            Gamen gamenT900 = new Gamen(t900.ID, 1);
            double[] gamens = null;
            if (gamenT900.ID > 0)
            {
                gamens = gamenT900.GetValues();
            }

            if (gamens != null)
            {
                lblT900_Gamen002.Text = (gamens[1] == Double.MinValue ? "" : gamens[1].ToString());
            }

            T900 t900Previous = t900.GetPreviousPreset();

            T900_I2_07 t900_R393 = t900.R391;

            grdData1[2, 1].Value = (t900_R393.F1 * 0.01).ToString("0.00;-0.00;0.00");
            grdData1[3, 1].Value = (t900_R393.F2 * 0.01).ToString("0.00;-0.00;0.00");
            grdData1[4, 1].Value = (t900_R393.F3 * 0.01).ToString("0.00;-0.00;0.00");
            grdData1[5, 1].Value = (t900_R393.F4 * 0.01).ToString("0.00;-0.00;0.00");
            grdData1[6, 1].Value = (t900_R393.F5 * 0.01).ToString("0.00;-0.00;0.00");
            grdData1[7, 1].Value = (t900_R393.F6 * 0.01).ToString("0.00;-0.00;0.00");
            grdData1[8, 1].Value = (t900_R393.F7 * 0.01).ToString("0.00;-0.00;0.00");

            T900_I2_07 t900_R393Pre = null;
            if (t900Previous != null && t900Previous.ID > 0)
            {
                t900_R393Pre = t900Previous.R391;

                grdData1[2, 2].Value = (t900_R393Pre.F1 * 0.01).ToString("0.00;-0.00;0.00");
                grdData1[3, 2].Value = (t900_R393Pre.F2 * 0.01).ToString("0.00;-0.00;0.00");
                grdData1[4, 2].Value = (t900_R393Pre.F3 * 0.01).ToString("0.00;-0.00;0.00");
                grdData1[5, 2].Value = (t900_R393Pre.F4 * 0.01).ToString("0.00;-0.00;0.00");
                grdData1[6, 2].Value = (t900_R393Pre.F5 * 0.01).ToString("0.00;-0.00;0.00");
                grdData1[7, 2].Value = (t900_R393Pre.F6 * 0.01).ToString("0.00;-0.00;0.00");
                grdData1[8, 2].Value = (t900_R393Pre.F7 * 0.01).ToString("0.00;-0.00;0.00");

                grdData1[2, 3].Value = ((t900_R393.F1 - t900_R393Pre.F1) * 0.01).ToString("0.00;-0.00;0.00");
                grdData1[3, 3].Value = ((t900_R393.F2 - t900_R393Pre.F2) * 0.01).ToString("0.00;-0.00;0.00");
                grdData1[4, 3].Value = ((t900_R393.F3 - t900_R393Pre.F3) * 0.01).ToString("0.00;-0.00;0.00");
                grdData1[5, 3].Value = ((t900_R393.F4 - t900_R393Pre.F4) * 0.01).ToString("0.00;-0.00;0.00");
                grdData1[6, 3].Value = ((t900_R393.F5 - t900_R393Pre.F5) * 0.01).ToString("0.00;-0.00;0.00");
                grdData1[7, 3].Value = ((t900_R393.F6 - t900_R393Pre.F6) * 0.01).ToString("0.00;-0.00;0.00");
                grdData1[8, 3].Value = ((t900_R393.F7 - t900_R393Pre.F7) * 0.01).ToString("0.00;-0.00;0.00");
            }
            else
            {
                grdData1[2, 2].Value = "";
                grdData1[3, 2].Value = "";
                grdData1[4, 2].Value = "";
                grdData1[5, 2].Value = "";
                grdData1[6, 2].Value = "";
                grdData1[7, 2].Value = "";
                grdData1[8, 2].Value = "";

                grdData1[2, 3].Value = "";
                grdData1[3, 3].Value = "";
                grdData1[4, 3].Value = "";
                grdData1[5, 3].Value = "";
                grdData1[6, 3].Value = "";
                grdData1[7, 3].Value = "";
                grdData1[8, 3].Value = "";
            }



            T900_I2_07 t900_R199 = t900.R197;

            grdData1[2, 4].Value = (t900_R199.F1 * 0.1).ToString("0.0;-0.0;0.0");
            grdData1[3, 4].Value = (t900_R199.F2 * 0.1).ToString("0.0;-0.0;0.0");
            grdData1[4, 4].Value = (t900_R199.F3 * 0.1).ToString("0.0;-0.0;0.0");
            grdData1[5, 4].Value = (t900_R199.F4 * 0.1).ToString("0.0;-0.0;0.0");
            grdData1[6, 4].Value = (t900_R199.F5 * 0.1).ToString("0.0;-0.0;0.0");
            grdData1[7, 4].Value = (t900_R199.F6 * 0.1).ToString("0.0;-0.0;0.0");
            grdData1[8, 4].Value = (t900_R199.F7 * 0.1).ToString("0.0;-0.0;0.0");

            T900_I2_07 t900_R199Pre = null;
            if (t900Previous != null && t900Previous.ID > 0)
            {
                t900_R199Pre = t900Previous.R197;

                grdData1[2, 5].Value = (t900_R199Pre.F1 * 0.1).ToString("0.0;-0.0;0.0");
                grdData1[3, 5].Value = (t900_R199Pre.F2 * 0.1).ToString("0.0;-0.0;0.0");
                grdData1[4, 5].Value = (t900_R199Pre.F3 * 0.1).ToString("0.0;-0.0;0.0");
                grdData1[5, 5].Value = (t900_R199Pre.F4 * 0.1).ToString("0.0;-0.0;0.0");
                grdData1[6, 5].Value = (t900_R199Pre.F5 * 0.1).ToString("0.0;-0.0;0.0");
                grdData1[7, 5].Value = (t900_R199Pre.F6 * 0.1).ToString("0.0;-0.0;0.0");
                grdData1[8, 5].Value = (t900_R199Pre.F7 * 0.1).ToString("0.0;-0.0;0.0");

                grdData1[2, 6].Value = ((t900_R199.F1 - t900_R199Pre.F1) * 0.1).ToString("0.0;-0.0;0.0");
                grdData1[3, 6].Value = ((t900_R199.F2 - t900_R199Pre.F2) * 0.1).ToString("0.0;-0.0;0.0");
                grdData1[4, 6].Value = ((t900_R199.F3 - t900_R199Pre.F3) * 0.1).ToString("0.0;-0.0;0.0");
                grdData1[5, 6].Value = ((t900_R199.F4 - t900_R199Pre.F4) * 0.1).ToString("0.0;-0.0;0.0");
                grdData1[6, 6].Value = ((t900_R199.F5 - t900_R199Pre.F5) * 0.1).ToString("0.0;-0.0;0.0");
                grdData1[7, 6].Value = ((t900_R199.F6 - t900_R199Pre.F6) * 0.1).ToString("0.0;-0.0;0.0");
                grdData1[8, 6].Value = ((t900_R199.F7 - t900_R199Pre.F7) * 0.1).ToString("0.0;-0.0;0.0");
            }
            else
            {
                grdData1[2, 5].Value = "";
                grdData1[3, 5].Value = "";
                grdData1[4, 5].Value = "";
                grdData1[5, 5].Value = "";
                grdData1[6, 5].Value = "";
                grdData1[7, 5].Value = "";
                grdData1[8, 5].Value = "";

                grdData1[2, 6].Value = "";
                grdData1[3, 6].Value = "";
                grdData1[4, 6].Value = "";
                grdData1[5, 6].Value = "";
                grdData1[6, 6].Value = "";
                grdData1[7, 6].Value = "";
                grdData1[8, 6].Value = "";
            }



            T900_I2_07 t900_R433 = t900.R433;

            grdData1[2, 7].Value = t900_R433.F1.ToString();
            grdData1[3, 7].Value = t900_R433.F2.ToString();
            grdData1[4, 7].Value = t900_R433.F3.ToString();
            grdData1[5, 7].Value = t900_R433.F4.ToString();
            grdData1[6, 7].Value = t900_R433.F5.ToString();
            grdData1[7, 7].Value = t900_R433.F6.ToString();
            grdData1[8, 7].Value = t900_R433.F7.ToString();

            T900_I2_07 t900_R433Pre = null;
            if (t900Previous != null && t900Previous.ID > 0)
            {
                t900_R433Pre = t900Previous.R433;

                grdData1[2, 8].Value = t900_R433Pre.F1.ToString();
                grdData1[3, 8].Value = t900_R433Pre.F2.ToString();
                grdData1[4, 8].Value = t900_R433Pre.F3.ToString();
                grdData1[5, 8].Value = t900_R433Pre.F4.ToString();
                grdData1[6, 8].Value = t900_R433Pre.F5.ToString();
                grdData1[7, 8].Value = t900_R433Pre.F6.ToString();
                grdData1[8, 8].Value = t900_R433Pre.F7.ToString();
            }
            else
            {
                grdData1[2, 8].Value = "";
                grdData1[3, 8].Value = "";
                grdData1[4, 8].Value = "";
                grdData1[5, 8].Value = "";
                grdData1[6, 8].Value = "";
                grdData1[7, 8].Value = "";
                grdData1[8, 8].Value = "";
            }



            T900_I2_07 t900_R447 = t900.R447;

            grdData1[2, 9].Value = t900_R447.F1.ToString();
            grdData1[3, 9].Value = t900_R447.F2.ToString();
            grdData1[4, 9].Value = t900_R447.F3.ToString();
            grdData1[5, 9].Value = t900_R447.F4.ToString();
            grdData1[6, 9].Value = t900_R447.F5.ToString();
            grdData1[7, 9].Value = t900_R447.F6.ToString();
            grdData1[8, 9].Value = t900_R447.F7.ToString();

            this.chtT900_1.ValueAxis2.BarSeries.Clear();
            BarSeries bs1_t900 = new BarSeries("ìñçﬁó\îıåvéZ");
            bs1_t900.Size = 15;
            bs1_t900.Color = Color.Red;
            bs1_t900.BorderSize = 1;
            bs1_t900.BorderColor = Color.White;
            bs1_t900.Values.Add(t900_R447.F1);
            bs1_t900.Values.Add(t900_R447.F2);
            bs1_t900.Values.Add(t900_R447.F3);
            bs1_t900.Values.Add(t900_R447.F4);
            bs1_t900.Values.Add(t900_R447.F5);
            bs1_t900.Values.Add(t900_R447.F6);
            bs1_t900.Values.Add(t900_R447.F7);
            this.chtT900_1.ValueAxis2.BarSeries.Add(bs1_t900);

            T900_I2_07 t900_R447Pre = null;
            if (t900Previous != null && t900Previous.ID > 0)
            {
                t900_R447Pre = t900Previous.R447;

                grdData1[2, 10].Value = t900_R447Pre.F1.ToString();
                grdData1[3, 10].Value = t900_R447Pre.F2.ToString();
                grdData1[4, 10].Value = t900_R447Pre.F3.ToString();
                grdData1[5, 10].Value = t900_R447Pre.F4.ToString();
                grdData1[6, 10].Value = t900_R447Pre.F5.ToString();
                grdData1[7, 10].Value = t900_R447Pre.F6.ToString();
                grdData1[8, 10].Value = t900_R447Pre.F7.ToString();
            }
            else
            {
                grdData1[2, 10].Value = "";
                grdData1[3, 10].Value = "";
                grdData1[4, 10].Value = "";
                grdData1[5, 10].Value = "";
                grdData1[6, 10].Value = "";
                grdData1[7, 10].Value = "";
                grdData1[8, 10].Value = "";
            }

            if (gamens != null)
            {
                LineSeries ls1_t900 = new LineSeries("Red");
                ls1_t900.Color = Color.Red;
                ls1_t900.Marker.BackColor = ls1_t900.Marker.ForeColor = ls1_t900.Color;
                ls1_t900.Marker.Style = MarkerStyle.VUONG;
                ls1_t900.Marker.Size = 6;
                ls1_t900.Size = 1;

                ls1_t900.Values.Add(gamens[171] / 100.0);
                ls1_t900.Values.Add(gamens[172] / 100.0);
                ls1_t900.Values.Add(gamens[173] / 100.0);
                ls1_t900.Values.Add(gamens[174] / 100.0);
                ls1_t900.Values.Add(gamens[175] / 100.0);
                ls1_t900.Values.Add(gamens[176] / 100.0);
                ls1_t900.Values.Add(gamens[177] / 100.0);

                chtT900_1.ValueAxis1.LineSeries.Add(ls1_t900);

                LineSeries ls2_t900 = new LineSeries("Lime");
                ls2_t900.Color = Color.Lime;
                ls2_t900.Marker.BackColor = ls2_t900.Marker.ForeColor = ls2_t900.Color;
                ls2_t900.Marker.Style = MarkerStyle.THOI;
                ls2_t900.Marker.Size = 8;
                ls2_t900.Size = 1;

                ls2_t900.Values.Add(gamens[185] / 100.0);
                ls2_t900.Values.Add(gamens[186] / 100.0);
                ls2_t900.Values.Add(gamens[187] / 100.0);
                ls2_t900.Values.Add(gamens[188] / 100.0);
                ls2_t900.Values.Add(gamens[189] / 100.0);
                ls2_t900.Values.Add(gamens[190] / 100.0);
                ls2_t900.Values.Add(gamens[191] / 100.0);

                chtT900_1.ValueAxis1.LineSeries.Add(ls2_t900);

                BarSeries bs4_t900 = new BarSeries("âﬂãéé¿ê—ïΩãœ");
                bs4_t900.Color = Color.Yellow;
                bs4_t900.Size = 15;
                bs4_t900.BorderSize = 1;
                bs4_t900.BorderColor = Color.Lime;
                bs4_t900.Values.Add(gamens[178]);
                bs4_t900.Values.Add(gamens[179]);
                bs4_t900.Values.Add(gamens[180]);
                bs4_t900.Values.Add(gamens[181]);
                bs4_t900.Values.Add(gamens[182]);
                bs4_t900.Values.Add(gamens[183]);
                bs4_t900.Values.Add(gamens[184]);
                chtT900_1.ValueAxis2.BarSeries.Add(bs4_t900);
            }

            LineSeries lsl_t900 = new LineSeries("ó\îı");
            lsl_t900.Color = Color.Cyan;
            lsl_t900.Marker.BackColor = lsl_t900.Marker.ForeColor = lsl_t900.Color;
            lsl_t900.Marker.Style = MarkerStyle.THOI;
            lsl_t900.Marker.Size = 6;
            lsl_t900.Size = 1;

            //foreach (LineSeries lsr in chtMulti.ValueAxis1.LineSeries)
            //{
            //    if (lsr.Name.Equals(lsl_t900.Name, StringComparison.OrdinalIgnoreCase))
            //    {
            //        chtMulti.ValueAxis1.LineSeries.Remove(lsr);
            //        break;
            //    }
            //}

            DataSet ds = gamenT900.GetLast101CoilList();
            if (ds != null)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string[] values = Gamen.ParseValuesInString(row[Gamen.VALUES__COLUMN_NAME].ToString());
                    double value = Convert.ToDouble(values[1]);
                    lsl_t900.Values.Add(value);
                }
            }

            int ii = 0;
            for (ii = 0; ii < chtMulti.ValueAxis1.LineSeries.Count; ii++)
            {
                if (chtMulti.ValueAxis1.LineSeries[ii].Name.Equals(lsl_t900.Name, StringComparison.OrdinalIgnoreCase))
                {
                    chtMulti.ValueAxis1.LineSeries.RemoveAt(ii);
                    chtMulti.ValueAxis1.LineSeries.Insert(ii, lsl_t900);
                    break;
                }
            }
            if (ii == chtMulti.ValueAxis1.LineSeries.Count)
            {
                chtMulti.ValueAxis1.LineSeries.Add(lsl_t900);
            }
            chtMulti.Refresh();
        }

        protected void FillData(T800 t800)
        {
            HighLightT800();

            this.chtT800_1.ValueAxis1.BarSeries.Clear();
            this.chtT800_1.ValueAxis1.LineSeries.Clear();
            this.chtT800_1.ValueAxis2.BarSeries.Clear();
            this.chtT800_1.ValueAxis2.LineSeries.Clear();

            this.chtT800_2.ValueAxis1.BarSeries.Clear();
            this.chtT800_2.ValueAxis1.LineSeries.Clear();
            this.chtT800_2.ValueAxis2.BarSeries.Clear();
            this.chtT800_2.ValueAxis2.LineSeries.Clear();

            Gamen gamenT800 = new Gamen(t800.ID, 2);
            double[] gamens = null;
            if (gamenT800.ID > 0)
            {
                gamens = gamenT800.GetValues();
            }

            lblT800_CoilNo.Text = t800.R025;
            lblT800_Thick.Text = (t800.R119 * 0.01).ToString("0.00;-0.00;0.00");
            lblT800_Width.Text = t800.R117.ToString();
            lblT800_SteelName.Text = t800.R073;

            if (gamens != null)
            {
                lblT800_Gamen077.Text = (gamens[76] == Double.MinValue ? "" : gamens[76].ToString());
            }

            T800 t800Previous = t800.GetPreviousFinal();

            T800_I2_07 t800_R343 = t800.R343;

            grdData2[2, 1].Value = (t800_R343.F1 * 0.01).ToString("0.00;-0.00;0.00");
            grdData2[3, 1].Value = (t800_R343.F2 * 0.01).ToString("0.00;-0.00;0.00");
            grdData2[4, 1].Value = (t800_R343.F3 * 0.01).ToString("0.00;-0.00;0.00");
            grdData2[5, 1].Value = (t800_R343.F4 * 0.01).ToString("0.00;-0.00;0.00");
            grdData2[6, 1].Value = (t800_R343.F5 * 0.01).ToString("0.00;-0.00;0.00");
            grdData2[7, 1].Value = (t800_R343.F6 * 0.01).ToString("0.00;-0.00;0.00");
            grdData2[8, 1].Value = (t800_R343.F7 * 0.01).ToString("0.00;-0.00;0.00");

            T800_I2_07 t800_R343Pre = null;
            if (t800Previous != null && t800Previous.ID > 0)
            {
                t800_R343Pre = t800Previous.R343;

                grdData2[2, 2].Value = (t800_R343Pre.F1 * 0.01).ToString("0.00;-0.00;0.00");
                grdData2[3, 2].Value = (t800_R343Pre.F2 * 0.01).ToString("0.00;-0.00;0.00");
                grdData2[4, 2].Value = (t800_R343Pre.F3 * 0.01).ToString("0.00;-0.00;0.00");
                grdData2[5, 2].Value = (t800_R343Pre.F4 * 0.01).ToString("0.00;-0.00;0.00");
                grdData2[6, 2].Value = (t800_R343Pre.F5 * 0.01).ToString("0.00;-0.00;0.00");
                grdData2[7, 2].Value = (t800_R343Pre.F6 * 0.01).ToString("0.00;-0.00;0.00");
                grdData2[8, 2].Value = (t800_R343Pre.F7 * 0.01).ToString("0.00;-0.00;0.00");

                grdData2[2, 3].Value = ((t800_R343.F1 - t800_R343Pre.F1) * 0.01).ToString("0.00;-0.00;0.00");
                grdData2[3, 3].Value = ((t800_R343.F2 - t800_R343Pre.F2) * 0.01).ToString("0.00;-0.00;0.00");
                grdData2[4, 3].Value = ((t800_R343.F3 - t800_R343Pre.F3) * 0.01).ToString("0.00;-0.00;0.00");
                grdData2[5, 3].Value = ((t800_R343.F4 - t800_R343Pre.F4) * 0.01).ToString("0.00;-0.00;0.00");
                grdData2[6, 3].Value = ((t800_R343.F5 - t800_R343Pre.F5) * 0.01).ToString("0.00;-0.00;0.00");
                grdData2[7, 3].Value = ((t800_R343.F6 - t800_R343Pre.F6) * 0.01).ToString("0.00;-0.00;0.00");
                grdData2[8, 3].Value = ((t800_R343.F7 - t800_R343Pre.F7) * 0.01).ToString("0.00;-0.00;0.00");
            }
            else
            {
                grdData2[2, 2].Value = "";
                grdData2[3, 2].Value = "";
                grdData2[4, 2].Value = "";
                grdData2[5, 2].Value = "";
                grdData2[6, 2].Value = "";
                grdData2[7, 2].Value = "";
                grdData2[8, 2].Value = "";

                grdData2[2, 3].Value = "";
                grdData2[3, 3].Value = "";
                grdData2[4, 3].Value = "";
                grdData2[5, 3].Value = "";
                grdData2[6, 3].Value = "";
                grdData2[7, 3].Value = "";
                grdData2[8, 3].Value = "";
            }



            T800_I2_07 t800_R149 = t800.R149;

            grdData2[2, 4].Value = (t800_R149.F1 * 0.1).ToString("0.0;-0.0;0.0");
            grdData2[3, 4].Value = (t800_R149.F2 * 0.1).ToString("0.0;-0.0;0.0");
            grdData2[4, 4].Value = (t800_R149.F3 * 0.1).ToString("0.0;-0.0;0.0");
            grdData2[5, 4].Value = (t800_R149.F4 * 0.1).ToString("0.0;-0.0;0.0");
            grdData2[6, 4].Value = (t800_R149.F5 * 0.1).ToString("0.0;-0.0;0.0");
            grdData2[7, 4].Value = (t800_R149.F6 * 0.1).ToString("0.0;-0.0;0.0");
            grdData2[8, 4].Value = (t800_R149.F7 * 0.1).ToString("0.0;-0.0;0.0");

            T800_I2_07 t800_R149Pre = null;
            if (t800Previous != null && t800Previous.ID > 0)
            {
                t800_R149Pre = t800Previous.R149;

                grdData2[2, 5].Value = (t800_R149Pre.F1 * 0.1).ToString("0.0;-0.0;0.0");
                grdData2[3, 5].Value = (t800_R149Pre.F2 * 0.1).ToString("0.0;-0.0;0.0");
                grdData2[4, 5].Value = (t800_R149Pre.F3 * 0.1).ToString("0.0;-0.0;0.0");
                grdData2[5, 5].Value = (t800_R149Pre.F4 * 0.1).ToString("0.0;-0.0;0.0");
                grdData2[6, 5].Value = (t800_R149Pre.F5 * 0.1).ToString("0.0;-0.0;0.0");
                grdData2[7, 5].Value = (t800_R149Pre.F6 * 0.1).ToString("0.0;-0.0;0.0");
                grdData2[8, 5].Value = (t800_R149Pre.F7 * 0.1).ToString("0.0;-0.0;0.0");

                grdData2[2, 6].Value = ((t800_R149.F1 - t800_R149Pre.F1) * 0.1).ToString("0.0;-0.0;0.0");
                grdData2[3, 6].Value = ((t800_R149.F2 - t800_R149Pre.F2) * 0.1).ToString("0.0;-0.0;0.0");
                grdData2[4, 6].Value = ((t800_R149.F3 - t800_R149Pre.F3) * 0.1).ToString("0.0;-0.0;0.0");
                grdData2[5, 6].Value = ((t800_R149.F4 - t800_R149Pre.F4) * 0.1).ToString("0.0;-0.0;0.0");
                grdData2[6, 6].Value = ((t800_R149.F5 - t800_R149Pre.F5) * 0.1).ToString("0.0;-0.0;0.0");
                grdData2[7, 6].Value = ((t800_R149.F6 - t800_R149Pre.F6) * 0.1).ToString("0.0;-0.0;0.0");
                grdData2[8, 6].Value = ((t800_R149.F7 - t800_R149Pre.F7) * 0.1).ToString("0.0;-0.0;0.0");
            }
            else
            {
                grdData2[2, 5].Value = "";
                grdData2[3, 5].Value = "";
                grdData2[4, 5].Value = "";
                grdData2[5, 5].Value = "";
                grdData2[6, 5].Value = "";
                grdData2[7, 5].Value = "";
                grdData2[8, 5].Value = "";

                grdData2[2, 6].Value = "";
                grdData2[3, 6].Value = "";
                grdData2[4, 6].Value = "";
                grdData2[5, 6].Value = "";
                grdData2[6, 6].Value = "";
                grdData2[7, 6].Value = "";
                grdData2[8, 6].Value = "";
            }



            T800_I2_07 t800_R385 = t800.R385;

            grdData2[2, 7].Value = t800_R385.F1.ToString();
            grdData2[3, 7].Value = t800_R385.F2.ToString();
            grdData2[4, 7].Value = t800_R385.F3.ToString();
            grdData2[5, 7].Value = t800_R385.F4.ToString();
            grdData2[6, 7].Value = t800_R385.F5.ToString();
            grdData2[7, 7].Value = t800_R385.F6.ToString();
            grdData2[8, 7].Value = t800_R385.F7.ToString();

            T800_I2_07 t800_R385Pre = null;
            if (t800Previous != null && t800Previous.ID > 0)
            {
                t800_R385Pre = t800Previous.R385;

                grdData2[2, 8].Value = t800_R385Pre.F1.ToString();
                grdData2[3, 8].Value = t800_R385Pre.F2.ToString();
                grdData2[4, 8].Value = t800_R385Pre.F3.ToString();
                grdData2[5, 8].Value = t800_R385Pre.F4.ToString();
                grdData2[6, 8].Value = t800_R385Pre.F5.ToString();
                grdData2[7, 8].Value = t800_R385Pre.F6.ToString();
                grdData2[8, 8].Value = t800_R385Pre.F7.ToString();
            }
            else
            {
                grdData2[2, 8].Value = "";
                grdData2[3, 8].Value = "";
                grdData2[4, 8].Value = "";
                grdData2[5, 8].Value = "";
                grdData2[6, 8].Value = "";
                grdData2[7, 8].Value = "";
                grdData2[8, 8].Value = "";
            }



            T800_I2_07 t800_R413 = t800.R413;

            grdData2[2, 9].Value = t800_R413.F1.ToString();
            grdData2[3, 9].Value = t800_R413.F2.ToString();
            grdData2[4, 9].Value = t800_R413.F3.ToString();
            grdData2[5, 9].Value = t800_R413.F4.ToString();
            grdData2[6, 9].Value = t800_R413.F5.ToString();
            grdData2[7, 9].Value = t800_R413.F6.ToString();
            grdData2[8, 9].Value = t800_R413.F7.ToString();

            this.chtT800_1.ValueAxis2.BarSeries.Clear();
            BarSeries bs1_t800 = new BarSeries("ìñçﬁê›íËåvéZ");
            bs1_t800.BorderSize = 1;
            bs1_t800.BorderColor = Color.White;
            bs1_t800.Color = Color.Blue;
            bs1_t800.Size = 15;
            bs1_t800.Values.Add(t800_R413.F1);
            bs1_t800.Values.Add(t800_R413.F2);
            bs1_t800.Values.Add(t800_R413.F3);
            bs1_t800.Values.Add(t800_R413.F4);
            bs1_t800.Values.Add(t800_R413.F5);
            bs1_t800.Values.Add(t800_R413.F6);
            bs1_t800.Values.Add(t800_R413.F7);
            this.chtT800_1.ValueAxis2.BarSeries.Add(bs1_t800);

            T800_I2_07 t800_R413Pre = null;
            if (t800Previous != null && t800Previous.ID > 0)
            {
                t800_R413Pre = t800Previous.R413;

                grdData2[2, 10].Value = t800_R413Pre.F1.ToString();
                grdData2[3, 10].Value = t800_R413Pre.F2.ToString();
                grdData2[4, 10].Value = t800_R413Pre.F3.ToString();
                grdData2[5, 10].Value = t800_R413Pre.F4.ToString();
                grdData2[6, 10].Value = t800_R413Pre.F5.ToString();
                grdData2[7, 10].Value = t800_R413Pre.F6.ToString();
                grdData2[8, 10].Value = t800_R413Pre.F7.ToString();
            }
            else
            {
                grdData2[2, 10].Value = "";
                grdData2[3, 10].Value = "";
                grdData2[4, 10].Value = "";
                grdData2[5, 10].Value = "";
                grdData2[6, 10].Value = "";
                grdData2[7, 10].Value = "";
                grdData2[8, 10].Value = "";
            }



            T800_I2_06 t800_R427 = t800.R427;

            grdData2[2, 12].Value = (t800_R427.R1 * 0.01).ToString("0.00;-0.00;0.00");
            grdData2[3, 12].Value = (t800_R427.R2 * 0.01).ToString("0.00;-0.00;0.00");
            grdData2[4, 12].Value = (t800_R427.R3 * 0.01).ToString("0.00;-0.00;0.00");
            grdData2[5, 12].Value = (t800_R427.R4 * 0.01).ToString("0.00;-0.00;0.00");
            grdData2[6, 12].Value = (t800_R427.R5 * 0.01).ToString("0.00;-0.00;0.00");
            grdData2[7, 12].Value = (t800_R427.R6 * 0.01).ToString("0.00;-0.00;0.00");
            grdData2[8, 12].Value = "";

            T800_I2_06 t800_R427Pre = null;
            if (t800Previous != null && t800Previous.ID > 0)
            {
                t800_R427Pre = t800Previous.R427;

                grdData2[2, 13].Value = (t800_R427Pre.R1 * 0.01).ToString("0.00;-0.00;0.00");
                grdData2[3, 13].Value = (t800_R427Pre.R2 * 0.01).ToString("0.00;-0.00;0.00");
                grdData2[4, 13].Value = (t800_R427Pre.R3 * 0.01).ToString("0.00;-0.00;0.00");
                grdData2[5, 13].Value = (t800_R427Pre.R4 * 0.01).ToString("0.00;-0.00;0.00");
                grdData2[6, 13].Value = (t800_R427Pre.R5 * 0.01).ToString("0.00;-0.00;0.00");
                grdData2[7, 13].Value = (t800_R427Pre.R6 * 0.01).ToString("0.00;-0.00;0.00");
                grdData2[8, 13].Value = "";
            }
            else
            {
                grdData2[2, 13].Value = "";
                grdData2[3, 13].Value = "";
                grdData2[4, 13].Value = "";
                grdData2[5, 13].Value = "";
                grdData2[6, 13].Value = "";
                grdData2[7, 13].Value = "";
                grdData2[8, 13].Value = "";
            }

            LineSeries lineT800_1 = new LineSeries("å˙Ç›");
            lineT800_1.Color = lineT800_1.Marker.BackColor = lineT800_1.Marker.ForeColor = Color.Cyan;
            lineT800_1.Marker.Style = MarkerStyle.THOI;
            lineT800_1.Marker.Size = 6;
            lineT800_1.Size = 1;

            LineSeries lineT800_2 = new LineSeries("ïù");
            lineT800_2.Color = lineT800_2.Marker.BackColor = lineT800_2.Marker.ForeColor = Color.Fuchsia;
            lineT800_2.Marker.Style = MarkerStyle.VUONG;
            lineT800_2.Marker.Size = 5;
            lineT800_2.Size = 1;

            DataSet ds = t800.GetLast101CoilList();
            if (ds != null)
            {
                DataTable tb = ds.Tables[0];
                for (int i = 0, size = tb.Rows.Count; i < size; i++)
                {
                    DataRow row = tb.Rows[i];
                    lineT800_1.Values.Add(((Int16)row[T800.R119__COLUMN_NAME]) * 0.01);
                    lineT800_2.Values.Add((Int16)row[T800.R117__COLUMN_NAME]);
                }
            }

            chtT800_2.ValueAxis1.LineSeries.Add(lineT800_1);
            chtT800_2.ValueAxis2.LineSeries.Add(lineT800_2);

            if (gamens != null)
            {
                LineSeries ls1_t900 = new LineSeries("Blue");
                ls1_t900.Color = Color.Blue;
                ls1_t900.Marker.BackColor = ls1_t900.Marker.ForeColor = ls1_t900.Color;
                ls1_t900.Marker.Style = MarkerStyle.VUONG;
                ls1_t900.Marker.Size = 6;
                ls1_t900.Size = 1;

                ls1_t900.Values.Add(gamens[201] / 100.0);
                ls1_t900.Values.Add(gamens[202] / 100.0);
                ls1_t900.Values.Add(gamens[203] / 100.0);
                ls1_t900.Values.Add(gamens[204] / 100.0);
                ls1_t900.Values.Add(gamens[205] / 100.0);
                ls1_t900.Values.Add(gamens[206] / 100.0);
                ls1_t900.Values.Add(gamens[207] / 100.0);

                chtT800_1.ValueAxis1.LineSeries.Add(ls1_t900);

                LineSeries ls2_t900 = new LineSeries("Yellow");
                ls2_t900.Color = Color.Yellow;
                ls2_t900.Marker.BackColor = ls2_t900.Marker.ForeColor = ls2_t900.Color;
                ls2_t900.Marker.Style = MarkerStyle.THOI;
                ls2_t900.Marker.Size = 8;
                ls2_t900.Size = 1;

                ls2_t900.Values.Add(gamens[215] / 100.0);
                ls2_t900.Values.Add(gamens[216] / 100.0);
                ls2_t900.Values.Add(gamens[217] / 100.0);
                ls2_t900.Values.Add(gamens[218] / 100.0);
                ls2_t900.Values.Add(gamens[219] / 100.0);
                ls2_t900.Values.Add(gamens[220] / 100.0);
                ls2_t900.Values.Add(gamens[221] / 100.0);

                chtT800_1.ValueAxis1.LineSeries.Add(ls2_t900);

                BarSeries bs4_t900 = new BarSeries("âﬂãéé¿ê—ïΩãœ");
                bs4_t900.Color = Color.Yellow;
                bs4_t900.Size = 15;
                bs4_t900.BorderSize = 1;
                bs4_t900.BorderColor = Color.Lime;
                bs4_t900.Values.Add(gamens[208]);
                bs4_t900.Values.Add(gamens[209]);
                bs4_t900.Values.Add(gamens[210]);
                bs4_t900.Values.Add(gamens[211]);
                bs4_t900.Values.Add(gamens[212]);
                bs4_t900.Values.Add(gamens[213]);
                bs4_t900.Values.Add(gamens[214]);
                chtT800_1.ValueAxis2.BarSeries.Add(bs4_t900);
            }


            //sample data for last chart
            LineSeries lsl_t900 = new LineSeries("ê›íË");
            lsl_t900.Color = Color.Yellow;
            lsl_t900.Marker.BackColor = lsl_t900.Marker.ForeColor = lsl_t900.Color;
            lsl_t900.Marker.Style = MarkerStyle.TAM_GIAC;
            lsl_t900.Marker.Size = 6;
            lsl_t900.Size = 1;

            //foreach (LineSeries lsr in chtMulti.ValueAxis1.LineSeries)
            //{
            //    if (lsr.Name.Equals(lsl_t900.Name, StringComparison.OrdinalIgnoreCase))
            //    {
            //        chtMulti.ValueAxis1.LineSeries.Remove(lsr);
            //        break;
            //    }
            //}

            ds = gamenT800.GetLast101CoilList();
            if (ds != null)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string[] values = Gamen.ParseValuesInString(row[Gamen.VALUES__COLUMN_NAME].ToString());
                    double value = Convert.ToDouble(values[76]);
                    lsl_t900.Values.Add(value);
                }
            }

            //Random r = new Random();
            //for (int i = 0; i < 101; i++)
            //{
            //    lsl_t900.Values.Add(r.Next(1000));
            //}
            //chtMulti.ValueAxis1.LineSeries.Add(lsl_t900);

            

            int ii = 0;
            for (ii = 0; ii < chtMulti.ValueAxis1.LineSeries.Count; ii++)
            {
                if (chtMulti.ValueAxis1.LineSeries[ii].Name.Equals(lsl_t900.Name, StringComparison.OrdinalIgnoreCase))
                {
                    chtMulti.ValueAxis1.LineSeries.RemoveAt(ii);
                    chtMulti.ValueAxis1.LineSeries.Insert(ii, lsl_t900);
                    break;
                }
            }
            if (ii == chtMulti.ValueAxis1.LineSeries.Count)
            {
                chtMulti.ValueAxis1.LineSeries.Add(lsl_t900);
            }
            chtMulti.Refresh();
        }

        protected void FillData(T1800 t1800)
        {
            HighLightT1800();

            this.chtT1800_1.ValueAxis1.BarSeries.Clear();
            this.chtT1800_1.ValueAxis1.LineSeries.Clear();
            this.chtT1800_1.ValueAxis2.BarSeries.Clear();
            this.chtT1800_1.ValueAxis2.LineSeries.Clear();

            //this.chtT800_2.ValueAxis1.BarSeries.Clear();
            //this.chtT800_2.ValueAxis1.LineSeries.Clear();
            //this.chtT800_2.ValueAxis2.BarSeries.Clear();
            //this.chtT800_2.ValueAxis2.LineSeries.Clear();

            Gamen gamenT1800 = new Gamen(t1800.ID, 3);
            double[] gamens = null;
            if (gamenT1800.ID > 0)
            {
                gamens = gamenT1800.GetValues();
            }

            lblT1800_CoilNo.Text = t1800.R0025;
            lblT1800_Thick.Text = (t1800.R0095 * 0.01).ToString("0.00;-0.00;0.00");
            lblT1800_Width.Text = t1800.R0093.ToString();
            lblT1800_SteelName.Text = t1800.R0073;

            if (gamens != null)
            {
                lblT1800_Gamen131.Text = (gamens[130] == Double.MinValue ? "" : gamens[130].ToString());
            }

            T1800 t1800Previous = t1800.GetPreviousResult();

            T1800_I2_14 t1800_R0195 = t1800.R0195;

            grdData3[2, 1].Value = (t1800_R0195.F1_1 * 0.01).ToString("0.00;-0.00;0.00");
            grdData3[3, 1].Value = (t1800_R0195.F2_1 * 0.01).ToString("0.00;-0.00;0.00");
            grdData3[4, 1].Value = (t1800_R0195.F3_1 * 0.01).ToString("0.00;-0.00;0.00");
            grdData3[5, 1].Value = (t1800_R0195.F4_1 * 0.01).ToString("0.00;-0.00;0.00");
            grdData3[6, 1].Value = (t1800_R0195.F5_1 * 0.01).ToString("0.00;-0.00;0.00");
            grdData3[7, 1].Value = (t1800_R0195.F6_1 * 0.01).ToString("0.00;-0.00;0.00");
            grdData3[8, 1].Value = (t1800_R0195.F7_1 * 0.01).ToString("0.00;-0.00;0.00");

            T1800_I2_14 t1800_R0195Pre = null;
            if (t1800Previous != null && t1800Previous.ID > 0)
            {
                t1800_R0195Pre = t1800Previous.R0195;

                grdData3[2, 2].Value = (t1800_R0195Pre.F1_1 * 0.01).ToString("0.00;-0.00;0.00");
                grdData3[3, 2].Value = (t1800_R0195Pre.F2_1 * 0.01).ToString("0.00;-0.00;0.00");
                grdData3[4, 2].Value = (t1800_R0195Pre.F3_1 * 0.01).ToString("0.00;-0.00;0.00");
                grdData3[5, 2].Value = (t1800_R0195Pre.F4_1 * 0.01).ToString("0.00;-0.00;0.00");
                grdData3[6, 2].Value = (t1800_R0195Pre.F5_1 * 0.01).ToString("0.00;-0.00;0.00");
                grdData3[7, 2].Value = (t1800_R0195Pre.F6_1 * 0.01).ToString("0.00;-0.00;0.00");
                grdData3[8, 2].Value = (t1800_R0195Pre.F7_1 * 0.01).ToString("0.00;-0.00;0.00");

                grdData3[2, 3].Value = ((t1800_R0195.F1_1 - t1800_R0195Pre.F1_1) * 0.01).ToString("0.00;-0.00;0.00");
                grdData3[3, 3].Value = ((t1800_R0195.F2_1 - t1800_R0195Pre.F2_1) * 0.01).ToString("0.00;-0.00;0.00");
                grdData3[4, 3].Value = ((t1800_R0195.F3_1 - t1800_R0195Pre.F3_1) * 0.01).ToString("0.00;-0.00;0.00");
                grdData3[5, 3].Value = ((t1800_R0195.F4_1 - t1800_R0195Pre.F4_1) * 0.01).ToString("0.00;-0.00;0.00");
                grdData3[6, 3].Value = ((t1800_R0195.F5_2 - t1800_R0195Pre.F5_2) * 0.01).ToString("0.00;-0.00;0.00");
                grdData3[7, 3].Value = ((t1800_R0195.F6_1 - t1800_R0195Pre.F6_1) * 0.01).ToString("0.00;-0.00;0.00");
                grdData3[8, 3].Value = ((t1800_R0195.F7_1 - t1800_R0195Pre.F7_1) * 0.01).ToString("0.00;-0.00;0.00");
            }
            else
            {
                grdData3[2, 2].Value = "";
                grdData3[3, 2].Value = "";
                grdData3[4, 2].Value = "";
                grdData3[5, 2].Value = "";
                grdData3[6, 2].Value = "";
                grdData3[7, 2].Value = "";
                grdData3[8, 2].Value = "";

                grdData3[2, 3].Value = "";
                grdData3[3, 3].Value = "";
                grdData3[4, 3].Value = "";
                grdData3[5, 3].Value = "";
                grdData3[6, 3].Value = "";
                grdData3[7, 3].Value = "";
                grdData3[8, 3].Value = "";
            }

            T1800_I2_07 t1800_R0125 = t1800.R0125;

            grdData3[2, 4].Value = (t1800_R0125.F1 * 0.1).ToString("0.0;-0.0;0.0");
            grdData3[3, 4].Value = (t1800_R0125.F2 * 0.1).ToString("0.0;-0.0;0.0");
            grdData3[4, 4].Value = (t1800_R0125.F3 * 0.1).ToString("0.0;-0.0;0.0");
            grdData3[5, 4].Value = (t1800_R0125.F4 * 0.1).ToString("0.0;-0.0;0.0");
            grdData3[6, 4].Value = (t1800_R0125.F5 * 0.1).ToString("0.0;-0.0;0.0");
            grdData3[7, 4].Value = (t1800_R0125.F6 * 0.1).ToString("0.0;-0.0;0.0");
            grdData3[8, 4].Value = (t1800_R0125.F7 * 0.1).ToString("0.0;-0.0;0.0");

            T1800_I2_07 t1800_R0125Pre = null;
            if (t1800Previous != null && t1800Previous.ID > 0)
            {
                t1800_R0125Pre = t1800Previous.R0125;

                grdData3[2, 5].Value = (t1800_R0125Pre.F1 * 0.1).ToString("0.0;-0.0;0.0");
                grdData3[3, 5].Value = (t1800_R0125Pre.F2 * 0.1).ToString("0.0;-0.0;0.0");
                grdData3[4, 5].Value = (t1800_R0125Pre.F3 * 0.1).ToString("0.0;-0.0;0.0");
                grdData3[5, 5].Value = (t1800_R0125Pre.F4 * 0.1).ToString("0.0;-0.0;0.0");
                grdData3[6, 5].Value = (t1800_R0125Pre.F5 * 0.1).ToString("0.0;-0.0;0.0");
                grdData3[7, 5].Value = (t1800_R0125Pre.F6 * 0.1).ToString("0.0;-0.0;0.0");
                grdData3[8, 5].Value = (t1800_R0125Pre.F7 * 0.1).ToString("0.0;-0.0;0.0");

                grdData3[2, 6].Value = ((t1800_R0125.F1 - t1800_R0125Pre.F1) * 0.1).ToString("0.0;-0.0;0.0");
                grdData3[3, 6].Value = ((t1800_R0125.F2 - t1800_R0125Pre.F2) * 0.1).ToString("0.0;-0.0;0.0");
                grdData3[4, 6].Value = ((t1800_R0125.F3 - t1800_R0125Pre.F3) * 0.1).ToString("0.0;-0.0;0.0");
                grdData3[5, 6].Value = ((t1800_R0125.F4 - t1800_R0125Pre.F4) * 0.1).ToString("0.0;-0.0;0.0");
                grdData3[6, 6].Value = ((t1800_R0125.F5 - t1800_R0125Pre.F5) * 0.1).ToString("0.0;-0.0;0.0");
                grdData3[7, 6].Value = ((t1800_R0125.F6 - t1800_R0125Pre.F6) * 0.1).ToString("0.0;-0.0;0.0");
                grdData3[8, 6].Value = ((t1800_R0125.F7 - t1800_R0125Pre.F7) * 0.1).ToString("0.0;-0.0;0.0");
            }
            else
            {
                grdData3[2, 5].Value = "";
                grdData3[3, 5].Value = "";
                grdData3[4, 5].Value = "";
                grdData3[5, 5].Value = "";
                grdData3[6, 5].Value = "";
                grdData3[7, 5].Value = "";
                grdData3[8, 5].Value = "";

                grdData3[2, 6].Value = "";
                grdData3[3, 6].Value = "";
                grdData3[4, 6].Value = "";
                grdData3[5, 6].Value = "";
                grdData3[6, 6].Value = "";
                grdData3[7, 6].Value = "";
                grdData3[8, 6].Value = "";
            }

            T1800_I2_07 t1800_R0223 = t1800.R0223;

            grdData3[2, 7].Value = t1800_R0223.F1.ToString();
            grdData3[3, 7].Value = t1800_R0223.F2.ToString();
            grdData3[4, 7].Value = t1800_R0223.F3.ToString();
            grdData3[5, 7].Value = t1800_R0223.F4.ToString();
            grdData3[6, 7].Value = t1800_R0223.F5.ToString();
            grdData3[7, 7].Value = t1800_R0223.F6.ToString();
            grdData3[8, 7].Value = t1800_R0223.F7.ToString();

            T1800_I2_07 t1800_R0223Pre = null;
            if (t1800Previous != null && t1800Previous.ID > 0)
            {
                t1800_R0223Pre = t1800Previous.R0223;

                grdData3[2, 8].Value = t1800_R0223Pre.F1.ToString();
                grdData3[3, 8].Value = t1800_R0223Pre.F2.ToString();
                grdData3[4, 8].Value = t1800_R0223Pre.F3.ToString();
                grdData3[5, 8].Value = t1800_R0223Pre.F4.ToString();
                grdData3[6, 8].Value = t1800_R0223Pre.F5.ToString();
                grdData3[7, 8].Value = t1800_R0223Pre.F6.ToString();
                grdData3[8, 8].Value = t1800_R0223Pre.F7.ToString();
            }
            else
            {
                grdData3[2, 8].Value = "";
                grdData3[3, 8].Value = "";
                grdData3[4, 8].Value = "";
                grdData3[5, 8].Value = "";
                grdData3[6, 8].Value = "";
                grdData3[7, 8].Value = "";
                grdData3[8, 8].Value = "";
            }

            T1800_I2_14 t1800_R0251 = t1800.R0251;

            grdData3[2, 9].Value = t1800_R0251.F1_1.ToString();
            grdData3[3, 9].Value = t1800_R0251.F2_1.ToString();
            grdData3[4, 9].Value = t1800_R0251.F3_1.ToString();
            grdData3[5, 9].Value = t1800_R0251.F4_1.ToString();
            grdData3[6, 9].Value = t1800_R0251.F5_1.ToString();
            grdData3[7, 9].Value = t1800_R0251.F6_1.ToString();
            grdData3[8, 9].Value = t1800_R0251.F7_1.ToString();

            this.chtT1800_1.ValueAxis2.BarSeries.Clear();
            BarSeries bs1_t1800 = new BarSeries("ìñçﬁé¿ê—");
            bs1_t1800.BorderSize = 1;
            bs1_t1800.BorderColor = Color.White;
            bs1_t1800.Color = Color.Lime;
            bs1_t1800.Size = 15;
            bs1_t1800.Values.Add(t1800_R0251.F1_1);
            bs1_t1800.Values.Add(t1800_R0251.F2_1);
            bs1_t1800.Values.Add(t1800_R0251.F3_1);
            bs1_t1800.Values.Add(t1800_R0251.F4_1);
            bs1_t1800.Values.Add(t1800_R0251.F5_1);
            bs1_t1800.Values.Add(t1800_R0251.F6_1);
            bs1_t1800.Values.Add(t1800_R0251.F7_1);
            this.chtT1800_1.ValueAxis2.BarSeries.Add(bs1_t1800);

            T1800_I2_14 t1800_R0251Pre = null;
            if (t1800Previous != null && t1800Previous.ID > 0)
            {
                t1800_R0251Pre = t1800Previous.R0251;

                grdData3[2, 10].Value = t1800_R0251Pre.F1_1.ToString();
                grdData3[3, 10].Value = t1800_R0251Pre.F2_1.ToString();
                grdData3[4, 10].Value = t1800_R0251Pre.F3_1.ToString();
                grdData3[5, 10].Value = t1800_R0251Pre.F4_1.ToString();
                grdData3[6, 10].Value = t1800_R0251Pre.F5_1.ToString();
                grdData3[7, 10].Value = t1800_R0251Pre.F6_1.ToString();
                grdData3[8, 10].Value = t1800_R0251Pre.F7_1.ToString();
            }
            else
            {
                grdData3[2, 10].Value = "";
                grdData3[3, 10].Value = "";
                grdData3[4, 10].Value = "";
                grdData3[5, 10].Value = "";
                grdData3[6, 10].Value = "";
                grdData3[7, 10].Value = "";
                grdData3[8, 10].Value = "";
            }

            T1800_I2_06 t1800_R0279 = t1800.R0279;

            grdData3[2, 12].Value = (t1800_R0279.R1 * 0.01).ToString("0.00;-0.00;0.00");
            grdData3[3, 12].Value = (t1800_R0279.R2 * 0.01).ToString("0.00;-0.00;0.00");
            grdData3[4, 12].Value = (t1800_R0279.R3 * 0.01).ToString("0.00;-0.00;0.00");
            grdData3[5, 12].Value = (t1800_R0279.R4 * 0.01).ToString("0.00;-0.00;0.00");
            grdData3[6, 12].Value = (t1800_R0279.R5 * 0.01).ToString("0.00;-0.00;0.00");
            grdData3[7, 12].Value = (t1800_R0279.R6 * 0.01).ToString("0.00;-0.00;0.00");
            grdData3[8, 12].Value = "";

            T1800_I2_06 t1800_R0279Pre = null;
            if (t1800Previous != null && t1800Previous.ID > 0)
            {
                t1800_R0279Pre = t1800Previous.R0279;

                grdData3[2, 13].Value = (t1800_R0279Pre.R1 * 0.01).ToString("0.00;-0.00;0.00");
                grdData3[3, 13].Value = (t1800_R0279Pre.R2 * 0.01).ToString("0.00;-0.00;0.00");
                grdData3[4, 13].Value = (t1800_R0279Pre.R3 * 0.01).ToString("0.00;-0.00;0.00");
                grdData3[5, 13].Value = (t1800_R0279Pre.R4 * 0.01).ToString("0.00;-0.00;0.00");
                grdData3[6, 13].Value = (t1800_R0279Pre.R5 * 0.01).ToString("0.00;-0.00;0.00");
                grdData3[7, 13].Value = (t1800_R0279Pre.R6 * 0.01).ToString("0.00;-0.00;0.00");
                grdData3[8, 13].Value = "";
            }
            else
            {
                grdData3[2, 13].Value = "";
                grdData3[3, 13].Value = "";
                grdData3[4, 13].Value = "";
                grdData3[5, 13].Value = "";
                grdData3[6, 13].Value = "";
                grdData3[7, 13].Value = "";
                grdData3[8, 13].Value = "";
            }

            T800 t800 = T800.GetCoilDetailOfYear(t1800.R0025, t1800.R0033);
            if (t1800 != null)
            {
                T800_I2_07 t800_R425 = t800.R413;
                if (t800_R425 != null)
                {
                    BarSeries bs4_t900 = new BarSeries("ìñçﬁê›íË");
                    bs4_t900.Color = Color.Blue;
                    bs4_t900.Size = 15;
                    bs4_t900.BorderSize = 1;
                    bs4_t900.BorderColor = Color.White;
                    bs4_t900.Values.Add(t800_R425.F1);
                    bs4_t900.Values.Add(t800_R425.F2);
                    bs4_t900.Values.Add(t800_R425.F3);
                    bs4_t900.Values.Add(t800_R425.F4);
                    bs4_t900.Values.Add(t800_R425.F5);
                    bs4_t900.Values.Add(t800_R425.F6);
                    bs4_t900.Values.Add(t800_R425.F7);
                    chtT1800_1.ValueAxis2.BarSeries.Add(bs4_t900);
                }
            }

            if (gamens != null)
            {
                LineSeries ls1_t900 = new LineSeries("Blue");
                ls1_t900.Color = Color.Lime;
                ls1_t900.Marker.BackColor = ls1_t900.Marker.ForeColor = ls1_t900.Color;
                ls1_t900.Marker.Style = MarkerStyle.VUONG;
                ls1_t900.Marker.Size = 6;
                ls1_t900.Size = 1;

                ls1_t900.Values.Add(gamens[223] / 100.0);
                ls1_t900.Values.Add(gamens[224] / 100.0);
                ls1_t900.Values.Add(gamens[225] / 100.0);
                ls1_t900.Values.Add(gamens[226] / 100.0);
                ls1_t900.Values.Add(gamens[227] / 100.0);
                ls1_t900.Values.Add(gamens[228] / 100.0);
                ls1_t900.Values.Add(gamens[229] / 100.0);

                chtT1800_1.ValueAxis1.LineSeries.Add(ls1_t900);

                LineSeries ls2_t900 = new LineSeries("Yellow");
                ls2_t900.Color = Color.White;
                ls2_t900.Marker.BackColor = ls2_t900.Marker.ForeColor = ls2_t900.Color;
                ls2_t900.Marker.Style = MarkerStyle.THOI;
                ls2_t900.Marker.Size = 8;
                ls2_t900.Size = 1;

                ls2_t900.Values.Add(gamens[230] / 100.0);
                ls2_t900.Values.Add(gamens[231] / 100.0);
                ls2_t900.Values.Add(gamens[232] / 100.0);
                ls2_t900.Values.Add(gamens[233] / 100.0);
                ls2_t900.Values.Add(gamens[234] / 100.0);
                ls2_t900.Values.Add(gamens[235] / 100.0);
                ls2_t900.Values.Add(gamens[236] / 100.0);

                chtT1800_1.ValueAxis1.LineSeries.Add(ls2_t900);
            }

            //sample data for last chart
            LineSeries lsl_t900 = new LineSeries("é¿ê—");
            lsl_t900.Color = Color.Fuchsia;
            lsl_t900.Marker.BackColor = lsl_t900.Marker.ForeColor = lsl_t900.Color;
            lsl_t900.Marker.Style = MarkerStyle.VUONG;
            lsl_t900.Marker.Size = 5;
            lsl_t900.Size = 1;

            //foreach (LineSeries lsr in chtMulti.ValueAxis1.LineSeries)
            //{
            //    if (lsr.Name.Equals(lsl_t900.Name, StringComparison.OrdinalIgnoreCase))
            //    {
            //        chtMulti.ValueAxis1.LineSeries.Remove(lsr);
            //        break;
            //    }
            //}

            if (gamenT1800.ID > 0)
            {
                DataSet ds = gamenT1800.GetLast101CoilList();
                if (ds != null)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string[] values = Gamen.ParseValuesInString(row[Gamen.VALUES__COLUMN_NAME].ToString());
                        double value = Convert.ToDouble(values[130]);
                        lsl_t900.Values.Add(value);
                    }
                }
                //chtMulti.ValueAxis1.LineSeries.Add(lsl_t900);

                int ii = 0;
                for (ii = 0; ii < chtMulti.ValueAxis1.LineSeries.Count; ii++)
                {
                    if (chtMulti.ValueAxis1.LineSeries[ii].Name.Equals(lsl_t900.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        chtMulti.ValueAxis1.LineSeries.RemoveAt(ii);
                        chtMulti.ValueAxis1.LineSeries.Insert(ii, lsl_t900);
                        break;
                    }
                }
                if (ii == chtMulti.ValueAxis1.LineSeries.Count)
                {
                    chtMulti.ValueAxis1.LineSeries.Add(lsl_t900);
                }
                chtMulti.Refresh();
            }
        }

        private void lblRangeChange_Click(object sender, EventArgs e)
        {
            RangeForm frm = new RangeForm();
            frm.MaxValue = chtMulti.Max1;
            frm.ShowDialog(this);
            if (frm.DialogResult == DialogResult.OK)
            {
                this.chtMulti.Max1 = frm.MaxValue;
                this.chtMulti.Ranger1 = this.chtMulti.Max1 / 5.0;

                TConfig config = new TConfig(TConfig.FINISHSUPPORTFORM_MAX);
                config.Name = TConfig.FINISHSUPPORTFORM_MAX;
                config.Value = this.chtMulti.Max1.ToString("###,###;-###,###;0");

                if (config.ID > 0)
                {
                    config.Update();
                }
                else
                {
                    config.Insert();
                }
            }
        }

        private void HighLightT900()
        {
            if (_IsLoading)
            {
                return;
            }
            if (!tmrT900.Enabled)
            {
                tmrT900.Start();
            }

            pnlT900Header.BackColor = Color.Lime;
            foreach (Control ctrl in pnlT900Header.Controls)
            {
                ctrl.ForeColor = Color.Black;
            }
        }

        private void HighLightT800()
        {
            if (_IsLoading)
            {
                return;
            }
            if (!tmrT800.Enabled)
            {
                tmrT800.Start();
            }

            pnlT800Header.BackColor = Color.Lime;
            foreach (Control ctrl in pnlT800Header.Controls)
            {
                ctrl.ForeColor = Color.Black;
            }
        }

        private void HighLightT1800()
        {
            if (_IsLoading)
            {
                return;
            }
            if (!tmrT1800.Enabled)
            {
                tmrT1800.Start();
            }

            pnlT1800Header.BackColor = Color.Lime;
            foreach (Control ctrl in pnlT1800Header.Controls)
            {
                ctrl.ForeColor = Color.Black;
            }
        }

        private void tmrT900_Tick(object sender, EventArgs e)
        {
            tmrT900.Stop();
            pnlT900Header.BackColor = Color.Black;
            foreach (Control ctrl in pnlT900Header.Controls)
            {
                ctrl.ForeColor = Color.Lime;
            }
        }

        private void tmrT800_Tick(object sender, EventArgs e)
        {
            tmrT800.Stop();
            pnlT800Header.BackColor = Color.Black;
            foreach (Control ctrl in pnlT800Header.Controls)
            {
                ctrl.ForeColor = Color.Lime;
            }
        }

        private void tmrT1800_Tick(object sender, EventArgs e)
        {
            tmrT1800.Stop();
            pnlT1800Header.BackColor = Color.Black;
            foreach (Control ctrl in pnlT1800Header.Controls)
            {
                ctrl.ForeColor = Color.Lime;
            }
        }

        private void FormFinishSupport2_Load(object sender, EventArgs e)
        {
            PreloadAll();
        }
    }
}