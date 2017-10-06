using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Kvics.HotMill.BL;
using Kvics.Controls.Chart;

using log4net;
using log4net.Config;

namespace Kvics.HotMill.Forms
{
    public partial class FormFinishSupport1 : SubFormFullScreen
    {
        private static readonly ILog log = Kvics.DBAccess.Log.Instance.GetLogger(typeof(FormFinishSupport1));

        private Color _NomalWorkerBackColor = Color.Black;
        private Color _HightlightWorkerBackColor = Color.Green;
        private Label[] _lblWorkerList = new Label[24];
        private int _SelectedWorkerIndex = 0;
        private int _SelectedWorkerID = -1;
        private WorkerCollection _UserColl = null;
        private int _SimulateTime1 = 1;
        private int _SimulateTime2 = 1;

        public event Worker_EventHandler OnWorker_Selected;
        public event SimulationCalculate_EventHandler OnSimulation_Calculate1;
        public event SimulationCalculate_EventHandler OnSimulation_Calculate2;
        public event SimulationCalculate_EventHandler OnSimulation_Clear;
        //public event FormFinishSupport_KeyEventHandler OnPuPd_Press;
        private bool _Idle = false;

        private readonly Color _ValueChanged_Color1 = Color.Fuchsia;
        private readonly Color _Default_Color1 = Color.Lime;
        private readonly Color _ValueChanged_Color2 = Color.Fuchsia;
        private readonly Color _Default_Color2 = Color.Cyan;
        private bool _IsLoading = true;

        public FormFinishSupport1()
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

            PreloadChart();

            LoadData(DataPackages.Preset);
            LoadData(DataPackages.FinalSet);
            LoadData(DataPackages.Result);

            _IsLoading = false;
        }

        private void ResetAll()
        {
            lblGamen002.Text = "";
            lblGamen077.Text = "";
            lblGamen131.Text = "";
            lblMaxF1.Text = "";
            lblMaxF2.Text = "";
            lblMaxF3.Text = "";
            lblMaxF4.Text = "";
            lblMaxF5.Text = "";
            lblMaxF6.Text = "";
            lblMaxF7.Text = "";
            lblMinF1.Text = "";
            lblMinF2.Text = "";
            lblMinF3.Text = "";
            lblMinF4.Text = "";
            lblMinF5.Text = "";
            lblMinF6.Text = "";
            lblMinF7.Text = "";
            lblT1800_1_F1F2.Text = "";
            lblT1800_1_F2F3.Text = "";
            lblT1800_1_F3F4.Text = "";
            lblT1800_1_F4F5.Text = "";
            lblT1800_1_F5F6.Text = "";
            lblT1800_1_F6F7.Text = "";
            lblT1800_CoilNo.Text = "";
            lblT1800_SteelName.Text = "";
            lblT1800_Thick.Text = "";
            lblT1800_Width.Text = "";
            lblT800_1_F1F2.Text = "";
            lblT800_1_F2F3.Text = "";
            lblT800_1_F3F4.Text = "";
            lblT800_1_F4F5.Text = "";
            lblT800_1_F5F6.Text = "";
            lblT800_1_F6F7.Text = "";
            lblT800_CoilNo.Text = "";
            lblT800_SteelName.Text = "";
            lblT800_Thick.Text = "";
            lblT800_Width.Text = "";
            lblT900_1_F1F2.Text = "";
            lblT900_1_F2F3.Text = "";
            lblT900_1_F3F4.Text = "";
            lblT900_1_F4F5.Text = "";
            lblT900_1_F5F6.Text = "";
            lblT900_1_F6F7.Text = "";
            lblT900_3_1_F1F2.Text = "";
            lblT900_3_1_F2F3.Text = "";
            lblT900_3_1_F3F4.Text = "";
            lblT900_3_1_F4F5.Text = "";
            lblT900_3_1_F5F6.Text = "";
            lblT900_3_1_F6F7.Text = "";
            lblT900_3_2_F1F2.Text = "";
            lblT900_3_2_F2F3.Text = "";
            lblT900_3_2_F3F4.Text = "";
            lblT900_3_2_F4F5.Text = "";
            lblT900_3_2_F5F6.Text = "";
            lblT900_3_2_F6F7.Text = "";
            lblT900_3_3_F1.Text = "";
            lblT900_3_3_F2.Text = "";
            lblT900_3_3_F3.Text = "";
            lblT900_3_3_F4.Text = "";
            lblT900_3_3_F5.Text = "";
            lblT900_3_3_F6.Text = "";
            lblT900_3_3_F7.Text = "";
            lblT900_3_4_F1.Text = "";
            lblT900_3_4_F2.Text = "";
            lblT900_3_4_F3.Text = "";
            lblT900_3_4_F4.Text = "";
            lblT900_3_4_F5.Text = "";
            lblT900_3_4_F6.Text = "";
            lblT900_3_4_F7.Text = "";
            lblT900_CoilNo.Text = "";
            lblT900_SteelName.Text = "";
            lblT900_Thick.Text = "";
            lblT900_Width.Text = "";
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
            lblWorker13.Text = "";
            lblWorker14.Text = "";
            lblWorker15.Text = "";
            lblWorker16.Text = "";
            lblWorker17.Text = "";
            lblWorker18.Text = "";
            lblWorker19.Text = "";
            lblWorker20.Text = "";
            lblWorker21.Text = "";
            lblWorker22.Text = "";
            lblWorker23.Text = "";
            lblWorker24.Text = "";
        }

        private void PreloadChart()
        {
            int ticCount = 45;
            chtT1800_F1.Category = new string[ticCount];
            chtT1800_F2.Category = new string[ticCount];
            chtT1800_F3.Category = new string[ticCount];
            chtT1800_F4.Category = new string[ticCount];
            chtT1800_F5.Category = new string[ticCount];
            chtT1800_F6.Category = new string[ticCount];
            chtT1800_F7.Category = new string[ticCount];
            for (int i = 0; i < ticCount; i++)
            {
                chtT1800_F1.Category[i] = "";
                chtT1800_F2.Category[i] = "";
                chtT1800_F3.Category[i] = "";
                chtT1800_F4.Category[i] = "";
                chtT1800_F5.Category[i] = "";
                chtT1800_F6.Category[i] = "";
                chtT1800_F7.Category[i] = "";
            }

            int maxCatCount = 2187;
            chtT1800_F1.CategoryAxis2.Labels = new string[maxCatCount];
            chtT1800_F1.ValueAxis2.ValueCategory = maxCatCount;

            chtT1800_F2.CategoryAxis2.Labels = new string[maxCatCount];
            chtT1800_F2.ValueAxis2.ValueCategory = maxCatCount;

            chtT1800_F3.CategoryAxis2.Labels = new string[maxCatCount];
            chtT1800_F3.ValueAxis2.ValueCategory = maxCatCount;

            chtT1800_F4.CategoryAxis2.Labels = new string[maxCatCount];
            chtT1800_F4.ValueAxis2.ValueCategory = maxCatCount;

            chtT1800_F5.CategoryAxis2.Labels = new string[maxCatCount];
            chtT1800_F5.ValueAxis2.ValueCategory = maxCatCount;

            chtT1800_F6.CategoryAxis2.Labels = new string[maxCatCount];
            chtT1800_F6.ValueAxis2.ValueCategory = maxCatCount;

            chtT1800_F7.CategoryAxis2.Labels = new string[maxCatCount];
            chtT1800_F7.ValueAxis2.ValueCategory = maxCatCount;

            chtT800_3.Legend.SampeSize = new Size(30, chtT800_3.Legend.SampeSize.Height);
            chtT800_4.Legend.SampeSize = new Size(30, chtT800_4.Legend.SampeSize.Height);
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
            lblT900_3_4_F1.ForeColor = _Default_Color2;
            lblT900_3_4_F2.ForeColor = _Default_Color2;
            lblT900_3_4_F3.ForeColor = _Default_Color2;
            lblT900_3_4_F4.ForeColor = _Default_Color2;
            lblT900_3_4_F5.ForeColor = _Default_Color2;
            lblT900_3_4_F6.ForeColor = _Default_Color2;
            lblT900_3_4_F7.ForeColor = _Default_Color2;

            lblT900_3_2_F1F2.ForeColor = _Default_Color1;
            lblT900_3_2_F2F3.ForeColor = _Default_Color1;
            lblT900_3_2_F3F4.ForeColor = _Default_Color1;
            lblT900_3_2_F4F5.ForeColor = _Default_Color1;
            lblT900_3_2_F5F6.ForeColor = _Default_Color1;
            lblT900_3_2_F6F7.ForeColor = _Default_Color1;

            HighLightT900();

            _SimulateTime1 = 1;
            _SimulateTime2 = 1;

            chtT900_1.ValueAxis1.BarSeries.Clear();
            chtT900_1.ValueAxis2.BarSeries.Clear();
            chtT900_2.ValueAxis1.BarSeries.Clear();
            chtT900_2.ValueAxis2.BarSeries.Clear();

            chtT900_1.ValueAxis1.LineSeries.Clear();
            chtT900_1.ValueAxis2.LineSeries.Clear();
            chtT900_2.ValueAxis1.LineSeries.Clear();
            chtT900_2.ValueAxis2.LineSeries.Clear();

            chtT900_1.ValueAxis1.UpdateBarSeries.Clear();
            chtT900_1.ValueAxis2.UpdateBarSeries.Clear();
            chtT900_2.ValueAxis1.UpdateBarSeries.Clear();
            chtT900_2.ValueAxis2.UpdateBarSeries.Clear();

            Gamen gamenT900 = new Gamen(t900.ID, 1);
            double[] gamens = null;
            if (gamenT900.ID > 0)
            {
                gamens = gamenT900.GetValues();
            }

            lblT900_CoilNo.Text = t900.R025;
            lblT900_Thick.Text = (t900.R167 * 0.01).ToString("0.00;-0.00;0.00");
            lblT900_Width.Text = t900.R165.ToString();
            lblT900_SteelName.Text = t900.R071;

            if (gamens != null)
            {
                lblGamen002.Text = "負荷率：" + (gamens[1] == Double.MinValue ? "" : (gamens[1]).ToString());
            }
            else
            {
                lblGamen002.Text = "負荷率：";
            }

            T900_I2_06 t900_R367 = t900.R367;            
            if(t900_R367 != null)
            {
                lblT900_1_F1F2.Text = (t900_R367.R1 * 0.01).ToString("0.00;-0.00;0.00");
                lblT900_1_F2F3.Text = (t900_R367.R2 * 0.01).ToString("0.00;-0.00;0.00");
                lblT900_1_F3F4.Text = (t900_R367.R3 * 0.01).ToString("0.00;-0.00;0.00");
                lblT900_1_F4F5.Text = (t900_R367.R4 * 0.01).ToString("0.00;-0.00;0.00");
                lblT900_1_F5F6.Text = (t900_R367.R5 * 0.01).ToString("0.00;-0.00;0.00");
                lblT900_1_F6F7.Text = (t900_R367.R6 * 0.01).ToString("0.00;-0.00;0.00");

                BarSeries bs1_t900 = new BarSeries("当材予備計算");
                bs1_t900.Size = 15;
                bs1_t900.Color = lblT900_Color1.BackColor;
                bs1_t900.BorderSize = 1;
                bs1_t900.BorderColor = Color.White;
                bs1_t900.Values.Add(t900_R367.R1 * 0.01);
                bs1_t900.Values.Add(t900_R367.R2 * 0.01);
                bs1_t900.Values.Add(t900_R367.R3 * 0.01);
                bs1_t900.Values.Add(t900_R367.R4 * 0.01);
                bs1_t900.Values.Add(t900_R367.R5 * 0.01);
                bs1_t900.Values.Add(t900_R367.R6 * 0.01);
                chtT900_1.ValueAxis1.BarSeries.Add(bs1_t900);

                //lblT900_3_1_F1F2.Text = (t900_R367.R1 * 0.01).ToString("0.00;-0.00;0.00");
                //lblT900_3_1_F2F3.Text = (t900_R367.R2 * 0.01).ToString("0.00;-0.00;0.00");
                //lblT900_3_1_F3F4.Text = (t900_R367.R3 * 0.01).ToString("0.00;-0.00;0.00");
                //lblT900_3_1_F4F5.Text = (t900_R367.R4 * 0.01).ToString("0.00;-0.00;0.00");
                //lblT900_3_1_F5F6.Text = (t900_R367.R5 * 0.01).ToString("0.00;-0.00;0.00");
                //lblT900_3_1_F6F7.Text = (t900_R367.R6 * 0.01).ToString("0.00;-0.00;0.00");

                //lblT900_3_2_F1F2.Text = (t900_R367.R1 * 0.01).ToString("0.00;-0.00;0.00");
                //lblT900_3_2_F2F3.Text = (t900_R367.R2 * 0.01).ToString("0.00;-0.00;0.00");
                //lblT900_3_2_F3F4.Text = (t900_R367.R3 * 0.01).ToString("0.00;-0.00;0.00");
                //lblT900_3_2_F4F5.Text = (t900_R367.R4 * 0.01).ToString("0.00;-0.00;0.00");
                //lblT900_3_2_F5F6.Text = (t900_R367.R5 * 0.01).ToString("0.00;-0.00;0.00");
                //lblT900_3_2_F6F7.Text = (t900_R367.R6 * 0.01).ToString("0.00;-0.00;0.00");

            }

            T900_I2_06 t900_R379 = t900.R379;
            if (t900_R379 != null)
            {
                BarSeries bs2_t900 = new BarSeries("圧下位置差介入量");
                bs2_t900.Size = 15;
                bs2_t900.Color = Color.Pink;
                bs2_t900.BorderSize = 1;
                bs2_t900.BorderColor = Color.White;
                bs2_t900.Values.Add(t900_R379.R1 * 0.01);
                bs2_t900.Values.Add(t900_R379.R2 * 0.01);
                bs2_t900.Values.Add(t900_R379.R3 * 0.01);
                bs2_t900.Values.Add(t900_R379.R4 * 0.01);
                bs2_t900.Values.Add(t900_R379.R5 * 0.01);
                bs2_t900.Values.Add(t900_R379.R6 * 0.01);
                chtT900_1.ValueAxis2.BarSeries.Add(bs2_t900);
            }

            T900_I2_07 t900_R227 = t900.R227;
            if (t900_R227 != null)
            {
                //lblT900_3_3_F1.Text = t900_R227.F1.ToString();
                //lblT900_3_3_F2.Text = t900_R227.F2.ToString();
                //lblT900_3_3_F3.Text = t900_R227.F3.ToString();
                //lblT900_3_3_F4.Text = t900_R227.F4.ToString();
                //lblT900_3_3_F5.Text = t900_R227.F5.ToString();
                //lblT900_3_3_F6.Text = t900_R227.F6.ToString();
                //lblT900_3_3_F7.Text = t900_R227.F7.ToString();

                //lblT900_3_4_F1.Text = t900_R227.F1.ToString();
                //lblT900_3_4_F2.Text = t900_R227.F2.ToString();
                //lblT900_3_4_F3.Text = t900_R227.F3.ToString();
                //lblT900_3_4_F4.Text = t900_R227.F4.ToString();
                //lblT900_3_4_F5.Text = t900_R227.F5.ToString();
                //lblT900_3_4_F6.Text = t900_R227.F6.ToString();
                //lblT900_3_4_F7.Text = t900_R227.F7.ToString();

                BarSeries bs3_t900 = new BarSeries("当材設定計算");
                bs3_t900.Size = 15;
                bs3_t900.Color = lblT900_Color1.BackColor;
                bs3_t900.BorderSize = 1;
                bs3_t900.BorderColor = Color.White;

                bs3_t900.Values.Add(t900_R227.F1 / (t900_R227.F1 * 1.0));
                bs3_t900.Values.Add(t900_R227.F2 / (t900_R227.F1 * 1.0));
                bs3_t900.Values.Add(t900_R227.F3 / (t900_R227.F1 * 1.0));
                bs3_t900.Values.Add(t900_R227.F4 / (t900_R227.F1 * 1.0));
                bs3_t900.Values.Add(t900_R227.F5 / (t900_R227.F1 * 1.0));
                bs3_t900.Values.Add(t900_R227.F6 / (t900_R227.F1 * 1.0));
                bs3_t900.Values.Add(t900_R227.F7 / (t900_R227.F1 * 1.0));

                chtT900_2.ValueAxis1.BarSeries.Add(bs3_t900);
            }
            else
            {
                lblT900_3_3_F1.Text = "";
                lblT900_3_3_F2.Text = "";
                lblT900_3_3_F3.Text = "";
                lblT900_3_3_F4.Text = "";
                lblT900_3_3_F5.Text = "";
                lblT900_3_3_F6.Text = "";
                lblT900_3_3_F7.Text = "";

                lblT900_3_4_F1.Text = "";
                lblT900_3_4_F2.Text = "";
                lblT900_3_4_F3.Text = "";
                lblT900_3_4_F4.Text = "";
                lblT900_3_4_F5.Text = "";
                lblT900_3_4_F6.Text = "";
                lblT900_3_4_F7.Text = "";
            }

            if (gamens != null)
            {
                lblT900_3_1_F1F2.Text = (gamens[55]).ToString("0.00;-0.00;0.00");
                lblT900_3_1_F2F3.Text = (gamens[56]).ToString("0.00;-0.00;0.00");
                lblT900_3_1_F3F4.Text = (gamens[57]).ToString("0.00;-0.00;0.00");
                lblT900_3_1_F4F5.Text = (gamens[58]).ToString("0.00;-0.00;0.00");
                lblT900_3_1_F5F6.Text = (gamens[59]).ToString("0.00;-0.00;0.00");
                lblT900_3_1_F6F7.Text = (gamens[60]).ToString("0.00;-0.00;0.00");

                lblT900_3_2_F1F2.Text = (gamens[55]).ToString("0.00;-0.00;0.00");
                lblT900_3_2_F2F3.Text = (gamens[56]).ToString("0.00;-0.00;0.00");
                lblT900_3_2_F3F4.Text = (gamens[57]).ToString("0.00;-0.00;0.00");
                lblT900_3_2_F4F5.Text = (gamens[58]).ToString("0.00;-0.00;0.00");
                lblT900_3_2_F5F6.Text = (gamens[59]).ToString("0.00;-0.00;0.00");
                lblT900_3_2_F6F7.Text = (gamens[60]).ToString("0.00;-0.00;0.00");

                lblT900_3_3_F1.Text = gamens[68].ToString("0;-0;0");
                lblT900_3_3_F2.Text = gamens[69].ToString("0;-0;0");
                lblT900_3_3_F3.Text = gamens[70].ToString("0;-0;0");
                lblT900_3_3_F4.Text = gamens[71].ToString("0;-0;0");
                lblT900_3_3_F5.Text = gamens[72].ToString("0;-0;0");
                lblT900_3_3_F6.Text = gamens[73].ToString("0;-0;0");
                lblT900_3_3_F7.Text = gamens[74].ToString("0;-0;0");

                lblT900_3_4_F1.Text = gamens[68].ToString("0;-0;0");
                lblT900_3_4_F2.Text = gamens[69].ToString("0;-0;0");
                lblT900_3_4_F3.Text = gamens[70].ToString("0;-0;0");
                lblT900_3_4_F4.Text = gamens[71].ToString("0;-0;0");
                lblT900_3_4_F5.Text = gamens[72].ToString("0;-0;0");
                lblT900_3_4_F6.Text = gamens[73].ToString("0;-0;0");
                lblT900_3_4_F7.Text = gamens[74].ToString("0;-0;0");

                // chart 1
                LineSeries ls1_t900 = new LineSeries("上限パターン");
                ls1_t900.Color = lblLine_Lime.BackColor;
                ls1_t900.Marker.BackColor = ls1_t900.Marker.ForeColor = ls1_t900.Color;
                ls1_t900.Marker.Style = MarkerStyle.THANG;
                ls1_t900.Marker.Size = 1;
                ls1_t900.Size = 2;

                ls1_t900.Values.Add(gamens[2]);
                ls1_t900.Values.Add(gamens[3]);
                ls1_t900.Values.Add(gamens[4]);
                ls1_t900.Values.Add(gamens[5]);
                ls1_t900.Values.Add(gamens[6]);
                ls1_t900.Values.Add(gamens[7]);

                chtT900_1.ValueAxis1.LineSeries.Add(ls1_t900);

                LineSeries ls2_t900 = new LineSeries("中央パターン");
                ls2_t900.Color = lblLine_Fuchsia.BackColor;
                ls2_t900.Marker.BackColor = ls2_t900.Marker.ForeColor = ls2_t900.Color;
                ls2_t900.Marker.Style = MarkerStyle.THANG;
                ls2_t900.Marker.Size = 1;
                ls2_t900.Size = 2;

                ls2_t900.Values.Add(gamens[8]);
                ls2_t900.Values.Add(gamens[9]);
                ls2_t900.Values.Add(gamens[10]);
                ls2_t900.Values.Add(gamens[11]);
                ls2_t900.Values.Add(gamens[12]);
                ls2_t900.Values.Add(gamens[13]);

                chtT900_1.ValueAxis1.LineSeries.Add(ls2_t900);

                LineSeries ls3_t900 = new LineSeries("下限パターン");
                ls3_t900.Color = lblLine_Cyan.BackColor;
                ls3_t900.Marker.BackColor = ls3_t900.Marker.ForeColor = ls3_t900.Color;
                ls3_t900.Marker.Style = MarkerStyle.THANG;
                ls3_t900.Marker.Size = 1;
                ls3_t900.Size = 2;

                ls3_t900.Values.Add(gamens[14]);
                ls3_t900.Values.Add(gamens[15]);
                ls3_t900.Values.Add(gamens[16]);
                ls3_t900.Values.Add(gamens[17]);
                ls3_t900.Values.Add(gamens[18]);
                ls3_t900.Values.Add(gamens[19]);

                chtT900_1.ValueAxis1.LineSeries.Add(ls3_t900);

                BarSeries bs1_t900 = new BarSeries("過去実績平均");
                bs1_t900.Size = 15;
                bs1_t900.Color = lblT900_Color2.BackColor;
                bs1_t900.BorderSize = 1;
                bs1_t900.BorderColor = Color.White;
                bs1_t900.Values.Add(gamens[20]);
                bs1_t900.Values.Add(gamens[21]);
                bs1_t900.Values.Add(gamens[22]);
                bs1_t900.Values.Add(gamens[23]);
                bs1_t900.Values.Add(gamens[24]);
                bs1_t900.Values.Add(gamens[25]);
                chtT900_1.ValueAxis1.BarSeries.Add(bs1_t900);

                BarSeries bs2_t900 = new BarSeries("Blank");
                bs2_t900.Size = 15;
                //bs2_t900.Color = lblT900_Color2.BackColor;
                bs2_t900.BorderSize = 3;
                bs2_t900.BorderColor = Color.SkyBlue;
                bs2_t900.Values.Add(gamens[55]);
                bs2_t900.Values.Add(gamens[56]);
                bs2_t900.Values.Add(gamens[57]);
                bs2_t900.Values.Add(gamens[58]);
                bs2_t900.Values.Add(gamens[59]);
                bs2_t900.Values.Add(gamens[60]);
                chtT900_1.ValueAxis1.UpdateBarSeries.Add(bs2_t900);

                BarSeries bs6_t900 = new BarSeries("Blank");
                chtT900_1.ValueAxis1.UpdateBarSeries.Add(bs6_t900);
                // end chart 1

                // chart 2
                LineSeries ls4_t900 = new LineSeries("上限パターン");
                ls4_t900.Color = lblLine_Lime.BackColor;
                ls4_t900.Marker.BackColor = ls4_t900.Marker.ForeColor = ls4_t900.Color;
                ls4_t900.Marker.Style = MarkerStyle.THANG;
                ls4_t900.Marker.Size = 1;
                ls4_t900.Size = 2;

                ls4_t900.Values.Add(gamens[26]);
                ls4_t900.Values.Add(gamens[27]);
                ls4_t900.Values.Add(gamens[28]);
                ls4_t900.Values.Add(gamens[29]);
                ls4_t900.Values.Add(gamens[30]);
                ls4_t900.Values.Add(gamens[31]);
                ls4_t900.Values.Add(gamens[32]);

                chtT900_2.ValueAxis1.LineSeries.Add(ls4_t900);

                LineSeries ls5_t900 = new LineSeries("中央パターン");
                ls5_t900.Color = lblLine_Fuchsia.BackColor;
                ls5_t900.Marker.BackColor = ls5_t900.Marker.ForeColor = ls5_t900.Color;
                ls5_t900.Marker.Style = MarkerStyle.THANG;
                ls5_t900.Marker.Size = 1;
                ls5_t900.Size = 2;

                ls5_t900.Values.Add(gamens[33]);
                ls5_t900.Values.Add(gamens[34]);
                ls5_t900.Values.Add(gamens[35]);
                ls5_t900.Values.Add(gamens[36]);
                ls5_t900.Values.Add(gamens[37]);
                ls5_t900.Values.Add(gamens[38]);
                ls5_t900.Values.Add(gamens[39]);

                chtT900_2.ValueAxis1.LineSeries.Add(ls5_t900);

                LineSeries ls6_t900 = new LineSeries("下限パターン");
                ls6_t900.Color = lblLine_Cyan.BackColor;
                ls6_t900.Marker.BackColor = ls6_t900.Marker.ForeColor = ls6_t900.Color;
                ls6_t900.Marker.Style = MarkerStyle.THANG;
                ls6_t900.Marker.Size = 1;
                ls6_t900.Size = 2;

                ls6_t900.Values.Add(gamens[40]);
                ls6_t900.Values.Add(gamens[41]);
                ls6_t900.Values.Add(gamens[42]);
                ls6_t900.Values.Add(gamens[43]);
                ls6_t900.Values.Add(gamens[44]);
                ls6_t900.Values.Add(gamens[45]);
                ls6_t900.Values.Add(gamens[46]);

                chtT900_2.ValueAxis1.LineSeries.Add(ls6_t900);

                BarSeries bs3_t900 = new BarSeries("過去実績平均");
                bs3_t900.Size = 15;
                bs3_t900.Color = lblT900_Color2.BackColor;
                bs3_t900.BorderSize = 1;
                bs3_t900.BorderColor = Color.White;
                bs3_t900.Values.Add(gamens[47]);
                bs3_t900.Values.Add(gamens[48]);
                bs3_t900.Values.Add(gamens[49]);
                bs3_t900.Values.Add(gamens[50]);
                bs3_t900.Values.Add(gamens[51]);
                bs3_t900.Values.Add(gamens[52]);
                bs3_t900.Values.Add(gamens[53]);
                chtT900_2.ValueAxis1.BarSeries.Add(bs3_t900);

                BarSeries bs4_t900 = new BarSeries("Blank");
                bs4_t900.Size = 15;
                bs4_t900.BorderSize = 3;
                bs4_t900.BorderColor = Color.SkyBlue;
                bs4_t900.Values.Add(gamens[61]);
                bs4_t900.Values.Add(gamens[62]);
                bs4_t900.Values.Add(gamens[63]);
                bs4_t900.Values.Add(gamens[64]);
                bs4_t900.Values.Add(gamens[65]);
                bs4_t900.Values.Add(gamens[66]);
                bs4_t900.Values.Add(gamens[67]);
                chtT900_2.ValueAxis1.UpdateBarSeries.Add(bs4_t900);

                BarSeries bs5_t900 = new BarSeries("Blank");
                chtT900_2.ValueAxis1.UpdateBarSeries.Add(bs5_t900);
                // end chart 2
            }

            lblGamen002.Refresh();
        }

        protected void FillData(T800 t800)
        {
            HighLightT800();

            chtT800_1.ValueAxis1.BarSeries.Clear();
            chtT800_1.ValueAxis2.BarSeries.Clear();
            chtT800_1.ValueAxis1.LineSeries.Clear();
            chtT800_1.ValueAxis2.LineSeries.Clear();
            chtT800_1.ValueAxis1.UpdateBarSeries.Clear();
            chtT800_1.ValueAxis2.UpdateBarSeries.Clear();

            chtT800_2.ValueAxis1.BarSeries.Clear();
            chtT800_2.ValueAxis1.LineSeries.Clear();
            chtT800_2.ValueAxis1.UpdateBarSeries.Clear();
            
            chtT800_3.ValueAxis1.LineSeries.Clear();
            chtT800_4.ValueAxis1.LineSeries.Clear();

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
                lblGamen077.Text = "負荷率：" + (gamens[76] == Double.MinValue ? "" : (gamens[76]).ToString());
            }
            else
            {
                lblGamen077.Text = "負荷率：";
            }

            T800_I2_06 t800_R319 = t800.R319;
            if (t800_R319 != null)
            {
                lblT800_1_F1F2.Text = (t800_R319.R1 * 0.01).ToString("0.00;-0.00;0.00");
                lblT800_1_F2F3.Text = (t800_R319.R2 * 0.01).ToString("0.00;-0.00;0.00");
                lblT800_1_F3F4.Text = (t800_R319.R3 * 0.01).ToString("0.00;-0.00;0.00");
                lblT800_1_F4F5.Text = (t800_R319.R4 * 0.01).ToString("0.00;-0.00;0.00");
                lblT800_1_F5F6.Text = (t800_R319.R5 * 0.01).ToString("0.00;-0.00;0.00");
                lblT800_1_F6F7.Text = (t800_R319.R6 * 0.01).ToString("0.00;-0.00;0.00");

                BarSeries bs1_t800 = new BarSeries("当材設定計算");
                bs1_t800.Size = 15;
                bs1_t800.Color = lblT800_Color1.BackColor;
                bs1_t800.BorderSize = 1;
                bs1_t800.BorderColor = Color.White;
                bs1_t800.Values.Add(t800_R319.R1 * 0.01);
                bs1_t800.Values.Add(t800_R319.R2 * 0.01);
                bs1_t800.Values.Add(t800_R319.R3 * 0.01);
                bs1_t800.Values.Add(t800_R319.R4 * 0.01);
                bs1_t800.Values.Add(t800_R319.R5 * 0.01);
                bs1_t800.Values.Add(t800_R319.R6 * 0.01);

                chtT800_1.ValueAxis1.BarSeries.Add(bs1_t800);
            }

            T800_I2_06 t800_R331 = t800.R331;
            if (t800_R331 != null)
            {
                BarSeries bs2_t800 = new BarSeries("圧下位置差介入量");
                bs2_t800.Size = 15;
                bs2_t800.Color = Color.SkyBlue;
                bs2_t800.BorderSize = 1;
                bs2_t800.BorderColor = Color.White;

                bs2_t800.Values.Add(t800_R331.R1 * 0.01);
                bs2_t800.Values.Add(t800_R331.R2 * 0.01);
                bs2_t800.Values.Add(t800_R331.R3 * 0.01);
                bs2_t800.Values.Add(t800_R331.R4 * 0.01);
                bs2_t800.Values.Add(t800_R331.R5 * 0.01);
                bs2_t800.Values.Add(t800_R331.R6 * 0.01);

                chtT800_1.ValueAxis2.BarSeries.Add(bs2_t800);
            }

            T800_I2_07 t800_R179 = t800.R179;
            if (t800_R179 != null)
            {
                BarSeries bs3_t800 = new BarSeries("当材設定計算");
                bs3_t800.Size = 15;
                bs3_t800.Color = lblT800_Color1.BackColor;
                bs3_t800.BorderSize = 1;
                bs3_t800.BorderColor = Color.White;

                bs3_t800.Values.Add(t800_R179.F1 / (t800_R179.F1 * 1.0));
                bs3_t800.Values.Add(t800_R179.F2 / (t800_R179.F1 * 1.0));
                bs3_t800.Values.Add(t800_R179.F3 / (t800_R179.F1 * 1.0));
                bs3_t800.Values.Add(t800_R179.F4 / (t800_R179.F1 * 1.0));
                bs3_t800.Values.Add(t800_R179.F5 / (t800_R179.F1 * 1.0));
                bs3_t800.Values.Add(t800_R179.F6 / (t800_R179.F1 * 1.0));
                bs3_t800.Values.Add(t800_R179.F7 / (t800_R179.F1 * 1.0));

                chtT800_2.ValueAxis1.BarSeries.Add(bs3_t800);
            }

            // line 3
            T800_I2_07_10 t800_R561 = t800.R561;
            T800_I2_07_10 t800_R575 = t800.R575;
            T800_I2_07_10 t800_R589 = t800.R589;
            T800_I2_07_10 t800_R603 = t800.R603;
            T800_I2_07_10 t800_R617 = t800.R617;
            T800_I2_07_10 t800_R631 = t800.R631;
            T800_I2_07_10 t800_R645 = t800.R645;
            T800_I2_07_10 t800_R659 = t800.R659;
            T800_I2_07_10 t800_R673 = t800.R673;
            T800_I2_07_10 t800_R687 = t800.R687;
            if (t800_R561 != null)
            {
                LineSeries bs4_t800 = new LineSeries("F1");
                bs4_t800.Size = 2;
                bs4_t800.Color = Color.Cyan;
                bs4_t800.Marker.Size = 11;
                bs4_t800.Marker.Style = MarkerStyle.THOI;
                bs4_t800.Marker.BackColor = bs4_t800.Marker.ForeColor = bs4_t800.Color;

                bs4_t800.Values.Add(t800_R561.F1);
                bs4_t800.Values.Add(t800_R575.F1);
                bs4_t800.Values.Add(t800_R589.F1);
                bs4_t800.Values.Add(t800_R603.F1);
                bs4_t800.Values.Add(t800_R617.F1);
                bs4_t800.Values.Add(t800_R631.F1);
                bs4_t800.Values.Add(t800_R645.F1);
                bs4_t800.Values.Add(t800_R659.F1);
                bs4_t800.Values.Add(t800_R673.F1);
                bs4_t800.Values.Add(t800_R687.F1);

                chtT800_3.ValueAxis1.LineSeries.Add(bs4_t800);

                LineSeries bs5_t800 = new LineSeries("F2");
                bs5_t800.Size = 2;
                bs5_t800.Color = Color.Magenta;
                bs5_t800.Marker.Size = 10;
                bs5_t800.Marker.Style = MarkerStyle.VUONG;
                bs5_t800.Marker.BackColor = bs5_t800.Marker.ForeColor = bs5_t800.Color;

                bs5_t800.Values.Add(t800_R561.F2);
                bs5_t800.Values.Add(t800_R575.F2);
                bs5_t800.Values.Add(t800_R589.F2);
                bs5_t800.Values.Add(t800_R603.F2);
                bs5_t800.Values.Add(t800_R617.F2);
                bs5_t800.Values.Add(t800_R631.F2);
                bs5_t800.Values.Add(t800_R645.F2);
                bs5_t800.Values.Add(t800_R659.F2);
                bs5_t800.Values.Add(t800_R673.F2);
                bs5_t800.Values.Add(t800_R687.F2);

                chtT800_3.ValueAxis1.LineSeries.Add(bs5_t800);

                LineSeries bs6_t800 = new LineSeries("F3");
                bs6_t800.Size = 2;
                bs6_t800.Color = Color.Yellow;
                bs6_t800.Marker.Size = 11;
                bs6_t800.Marker.Style = MarkerStyle.TAM_GIAC;
                bs6_t800.Marker.BackColor = bs6_t800.Marker.ForeColor = bs6_t800.Color;

                bs6_t800.Values.Add(t800_R561.F3);
                bs6_t800.Values.Add(t800_R575.F3);
                bs6_t800.Values.Add(t800_R589.F3);
                bs6_t800.Values.Add(t800_R603.F3);
                bs6_t800.Values.Add(t800_R617.F3);
                bs6_t800.Values.Add(t800_R631.F3);
                bs6_t800.Values.Add(t800_R645.F3);
                bs6_t800.Values.Add(t800_R659.F3);
                bs6_t800.Values.Add(t800_R673.F3);
                bs6_t800.Values.Add(t800_R687.F3);

                chtT800_3.ValueAxis1.LineSeries.Add(bs6_t800);
            }

            T800_I2_07_10 t800_R701 = t800.R701;
            T800_I2_07_10 t800_R715 = t800.R715;
            T800_I2_07_10 t800_R729 = t800.R729;
            T800_I2_07_10 t800_R743 = t800.R743;
            T800_I2_07_10 t800_R757 = t800.R757;
            T800_I2_07_10 t800_R771 = t800.R771;
            T800_I2_07_10 t800_R785 = t800.R785;
            T800_I2_07_10 t800_R799 = t800.R799;
            T800_I2_07_10 t800_R813 = t800.R813;
            T800_I2_07_10 t800_R827 = t800.R827;
            if (t800_R701 != null)
            {
                LineSeries bs7_t800 = new LineSeries("F4");
                bs7_t800.Size = 2;
                bs7_t800.Color = Color.Cyan;
                bs7_t800.Marker.Size = 11;
                bs7_t800.Marker.Style = MarkerStyle.THOI;
                bs7_t800.Marker.BackColor = bs7_t800.Marker.ForeColor = bs7_t800.Color;

                bs7_t800.Values.Add(t800_R701.F4);
                bs7_t800.Values.Add(t800_R715.F4);
                bs7_t800.Values.Add(t800_R729.F4);
                bs7_t800.Values.Add(t800_R743.F4);
                bs7_t800.Values.Add(t800_R757.F4);
                bs7_t800.Values.Add(t800_R771.F4);
                bs7_t800.Values.Add(t800_R785.F4);
                bs7_t800.Values.Add(t800_R799.F4);
                bs7_t800.Values.Add(t800_R813.F4);
                bs7_t800.Values.Add(t800_R827.F4);

                chtT800_4.ValueAxis1.LineSeries.Add(bs7_t800);

                LineSeries bs8_t800 = new LineSeries("F5");
                bs8_t800.Size = 2;
                bs8_t800.Color = Color.Magenta;
                bs8_t800.Marker.Size = 10;
                bs8_t800.Marker.Style = MarkerStyle.VUONG;
                bs8_t800.Marker.BackColor = bs8_t800.Marker.ForeColor = bs8_t800.Color;

                bs8_t800.Values.Add(t800_R701.F5);
                bs8_t800.Values.Add(t800_R715.F5);
                bs8_t800.Values.Add(t800_R729.F5);
                bs8_t800.Values.Add(t800_R743.F5);
                bs8_t800.Values.Add(t800_R757.F5);
                bs8_t800.Values.Add(t800_R771.F5);
                bs8_t800.Values.Add(t800_R785.F5);
                bs8_t800.Values.Add(t800_R799.F5);
                bs8_t800.Values.Add(t800_R813.F5);
                bs8_t800.Values.Add(t800_R827.F5);

                chtT800_4.ValueAxis1.LineSeries.Add(bs8_t800);

                LineSeries bs9_t800 = new LineSeries("F6");
                bs9_t800.Size = 2;
                bs9_t800.Color = Color.Yellow;
                bs9_t800.Marker.Size = 11;
                bs9_t800.Marker.Style = MarkerStyle.TAM_GIAC;
                bs9_t800.Marker.BackColor = bs9_t800.Marker.ForeColor = bs9_t800.Color;

                bs9_t800.Values.Add(t800_R701.F6);
                bs9_t800.Values.Add(t800_R715.F6);
                bs9_t800.Values.Add(t800_R729.F6);
                bs9_t800.Values.Add(t800_R743.F6);
                bs9_t800.Values.Add(t800_R757.F6);
                bs9_t800.Values.Add(t800_R771.F6);
                bs9_t800.Values.Add(t800_R785.F6);
                bs9_t800.Values.Add(t800_R799.F6);
                bs9_t800.Values.Add(t800_R813.F6);
                bs9_t800.Values.Add(t800_R827.F6);

                chtT800_4.ValueAxis1.LineSeries.Add(bs9_t800);

                LineSeries bs10_t800 = new LineSeries("F7");
                bs10_t800.Size = 2;
                bs10_t800.Color = Color.FromArgb(255,192,255);
                bs10_t800.Marker.Size = 10;
                bs10_t800.Marker.Style = MarkerStyle.TRON;
                bs10_t800.Marker.BackColor = bs10_t800.Marker.ForeColor = bs10_t800.Color;

                bs10_t800.Values.Add(t800_R701.F7);
                bs10_t800.Values.Add(t800_R715.F7);
                bs10_t800.Values.Add(t800_R729.F7);
                bs10_t800.Values.Add(t800_R743.F7);
                bs10_t800.Values.Add(t800_R757.F7);
                bs10_t800.Values.Add(t800_R771.F7);
                bs10_t800.Values.Add(t800_R785.F7);
                bs10_t800.Values.Add(t800_R799.F7);
                bs10_t800.Values.Add(t800_R813.F7);
                bs10_t800.Values.Add(t800_R827.F7);

                chtT800_4.ValueAxis1.LineSeries.Add(bs10_t800);
            }

            if (gamens != null)
            {
                // chart 1
                LineSeries ls1_t900 = new LineSeries("上限パターン");
                ls1_t900.Color = lblLine_Lime.BackColor;
                ls1_t900.Marker.BackColor = ls1_t900.Marker.ForeColor = ls1_t900.Color;
                ls1_t900.Marker.Style = MarkerStyle.THANG;
                ls1_t900.Marker.Size = 1;
                ls1_t900.Size = 2;

                ls1_t900.Values.Add(gamens[2]);
                ls1_t900.Values.Add(gamens[3]);
                ls1_t900.Values.Add(gamens[4]);
                ls1_t900.Values.Add(gamens[5]);
                ls1_t900.Values.Add(gamens[6]);
                ls1_t900.Values.Add(gamens[7]);

                chtT800_1.ValueAxis1.LineSeries.Add(ls1_t900);

                LineSeries ls2_t900 = new LineSeries("中央パターン");
                ls2_t900.Color = lblLine_Fuchsia.BackColor;
                ls2_t900.Marker.BackColor = ls2_t900.Marker.ForeColor = ls2_t900.Color;
                ls2_t900.Marker.Style = MarkerStyle.THANG;
                ls2_t900.Marker.Size = 1;
                ls2_t900.Size = 2;

                ls2_t900.Values.Add(gamens[8]);
                ls2_t900.Values.Add(gamens[9]);
                ls2_t900.Values.Add(gamens[10]);
                ls2_t900.Values.Add(gamens[11]);
                ls2_t900.Values.Add(gamens[12]);
                ls2_t900.Values.Add(gamens[13]);

                chtT800_1.ValueAxis1.LineSeries.Add(ls2_t900);

                LineSeries ls3_t900 = new LineSeries("下限パターン");
                ls3_t900.Color = lblLine_Cyan.BackColor;
                ls3_t900.Marker.BackColor = ls3_t900.Marker.ForeColor = ls3_t900.Color;
                ls3_t900.Marker.Style = MarkerStyle.THANG;
                ls3_t900.Marker.Size = 1;
                ls3_t900.Size = 2;

                ls3_t900.Values.Add(gamens[14]);
                ls3_t900.Values.Add(gamens[15]);
                ls3_t900.Values.Add(gamens[16]);
                ls3_t900.Values.Add(gamens[17]);
                ls3_t900.Values.Add(gamens[18]);
                ls3_t900.Values.Add(gamens[19]);

                chtT800_1.ValueAxis1.LineSeries.Add(ls3_t900);

                BarSeries bs1_t900 = new BarSeries("過去実績平均");
                bs1_t900.Size = 15;
                bs1_t900.Color = lblT800_Color2.BackColor;
                bs1_t900.BorderSize = 1;
                bs1_t900.BorderColor = Color.White;
                bs1_t900.Values.Add(gamens[95]);
                bs1_t900.Values.Add(gamens[96]);
                bs1_t900.Values.Add(gamens[97]);
                bs1_t900.Values.Add(gamens[98]);
                bs1_t900.Values.Add(gamens[99]);
                bs1_t900.Values.Add(gamens[100]);
                chtT800_1.ValueAxis1.BarSeries.Add(bs1_t900);
                // end chart 1
                
                // chart 2
                LineSeries ls4_t900 = new LineSeries("上限パターン");
                ls4_t900.Color = lblLine_Lime.BackColor;
                ls4_t900.Marker.BackColor = ls4_t900.Marker.ForeColor = ls4_t900.Color;
                ls4_t900.Marker.Style = MarkerStyle.THANG;
                ls4_t900.Marker.Size = 1;
                ls4_t900.Size = 2;

                ls4_t900.Values.Add(gamens[101]);
                ls4_t900.Values.Add(gamens[102]);
                ls4_t900.Values.Add(gamens[103]);
                ls4_t900.Values.Add(gamens[104]);
                ls4_t900.Values.Add(gamens[105]);
                ls4_t900.Values.Add(gamens[106]);
                ls4_t900.Values.Add(gamens[107]);

                chtT800_2.ValueAxis1.LineSeries.Add(ls4_t900);

                LineSeries ls5_t900 = new LineSeries("中央パターン");
                ls5_t900.Color = lblLine_Fuchsia.BackColor;
                ls5_t900.Marker.BackColor = ls5_t900.Marker.ForeColor = ls5_t900.Color;
                ls5_t900.Marker.Style = MarkerStyle.THANG;
                ls5_t900.Marker.Size = 1;
                ls5_t900.Size = 2;

                ls5_t900.Values.Add(gamens[108]);
                ls5_t900.Values.Add(gamens[109]);
                ls5_t900.Values.Add(gamens[110]);
                ls5_t900.Values.Add(gamens[111]);
                ls5_t900.Values.Add(gamens[112]);
                ls5_t900.Values.Add(gamens[113]);
                ls5_t900.Values.Add(gamens[114]);

                chtT800_2.ValueAxis1.LineSeries.Add(ls5_t900);

                LineSeries ls6_t900 = new LineSeries("下限パターン");
                ls6_t900.Color = lblLine_Cyan.BackColor;
                ls6_t900.Marker.BackColor = ls6_t900.Marker.ForeColor = ls6_t900.Color;
                ls6_t900.Marker.Style = MarkerStyle.THANG;
                ls6_t900.Marker.Size = 1;
                ls6_t900.Size = 2;

                ls6_t900.Values.Add(gamens[115]);
                ls6_t900.Values.Add(gamens[116]);
                ls6_t900.Values.Add(gamens[117]);
                ls6_t900.Values.Add(gamens[118]);
                ls6_t900.Values.Add(gamens[119]);
                ls6_t900.Values.Add(gamens[120]);
                ls6_t900.Values.Add(gamens[121]);

                chtT800_2.ValueAxis1.LineSeries.Add(ls6_t900);

                BarSeries bs3_t900 = new BarSeries("過去実績平均");
                bs3_t900.Size = 15;
                bs3_t900.Color = lblT800_Color2.BackColor;
                bs3_t900.BorderSize = 1;
                bs3_t900.BorderColor = Color.White;
                bs3_t900.Values.Add(gamens[122]);
                bs3_t900.Values.Add(gamens[123]);
                bs3_t900.Values.Add(gamens[124]);
                bs3_t900.Values.Add(gamens[125]);
                bs3_t900.Values.Add(gamens[126]);
                bs3_t900.Values.Add(gamens[127]);
                bs3_t900.Values.Add(gamens[128]);
                chtT800_2.ValueAxis1.BarSeries.Add(bs3_t900);
                //end chart 2
            }

            lblGamen077.Refresh();
        }

        protected void FillData(T1800 t1800)
        {
            HighLightT1800();

            chtT1800_1.ValueAxis1.BarSeries.Clear();
            chtT1800_1.ValueAxis2.BarSeries.Clear();
            chtT1800_2.ValueAxis1.BarSeries.Clear();
            chtT1800_1.ValueAxis1.LineSeries.Clear();
            chtT1800_1.ValueAxis2.LineSeries.Clear();
            chtT1800_2.ValueAxis1.LineSeries.Clear();

            chtT1800_F1.ValueAxis1.LineSeries.Clear();
            chtT1800_F2.ValueAxis1.LineSeries.Clear();
            chtT1800_F3.ValueAxis1.LineSeries.Clear();
            chtT1800_F4.ValueAxis1.LineSeries.Clear();
            chtT1800_F5.ValueAxis1.LineSeries.Clear();
            chtT1800_F6.ValueAxis1.LineSeries.Clear();
            chtT1800_F7.ValueAxis1.LineSeries.Clear();
            chtT1800_F1.ValueAxis2.LineSeries.Clear();
            chtT1800_F2.ValueAxis2.LineSeries.Clear();
            chtT1800_F3.ValueAxis2.LineSeries.Clear();
            chtT1800_F4.ValueAxis2.LineSeries.Clear();
            chtT1800_F5.ValueAxis2.LineSeries.Clear();
            chtT1800_F6.ValueAxis2.LineSeries.Clear();
            chtT1800_F7.ValueAxis2.LineSeries.Clear();

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

            if (gamenT1800.ID > 0)
            {
                lblGamen131.Text = "負荷率：" + (gamens[130] == Double.MinValue ? "" : (gamens[130]).ToString());
            }
            else
            {
                lblGamen131.Text = "負荷率：";
            }

            T1800_I2_14 t1800_R0207 = t1800.R0195;
            if (t1800_R0207 != null)
            {
                lblT1800_1_F1F2.Text = ((t1800_R0207.F1_1 - t1800_R0207.F2_1) * 0.01).ToString("0.00;-0.00;0.00");
                lblT1800_1_F2F3.Text = ((t1800_R0207.F2_1 - t1800_R0207.F3_1) * 0.01).ToString("0.00;-0.00;0.00");
                lblT1800_1_F3F4.Text = ((t1800_R0207.F3_1 - t1800_R0207.F4_1) * 0.01).ToString("0.00;-0.00;0.00");
                lblT1800_1_F4F5.Text = ((t1800_R0207.F4_1 - t1800_R0207.F5_1) * 0.01).ToString("0.00;-0.00;0.00");
                lblT1800_1_F5F6.Text = ((t1800_R0207.F5_1 - t1800_R0207.F6_1) * 0.01).ToString("0.00;-0.00;0.00");
                lblT1800_1_F6F7.Text = ((t1800_R0207.F6_1 - t1800_R0207.F7_1) * 0.01).ToString("0.00;-0.00;0.00");

                BarSeries bs1_t1800 = new BarSeries("当材実績");
                bs1_t1800.Size = 15;
                bs1_t1800.Color = lblT1800_Color1.BackColor;
                bs1_t1800.BorderSize = 1;
                bs1_t1800.BorderColor = Color.White;

                bs1_t1800.Values.Add((t1800_R0207.F1_1 - t1800_R0207.F2_1) * 0.01);
                bs1_t1800.Values.Add((t1800_R0207.F2_1 - t1800_R0207.F3_1) * 0.01);
                bs1_t1800.Values.Add((t1800_R0207.F3_1 - t1800_R0207.F4_1) * 0.01);
                bs1_t1800.Values.Add((t1800_R0207.F4_1 - t1800_R0207.F5_1) * 0.01);
                bs1_t1800.Values.Add((t1800_R0207.F5_1 - t1800_R0207.F6_1) * 0.01);
                bs1_t1800.Values.Add((t1800_R0207.F6_1 - t1800_R0207.F7_1) * 0.01);

                chtT1800_1.ValueAxis1.BarSeries.Add(bs1_t1800);
            }
            //////////////////////////////////////////////
            //// Update 
            //////////////////////////////////////////////
            T1800_I2_14 t1800_R0251 = t1800.R0251;
            T1800_I2_14 t1800_R0139 = t1800.R0139;
            if (t1800_R0207 != null)
            {
                BarSeries bs4_t1800 = new BarSeries("当材実績");
                bs4_t1800.Size = 15;
                bs4_t1800.Color = lblT1800_Color1.BackColor;
                bs4_t1800.BorderSize = 1;
                bs4_t1800.BorderColor = Color.White;

                double f1 = t1800_R0139.F1_1 - 2 * (t1800_R0251.F1_1 - 30);
                double f2 = t1800_R0139.F2_1 - 2 * (t1800_R0251.F2_1 - 30);
                double f3 = t1800_R0139.F3_1 - 2 * (t1800_R0251.F3_1 - 30);
                double f4 = t1800_R0139.F4_1 - 2 * (t1800_R0251.F4_1 - 45);
                double f5 = t1800_R0139.F5_1 - 2 * (t1800_R0251.F5_1 - 45);
                double f6 = t1800_R0139.F6_1 - 2 * (t1800_R0251.F6_1 - 45);
                double f7 = t1800_R0139.F7_1 - 2 * (t1800_R0251.F7_1 - 45);

                bs4_t1800.Values.Add(f1 / f1);
                bs4_t1800.Values.Add(f2 / f1);
                bs4_t1800.Values.Add(f3 / f1);
                bs4_t1800.Values.Add(f4 / f1);
                bs4_t1800.Values.Add(f5 / f1);
                bs4_t1800.Values.Add(f6 / f1);
                bs4_t1800.Values.Add(f7 / f1);

                chtT1800_2.ValueAxis1.BarSeries.Add(bs4_t1800);
            }

            //T1800_I2_14 t1800_R0139 = t1800.R0139;
            //if (t1800_R0207 != null)
            //{
            //    BarSeries bs4_t1800 = new BarSeries("当材実績");
            //    bs4_t1800.Size = 15;
            //    bs4_t1800.Color = lblT1800_Color1.BackColor;
            //    bs4_t1800.BorderSize = 1;
            //    bs4_t1800.BorderColor = Color.White;

            //    bs4_t1800.Values.Add(t1800_R0139.F1_1 - 2 * (t1800_R0139.F1_1 - 30));
            //    bs4_t1800.Values.Add(t1800_R0139.F2_1 - 2 * (t1800_R0139.F2_1 - 30));
            //    bs4_t1800.Values.Add(t1800_R0139.F3_1 - 2 * (t1800_R0139.F3_1 - 30));
            //    bs4_t1800.Values.Add(t1800_R0139.F4_1 - 2 * (t1800_R0139.F4_1 - 45));
            //    bs4_t1800.Values.Add(t1800_R0139.F5_1 - 2 * (t1800_R0139.F5_1 - 45));
            //    bs4_t1800.Values.Add(t1800_R0139.F6_1 - 2 * (t1800_R0139.F6_1 - 45));
            //    bs4_t1800.Values.Add(t1800_R0139.F7_1 - 2 * (t1800_R0139.F7_1 - 45));

            //    chtT1800_2.ValueAxis1.BarSeries.Add(bs4_t1800);
            //}

            T800 t800 = T800.GetCoilDetailOfYear(t1800.R0025, t1800.R0033);
            if (t800 != null)
            {
                T800_I2_06 t800_R319 = t800.R319;
                if (t800_R319 != null)
                {
                    BarSeries bs1_t800 = new BarSeries("当材実績");
                    bs1_t800.Size = 15;
                    bs1_t800.Color = lblT1800_Color2.BackColor;
                    bs1_t800.BorderSize = 1;
                    bs1_t800.BorderColor = Color.White;

                    bs1_t800.Values.Add(t800_R319.R1 * 0.01);
                    bs1_t800.Values.Add(t800_R319.R2 * 0.01);
                    bs1_t800.Values.Add(t800_R319.R3 * 0.01);
                    bs1_t800.Values.Add(t800_R319.R4 * 0.01);
                    bs1_t800.Values.Add(t800_R319.R5 * 0.01);
                    bs1_t800.Values.Add(t800_R319.R6 * 0.01);

                    chtT1800_1.ValueAxis1.BarSeries.Add(bs1_t800);
                }

                T800_I2_06 t800_R331 = t800.R331;
                if (t800_R331 != null)
                {
                    BarSeries bs2_t800 = new BarSeries("圧下位置差介入量");
                    bs2_t800.Size = 15;
                    bs2_t800.Color = Color.LightGreen;
                    bs2_t800.BorderSize = 1;
                    bs2_t800.BorderColor = Color.White;

                    bs2_t800.Values.Add(t800_R331.R1 * 0.01);
                    bs2_t800.Values.Add(t800_R331.R2 * 0.01);
                    bs2_t800.Values.Add(t800_R331.R3 * 0.01);
                    bs2_t800.Values.Add(t800_R331.R4 * 0.01);
                    bs2_t800.Values.Add(t800_R331.R5 * 0.01);
                    bs2_t800.Values.Add(t800_R331.R6 * 0.01);

                    chtT1800_1.ValueAxis2.BarSeries.Add(bs2_t800);
                }

                T800_I2_07 t800_R179 = t800.R179;
                if (t800_R331 != null)
                {
                    BarSeries bs3_t800 = new BarSeries("当材設定");
                    bs3_t800.Size = 15;
                    bs3_t800.Color = lblT1800_Color2.BackColor;
                    bs3_t800.BorderSize = 1;
                    bs3_t800.BorderColor = Color.White;

                    bs3_t800.Values.Add(t800_R179.F1 / (t800_R179.F1 * 1.0));
                    bs3_t800.Values.Add(t800_R179.F2 / (t800_R179.F1 * 1.0));
                    bs3_t800.Values.Add(t800_R179.F3 / (t800_R179.F1 * 1.0));
                    bs3_t800.Values.Add(t800_R179.F4 / (t800_R179.F1 * 1.0));
                    bs3_t800.Values.Add(t800_R179.F5 / (t800_R179.F1 * 1.0));
                    bs3_t800.Values.Add(t800_R179.F6 / (t800_R179.F1 * 1.0));
                    bs3_t800.Values.Add(t800_R179.F7 / (t800_R179.F1 * 1.0));

                    chtT1800_2.ValueAxis1.BarSeries.Add(bs3_t800);
                }
            }

            ////////////////////////////////////////////////////////
            // Fill F1...F7 charts
            ////////////////////////////////////////////////////////

            int twoPointX = -300;
            T1800_I2_07 t1800_R0235 = t1800.R0223;

            // F1
            T1800_I2_45 t1800_R0401 = t1800.R0401;
            T1800_I2_45 t1800_R1031 = t1800.R1031;
            if (t1800_R0401 != null)
            {
                int maxR0410 = Int32.MinValue;
                int minR0410 = Int32.MaxValue;

                LineSeries bsF1_t1800_Red = new LineSeries("サーマルプロフィル");
                bsF1_t1800_Red.Size = 2;
                bsF1_t1800_Red.Color = lblT1800_Red.BackColor;
                bsF1_t1800_Red.Marker.Size = 2;
                bsF1_t1800_Red.Marker.Style = MarkerStyle.THANG;
                bsF1_t1800_Red.Marker.BackColor = bsF1_t1800_Red.Marker.ForeColor = bsF1_t1800_Red.Color;

                for (int i = 0; i < t1800_R0401.Rows.Length; i++)
                {
                    bsF1_t1800_Red.Values.Add(t1800_R0401.Rows[i]);
                    maxR0410 = maxR0410 > t1800_R0401.Rows[i] ? maxR0410 : t1800_R0401.Rows[i];
                    minR0410 = minR0410 < t1800_R1031.Rows[i] ? minR0410 : t1800_R1031.Rows[i];
                }

                chtT1800_F1.ValueAxis1.LineSeries.Add(bsF1_t1800_Red);
                lblMaxF1.Text = maxR0410.ToString();
                lblMinF1.Text = minR0410.ToString();

                LineSeries bsF1_t1800_Lime = new LineSeries("サーマル+摩耗");
                bsF1_t1800_Lime.Size = 2;
                bsF1_t1800_Lime.Color = lblT1800_Lime.BackColor;
                bsF1_t1800_Lime.Marker.Size = 2;
                bsF1_t1800_Lime.Marker.Style = MarkerStyle.THANG;
                bsF1_t1800_Lime.Marker.BackColor = bsF1_t1800_Lime.Marker.ForeColor = bsF1_t1800_Lime.Color;

                for (int i = 0; i < t1800_R0401.Rows.Length; i++)
                {
                    bsF1_t1800_Lime.Values.Add(t1800_R0401.Rows[i] + t1800_R1031.Rows[i]);
                }

                chtT1800_F1.ValueAxis1.LineSeries.Add(bsF1_t1800_Lime);

                LineSeries bsF1_t1800_Cyan = new LineSeries("摩耗プロフィル");
                bsF1_t1800_Cyan.Size = 2;
                bsF1_t1800_Cyan.Color = lblT1800_Cyan.BackColor;
                bsF1_t1800_Cyan.Marker.Size = 2;
                bsF1_t1800_Cyan.Marker.Style = MarkerStyle.THANG;
                bsF1_t1800_Cyan.Marker.BackColor = bsF1_t1800_Cyan.Marker.ForeColor = bsF1_t1800_Cyan.Color;

                for (int i = 0; i < t1800_R0401.Rows.Length; i++)
                {
                    bsF1_t1800_Cyan.Values.Add(t1800_R1031.Rows[i]);
                }

                chtT1800_F1.ValueAxis1.LineSeries.Add(bsF1_t1800_Cyan);

                // 2 points - Orange
                LineSeries bsF1_t1800_Orange = new LineSeries("圧延材");
                bsF1_t1800_Orange.Size = 2;
                bsF1_t1800_Orange.Color = lblT1800_Orange.BackColor;
                bsF1_t1800_Orange.Marker.Size = 2;
                bsF1_t1800_Orange.Marker.Style = MarkerStyle.THANG;
                bsF1_t1800_Orange.Marker.BackColor = bsF1_t1800_Orange.Marker.ForeColor = bsF1_t1800_Orange.Color;

                double min = -t1800.R0093 / 2.0 - t1800_R0235.F1;
                double max = t1800.R0093 / 2.0 - t1800_R0235.F1;
                for (int i = -1093; i < min; i++)
                {
                    bsF1_t1800_Orange.Values.Add(Double.MinValue);
                }
                bsF1_t1800_Orange.Values.Add(twoPointX);
                for (int i = (int)(min + 1); i < max; i++)
                {
                    bsF1_t1800_Orange.Values.Add(Double.MinValue);
                }
                bsF1_t1800_Orange.Values.Add(twoPointX);

                chtT1800_F1.ValueAxis2.LineSeries.Add(bsF1_t1800_Orange);
            }

            // F2
            T1800_I2_45 t1800_R0491 = t1800.R0491;
            T1800_I2_45 t1800_R1121 = t1800.R1121;
            if (t1800_R0491 != null)
            {
                int maxR0491 = Int32.MinValue;
                int minR0491 = Int32.MaxValue;

                LineSeries bsF2_t1800_Red = new LineSeries("サーマルプロフィル");
                bsF2_t1800_Red.Size = 2;
                bsF2_t1800_Red.Color = lblT1800_Red.BackColor;
                bsF2_t1800_Red.Marker.Size = 2;
                bsF2_t1800_Red.Marker.Style = MarkerStyle.THANG;
                bsF2_t1800_Red.Marker.BackColor = bsF2_t1800_Red.Marker.ForeColor = bsF2_t1800_Red.Color;

                for (int i = 0; i < t1800_R0491.Rows.Length; i++)
                {
                    bsF2_t1800_Red.Values.Add(t1800_R0491.Rows[i]);
                    maxR0491 = maxR0491 > t1800_R0491.Rows[i] ? maxR0491 : t1800_R0491.Rows[i];
                    minR0491 = minR0491 < t1800_R1121.Rows[i] ? minR0491 : t1800_R1121.Rows[i];
                }

                chtT1800_F2.ValueAxis1.LineSeries.Add(bsF2_t1800_Red);
                lblMaxF2.Text = maxR0491.ToString();
                lblMinF2.Text = minR0491.ToString();

                LineSeries bsF2_t1800_Lime = new LineSeries("サーマル+摩耗");
                bsF2_t1800_Lime.Size = 2;
                bsF2_t1800_Lime.Color = lblT1800_Lime.BackColor;
                bsF2_t1800_Lime.Marker.Size = 2;
                bsF2_t1800_Lime.Marker.Style = MarkerStyle.THANG;
                bsF2_t1800_Lime.Marker.BackColor = bsF2_t1800_Lime.Marker.ForeColor = bsF2_t1800_Lime.Color;

                for (int i = 0; i < t1800_R0491.Rows.Length; i++)
                {
                    bsF2_t1800_Lime.Values.Add(t1800_R0491.Rows[i] + t1800_R1121.Rows[i]);
                }

                chtT1800_F2.ValueAxis1.LineSeries.Add(bsF2_t1800_Lime);

                LineSeries bsF2_t1800_Cyan = new LineSeries("摩耗プロフィル");
                bsF2_t1800_Cyan.Size = 2;
                bsF2_t1800_Cyan.Color = lblT1800_Cyan.BackColor;
                bsF2_t1800_Cyan.Marker.Size = 2;
                bsF2_t1800_Cyan.Marker.Style = MarkerStyle.THANG;
                bsF2_t1800_Cyan.Marker.BackColor = bsF2_t1800_Cyan.Marker.ForeColor = bsF2_t1800_Cyan.Color;

                for (int i = 0; i < t1800_R0491.Rows.Length; i++)
                {
                    bsF2_t1800_Cyan.Values.Add(t1800_R1121.Rows[i]);
                }

                chtT1800_F2.ValueAxis1.LineSeries.Add(bsF2_t1800_Cyan);

                // 2 points - Orange
                LineSeries bsF2_t1800_Orange = new LineSeries("圧延材");
                bsF2_t1800_Orange.Size = 2;
                bsF2_t1800_Orange.Color = lblT1800_Orange.BackColor;
                bsF2_t1800_Orange.Marker.Size = 2;
                bsF2_t1800_Orange.Marker.Style = MarkerStyle.THANG;
                bsF2_t1800_Orange.Marker.BackColor = bsF2_t1800_Orange.Marker.ForeColor = bsF2_t1800_Orange.Color;

                double min = -t1800.R0093 / 2.0 - t1800_R0235.F2;
                double max = t1800.R0093 / 2.0 - t1800_R0235.F2;
                for (int i = -1093; i < min; i++)
                {
                    bsF2_t1800_Orange.Values.Add(Double.MinValue);
                }
                bsF2_t1800_Orange.Values.Add(twoPointX);
                for (int i = (int)(min + 1); i < max; i++)
                {
                    bsF2_t1800_Orange.Values.Add(Double.MinValue);
                }
                bsF2_t1800_Orange.Values.Add(twoPointX);

                chtT1800_F2.ValueAxis2.LineSeries.Add(bsF2_t1800_Orange);
            }

            // F3
            T1800_I2_45 t1800_R0581 = t1800.R0581;
            T1800_I2_45 t1800_R1211 = t1800.R1211;
            if (t1800_R0581 != null)
            {
                int maxR0581 = Int32.MinValue;
                int minR0581 = Int32.MaxValue;

                LineSeries bsF3_t1800_Red = new LineSeries("サーマルプロフィル");
                bsF3_t1800_Red.Size = 2;
                bsF3_t1800_Red.Color = lblT1800_Red.BackColor;
                bsF3_t1800_Red.Marker.Size = 2;
                bsF3_t1800_Red.Marker.Style = MarkerStyle.THANG;
                bsF3_t1800_Red.Marker.BackColor = bsF3_t1800_Red.Marker.ForeColor = bsF3_t1800_Red.Color;

                for (int i = 0; i < t1800_R0581.Rows.Length; i++)
                {
                    bsF3_t1800_Red.Values.Add(t1800_R0581.Rows[i]);
                    maxR0581 = maxR0581 > t1800_R0581.Rows[i] ? maxR0581 : t1800_R0581.Rows[i];
                    minR0581 = minR0581 < t1800_R1211.Rows[i] ? minR0581 : t1800_R1211.Rows[i];
                }

                chtT1800_F3.ValueAxis1.LineSeries.Add(bsF3_t1800_Red);
                lblMaxF3.Text = maxR0581.ToString();
                lblMinF3.Text = minR0581.ToString();

                LineSeries bsF3_t1800_Lime = new LineSeries("サーマル+摩耗");
                bsF3_t1800_Lime.Size = 2;
                bsF3_t1800_Lime.Color = lblT1800_Lime.BackColor;
                bsF3_t1800_Lime.Marker.Size = 2;
                bsF3_t1800_Lime.Marker.Style = MarkerStyle.THANG;
                bsF3_t1800_Lime.Marker.BackColor = bsF3_t1800_Lime.Marker.ForeColor = bsF3_t1800_Lime.Color;

                for (int i = 0; i < t1800_R0581.Rows.Length; i++)
                {
                    bsF3_t1800_Lime.Values.Add(t1800_R0581.Rows[i] + t1800_R1211.Rows[i]);
                }

                chtT1800_F3.ValueAxis1.LineSeries.Add(bsF3_t1800_Lime);

                LineSeries bsF3_t1800_Cyan = new LineSeries("摩耗プロフィル");
                bsF3_t1800_Cyan.Size = 2;
                bsF3_t1800_Cyan.Color = lblT1800_Cyan.BackColor;
                bsF3_t1800_Cyan.Marker.Size = 2;
                bsF3_t1800_Cyan.Marker.Style = MarkerStyle.THANG;
                bsF3_t1800_Cyan.Marker.BackColor = bsF3_t1800_Cyan.Marker.ForeColor = bsF3_t1800_Cyan.Color;

                for (int i = 0; i < t1800_R0581.Rows.Length; i++)
                {
                    bsF3_t1800_Cyan.Values.Add(t1800_R1211.Rows[i]);
                }

                chtT1800_F3.ValueAxis1.LineSeries.Add(bsF3_t1800_Cyan);

                // 2 points - Orange
                LineSeries bsF3_t1800_Orange = new LineSeries("圧延材");
                bsF3_t1800_Orange.Size = 2;
                bsF3_t1800_Orange.Color = lblT1800_Orange.BackColor;
                bsF3_t1800_Orange.Marker.Size = 2;
                bsF3_t1800_Orange.Marker.Style = MarkerStyle.THANG;
                bsF3_t1800_Orange.Marker.BackColor = bsF3_t1800_Orange.Marker.ForeColor = bsF3_t1800_Orange.Color;

                double min = -t1800.R0093 / 2.0 - t1800_R0235.F3;
                double max = t1800.R0093 / 2.0 - t1800_R0235.F3;
                for (int i = -1093; i < min; i++)
                {
                    bsF3_t1800_Orange.Values.Add(Double.MinValue);
                }
                bsF3_t1800_Orange.Values.Add(twoPointX);
                for (int i = (int)(min + 1); i < max; i++)
                {
                    bsF3_t1800_Orange.Values.Add(Double.MinValue);
                }
                bsF3_t1800_Orange.Values.Add(twoPointX);

                chtT1800_F3.ValueAxis2.LineSeries.Add(bsF3_t1800_Orange);
            }

            // F4
            T1800_I2_45 t1800_R0671 = t1800.R0671;
            T1800_I2_45 t1800_R1301 = t1800.R1301;
            if (t1800_R0671 != null)
            {
                int maxR0671 = Int32.MinValue;
                int minR0671 = Int32.MaxValue;

                LineSeries bsF4_t1800_Red = new LineSeries("サーマルプロフィル");
                bsF4_t1800_Red.Size = 2;
                bsF4_t1800_Red.Color = lblT1800_Red.BackColor;
                bsF4_t1800_Red.Marker.Size = 2;
                bsF4_t1800_Red.Marker.Style = MarkerStyle.THANG;
                bsF4_t1800_Red.Marker.BackColor = bsF4_t1800_Red.Marker.ForeColor = bsF4_t1800_Red.Color;

                for (int i = 0; i < t1800_R0671.Rows.Length; i++)
                {
                    bsF4_t1800_Red.Values.Add(t1800_R0671.Rows[i]);
                    maxR0671 = maxR0671 > t1800_R0671.Rows[i] ? maxR0671 : t1800_R0671.Rows[i];
                    minR0671 = minR0671 < t1800_R1301.Rows[i] ? minR0671 : t1800_R1301.Rows[i];
                }

                chtT1800_F4.ValueAxis1.LineSeries.Add(bsF4_t1800_Red);
                lblMaxF4.Text = maxR0671.ToString();
                lblMinF4.Text = minR0671.ToString();

                LineSeries bsF4_t1800_Lime = new LineSeries("サーマル+摩耗");
                bsF4_t1800_Lime.Size = 2;
                bsF4_t1800_Lime.Color = lblT1800_Lime.BackColor;
                bsF4_t1800_Lime.Marker.Size = 2;
                bsF4_t1800_Lime.Marker.Style = MarkerStyle.THANG;
                bsF4_t1800_Lime.Marker.BackColor = bsF4_t1800_Lime.Marker.ForeColor = bsF4_t1800_Lime.Color;

                for (int i = 0; i < t1800_R0671.Rows.Length; i++)
                {
                    bsF4_t1800_Lime.Values.Add(t1800_R0671.Rows[i] + t1800_R1301.Rows[i]);
                }

                chtT1800_F4.ValueAxis1.LineSeries.Add(bsF4_t1800_Lime);

                LineSeries bsF4_t1800_Cyan = new LineSeries("摩耗プロフィル");
                bsF4_t1800_Cyan.Size = 2;
                bsF4_t1800_Cyan.Color = lblT1800_Cyan.BackColor;
                bsF4_t1800_Cyan.Marker.Size = 2;
                bsF4_t1800_Cyan.Marker.Style = MarkerStyle.THANG;
                bsF4_t1800_Cyan.Marker.BackColor = bsF4_t1800_Cyan.Marker.ForeColor = bsF4_t1800_Cyan.Color;

                for (int i = 0; i < t1800_R0671.Rows.Length; i++)
                {
                    bsF4_t1800_Cyan.Values.Add(t1800_R1301.Rows[i]);
                }

                chtT1800_F4.ValueAxis1.LineSeries.Add(bsF4_t1800_Cyan);

                // 2 points - Orange
                LineSeries bsF4_t1800_Orange = new LineSeries("圧延材");
                bsF4_t1800_Orange.Size = 2;
                bsF4_t1800_Orange.Color = lblT1800_Orange.BackColor;
                bsF4_t1800_Orange.Marker.Size = 2;
                bsF4_t1800_Orange.Marker.Style = MarkerStyle.THANG;
                bsF4_t1800_Orange.Marker.BackColor = bsF4_t1800_Orange.Marker.ForeColor = bsF4_t1800_Orange.Color;

                double min = -t1800.R0093 / 2.0 - t1800_R0235.F4;
                double max = t1800.R0093 / 2.0 - t1800_R0235.F4;
                for (int i = -1093; i < min; i++)
                {
                    bsF4_t1800_Orange.Values.Add(Double.MinValue);
                }
                bsF4_t1800_Orange.Values.Add(twoPointX);
                for (int i = (int)(min + 1); i < max; i++)
                {
                    bsF4_t1800_Orange.Values.Add(Double.MinValue);
                }
                bsF4_t1800_Orange.Values.Add(twoPointX);

                chtT1800_F4.ValueAxis2.LineSeries.Add(bsF4_t1800_Orange);
            }

            // F5
            T1800_I2_45 t1800_R0761 = t1800.R0761;
            T1800_I2_45 t1800_R1391 = t1800.R1391;
            if (t1800_R0761 != null)
            {
                int maxR0761 = Int32.MinValue;
                int minR0761 = Int32.MaxValue;

                LineSeries bsF5_t1800_Red = new LineSeries("サーマルプロフィル");
                bsF5_t1800_Red.Size = 2;
                bsF5_t1800_Red.Color = lblT1800_Red.BackColor;
                bsF5_t1800_Red.Marker.Size = 2;
                bsF5_t1800_Red.Marker.Style = MarkerStyle.THANG;
                bsF5_t1800_Red.Marker.BackColor = bsF5_t1800_Red.Marker.ForeColor = bsF5_t1800_Red.Color;

                for (int i = 0; i < t1800_R0761.Rows.Length; i++)
                {
                    bsF5_t1800_Red.Values.Add(t1800_R0761.Rows[i]);
                    maxR0761 = maxR0761 > t1800_R0761.Rows[i] ? maxR0761 : t1800_R0761.Rows[i];
                    minR0761 = minR0761 < t1800_R1391.Rows[i] ? minR0761 : t1800_R1391.Rows[i];
                }

                chtT1800_F5.ValueAxis1.LineSeries.Add(bsF5_t1800_Red);
                lblMaxF5.Text = maxR0761.ToString();
                lblMinF5.Text = minR0761.ToString();

                LineSeries bsF5_t1800_Lime = new LineSeries("サーマル+摩耗");
                bsF5_t1800_Lime.Size = 2;
                bsF5_t1800_Lime.Color = lblT1800_Lime.BackColor;
                bsF5_t1800_Lime.Marker.Size = 2;
                bsF5_t1800_Lime.Marker.Style = MarkerStyle.THANG;
                bsF5_t1800_Lime.Marker.BackColor = bsF5_t1800_Lime.Marker.ForeColor = bsF5_t1800_Lime.Color;

                for (int i = 0; i < t1800_R0761.Rows.Length; i++)
                {
                    bsF5_t1800_Lime.Values.Add(t1800_R0761.Rows[i] + t1800_R1391.Rows[i]);
                }

                chtT1800_F5.ValueAxis1.LineSeries.Add(bsF5_t1800_Lime);

                LineSeries bsF5_t1800_Cyan = new LineSeries("摩耗プロフィル");
                bsF5_t1800_Cyan.Size = 2;
                bsF5_t1800_Cyan.Color = lblT1800_Cyan.BackColor;
                bsF5_t1800_Cyan.Marker.Size = 2;
                bsF5_t1800_Cyan.Marker.Style = MarkerStyle.THANG;
                bsF5_t1800_Cyan.Marker.BackColor = bsF5_t1800_Cyan.Marker.ForeColor = bsF5_t1800_Cyan.Color;

                for (int i = 0; i < t1800_R0761.Rows.Length; i++)
                {
                    bsF5_t1800_Cyan.Values.Add(t1800_R1391.Rows[i]);
                }

                chtT1800_F5.ValueAxis1.LineSeries.Add(bsF5_t1800_Cyan);

                // 2 points - Orange
                LineSeries bsF5_t1800_Orange = new LineSeries("圧延材");
                bsF5_t1800_Orange.Size = 2;
                bsF5_t1800_Orange.Color = lblT1800_Orange.BackColor;
                bsF5_t1800_Orange.Marker.Size = 2;
                bsF5_t1800_Orange.Marker.Style = MarkerStyle.THANG;
                bsF5_t1800_Orange.Marker.BackColor = bsF5_t1800_Orange.Marker.ForeColor = bsF5_t1800_Orange.Color;

                double min = -t1800.R0093 / 2.0 - t1800_R0235.F5;
                double max = t1800.R0093 / 2.0 - t1800_R0235.F5;
                for (int i = -1093; i < min; i++)
                {
                    bsF5_t1800_Orange.Values.Add(Double.MinValue);
                }
                bsF5_t1800_Orange.Values.Add(twoPointX);
                for (int i = (int)(min + 1); i < max; i++)
                {
                    bsF5_t1800_Orange.Values.Add(Double.MinValue);
                }
                bsF5_t1800_Orange.Values.Add(twoPointX);

                chtT1800_F5.ValueAxis2.LineSeries.Add(bsF5_t1800_Orange);
            }

            // F6
            T1800_I2_45 t1800_R0851 = t1800.R0851;
            T1800_I2_45 t1800_R1481 = t1800.R1481;
            if (t1800_R0851 != null)
            {
                int maxR0851 = Int32.MinValue;
                int minR0851 = Int32.MaxValue;

                LineSeries bsF6_t1800_Red = new LineSeries("サーマルプロフィル");
                bsF6_t1800_Red.Size = 2;
                bsF6_t1800_Red.Color = lblT1800_Red.BackColor;
                bsF6_t1800_Red.Marker.Size = 2;
                bsF6_t1800_Red.Marker.Style = MarkerStyle.THANG;
                bsF6_t1800_Red.Marker.BackColor = bsF6_t1800_Red.Marker.ForeColor = bsF6_t1800_Red.Color;

                for (int i = 0; i < t1800_R0851.Rows.Length; i++)
                {
                    bsF6_t1800_Red.Values.Add(t1800_R0851.Rows[i]);
                    maxR0851 = maxR0851 > t1800_R0851.Rows[i] ? maxR0851 : t1800_R0851.Rows[i];
                    minR0851 = minR0851 < t1800_R1481.Rows[i] ? minR0851 : t1800_R1481.Rows[i];
                }

                chtT1800_F6.ValueAxis1.LineSeries.Add(bsF6_t1800_Red);
                lblMaxF6.Text = maxR0851.ToString();
                lblMinF6.Text = minR0851.ToString();

                LineSeries bsF6_t1800_Lime = new LineSeries("サーマル+摩耗");
                bsF6_t1800_Lime.Size = 2;
                bsF6_t1800_Lime.Color = lblT1800_Lime.BackColor;
                bsF6_t1800_Lime.Marker.Size = 2;
                bsF6_t1800_Lime.Marker.Style = MarkerStyle.THANG;
                bsF6_t1800_Lime.Marker.BackColor = bsF6_t1800_Lime.Marker.ForeColor = bsF6_t1800_Lime.Color;

                for (int i = 0; i < t1800_R0851.Rows.Length; i++)
                {
                    bsF6_t1800_Lime.Values.Add(t1800_R0851.Rows[i] + t1800_R1481.Rows[i]);
                }

                chtT1800_F6.ValueAxis1.LineSeries.Add(bsF6_t1800_Lime);

                LineSeries bsF6_t1800_Cyan = new LineSeries("摩耗プロフィル");
                bsF6_t1800_Cyan.Size = 2;
                bsF6_t1800_Cyan.Color = lblT1800_Cyan.BackColor;
                bsF6_t1800_Cyan.Marker.Size = 2;
                bsF6_t1800_Cyan.Marker.Style = MarkerStyle.THANG;
                bsF6_t1800_Cyan.Marker.BackColor = bsF6_t1800_Cyan.Marker.ForeColor = bsF6_t1800_Cyan.Color;

                for (int i = 0; i < t1800_R0851.Rows.Length; i++)
                {
                    bsF6_t1800_Cyan.Values.Add(t1800_R1481.Rows[i]);
                }

                chtT1800_F6.ValueAxis1.LineSeries.Add(bsF6_t1800_Cyan);

                // 2 points - Orange
                LineSeries bsF6_t1800_Orange = new LineSeries("圧延材");
                bsF6_t1800_Orange.Size = 2;
                bsF6_t1800_Orange.Color = lblT1800_Orange.BackColor;
                bsF6_t1800_Orange.Marker.Size = 2;
                bsF6_t1800_Orange.Marker.Style = MarkerStyle.THANG;
                bsF6_t1800_Orange.Marker.BackColor = bsF6_t1800_Orange.Marker.ForeColor = bsF6_t1800_Orange.Color;

                double min = -t1800.R0093 / 2.0 - t1800_R0235.F6;
                double max = t1800.R0093 / 2.0 - t1800_R0235.F6;
                for (int i = -1093; i < min; i++)
                {
                    bsF6_t1800_Orange.Values.Add(Double.MinValue);
                }
                bsF6_t1800_Orange.Values.Add(twoPointX);
                for (int i = (int)(min + 1); i < max; i++)
                {
                    bsF6_t1800_Orange.Values.Add(Double.MinValue);
                }
                bsF6_t1800_Orange.Values.Add(twoPointX);

                chtT1800_F6.ValueAxis2.LineSeries.Add(bsF6_t1800_Orange);
            }

            // F7
            T1800_I2_45 t1800_R0941 = t1800.R0941;
            T1800_I2_45 t1800_R1571 = t1800.R1571;
            if (t1800_R0941 != null)
            {
                int maxR0941 = Int32.MinValue;
                int minR0941 = Int32.MaxValue;

                LineSeries bsF7_t1800_Red = new LineSeries("サーマルプロフィル");
                bsF7_t1800_Red.Size = 2;
                bsF7_t1800_Red.Color = lblT1800_Red.BackColor;
                bsF7_t1800_Red.Marker.Size = 2;
                bsF7_t1800_Red.Marker.Style = MarkerStyle.THANG;
                bsF7_t1800_Red.Marker.BackColor = bsF7_t1800_Red.Marker.ForeColor = bsF7_t1800_Red.Color;

                for (int i = 0; i < t1800_R0941.Rows.Length; i++)
                {
                    bsF7_t1800_Red.Values.Add(t1800_R0941.Rows[i]);
                    maxR0941 = maxR0941 > t1800_R0941.Rows[i] ? maxR0941 : t1800_R0941.Rows[i];
                    minR0941 = minR0941 < t1800_R1571.Rows[i] ? minR0941 : t1800_R1571.Rows[i];
                }

                chtT1800_F7.ValueAxis1.LineSeries.Add(bsF7_t1800_Red);
                lblMaxF7.Text = maxR0941.ToString();
                lblMinF7.Text = minR0941.ToString();

                LineSeries bsF7_t1800_Lime = new LineSeries("サーマル+摩耗");
                bsF7_t1800_Lime.Size = 2;
                bsF7_t1800_Lime.Color = lblT1800_Lime.BackColor;
                bsF7_t1800_Lime.Marker.Size = 2;
                bsF7_t1800_Lime.Marker.Style = MarkerStyle.THANG;
                bsF7_t1800_Lime.Marker.BackColor = bsF7_t1800_Lime.Marker.ForeColor = bsF7_t1800_Lime.Color;

                for (int i = 0; i < t1800_R0941.Rows.Length; i++)
                {
                    bsF7_t1800_Lime.Values.Add(t1800_R0941.Rows[i] + t1800_R1571.Rows[i]);
                }

                chtT1800_F7.ValueAxis1.LineSeries.Add(bsF7_t1800_Lime);

                LineSeries bsF7_t1800_Cyan = new LineSeries("摩耗プロフィル");
                bsF7_t1800_Cyan.Size = 2;
                bsF7_t1800_Cyan.Color = lblT1800_Cyan.BackColor;
                bsF7_t1800_Cyan.Marker.Size = 2;
                bsF7_t1800_Cyan.Marker.Style = MarkerStyle.THANG;
                bsF7_t1800_Cyan.Marker.BackColor = bsF7_t1800_Cyan.Marker.ForeColor = bsF7_t1800_Cyan.Color;

                for (int i = 0; i < t1800_R0941.Rows.Length; i++)
                {
                    bsF7_t1800_Cyan.Values.Add(t1800_R1571.Rows[i]);
                }

                chtT1800_F7.ValueAxis1.LineSeries.Add(bsF7_t1800_Cyan);

                // 2 points - Orange
                LineSeries bsF7_t1800_Orange = new LineSeries("圧延材");
                bsF7_t1800_Orange.Size = 2;
                bsF7_t1800_Orange.Color = lblT1800_Orange.BackColor;
                bsF7_t1800_Orange.Marker.Size = 2;
                bsF7_t1800_Orange.Marker.Style = MarkerStyle.THANG;
                bsF7_t1800_Orange.Marker.BackColor = bsF7_t1800_Orange.Marker.ForeColor = bsF7_t1800_Orange.Color;

                double min = -t1800.R0093 / 2.0 - t1800_R0235.F7;
                double max = t1800.R0093 / 2.0 - t1800_R0235.F7;
                for (int i = -1093; i < min; i++)
                {
                    bsF7_t1800_Orange.Values.Add(Double.MinValue);
                }
                bsF7_t1800_Orange.Values.Add(twoPointX);
                for (int i = (int)(min + 1); i < max; i++)
                {
                    bsF7_t1800_Orange.Values.Add(Double.MinValue);
                }
                bsF7_t1800_Orange.Values.Add(twoPointX);

                chtT1800_F7.ValueAxis2.LineSeries.Add(bsF7_t1800_Orange);
            }

            if (gamens != null)
            {
                // chart 1
                LineSeries ls1_t900 = new LineSeries("上限パターン");
                ls1_t900.Color = lblLine_Lime.BackColor;
                ls1_t900.Marker.BackColor = ls1_t900.Marker.ForeColor = ls1_t900.Color;
                ls1_t900.Marker.Style = MarkerStyle.THANG;
                ls1_t900.Marker.Size = 1;
                ls1_t900.Size = 2;

                ls1_t900.Values.Add(gamens[77]);
                ls1_t900.Values.Add(gamens[78]);
                ls1_t900.Values.Add(gamens[79]);
                ls1_t900.Values.Add(gamens[80]);
                ls1_t900.Values.Add(gamens[81]);
                ls1_t900.Values.Add(gamens[82]);

                chtT1800_1.ValueAxis1.LineSeries.Add(ls1_t900);

                LineSeries ls2_t900 = new LineSeries("中央パターン");
                ls2_t900.Color = lblLine_Fuchsia.BackColor;
                ls2_t900.Marker.BackColor = ls2_t900.Marker.ForeColor = ls2_t900.Color;
                ls2_t900.Marker.Style = MarkerStyle.THANG;
                ls2_t900.Marker.Size = 1;
                ls2_t900.Size = 2;

                ls2_t900.Values.Add(gamens[83]);
                ls2_t900.Values.Add(gamens[84]);
                ls2_t900.Values.Add(gamens[85]);
                ls2_t900.Values.Add(gamens[86]);
                ls2_t900.Values.Add(gamens[87]);
                ls2_t900.Values.Add(gamens[88]);

                chtT1800_1.ValueAxis1.LineSeries.Add(ls2_t900);

                LineSeries ls3_t900 = new LineSeries("下限パターン");
                ls3_t900.Color = lblLine_Cyan.BackColor;
                ls3_t900.Marker.BackColor = ls3_t900.Marker.ForeColor = ls3_t900.Color;
                ls3_t900.Marker.Style = MarkerStyle.THANG;
                ls3_t900.Marker.Size = 1;
                ls3_t900.Size = 2;

                ls3_t900.Values.Add(gamens[89]);
                ls3_t900.Values.Add(gamens[90]);
                ls3_t900.Values.Add(gamens[91]);
                ls3_t900.Values.Add(gamens[92]);
                ls3_t900.Values.Add(gamens[93]);
                ls3_t900.Values.Add(gamens[94]);

                chtT1800_1.ValueAxis1.LineSeries.Add(ls3_t900);
                // end chart 1

                // chart 2
                LineSeries ls4_t900 = new LineSeries("上限パターン");
                ls4_t900.Color = lblLine_Lime.BackColor;
                ls4_t900.Marker.BackColor = ls4_t900.Marker.ForeColor = ls4_t900.Color;
                ls4_t900.Marker.Style = MarkerStyle.THANG;
                ls4_t900.Marker.Size = 1;
                ls4_t900.Size = 2;

                ls4_t900.Values.Add(gamens[149]);
                ls4_t900.Values.Add(gamens[150]);
                ls4_t900.Values.Add(gamens[151]);
                ls4_t900.Values.Add(gamens[152]);
                ls4_t900.Values.Add(gamens[153]);
                ls4_t900.Values.Add(gamens[154]);
                ls4_t900.Values.Add(gamens[155]);

                chtT1800_2.ValueAxis1.LineSeries.Add(ls4_t900);

                LineSeries ls5_t900 = new LineSeries("中央パターン");
                ls5_t900.Color = lblLine_Fuchsia.BackColor;
                ls5_t900.Marker.BackColor = ls5_t900.Marker.ForeColor = ls5_t900.Color;
                ls5_t900.Marker.Style = MarkerStyle.THANG;
                ls5_t900.Marker.Size = 1;
                ls5_t900.Size = 2;

                ls5_t900.Values.Add(gamens[156]);
                ls5_t900.Values.Add(gamens[157]);
                ls5_t900.Values.Add(gamens[158]);
                ls5_t900.Values.Add(gamens[159]);
                ls5_t900.Values.Add(gamens[160]);
                ls5_t900.Values.Add(gamens[161]);
                ls5_t900.Values.Add(gamens[162]);

                chtT1800_2.ValueAxis1.LineSeries.Add(ls5_t900);

                LineSeries ls6_t900 = new LineSeries("下限パターン");
                ls6_t900.Color = lblLine_Cyan.BackColor;
                ls6_t900.Marker.BackColor = ls6_t900.Marker.ForeColor = ls6_t900.Color;
                ls6_t900.Marker.Style = MarkerStyle.THANG;
                ls6_t900.Marker.Size = 1;
                ls6_t900.Size = 2;

                ls6_t900.Values.Add(gamens[163]);
                ls6_t900.Values.Add(gamens[164]);
                ls6_t900.Values.Add(gamens[165]);
                ls6_t900.Values.Add(gamens[166]);
                ls6_t900.Values.Add(gamens[167]);
                ls6_t900.Values.Add(gamens[168]);
                ls6_t900.Values.Add(gamens[169]);

                chtT1800_2.ValueAxis1.LineSeries.Add(ls6_t900);
                //end chart 2
            }

            lblMaxF1.Refresh();
            lblMaxF2.Refresh();
            lblMaxF3.Refresh();
            lblMaxF4.Refresh();
            lblMaxF5.Refresh();
            lblMaxF6.Refresh();
            lblMaxF7.Refresh();
            lblMinF1.Refresh();
            lblMinF2.Refresh();
            lblMinF3.Refresh();
            lblMinF4.Refresh();
            lblMinF5.Refresh();
            lblMinF6.Refresh();
            lblMinF7.Refresh();
            lblGamen131.Refresh();
        }

        protected void FillData(Gamen gamen)
        {
            chtT900_1.ValueAxis1.LineSeries.Clear();
            chtT900_1.ValueAxis2.LineSeries.Clear();
            chtT900_2.ValueAxis1.LineSeries.Clear();
            chtT900_2.ValueAxis2.LineSeries.Clear();

            chtT900_1.ValueAxis1.UpdateBarSeries.Clear();
            chtT900_1.ValueAxis2.UpdateBarSeries.Clear();
            chtT900_2.ValueAxis1.UpdateBarSeries.Clear();
            chtT900_2.ValueAxis2.UpdateBarSeries.Clear();

            if (gamen == null || gamen.Values == null || gamen.Values.Length == 0)
            {
                return;
            }

            double[] gamens = null;
            gamens = gamen.GetValues();
            if (gamens != null)
            {
                lblGamen002.Text = "評価値：" + (gamens[1] == Double.MinValue ? "" : (gamens[1]).ToString());

                // update pre-process
                //lblT900_3_1_F1F2.Text = (gamens[55]).ToString("0.00;-0.00;0.00");
                //lblT900_3_1_F2F3.Text = (gamens[56]).ToString("0.00;-0.00;0.00");
                //lblT900_3_1_F3F4.Text = (gamens[57]).ToString("0.00;-0.00;0.00");
                //lblT900_3_1_F4F5.Text = (gamens[58]).ToString("0.00;-0.00;0.00");
                //lblT900_3_1_F5F6.Text = (gamens[59]).ToString("0.00;-0.00;0.00");
                //lblT900_3_1_F6F7.Text = (gamens[60]).ToString("0.00;-0.00;0.00");

                lblT900_3_2_F1F2.Text = (gamens[55]).ToString("0.00;-0.00;0.00");
                lblT900_3_2_F2F3.Text = (gamens[56]).ToString("0.00;-0.00;0.00");
                lblT900_3_2_F3F4.Text = (gamens[57]).ToString("0.00;-0.00;0.00");
                lblT900_3_2_F4F5.Text = (gamens[58]).ToString("0.00;-0.00;0.00");
                lblT900_3_2_F5F6.Text = (gamens[59]).ToString("0.00;-0.00;0.00");
                lblT900_3_2_F6F7.Text = (gamens[60]).ToString("0.00;-0.00;0.00");

                //lblT900_3_3_F1.Text = gamens[68].ToString("0;-0;0");
                //lblT900_3_3_F2.Text = gamens[69].ToString("0;-0;0");
                //lblT900_3_3_F3.Text = gamens[70].ToString("0;-0;0");
                //lblT900_3_3_F4.Text = gamens[71].ToString("0;-0;0");
                //lblT900_3_3_F5.Text = gamens[72].ToString("0;-0;0");
                //lblT900_3_3_F6.Text = gamens[73].ToString("0;-0;0");
                //lblT900_3_3_F7.Text = gamens[74].ToString("0;-0;0");

                lblT900_3_4_F1.Text = gamens[68].ToString("0;-0;0");
                lblT900_3_4_F2.Text = gamens[69].ToString("0;-0;0");
                lblT900_3_4_F3.Text = gamens[70].ToString("0;-0;0");
                lblT900_3_4_F4.Text = gamens[71].ToString("0;-0;0");
                lblT900_3_4_F5.Text = gamens[72].ToString("0;-0;0");
                lblT900_3_4_F6.Text = gamens[73].ToString("0;-0;0");
                lblT900_3_4_F7.Text = gamens[74].ToString("0;-0;0");
                // end update

                // chart 1
                LineSeries ls1_t900 = new LineSeries("上限パターン");
                ls1_t900.Color = lblLine_Lime.BackColor;
                ls1_t900.Marker.BackColor = ls1_t900.Marker.ForeColor = ls1_t900.Color;
                ls1_t900.Marker.Style = MarkerStyle.THANG;
                ls1_t900.Marker.Size = 1;
                ls1_t900.Size = 2;

                ls1_t900.Values.Add(gamens[2]);
                ls1_t900.Values.Add(gamens[3]);
                ls1_t900.Values.Add(gamens[4]);
                ls1_t900.Values.Add(gamens[5]);
                ls1_t900.Values.Add(gamens[6]);
                ls1_t900.Values.Add(gamens[7]);

                chtT900_1.ValueAxis1.LineSeries.Add(ls1_t900);

                LineSeries ls2_t900 = new LineSeries("中央パターン");
                ls2_t900.Color = lblLine_Fuchsia.BackColor;
                ls2_t900.Marker.BackColor = ls2_t900.Marker.ForeColor = ls2_t900.Color;
                ls2_t900.Marker.Style = MarkerStyle.THANG;
                ls2_t900.Marker.Size = 1;
                ls2_t900.Size = 2;

                ls2_t900.Values.Add(gamens[8]);
                ls2_t900.Values.Add(gamens[9]);
                ls2_t900.Values.Add(gamens[10]);
                ls2_t900.Values.Add(gamens[11]);
                ls2_t900.Values.Add(gamens[12]);
                ls2_t900.Values.Add(gamens[13]);

                chtT900_1.ValueAxis1.LineSeries.Add(ls2_t900);

                LineSeries ls3_t900 = new LineSeries("下限パターン");
                ls3_t900.Color = lblLine_Cyan.BackColor;
                ls3_t900.Marker.BackColor = ls3_t900.Marker.ForeColor = ls3_t900.Color;
                ls3_t900.Marker.Style = MarkerStyle.THANG;
                ls3_t900.Marker.Size = 1;
                ls3_t900.Size = 2;

                ls3_t900.Values.Add(gamens[14]);
                ls3_t900.Values.Add(gamens[15]);
                ls3_t900.Values.Add(gamens[16]);
                ls3_t900.Values.Add(gamens[17]);
                ls3_t900.Values.Add(gamens[18]);
                ls3_t900.Values.Add(gamens[19]);

                chtT900_1.ValueAxis1.LineSeries.Add(ls3_t900);

                BarSeries bs1_t900 = new BarSeries("過去実績平均");
                bs1_t900.Size = 15;
                bs1_t900.Color = lblT900_Color2.BackColor;
                bs1_t900.BorderSize = 1;
                bs1_t900.BorderColor = Color.White;
                bs1_t900.Values.Add(gamens[20]);
                bs1_t900.Values.Add(gamens[21]);
                bs1_t900.Values.Add(gamens[22]);
                bs1_t900.Values.Add(gamens[23]);
                bs1_t900.Values.Add(gamens[24]);
                bs1_t900.Values.Add(gamens[25]);

                int ii = 0;

                for (ii = 0; ii < chtT900_1.ValueAxis1.BarSeries.Count; ii++)
                {
                    if (chtT900_1.ValueAxis1.BarSeries[ii].Name.Equals(bs1_t900.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        chtT900_1.ValueAxis1.BarSeries.RemoveAt(ii);
                        chtT900_1.ValueAxis1.BarSeries.Insert(ii, bs1_t900);
                        break;
                    }
                }
                if (ii == chtT900_1.ValueAxis1.BarSeries.Count)
                {
                    chtT900_1.ValueAxis1.BarSeries.Add(bs1_t900);
                }

                BarSeries bs2_t900 = new BarSeries("Blank");
                bs2_t900.Size = 15;
                //bs2_t900.Color = lblT900_Color2.BackColor;
                bs2_t900.BorderSize = 3;
                bs2_t900.BorderColor = Color.SkyBlue;
                bs2_t900.Values.Add(gamens[55]);
                bs2_t900.Values.Add(gamens[56]);
                bs2_t900.Values.Add(gamens[57]);
                bs2_t900.Values.Add(gamens[58]);
                bs2_t900.Values.Add(gamens[59]);
                bs2_t900.Values.Add(gamens[60]);
                chtT900_1.ValueAxis1.UpdateBarSeries.Add(bs2_t900);

                BarSeries bs6_t900 = new BarSeries("Blank");
                chtT900_1.ValueAxis1.UpdateBarSeries.Add(bs6_t900);
                // end chart 1

                // chart 2
                LineSeries ls4_t900 = new LineSeries("上限パターン");
                ls4_t900.Color = lblLine_Lime.BackColor;
                ls4_t900.Marker.BackColor = ls4_t900.Marker.ForeColor = ls4_t900.Color;
                ls4_t900.Marker.Style = MarkerStyle.THANG;
                ls4_t900.Marker.Size = 1;
                ls4_t900.Size = 2;

                ls4_t900.Values.Add(gamens[26]);
                ls4_t900.Values.Add(gamens[27]);
                ls4_t900.Values.Add(gamens[28]);
                ls4_t900.Values.Add(gamens[29]);
                ls4_t900.Values.Add(gamens[30]);
                ls4_t900.Values.Add(gamens[31]);
                ls4_t900.Values.Add(gamens[32]);

                chtT900_2.ValueAxis1.LineSeries.Add(ls4_t900);

                LineSeries ls5_t900 = new LineSeries("中央パターン");
                ls5_t900.Color = lblLine_Fuchsia.BackColor;
                ls5_t900.Marker.BackColor = ls5_t900.Marker.ForeColor = ls5_t900.Color;
                ls5_t900.Marker.Style = MarkerStyle.THANG;
                ls5_t900.Marker.Size = 1;
                ls5_t900.Size = 2;

                ls5_t900.Values.Add(gamens[33]);
                ls5_t900.Values.Add(gamens[34]);
                ls5_t900.Values.Add(gamens[35]);
                ls5_t900.Values.Add(gamens[36]);
                ls5_t900.Values.Add(gamens[37]);
                ls5_t900.Values.Add(gamens[38]);
                ls5_t900.Values.Add(gamens[39]);

                chtT900_2.ValueAxis1.LineSeries.Add(ls5_t900);

                LineSeries ls6_t900 = new LineSeries("下限パターン");
                ls6_t900.Color = lblLine_Cyan.BackColor;
                ls6_t900.Marker.BackColor = ls6_t900.Marker.ForeColor = ls6_t900.Color;
                ls6_t900.Marker.Style = MarkerStyle.THANG;
                ls6_t900.Marker.Size = 1;
                ls6_t900.Size = 2;

                ls6_t900.Values.Add(gamens[40]);
                ls6_t900.Values.Add(gamens[41]);
                ls6_t900.Values.Add(gamens[42]);
                ls6_t900.Values.Add(gamens[43]);
                ls6_t900.Values.Add(gamens[44]);
                ls6_t900.Values.Add(gamens[45]);
                ls6_t900.Values.Add(gamens[46]);

                chtT900_2.ValueAxis1.LineSeries.Add(ls6_t900);

                BarSeries bs3_t900 = new BarSeries("過去実績平均");
                bs3_t900.Size = 15;
                bs3_t900.Color = lblT900_Color2.BackColor;
                bs3_t900.BorderSize = 1;
                bs3_t900.BorderColor = Color.White;
                bs3_t900.Values.Add(gamens[47]);
                bs3_t900.Values.Add(gamens[48]);
                bs3_t900.Values.Add(gamens[49]);
                bs3_t900.Values.Add(gamens[50]);
                bs3_t900.Values.Add(gamens[51]);
                bs3_t900.Values.Add(gamens[52]);
                bs3_t900.Values.Add(gamens[53]);

                for (ii = 0; ii < chtT900_2.ValueAxis1.BarSeries.Count; ii++)
                {
                    if (chtT900_2.ValueAxis1.BarSeries[ii].Name.Equals(bs3_t900.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        chtT900_2.ValueAxis1.BarSeries.RemoveAt(ii);
                        chtT900_2.ValueAxis1.BarSeries.Insert(ii, bs3_t900);
                        break;
                    }
                }
                if (ii == chtT900_1.ValueAxis1.BarSeries.Count)
                {
                    chtT900_2.ValueAxis1.BarSeries.Add(bs3_t900);
                }
                //chtT900_2.ValueAxis1.BarSeries.Add(bs3_t900);

                BarSeries bs4_t900 = new BarSeries("Blank");
                bs4_t900.Size = 15;
                bs4_t900.BorderSize = 3;
                bs4_t900.BorderColor = Color.SkyBlue;
                bs4_t900.Values.Add(gamens[61]);
                bs4_t900.Values.Add(gamens[62]);
                bs4_t900.Values.Add(gamens[63]);
                bs4_t900.Values.Add(gamens[64]);
                bs4_t900.Values.Add(gamens[65]);
                bs4_t900.Values.Add(gamens[66]);
                bs4_t900.Values.Add(gamens[67]);
                chtT900_2.ValueAxis1.UpdateBarSeries.Add(bs4_t900);

                BarSeries bs5_t900 = new BarSeries("Blank");
                chtT900_2.ValueAxis1.UpdateBarSeries.Add(bs5_t900);
                // end chart 2
            }

            lblGamen002.Refresh();
            lblGamen077.Refresh();
            lblGamen131.Refresh();
        }

        private void lbl1Up1_MouseDown(object sender, MouseEventArgs e)
        {
            string lblName = ((Label)sender).Name;
            int valueChangable = Int32.Parse(lblName.Substring(lblName.Length - 1, 1));
            switch (valueChangable)
            {
                case 1:
                    lblT900_3_2_F1F2.Text = (Double.Parse(lblT900_3_2_F1F2.Text) + 0.1).ToString("0.00");
                    //lblT900_3_2_F1F2.ForeColor = lblT900_3_2_F1F2.Text.Equals(lblT900_3_1_F1F2.Text, StringComparison.OrdinalIgnoreCase) ? _Default_Color1 : _ValueChanged_Color1;
                    break;
                case 2:
                    lblT900_3_2_F2F3.Text = (Double.Parse(lblT900_3_2_F2F3.Text) + 0.1).ToString("0.00");
                    //lblT900_3_2_F2F3.ForeColor = lblT900_3_2_F2F3.Text.Equals(lblT900_3_1_F2F3.Text, StringComparison.OrdinalIgnoreCase) ? _Default_Color1 : _ValueChanged_Color1;
                    break;
                case 3:
                    lblT900_3_2_F3F4.Text = (Double.Parse(lblT900_3_2_F3F4.Text) + 0.1).ToString("0.00");
                    //lblT900_3_2_F3F4.ForeColor = lblT900_3_2_F3F4.Text.Equals(lblT900_3_1_F3F4.Text, StringComparison.OrdinalIgnoreCase) ? _Default_Color1 : _ValueChanged_Color1;
                    break;
                case 4:
                    lblT900_3_2_F4F5.Text = (Double.Parse(lblT900_3_2_F4F5.Text) + 0.05).ToString("0.00");
                    //lblT900_3_2_F4F5.ForeColor = lblT900_3_2_F4F5.Text.Equals(lblT900_3_1_F4F5.Text, StringComparison.OrdinalIgnoreCase) ? _Default_Color1 : _ValueChanged_Color1;
                    break;
                case 5:
                    lblT900_3_2_F5F6.Text = (Double.Parse(lblT900_3_2_F5F6.Text) + 0.05).ToString("0.00");
                    //lblT900_3_2_F5F6.ForeColor = lblT900_3_2_F5F6.Text.Equals(lblT900_3_1_F5F6.Text, StringComparison.OrdinalIgnoreCase) ? _Default_Color1 : _ValueChanged_Color1;
                    break;
                case 6:
                    lblT900_3_2_F6F7.Text = (Double.Parse(lblT900_3_2_F6F7.Text) + 0.05).ToString("0.00");
                    //lblT900_3_2_F6F7.ForeColor = lblT900_3_2_F6F7.Text.Equals(lblT900_3_1_F6F7.Text, StringComparison.OrdinalIgnoreCase) ? _Default_Color1 : _ValueChanged_Color1;
                    break;
                default:
                    break;
            }
        }

        private void lbl1Down1_MouseDown(object sender, MouseEventArgs e)
        {
            string lblName = ((Label)sender).Name;
            int valueChangable = Int32.Parse(lblName.Substring(lblName.Length - 1, 1));
            switch (valueChangable)
            {
                case 1:
                    lblT900_3_2_F1F2.Text = (Double.Parse(lblT900_3_2_F1F2.Text) - 0.1).ToString("0.00");
                    //lblT900_3_2_F1F2.ForeColor = lblT900_3_2_F1F2.Text.Equals(lblT900_3_1_F1F2.Text, StringComparison.OrdinalIgnoreCase) ? _Default_Color1 : _ValueChanged_Color1;
                    break;
                case 2:
                    lblT900_3_2_F2F3.Text = (Double.Parse(lblT900_3_2_F2F3.Text) - 0.1).ToString("0.00");
                    ///lblT900_3_2_F2F3.ForeColor = lblT900_3_2_F2F3.Text.Equals(lblT900_3_1_F2F3.Text, StringComparison.OrdinalIgnoreCase) ? _Default_Color1 : _ValueChanged_Color1;
                    break;
                case 3:
                    lblT900_3_2_F3F4.Text = (Double.Parse(lblT900_3_2_F3F4.Text) - 0.1).ToString("0.00");
                    //lblT900_3_2_F3F4.ForeColor = lblT900_3_2_F3F4.Text.Equals(lblT900_3_1_F3F4.Text, StringComparison.OrdinalIgnoreCase) ? _Default_Color1 : _ValueChanged_Color1;
                    break;
                case 4:
                    lblT900_3_2_F4F5.Text = (Double.Parse(lblT900_3_2_F4F5.Text) - 0.05).ToString("0.00");
                    //lblT900_3_2_F4F5.ForeColor = lblT900_3_2_F4F5.Text.Equals(lblT900_3_1_F4F5.Text, StringComparison.OrdinalIgnoreCase) ? _Default_Color1 : _ValueChanged_Color1;
                    break;
                case 5:
                    lblT900_3_2_F5F6.Text = (Double.Parse(lblT900_3_2_F5F6.Text) - 0.05).ToString("0.00");
                    //lblT900_3_2_F5F6.ForeColor = lblT900_3_2_F5F6.Text.Equals(lblT900_3_1_F5F6.Text, StringComparison.OrdinalIgnoreCase) ? _Default_Color1 : _ValueChanged_Color1;
                    break;
                case 6:
                    lblT900_3_2_F6F7.Text = (Double.Parse(lblT900_3_2_F6F7.Text) - 0.05).ToString("0.00");
                    //lblT900_3_2_F6F7.ForeColor = lblT900_3_2_F6F7.Text.Equals(lblT900_3_1_F6F7.Text, StringComparison.OrdinalIgnoreCase) ? _Default_Color1 : _ValueChanged_Color1;
                    break;
                default:
                    break;
            }
        }

        private void lbl1Clear_Click(object sender, EventArgs e)
        {
            //lblT900_3_2_F1F2.Text = lblT900_3_1_F1F2.Text;
            //lblT900_3_2_F2F3.Text = lblT900_3_1_F2F3.Text;
            //lblT900_3_2_F3F4.Text = lblT900_3_1_F3F4.Text;
            //lblT900_3_2_F4F5.Text = lblT900_3_1_F4F5.Text;
            //lblT900_3_2_F5F6.Text = lblT900_3_1_F5F6.Text;
            //lblT900_3_2_F6F7.Text = lblT900_3_1_F6F7.Text;

            //lblT900_3_2_F1F2.ForeColor = _Default_Color1;
            //lblT900_3_2_F2F3.ForeColor = _Default_Color1;
            //lblT900_3_2_F3F4.ForeColor = _Default_Color1;
            //lblT900_3_2_F4F5.ForeColor = _Default_Color1;
            //lblT900_3_2_F5F6.ForeColor = _Default_Color1;
            //lblT900_3_2_F6F7.ForeColor = _Default_Color1;

            //lbl1Calculate_Click(lbl1Calculate, e);

            // modify for requirement 2008/09/15
            // reload gamen
            if (this.OnSimulation_Clear != null)
            {
                lbl1Clear.Enabled = false;
                lbl1Calculate.Enabled = false;
                try
                {
                    T900 t900 = T900.GetLast();
                    if (t900.ID > 0)
                    {
                        Gamen gamen = this.OnSimulation_Clear(this, new SimulationCalculateEventArgs(t900, this._SimulateTime1, SimulationType.Simulation1Clear));
                        if (gamen != null)
                        {
                            FillData(gamen);
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.Error("lbl1Clear_Click error. Detail:", ex);
                }
                finally
                {
                    lbl1Clear.Enabled = true;
                    lbl1Calculate.Enabled = true;
                }
            }
        }

        private void lbl1Calculate_Click(object sender, EventArgs e)
        {
            if (this.OnSimulation_Calculate1 == null)
            {
                return;
            }
            lbl1Calculate.Enabled = false;
            try
            {
                T900 t900 = T900.GetLast();
                if (t900.ID > 0)
                {
                    t900.R367.R1 = Convert.ToInt16(Convert.ToDouble(lblT900_3_2_F1F2.Text.Trim()) * 100);
                    t900.R367.R2 = Convert.ToInt16(Convert.ToDouble(lblT900_3_2_F2F3.Text.Trim()) * 100);
                    t900.R367.R3 = Convert.ToInt16(Convert.ToDouble(lblT900_3_2_F3F4.Text.Trim()) * 100);
                    t900.R367.R4 = Convert.ToInt16(Convert.ToDouble(lblT900_3_2_F4F5.Text.Trim()) * 100);
                    t900.R367.R5 = Convert.ToInt16(Convert.ToDouble(lblT900_3_2_F5F6.Text.Trim()) * 100);
                    t900.R367.R6 = Convert.ToInt16(Convert.ToDouble(lblT900_3_2_F6F7.Text.Trim()) * 100);

                    t900.R227.F1 = Convert.ToInt16(lblT900_3_4_F1.Text.Trim());
                    t900.R227.F2 = Convert.ToInt16(lblT900_3_4_F2.Text.Trim());
                    t900.R227.F3 = Convert.ToInt16(lblT900_3_4_F3.Text.Trim());
                    t900.R227.F4 = Convert.ToInt16(lblT900_3_4_F4.Text.Trim());
                    t900.R227.F5 = Convert.ToInt16(lblT900_3_4_F5.Text.Trim());
                    t900.R227.F6 = Convert.ToInt16(lblT900_3_4_F6.Text.Trim());
                    t900.R227.F6 = Convert.ToInt16(lblT900_3_4_F7.Text.Trim());

                    Gamen gamen = this.OnSimulation_Calculate1(this, new SimulationCalculateEventArgs(t900, this._SimulateTime1, SimulationType.Simulation1));
                    FillData(gamen);
                }
            }
            catch (Exception ex)
            {
                log.Error("lbl1Calculate_Click error. Detail:", ex);
            }
            finally
            {
                this._SimulateTime1++;
                lbl1Calculate.Enabled = true;
            }
        }

        private void lbl2Up1_MouseDown(object sender, MouseEventArgs e)
        {
            string lblName = ((Label)sender).Name;
            int valueChangable = Int32.Parse(lblName.Substring(lblName.Length - 1, 1));
            switch (valueChangable)
            {
                case 1:
                    lblT900_3_4_F1.Text = (Int32.Parse(lblT900_3_4_F1.Text) + 10).ToString();
                    //lblT900_3_4_F1.ForeColor = lblT900_3_4_F1.Text.Equals(lblT900_3_3_F1.Text, StringComparison.OrdinalIgnoreCase) ? _Default_Color2 : _ValueChanged_Color2;
                    break;
                case 2:
                    lblT900_3_4_F2.Text = (Int32.Parse(lblT900_3_4_F2.Text) + 10).ToString();
                    //lblT900_3_4_F2.ForeColor = lblT900_3_4_F2.Text.Equals(lblT900_3_3_F2.Text, StringComparison.OrdinalIgnoreCase) ? _Default_Color2 : _ValueChanged_Color2;
                    break;
                case 3:
                    lblT900_3_4_F3.Text = (Int32.Parse(lblT900_3_4_F3.Text) + 10).ToString();
                    //lblT900_3_4_F3.ForeColor = lblT900_3_4_F3.Text.Equals(lblT900_3_3_F3.Text, StringComparison.OrdinalIgnoreCase) ? _Default_Color2 : _ValueChanged_Color2;
                    break;
                case 4:
                    lblT900_3_4_F4.Text = (Int32.Parse(lblT900_3_4_F4.Text) + 10).ToString();
                    //lblT900_3_4_F4.ForeColor = lblT900_3_4_F4.Text.Equals(lblT900_3_3_F4.Text, StringComparison.OrdinalIgnoreCase) ? _Default_Color2 : _ValueChanged_Color2;
                    break;
                case 5:
                    lblT900_3_4_F5.Text = (Int32.Parse(lblT900_3_4_F5.Text) + 10).ToString();
                    //lblT900_3_4_F5.ForeColor = lblT900_3_4_F5.Text.Equals(lblT900_3_3_F5.Text, StringComparison.OrdinalIgnoreCase) ? _Default_Color2 : _ValueChanged_Color2;
                    break;
                case 6:
                    lblT900_3_4_F6.Text = (Int32.Parse(lblT900_3_4_F6.Text) + 10).ToString();
                    //lblT900_3_4_F6.ForeColor = lblT900_3_4_F6.Text.Equals(lblT900_3_3_F6.Text, StringComparison.OrdinalIgnoreCase) ? _Default_Color2 : _ValueChanged_Color2;
                    break;
                case 7:
                    lblT900_3_4_F7.Text = (Int32.Parse(lblT900_3_4_F7.Text) + 10).ToString();
                    //lblT900_3_4_F7.ForeColor = lblT900_3_4_F7.Text.Equals(lblT900_3_3_F7.Text, StringComparison.OrdinalIgnoreCase) ? _Default_Color2 : _ValueChanged_Color2;
                    break;
                default:
                    break;
            }
        }

        private void lbl2Down1_MouseDown(object sender, MouseEventArgs e)
        {
            string lblName = ((Label)sender).Name;
            int valueChangable = Int32.Parse(lblName.Substring(lblName.Length - 1, 1));
            switch (valueChangable)
            {
                case 1:
                    lblT900_3_4_F1.Text = (Int32.Parse(lblT900_3_4_F1.Text) - 10).ToString();
                    //lblT900_3_4_F1.ForeColor = lblT900_3_4_F1.Text.Equals(lblT900_3_3_F1.Text, StringComparison.OrdinalIgnoreCase) ? _Default_Color2 : _ValueChanged_Color2;
                    break;
                case 2:
                    lblT900_3_4_F2.Text = (Int32.Parse(lblT900_3_4_F2.Text) - 10).ToString();
                    //lblT900_3_4_F2.ForeColor = lblT900_3_4_F2.Text.Equals(lblT900_3_3_F2.Text, StringComparison.OrdinalIgnoreCase) ? _Default_Color2 : _ValueChanged_Color2;
                    break;
                case 3:
                    lblT900_3_4_F3.Text = (Int32.Parse(lblT900_3_4_F3.Text) - 10).ToString();
                    //lblT900_3_4_F3.ForeColor = lblT900_3_4_F3.Text.Equals(lblT900_3_3_F3.Text, StringComparison.OrdinalIgnoreCase) ? _Default_Color2 : _ValueChanged_Color2;
                    break;
                case 4:
                    lblT900_3_4_F4.Text = (Int32.Parse(lblT900_3_4_F4.Text) - 10).ToString();
                    //lblT900_3_4_F4.ForeColor = lblT900_3_4_F4.Text.Equals(lblT900_3_3_F4.Text, StringComparison.OrdinalIgnoreCase) ? _Default_Color2 : _ValueChanged_Color2;
                    break;
                case 5:
                    lblT900_3_4_F5.Text = (Int32.Parse(lblT900_3_4_F5.Text) - 10).ToString();
                    //lblT900_3_4_F5.ForeColor = lblT900_3_4_F5.Text.Equals(lblT900_3_3_F5.Text, StringComparison.OrdinalIgnoreCase) ? _Default_Color2 : _ValueChanged_Color2;
                    break;
                case 6:
                    lblT900_3_4_F6.Text = (Int32.Parse(lblT900_3_4_F6.Text) - 10).ToString();
                    //lblT900_3_4_F6.ForeColor = lblT900_3_4_F6.Text.Equals(lblT900_3_3_F6.Text, StringComparison.OrdinalIgnoreCase) ? _Default_Color2 : _ValueChanged_Color2;
                    break;
                case 7:
                    lblT900_3_4_F7.Text = (Int32.Parse(lblT900_3_4_F7.Text) - 10).ToString();
                    //lblT900_3_4_F7.ForeColor = lblT900_3_4_F7.Text.Equals(lblT900_3_3_F7.Text, StringComparison.OrdinalIgnoreCase) ? _Default_Color2 : _ValueChanged_Color2;
                    break;
                default:
                    break;
            }
        }

        private void lbl2Clear_Click(object sender, EventArgs e)
        {
            //lblT900_3_4_F1.Text = lblT900_3_3_F1.Text;
            //lblT900_3_4_F2.Text = lblT900_3_3_F2.Text;
            //lblT900_3_4_F3.Text = lblT900_3_3_F3.Text;
            //lblT900_3_4_F4.Text = lblT900_3_3_F4.Text;
            //lblT900_3_4_F5.Text = lblT900_3_3_F5.Text;
            //lblT900_3_4_F6.Text = lblT900_3_3_F6.Text;
            //lblT900_3_4_F7.Text = lblT900_3_3_F7.Text;

            //lblT900_3_4_F1.ForeColor = _Default_Color2;
            //lblT900_3_4_F2.ForeColor = _Default_Color2;
            //lblT900_3_4_F3.ForeColor = _Default_Color2;
            //lblT900_3_4_F4.ForeColor = _Default_Color2;
            //lblT900_3_4_F5.ForeColor = _Default_Color2;
            //lblT900_3_4_F6.ForeColor = _Default_Color2;
            //lblT900_3_4_F7.ForeColor = _Default_Color2;

            //lbl2Calculate_Click(lbl2Calculate, e);

            // modify for requirement 2008/09/15
            // reload gamen
            if (this.OnSimulation_Clear != null)
            {
                lbl2Clear.Enabled = false;
                lbl2Calculate.Enabled = false;
                try
                {
                    T900 t900 = T900.GetLast();
                    if (t900.ID > 0)
                    {
                        Gamen gamen = this.OnSimulation_Clear(this, new SimulationCalculateEventArgs(t900, this._SimulateTime2, SimulationType.Simulation2Clear));
                        if (gamen != null)
                        {
                            FillData(gamen);
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.Error("lbl2Clear_Click error. Detail:", ex);
                }
                finally
                {
                    lbl2Clear.Enabled = true;
                    lbl2Calculate.Enabled = true;
                }
            }
        }

        private void lbl2Calculate_Click(object sender, EventArgs e)
        {
            if (this.OnSimulation_Calculate2 == null)
            {
                return;
            }
            lbl2Calculate.Enabled = false;
            try
            {
                T900 t900 = T900.GetLast();
                if (t900.ID > 0)
                {
                    t900.R367.R1 = Convert.ToInt16(Convert.ToDouble(lblT900_3_2_F1F2.Text.Trim()) * 100);
                    t900.R367.R2 = Convert.ToInt16(Convert.ToDouble(lblT900_3_2_F2F3.Text.Trim()) * 100);
                    t900.R367.R3 = Convert.ToInt16(Convert.ToDouble(lblT900_3_2_F3F4.Text.Trim()) * 100);
                    t900.R367.R4 = Convert.ToInt16(Convert.ToDouble(lblT900_3_2_F4F5.Text.Trim()) * 100);
                    t900.R367.R5 = Convert.ToInt16(Convert.ToDouble(lblT900_3_2_F5F6.Text.Trim()) * 100);
                    t900.R367.R6 = Convert.ToInt16(Convert.ToDouble(lblT900_3_2_F6F7.Text.Trim()) * 100);

                    t900.R227.F1 = Convert.ToInt16(lblT900_3_4_F1.Text.Trim());
                    t900.R227.F2 = Convert.ToInt16(lblT900_3_4_F2.Text.Trim());
                    t900.R227.F3 = Convert.ToInt16(lblT900_3_4_F3.Text.Trim());
                    t900.R227.F4 = Convert.ToInt16(lblT900_3_4_F4.Text.Trim());
                    t900.R227.F5 = Convert.ToInt16(lblT900_3_4_F5.Text.Trim());
                    t900.R227.F6 = Convert.ToInt16(lblT900_3_4_F6.Text.Trim());
                    t900.R227.F7 = Convert.ToInt16(lblT900_3_4_F7.Text.Trim());

                    Gamen gamen = this.OnSimulation_Calculate2(this, new SimulationCalculateEventArgs(t900, this._SimulateTime2, SimulationType.Simulation2));
                    FillData(gamen);
                }
            }
            catch (Exception ex)
            {
                log.Error("lbl1Calculate_Click error. Detail:", ex);
            }
            finally
            {
                this._SimulateTime2++;
                lbl2Calculate.Enabled = true;
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

        private void FormFinishSupport1_Load(object sender, EventArgs e)
        {
            PreloadAll();
        }

        private void lblT900_3_2_TextChanged(object sender, EventArgs e)
        {
            Label lblStatic = null;
            Label lblDynamic = null;
            try
            {
                lblDynamic = (Label)sender;
                int valueChangable = Int32.Parse(lblDynamic.Name.Substring(lblDynamic.Name.Length - 1, 1));
                switch (valueChangable)
                {
                    case 2:
                        lblStatic = lblT900_3_1_F1F2;
                        break;
                    case 3:
                        lblStatic = lblT900_3_1_F2F3;
                        break;
                    case 4:
                        lblStatic = lblT900_3_1_F3F4;
                        break;
                    case 5:
                        lblStatic = lblT900_3_1_F4F5;
                        break;
                    case 6:
                        lblStatic = lblT900_3_1_F5F6;
                        break;
                    case 7:
                        lblStatic = lblT900_3_1_F6F7;
                        break;
                    default:
                        return;
                }

                if (lblStatic.Text.Equals(lblDynamic.Text, StringComparison.OrdinalIgnoreCase))
                {
                    lblDynamic.ForeColor = _Default_Color1;
                }
                else
                {
                    lblDynamic.ForeColor = _ValueChanged_Color1;
                }
            }
            catch (Exception)
            {
            }
        }

        private void lblT900_3_4_TextChanged(object sender, EventArgs e)
        {
            Label lblStatic = null;
            Label lblDynamic = null;
            try
            {
                lblDynamic = (Label)sender;
                int valueChangable = Int32.Parse(lblDynamic.Name.Substring(lblDynamic.Name.Length - 1, 1));
                switch (valueChangable)
                {
                    case 1:
                        lblStatic = lblT900_3_3_F1;
                        break;
                    case 2:
                        lblStatic = lblT900_3_3_F2;
                        break;
                    case 3:
                        lblStatic = lblT900_3_3_F3;
                        break;
                    case 4:
                        lblStatic = lblT900_3_3_F4;
                        break;
                    case 5:
                        lblStatic = lblT900_3_3_F5;
                        break;
                    case 6:
                        lblStatic = lblT900_3_3_F6;
                        break;
                    case 7:
                        lblStatic = lblT900_3_3_F7;
                        break;
                    default:
                        return;
                }

                if (lblStatic.Text.Equals(lblDynamic.Text, StringComparison.OrdinalIgnoreCase))
                {
                    lblDynamic.ForeColor = _Default_Color2;
                }
                else
                {
                    lblDynamic.ForeColor = _ValueChanged_Color2;
                }
            }
            catch (Exception)
            {
            }
        }
    }
}