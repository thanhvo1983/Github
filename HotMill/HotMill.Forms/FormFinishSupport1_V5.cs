using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using log4net;
using Kvics.HotMill.BL;
using Kvics.Controls.Chart;

namespace Kvics.HotMill.Forms
{
    public partial class FormFinishSupport1_V5 : SubFormFullScreen
    {
        private static readonly ILog log = Kvics.DBAccess.Log.Instance.GetLogger(typeof(FormFinishSupport1_V5));
        private static readonly Color WORKER_BACKCOLOR_NOMAL = Color.Black;
        private static readonly Color WORKER_BACKCOLOR_HIGHLIGHT = Color.Green;
        private static readonly Color ROLL_PROFILE_BACKCOLOR_NOMAL = Color.Black;
        private static readonly Color ROLL_PROFILE_BACKCOLOR_HIGHLIGHT = Color.Lime;
        private static readonly Color ROLL_PROFILE_FORCOLOR_NOMAL = Color.Lime;
        private static readonly Color ROLL_PROFILE_FORCOLOR_HIGHLIGHT = Color.Black;
        private static readonly int LBLT900_ROLLGAP_DIFF_POSITIVE_TOP = 10;
        private static readonly int LBLT900_ROLLGAP_DIFF_NEGATIVE_TOP = 59;
        private static readonly int MIN_VALUE = Int32.MinValue;


        //private static readonly int TOP_F3 = -294;
        private Label[] _lblWorkerList = new Label[24];
        private int _SelectedWorkerIndex = 0;
        private int _SelectedWorkerID = -1;
        private bool _IsLoading = true;
        private bool _Idle = false;
        private WorkerCollection _UserColl = null;
        public event Worker_EventHandler OnWorker_Selected;
        private int _T900BlinkCount = 0;
        private int _T800BlinkCount = 0;
        private int _T900AlertType = 0;
        private int _T800AlertType = 0;
        private int _T900AlertCount = 0;
        private int _T800AlertCount = 0;

        public FormFinishSupport1_V5()
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
            
            switch (keyData)
            {
                case Keys.NumPad1:
                    SendDataTest(DataPackages.Preset);
                    break;
                case Keys.NumPad2:
                    SendDataTest(DataPackages.FinalSet);
                    break;
                case Keys.NumPad3:
                    SendDataTest(DataPackages.Result);
                    break;
                default:
                    break;
            }

            /*
            // test for refresh data
            if ((keyData & Keys.Control) == Keys.Control)
            {
                Keys keyPressed = keyData & (~Keys.Control);
                switch (keyPressed)
                {
                    case Keys.D1:
                        LoadAlert(1, "１Test value １.");
                        break;
                    case Keys.D2:
                        LoadAlert(2, "１Test value １.");
                        break;
                    case Keys.D3:
                        LoadAlert(1, "２Test value ２.");
                        break;
                    case Keys.D4:
                        LoadAlert(2, "２Test value ２.");
                        break;
                    case Keys.D5:
                        LoadAlert(1, "３Test value ３.");
                        break;
                    case Keys.D6:
                        LoadAlert(2, "３Test value ３.");
                        break;
                    case Keys.F5:
                        LoadData(DataPackages.Preset);
                        break;
                    case Keys.F6:
                        LoadData(DataPackages.FinalSet);
                        break;
                    case Keys.F7:
                        LoadData(DataPackages.Result);
                        break;
                    case Keys.F8:
                        LoadData(DataPackages.Finished);
                        break;
                    case Keys.F9:
                        LoadData(DataPackages.Preset);
                        LoadData(DataPackages.FinalSet);
                        LoadData(DataPackages.Finished);
                        LoadData(DataPackages.Result);
                        break;
                    case Keys.F10:
                        this.Refresh();
                        break;
                    default:
                        break;
                }
            }
            // end test
            */

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void pnlT800_7F_StateChanged()
        {
            //this.pnlT1800_7F.Top = TOP_F3 - this.pnlT1800_7F.Top;
            /*
            if (this.pnlT1800_7F.Top < 0)
            {
                lblStickF3_1.Visible = true;
                lblStickF3_2.Visible = true;
            }
            else
            {
                lblStickF3_1.Visible = false;
                lblStickF3_2.Visible = false;
            }
            */
            lblStickF1_1.Refresh();
            lblStickF1_2.Refresh();
            /*
            lblStickF3_1.Refresh();
            lblStickF3_2.Refresh();
            */
        }

        private void SelectWorker(int index)
        {
            if (_UserColl != null && index >= 0 && index < _lblWorkerList.Length && index < _UserColl.Count)
            {
                _lblWorkerList[_SelectedWorkerIndex].BackColor = WORKER_BACKCOLOR_NOMAL;
                _SelectedWorkerIndex = index;

                if (OnWorker_Selected != null)
                {
                    _Idle = true;
                    OnWorker_Selected(this, new WorkerEventArgs(new TWorker(_UserColl[index].ID)));
                    _Idle = false;
                }

                _lblWorkerList[_SelectedWorkerIndex].BackColor = WORKER_BACKCOLOR_HIGHLIGHT;
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
        #region comment
        /*
        private void InitTempData()
        {
            #region T900 Roll Gap
            T900_I2_07 t900_R393 = new T900_I2_07(0, 0, 1971, 1341, 1050, 870, 734, 702, 727);
            this.lblT900_RollGap_F1.Text = (t900_R393.F1 * 0.01).ToString("0.00;-0.00;0.00");
            this.lblT900_RollGap_F2.Text = (t900_R393.F2 * 0.01).ToString("0.00;-0.00;0.00");
            this.lblT900_RollGap_F3.Text = (t900_R393.F3 * 0.01).ToString("0.00;-0.00;0.00");
            this.lblT900_RollGap_F4.Text = (t900_R393.F4 * 0.01).ToString("0.00;-0.00;0.00");
            this.lblT900_RollGap_F5.Text = (t900_R393.F5 * 0.01).ToString("0.00;-0.00;0.00");
            this.lblT900_RollGap_F6.Text = (t900_R393.F6 * 0.01).ToString("0.00;-0.00;0.00");
            this.lblT900_RollGap_F7.Text = (t900_R393.F7 * 0.01).ToString("0.00;-0.00;0.00");

            // GAMEN 238 - 243
            
            double[] gamen238 = new double[] { 7.05, 3.32, 3.88, 1.71, 0.76, 0.38 };
            this.lblT900_RollGap_Past_F1F2.Text = gamen238[0].ToString("0.0;-0.0;0.0");
            this.lblT900_RollGap_Past_F2F3.Text = gamen238[1].ToString("0.0;-0.0;0.0");
            this.lblT900_RollGap_Past_F3F4.Text = gamen238[2].ToString("0.0;-0.0;0.0");
            this.lblT900_RollGap_Past_F4F5.Text = gamen238[3].ToString("0.0;-0.0;0.0");
            this.lblT900_RollGap_Past_F5F6.Text = gamen238[4].ToString("0.0;-0.0;0.0");
            this.lblT900_RollGap_Past_F6F7.Text = gamen238[5].ToString("0.0;-0.0;0.0");
            
            T900_I2_06 t900_R369 = new T900_I2_06(0, 0, 858, 392, 261, 155, 54, 15);
            this.lblT900_RollGap_Preliminary_F1F2.Text = (t900_R369.R1 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT900_RollGap_Preliminary_F2F3.Text = (t900_R369.R2 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT900_RollGap_Preliminary_F3F4.Text = (t900_R369.R3 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT900_RollGap_Preliminary_F4F5.Text = (t900_R369.R4 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT900_RollGap_Preliminary_F5F6.Text = (t900_R369.R5 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT900_RollGap_Preliminary_F6F7.Text = (t900_R369.R6 * 0.01).ToString("0.0;-0.0;0.0");
            
            #endregion

            #region chtT900_RollGapDiff

            BarSeries barRollGapDiff = new BarSeries("Roll Gap Difference");
            barRollGapDiff.BorderSize = 2;
            barRollGapDiff.BorderColor = Color.White;
            barRollGapDiff.Color = Color.Blue;
            barRollGapDiff.Size = 40;

            int[] t900_R381 = new int[] { -1, 10, 11, 15, 4, 33 };

            barRollGapDiff.Values.Add(t900_R381[0] * 0.01);
            barRollGapDiff.Values.Add(t900_R381[1] * 0.01);
            barRollGapDiff.Values.Add(t900_R381[2] * 0.01);
            barRollGapDiff.Values.Add(t900_R381[3] * 0.01);
            barRollGapDiff.Values.Add(t900_R381[4] * 0.01);
            barRollGapDiff.Values.Add(t900_R381[5] * 0.01);

            lblT900_RollGapDiff_F1F2.Text = (t900_R381[0] * 0.01).ToString("0.0;-0.0;0.0");
            lblT900_RollGapDiff_F2F3.Text = (t900_R381[1] * 0.01).ToString("0.0;-0.0;0.0");
            lblT900_RollGapDiff_F3F4.Text = (t900_R381[2] * 0.01).ToString("0.0;-0.0;0.0");
            lblT900_RollGapDiff_F4F5.Text = (t900_R381[3] * 0.01).ToString("0.0;-0.0;0.0");
            lblT900_RollGapDiff_F5F6.Text = (t900_R381[4] * 0.01).ToString("0.0;-0.0;0.0");
            lblT900_RollGapDiff_F6F7.Text = (t900_R381[5] * 0.01).ToString("0.0;-0.0;0.0");

            lblT900_RollGapDiff_F1F2.Top = t900_R381[0] > 0 ? LBLT900_ROLLGAP_DIFF_POSITIVE_TOP : LBLT900_ROLLGAP_DIFF_NEGATIVE_TOP;
            lblT900_RollGapDiff_F2F3.Top = t900_R381[1] > 0 ? LBLT900_ROLLGAP_DIFF_POSITIVE_TOP : LBLT900_ROLLGAP_DIFF_NEGATIVE_TOP;
            lblT900_RollGapDiff_F3F4.Top = t900_R381[2] > 0 ? LBLT900_ROLLGAP_DIFF_POSITIVE_TOP : LBLT900_ROLLGAP_DIFF_NEGATIVE_TOP;
            lblT900_RollGapDiff_F4F5.Top = t900_R381[3] > 0 ? LBLT900_ROLLGAP_DIFF_POSITIVE_TOP : LBLT900_ROLLGAP_DIFF_NEGATIVE_TOP;
            lblT900_RollGapDiff_F5F6.Top = t900_R381[4] > 0 ? LBLT900_ROLLGAP_DIFF_POSITIVE_TOP : LBLT900_ROLLGAP_DIFF_NEGATIVE_TOP;
            lblT900_RollGapDiff_F6F7.Top = t900_R381[5] > 0 ? LBLT900_ROLLGAP_DIFF_POSITIVE_TOP : LBLT900_ROLLGAP_DIFF_NEGATIVE_TOP;

            chtT900_RollGapDiff.ValueAxis1.BarSeries.Add(barRollGapDiff);
            #endregion

            lblT900_Alert.Text = "F7先端中伸び注意";

            #region chtT900_PathPattern

            T900_I2_07 t900_R171 = new T900_I2_07(0, 0, 1694, 945, 641, 452, 338, 261, 234);
            T900_I2_07 t900_R229 = new T900_I2_07(0, 0, 1961, 1504, 1141, 1215, 1266, 1074, 703);
            int[] gamen_PathPatternX = new int[] { 1554, 921, 579, 409, 305, 246, 218 };
            int[] gamen_PathPatternY = new int[] { 1840, 1450, 1234, 1310, 1154, 1086, 873 };
            
            int[] gamen_PathPatternXMin = new int[] { 1554, 921, 579, 409, 305, 246, 218 };
            int[] gamen_PathPatternXMax = new int[] { 1792, 993, 627, 424, 303, 236, 205 };
            int[] gamen_PathPatternYMin = new int[] { 2162, 2040, 2062, 1867, 1866, 1524, 1287 };
            int[] gamen_PathPatternYMax = new int[] { 1729, 1608, 1565, 1621, 1616, 1264, 1037 };
            
            int minX = Int32.MaxValue;
            int maxX = Int32.MinValue;
            int minY = Int32.MaxValue;
            int maxY = Int32.MinValue;

            LineSeries lnPathPattern = new LineSeries("パスパターン 当材");
            lnPathPattern.Marker.Style = MarkerStyle.TAM_GIAC;
            lnPathPattern.Marker.Size = 10;
            lnPathPattern.Color = Color.Red;
            lnPathPattern.Marker.ForeColor = Color.Red;
            lnPathPattern.Marker.BackColor = Color.Red;

            LineSeries lnGamenPathPattern = new LineSeries("パスパターン 前材");
            lnGamenPathPattern.Marker.Style = MarkerStyle.VUONG;
            lnGamenPathPattern.Marker.Size = 10;
            lnGamenPathPattern.Color = Color.Yellow;
            lnGamenPathPattern.Marker.ForeColor = Color.Yellow;
            lnGamenPathPattern.Marker.BackColor = Color.Yellow;

            TetragonCustomSeries lnAreaPathPattern = new TetragonCustomSeries("パスパターン 上限");
            lnAreaPathPattern.Color = Color.LightYellow;
            lnAreaPathPattern.TransposeX = true;

            for (int i = 0; i < t900_R171.Rows.Length; i++)
            {
                minX = Math.Min(minX, t900_R171.Rows[i]);
                maxX = Math.Max(maxX, t900_R171.Rows[i]);

                minY = Math.Min(minY, t900_R229.Rows[i]);
                maxY = Math.Max(maxY, t900_R229.Rows[i]);

                minX = Math.Min(minX, gamen_PathPatternX[i]);
                maxX = Math.Max(maxX, gamen_PathPatternX[i]);

                minY = Math.Min(minY, gamen_PathPatternY[i]);
                maxY = Math.Max(maxY, gamen_PathPatternY[i]);

                minX = Math.Min(minX, gamen_PathPatternXMin[i]);
                maxX = Math.Max(maxX, gamen_PathPatternXMin[i]);

                minY = Math.Min(minY, gamen_PathPatternYMin[i]);
                maxY = Math.Max(maxY, gamen_PathPatternYMin[i]);

                minX = Math.Min(minX, gamen_PathPatternXMax[i]);
                maxX = Math.Max(maxX, gamen_PathPatternXMax[i]);

                minY = Math.Min(minY, gamen_PathPatternYMax[i]);
                maxY = Math.Max(maxY, gamen_PathPatternYMax[i]);
            }

            minX = (minX / 500) * 500 - (minX % 500 > 0 ? 0 : 500);
            maxX = (maxX / 500) * 500 + (maxX % 500 > 0 ? 500 : 0);

            minY = (minY / 1000) * 1000 - (minY % 1000 > 0 ? 0 : 1000);
            maxY = (maxY / 1000) * 1000 + (maxY % 1000 > 0 ? 1000 : 0);

            chtT900_PathPattern.Min1 = minY;
            chtT900_PathPattern.Max1 = maxY;
            chtT900_PathPattern.Ranger1 = (maxY - minY) > 2000 ? 1000 : 500;

            chtT900_PathPattern.Category = new string[maxX - minX + 1];
            for (int i = 0; i < chtT900_PathPattern.Category.Length; i++)
            {
                chtT900_PathPattern.Category[i] = ((chtT900_PathPattern.Category.Length - i - 1) / 100).ToString();
            }
            chtT900_PathPattern.TickMarkStep = 500;

            for (int i = 0; i < chtT900_PathPattern.Category.Length; i++)
            {
                lnPathPattern.Values.Add(Double.MinValue);
                lnGamenPathPattern.Values.Add(Double.MinValue);
            }
            for (int i = 0; i < t900_R229.Rows.Length; i++)
            {
                lnPathPattern.Values[chtT900_PathPattern.Category.Length - 1 - (int)(t900_R171.Rows[i])] = t900_R229.Rows[i];
                lnGamenPathPattern.Values[chtT900_PathPattern.Category.Length - 1 - (int)(gamen_PathPatternX[i])] = gamen_PathPatternY[i];
            }

            lnAreaPathPattern.MinX = minX;
            lnAreaPathPattern.MaxX = maxX;
            for (int i = 0; i < gamen_PathPatternXMax.Length; i++)
            {
                lnAreaPathPattern.Values.Add(new LineF(new PointF(gamen_PathPatternXMin[i], gamen_PathPatternYMin[i]), new PointF(gamen_PathPatternXMax[i], gamen_PathPatternYMax[i])));
            }

            chtT900_PathPattern.ValueAxis1.LineSeries.Add(lnPathPattern);
            chtT900_PathPattern.ValueAxis1.LineSeries.Add(lnGamenPathPattern);
            chtT900_PathPattern.ValueAxis1.TetragonCustomSeries.Add(lnAreaPathPattern);
            #endregion

            #region chtT900_Vendor
            int[] vendorT900 = new int[] { 187, 141, 189, 173, 173, 173, 89 };

            BarSeries barVendorT900 = new BarSeries("Vendor T900");
            barVendorT900.BorderSize = 2;
            barVendorT900.BorderColor = Color.White;
            barVendorT900.Color = Color.Yellow;
            barVendorT900.Size = 40;

            for (int i = 0; i < vendorT900.Length; i++)
            {
                barVendorT900.Values.Add(vendorT900[i]);
            }

            chtT900_Vendor.ValueAxis1.BarSeries.Add(barVendorT900);
            #endregion

            #region chtT900_CrownTotal
            int[] crownTotalT9001 = new int[] { 214, 237, 221, 179, 169, 148, 37 };
            int[] crownTotalT9002 = new int[] { 214, 237, 221, 179, 169, 148, 37 };//{ 6, 14, 15, 0, 0, 0, 0 };

            BarSeries barCrownTotal1T900 = new BarSeries("Crown Total 1 T900");
            barCrownTotal1T900.BorderSize = 1;
            barCrownTotal1T900.BorderColor = Color.White;
            barCrownTotal1T900.Color = Color.Red;
            barCrownTotal1T900.Size = 20;

            BarSeries barCrownTotal2T900 = new BarSeries("Crown Total 2 T900");
            barCrownTotal2T900.BorderSize = 1;
            barCrownTotal2T900.BorderColor = Color.White;
            barCrownTotal2T900.Color = Color.Yellow;
            barCrownTotal2T900.Size = 20;

            for (int i = 0; i < crownTotalT9001.Length; i++)
            {
                barCrownTotal1T900.Values.Add(crownTotalT9001[i]);
                barCrownTotal2T900.Values.Add(crownTotalT9002[i]);
            }

            chtT900_CrownTotal.ValueAxis1.BarSeries.Add(barCrownTotal1T900);
            chtT900_CrownTotal.ValueAxis1.BarSeries.Add(barCrownTotal2T900);
            #endregion



            #region T800 Roll Gap
            T800_I2_07 t800_R355 = new T800_I2_07(0, 0, 2641, 1813, 1423, 1131, 957, 883, 874);
            this.lblT800_RollGap_F1.Text = (t800_R355.F1 * 0.01).ToString("0.00;-0.00;0.00");
            this.lblT800_RollGap_F2.Text = (t800_R355.F2 * 0.01).ToString("0.00;-0.00;0.00");
            this.lblT800_RollGap_F3.Text = (t800_R355.F3 * 0.01).ToString("0.00;-0.00;0.00");
            this.lblT800_RollGap_F4.Text = (t800_R355.F4 * 0.01).ToString("0.00;-0.00;0.00");
            this.lblT800_RollGap_F5.Text = (t800_R355.F5 * 0.01).ToString("0.00;-0.00;0.00");
            this.lblT800_RollGap_F6.Text = (t800_R355.F6 * 0.01).ToString("0.00;-0.00;0.00");
            this.lblT800_RollGap_F7.Text = (t800_R355.F7 * 0.01).ToString("0.00;-0.00;0.00");

            // GAMEN 308 - 313
            double[] rollGapT800Gamen = new double[] { 7.05, 3.32, 3.88, 1.71, 0.76, 0.38 };
            this.lblT800_RollGap_Past_F1F2.Text = rollGapT800Gamen[0].ToString("0.0;-0.0;0.0");
            this.lblT800_RollGap_Past_F2F3.Text = rollGapT800Gamen[1].ToString("0.0;-0.0;0.0");
            this.lblT800_RollGap_Past_F3F4.Text = rollGapT800Gamen[2].ToString("0.0;-0.0;0.0");
            this.lblT800_RollGap_Past_F4F5.Text = rollGapT800Gamen[3].ToString("0.0;-0.0;0.0");
            this.lblT800_RollGap_Past_F5F6.Text = rollGapT800Gamen[4].ToString("0.0;-0.0;0.0");
            this.lblT800_RollGap_Past_F6F7.Text = rollGapT800Gamen[5].ToString("0.0;-0.0;0.0");
            
            // for T900 as same CoilNo
            //T900_I2_06 t900_R369 = new T900_I2_06(0, 0, 858, 392, 261, 155, 54, 15);
            this.lblT800_RollGap_Preliminary_F1F2.Text = (t900_R369.R1 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT800_RollGap_Preliminary_F2F3.Text = (t900_R369.R2 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT800_RollGap_Preliminary_F3F4.Text = (t900_R369.R3 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT800_RollGap_Preliminary_F4F5.Text = (t900_R369.R4 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT800_RollGap_Preliminary_F5F6.Text = (t900_R369.R5 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT800_RollGap_Preliminary_F6F7.Text = (t900_R369.R6 * 0.01).ToString("0.0;-0.0;0.0");
            
            T800_I2_06 t800_R331 = new T800_I2_06(0, 0, 0, 5, 4, 3, 1, 20);
            this.lblT800_RollGap_Setting_F1F2.Text = (t800_R331.R1 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT800_RollGap_Setting_F2F3.Text = (t800_R331.R2 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT800_RollGap_Setting_F3F4.Text = (t800_R331.R3 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT800_RollGap_Setting_F4F5.Text = (t800_R331.R4 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT800_RollGap_Setting_F5F6.Text = (t800_R331.R5 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT800_RollGap_Setting_F6F7.Text = (t800_R331.R6 * 0.01).ToString("0.0;-0.0;0.0");

            #endregion

            lblT800_Alert.Text = "先端ベンダー設定高め（F5、F7)";

            #region chtT800_Vendor
            T800_I2_07 t800_R425 = new T800_I2_07(0, 0, 149, 150, 149, 118, 133, 129, 83); // Blue bar
            // GAMEN 357 - 363
            int[] gamenVendor1 = new int[] { 187, 141, 189, 173, 173, 173, 89 }; // Yellow bar
            // GAMEN 364 - 370
            int[] gamenVendor2 = new int[] { 187, 141, 189, 173, 173, 173, 89 }; // red line
            // GAMEN 371 - 377
            int[] gamenVendor3 = new int[] { 177, 131, 179, 163, 163, 163, 79 }; // Pink line

            BarSeries brT800_Vendor1 = new BarSeries("ベンダー力");
            brT800_Vendor1.BorderColor = Color.White;
            brT800_Vendor1.BorderSize = 1;
            brT800_Vendor1.Color = Color.Blue;
            brT800_Vendor1.Size = 20;
            for (int i = 0; i < t800_R425.Rows.Length; i++)
            {
                brT800_Vendor1.Values.Add(t800_R425.Rows[i]);
            }
            chtT800_Vendor.ValueAxis1.BarSeries.Add(brT800_Vendor1);

            BarSeries brT800_Vendor2 = new BarSeries("ベンダー力_GAMEN");
            brT800_Vendor2.BorderColor = Color.White;
            brT800_Vendor2.BorderSize = 1;
            brT800_Vendor2.Color = Color.Yellow;
            brT800_Vendor2.Size = 20;
            for (int i = 0; i < gamenVendor1.Length; i++)
            {
                brT800_Vendor2.Values.Add(gamenVendor1[i]);
            }
            chtT800_Vendor.ValueAxis1.BarSeries.Add(brT800_Vendor2);

            LineSeries lnT800_Vendor3 = new LineSeries("ベンダー力上限_GAMEN");
            lnT800_Vendor3.Color = Color.Red;
            lnT800_Vendor3.Size = 3;
            lnT800_Vendor3.Marker.Style = MarkerStyle.THANG;
            lnT800_Vendor3.Marker.Size = 2;
            lnT800_Vendor3.Marker.BackColor = Color.Red;
            lnT800_Vendor3.Marker.BorderSize = 1;
            lnT800_Vendor3.Marker.ForeColor = Color.Red;
            for (int i = 0; i < gamenVendor2.Length; i++)
            {
                lnT800_Vendor3.Values.Add(gamenVendor2[i]);
            }
            chtT800_Vendor.ValueAxis1.LineSeries.Add(lnT800_Vendor3);

            LineSeries lnT800_Vendor4 = new LineSeries("ベンダー力下限_GAMEN");
            lnT800_Vendor4.Color = Color.Fuchsia;
            lnT800_Vendor4.Size = 3;
            lnT800_Vendor4.Marker.Style = MarkerStyle.THANG;
            lnT800_Vendor4.Marker.Size = 2;
            lnT800_Vendor4.Marker.BackColor = Color.Fuchsia;
            lnT800_Vendor4.Marker.BorderSize = 1;
            lnT800_Vendor4.Marker.ForeColor = Color.Fuchsia;
            for (int i = 0; i < gamenVendor3.Length; i++)
            {
                lnT800_Vendor4.Values.Add(gamenVendor3[i]);
            }

            chtT800_Vendor.ValueAxis1.LineSeries.Add(lnT800_Vendor4);

            this.lblT800_Vendor_F1.Text = t800_R425.F1.ToString();
            this.lblT800_Vendor_F2.Text = t800_R425.F2.ToString();
            this.lblT800_Vendor_F3.Text = t800_R425.F3.ToString();
            this.lblT800_Vendor_F4.Text = t800_R425.F4.ToString();
            this.lblT800_Vendor_F5.Text = t800_R425.F5.ToString();
            this.lblT800_Vendor_F6.Text = t800_R425.F6.ToString();
            this.lblT800_Vendor_F7.Text = t800_R425.F7.ToString();

            this.lblT800_VendorGamen_F1.Text = gamenVendor1[0].ToString();
            this.lblT800_VendorGamen_F2.Text = gamenVendor1[1].ToString();
            this.lblT800_VendorGamen_F3.Text = gamenVendor1[2].ToString();
            this.lblT800_VendorGamen_F4.Text = gamenVendor1[3].ToString();
            this.lblT800_VendorGamen_F5.Text = gamenVendor1[4].ToString();
            this.lblT800_VendorGamen_F6.Text = gamenVendor1[5].ToString();
            this.lblT800_VendorGamen_F7.Text = gamenVendor1[6].ToString();

            this.lblT800_Vendor_F1.Refresh();
            this.lblT800_Vendor_F2.Refresh();
            this.lblT800_Vendor_F3.Refresh();
            this.lblT800_Vendor_F4.Refresh();
            this.lblT800_Vendor_F5.Refresh();
            this.lblT800_Vendor_F6.Refresh();
            this.lblT800_Vendor_F7.Refresh();

            this.lblT800_VendorGamen_F1.Refresh();
            this.lblT800_VendorGamen_F2.Refresh();
            this.lblT800_VendorGamen_F3.Refresh();
            this.lblT800_VendorGamen_F4.Refresh();
            this.lblT800_VendorGamen_F5.Refresh();
            this.lblT800_VendorGamen_F6.Refresh();
            this.lblT800_VendorGamen_F7.Refresh();
            #endregion

            #region chtT800_CrownTotal
            int[] crownTotalT8001 = new int[] { 214, 237, 221, 179, 169, 148, 37 };
            int[] crownTotalT8002 = new int[] { 214, 237, 221, 179, 169, 148, 37 };

            BarSeries barCrownTotal1T800 = new BarSeries("Crown Total 1 T800");
            barCrownTotal1T800.BorderSize = 1;
            barCrownTotal1T800.BorderColor = Color.White;
            barCrownTotal1T800.Color = Color.Blue;
            barCrownTotal1T800.Size = 20;

            BarSeries barCrownTotal2T800 = new BarSeries("Crown Total 2 T800");
            barCrownTotal2T800.BorderSize = 1;
            barCrownTotal2T800.BorderColor = Color.White;
            barCrownTotal2T800.Color = Color.Yellow;
            barCrownTotal2T800.Size = 20;

            for (int i = 0; i < crownTotalT8001.Length; i++)
            {
                barCrownTotal1T800.Values.Add(crownTotalT8001[i]);
                barCrownTotal2T800.Values.Add(crownTotalT8002[i]);
            }

            chtT800_CrownTotal.ValueAxis1.BarSeries.Add(barCrownTotal1T800);
            chtT800_CrownTotal.ValueAxis1.BarSeries.Add(barCrownTotal2T800);
            #endregion


            #region chtRollShift01
            //GAMEN 392 - 421
            int[] gamen392 = new int[] { 0, 0, -20, -20, -20, -20, -21, -40, -60, -20 };
            int[] gamen402 = new int[] { -10, -10, -30, -40, -30, -30, -31, -40, -70, -30 };
            int[] gamen412 = new int[] { -10, -10, -30, -40, -30, -30, -31, -50, -70, -30 };

            LineSeries lineseries1 = new LineSeries("WR_F1");
            lineseries1.IsSolidLine = false;
            lineseries1.Marker.Style = MarkerStyle.THANG;
            lineseries1.Marker.Size = 20;
            lineseries1.Color = Color.Cyan;
            lineseries1.Marker.ForeColor = Color.Cyan;

            for (int i = 0; i < gamen392.Length; i++)
            {
                lineseries1.Values.Add(Double.MinValue);
                lineseries1.Values.Add(gamen392[i]);
            }
            lineseries1.Values.Add(Double.MinValue);

            chtRollShift01.ValueAxis1.LineSeries.Add(lineseries1);


            LineSeries lineseries2 = new LineSeries("WR_F2");
            lineseries2.IsSolidLine = false;
            lineseries2.Marker.Style = MarkerStyle.THANG;
            lineseries2.Marker.Size = 20;
            lineseries2.Color = Color.Orange;
            lineseries2.Marker.ForeColor = Color.Orange;

            for (int i = 0; i < gamen392.Length; i++)
            {
                lineseries2.Values.Add(Double.MinValue);
                lineseries2.Values.Add(gamen402[i]);
            }
            lineseries2.Values.Add(Double.MinValue);

            chtRollShift01.ValueAxis1.LineSeries.Add(lineseries2);

            LineSeries lineseries3 = new LineSeries("Test3");
            lineseries3.IsSolidLine = false;
            lineseries3.Marker.Style = MarkerStyle.THANG;
            lineseries3.Marker.Size = 20;
            lineseries3.Color = Color.Yellow;
            lineseries3.Marker.ForeColor = Color.Yellow;

            for (int i = 0; i < gamen392.Length; i++)
            {
                lineseries3.Values.Add(Double.MinValue);
                lineseries3.Values.Add(gamen412[i]);
            }
            lineseries3.Values.Add(Double.MinValue);

            chtRollShift01.ValueAxis1.LineSeries.Add(lineseries3);
            #endregion

            #region chtRollShift02
            // GAMEN 457 - 476
            int[] gamen457 = new int[] { 553, 601, 589, 557, 531, 484, 438, 393, 341, 295 };
            int[] gamen467 = new int[] { 36, -12, -32, -26, -47, -46, -45, -52, -46, -46 };

            LineSeries lineseries4 = new LineSeries("Test");
            lineseries4.IsSolidLine = false;
            lineseries4.Marker.Style = MarkerStyle.THANG;
            lineseries4.Marker.Size = 20;
            lineseries4.Color = Color.Cyan;
            lineseries4.Marker.ForeColor = Color.Cyan;

            for (int i = 0; i < gamen457.Length; i++)
            {
                lineseries4.Values.Add(Double.MinValue);
                lineseries4.Values.Add(gamen457[i]);
            }
            lineseries4.Values.Add(Double.MinValue);

            chtRollShift02.ValueAxis1.LineSeries.Add(lineseries4);

            LineSeries lineseries5 = new LineSeries("Test2");
            lineseries5.IsSolidLine = false;
            lineseries5.Marker.Style = MarkerStyle.THANG;
            lineseries5.Marker.Size = 20;
            lineseries5.Color = Color.Orange;
            lineseries5.Marker.ForeColor = Color.Orange;

            for (int i = 0; i < gamen467.Length; i++)
            {
                lineseries5.Values.Add(Double.MinValue);
                lineseries5.Values.Add(gamen467[i]);
            }
            lineseries5.Values.Add(Double.MinValue);

            chtRollShift02.ValueAxis1.LineSeries.Add(lineseries5);
            #endregion

            #region lblT800_WR_F1 - F7
            double[] gamen757 = new double[] { 5, 5, 3, 2, 2, 1, 1 };
            double[] gamen764 = new double[] { 10000, 10000, 6000, 4000, 4000, 2000, 2000 };

            lblT800_Time_F1.Text = gamen757[0].ToString() + "回";
            lblT800_Time_F2.Text = gamen757[1].ToString() + "回";
            lblT800_Time_F3.Text = gamen757[2].ToString() + "回";
            lblT800_Time_F4.Text = gamen757[3].ToString() + "回";
            lblT800_Time_F5.Text = gamen757[4].ToString() + "回";
            lblT800_Time_F6.Text = gamen757[5].ToString() + "回";
            lblT800_Time_F7.Text = gamen757[6].ToString() + "回";

            lblT800_WR_F1.Text = gamen764[0].ToString("#####0");
            lblT800_WR_F2.Text = gamen764[1].ToString("#####0");
            lblT800_WR_F3.Text = gamen764[2].ToString("#####0");
            lblT800_WR_F4.Text = gamen764[3].ToString("#####0");
            lblT800_WR_F5.Text = gamen764[4].ToString("#####0");
            lblT800_WR_F6.Text = gamen764[5].ToString("#####0");
            lblT800_WR_F7.Text = gamen764[6].ToString("#####0");
            #endregion
        }
        */
        #endregion

        private void FormFinishSupport1_V5_Load(object sender, EventArgs e)
        {
            PreloadAll();
        }

        private void ResetAll()
        {
            this.lblMaxF1.Text = "";
            this.lblMaxF2.Text = "";
            this.lblMaxF3.Text = "";
            this.lblMaxF4.Text = "";
            this.lblMaxF5.Text = "";
            this.lblMaxF6.Text = "";
            this.lblMaxF7.Text = "";

            this.lblMinF1.Text = "";
            this.lblMinF2.Text = "";
            this.lblMinF3.Text = "";
            this.lblMinF4.Text = "";
            this.lblMinF5.Text = "";
            this.lblMinF6.Text = "";
            this.lblMinF7.Text = "";

            this.lblT800_Alert.Text = "";
            this.lblT800_RBWidth.Text = "";
            this.lblT800_Strength.Text = "";
            this.lblT800_CoilNo.Text = "";
            this.lblT800_SteelName.Text = "";
            this.lblT800_Thick.Text = "";
            this.lblT800_Width.Text = "";

            this.lblT800_RollGap_F1.Text = "";
            this.lblT800_RollGap_F2.Text = "";
            this.lblT800_RollGap_F3.Text = "";
            this.lblT800_RollGap_F4.Text = "";
            this.lblT800_RollGap_F5.Text = "";
            this.lblT800_RollGap_F6.Text = "";
            this.lblT800_RollGap_F7.Text = "";

            this.lblT800_RollGap_Past_F1F2.Text = "";
            this.lblT800_RollGap_Past_F2F3.Text = "";
            this.lblT800_RollGap_Past_F3F4.Text = "";
            this.lblT800_RollGap_Past_F4F5.Text = "";
            this.lblT800_RollGap_Past_F5F6.Text = "";
            this.lblT800_RollGap_Past_F6F7.Text = "";

            this.lblT800_RollGap_Preliminary_F1F2.Text = "";
            this.lblT800_RollGap_Preliminary_F2F3.Text = "";
            this.lblT800_RollGap_Preliminary_F3F4.Text = "";
            this.lblT800_RollGap_Preliminary_F4F5.Text = "";
            this.lblT800_RollGap_Preliminary_F5F6.Text = "";
            this.lblT800_RollGap_Preliminary_F6F7.Text = "";

            this.lblT800_RollGap_Setting_F1F2.Text = "";
            this.lblT800_RollGap_Setting_F2F3.Text = "";
            this.lblT800_RollGap_Setting_F3F4.Text = "";
            this.lblT800_RollGap_Setting_F4F5.Text = "";
            this.lblT800_RollGap_Setting_F5F6.Text = "";
            this.lblT800_RollGap_Setting_F6F7.Text = "";

            this.lblT900_Alert.Text = "";
            this.lblT900_CoilNo.Text = "";
            this.lblT900_RBWidth.Text = "";
            this.lblT900_SteelName.Text = "";
            this.lblT900_Strength.Text = "";
            this.lblT900_Thick.Text = "";
            this.lblT900_Width.Text = "";

            this.lblT900_RollGap_F1.Text = "";
            this.lblT900_RollGap_F2.Text = "";
            this.lblT900_RollGap_F3.Text = "";
            this.lblT900_RollGap_F4.Text = "";
            this.lblT900_RollGap_F5.Text = "";
            this.lblT900_RollGap_F6.Text = "";
            this.lblT900_RollGap_F7.Text = "";

            this.lblT900_RollGapDiff_F1F2.Text = "";
            this.lblT900_RollGapDiff_F2F3.Text = "";
            this.lblT900_RollGapDiff_F3F4.Text = "";
            this.lblT900_RollGapDiff_F4F5.Text = "";
            this.lblT900_RollGapDiff_F5F6.Text = "";
            this.lblT900_RollGapDiff_F6F7.Text = "";

            this.lblT900_RollGapDiff_F1F2.Visible = false;
            this.lblT900_RollGapDiff_F2F3.Visible = false;
            this.lblT900_RollGapDiff_F3F4.Visible = false;
            this.lblT900_RollGapDiff_F4F5.Visible = false;
            this.lblT900_RollGapDiff_F5F6.Visible = false;
            this.lblT900_RollGapDiff_F6F7.Visible = false;

            this.lblT900_RollGap_Past_F1F2.Text = "";
            this.lblT900_RollGap_Past_F2F3.Text = "";
            this.lblT900_RollGap_Past_F3F4.Text = "";
            this.lblT900_RollGap_Past_F4F5.Text = "";
            this.lblT900_RollGap_Past_F5F6.Text = "";
            this.lblT900_RollGap_Past_F6F7.Text = "";

            this.lblT900_RollGap_Preliminary_F1F2.Text = "";
            this.lblT900_RollGap_Preliminary_F2F3.Text = "";
            this.lblT900_RollGap_Preliminary_F3F4.Text = "";
            this.lblT900_RollGap_Preliminary_F4F5.Text = "";
            this.lblT900_RollGap_Preliminary_F5F6.Text = "";
            this.lblT900_RollGap_Preliminary_F6F7.Text = "";
            // HSS5
            #region comment
            /*
            this.lblT800_Vendor_F1.Text = "";
            this.lblT800_Vendor_F2.Text = "";
            this.lblT800_Vendor_F3.Text = "";
            this.lblT800_Vendor_F4.Text = "";
            this.lblT800_Vendor_F5.Text = "";
            this.lblT800_Vendor_F6.Text = "";
            this.lblT800_Vendor_F7.Text = "";

            this.lblT800_VendorGamen_F1.Text = "";
            this.lblT800_VendorGamen_F2.Text = "";
            this.lblT800_VendorGamen_F3.Text = "";
            this.lblT800_VendorGamen_F4.Text = "";
            this.lblT800_VendorGamen_F5.Text = "";
            this.lblT800_VendorGamen_F6.Text = "";
            this.lblT800_VendorGamen_F7.Text = "";

            this.lblT800_Vendor_F1.Refresh();
            this.lblT800_Vendor_F2.Refresh();
            this.lblT800_Vendor_F3.Refresh();
            this.lblT800_Vendor_F4.Refresh();
            this.lblT800_Vendor_F5.Refresh();
            this.lblT800_Vendor_F6.Refresh();
            this.lblT800_Vendor_F7.Refresh();

            this.lblT800_VendorGamen_F1.Refresh();
            this.lblT800_VendorGamen_F2.Refresh();
            this.lblT800_VendorGamen_F3.Refresh();
            this.lblT800_VendorGamen_F4.Refresh();
            this.lblT800_VendorGamen_F5.Refresh();
            this.lblT800_VendorGamen_F6.Refresh();
            this.lblT800_VendorGamen_F7.Refresh();
            */
            #endregion

            this.lblMyRollGap_Gamen_F1F2.Text = "";
            this.lblMyRollGap_Gamen_F2F3.Text = "";
            this.lblMyRollGap_Gamen_F3F4.Text = "";
            this.lblMyRollGap_Gamen_F4F5.Text = "";
            this.lblMyRollGap_Gamen_F5F6.Text = "";
            this.lblMyRollGap_Gamen_F6F7.Text = "";

            this.lblMyRollGap_Past_Gamen_F1F2.Text = "";
            this.lblMyRollGap_Past_Gamen_F2F3.Text = "";
            this.lblMyRollGap_Past_Gamen_F3F4.Text = "";
            this.lblMyRollGap_Past_Gamen_F4F5.Text = "";
            this.lblMyRollGap_Past_Gamen_F5F6.Text = "";
            this.lblMyRollGap_Past_Gamen_F6F7.Text = "";
            // End HSS5

            this.pnlT1800_F1.BackColor = ROLL_PROFILE_BACKCOLOR_NOMAL;
            this.pnlT1800_F2.BackColor = ROLL_PROFILE_BACKCOLOR_NOMAL;
            this.pnlT1800_F3.BackColor = ROLL_PROFILE_BACKCOLOR_NOMAL;
            this.pnlT1800_F4.BackColor = ROLL_PROFILE_BACKCOLOR_NOMAL;
            this.pnlT1800_F5.BackColor = ROLL_PROFILE_BACKCOLOR_NOMAL;
            this.pnlT1800_F6.BackColor = ROLL_PROFILE_BACKCOLOR_NOMAL;
            this.pnlT1800_F7.BackColor = ROLL_PROFILE_BACKCOLOR_NOMAL;

            // HSS5
            //this.pnlT1800_F1.BackColor = ROLL_PROFILE_BACKCOLOR_HIGHLIGHT;
            //this.pnlT1800_F1.ForeColor = ROLL_PROFILE_FORCOLOR_HIGHLIGHT;
            // End HSS5

            // HSS5
            #region Vendor
            {
                lblT800VendorsMode_Manual_Pre.BackColor = Color.Black;
                lblT800VendorsMode_Auto_Pre.BackColor = Color.Black;
                lblT800VendorsMode_SemiAuto_Pre.BackColor = Color.Black;

                lblT800VendorsMode_Manual_Pre.ForeColor = Color.Lime;
                lblT800VendorsMode_Auto_Pre.ForeColor = Color.Lime;
                lblT800VendorsMode_SemiAuto_Pre.ForeColor = Color.Lime;

                lblT800Vendors_Pre_F1.Text = "";
                lblT800Vendors_Pre_F2.Text = "";
                lblT800Vendors_Pre_F3.Text = "";
                lblT800Vendors_Pre_F4.Text = "";
                lblT800Vendors_Pre_F5.Text = "";
                lblT800Vendors_Pre_F6.Text = "";
                lblT800Vendors_Pre_F7.Text = "";

                lblT800Crow_Directive_Pre.Text = "";
                lblT800Crow_Real_Preliminary_Pre.Text = "";

                lblT800VendorsMode_Manual.BackColor = Color.Black;
                lblT800VendorsMode_Auto.BackColor = Color.Black;
                lblT800VendorsMode_SemiAuto.BackColor = Color.Black;

                lblT800VendorsMode_Manual.ForeColor = Color.Lime;
                lblT800VendorsMode_Auto.ForeColor = Color.Lime;
                lblT800VendorsMode_SemiAuto.ForeColor = Color.Lime;

                lblT800Vendors_F1.Text = "";
                lblT800Vendors_F2.Text = "";
                lblT800Vendors_F3.Text = "";
                lblT800Vendors_F4.Text = "";
                lblT800Vendors_F5.Text = "";
                lblT800Vendors_F6.Text = "";
                lblT800Vendors_F7.Text = "";

                lblT800Crow_Directive.Text = "";
                lblT800Crow_Real_Preliminary.Text = "";

                lblPastPerformanceVendor_F1.Text = "";
                lblPastPerformanceVendor_F2.Text = "";
                lblPastPerformanceVendor_F3.Text = "";
                lblPastPerformanceVendor_F4.Text = "";
                lblPastPerformanceVendor_F5.Text = "";
                lblPastPerformanceVendor_F6.Text = "";
                lblPastPerformanceVendor_F7.Text = "";

                lblPastPerformanceCrown.Text = "";
                lblPastPerformancePredictions.Text = "";

                lblT800VendorThermal_F1.Text = "";
                lblT800VendorThermal_F2.Text = "";
                lblT800VendorThermal_F3.Text = "";
                lblT800VendorThermal_F4.Text = "";
                lblT800VendorThermal_F5.Text = "";
                lblT800VendorThermal_F6.Text = "";
                lblT800VendorThermal_F7.Text = "";
            }
            #endregion

            #region RBｵﾌｾﾝﾀ
            {
                lblGamenHCNO_1.Text = "";
                lblGamenHCNO_2.Text = "";
                lblGamenHCNO_3.Text = "";
                lblGamenHCNO_4.Text = "";
                lblGamenHCNO_5.Text = "";
                lblGamenHCNO_6.Text = "";
                lblGamenHCNO_7.Text = "";
                lblGamenHCNO_8.Text = "";
                lblGamenHCNO_9.Text = "";
                lblGamenHCNO_10.Text = "";

                lblGamen_OffCenter_T_1.Text = "";
                lblGamen_OffCenter_T_2.Text = "";
                lblGamen_OffCenter_T_3.Text = "";
                lblGamen_OffCenter_T_4.Text = "";
                lblGamen_OffCenter_T_5.Text = "";
                lblGamen_OffCenter_T_6.Text = "";
                lblGamen_OffCenter_T_7.Text = "";
                lblGamen_OffCenter_T_8.Text = "";
                lblGamen_OffCenter_T_9.Text = "";
                lblGamen_OffCenter_T_10.Text = "";

                lblGamen_OffCenter_B_1.Text = "";
                lblGamen_OffCenter_B_2.Text = "";
                lblGamen_OffCenter_B_3.Text = "";
                lblGamen_OffCenter_B_4.Text = "";
                lblGamen_OffCenter_B_5.Text = "";
                lblGamen_OffCenter_B_6.Text = "";
                lblGamen_OffCenter_B_7.Text = "";
                lblGamen_OffCenter_B_8.Text = "";
                lblGamen_OffCenter_B_9.Text = "";
                lblGamen_OffCenter_B_10.Text = "";
            }
            #endregion

            #region lblT800_WR_F1 - F7

            lblT800_Time_F1.Text = "";
            lblT800_Time_F2.Text = "";
            lblT800_Time_F3.Text = "";
            lblT800_Time_F4.Text = "";
            lblT800_Time_F5.Text = "";
            lblT800_Time_F6.Text = "";
            lblT800_Time_F7.Text = "";

            lblT800_WR_F1.Text = "";
            lblT800_WR_F2.Text = "";
            lblT800_WR_F3.Text = "";
            lblT800_WR_F4.Text = "";
            lblT800_WR_F5.Text = "";
            lblT800_WR_F6.Text = "";
            lblT800_WR_F7.Text = "";

            #endregion
            // End HSS5

            pnlT800_7F_StateChanged();
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
        }

        public void PreloadAll()
        {
            try
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
                // HSS5
                LoadData(DataPackages.Finished);
                // End HSS5
                LoadData(DataPackages.Result);


                lblT900_Alert.BackColor = Color.Black;
                if (_T900AlertType == 1)
                {
                    lblT900_Alert.ForeColor = Color.Red;
                }
                else if (_T900AlertType == 2)
                {
                    lblT900_Alert.ForeColor = Color.Lime;
                }
                else if (_T900AlertType == 3)
                {
                    lblT900_Alert.ForeColor = Color.Cyan;
                }
                
                lblT800_Alert.BackColor = Color.Black;
                if (_T800AlertType == 1)
                {
                    lblT800_Alert.ForeColor = Color.Red;
                }
                else if (_T800AlertType == 2)
                {
                    lblT800_Alert.ForeColor = Color.Lime;
                }
                else if (_T800AlertType == 3)
                {
                    lblT800_Alert.ForeColor = Color.Cyan;
                }

                _IsLoading = false;
            }
            catch (Exception ex)
            {
                log.Error("FormFinishSupport1_V5 loading error: " + ex.Message, ex);
                throw ex;
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

        protected void LoadAlert(int type, string message)
        {
            message = message != null ? message.Trim() : "";

            if (message.Length > 0)
            {
                switch (type)
                {
                    case 1:
                        lblT900_Alert.Text = message.Substring(1);
                        break;
                    case 2:
                        lblT800_Alert.Text = message.Substring(1);
                        break;
                    default:
                        break;
                }

                string messageTypeStr = message.Substring(0, 1);
                int msgType = (messageTypeStr == "１") ? 1 : ((messageTypeStr == "２") ? 2 : ((messageTypeStr == "３") ? 3 : 0));

                switch (type)
                {
                    case 1:
                        tmrAlert_T900.Enabled = false;
                        _T900AlertType = msgType;
                        break;
                    case 2:
                        tmrAlert_T800.Enabled = false;
                        _T800AlertType = msgType;
                        break;
                    default:
                        break;
                }

                if (_IsLoading)
                {
                    return;
                }

                switch (type)
                {
                    case 1:
                        _T900AlertCount = 0;
                        tmrAlert_T900_Tick(null, null);
                        tmrAlert_T900.Enabled = true;
                        break;
                    case 2:
                        _T800AlertCount = 0;
                        tmrAlert_T800_Tick(null, null);
                        tmrAlert_T800.Enabled = true;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (type)
                {
                    case 1:
                        tmrAlert_T900.Enabled = false;
                        lblT900_Alert.Text = "";
                        lblT900_Alert.BackColor = Color.Black;
                        lblT900_Alert.ForeColor = Color.Lime;
                        _T900AlertCount = 0;
                        break;
                    case 2:
                        tmrAlert_T800.Enabled = false;
                        lblT800_Alert.Text = "";
                        lblT800_Alert.BackColor = Color.Black;
                        lblT800_Alert.ForeColor = Color.Lime;
                        _T800AlertCount = 0;
                        break;
                    default:
                        break;
                }
            }
        }

        protected void FillData(T900 t900)
        {
            log.Debug("Begin FillData(T900), at: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));

            // clear alert
            LoadAlert(1, null);

            chtT900_RollGapDiff.ValueAxis1.BarSeries.Clear();
            chtT900_PathPattern.ValueAxis1.LineSeries.Clear();
            chtT900_PathPattern.ValueAxis1.TetragonCustomSeries.Clear();
            /*
            chtT900_Vendor.ValueAxis1.BarSeries.Clear();
            chtT900_Vendor.ValueAxis1.LineSeries.Clear();
            chtT900_CrownTotal.ValueAxis1.BarSeries.Clear();
            */
            lblT900_RollGapDiff_F1F2.Visible = false;
            lblT900_RollGapDiff_F2F3.Visible = false;
            lblT900_RollGapDiff_F3F4.Visible = false;
            lblT900_RollGapDiff_F4F5.Visible = false;
            lblT900_RollGapDiff_F5F6.Visible = false;
            lblT900_RollGapDiff_F6F7.Visible = false;


            HighLightT900();

            log.Debug("FillData(T900): load gamen, " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));

            Gamen gamenT900 = new Gamen(t900.ID, 1);
            double[] gamens = null;
            string[] gamensString = null;
            log.Debug("FillData(T900): gamen ID: " + gamenT900.ID.ToString());
            if (gamenT900.ID > 0)
            {
                gamens = gamenT900.GetValues();
                gamensString = gamenT900.GetValuesInString();
                if (gamens != null)
                {
                    log.Debug("FillData(T900): gamens length: " + gamens.Length.ToString());
                }
                else
                {
                    log.Debug("FillData(T900): gamens is null.");
                }

                if (gamensString != null)
                {
                    log.Debug("FillData(T900): gamensString length: " + gamensString.Length.ToString());
                }
                else
                {
                    log.Debug("FillData(T900): gamensString is null.");
                }
            }
            string alertMess = "";

            this.lblT900_CoilNo.Text = t900.R025;
            this.lblT900_RBWidth.Text = (t900.R163 * 0.01).ToString("0.00;-0.00;0.00");
            this.lblT900_Width.Text = (t900.R167 * 0.01).ToString("0.00;-0.00;0.00");
            this.lblT900_Thick.Text = t900.R165.ToString();
            this.lblT900_SteelName.Text = t900.R071;
            this.lblT900_Strength.Text = t900.R079.ToString();

            log.Debug("FillData(T900): RollGap, " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));

            #region RollGap
            T900_I2_07 t900_R393 = t900.R391;
            this.lblT900_RollGap_F1.Text = (t900_R393.F1 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT900_RollGap_F2.Text = (t900_R393.F2 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT900_RollGap_F3.Text = (t900_R393.F3 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT900_RollGap_F4.Text = (t900_R393.F4 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT900_RollGap_F5.Text = (t900_R393.F5 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT900_RollGap_F6.Text = (t900_R393.F6 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT900_RollGap_F7.Text = (t900_R393.F7 * 0.01).ToString("0.0;-0.0;0.0");

            if (gamens != null)
            {

                // GAMEN 238 - 243
                this.lblT900_RollGap_Past_F1F2.Text = gamens[237].ToString("0.0;-0.0;0.0");
                this.lblT900_RollGap_Past_F2F3.Text = gamens[238].ToString("0.0;-0.0;0.0");
                this.lblT900_RollGap_Past_F3F4.Text = gamens[239].ToString("0.0;-0.0;0.0");
                this.lblT900_RollGap_Past_F4F5.Text = gamens[240].ToString("0.0;-0.0;0.0");
                this.lblT900_RollGap_Past_F5F6.Text = gamens[241].ToString("0.0;-0.0;0.0");
                this.lblT900_RollGap_Past_F6F7.Text = gamens[242].ToString("0.0;-0.0;0.0");
                /*
                // GAMEN 20 - 25
                this.lblT900_RollGap_Past_F1F2.Text = gamens[20].ToString("0.0;-0.0;0.0");
                this.lblT900_RollGap_Past_F2F3.Text = gamens[10].ToString("0.0;-0.0;0.0");
                this.lblT900_RollGap_Past_F3F4.Text = gamens[22].ToString("0.0;-0.0;0.0");
                this.lblT900_RollGap_Past_F4F5.Text = gamens[23].ToString("0.0;-0.0;0.0");
                this.lblT900_RollGap_Past_F5F6.Text = gamens[24].ToString("0.0;-0.0;0.0");
                this.lblT900_RollGap_Past_F6F7.Text = gamens[25].ToString("0.0;-0.0;0.0");
                */
            }

            T900_I2_06 t900_R369 = t900.R367;
            this.lblT900_RollGap_Preliminary_F1F2.Text = (t900_R369.R1 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT900_RollGap_Preliminary_F2F3.Text = (t900_R369.R2 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT900_RollGap_Preliminary_F3F4.Text = (t900_R369.R3 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT900_RollGap_Preliminary_F4F5.Text = (t900_R369.R4 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT900_RollGap_Preliminary_F5F6.Text = (t900_R369.R5 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT900_RollGap_Preliminary_F6F7.Text = (t900_R369.R6 * 0.01).ToString("0.0;-0.0;0.0");

            T900_I2_06 t900_R381 = t900.R379;
            BarSeries barRollGapDiff = new BarSeries("Roll Gap Difference");
            barRollGapDiff.BorderSize = 2;
            barRollGapDiff.BorderColor = Color.White;
            barRollGapDiff.Color = Color.Blue;
            barRollGapDiff.Size = 40;

            barRollGapDiff.Values.Add(t900_R381.R1 * 0.01);
            barRollGapDiff.Values.Add(t900_R381.R2 * 0.01);
            barRollGapDiff.Values.Add(t900_R381.R3 * 0.01);
            barRollGapDiff.Values.Add(t900_R381.R4 * 0.01);
            barRollGapDiff.Values.Add(t900_R381.R5 * 0.01);
            barRollGapDiff.Values.Add(t900_R381.R6 * 0.01);

            chtT900_RollGapDiff.ValueAxis1.BarSeries.Add(barRollGapDiff);

            lblT900_RollGapDiff_F1F2.Text = (t900_R381.R1 * 0.01).ToString("0.0;-0.0;0.0");
            lblT900_RollGapDiff_F2F3.Text = (t900_R381.R2 * 0.01).ToString("0.0;-0.0;0.0");
            lblT900_RollGapDiff_F3F4.Text = (t900_R381.R3 * 0.01).ToString("0.0;-0.0;0.0");
            lblT900_RollGapDiff_F4F5.Text = (t900_R381.R4 * 0.01).ToString("0.0;-0.0;0.0");
            lblT900_RollGapDiff_F5F6.Text = (t900_R381.R5 * 0.01).ToString("0.0;-0.0;0.0");
            lblT900_RollGapDiff_F6F7.Text = (t900_R381.R6 * 0.01).ToString("0.0;-0.0;0.0");

            lblT900_RollGapDiff_F1F2.Top = t900_R381.R1 > 0 ? LBLT900_ROLLGAP_DIFF_POSITIVE_TOP : LBLT900_ROLLGAP_DIFF_NEGATIVE_TOP;
            lblT900_RollGapDiff_F2F3.Top = t900_R381.R2 > 0 ? LBLT900_ROLLGAP_DIFF_POSITIVE_TOP : LBLT900_ROLLGAP_DIFF_NEGATIVE_TOP;
            lblT900_RollGapDiff_F3F4.Top = t900_R381.R3 > 0 ? LBLT900_ROLLGAP_DIFF_POSITIVE_TOP : LBLT900_ROLLGAP_DIFF_NEGATIVE_TOP;
            lblT900_RollGapDiff_F4F5.Top = t900_R381.R4 > 0 ? LBLT900_ROLLGAP_DIFF_POSITIVE_TOP : LBLT900_ROLLGAP_DIFF_NEGATIVE_TOP;
            lblT900_RollGapDiff_F5F6.Top = t900_R381.R5 > 0 ? LBLT900_ROLLGAP_DIFF_POSITIVE_TOP : LBLT900_ROLLGAP_DIFF_NEGATIVE_TOP;
            lblT900_RollGapDiff_F6F7.Top = t900_R381.R6 > 0 ? LBLT900_ROLLGAP_DIFF_POSITIVE_TOP : LBLT900_ROLLGAP_DIFF_NEGATIVE_TOP;

            lblT900_RollGapDiff_F1F2.Visible = true;
            lblT900_RollGapDiff_F2F3.Visible = true;
            lblT900_RollGapDiff_F3F4.Visible = true;
            lblT900_RollGapDiff_F4F5.Visible = true;
            lblT900_RollGapDiff_F5F6.Visible = true;
            lblT900_RollGapDiff_F6F7.Visible = true;
            #endregion

            log.Debug("FillData(T900): Alert, " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));

            // alert
            if (gamens != null)
            {
                // GAMEN 244
                //lblT900_Alert.Text = "";
                alertMess = gamensString[243];
                LoadAlert(1, alertMess);
            }

            log.Debug("FillData(T900): Path pattern, " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));

            #region chtT900_PathPattern

            T900_I2_07 t900_R171 = t900.R169;
            T900_I2_07 t900_R229 = t900.R227;

            int[] gamen_PathPatternX = new int[] { MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE };
            int[] gamen_PathPatternY = new int[] { MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE };

            int[] gamen_PathPatternXMin = new int[] { MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE };
            int[] gamen_PathPatternXMax = new int[] { MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE };
            int[] gamen_PathPatternYMin = new int[] { MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE };
            int[] gamen_PathPatternYMax = new int[] { MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE };

            log.Debug("FillData(T900): Path pattern: if ");

            if (gamens != null && gamens.Length > 300)
            {
                log.Debug("FillData(T900): Path pattern: for ");
                for (int i = 0; i < 7; i++)
                {
                    log.Debug("FillData(T900): Path pattern: for i = " + i.ToString());

                    gamen_PathPatternX[i] = Convert.ToInt32(gamens[244 + i] * 100);
                    gamen_PathPatternY[i] = Convert.ToInt32(gamens[251 + i]);

                    gamen_PathPatternXMin[i] = Convert.ToInt32(gamens[258 + i] * 100);
                    gamen_PathPatternXMax[i] = Convert.ToInt32(gamens[272 + i] * 100);
                    gamen_PathPatternYMin[i] = Convert.ToInt32(gamens[265 + i]);
                    gamen_PathPatternYMax[i] = Convert.ToInt32(gamens[279 + i]);
                }
            }
            int minX = Int32.MaxValue;
            int maxX = Int32.MinValue;
            int minY = Int32.MaxValue;
            int maxY = Int32.MinValue;

            LineSeries lnPathPattern = new LineSeries("パスパターン 当材");
            lnPathPattern.Size = 3;
            lnPathPattern.Marker.Style = MarkerStyle.VUONG;
            lnPathPattern.Marker.Size = 12;
            lnPathPattern.Color = lblT900_PathPattern_Curr.ForeColor;
            lnPathPattern.Marker.ForeColor = lblT900_PathPattern_Curr.ForeColor;
            lnPathPattern.Marker.BackColor = lblT900_PathPattern_Curr.ForeColor;

            LineSeries lnGamenPathPattern = new LineSeries("パスパターン 前材");
            lnGamenPathPattern.Size = 3;
            lnGamenPathPattern.Marker.Style = MarkerStyle.TAM_GIAC;
            lnGamenPathPattern.Marker.Size = 12;
            lnGamenPathPattern.Color = lblT900_PathPattern_Pre.ForeColor;
            lnGamenPathPattern.Marker.ForeColor = lblT900_PathPattern_Pre.ForeColor;
            lnGamenPathPattern.Marker.BackColor = lblT900_PathPattern_Pre.ForeColor;

            TetragonCustomSeries lnAreaPathPattern = new TetragonCustomSeries("パスパターン 上限");
            //lnAreaPathPattern.Color = Color.LightYellow;
            lnAreaPathPattern.Color = Color.SkyBlue;
            lnAreaPathPattern.TransposeX = true;

            log.Debug("FillData(T900): Path pattern: for i < t900_R171.Rows.Length ");

            for (int i = 0; i < t900_R171.Rows.Length; i++)
            {
                log.Debug("FillData(T900): Path pattern: for i = " + i.ToString());

                minX = Math.Min(minX, t900_R171.Rows[i]);
                maxX = Math.Max(maxX, t900_R171.Rows[i]);

                minY = Math.Min(minY, t900_R229.Rows[i]);
                maxY = Math.Max(maxY, t900_R229.Rows[i]);

                minX = Math.Min(minX, gamen_PathPatternX[i] == MIN_VALUE ? minX : gamen_PathPatternX[i]);
                maxX = Math.Max(maxX, gamen_PathPatternX[i] == MIN_VALUE ? maxX : gamen_PathPatternX[i]);

                minY = Math.Min(minY, gamen_PathPatternY[i] == MIN_VALUE ? minY : gamen_PathPatternY[i]);
                maxY = Math.Max(maxY, gamen_PathPatternY[i] == MIN_VALUE ? maxY : gamen_PathPatternY[i]);

                minX = Math.Min(minX, gamen_PathPatternXMin[i] == MIN_VALUE ? minX : gamen_PathPatternXMin[i]);
                maxX = Math.Max(maxX, gamen_PathPatternXMin[i] == MIN_VALUE ? maxX : gamen_PathPatternXMin[i]);

                minY = Math.Min(minY, gamen_PathPatternYMin[i] == MIN_VALUE ? minY : gamen_PathPatternYMin[i]);
                maxY = Math.Max(maxY, gamen_PathPatternYMin[i] == MIN_VALUE ? maxY : gamen_PathPatternYMin[i]);

                minX = Math.Min(minX, gamen_PathPatternXMax[i] == MIN_VALUE ? minX : gamen_PathPatternXMax[i]);
                maxX = Math.Max(maxX, gamen_PathPatternXMax[i] == MIN_VALUE ? maxX : gamen_PathPatternXMax[i]);

                minY = Math.Min(minY, gamen_PathPatternYMax[i] == MIN_VALUE ? minY : gamen_PathPatternYMax[i]);
                maxY = Math.Max(maxY, gamen_PathPatternYMax[i] == MIN_VALUE ? maxY : gamen_PathPatternYMax[i]);
            }

            log.Debug("FillData(T900): Path pattern: Min Max calculate ");

            minX = (minX / 500) * 500 - (minX % 500 > 0 ? 0 : 500);
            maxX = (maxX / 500) * 500 + (maxX % 500 > 0 ? 500 : 0);

            minY = (minY / 1000) * 1000 - (minY % 1000 > 0 ? 0 : 1000);
            maxY = (maxY / 1000) * 1000 + (maxY % 1000 > 0 ? 1000 : 0);

            chtT900_PathPattern.Min1 = minY;
            chtT900_PathPattern.Max1 = maxY;
            chtT900_PathPattern.Ranger1 = (maxY - minY) > 2000 ? 1000 : 500;

            log.Debug("FillData(T900): Path pattern: chtT900_PathPattern ");

            // vi category luon bat dau tu 0, nen set minX = 0
            minX = 0;

            chtT900_PathPattern.Category = new string[maxX - minX + 1];
            for (int i = 0; i < chtT900_PathPattern.Category.Length; i++)
            {
                chtT900_PathPattern.Category[i] = ((chtT900_PathPattern.Category.Length - i - 1) / 100).ToString();
            }
            chtT900_PathPattern.TickMarkStep = 500;

            log.Debug("FillData(T900): Path pattern: lnPathPattern, lnGamenPathPattern min value ");

            for (int i = 0; i < chtT900_PathPattern.Category.Length; i++)
            {
                lnPathPattern.Values.Add(Double.MinValue);
                lnGamenPathPattern.Values.Add(Double.MinValue);
            }

            log.Debug("FillData(T900): Path pattern: lnPathPattern, lnGamenPathPattern ");

            for (int i = 0; i < t900_R229.Rows.Length; i++)
            {
                //lnPathPattern.Values[chtT900_PathPattern.Category.Length - 1 - (int)(t900_R171.Rows[i])] = t900_R229.Rows[i];
                // F4 - F7: = 0.8 * data
                if (chtT900_PathPattern.Category.Length - 1 - (int)(t900_R171.Rows[i]) < 0)
                {
                    lnPathPattern.Values[0] = t900_R229.Rows[i];// *(i > 2 ? 0.8 : 1);
                }
                else if (lnPathPattern.Values.Count > chtT900_PathPattern.Category.Length - 1 - t900_R171.Rows[i])
                {
                    int valueX = chtT900_PathPattern.Category.Length - 1 - (int)(t900_R171.Rows[i]);
                    double valueY = t900_R229.Rows[i];// *(i > 2 ? 0.8 : 1);

                    while (valueX < chtT900_PathPattern.Category.Length && lnPathPattern.Values[valueX] != Double.MinValue && lnPathPattern.Values[valueX] != valueY)
                    {
                        valueX++;
                    }

                    lnPathPattern.Values[valueX] = valueY;
                }
                else
                {
                    lnPathPattern.Values[lnPathPattern.Values.Count - 1] = t900_R229.Rows[i];// *(i > 2 ? 0.8 : 1);
                }
                if (chtT900_PathPattern.Category.Length - 1 - (int)(gamen_PathPatternX[i]) < 0)
                {
                    lnGamenPathPattern.Values[0] = gamen_PathPatternY[i];
                }
                else if (lnGamenPathPattern.Values.Count > chtT900_PathPattern.Category.Length - 1 - gamen_PathPatternX[i])
                {
                    int valueX = chtT900_PathPattern.Category.Length - 1 - (int)(gamen_PathPatternX[i]);
                    while (valueX < chtT900_PathPattern.Category.Length && lnGamenPathPattern.Values[valueX] != Double.MinValue && lnGamenPathPattern.Values[valueX] != gamen_PathPatternY[i])
                    {
                        valueX++;
                    }

                    //lnGamenPathPattern.Values[chtT900_PathPattern.Category.Length - 1 - (int)(gamen_PathPatternX[i])] = gamen_PathPatternY[i];
                    lnGamenPathPattern.Values[valueX] = gamen_PathPatternY[i];
                }
                else
                {
                    lnGamenPathPattern.Values[lnGamenPathPattern.Values.Count - 1] = gamen_PathPatternY[i];
                }
            }

            log.Debug("FillData(T900): Path pattern: lnAreaPathPattern ");

            lnAreaPathPattern.MinX = minX;
            lnAreaPathPattern.MaxX = maxX;
            for (int i = 0; i < gamen_PathPatternXMax.Length; i++)
            {
                lnAreaPathPattern.Values.Add(new LineF(new PointF(gamen_PathPatternXMin[i], gamen_PathPatternYMin[i]), new PointF(gamen_PathPatternXMax[i], gamen_PathPatternYMax[i])));
            }

            chtT900_PathPattern.ValueAxis1.LineSeries.Add(lnGamenPathPattern);
            chtT900_PathPattern.ValueAxis1.LineSeries.Add(lnPathPattern);
            chtT900_PathPattern.ValueAxis1.TetragonCustomSeries.Add(lnAreaPathPattern);
            #endregion

            #region HSS5 comment
            //log.Debug("FillData(T900): vendor, " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));

            /*
            #region chtT900_Vendor
            // GAMEN 287 - 293
            int[] vendorT900 = new int[] { MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE };

            if (gamens != null)
            {
                for (int i = 0; i < 7; i++)
                {
                    vendorT900[i] = Convert.ToInt32(gamens[286 + i]);
                }
            }

            BarSeries barVendorT900 = new BarSeries("Vendor T900");
            barVendorT900.BorderSize = 2;
            barVendorT900.BorderColor = Color.White;
            barVendorT900.Color = lblT900_PathPattern_Pre.ForeColor;
            barVendorT900.Size = 40;

            for (int i = 0; i < vendorT900.Length; i++)
            {
                barVendorT900.Values.Add(vendorT900[i]);
            }

            chtT900_Vendor.ValueAxis1.BarSeries.Add(barVendorT900);
            #endregion

            log.Debug("FillData(T900): Crom Total, " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));

            #region chtT900_CrownTotal
            // GAMEN 294 - 300
            // GAMEN 301 - 307
            int[] crownTotalT9001 = new int[] { MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE };
            int[] crownTotalT9002 = new int[] { MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE };

            if (gamens != null)
            {
                for (int i = 0; i < 7; i++)
                {
                    crownTotalT9001[i] = Convert.ToInt32(gamens[293 + i]);
                    crownTotalT9002[i] = Convert.ToInt32(gamens[300 + i]);
                }
            }

            BarSeries barCrownTotal1T900 = new BarSeries("Crown Total 当材 T900");
            barCrownTotal1T900.BorderSize = 1;
            barCrownTotal1T900.BorderColor = Color.White;
            barCrownTotal1T900.Color = lblT900_PathPattern_Curr.ForeColor;
            barCrownTotal1T900.Size = 20;

            BarSeries barCrownTotal2T900 = new BarSeries("Crown Total 過去実績 T900");
            barCrownTotal2T900.BorderSize = 1;
            barCrownTotal2T900.BorderColor = Color.White;
            barCrownTotal2T900.Color = lblT900_PathPattern_Pre.ForeColor;
            barCrownTotal2T900.Size = 20;

            for (int i = 0; i < crownTotalT9001.Length; i++)
            {
                barCrownTotal1T900.Values.Add(crownTotalT9001[i]);
                barCrownTotal2T900.Values.Add(crownTotalT9002[i]);
            }

            chtT900_CrownTotal.ValueAxis1.BarSeries.Add(barCrownTotal2T900);
            chtT900_CrownTotal.ValueAxis1.BarSeries.Add(barCrownTotal1T900);
            #endregion
            */
            #endregion

            #region HSS5 add
            {
                if (gamenT900.ID > 0)
                {
                    log.Debug("FillData(T900): FillGamen_V5, " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                    FillGamen_V5(gamenT900);
                }
            }
            #endregion

            log.Debug("FillData(T900): End, " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));

            lblT900_RollGap_F1.Refresh();
            lblT900_RollGap_F2.Refresh();
            lblT900_RollGap_F3.Refresh();
            lblT900_RollGap_F4.Refresh();
            lblT900_RollGap_F5.Refresh();
            lblT900_RollGap_F6.Refresh();
            lblT900_RollGap_F7.Refresh();
        }

        protected void FillData(T800 t800)
        {
            log.Debug("Begin FillData(T800), at: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));

            // clear alert
            LoadAlert(2, null);

            //chtT800_PathPattern.ValueAxis1.LineSeries.Clear();
            //chtT800_PathPattern.ValueAxis1.TetragonCustomSeries.Clear();
            /*
            chtT800_Vendor.ValueAxis1.BarSeries.Clear();
            chtT800_Vendor.ValueAxis1.LineSeries.Clear();
            chtT800_CrownTotal.ValueAxis1.BarSeries.Clear();
            */
            chtRollShift01.ValueAxis1.LineSeries.Clear();
            chtRollShift02.ValueAxis1.LineSeries.Clear();
            chtRollShift02.ValueAxis2.LineSeries.Clear();

            HighLightT800();

            log.Debug("FillData(T800): load T900, " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
            T900 t900 = T900.FromCoilNo(t800.R025);

            log.Debug("FillData(T800): load gamen, " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
            Gamen gamenT800 = new Gamen(t800.ID, 2);
            double[] gamens = null;
            string[] gamensString = null;

            log.Debug("FillData(T800): gamen ID: " + gamenT800.ID.ToString());

            if (gamenT800.ID > 0)
            {
                gamens = gamenT800.GetValues();
                gamensString = gamenT800.GetValuesInString();


                if (gamens != null)
                {
                    log.Debug("FillData(T800): gamens length: " + gamens.Length.ToString());
                }
                else
                {
                    log.Debug("FillData(T800): gamens is null.");
                }

                if (gamensString != null)
                {
                    log.Debug("FillData(T800): gamensString length: " + gamensString.Length.ToString());
                }
                else
                {
                    log.Debug("FillData(T800): gamensString is null.");
                }
            }

            string alertMess = "";

            this.lblT800_CoilNo.Text = t800.R025;
            this.lblT800_RBWidth.Text = (t800.R115 * 0.01).ToString("0.00;-0.00;0.00");
            this.lblT800_Width.Text = (t800.R119 * 0.01).ToString("0.00;-0.00;0.00");
            this.lblT800_Thick.Text = t800.R117.ToString();
            this.lblT800_SteelName.Text = t800.R073;
            this.lblT800_Strength.Text = t800.R081.ToString();

            log.Debug("FillData(T800): RollGap, " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));

            #region Roll Gap
            T800_I2_07 t800_R355 = t800.R343;
            this.lblT800_RollGap_F1.Text = (t800_R355.F1 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT800_RollGap_F2.Text = (t800_R355.F2 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT800_RollGap_F3.Text = (t800_R355.F3 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT800_RollGap_F4.Text = (t800_R355.F4 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT800_RollGap_F5.Text = (t800_R355.F5 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT800_RollGap_F6.Text = (t800_R355.F6 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT800_RollGap_F7.Text = (t800_R355.F7 * 0.01).ToString("0.0;-0.0;0.0");

            if (gamens != null)
            {
                // GAMEN 308 - 313

                this.lblT800_RollGap_Past_F1F2.Text = gamens[307].ToString("0.0;-0.0;0.0");
                this.lblT800_RollGap_Past_F2F3.Text = gamens[308].ToString("0.0;-0.0;0.0");
                this.lblT800_RollGap_Past_F3F4.Text = gamens[309].ToString("0.0;-0.0;0.0");
                this.lblT800_RollGap_Past_F4F5.Text = gamens[310].ToString("0.0;-0.0;0.0");
                this.lblT800_RollGap_Past_F5F6.Text = gamens[311].ToString("0.0;-0.0;0.0");
                this.lblT800_RollGap_Past_F6F7.Text = gamens[312].ToString("0.0;-0.0;0.0");
                /*
                // GAMEN 95 - 100
                this.lblT800_RollGap_Past_F1F2.Text = gamens[95].ToString("0.0;-0.0;0.0");
                this.lblT800_RollGap_Past_F2F3.Text = gamens[96].ToString("0.0;-0.0;0.0");
                this.lblT800_RollGap_Past_F3F4.Text = gamens[97].ToString("0.0;-0.0;0.0");
                this.lblT800_RollGap_Past_F4F5.Text = gamens[98].ToString("0.0;-0.0;0.0");
                this.lblT800_RollGap_Past_F5F6.Text = gamens[99].ToString("0.0;-0.0;0.0");
                this.lblT800_RollGap_Past_F6F7.Text = gamens[100].ToString("0.0;-0.0;0.0");
                 * */
            }

            // for T900 as same CoilNo
            if (t900 != null)
            {
                T900_I2_06 t900_R369 = t900.R367;
                this.lblT800_RollGap_Preliminary_F1F2.Text = (t900_R369.R1 * 0.01).ToString("0.0;-0.0;0.0");
                this.lblT800_RollGap_Preliminary_F2F3.Text = (t900_R369.R2 * 0.01).ToString("0.0;-0.0;0.0");
                this.lblT800_RollGap_Preliminary_F3F4.Text = (t900_R369.R3 * 0.01).ToString("0.0;-0.0;0.0");
                this.lblT800_RollGap_Preliminary_F4F5.Text = (t900_R369.R4 * 0.01).ToString("0.0;-0.0;0.0");
                this.lblT800_RollGap_Preliminary_F5F6.Text = (t900_R369.R5 * 0.01).ToString("0.0;-0.0;0.0");
                this.lblT800_RollGap_Preliminary_F6F7.Text = (t900_R369.R6 * 0.01).ToString("0.0;-0.0;0.0");
            }

            T800_I2_06 t800_R331 = t800.R319;
            this.lblT800_RollGap_Setting_F1F2.Text = (t800_R331.R1 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT800_RollGap_Setting_F2F3.Text = (t800_R331.R2 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT800_RollGap_Setting_F3F4.Text = (t800_R331.R3 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT800_RollGap_Setting_F4F5.Text = (t800_R331.R4 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT800_RollGap_Setting_F5F6.Text = (t800_R331.R5 * 0.01).ToString("0.0;-0.0;0.0");
            this.lblT800_RollGap_Setting_F6F7.Text = (t800_R331.R6 * 0.01).ToString("0.0;-0.0;0.0");

            #endregion

            log.Debug("FillData(T800): Alert, " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));

            if (gamens != null)
            {
                // GAMEN 314
                //lblT800_Alert.Text = "";
                alertMess = gamensString[313];
                LoadAlert(2, alertMess);
            }

            // HSS5
            //log.Debug("FillData(T800): Path pattern, " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));

            #region chtT800_PathPattern
            /*
            
            T800_I2_07 t800_R133 = t800.R121;
            T800_I2_07 t800_R191 = t800.R179;

            int[] gamen_PathPatternX = new int[] { MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE };
            int[] gamen_PathPatternY = new int[] { MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE };

            int[] gamen_PathPatternXMin = new int[] { MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE };
            int[] gamen_PathPatternXMax = new int[] { MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE };
            int[] gamen_PathPatternYMin = new int[] { MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE };
            int[] gamen_PathPatternYMax = new int[] { MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE };

            log.Debug("FillData(T800): Path pattern: if ");
            if (gamens != null && gamens.Length > 360)
            {
                for (int i = 0; i < 7; i++)
                {
                    gamen_PathPatternX[i] = Convert.ToInt32(gamens[314 + i] * 100);
                    gamen_PathPatternY[i] = Convert.ToInt32(gamens[321 + i]);

                    gamen_PathPatternXMin[i] = Convert.ToInt32(gamens[328 + i] * 100);
                    gamen_PathPatternXMax[i] = Convert.ToInt32(gamens[342 + i] * 100);
                    gamen_PathPatternYMin[i] = Convert.ToInt32(gamens[335 + i]);
                    gamen_PathPatternYMax[i] = Convert.ToInt32(gamens[349 + i]);
                }
            }

            int minX = Int32.MaxValue;
            int maxX = Int32.MinValue;
            int minY = Int32.MaxValue;
            int maxY = Int32.MinValue;

            LineSeries lnPathPattern = new LineSeries("パスパターン 当材");
            lnPathPattern.Size = 3;
            lnPathPattern.Marker.Style = MarkerStyle.TAM_GIAC;
            lnPathPattern.Marker.Size = 12;
            lnPathPattern.Color = lblT800_PathPattern_Curr.ForeColor;
            lnPathPattern.Marker.ForeColor = lblT800_PathPattern_Curr.ForeColor;
            lnPathPattern.Marker.BackColor = lblT800_PathPattern_Curr.ForeColor;

            LineSeries lnGamenPathPattern = new LineSeries("パスパターン 前材");
            lnGamenPathPattern.Size = 3;
            lnGamenPathPattern.Marker.Style = MarkerStyle.VUONG;
            lnGamenPathPattern.Marker.Size = 12;
            lnGamenPathPattern.Color = lblT800_PathPattern_Pre.ForeColor;
            lnGamenPathPattern.Marker.ForeColor = lblT800_PathPattern_Pre.ForeColor;
            lnGamenPathPattern.Marker.BackColor = lblT800_PathPattern_Pre.ForeColor;

            TetragonCustomSeries lnAreaPathPattern = new TetragonCustomSeries("パスパターン 上限");
            //lnAreaPathPattern.Color = Color.LightYellow;
            lnAreaPathPattern.Color = Color.SkyBlue;
            lnAreaPathPattern.TransposeX = true;

            log.Debug("FillData(T800): Path pattern: for i < t800_R133.Rows.Length ");

            for (int i = 0; i < t800_R133.Rows.Length; i++)
            {
                //log.Debug("FillData(T800): Path pattern: for i = " + i.ToString());

                minX = Math.Min(minX, t800_R133.Rows[i]);
                maxX = Math.Max(maxX, t800_R133.Rows[i]);

                minY = Math.Min(minY, t800_R191.Rows[i]);
                maxY = Math.Max(maxY, t800_R191.Rows[i]);

                minX = Math.Min(minX, gamen_PathPatternX[i]);
                maxX = Math.Max(maxX, gamen_PathPatternX[i]);

                minY = Math.Min(minY, gamen_PathPatternY[i]);
                maxY = Math.Max(maxY, gamen_PathPatternY[i]);

                minX = Math.Min(minX, gamen_PathPatternXMin[i]);
                maxX = Math.Max(maxX, gamen_PathPatternXMin[i]);

                minY = Math.Min(minY, gamen_PathPatternYMin[i]);
                maxY = Math.Max(maxY, gamen_PathPatternYMin[i]);

                minX = Math.Min(minX, gamen_PathPatternXMax[i]);
                maxX = Math.Max(maxX, gamen_PathPatternXMax[i]);

                minY = Math.Min(minY, gamen_PathPatternYMax[i]);
                maxY = Math.Max(maxY, gamen_PathPatternYMax[i]);
            }

            //log.Debug(String.Format("Before cal: min({0}, {1}), max ({2}, {3})", minX, minY, maxX, maxY));
            log.Debug("FillData(T800): Path pattern: Min Max calculate ");

            minX = (minX / 500) * 500 - (minX % 500 > 0 ? 0 : 500);
            maxX = (maxX / 500) * 500 + (maxX % 500 > 0 ? 500 : 0);

            minY = (minY / 1000) * 1000 - (minY % 1000 > 0 ? 0 : 1000);
            maxY = (maxY / 1000) * 1000 + (maxY % 1000 > 0 ? 1000 : 0);

            chtT800_PathPattern.Min1 = minY;
            chtT800_PathPattern.Max1 = maxY;
            chtT800_PathPattern.Ranger1 = (maxY - minY) > 2000 ? 1000 : 500;

            log.Debug("FillData(T800): Path pattern: chtT800_PathPattern ");

            chtT800_PathPattern.Category = new string[maxX - minX + 1];
            for (int i = 0; i < chtT800_PathPattern.Category.Length; i++)
            {
                chtT800_PathPattern.Category[i] = ((chtT800_PathPattern.Category.Length - i - 1) / 100).ToString();
            }

            chtT800_PathPattern.TickMarkStep = 500;

            log.Debug("FillData(T800): Path pattern: lnPathPattern, lnGamenPathPattern min value ");

            for (int i = 0; i < chtT800_PathPattern.Category.Length; i++)
            {
                lnPathPattern.Values.Add(Double.MinValue);
                lnGamenPathPattern.Values.Add(Double.MinValue);
            }

            log.Debug("FillData(T800): Path pattern: lnPathPattern, lnGamenPathPattern ");

            for (int i = 0; i < t800_R191.Rows.Length; i++)
            {
                if (chtT800_PathPattern.Category.Length - 1 - (int)(t800_R133.Rows[i]) < 0) 
                {
                    lnPathPattern.Values[0] = t800_R191.Rows[i] * (i > 2 ? 0.8 : 1);
                }
                else if (lnPathPattern.Values.Count > chtT800_PathPattern.Category.Length - 1 - t800_R133.Rows[i])
                {
                    lnPathPattern.Values[chtT800_PathPattern.Category.Length - 1 - (int)(t800_R133.Rows[i])] = t800_R191.Rows[i] * (i > 2 ? 0.8 : 1);
                }
                else
                {
                    lnPathPattern.Values[lnPathPattern.Values.Count - 1] = t800_R191.Rows[i] * (i > 2 ? 0.8 : 1);
                }

                if (chtT800_PathPattern.Category.Length - 1 - (int)(gamen_PathPatternX[i]) < 0)
                {
                    lnGamenPathPattern.Values[0] = gamen_PathPatternY[i];
                }
                else if (lnGamenPathPattern.Values.Count > chtT800_PathPattern.Category.Length - 1 - gamen_PathPatternX[i])
                {
                    lnGamenPathPattern.Values[chtT800_PathPattern.Category.Length - 1 - (int)(gamen_PathPatternX[i])] = gamen_PathPatternY[i];
                }
                else
                {
                    lnGamenPathPattern.Values[lnGamenPathPattern.Values.Count - 1] = gamen_PathPatternY[i];
                }
            }

            log.Debug("FillData(T800): Path pattern: lnAreaPathPattern ");

            lnAreaPathPattern.MinX = minX;
            lnAreaPathPattern.MaxX = maxX;
            for (int i = 0; i < gamen_PathPatternXMax.Length; i++)
            {
                lnAreaPathPattern.Values.Add(new LineF(new PointF(gamen_PathPatternXMin[i], gamen_PathPatternYMin[i]), new PointF(gamen_PathPatternXMax[i], gamen_PathPatternYMax[i])));
            }

            chtT800_PathPattern.ValueAxis1.LineSeries.Add(lnGamenPathPattern);
            chtT800_PathPattern.ValueAxis1.LineSeries.Add(lnPathPattern);
            chtT800_PathPattern.ValueAxis1.TetragonCustomSeries.Add(lnAreaPathPattern);
            
            */
            #endregion

            //log.Debug("FillData(T800): vendor, " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));

            #region chtT800_Vendor
            /*
            T800_I2_07 t800_R425 = t800.R413; // Blue bar
            // GAMEN 357 - 363
            int[] gamenVendor1 = new int[] { MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE }; // Yellow bar
            // GAMEN 364 - 370
            int[] gamenVendor2 = new int[] { MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE }; // red line
            // GAMEN 371 - 377
            int[] gamenVendor3 = new int[] { MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE }; // Pink line

            if (gamens != null)
            {
                for (int i = 0; i < 7; i++)
                {
                    gamenVendor1[i] = Convert.ToInt32(gamens[356 + i]);
                    gamenVendor2[i] = Convert.ToInt32(gamens[363 + i]);
                    gamenVendor3[i] = Convert.ToInt32(gamens[370 + i]);
                }
            }
            */
            /*
            BarSeries brT800_Vendor2 = new BarSeries("ベンダー力_GAMEN");
            brT800_Vendor2.BorderColor = Color.White;
            brT800_Vendor2.BorderSize = 1;
            brT800_Vendor2.Color = lblT800_PathPattern_Pre.ForeColor;
            brT800_Vendor2.Size = 20;
            for (int i = 0; i < gamenVendor1.Length; i++)
            {
                brT800_Vendor2.Values.Add(gamenVendor1[i]);
            }
            chtT800_Vendor.ValueAxis1.BarSeries.Add(brT800_Vendor2);
            */

            /*
            BarSeries brT800_Vendor1 = new BarSeries("ベンダー力");
            brT800_Vendor1.BorderColor = Color.White;
            brT800_Vendor1.BorderSize = 1;
            brT800_Vendor1.Color = lblT800_PathPattern_Curr.ForeColor;
            brT800_Vendor1.Size = 20;
            for (int i = 0; i < t800_R425.Rows.Length; i++)
            {
                brT800_Vendor1.Values.Add(t800_R425.Rows[i]);
            }
            chtT800_Vendor.ValueAxis1.BarSeries.Add(brT800_Vendor1);
            */
            /*
            LineSeries lnT800_Vendor3 = new LineSeries("ベンダー力上限_GAMEN");
            lnT800_Vendor3.Color = Color.Red;
            lnT800_Vendor3.Size = 3;
            lnT800_Vendor3.Marker.Style = MarkerStyle.THANG;
            lnT800_Vendor3.Marker.Size = 2;
            lnT800_Vendor3.Marker.BackColor = Color.Red;
            lnT800_Vendor3.Marker.BorderSize = 1;
            lnT800_Vendor3.Marker.ForeColor = Color.Red;
            for (int i = 0; i < gamenVendor2.Length; i++)
            {
                lnT800_Vendor3.Values.Add(gamenVendor2[i]);
            }
            chtT800_Vendor.ValueAxis1.LineSeries.Add(lnT800_Vendor3);
            */
            /*
            LineSeries lnT800_Vendor4 = new LineSeries("ベンダー力下限_GAMEN");
            lnT800_Vendor4.Color = Color.Fuchsia;
            lnT800_Vendor4.Size = 3;
            lnT800_Vendor4.Marker.Style = MarkerStyle.THANG;
            lnT800_Vendor4.Marker.Size = 2;
            lnT800_Vendor4.Marker.BackColor = Color.Fuchsia;
            lnT800_Vendor4.Marker.BorderSize = 1;
            lnT800_Vendor4.Marker.ForeColor = Color.Fuchsia;
            for (int i = 0; i < gamenVendor3.Length; i++)
            {
                lnT800_Vendor4.Values.Add(gamenVendor3[i]);
            }
            chtT800_Vendor.ValueAxis1.LineSeries.Add(lnT800_Vendor4);

            this.lblT800_Vendor_F1.Text = t800_R425.F1.ToString();
            this.lblT800_Vendor_F2.Text = t800_R425.F2.ToString();
            this.lblT800_Vendor_F3.Text = t800_R425.F3.ToString();
            this.lblT800_Vendor_F4.Text = t800_R425.F4.ToString();
            this.lblT800_Vendor_F5.Text = t800_R425.F5.ToString();
            this.lblT800_Vendor_F6.Text = t800_R425.F6.ToString();
            this.lblT800_Vendor_F7.Text = t800_R425.F7.ToString();

            this.lblT800_VendorGamen_F1.Text = gamenVendor1[0].ToString();
            this.lblT800_VendorGamen_F2.Text = gamenVendor1[1].ToString();
            this.lblT800_VendorGamen_F3.Text = gamenVendor1[2].ToString();
            this.lblT800_VendorGamen_F4.Text = gamenVendor1[3].ToString();
            this.lblT800_VendorGamen_F5.Text = gamenVendor1[4].ToString();
            this.lblT800_VendorGamen_F6.Text = gamenVendor1[5].ToString();
            this.lblT800_VendorGamen_F7.Text = gamenVendor1[6].ToString();

            this.lblT800_Vendor_F1.Refresh();
            this.lblT800_Vendor_F2.Refresh();
            this.lblT800_Vendor_F3.Refresh();
            this.lblT800_Vendor_F4.Refresh();
            this.lblT800_Vendor_F5.Refresh();
            this.lblT800_Vendor_F6.Refresh();
            this.lblT800_Vendor_F7.Refresh();

            this.lblT800_VendorGamen_F1.Refresh();
            this.lblT800_VendorGamen_F2.Refresh();
            this.lblT800_VendorGamen_F3.Refresh();
            this.lblT800_VendorGamen_F4.Refresh();
            this.lblT800_VendorGamen_F5.Refresh();
            this.lblT800_VendorGamen_F6.Refresh();
            this.lblT800_VendorGamen_F7.Refresh();
            */
            #endregion

            //log.Debug("FillData(T800): Crom Total, " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));

            // End HSS5

            #region chtT800_CrownTotal
            /*
            // GAMEN 378 - 384
            // GAMEN 385 - 391
            int[] crownTotalT8001 = new int[] { MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE };
            int[] crownTotalT8002 = new int[] { MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE };

            if (gamens != null)
            {
                for (int i = 0; i < 7; i++)
                {
                    crownTotalT8001[i] = Convert.ToInt32(gamens[377 + i]);
                    crownTotalT8002[i] = Convert.ToInt32(gamens[384 + i]);
                }
            }

            BarSeries barCrownTotal1T800 = new BarSeries("Crown Total 当材 T800");
            barCrownTotal1T800.BorderSize = 1;
            barCrownTotal1T800.BorderColor = Color.White;
            barCrownTotal1T800.Color = lblT800_PathPattern_Curr.ForeColor;
            barCrownTotal1T800.Size = 20;

            BarSeries barCrownTotal2T800 = new BarSeries("Crown Total 過去実績 T800");
            barCrownTotal2T800.BorderSize = 1;
            barCrownTotal2T800.BorderColor = Color.White;
            barCrownTotal2T800.Color = lblT800_PathPattern_Pre.ForeColor;
            barCrownTotal2T800.Size = 20;

            for (int i = 0; i < crownTotalT8001.Length; i++)
            {
                barCrownTotal1T800.Values.Add(crownTotalT8001[i]);
                barCrownTotal2T800.Values.Add(crownTotalT8002[i]);
            }

            chtT800_CrownTotal.ValueAxis1.BarSeries.Add(barCrownTotal2T800);
            chtT800_CrownTotal.ValueAxis1.BarSeries.Add(barCrownTotal1T800);
            */

            #endregion

            log.Debug("FillData(T800): Roll Shift 01, " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));

            #region chtRollShift01
            if (gamens != null)
            {
                //GAMEN 392 - 421
                int[] gamen392 = new int[] { MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE };
                int[] gamen402 = new int[] { MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE };
                int[] gamen412 = new int[] { MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE };

                if (gamens != null)
                {
                    for (int i = 0; i < gamen392.Length; i++)
                    {
                        gamen392[i] = Convert.ToInt32(gamens[391 + i]);
                        gamen402[i] = Convert.ToInt32(gamens[401 + i]);
                        gamen412[i] = Convert.ToInt32(gamens[411 + i]);
                    }
                }

                LineSeries lineseries1 = new LineSeries("WR_F1");
                lineseries1.IsSolidLine = false;
                lineseries1.Marker.Style = MarkerStyle.THANG;
                lineseries1.Marker.Size = 20;
                lineseries1.Color = Color.Cyan;
                lineseries1.Marker.ForeColor = Color.Cyan;

                for (int i = 0; i < gamen392.Length; i++)
                {
                    lineseries1.Values.Add(Double.MinValue);
                    lineseries1.Values.Add(gamen392[i]);
                }
                lineseries1.Values.Add(Double.MinValue);

                chtRollShift01.ValueAxis1.LineSeries.Add(lineseries1);


                LineSeries lineseries2 = new LineSeries("WR_F2");
                lineseries2.IsSolidLine = false;
                lineseries2.Marker.Style = MarkerStyle.THANG;
                lineseries2.Marker.Size = 20;
                lineseries2.Color = Color.Orange;
                lineseries2.Marker.ForeColor = Color.Orange;

                for (int i = 0; i < gamen392.Length; i++)
                {
                    lineseries2.Values.Add(Double.MinValue);
                    lineseries2.Values.Add(gamen402[i]);
                }
                lineseries2.Values.Add(Double.MinValue);

                chtRollShift01.ValueAxis1.LineSeries.Add(lineseries2);

                LineSeries lineseries3 = new LineSeries("Test3");
                lineseries3.IsSolidLine = false;
                lineseries3.Marker.Style = MarkerStyle.THANG;
                lineseries3.Marker.Size = 20;
                lineseries3.Color = Color.Yellow;
                lineseries3.Marker.ForeColor = Color.Yellow;

                for (int i = 0; i < gamen392.Length; i++)
                {
                    lineseries3.Values.Add(Double.MinValue);
                    lineseries3.Values.Add(gamen412[i]);
                }
                lineseries3.Values.Add(Double.MinValue);

                chtRollShift01.ValueAxis1.LineSeries.Add(lineseries3);
            }
            #endregion

            lblRollShift01_2.Refresh();
            lblRollShift01_5.Refresh();
            lblRollShift01_8.Refresh();

            log.Debug("FillData(T800): Roll Shift 02, " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));

            #region chtRollShift02
            if (gamens != null)
            {
                // GAMEN 422 - 441
                int[] gamen422 = new int[] { MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE };
                int[] gamen432 = new int[] { MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE, MIN_VALUE };

                if (gamens != null)
                {
                    for (int i = 0; i < gamen422.Length; i++)
                    {
                        gamen422[i] = Convert.ToInt32(gamens[421 + i]);
                        gamen432[i] = Convert.ToInt32(gamens[431 + i]);
                    }
                }

                LineSeries lineseries4 = new LineSeries("Test");
                lineseries4.IsSolidLine = false;
                lineseries4.Marker.Style = MarkerStyle.THANG;
                lineseries4.Marker.Size = 20;
                lineseries4.Color = Color.Cyan;
                lineseries4.Marker.ForeColor = Color.Cyan;

                for (int i = 0; i < gamen422.Length; i++)
                {
                    lineseries4.Values.Add(Double.MinValue);
                    lineseries4.Values.Add(gamen422[i]);
                }
                lineseries4.Values.Add(Double.MinValue);

                chtRollShift02.ValueAxis1.LineSeries.Add(lineseries4);

                LineSeries lineseries5 = new LineSeries("Test2");
                lineseries5.IsSolidLine = false;
                lineseries5.Marker.Style = MarkerStyle.THANG;
                lineseries5.Marker.Size = 20;
                lineseries5.Color = Color.Orange;
                lineseries5.Marker.ForeColor = Color.Orange;

                for (int i = 0; i < gamen432.Length; i++)
                {
                    lineseries5.Values.Add(Double.MinValue);
                    lineseries5.Values.Add(gamen432[i]);
                }
                lineseries5.Values.Add(Double.MinValue);

                chtRollShift02.ValueAxis2.LineSeries.Add(lineseries5);
            }
            #endregion

            log.Debug("FillData(T800): End, " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));

            lblRollShift02_2.Refresh();
            lblRollShift02_5.Refresh();
            lblRollShift02_8.Refresh();

            // HSS5
            #region ベンダー
            {
                #region Pre
                T800 t800_Pre = t800.GetPreviousFinal();

                lblT800VendorsMode_Manual_Pre.BackColor = Color.Black;
                lblT800VendorsMode_Auto_Pre.BackColor = Color.Black;
                lblT800VendorsMode_SemiAuto_Pre.BackColor = Color.Black;

                lblT800VendorsMode_Manual_Pre.ForeColor = Color.Lime;
                lblT800VendorsMode_Auto_Pre.ForeColor = Color.Lime;
                lblT800VendorsMode_SemiAuto_Pre.ForeColor = Color.Lime;
                
                if (t800_Pre != null)
                {
                    T800_Extend_02 t800_Extend_02_Pre = t800_Pre.R451;
                    if (t800_Extend_02_Pre != null)
                    {
                        switch (t800_Extend_02_Pre.R451)
                        {
                            case 1:
                                lblT800VendorsMode_Manual_Pre.BackColor = Color.Lime;
                                lblT800VendorsMode_Manual_Pre.ForeColor = Color.Black;
                                break;
                            case 2:
                                lblT800VendorsMode_SemiAuto_Pre.BackColor = Color.Lime;
                                lblT800VendorsMode_SemiAuto_Pre.ForeColor = Color.Black;
                                break;
                            case 3:
                                lblT800VendorsMode_Auto_Pre.BackColor = Color.Lime;
                                lblT800VendorsMode_Auto_Pre.ForeColor = Color.Black;
                                break;
                            default:
                                break;
                        }
                    }
                }
                #endregion

                #region Current
                lblT800VendorsMode_Manual.BackColor = Color.Black;
                lblT800VendorsMode_Auto.BackColor = Color.Black;
                lblT800VendorsMode_SemiAuto.BackColor = Color.Black;

                lblT800VendorsMode_Manual.ForeColor = Color.Lime;
                lblT800VendorsMode_Auto.ForeColor = Color.Lime;
                lblT800VendorsMode_SemiAuto.ForeColor = Color.Lime;

                lblT800VendorThermal_F1.Text = "";
                lblT800VendorThermal_F2.Text = "";
                lblT800VendorThermal_F3.Text = "";
                lblT800VendorThermal_F4.Text = "";
                lblT800VendorThermal_F5.Text = "";
                lblT800VendorThermal_F6.Text = "";
                lblT800VendorThermal_F7.Text = "";

                if (t800 != null)
                {
                    T800_Extend_02 t800_Extend_02 = t800.R451;
                    if (t800_Extend_02 != null)
                    {
                        switch (t800_Extend_02.R451)
                        {
                            case 1:
                                lblT800VendorsMode_Manual.BackColor = Color.Lime;
                                lblT800VendorsMode_Manual.ForeColor = Color.Black;
                                break;
                            case 2:
                                lblT800VendorsMode_SemiAuto.BackColor = Color.Lime;
                                lblT800VendorsMode_SemiAuto.ForeColor = Color.Black;
                                break;
                            case 3:
                                lblT800VendorsMode_Auto.BackColor = Color.Lime;
                                lblT800VendorsMode_Auto.ForeColor = Color.Black;
                                break;
                            default:
                                break;
                        }

                        #region ｻｰﾏﾙｹﾞｲﾝ
                        lblT800VendorThermal_F1.Text = t800_Extend_02.R453.ToString("###;-###;0");
                        lblT800VendorThermal_F2.Text = t800_Extend_02.R455.ToString("###;-###;0");
                        lblT800VendorThermal_F3.Text = t800_Extend_02.R457.ToString("###;-###;0");
                        lblT800VendorThermal_F4.Text = t800_Extend_02.R459.ToString("###;-###;0");
                        lblT800VendorThermal_F5.Text = t800_Extend_02.R461.ToString("###;-###;0");
                        lblT800VendorThermal_F6.Text = t800_Extend_02.R463.ToString("###;-###;0");
                        lblT800VendorThermal_F7.Text = t800_Extend_02.R465.ToString("###;-###;0");
                        #endregion
                    }
                }
                #endregion
            }
            #endregion
            // End HSS5

            #region HSS5 add
            {
                if (gamenT800.ID > 0)
                {
                    log.Debug("FillData(T800): FillGamen_V5, " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                    FillGamen_V5(gamenT800);
                }
            }
            #endregion

        }

        // HSS5
        protected void FillData(T200 t200)
        {
            log.Debug("Begin FillData(T200), at: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
            try
            {
                log.Debug("FillData(T200): load gamen, " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                Gamen gamenT200 = new Gamen(t200.ID, 4);
                                
                #region HSS5 add
                {
                    if (gamenT200.ID > 0)
                    {
                        log.Debug("FillData(T200): FillGamen_V5, " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                        FillGamen_V5(gamenT200);
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                log.Error("FillData(T200 t200) Error: ", ex);
            }
            finally
            {
                log.Debug("End FillData(T200), at: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
            }
        }
        // End HSS5

        protected void FillData(T1800 t1800)
        {
            log.Debug("Begin FillData(T1800), at: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));

            log.Debug("FillData(T1800): load T800, " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
            T800 t800 = T800.FromCoilNo(t1800.R0025);
            log.Debug("FillData(T1800): load gamen, " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
            Gamen gamenT1800 = new Gamen(t1800.ID, 3);
            double[] gamens = null;
            if (gamenT1800.ID > 0)
            {
                gamens = gamenT1800.GetValues();
            }

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

            ////////////////////////////////////////////////////////
            // Fill F1...F7 charts
            ////////////////////////////////////////////////////////

            log.Debug("FillData(T1800): Chart F1 - F7, " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));

            #region chart T1800 F1...F7
            int twoPointX = -300;
            //T1800_I2_07 t1800_R0235 = t1800.R0223;

            T800_I2_07 t800_R397 = new T800_I2_07(0, 0, 0, 0, 0, 0, 0, 0, 0); // t800.R385;
            int t800_R129 = 0;// t800.R117;

            if (t800 != null)
            {
                t800_R397 = t800.R385;
                t800_R129 = t800.R117;
            }

            // F1
            T1800_I2_45 t1800_R0401 = t1800.R0401;
            T1800_I2_45 t1800_R1031 = t1800.R1031;
            double[] gamen442 = new double[45];
            for (int i = 0; i < gamen442.Length; i++)
            {
                gamen442[i] = Double.MinValue;
            }
            if (gamenT1800.ID > 0)
            {
                Array.Copy(gamens, 441, gamen442, 0, 45);
            }
            //double[] gamen442 = new double[] { -106, -95, -84, -73, -62, -51, -40, -28, -15, -2, 13, 29, 51, 78, 101, 116, 128, 138, 146, 151, 155, 157, 157, 156, 154, 149, 143, 135, 124, 112, 94, 68, 43, 24, 9, -5, -17, -30, -41, -53, -63, -74, -84, -95, -104 };
            #region F1
            if (t1800_R0401 != null)
            {
                int maxR0410 = Int32.MinValue;
                int minR0410 = Int32.MaxValue;

                LineSeries bsF1_t1800_Red = new LineSeries("サーマルプロフィル");
                bsF1_t1800_Red.Size = 2;
                bsF1_t1800_Red.Color = lblT1800_Red.ForeColor;
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
                bsF1_t1800_Lime.Color = lblT1800_Lime.ForeColor;
                bsF1_t1800_Lime.Marker.Size = 2;
                bsF1_t1800_Lime.Marker.Style = MarkerStyle.THANG;
                bsF1_t1800_Lime.Marker.BackColor = bsF1_t1800_Lime.Marker.ForeColor = bsF1_t1800_Lime.Color;

                for (int i = 0; i < gamen442.Length; i++)
                {
                    //bsF1_t1800_Lime.Values.Add(t1800_R0401.Rows[i] + t1800_R1031.Rows[i]);
                    bsF1_t1800_Lime.Values.Add(gamen442[i]);
                }

                chtT1800_F1.ValueAxis1.LineSeries.Add(bsF1_t1800_Lime);

                LineSeries bsF1_t1800_Cyan = new LineSeries("摩耗プロフィル");
                bsF1_t1800_Cyan.Size = 2;
                bsF1_t1800_Cyan.Color = lblT1800_Cyan.ForeColor;
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
                bsF1_t1800_Orange.Color = System.Drawing.Color.Orange;
                bsF1_t1800_Orange.Marker.Size = 2;
                bsF1_t1800_Orange.Marker.Style = MarkerStyle.THANG;
                bsF1_t1800_Orange.Marker.BackColor = bsF1_t1800_Orange.Marker.ForeColor = bsF1_t1800_Orange.Color;

                double min = -t800_R129 / 2.0 - t800_R397.F1;
                double max = t800_R129 / 2.0 - t800_R397.F1;
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
            #endregion

            #region F2
            // F2
            T1800_I2_45 t1800_R0491 = t1800.R0491;
            T1800_I2_45 t1800_R1121 = t1800.R1121;
            double[] gamen487 = new double[45];
            for (int i = 0; i < gamen487.Length; i++)
            {
                gamen487[i] = Double.MinValue;
            }
            if (gamenT1800.ID > 0)
            {
                Array.Copy(gamens, 486, gamen487, 0, 45);
            }
            
            if (t1800_R0491 != null)
            {
                int maxR0491 = Int32.MinValue;
                int minR0491 = Int32.MaxValue;

                LineSeries bsF2_t1800_Red = new LineSeries("サーマルプロフィル");
                bsF2_t1800_Red.Size = 2;
                bsF2_t1800_Red.Color = lblT1800_Red.ForeColor;
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
                bsF2_t1800_Lime.Color = lblT1800_Lime.ForeColor;
                bsF2_t1800_Lime.Marker.Size = 2;
                bsF2_t1800_Lime.Marker.Style = MarkerStyle.THANG;
                bsF2_t1800_Lime.Marker.BackColor = bsF2_t1800_Lime.Marker.ForeColor = bsF2_t1800_Lime.Color;

                for (int i = 0; i < gamen487.Length; i++)
                {
                    //bsF2_t1800_Lime.Values.Add(t1800_R0491.Rows[i] + t1800_R1121.Rows[i]);
                    bsF2_t1800_Lime.Values.Add(gamen487[i]);
                }

                chtT1800_F2.ValueAxis1.LineSeries.Add(bsF2_t1800_Lime);

                LineSeries bsF2_t1800_Cyan = new LineSeries("摩耗プロフィル");
                bsF2_t1800_Cyan.Size = 2;
                bsF2_t1800_Cyan.Color = lblT1800_Cyan.ForeColor;
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
                bsF2_t1800_Orange.Color = System.Drawing.Color.Orange;
                bsF2_t1800_Orange.Marker.Size = 2;
                bsF2_t1800_Orange.Marker.Style = MarkerStyle.THANG;
                bsF2_t1800_Orange.Marker.BackColor = bsF2_t1800_Orange.Marker.ForeColor = bsF2_t1800_Orange.Color;

                double min = -t800_R129 / 2.0 - t800_R397.F2;
                double max = t800_R129 / 2.0 - t800_R397.F2;
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
            #endregion

            #region F3
            // F3
            T1800_I2_45 t1800_R0581 = t1800.R0581;
            T1800_I2_45 t1800_R1211 = t1800.R1211;
            double[] gamen532 = new double[45];
            for (int i = 0; i < gamen532.Length; i++)
            {
                gamen532[i] = Double.MinValue;
            }
            if (gamenT1800.ID > 0)
            {
                Array.Copy(gamens, 531, gamen532, 0, 45);
            }
            
            if (t1800_R0581 != null)
            {
                int maxR0581 = Int32.MinValue;
                int minR0581 = Int32.MaxValue;

                LineSeries bsF3_t1800_Red = new LineSeries("サーマルプロフィル");
                bsF3_t1800_Red.Size = 2;
                bsF3_t1800_Red.Color = lblT1800_Red.ForeColor;
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
                bsF3_t1800_Lime.Color = lblT1800_Lime.ForeColor;
                bsF3_t1800_Lime.Marker.Size = 2;
                bsF3_t1800_Lime.Marker.Style = MarkerStyle.THANG;
                bsF3_t1800_Lime.Marker.BackColor = bsF3_t1800_Lime.Marker.ForeColor = bsF3_t1800_Lime.Color;

                for (int i = 0; i < gamen532.Length; i++)
                {
                    //bsF3_t1800_Lime.Values.Add(t1800_R0581.Rows[i] + t1800_R1211.Rows[i]);
                    bsF3_t1800_Lime.Values.Add(gamen532[i]);
                    
                }

                chtT1800_F3.ValueAxis1.LineSeries.Add(bsF3_t1800_Lime);

                LineSeries bsF3_t1800_Cyan = new LineSeries("摩耗プロフィル");
                bsF3_t1800_Cyan.Size = 2;
                bsF3_t1800_Cyan.Color = lblT1800_Cyan.ForeColor;
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
                bsF3_t1800_Orange.Color = System.Drawing.Color.Orange;
                bsF3_t1800_Orange.Marker.Size = 2;
                bsF3_t1800_Orange.Marker.Style = MarkerStyle.THANG;
                bsF3_t1800_Orange.Marker.BackColor = bsF3_t1800_Orange.Marker.ForeColor = bsF3_t1800_Orange.Color;

                double min = -t800_R129 / 2.0 - t800_R397.F3;
                double max = t800_R129 / 2.0 - t800_R397.F3;
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
            #endregion

            #region F4
            // F4
            T1800_I2_45 t1800_R0671 = t1800.R0671;
            T1800_I2_45 t1800_R1301 = t1800.R1301;
            double[] gamen577 = new double[45];
            for (int i = 0; i < gamen577.Length; i++)
            {
                gamen577[i] = Double.MinValue;
            }
            if (gamenT1800.ID > 0)
            {
                Array.Copy(gamens, 576, gamen577, 0, 45);
            }
            
            if (t1800_R0671 != null)
            {
                int maxR0671 = Int32.MinValue;
                int minR0671 = Int32.MaxValue;

                LineSeries bsF4_t1800_Red = new LineSeries("サーマルプロフィル");
                bsF4_t1800_Red.Size = 2;
                bsF4_t1800_Red.Color = lblT1800_Red.ForeColor;
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
                bsF4_t1800_Lime.Color = lblT1800_Lime.ForeColor;
                bsF4_t1800_Lime.Marker.Size = 2;
                bsF4_t1800_Lime.Marker.Style = MarkerStyle.THANG;
                bsF4_t1800_Lime.Marker.BackColor = bsF4_t1800_Lime.Marker.ForeColor = bsF4_t1800_Lime.Color;

                for (int i = 0; i < gamen577.Length; i++)
                {
                    //bsF4_t1800_Lime.Values.Add(t1800_R0671.Rows[i] + t1800_R1301.Rows[i]);
                    bsF4_t1800_Lime.Values.Add(gamen577[i]);
                    
                }

                chtT1800_F4.ValueAxis1.LineSeries.Add(bsF4_t1800_Lime);

                LineSeries bsF4_t1800_Cyan = new LineSeries("摩耗プロフィル");
                bsF4_t1800_Cyan.Size = 2;
                bsF4_t1800_Cyan.Color = lblT1800_Cyan.ForeColor;
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
                bsF4_t1800_Orange.Color = System.Drawing.Color.Orange;
                bsF4_t1800_Orange.Marker.Size = 2;
                bsF4_t1800_Orange.Marker.Style = MarkerStyle.THANG;
                bsF4_t1800_Orange.Marker.BackColor = bsF4_t1800_Orange.Marker.ForeColor = bsF4_t1800_Orange.Color;

                double min = -t800_R129 / 2.0 - t800_R397.F4;
                double max = t800_R129 / 2.0 - t800_R397.F4;
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
            #endregion

            #region F5
            // F5
            T1800_I2_45 t1800_R0761 = t1800.R0761;
            T1800_I2_45 t1800_R1391 = t1800.R1391;
            double[] gamen622 = new double[45];
            for (int i = 0; i < gamen622.Length; i++)
            {
                gamen622[i] = Double.MinValue;
            }
            if (gamenT1800.ID > 0)
            {
                Array.Copy(gamens, 621, gamen622, 0, 45);
            }
            
            if (t1800_R0761 != null)
            {
                int maxR0761 = Int32.MinValue;
                int minR0761 = Int32.MaxValue;

                LineSeries bsF5_t1800_Red = new LineSeries("サーマルプロフィル");
                bsF5_t1800_Red.Size = 2;
                bsF5_t1800_Red.Color = lblT1800_Red.ForeColor;
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
                bsF5_t1800_Lime.Color = lblT1800_Lime.ForeColor;
                bsF5_t1800_Lime.Marker.Size = 2;
                bsF5_t1800_Lime.Marker.Style = MarkerStyle.THANG;
                bsF5_t1800_Lime.Marker.BackColor = bsF5_t1800_Lime.Marker.ForeColor = bsF5_t1800_Lime.Color;

                for (int i = 0; i < gamen622.Length; i++)
                {
                    //bsF5_t1800_Lime.Values.Add(t1800_R0761.Rows[i] + t1800_R1391.Rows[i]);
                    bsF5_t1800_Lime.Values.Add(gamen622[i]);
                }

                chtT1800_F5.ValueAxis1.LineSeries.Add(bsF5_t1800_Lime);

                LineSeries bsF5_t1800_Cyan = new LineSeries("摩耗プロフィル");
                bsF5_t1800_Cyan.Size = 2;
                bsF5_t1800_Cyan.Color = lblT1800_Cyan.ForeColor;
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
                bsF5_t1800_Orange.Color = System.Drawing.Color.Orange;
                bsF5_t1800_Orange.Marker.Size = 2;
                bsF5_t1800_Orange.Marker.Style = MarkerStyle.THANG;
                bsF5_t1800_Orange.Marker.BackColor = bsF5_t1800_Orange.Marker.ForeColor = bsF5_t1800_Orange.Color;

                double min = -t800_R129 / 2.0 - t800_R397.F5;
                double max = t800_R129 / 2.0 - t800_R397.F5;
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
            #endregion

            #region F6
            // F6
            T1800_I2_45 t1800_R0851 = t1800.R0851;
            T1800_I2_45 t1800_R1481 = t1800.R1481;
            double[] gamen667 = new double[45];
            for (int i = 0; i < gamen667.Length; i++)
            {
                gamen667[i] = Double.MinValue;
            }
            if (gamenT1800.ID > 0)
            {
                Array.Copy(gamens, 666, gamen667, 0, 45);
            }
            
            if (t1800_R0851 != null)
            {
                int maxR0851 = Int32.MinValue;
                int minR0851 = Int32.MaxValue;

                LineSeries bsF6_t1800_Red = new LineSeries("サーマルプロフィル");
                bsF6_t1800_Red.Size = 2;
                bsF6_t1800_Red.Color = lblT1800_Red.ForeColor;
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
                bsF6_t1800_Lime.Color = lblT1800_Lime.ForeColor;
                bsF6_t1800_Lime.Marker.Size = 2;
                bsF6_t1800_Lime.Marker.Style = MarkerStyle.THANG;
                bsF6_t1800_Lime.Marker.BackColor = bsF6_t1800_Lime.Marker.ForeColor = bsF6_t1800_Lime.Color;

                for (int i = 0; i < gamen667.Length; i++)
                {
                    //bsF6_t1800_Lime.Values.Add(t1800_R0851.Rows[i] + t1800_R1481.Rows[i]);
                    bsF6_t1800_Lime.Values.Add(gamen667[i]);
                }

                chtT1800_F6.ValueAxis1.LineSeries.Add(bsF6_t1800_Lime);

                LineSeries bsF6_t1800_Cyan = new LineSeries("摩耗プロフィル");
                bsF6_t1800_Cyan.Size = 2;
                bsF6_t1800_Cyan.Color = lblT1800_Cyan.ForeColor;
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
                bsF6_t1800_Orange.Color = System.Drawing.Color.Orange;
                bsF6_t1800_Orange.Marker.Size = 2;
                bsF6_t1800_Orange.Marker.Style = MarkerStyle.THANG;
                bsF6_t1800_Orange.Marker.BackColor = bsF6_t1800_Orange.Marker.ForeColor = bsF6_t1800_Orange.Color;

                double min = -t800_R129 / 2.0 - t800_R397.F6;
                double max = t800_R129 / 2.0 - t800_R397.F6;
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
            #endregion

            #region F7
            // F7
            T1800_I2_45 t1800_R0941 = t1800.R0941;
            T1800_I2_45 t1800_R1571 = t1800.R1571;
            double[] gamen712 = new double[45];
            for (int i = 0; i < gamen712.Length; i++)
            {
                gamen712[i] = Double.MinValue;
            }
            if (gamenT1800.ID > 0)
            {
                Array.Copy(gamens, 711, gamen712, 0, 45);
            }
            
            if (t1800_R0941 != null)
            {
                int maxR0941 = Int32.MinValue;
                int minR0941 = Int32.MaxValue;

                LineSeries bsF7_t1800_Red = new LineSeries("サーマルプロフィル");
                bsF7_t1800_Red.Size = 2;
                bsF7_t1800_Red.Color = lblT1800_Red.ForeColor;
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
                bsF7_t1800_Lime.Color = lblT1800_Lime.ForeColor;
                bsF7_t1800_Lime.Marker.Size = 2;
                bsF7_t1800_Lime.Marker.Style = MarkerStyle.THANG;
                bsF7_t1800_Lime.Marker.BackColor = bsF7_t1800_Lime.Marker.ForeColor = bsF7_t1800_Lime.Color;

                for (int i = 0; i < gamen712.Length; i++)
                {
                    //bsF7_t1800_Lime.Values.Add(t1800_R0941.Rows[i] + t1800_R1571.Rows[i]);
                    bsF7_t1800_Lime.Values.Add(gamen712[i]);
                }

                chtT1800_F7.ValueAxis1.LineSeries.Add(bsF7_t1800_Lime);

                LineSeries bsF7_t1800_Cyan = new LineSeries("摩耗プロフィル");
                bsF7_t1800_Cyan.Size = 2;
                bsF7_t1800_Cyan.Color = lblT1800_Cyan.ForeColor;
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
                bsF7_t1800_Orange.Color = System.Drawing.Color.Orange;
                bsF7_t1800_Orange.Marker.Size = 2;
                bsF7_t1800_Orange.Marker.Style = MarkerStyle.THANG;
                bsF7_t1800_Orange.Marker.BackColor = bsF7_t1800_Orange.Marker.ForeColor = bsF7_t1800_Orange.Color;

                double min = -t800_R129 / 2.0 - t800_R397.F7;
                double max = t800_R129 / 2.0 - t800_R397.F7;
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
            #endregion

            lblStickF1_1.Refresh();
            lblStickF1_2.Refresh();
            /*
            lblStickF3_1.Refresh();
            lblStickF3_2.Refresh();
            */
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
            #endregion

            log.Debug("FillData(T1800): Label F1 - F7, " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));

            #region lblT800_WR_F1 - F7

            if (gamens != null)
            {
                double[] gamen757 = new double[7];// { 5, 5, 3, 2, 2, 1, 1 };
                double[] gamen764 = new double[7];// { 10000, 10000, 6000, 4000, 4000, 2000, 2000 };
                double[] gamen771 = new double[7];

                Array.Copy(gamens, 756, gamen757, 0, 7);
                Array.Copy(gamens, 763, gamen764, 0, 7);
                Array.Copy(gamens, 770, gamen771, 0, 7);

                lblT800_Time_F1.Text = gamen757[0].ToString() + "回";
                lblT800_Time_F2.Text = gamen757[1].ToString() + "回";
                lblT800_Time_F3.Text = gamen757[2].ToString() + "回";
                lblT800_Time_F4.Text = gamen757[3].ToString() + "回";
                lblT800_Time_F5.Text = gamen757[4].ToString() + "回";
                lblT800_Time_F6.Text = gamen757[5].ToString() + "回";
                lblT800_Time_F7.Text = gamen757[6].ToString() + "回";

                // HSS5
                //lblT800_WR_F1.Text = gamen764[0].ToString("#####0");
                //lblT800_WR_F2.Text = gamen764[1].ToString("#####0");
                //lblT800_WR_F3.Text = gamen764[2].ToString("#####0");
                //lblT800_WR_F4.Text = gamen764[3].ToString("#####0");
                //lblT800_WR_F5.Text = gamen764[4].ToString("#####0");
                //lblT800_WR_F6.Text = gamen764[5].ToString("#####0");
                //lblT800_WR_F7.Text = gamen764[6].ToString("#####0");
                // End HSS5

                // HSS5
                {
                    T1800_Extend_02 t1800_Extend_02 = t1800.R1749;

                    lblT800_WR_F1.Text = (t1800_Extend_02.R1761 * 0.01).ToString("#####0;-#####0;0");
                    lblT800_WR_F2.Text = (t1800_Extend_02.R1765 * 0.01).ToString("#####0;-#####0;0");
                    lblT800_WR_F3.Text = (t1800_Extend_02.R1769 * 0.01).ToString("#####0;-#####0;0");
                    lblT800_WR_F4.Text = (t1800_Extend_02.R1773 * 0.01).ToString("#####0;-#####0;0");
                    lblT800_WR_F5.Text = (t1800_Extend_02.R1777 * 0.01).ToString("#####0;-#####0;0");
                    lblT800_WR_F6.Text = (t1800_Extend_02.R1781 * 0.01).ToString("#####0;-#####0;0");
                    lblT800_WR_F7.Text = (t1800_Extend_02.R1785 * 0.01).ToString("#####0;-#####0;0");
                }
                // End HSS5

                int[] gamenInt771 = new int[7];
                for (int i = 0; i < gamen771.Length; i++)
                {
                    gamenInt771[i] = Convert.ToInt32(gamen771[i]);
                }

                Panel[] pnlList = new Panel[] { pnlT1800_F1, pnlT1800_F2, pnlT1800_F3, pnlT1800_F4, pnlT1800_F5, pnlT1800_F6, pnlT1800_F7 };

                for (int i = 0; i < gamen771.Length; i++)
                {
                    //if (gamenInt771[i] == 4 || gamenInt771[i] == 8 || gamenInt771[i] == 9)
                    // only 4 or 9
                    if (gamenInt771[i] == 4 || gamenInt771[i] == 9)
                    {
                        pnlList[i].BackColor = ROLL_PROFILE_BACKCOLOR_HIGHLIGHT;
                        pnlList[i].ForeColor = ROLL_PROFILE_FORCOLOR_HIGHLIGHT;
                    }
                    else
                    {
                        pnlList[i].BackColor = ROLL_PROFILE_BACKCOLOR_NOMAL;
                        pnlList[i].ForeColor = ROLL_PROFILE_FORCOLOR_NOMAL;
                    }
                }
            }
            #endregion

            #region HSS5 add
            {
                if (gamenT1800.ID > 0)
                {
                    log.Debug("FillData(T1800): FillGamen_V5, " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
                    FillGamen_V5(gamenT1800);
                }
            }
            #endregion

            log.Debug("FillData(T1800): End, " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"));
        }

        // HSS5
        protected void FillGamen_V5(Gamen gamen) //, double[] gamens_Pre)
        {
            if (gamen == null)
            {
                return;
            }

            double[] gamens = gamen.GetValues();
            string[] gamensString = gamen.GetValuesInString();

            // check data is HSS4 or HSS5
            if (gamens.Length < Gamen.VALUE__COUNT || gamens[784] == Double.MinValue)
            {
                return;
            }

            #region lblMyRollGap_Past_Gamen_FxFy
            {
                double[] myRollGap_Past = new double[] {
                    gamens[784 + 0],
                    gamens[784 + 1],
                    gamens[784 + 2],
                    gamens[784 + 3],
                    gamens[784 + 4],
                    gamens[784 + 5] };
                this.lblMyRollGap_Past_Gamen_F1F2.Text = (myRollGap_Past[0]).ToString("0.0;-0.0;0.0");
                this.lblMyRollGap_Past_Gamen_F2F3.Text = (myRollGap_Past[1]).ToString("0.0;-0.0;0.0");
                this.lblMyRollGap_Past_Gamen_F3F4.Text = (myRollGap_Past[2]).ToString("0.0;-0.0;0.0");
                this.lblMyRollGap_Past_Gamen_F4F5.Text = (myRollGap_Past[3]).ToString("0.0;-0.0;0.0");
                this.lblMyRollGap_Past_Gamen_F5F6.Text = (myRollGap_Past[4]).ToString("0.0;-0.0;0.0");
                this.lblMyRollGap_Past_Gamen_F6F7.Text = (myRollGap_Past[5]).ToString("0.0;-0.0;0.0");

                this.lblMyRollGap_Past_Gamen_F1F2.Refresh();
                this.lblMyRollGap_Past_Gamen_F2F3.Refresh();
                this.lblMyRollGap_Past_Gamen_F3F4.Refresh();
                this.lblMyRollGap_Past_Gamen_F4F5.Refresh();
                this.lblMyRollGap_Past_Gamen_F5F6.Refresh();
                this.lblMyRollGap_Past_Gamen_F6F7.Refresh();
            }
            #endregion

            #region lblMyRollGap_Gamen_FxFy
            {
                double[] myRollGap = new double[] {
                    gamens[804 + 0],
                    gamens[804 + 1],
                    gamens[804 + 2],
                    gamens[804 + 3],
                    gamens[804 + 4],
                    gamens[804 + 5] };
                this.lblMyRollGap_Gamen_F1F2.Text = (myRollGap[0]).ToString("0.0;-0.0;0.0");
                this.lblMyRollGap_Gamen_F2F3.Text = (myRollGap[1]).ToString("0.0;-0.0;0.0");
                this.lblMyRollGap_Gamen_F3F4.Text = (myRollGap[2]).ToString("0.0;-0.0;0.0");
                this.lblMyRollGap_Gamen_F4F5.Text = (myRollGap[3]).ToString("0.0;-0.0;0.0");
                this.lblMyRollGap_Gamen_F5F6.Text = (myRollGap[4]).ToString("0.0;-0.0;0.0");
                this.lblMyRollGap_Gamen_F6F7.Text = (myRollGap[5]).ToString("0.0;-0.0;0.0");

                this.lblMyRollGap_Gamen_F1F2.Refresh();
                this.lblMyRollGap_Gamen_F2F3.Refresh();
                this.lblMyRollGap_Gamen_F3F4.Refresh();
                this.lblMyRollGap_Gamen_F4F5.Refresh();
                this.lblMyRollGap_Gamen_F5F6.Refresh();
                this.lblMyRollGap_Gamen_F6F7.Refresh();
            }
            #endregion

            #region chtT900_PathPattern
            {
                String lineMyRollGapPast_Name = "My実績";
                chtT900_PathPattern.SuspendLayout();

                for (int i = 0; i < chtT900_PathPattern.ValueAxis1.LineSeries.Count; i++)
                {
                    if (lineMyRollGapPast_Name.Equals(chtT900_PathPattern.ValueAxis1.LineSeries[i].Name, StringComparison.OrdinalIgnoreCase))
                    {
                        chtT900_PathPattern.ValueAxis1.LineSeries.RemoveAt(i);
                        break;
                    }
                }

                int[] myRollGapValuesX = new int[] { 
                    Convert.ToInt32(gamens[790 + 0]), 
                    Convert.ToInt32(gamens[790 + 1]), 
                    Convert.ToInt32(gamens[790 + 2]), 
                    Convert.ToInt32(gamens[790 + 3]), 
                    Convert.ToInt32(gamens[790 + 4]), 
                    Convert.ToInt32(gamens[790 + 5]), 
                    Convert.ToInt32(gamens[790 + 6]) };
                double[] myRollGapValuesY = new double[] {
                    gamens[797 + 0],
                    gamens[797 + 1],
                    gamens[797 + 2],
                    gamens[797 + 3],
                    gamens[797 + 4],
                    gamens[797 + 5],
                    gamens[797 + 6] };

                LineSeries lineMyRollGapPast = new LineSeries(lineMyRollGapPast_Name);
                lineMyRollGapPast.Color = lblMyRollGapPast.ForeColor;
                lineMyRollGapPast.LineStyle = LineStyle.LongDash;
                lineMyRollGapPast.Size = 3;
                lineMyRollGapPast.Marker.Style = MarkerStyle.THANG;
                lineMyRollGapPast.Marker.Size = lineMyRollGapPast.Marker.BorderSize = 0; // no marker
                lineMyRollGapPast.Marker.ForeColor = lineMyRollGapPast.Marker.BackColor = lineMyRollGapPast.Color;

                for (int i = 0; i < chtT900_PathPattern.Category.Length; i++)
                {
                    lineMyRollGapPast.Values.Add(Double.MinValue);
                }

                for (int i = 0; i < myRollGapValuesX.Length; i++)
                {
                    if (chtT900_PathPattern.Category.Length - 1 < (myRollGapValuesX[i] * 100))
                    {
                        lineMyRollGapPast.Values[0] = myRollGapValuesY[i];
                    }
                    else if (lineMyRollGapPast.Values.Count > chtT900_PathPattern.Category.Length - 1 - (myRollGapValuesX[i] * 100))
                    {
                        int valueX = chtT900_PathPattern.Category.Length - 1 - (int)(myRollGapValuesX[i] * 100);
                        while (valueX < chtT900_PathPattern.Category.Length && lineMyRollGapPast.Values[valueX] != Double.MinValue && lineMyRollGapPast.Values[valueX] != myRollGapValuesY[i])
                        {
                            valueX++;
                        }

                        //lineMyRollGapPast.Values[chtT900_PathPattern.Category.Length - 1 - (int)(myRollGapValuesX[i] * 100)] = myRollGapValuesY[i];
                        lineMyRollGapPast.Values[valueX] = myRollGapValuesY[i];
                    }
                    else
                    {
                        lineMyRollGapPast.Values[lineMyRollGapPast.Values.Count - 1] = myRollGapValuesY[i];
                    }
                }

                chtT900_PathPattern.ValueAxis1.LineSeries.Add(lineMyRollGapPast);

                chtT900_PathPattern.ResumeLayout();
            }
            #endregion

            #region Vendor
            {
                #region chtT800_PathPattern
                {
                    chtT800_PathPattern.SuspendLayout();
                    chtT800_PathPattern.ValueAxis1.LineSeries.Clear();
                    chtT800_PathPattern.ValueAxis1.MultiLayerBarSeries.Clear();

                    // 当材のベンダー過去９０％範囲の上限
                    #region Past 90% upper limit of our material vendors
                    {
                        double[] vendor90Max = new double[] {
                            gamens[845 + 0],
                            gamens[845 + 2],
                            gamens[845 + 4],
                            gamens[845 + 6],
                            gamens[845 + 8],
                            gamens[845 + 10],
                            gamens[845 + 12] };
                        double[] vendor90Min = new double[] {
                            gamens[845 + 1],
                            gamens[845 + 3],
                            gamens[845 + 5],
                            gamens[845 + 7],
                            gamens[845 + 9],
                            gamens[845 + 11],
                            gamens[845 + 13] };

                        MultiLayerBarSeries multiBarVendor90 = new MultiLayerBarSeries("当材のベンダー過去９０％範囲の上限");
                        multiBarVendor90.Size = 30;
                        multiBarVendor90.Color = Color.Turquoise;
                        multiBarVendor90.Transparentcy = 45;

                        for (int i = 0; i < vendor90Max.Length; i++)
                        {
                            multiBarVendor90.Values.Add(new MinMax(vendor90Min[i], vendor90Max[i]));
                        }

                        chtT800_PathPattern.ValueAxis1.MultiLayerBarSeries.Add(multiBarVendor90);
                    }
                    #endregion

                    // 当材のベンダー過去６０％範囲の上限
                    #region Past 60% upper limit of our material vendors
                    {
                        double[] vendor60Max = new double[] {
                            gamens[831 + 0],
                            gamens[831 + 2],
                            gamens[831 + 4],
                            gamens[831 + 6],
                            gamens[831 + 8],
                            gamens[831 + 10],
                            gamens[831 + 12] };
                        double[] vendor60Min = new double[] {
                            gamens[831 + 1],
                            gamens[831 + 3],
                            gamens[831 + 5],
                            gamens[831 + 7],
                            gamens[831 + 9],
                            gamens[831 + 11],
                            gamens[831 + 13] };

                        MultiLayerBarSeries multiBarVendor60 = new MultiLayerBarSeries("当材のベンダー過去６０％範囲の上限");
                        multiBarVendor60.Size = 30;
                        multiBarVendor60.Color = Color.Turquoise;
                        multiBarVendor60.Transparentcy = 0;

                        for (int i = 0; i < vendor60Max.Length; i++)
                        {
                            multiBarVendor60.Values.Add(new MinMax(vendor60Min[i], vendor60Max[i]));
                        }

                        chtT800_PathPattern.ValueAxis1.MultiLayerBarSeries.Add(multiBarVendor60);
                    }
                    #endregion

                    #region My実績
                    {
                        double[] myRollGap = new double[] { 
                            gamens[824 + 0],
                            gamens[824 + 1],
                            gamens[824 + 2],
                            gamens[824 + 3],
                            gamens[824 + 4],
                            gamens[824 + 5],
                            gamens[824 + 6] };
                        LineSeries lineMyRollGap = new LineSeries("My実績");
                        lineMyRollGap.Color = lblMyRollGap.ForeColor;
                        lineMyRollGap.LineStyle = LineStyle.LongDash;
                        lineMyRollGap.Size = 3;
                        lineMyRollGap.Marker.Style = MarkerStyle.THANG;
                        lineMyRollGap.Marker.Size = lineMyRollGap.Marker.BorderSize = 0; // no marker
                        lineMyRollGap.Marker.ForeColor = lineMyRollGap.Marker.BackColor = lblMyRollGap.ForeColor;

                        for (int i = 0; i < myRollGap.Length; i++)
                        {
                            lineMyRollGap.Values.Add(myRollGap[i]);
                        }
                        chtT800_PathPattern.ValueAxis1.LineSeries.Add(lineMyRollGap);
                    }
                    #endregion

                    #region Before setting material vendors - 前材
                    {
                        double[] materialVendor_Pre = new double[] { 
                            gamens[810 + 0],
                            gamens[810 + 1],
                            gamens[810 + 2],
                            gamens[810 + 3],
                            gamens[810 + 4],
                            gamens[810 + 5],
                            gamens[810 + 6] };
                        LineSeries lineMaterialVendor_Pre = new LineSeries("前材");
                        lineMaterialVendor_Pre.Color = lblMaterialVendor_Pre.ForeColor;
                        lineMaterialVendor_Pre.LineStyle = LineStyle.LongDash;
                        lineMaterialVendor_Pre.Size = 3;
                        lineMaterialVendor_Pre.Marker.Style = MarkerStyle.TAM_GIAC;
                        lineMaterialVendor_Pre.Marker.Size = 12;
                        lineMaterialVendor_Pre.Marker.BorderSize = 0;
                        //lineMaterialVendor_Pre.Marker.Size = lineMaterialVendor_Pre.Marker.BorderSize = 0; // no marker
                        lineMaterialVendor_Pre.Marker.ForeColor = lineMaterialVendor_Pre.Marker.BackColor = lineMaterialVendor_Pre.Color;

                        for (int i = 0; i < materialVendor_Pre.Length; i++)
                        {
                            lineMaterialVendor_Pre.Values.Add(materialVendor_Pre[i]);
                        }
                        chtT800_PathPattern.ValueAxis1.LineSeries.Add(lineMaterialVendor_Pre);
                    }
                    #endregion

                    #region Current setting material vendors - 当材
                    {

                        double[] materialVendor = new double[] { 
                            gamens[817 + 0],
                            gamens[817 + 1],
                            gamens[817 + 2],
                            gamens[817 + 3],
                            gamens[817 + 4],
                            gamens[817 + 5],
                            gamens[817 + 6] };
                        LineSeries lineMaterialVendor = new LineSeries("当材");
                        lineMaterialVendor.Color = lblMaterialVendor_Curr.ForeColor;
                        lineMaterialVendor.LineStyle = LineStyle.Solid;
                        lineMaterialVendor.Size = 3;
                        lineMaterialVendor.Marker.Style = MarkerStyle.VUONG;
                        lineMaterialVendor.Marker.Size = 12;
                        lineMaterialVendor.Marker.BorderSize = 0;
                        lineMaterialVendor.Marker.ForeColor = lineMaterialVendor.Marker.BackColor = lblMaterialVendor_Curr.ForeColor;

                        for (int i = 0; i < materialVendor.Length; i++)
                        {
                            lineMaterialVendor.Values.Add(materialVendor[i]);
                        }
                        chtT800_PathPattern.ValueAxis1.LineSeries.Add(lineMaterialVendor);
                    }
                    #endregion

                    chtT800_PathPattern.ResumeLayout();
                }
                #endregion

                #region Vendor grid - ベンダー
                {
                    #region Pre - 前材
                    {
                        double[] vendorSettingPre = new double[] {
                            gamens[859 + 0],
                            gamens[859 + 1],
                            gamens[859 + 2],
                            gamens[859 + 3],
                            gamens[859 + 4],
                            gamens[859 + 5],
                            gamens[859 + 6] };

                        lblT800Vendors_Pre_F1.Text = vendorSettingPre[0].ToString("###;-###;0");
                        lblT800Vendors_Pre_F2.Text = vendorSettingPre[1].ToString("###;-###;0");
                        lblT800Vendors_Pre_F3.Text = vendorSettingPre[2].ToString("###;-###;0");
                        lblT800Vendors_Pre_F4.Text = vendorSettingPre[3].ToString("###;-###;0");
                        lblT800Vendors_Pre_F5.Text = vendorSettingPre[4].ToString("###;-###;0");
                        lblT800Vendors_Pre_F6.Text = vendorSettingPre[5].ToString("###;-###;0");
                        lblT800Vendors_Pre_F7.Text = vendorSettingPre[6].ToString("###;-###;0");

                        lblT800Crow_Directive_Pre.Text = gamens[880].ToString("###;-###;0");
                        lblT800Crow_Real_Preliminary_Pre.Text = gamens[881].ToString("###;-###;0");
                    }
                    #endregion

                    #region Current - 当材
                    {
                        double[] vendorSetting = new double[] {
                            gamens[866 + 0],
                            gamens[866 + 1],
                            gamens[866 + 2],
                            gamens[866 + 3],
                            gamens[866 + 4],
                            gamens[866 + 5],
                            gamens[866 + 6] };

                        lblT800Vendors_F1.Text = vendorSetting[0].ToString("###;-###;0");
                        lblT800Vendors_F2.Text = vendorSetting[1].ToString("###;-###;0");
                        lblT800Vendors_F3.Text = vendorSetting[2].ToString("###;-###;0");
                        lblT800Vendors_F4.Text = vendorSetting[3].ToString("###;-###;0");
                        lblT800Vendors_F5.Text = vendorSetting[4].ToString("###;-###;0");
                        lblT800Vendors_F6.Text = vendorSetting[5].ToString("###;-###;0");
                        lblT800Vendors_F7.Text = vendorSetting[6].ToString("###;-###;0");

                        lblT800Crow_Directive.Text = gamens[882].ToString("###;-###;0");
                        lblT800Crow_Real_Preliminary.Text = gamens[883].ToString("###;-###;0");
                    }
                    #endregion

                    #region 過去実績
                    {
                        double[] pastPerformanceVendor = new double[] {
                            gamens[873 + 0],
                            gamens[873 + 1],
                            gamens[873 + 2],
                            gamens[873 + 3],
                            gamens[873 + 4],
                            gamens[873 + 5],
                            gamens[873 + 6] };

                        lblPastPerformanceVendor_F1.Text = pastPerformanceVendor[0].ToString("###;-###;0");
                        lblPastPerformanceVendor_F2.Text = pastPerformanceVendor[1].ToString("###;-###;0");
                        lblPastPerformanceVendor_F3.Text = pastPerformanceVendor[2].ToString("###;-###;0");
                        lblPastPerformanceVendor_F4.Text = pastPerformanceVendor[3].ToString("###;-###;0");
                        lblPastPerformanceVendor_F5.Text = pastPerformanceVendor[4].ToString("###;-###;0");
                        lblPastPerformanceVendor_F6.Text = pastPerformanceVendor[5].ToString("###;-###;0");
                        lblPastPerformanceVendor_F7.Text = pastPerformanceVendor[6].ToString("###;-###;0");

                        lblPastPerformanceCrown.Text = gamens[884].ToString("###;-###;0");
                        lblPastPerformancePredictions.Text = gamens[885].ToString("###;-###;0");
                    }
                    #endregion
                }
                #endregion

                #region RBｵﾌｾﾝﾀ
                {
                    #region HCNO
                    {
                        string[] gamenHCNO = new string[] {
                            gamensString[886 + 9],
                            gamensString[886 + 8],
                            gamensString[886 + 7],
                            gamensString[886 + 6],
                            gamensString[886 + 5],
                            gamensString[886 + 4],
                            gamensString[886 + 3],
                            gamensString[886 + 2],
                            gamensString[886 + 1],
                            gamensString[886 + 0] };

                        lblGamenHCNO_1.Text = gamenHCNO[0].Trim();
                        lblGamenHCNO_2.Text = gamenHCNO[1].Trim();
                        lblGamenHCNO_3.Text = gamenHCNO[2].Trim();
                        lblGamenHCNO_4.Text = gamenHCNO[3].Trim();
                        lblGamenHCNO_5.Text = gamenHCNO[4].Trim();
                        lblGamenHCNO_6.Text = gamenHCNO[5].Trim();
                        lblGamenHCNO_7.Text = gamenHCNO[6].Trim();
                        lblGamenHCNO_8.Text = gamenHCNO[7].Trim();
                        lblGamenHCNO_9.Text = gamenHCNO[8].Trim();
                        lblGamenHCNO_10.Text = gamenHCNO[9].Trim();
                    }
                    #endregion

                    #region T
                    {
                        double[] offCenter_T = new double[] {
                            gamens[896 + 9],
                            gamens[896 + 8],
                            gamens[896 + 7],
                            gamens[896 + 6],
                            gamens[896 + 5],
                            gamens[896 + 4],
                            gamens[896 + 3],
                            gamens[896 + 2],
                            gamens[896 + 1],
                            gamens[896 + 0] };

                        lblGamen_OffCenter_T_1.Text = offCenter_T[0] == double.MinValue ? "" : offCenter_T[0].ToString("###;-###;0");
                        lblGamen_OffCenter_T_2.Text = offCenter_T[1] == double.MinValue ? "" : offCenter_T[1].ToString("###;-###;0");
                        lblGamen_OffCenter_T_3.Text = offCenter_T[2] == double.MinValue ? "" : offCenter_T[2].ToString("###;-###;0");
                        lblGamen_OffCenter_T_4.Text = offCenter_T[3] == double.MinValue ? "" : offCenter_T[3].ToString("###;-###;0");
                        lblGamen_OffCenter_T_5.Text = offCenter_T[4] == double.MinValue ? "" : offCenter_T[4].ToString("###;-###;0");
                        lblGamen_OffCenter_T_6.Text = offCenter_T[5] == double.MinValue ? "" : offCenter_T[5].ToString("###;-###;0");
                        lblGamen_OffCenter_T_7.Text = offCenter_T[6] == double.MinValue ? "" : offCenter_T[6].ToString("###;-###;0");
                        lblGamen_OffCenter_T_8.Text = offCenter_T[7] == double.MinValue ? "" : offCenter_T[7].ToString("###;-###;0");
                        lblGamen_OffCenter_T_9.Text = offCenter_T[8] == double.MinValue ? "" : offCenter_T[8].ToString("###;-###;0");
                        lblGamen_OffCenter_T_10.Text = offCenter_T[9] == double.MinValue ? "" : offCenter_T[9].ToString("###;-###;0");
                    }
                    #endregion

                    #region B
                    {
                        double[] offCenter_B = new double[] {
                            gamens[906 + 9],
                            gamens[906 + 8],
                            gamens[906 + 7],
                            gamens[906 + 6],
                            gamens[906 + 5],
                            gamens[906 + 4],
                            gamens[906 + 3],
                            gamens[906 + 2],
                            gamens[906 + 1],
                            gamens[906 + 0] };

                        lblGamen_OffCenter_B_1.Text = offCenter_B[0] == double.MinValue ? "" : offCenter_B[0].ToString("###;-###;0");
                        lblGamen_OffCenter_B_2.Text = offCenter_B[1] == double.MinValue ? "" : offCenter_B[1].ToString("###;-###;0");
                        lblGamen_OffCenter_B_3.Text = offCenter_B[2] == double.MinValue ? "" : offCenter_B[2].ToString("###;-###;0");
                        lblGamen_OffCenter_B_4.Text = offCenter_B[3] == double.MinValue ? "" : offCenter_B[3].ToString("###;-###;0");
                        lblGamen_OffCenter_B_5.Text = offCenter_B[4] == double.MinValue ? "" : offCenter_B[4].ToString("###;-###;0");
                        lblGamen_OffCenter_B_6.Text = offCenter_B[5] == double.MinValue ? "" : offCenter_B[5].ToString("###;-###;0");
                        lblGamen_OffCenter_B_7.Text = offCenter_B[6] == double.MinValue ? "" : offCenter_B[6].ToString("###;-###;0");
                        lblGamen_OffCenter_B_8.Text = offCenter_B[7] == double.MinValue ? "" : offCenter_B[7].ToString("###;-###;0");
                        lblGamen_OffCenter_B_9.Text = offCenter_B[8] == double.MinValue ? "" : offCenter_B[8].ToString("###;-###;0");
                        lblGamen_OffCenter_B_10.Text = offCenter_B[9] == double.MinValue ? "" : offCenter_B[9].ToString("###;-###;0");
                    }
                    #endregion
                }
                #endregion
            }
            #endregion
        }
        // End HSS5

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
                    case DataPackages.Finished:
                        T200 t200 = T200.GetLast();
                        if (t200 != null && t200.ID > 0)
                        {
                            FillData(t200);
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

        protected void HighLightT900()
        {
            if (_IsLoading)
            {
                return;
            }

            _T900BlinkCount = 0;
            tmrT900_Tick(tmrT900, null);

            if (!tmrT900.Enabled)
            {
                tmrT900.Start();
            }
        }

        protected void HighLightT800()
        {
            if (_IsLoading)
            {
                return;
            }

            _T800BlinkCount = 0;
            tmrT800_Tick(tmrT800, null);

            if (!tmrT800.Enabled)
            {
                tmrT800.Start();
            }
        }

        private void tmrT900_Tick(object sender, EventArgs e)
        {
            _T900BlinkCount += 1;

            lblT900Header.ForeColor = _T900BlinkCount % 2 == 0 ? Color.Lime : Color.Black;
            lblT900Header.BackColor = _T900BlinkCount % 2 == 0 ? Color.Black : Color.Lime;

            if (this._T900BlinkCount >= 4) // 6s
            {
                tmrT900.Stop();
            }
        }

        private void tmrT800_Tick(object sender, EventArgs e)
        {
            _T800BlinkCount += 1;

            lblT800Header.ForeColor = _T800BlinkCount % 2 == 0 ? Color.Lime : Color.Black;
            lblT800Header.BackColor = _T800BlinkCount % 2 == 0 ? Color.Black : Color.Lime;

            if (this._T800BlinkCount >= 4) // 6s
            {
                tmrT800.Stop();
            }
        }

        private void tmrT1800_Tick(object sender, EventArgs e)
        {

        }

        private void tmrAlert_T900_Tick(object sender, EventArgs e)
        {
            _T900AlertCount += 1;

            if (_T900AlertType == 1)
            {
                lblT900_Alert.BackColor = _T900AlertCount % 2 == 0 ? Color.Black : Color.Red;
                lblT900_Alert.ForeColor = _T900AlertCount % 2 == 0 ? Color.Red : Color.Black;
            }
            else if (_T900AlertType == 2)
            {
                lblT900_Alert.BackColor = _T900AlertCount % 2 == 0 ? Color.Black : Color.Lime;
                lblT900_Alert.ForeColor = _T900AlertCount % 2 == 0 ? Color.Lime : Color.Black;
            }
            else if (_T900AlertType == 3)
            {
                lblT900_Alert.BackColor = _T900AlertCount % 2 == 0 ? Color.Black : Color.Cyan;
                lblT900_Alert.ForeColor = _T900AlertCount % 2 == 0 ? Color.Cyan : Color.Black;
            }

            if (this._T900AlertCount >= 91) // 180s
            {
                tmrAlert_T900.Stop();
            }
        }

        private void tmrAlert_T800_Tick(object sender, EventArgs e)
        {
            _T800AlertCount += 1;

            if (_T800AlertType == 1)
            {
                lblT800_Alert.BackColor = _T800AlertCount % 2 == 0 ? Color.Black : Color.Red;
                lblT800_Alert.ForeColor = _T800AlertCount % 2 == 0 ? Color.Red : Color.Black;
            }
            else if (_T800AlertType == 2)
            {
                lblT800_Alert.BackColor = _T800AlertCount % 2 == 0 ? Color.Black : Color.Lime;
                lblT800_Alert.ForeColor = _T800AlertCount % 2 == 0 ? Color.Lime : Color.Black; 
            }
            else if (_T800AlertType == 3)
            {
                lblT800_Alert.BackColor = _T800AlertCount % 2 == 0 ? Color.Black : Color.Cyan;
                lblT800_Alert.ForeColor = _T800AlertCount % 2 == 0 ? Color.Cyan : Color.Black;
            }

            if (this._T800AlertCount >= 91) // 180s
            {
                tmrAlert_T800.Stop();
            }
        }

        private void SendDataTest(DataPackages package)
        {
            /*
            try
            {
                HotMill.Forms.MainForm frm = HotMill.Forms.MainForm.MAIN_FORM;
                frm.SetDataTest(package);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            */
        }
    }
}