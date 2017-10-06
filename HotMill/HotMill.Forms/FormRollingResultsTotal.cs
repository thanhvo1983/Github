using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Kvics.Controls;
using Kvics.HotMill.BL;

using log4net;
using log4net.Config;

namespace Kvics.HotMill.Forms
{
    public partial class FormRollingResultsTotal : SubFormFullScreen
    {
        private static readonly ILog log = Log.Instance.GetLogger(typeof(MainForm));

        private CoilSearchStructure _SearchStructure = null;

        public FormRollingResultsTotal()
        {
            InitializeComponent();

            PresetGrid();
        }

        public FormRollingResultsTotal(CoilSearchStructure searchStructure)
        {
            InitializeComponent();

            _SearchStructure = searchStructure;

            PresetGrid();
        }

        private void PresetGrid()
        {
            this.grdData.SuspendLayout();
            this.SuspendLayout();

            this.grdData.ColumnCount = 17;
            this.grdData.RowCount = 35;

            Color backColor = Color.Black;
            Color foreColor = Color.White;

            this.grdData[0, 0] = new KvicsDataGridViewHeaderCell();
            this.grdData[1, 0] = new KvicsDataGridViewHeaderCell();
            this.grdData[16, 0] = new KvicsDataGridViewHeaderCell();

            string[] columnsText = new string[] { "FÇP", "FÇQ", "FÇR", "FÇS", "FÇT", "FÇU", "FÇV" };

            for (int i = 0, size = columnsText.Length; i < size; i++)
            {
                this.grdData[i * 2 + 2, 0] = new KvicsDataGridViewHeaderMergeCell(1, 2, backColor, foreColor, H_Align.Center, V_Align.Middle);
                this.grdData[i * 2 + 2, 0].Value = columnsText[i];
            }

            this.grdData[0, 1] = new KvicsDataGridViewHeaderMergeCell(4, 1, backColor, foreColor);
            this.grdData[0, 1].Value = "â∑ìx";
            this.grdData[0, 4] = new KvicsDataGridViewHeaderMergeCell(4, 1, backColor, foreColor);
            this.grdData[0, 4].Value = "èoë§â∑ìx";
            this.grdData[0, 8] = new KvicsDataGridViewHeaderMergeCell(4, 1, backColor, foreColor);
            this.grdData[0, 8].Value = "à≥â∫à íu";
            this.grdData[0, 12] = new KvicsDataGridViewHeaderMergeCell(4, 1, backColor, foreColor);
            this.grdData[0, 12].Value = "à≥â∫à íuç∑";
            this.grdData[0, 15] = new KvicsDataGridViewHeaderMergeCell(4, 1, backColor, foreColor);
            this.grdData[0, 15].Value = "î¬å˙";
            this.grdData[0, 19] = new KvicsDataGridViewHeaderMergeCell(4, 1, backColor, foreColor);
            this.grdData[0, 19].Value = "ÉçÅ[Éãë¨ìx";
            this.grdData[0, 23] = new KvicsDataGridViewHeaderMergeCell(4, 1, backColor, foreColor);
            this.grdData[0, 23].Value = "ÉVÉtÉgó ";
            this.grdData[0, 27] = new KvicsDataGridViewHeaderMergeCell(4, 1, backColor, foreColor);
            this.grdData[0, 27].Value = "ÇgÇbÉ¬";
            this.grdData[0, 31] = new KvicsDataGridViewHeaderMergeCell(4, 1, backColor, foreColor);
            this.grdData[0, 31].Value = "ÉxÉìÉ_Å[óÕ";

            this.grdData[16, 1] = new KvicsDataGridViewHeaderMergeCell(4, 1, backColor, foreColor);
            this.grdData[16, 1].Value = "Åé";
            this.grdData[16, 4] = new KvicsDataGridViewHeaderMergeCell(4, 1, backColor, foreColor);
            this.grdData[16, 4].Value = "Åé";
            this.grdData[16, 8] = new KvicsDataGridViewHeaderMergeCell(4, 1, backColor, foreColor);
            this.grdData[16, 8].Value = "ÇçÇç";
            this.grdData[16, 12] = new KvicsDataGridViewHeaderMergeCell(4, 1, backColor, foreColor);
            this.grdData[16, 12].Value = "ÇçÇç";
            this.grdData[16, 15] = new KvicsDataGridViewHeaderMergeCell(4, 1, backColor, foreColor);
            this.grdData[16, 15].Value = "ÇçÇç";
            this.grdData[16, 19] = new KvicsDataGridViewHeaderMergeCell(4, 1, backColor, foreColor);
            this.grdData[16, 19].Value = "ÇçÇêÇç";
            this.grdData[16, 23] = new KvicsDataGridViewHeaderMergeCell(4, 1, backColor, foreColor);
            this.grdData[16, 23].Value = "ÇçÇç";
            this.grdData[16, 27] = new KvicsDataGridViewHeaderMergeCell(4, 1, backColor, foreColor);
            this.grdData[16, 27].Value = "ÇçÇç";
            this.grdData[16, 31] = new KvicsDataGridViewHeaderMergeCell(4, 1, backColor, foreColor);
            this.grdData[16, 31].Value = "Ton/CHOCK";

            this.grdData[1, 1] = new KvicsDataGridViewHeaderMergeCell(1, 1, backColor, foreColor, H_Align.Center, V_Align.Middle);
            this.grdData[1, 2] = new KvicsDataGridViewHeaderMergeCell(1, 1, backColor, foreColor, H_Align.Center, V_Align.Middle);
            this.grdData[1, 3] = new KvicsDataGridViewHeaderMergeCell(1, 1, backColor, foreColor, H_Align.Center, V_Align.Middle);
            this.grdData[1, 4] = new KvicsDataGridViewHeaderMergeCell(2, 1, backColor, foreColor, H_Align.Center, V_Align.Middle);
            this.grdData[1, 4].Value = "ê›íË";
            this.grdData[1, 6] = new KvicsDataGridViewHeaderMergeCell(2, 1, backColor, foreColor, H_Align.Center, V_Align.Middle);
            this.grdData[1, 6].Value = "ìØàÍ1";
            this.grdData[1, 8] = new KvicsDataGridViewHeaderMergeCell(2, 1, backColor, foreColor, H_Align.Center, V_Align.Middle);
            this.grdData[1, 8].Value = "ê›íË";
            this.grdData[1, 10] = new KvicsDataGridViewHeaderMergeCell(2, 1, backColor, foreColor, H_Align.Center, V_Align.Middle);
            this.grdData[1, 10].Value = "ìØàÍ1";
            this.grdData[1, 12] = new KvicsDataGridViewHeaderMergeCell(1, 1, backColor, foreColor, H_Align.Center, V_Align.Middle);
            this.grdData[1, 12].Value = "";
            this.grdData[1, 13] = new KvicsDataGridViewHeaderMergeCell(2, 1, backColor, foreColor, H_Align.Center, V_Align.Middle);
            this.grdData[1, 13].Value = "ê›íË";
            this.grdData[1, 15] = new KvicsDataGridViewHeaderMergeCell(2, 1, backColor, foreColor, H_Align.Center, V_Align.Middle);
            this.grdData[1, 15].Value = "ê›íË";
            this.grdData[1, 17] = new KvicsDataGridViewHeaderMergeCell(2, 1, backColor, foreColor, H_Align.Center, V_Align.Middle);
            this.grdData[1, 17].Value = "ìØàÍ1";
            this.grdData[1, 19] = new KvicsDataGridViewHeaderMergeCell(2, 1, backColor, foreColor, H_Align.Center, V_Align.Middle);
            this.grdData[1, 19].Value = "ê›íË";
            this.grdData[1, 21] = new KvicsDataGridViewHeaderMergeCell(2, 1, backColor, foreColor, H_Align.Center, V_Align.Middle);
            this.grdData[1, 21].Value = "ìØàÍ1";
            this.grdData[1, 23] = new KvicsDataGridViewHeaderMergeCell(2, 1, backColor, foreColor, H_Align.Center, V_Align.Middle);
            this.grdData[1, 23].Value = "ê›íË";
            this.grdData[1, 25] = new KvicsDataGridViewHeaderMergeCell(2, 1, backColor, foreColor, H_Align.Center, V_Align.Middle);
            this.grdData[1, 25].Value = "ìØàÍ1";
            this.grdData[1, 27] = new KvicsDataGridViewHeaderMergeCell(2, 1, backColor, foreColor, H_Align.Center, V_Align.Middle);
            this.grdData[1, 27].Value = "ê›íË";
            this.grdData[1, 29] = new KvicsDataGridViewHeaderMergeCell(2, 1, backColor, foreColor, H_Align.Center, V_Align.Middle);
            this.grdData[1, 29].Value = "ìØàÍ1";
            this.grdData[1, 31] = new KvicsDataGridViewHeaderMergeCell(2, 1, backColor, foreColor, H_Align.Center, V_Align.Middle);
            this.grdData[1, 31].Value = "ê›íË";
            this.grdData[1, 33] = new KvicsDataGridViewHeaderMergeCell(2, 1, backColor, foreColor, H_Align.Center, V_Align.Middle);
            this.grdData[1, 33].Value = "ìØàÍ1";

            string[] f1f2ColumnsText = new string[] { "F1-F2", "F2-F3", "F3-F4", "F4-F5", "F5-F6", "F6-F7", "" };
            string[] tempeColumnsText = new string[] { "RDT", "FET", "", "", "", "", "FDT" };
            for (int i = 0; i < f1f2ColumnsText.Length; i++)
            {
                this.grdData[i * 2 + 2, 12] = new KvicsDataGridViewHeaderMergeCell(1, 2, backColor, foreColor, H_Align.Center, V_Align.Middle);
                this.grdData[i * 2 + 2, 12].Value = f1f2ColumnsText[i];
                this.grdData[i * 2 + 2, 1] = new KvicsDataGridViewHeaderMergeCell(1, 2, backColor, foreColor, H_Align.Center, V_Align.Middle);
                this.grdData[i * 2 + 2, 1].Value = tempeColumnsText[i];
            }

            this.grdData.Columns[0].Width = 150;
            this.grdData.Columns[1].Width = 80;
            this.grdData.Columns[16].Width = 160;

            this.grdData.Rows[0].Height = 35;
            this.grdData.Rows[29].Height = 35;
            this.grdData.Rows[32].Height = 35;


            this.grdData.Rows[2].DefaultCellStyle.ForeColor = Color.Yellow;
            this.grdData.Rows[3].DefaultCellStyle.ForeColor = Color.Yellow;

            this.grdData.Rows[4].DefaultCellStyle.ForeColor = Color.Lime;
            this.grdData.Rows[5].DefaultCellStyle.ForeColor = Color.Lime;

            this.grdData.Rows[6].DefaultCellStyle.ForeColor = Color.Yellow;
            this.grdData.Rows[7].DefaultCellStyle.ForeColor = Color.Yellow;

            this.grdData.Rows[8].DefaultCellStyle.ForeColor = Color.Lime;
            this.grdData.Rows[9].DefaultCellStyle.ForeColor = Color.Lime;

            this.grdData.Rows[10].DefaultCellStyle.ForeColor = Color.Yellow;
            this.grdData.Rows[11].DefaultCellStyle.ForeColor = Color.Yellow;

            this.grdData.Rows[13].DefaultCellStyle.ForeColor = Color.Lime;
            this.grdData.Rows[14].DefaultCellStyle.ForeColor = Color.Lime;

            this.grdData.Rows[15].DefaultCellStyle.ForeColor = Color.Lime;
            this.grdData.Rows[16].DefaultCellStyle.ForeColor = Color.Lime;

            this.grdData.Rows[17].DefaultCellStyle.ForeColor = Color.Yellow;
            this.grdData.Rows[18].DefaultCellStyle.ForeColor = Color.Yellow;

            this.grdData.Rows[19].DefaultCellStyle.ForeColor = Color.Lime;
            this.grdData.Rows[20].DefaultCellStyle.ForeColor = Color.Lime;

            this.grdData.Rows[21].DefaultCellStyle.ForeColor = Color.Yellow;
            this.grdData.Rows[22].DefaultCellStyle.ForeColor = Color.Yellow;

            this.grdData.Rows[23].DefaultCellStyle.ForeColor = Color.Lime;
            this.grdData.Rows[24].DefaultCellStyle.ForeColor = Color.Lime;

            this.grdData.Rows[25].DefaultCellStyle.ForeColor = Color.Yellow;
            this.grdData.Rows[26].DefaultCellStyle.ForeColor = Color.Yellow;

            this.grdData.Rows[27].DefaultCellStyle.ForeColor = Color.Lime;
            this.grdData.Rows[28].DefaultCellStyle.ForeColor = Color.Lime;

            this.grdData.Rows[29].DefaultCellStyle.ForeColor = Color.Yellow;
            this.grdData.Rows[30].DefaultCellStyle.ForeColor = Color.Yellow;

            this.grdData.Rows[31].DefaultCellStyle.ForeColor = Color.Lime;
            this.grdData.Rows[32].DefaultCellStyle.ForeColor = Color.Lime;

            this.grdData.Rows[33].DefaultCellStyle.ForeColor = Color.Yellow;
            this.grdData.Rows[34].DefaultCellStyle.ForeColor = Color.Yellow;

            for (int i = 2, size = this.grdData.ColumnCount - 1; i < size; i++)
            {
                this.grdData.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            
            this.grdData.ResumeLayout(false);
            this.ResumeLayout(false);

            dataGridView1_SizeChanged(null, null);
        }

        private void dataGridView1_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width < 200 || this.grdData.ColumnCount < 1)
            {
                return;
            }

            int verticalScrollBarWidth = 0;
            int innerGridHeight = 0;

            for (int i = 0, length = this.grdData.Rows.Count; i < length; i++)
            {
                innerGridHeight += this.grdData.Rows[i].Height;
            }

            if (innerGridHeight > this.grdData.Height - 2)
            {
                verticalScrollBarWidth = System.Windows.Forms.SystemInformation.VerticalScrollBarWidth;
            }
            int cellWidth = this.grdData.Width
                - this.grdData.Columns[0].Width
                - this.grdData.Columns[1].Width
                - this.grdData.Columns[16].Width
                - verticalScrollBarWidth;

            cellWidth = Convert.ToInt32(cellWidth / 14);

            if (cellWidth * 14
                + this.grdData.Columns[0].Width
                + this.grdData.Columns[1].Width
                + this.grdData.Columns[16].Width
                + verticalScrollBarWidth
                > this.grdData.Width)
            {
                cellWidth -= 1;
            }

            for (int i = 2, size = this.grdData.ColumnCount - 1; i < size; i++)
            {
                this.grdData.Columns[i].Width = cellWidth;
            }

            int innerGridWidth = 0;

            for (int i = 1, size = grdData.ColumnCount; i < size; i++)
            {
                innerGridWidth += grdData.Columns[i].Width;
            }

            grdData.Columns[0].Width = grdData.Width - 2 - innerGridWidth - verticalScrollBarWidth;
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            Point topleft = new Point(0, 0);
            Point topright = new Point(this.grdData.Width - 1, 0);
            Point bottomleft = new Point(0, this.grdData.Height - 1);
            Point bottomfight = new Point(this.grdData.Width - 1, this.grdData.Height - 1);

            e.Graphics.DrawLines(new Pen(this.grdData.GridColor), new Point[] { topleft, topright, bottomfight, bottomleft, topleft });
        }

        private void FormRollingResultsTotal_Load(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                T1800 t1800 = new T1800();
                DataSet ds = t1800.GetCoilSearchAll(_SearchStructure);

                if (ds == null)
                {
                    return;
                }

                lblCoilCount.Text = ds.Tables[0].Rows.Count.ToString();
                lblDateBegin.Text = _SearchStructure.BeginDate;
                lblDateEnd.Text = _SearchStructure.EndDate;
                lblGroup.Text = _SearchStructure.Group.A ? "A," : "";
                lblGroup.Text += _SearchStructure.Group.B ? "B," : "";
                lblGroup.Text += _SearchStructure.Group.C ? "C," : "";
                lblGroup.Text += _SearchStructure.Group.D ? "D," : "";
                lblSteelKind.Text = _SearchStructure.SteelName;
                lblStrength.Text = (_SearchStructure.TemperatureBegin >= 0 ? _SearchStructure.TemperatureBegin.ToString() : "") + "-" +
                                    (_SearchStructure.TemperatureEnd >= 0 ? _SearchStructure.TemperatureEnd.ToString() : "");
                lblThickBegin.Text = _SearchStructure.ThickBegin >= 0 ? _SearchStructure.ThickBegin.ToString() : "";
                lblThickEnd.Text = _SearchStructure.ThickEnd >= 0 ? _SearchStructure.ThickEnd.ToString() : "";
                lblWidthBegin.Text = _SearchStructure.WidthBegin >= 0 ? _SearchStructure.WidthBegin.ToString() : "";
                lblWidthEnd.Text = _SearchStructure.WidthEnd >= 0 ? _SearchStructure.WidthEnd.ToString() : "";
                lblWorker1.Text = _SearchStructure.WorkerList.Count > 0 ? _SearchStructure.WorkerList[0].Name : "";
                lblWorker2.Text = _SearchStructure.WorkerList.Count > 1 ? _SearchStructure.WorkerList[1].Name : "";
                lblWorker3.Text = _SearchStructure.WorkerList.Count > 2 ? _SearchStructure.WorkerList[2].Name : "";
                lblWorker4.Text = _SearchStructure.WorkerList.Count > 3 ? _SearchStructure.WorkerList[3].Name : "";
                lblWorker5.Text = _SearchStructure.WorkerList.Count > 4 ? _SearchStructure.WorkerList[4].Name : "";
                lblWorker6.Text = _SearchStructure.WorkerList.Count > 5 ? _SearchStructure.WorkerList[5].Name : "";
                lblWorker7.Text = _SearchStructure.WorkerList.Count > 6 ? _SearchStructure.WorkerList[6].Name : "";
                lblWorker8.Text = _SearchStructure.WorkerList.Count > 7 ? _SearchStructure.WorkerList[7].Name : "";

                if (lblGroup.Text.Length < 1)
                {
                    lblGroup.Text = "A,B,C,D";
                }
                else
                {
                    lblGroup.Text = lblGroup.Text.Substring(0, lblGroup.Text.Length - 1);
                }

                DataTable tbResult = CalculateRollingTotal(ds.Tables[0]);
                if (tbResult == null)
                {
                    MessageBox.Show("ÉfÅ[É^åüçıåvéZÇÃéûÇ…ÉGÉâÅ[Ç™î≠ê∂ÇµÇ‹ÇµÇΩÅBä«óùé“Ç…í ímÇµÇƒâ∫Ç≥Ç¢ÅB", "í ím");
                }
                else if (ds.Tables[0].Rows.Count > 0)
                {
                    grdData[2, 2].Value = (Double.Parse(tbResult.Rows[0][0].ToString()) * (0.1)).ToString("0.0");
                    grdData[3, 2].Value = (Math.Pow(Double.Parse(tbResult.Rows[0][1].ToString()), 0.5) * (0.1)).ToString("0.0");
                    grdData[2, 3].Value = (Double.Parse(tbResult.Rows[1][0].ToString()) * (0.1)).ToString("0.0");
                    grdData[3, 3].Value = (Double.Parse(tbResult.Rows[1][1].ToString()) * (0.1)).ToString("0.0");

                    grdData[4, 2].Value = (Double.Parse(tbResult.Rows[0][2].ToString()) * (0.1)).ToString("0.0");
                    grdData[5, 2].Value = (Math.Pow(Double.Parse(tbResult.Rows[0][3].ToString()), 0.5) * (0.1)).ToString("0.0");
                    grdData[4, 3].Value = (Double.Parse(tbResult.Rows[1][2].ToString()) * (0.1)).ToString("0.0");
                    grdData[5, 3].Value = (Double.Parse(tbResult.Rows[1][3].ToString()) * (0.1)).ToString("0.0");

                    grdData[14, 2].Value = (Double.Parse(tbResult.Rows[0][4].ToString()) * (0.1)).ToString("0.0");
                    grdData[15, 2].Value = (Math.Pow(Double.Parse(tbResult.Rows[0][5].ToString()), 0.5) * (0.1)).ToString("0.0");
                    grdData[14, 3].Value = (Double.Parse(tbResult.Rows[1][4].ToString()) * (0.1)).ToString("0.0");
                    grdData[15, 3].Value = (Double.Parse(tbResult.Rows[1][5].ToString()) * (0.1)).ToString("0.0");

                    for (int i = 0; i < 7; i++)
                    {
                        grdData[i * 2 + 2, 4].Value = (Double.Parse(tbResult.Rows[2][i * 2].ToString()) * (0.1)).ToString("0.0");
                        grdData[i * 2 + 3, 4].Value = (Math.Pow(Double.Parse(tbResult.Rows[2][i * 2 + 1].ToString()), 0.5) * (0.1)).ToString("0.0");
                        grdData[i * 2 + 2, 5].Value = (Double.Parse(tbResult.Rows[3][i * 2].ToString()) * (0.1)).ToString("0.0");
                        grdData[i * 2 + 3, 5].Value = (Double.Parse(tbResult.Rows[3][i * 2 + 1].ToString()) * (0.1)).ToString("0.0");

                        grdData[i * 2 + 2, 6].Value = (Double.Parse(tbResult.Rows[4][i * 2].ToString()) * (0.1)).ToString("0.0");
                        grdData[i * 2 + 3, 6].Value = (Math.Pow(Double.Parse(tbResult.Rows[4][i * 2 + 1].ToString()), 0.5) * (0.1)).ToString("0.0");
                        grdData[i * 2 + 2, 7].Value = (Double.Parse(tbResult.Rows[5][i * 2].ToString()) * (0.1)).ToString("0.0");
                        grdData[i * 2 + 3, 7].Value = (Double.Parse(tbResult.Rows[5][i * 2 + 1].ToString()) * (0.1)).ToString("0.0");

                        grdData[i * 2 + 2, 8].Value = (Double.Parse(tbResult.Rows[6][i * 2].ToString()) * (0.01)).ToString("0.00");
                        grdData[i * 2 + 3, 8].Value = (Math.Pow(Double.Parse(tbResult.Rows[6][i * 2 + 1].ToString()), 0.5) * (0.01)).ToString("0.00");
                        grdData[i * 2 + 2, 9].Value = (Double.Parse(tbResult.Rows[7][i * 2].ToString()) * (0.01)).ToString("0.00");
                        grdData[i * 2 + 3, 9].Value = (Double.Parse(tbResult.Rows[7][i * 2 + 1].ToString()) * (0.01)).ToString("0.00");

                        grdData[i * 2 + 2, 10].Value = (Double.Parse(tbResult.Rows[8][i * 2].ToString()) * (0.01)).ToString("0.00");
                        grdData[i * 2 + 3, 10].Value = (Math.Pow(Double.Parse(tbResult.Rows[8][i * 2 + 1].ToString()), 0.5) * (0.01)).ToString("0.00");
                        grdData[i * 2 + 2, 11].Value = (Double.Parse(tbResult.Rows[9][i * 2].ToString()) * (0.01)).ToString("0.00");
                        grdData[i * 2 + 3, 11].Value = (Double.Parse(tbResult.Rows[9][i * 2 + 1].ToString()) * (0.01)).ToString("0.00");

                        if (i < 6)
                        {
                            grdData[i * 2 + 2, 13].Value = (Double.Parse(tbResult.Rows[10][i * 2].ToString()) * (0.01)).ToString("0.00");
                            grdData[i * 2 + 3, 13].Value = (Math.Pow(Double.Parse(tbResult.Rows[10][i * 2 + 1].ToString()), 0.5) * (0.01)).ToString("0.00");
                            grdData[i * 2 + 2, 14].Value = (Double.Parse(tbResult.Rows[11][i * 2].ToString()) * (0.01)).ToString("0.00");
                            grdData[i * 2 + 3, 14].Value = (Double.Parse(tbResult.Rows[11][i * 2 + 1].ToString()) * (0.01)).ToString("0.00");
                        }

                        grdData[i * 2 + 2, 15].Value = (Double.Parse(tbResult.Rows[12][i * 2].ToString()) * (0.01)).ToString("0.00");
                        grdData[i * 2 + 3, 15].Value = (Math.Pow(Double.Parse(tbResult.Rows[12][i * 2 + 1].ToString()), 0.5) * (0.01)).ToString("0.00");
                        grdData[i * 2 + 2, 16].Value = (Double.Parse(tbResult.Rows[13][i * 2].ToString()) * (0.01)).ToString("0.00");
                        grdData[i * 2 + 3, 16].Value = (Double.Parse(tbResult.Rows[13][i * 2 + 1].ToString()) * (0.01)).ToString("0.00");

                        grdData[i * 2 + 2, 17].Value = (Double.Parse(tbResult.Rows[14][i * 2].ToString()) * (0.01)).ToString("0.00");
                        grdData[i * 2 + 3, 17].Value = (Math.Pow(Double.Parse(tbResult.Rows[14][i * 2 + 1].ToString()), 0.5) * (0.01)).ToString("0.00");
                        grdData[i * 2 + 2, 18].Value = (Double.Parse(tbResult.Rows[15][i * 2].ToString()) * (0.01)).ToString("0.00");
                        grdData[i * 2 + 3, 18].Value = (Double.Parse(tbResult.Rows[15][i * 2 + 1].ToString()) * (0.01)).ToString("0.00");

                        grdData[i * 2 + 2, 19].Value = (Double.Parse(tbResult.Rows[16][i * 2].ToString()) * (0.1)).ToString("0.0");
                        grdData[i * 2 + 3, 19].Value = (Math.Pow(Double.Parse(tbResult.Rows[16][i * 2 + 1].ToString()), 0.5) * (0.1)).ToString("0.0");
                        grdData[i * 2 + 2, 20].Value = (Double.Parse(tbResult.Rows[17][i * 2].ToString()) * (0.1)).ToString("0.0");
                        grdData[i * 2 + 3, 20].Value = (Double.Parse(tbResult.Rows[17][i * 2 + 1].ToString()) * (0.1)).ToString("0.0");

                        grdData[i * 2 + 2, 21].Value = (Double.Parse(tbResult.Rows[18][i * 2].ToString()) * (0.1)).ToString("0.0");
                        grdData[i * 2 + 3, 21].Value = (Math.Pow(Double.Parse(tbResult.Rows[18][i * 2 + 1].ToString()), 0.5) * (0.1)).ToString("0.0");
                        grdData[i * 2 + 2, 22].Value = (Double.Parse(tbResult.Rows[19][i * 2].ToString()) * (0.1)).ToString("0.0");
                        grdData[i * 2 + 3, 22].Value = (Double.Parse(tbResult.Rows[19][i * 2 + 1].ToString()) * (0.1)).ToString("0.0");

                        grdData[i * 2 + 2, 23].Value = ((int)Math.Round(Double.Parse(tbResult.Rows[20][i * 2].ToString()))).ToString();
                        grdData[i * 2 + 3, 23].Value = ((int)Math.Pow(Math.Round(Double.Parse(tbResult.Rows[20][i * 2 + 1].ToString())), 0.5)).ToString();
                        grdData[i * 2 + 2, 24].Value = ((int)Math.Round(Double.Parse(tbResult.Rows[21][i * 2].ToString()))).ToString();
                        grdData[i * 2 + 3, 24].Value = ((int)Math.Round(Double.Parse(tbResult.Rows[21][i * 2 + 1].ToString()))).ToString();

                        grdData[i * 2 + 2, 25].Value = ((int)Math.Round(Double.Parse(tbResult.Rows[22][i * 2].ToString()))).ToString();
                        grdData[i * 2 + 3, 25].Value = ((int)Math.Pow(Math.Round(Double.Parse(tbResult.Rows[22][i * 2 + 1].ToString())), 0.5)).ToString();
                        grdData[i * 2 + 2, 26].Value = ((int)Math.Round(Double.Parse(tbResult.Rows[23][i * 2].ToString()))).ToString();
                        grdData[i * 2 + 3, 26].Value = ((int)Math.Round(Double.Parse(tbResult.Rows[23][i * 2 + 1].ToString()))).ToString();

                        grdData[i * 2 + 2, 27].Value = ((int)Math.Round(Double.Parse(tbResult.Rows[24][i * 2].ToString()))).ToString();
                        grdData[i * 2 + 3, 27].Value = ((int)Math.Pow(Math.Round(Double.Parse(tbResult.Rows[24][i * 2 + 1].ToString())), 0.5)).ToString();
                        grdData[i * 2 + 2, 28].Value = ((int)Math.Round(Double.Parse(tbResult.Rows[25][i * 2].ToString()))).ToString();
                        grdData[i * 2 + 3, 28].Value = ((int)Math.Round(Double.Parse(tbResult.Rows[25][i * 2 + 1].ToString()))).ToString();

                        grdData[i * 2 + 2, 29].Value = ((int)Math.Round(Double.Parse(tbResult.Rows[26][i * 2].ToString()))).ToString();
                        grdData[i * 2 + 3, 29].Value = ((int)Math.Pow(Math.Round(Double.Parse(tbResult.Rows[26][i * 2 + 1].ToString())), 0.5)).ToString();
                        grdData[i * 2 + 2, 30].Value = ((int)Math.Round(Double.Parse(tbResult.Rows[27][i * 2].ToString()))).ToString();
                        grdData[i * 2 + 3, 30].Value = ((int)Math.Round(Double.Parse(tbResult.Rows[27][i * 2 + 1].ToString()))).ToString();

                        grdData[i * 2 + 2, 31].Value = ((int)Math.Round(Double.Parse(tbResult.Rows[28][i * 2].ToString()))).ToString();
                        grdData[i * 2 + 3, 31].Value = ((int)Math.Pow(Math.Round(Double.Parse(tbResult.Rows[28][i * 2 + 1].ToString())), 0.5)).ToString();
                        grdData[i * 2 + 2, 32].Value = ((int)Math.Round(Double.Parse(tbResult.Rows[29][i * 2].ToString()))).ToString();
                        grdData[i * 2 + 3, 32].Value = ((int)Math.Round(Double.Parse(tbResult.Rows[29][i * 2 + 1].ToString()))).ToString();

                        grdData[i * 2 + 2, 33].Value = ((int)Math.Round(Double.Parse(tbResult.Rows[30][i * 2].ToString()))).ToString();
                        grdData[i * 2 + 3, 33].Value = ((int)Math.Pow(Math.Round(Double.Parse(tbResult.Rows[30][i * 2 + 1].ToString())), 0.5)).ToString();
                        grdData[i * 2 + 2, 34].Value = ((int)Math.Round(Double.Parse(tbResult.Rows[31][i * 2].ToString()))).ToString();
                        grdData[i * 2 + 3, 34].Value = ((int)Math.Round(Double.Parse(tbResult.Rows[31][i * 2 + 1].ToString()))).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("End of Search()", ex);
                MessageBox.Show("ÉfÅ[É^åüçıåvéZÇÃéûÇ…ÉGÉâÅ[Ç™î≠ê∂ÇµÇ‹ÇµÇΩÅBä«óùé“Ç…í ímÇµÇƒâ∫Ç≥Ç¢ÅB", "í ím");
            }
            Cursor = Cursors.Default;
        }

        private DataTable CalculateRollingTotal(DataTable tbData)
        {
            DataTable tbResult = new DataTable();

            int resultCount = tbData.Rows.Count;

            for (int i = 0; i < 14; i++)
            {
                tbResult.Columns.Add();
            }

            for (int i = 0; i < 32; i++)
            {
                tbResult.Rows.Add(tbResult.NewRow());
            }

            if (tbData == null || resultCount < 1)
            {
                return tbResult;
            }

            try
            {
                int[][] tempMinMax;
                double[][] tempSumTB = new double[34][];
                tempMinMax = new int[34][];
                for (int i = 0; i < 34; i++)
                {
                    tempMinMax[i] = new int[14];
                    tempSumTB[i] = new double[14];

                    for (int j = 0; j < 13; j += 2)
                    {
                        tempMinMax[i][j] = Int32.MaxValue;
                        tempMinMax[i][j + 1] = 0;

                        tempSumTB[i][j] = 0;
                        tempSumTB[i][j + 1] = 0;
                    }
                }

                for (int i = 0; i < resultCount; i++)
                {
                    try
                    {
                        DataRow row = tbData.Rows[i];

                        int R073 = (Int16)row["R073_ëeèoë§â∑ìx_ÇqÇTÇcÇs_è„ñ "];
                        tempMinMax[0][0] = R073 < tempMinMax[0][0] ? R073 : tempMinMax[0][0];
                        tempMinMax[0][1] = R073 > tempMinMax[0][1] ? R073 : tempMinMax[0][1];
                        tempSumTB[0][0] += R073;
                        int R0073 = (Int16)row["R0073_édè„ì¸ë§â∑ìx_FET"];
                        tempMinMax[0][2] = R0073 < tempMinMax[0][2] ? R0073 : tempMinMax[0][2];
                        tempMinMax[0][3] = R0073 > tempMinMax[0][3] ? R0073 : tempMinMax[0][3];
                        tempSumTB[0][2] += R0073;

                        int R0071 = (Int16)row["R0071_édè„é¿ê—â∑ìx_FDT"];
                        tempMinMax[0][4] = R0071 < tempMinMax[0][4] ? R0071 : tempMinMax[0][4];
                        tempMinMax[0][5] = R0071 > tempMinMax[0][5] ? R0071 : tempMinMax[0][5];
                        tempSumTB[0][4] += R0071;
                        #region "for (int j = 0; j < 7; j++)"
                        for (int j = 0; j < 7; j++)
                        {
                            try
                            {
                                int T800_I2_07_01_F = (Int16)row["T800_I2_07_01_F" + (j + 1).ToString()];
                                tempMinMax[1][j * 2] = T800_I2_07_01_F < tempMinMax[1][j * 2] ? T800_I2_07_01_F : tempMinMax[1][j * 2];
                                tempMinMax[1][j * 2 + 1] = T800_I2_07_01_F > tempMinMax[1][j * 2 + 1] ? T800_I2_07_01_F : tempMinMax[1][j * 2 + 1];
                                tempSumTB[1][j * 2] += T800_I2_07_01_F;

                                int T1800_I2_07_01_F = (Int16)row["T1800_I2_07_01_F" + (j + 1).ToString()];
                                tempMinMax[2][j * 2] = T1800_I2_07_01_F < tempMinMax[2][j * 2] ? T1800_I2_07_01_F : tempMinMax[2][j * 2];
                                tempMinMax[2][j * 2 + 1] = T1800_I2_07_01_F > tempMinMax[2][j * 2 + 1] ? T1800_I2_07_01_F : tempMinMax[2][j * 2 + 1];
                                tempSumTB[2][j * 2] += T1800_I2_07_01_F;

                                int T800_I2_07_02_F = (Int16)row["T800_I2_07_02_F" + (j + 1).ToString()];
                                tempMinMax[3][j * 2] = T800_I2_07_02_F < tempMinMax[3][j * 2] ? T800_I2_07_02_F : tempMinMax[3][j * 2];
                                tempMinMax[3][j * 2 + 1] = T800_I2_07_02_F > tempMinMax[3][j * 2 + 1] ? T800_I2_07_02_F : tempMinMax[3][j * 2 + 1];
                                tempSumTB[3][j * 2] += T800_I2_07_02_F;

                                int T1800_I2_14_01_F = (Int16)row["T1800_I2_14_01_F" + (j + 1).ToString()];
                                tempMinMax[4][j * 2] = T1800_I2_14_01_F < tempMinMax[4][j * 2] ? T1800_I2_14_01_F : tempMinMax[4][j * 2];
                                tempMinMax[4][j * 2 + 1] = T1800_I2_14_01_F > tempMinMax[4][j * 2 + 1] ? T1800_I2_14_01_F : tempMinMax[4][j * 2 + 1];
                                tempSumTB[4][j * 2] += T1800_I2_14_01_F;

                                if (j < 6)
                                {
                                    int T800_I2_06_01_F = (Int16)row["T800_I2_06_01_F" + (j + 1).ToString() + "F" + (j + 2).ToString()];
                                    tempMinMax[5][j * 2] = T800_I2_06_01_F < tempMinMax[5][j * 2] ? T800_I2_06_01_F : tempMinMax[5][j * 2];
                                    tempMinMax[5][j * 2 + 1] = T800_I2_06_01_F > tempMinMax[5][j * 2 + 1] ? T800_I2_06_01_F : tempMinMax[5][j * 2 + 1];
                                    tempSumTB[5][j * 2] += T800_I2_06_01_F;
                                }

                                int T800_I2_07_03_F = (Int16)row["T800_I2_07_03_F" + (j + 1).ToString()];
                                tempMinMax[6][j * 2] = T800_I2_07_03_F < tempMinMax[6][j * 2] ? T800_I2_07_03_F : tempMinMax[6][j * 2];
                                tempMinMax[6][j * 2 + 1] = T800_I2_07_03_F > tempMinMax[6][j * 2 + 1] ? T800_I2_07_03_F : tempMinMax[6][j * 2 + 1];
                                tempSumTB[6][j * 2] += T800_I2_07_03_F;

                                int T1800_I2_14_02_F = (Int16)row["T1800_I2_14_02_F" + (j + 1).ToString()];
                                tempMinMax[7][j * 2] = T1800_I2_14_02_F < tempMinMax[7][j * 2] ? T1800_I2_14_02_F : tempMinMax[7][j * 2];
                                tempMinMax[7][j * 2 + 1] = T1800_I2_14_02_F > tempMinMax[7][j * 2 + 1] ? T1800_I2_14_02_F : tempMinMax[7][j * 2 + 1];
                                tempSumTB[7][j * 2] += T1800_I2_14_02_F;

                                int T800_I2_07_04_F = (Int16)row["T800_I2_07_04_F" + (j + 1).ToString()];
                                tempMinMax[8][j * 2] = T800_I2_07_04_F < tempMinMax[8][j * 2] ? T800_I2_07_04_F : tempMinMax[8][j * 2];
                                tempMinMax[8][j * 2 + 1] = T800_I2_07_04_F > tempMinMax[8][j * 2 + 1] ? T800_I2_07_04_F : tempMinMax[8][j * 2 + 1];
                                tempSumTB[8][j * 2] += T800_I2_07_04_F;

                                int T1800_I2_07_02_F = (Int16)row["T1800_I2_07_02_F" + (j + 1).ToString()];
                                tempMinMax[9][j * 2] = T1800_I2_07_02_F < tempMinMax[9][j * 2] ? T1800_I2_07_02_F : tempMinMax[9][j * 2];
                                tempMinMax[9][j * 2 + 1] = T1800_I2_07_02_F > tempMinMax[9][j * 2 + 1] ? T1800_I2_07_02_F : tempMinMax[9][j * 2 + 1];
                                tempSumTB[9][j * 2] += T1800_I2_07_02_F;

                                int T800_I2_07_05_F = (Int16)row["T800_I2_07_05_F" + (j + 1).ToString()];
                                tempMinMax[10][j * 2] = T800_I2_07_05_F < tempMinMax[10][j * 2] ? T800_I2_07_05_F : tempMinMax[10][j * 2];
                                tempMinMax[10][j * 2 + 1] = T800_I2_07_05_F > tempMinMax[10][j * 2 + 1] ? T800_I2_07_05_F : tempMinMax[10][j * 2 + 1];
                                tempSumTB[10][j * 2] += T800_I2_07_05_F;

                                int T1800_I2_07_03_F = (Int16)row["T1800_I2_07_03_F" + (j + 1).ToString()];
                                tempMinMax[11][j * 2] = T1800_I2_07_03_F < tempMinMax[11][j * 2] ? T1800_I2_07_03_F : tempMinMax[11][j * 2];
                                tempMinMax[11][j * 2 + 1] = T1800_I2_07_03_F > tempMinMax[11][j * 2 + 1] ? T1800_I2_07_03_F : tempMinMax[11][j * 2 + 1];
                                tempSumTB[11][j * 2] += T1800_I2_07_03_F;

                                int T800_I2_07_06_F = (Int16)row["T800_I2_07_06_F" + (j + 1).ToString()];
                                tempMinMax[12][j * 2] = T800_I2_07_06_F < tempMinMax[12][j * 2] ? T800_I2_07_06_F : tempMinMax[12][j * 2];
                                tempMinMax[12][j * 2 + 1] = T800_I2_07_06_F > tempMinMax[12][j * 2 + 1] ? T800_I2_07_06_F : tempMinMax[12][j * 2 + 1];
                                tempSumTB[12][j * 2] += T800_I2_07_06_F;

                                int T1800_I2_07_04_F = (Int16)row["T1800_I2_07_04_F" + (j + 1).ToString()];
                                tempMinMax[13][j * 2] = T1800_I2_07_04_F < tempMinMax[13][j * 2] ? T1800_I2_07_04_F : tempMinMax[13][j * 2];
                                tempMinMax[13][j * 2 + 1] = T1800_I2_07_04_F > tempMinMax[13][j * 2 + 1] ? T1800_I2_07_04_F : tempMinMax[13][j * 2 + 1];
                                tempSumTB[13][j * 2] += T1800_I2_07_04_F;

                                int T800_I2_07_07_F = (Int16)row["T800_I2_07_07_F" + (j + 1).ToString()];
                                tempMinMax[14][j * 2] = T800_I2_07_07_F < tempMinMax[14][j * 2] ? T800_I2_07_07_F : tempMinMax[14][j * 2];
                                tempMinMax[14][j * 2 + 1] = T800_I2_07_07_F > tempMinMax[14][j * 2 + 1] ? T800_I2_07_07_F : tempMinMax[14][j * 2 + 1];
                                tempSumTB[14][j * 2] += T800_I2_07_07_F;

                                int T1800_I2_14_03_F = (Int16)row["T1800_I2_14_03_F" + (j + 1).ToString()];
                                tempMinMax[15][j * 2] = T1800_I2_14_03_F < tempMinMax[15][j * 2] ? T1800_I2_14_03_F : tempMinMax[15][j * 2];
                                tempMinMax[15][j * 2 + 1] = T1800_I2_14_03_F > tempMinMax[15][j * 2 + 1] ? T1800_I2_14_03_F : tempMinMax[15][j * 2 + 1];
                                tempSumTB[15][j * 2] += T1800_I2_14_03_F;
                            }
                            catch (Exception ex)
                            {
                                log.Error("(1)Inner: for (int j = 0; j < 7; j++). Current value j = " + j.ToString(), ex);
                                throw ex;
                            }
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        log.Error("(1)Inner: for (int i = 0; i < tbData.Rows.Count; i++). Current value i = " + i.ToString(), ex);
                        throw ex;
                    }
                }

                tbResult.Rows[0][0] = tempSumTB[0][1] = tempSumTB[0][0] / (resultCount * 1.0);
                tbResult.Rows[1][0] = tempMinMax[0][0];
                tbResult.Rows[1][1] = tempMinMax[0][1];
                tempSumTB[0][0] = 0;

                tbResult.Rows[0][2] = tempSumTB[0][3] = tempSumTB[0][2] / (resultCount * 1.0);
                tbResult.Rows[1][2] = tempMinMax[0][2];
                tbResult.Rows[1][3] = tempMinMax[0][3];
                tempSumTB[0][2] = 0;

                tbResult.Rows[0][4] = tempSumTB[0][5] = tempSumTB[0][4] / (resultCount * 1.0);
                tbResult.Rows[1][4] = tempMinMax[0][4];
                tbResult.Rows[1][5] = tempMinMax[0][5];
                tempSumTB[0][4] = 0;

                for (int i = 0; i < 7; i++)
                {
                    try
                    {
                        tbResult.Rows[2][i * 2] = tempSumTB[1][i * 2 + 1] = tempSumTB[1][i * 2] / (resultCount * 1.0);
                        tbResult.Rows[3][i * 2] = tempMinMax[1][i * 2];
                        tbResult.Rows[3][i * 2 + 1] = tempMinMax[1][i * 2 + 1];
                        tempSumTB[1][i * 2] = 0;

                        tbResult.Rows[4][i * 2] = tempSumTB[2][i * 2 + 1] = tempSumTB[2][i * 2] / (resultCount * 1.0);
                        tbResult.Rows[5][i * 2] = tempMinMax[2][i * 2];
                        tbResult.Rows[5][i * 2 + 1] = tempMinMax[2][i * 2 + 1];
                        tempSumTB[2][i * 2] = 0;

                        tbResult.Rows[6][i * 2] = tempSumTB[3][i * 2 + 1] = tempSumTB[3][i * 2] / (resultCount * 1.0);
                        tbResult.Rows[7][i * 2] = tempMinMax[3][i * 2];
                        tbResult.Rows[7][i * 2 + 1] = tempMinMax[3][i * 2 + 1];
                        tempSumTB[3][i * 2] = 0;

                        tbResult.Rows[8][i * 2] = tempSumTB[4][i * 2 + 1] = tempSumTB[4][i * 2] / (resultCount * 1.0);
                        tbResult.Rows[9][i * 2] = tempMinMax[4][i * 2];
                        tbResult.Rows[9][i * 2 + 1] = tempMinMax[4][i * 2 + 1];
                        tempSumTB[4][i * 2] = 0;

                        if (i < 6)
                        {
                            tbResult.Rows[10][i * 2] = tempSumTB[5][i * 2 + 1] = tempSumTB[5][i * 2] / (resultCount * 1.0);
                            tbResult.Rows[11][i * 2] = tempMinMax[5][i * 2];
                            tbResult.Rows[11][i * 2 + 1] = tempMinMax[5][i * 2 + 1];
                            tempSumTB[5][i * 2] = 0;
                        }

                        tbResult.Rows[12][i * 2] = tempSumTB[6][i * 2 + 1] = tempSumTB[6][i * 2] / (resultCount * 1.0);
                        tbResult.Rows[13][i * 2] = tempMinMax[6][i * 2];
                        tbResult.Rows[13][i * 2 + 1] = tempMinMax[6][i * 2 + 1];
                        tempSumTB[6][i * 2] = 0;

                        tbResult.Rows[14][i * 2] = tempSumTB[7][i * 2 + 1] = tempSumTB[7][i * 2] / (resultCount * 1.0);
                        tbResult.Rows[15][i * 2] = tempMinMax[7][i * 2];
                        tbResult.Rows[15][i * 2 + 1] = tempMinMax[7][i * 2 + 1];
                        tempSumTB[7][i * 2] = 0;

                        tbResult.Rows[16][i * 2] = tempSumTB[8][i * 2 + 1] = tempSumTB[8][i * 2] / (resultCount * 1.0);
                        tbResult.Rows[17][i * 2] = tempMinMax[8][i * 2];
                        tbResult.Rows[17][i * 2 + 1] = tempMinMax[8][i * 2 + 1];
                        tempSumTB[8][i * 2] = 0;

                        tbResult.Rows[18][i * 2] = tempSumTB[9][i * 2 + 1] = tempSumTB[9][i * 2] / (resultCount * 1.0);
                        tbResult.Rows[19][i * 2] = tempMinMax[9][i * 2];
                        tbResult.Rows[19][i * 2 + 1] = tempMinMax[9][i * 2 + 1];
                        tempSumTB[9][i * 2] = 0;

                        tbResult.Rows[20][i * 2] = tempSumTB[10][i * 2 + 1] = tempSumTB[10][i * 2] / (resultCount * 1.0);
                        tbResult.Rows[21][i * 2] = tempMinMax[10][i * 2];
                        tbResult.Rows[21][i * 2 + 1] = tempMinMax[10][i * 2 + 1];
                        tempSumTB[10][i * 2] = 0;

                        tbResult.Rows[22][i * 2] = tempSumTB[11][i * 2 + 1] = tempSumTB[11][i * 2] / (resultCount * 1.0);
                        tbResult.Rows[23][i * 2] = tempMinMax[11][i * 2];
                        tbResult.Rows[23][i * 2 + 1] = tempMinMax[11][i * 2 + 1];
                        tempSumTB[11][i * 2] = 0;

                        tbResult.Rows[24][i * 2] = tempSumTB[12][i * 2 + 1] = tempSumTB[12][i * 2] / (resultCount * 1.0);
                        tbResult.Rows[25][i * 2] = tempMinMax[12][i * 2];
                        tbResult.Rows[25][i * 2 + 1] = tempMinMax[12][i * 2 + 1];
                        tempSumTB[12][i * 2] = 0;

                        tbResult.Rows[26][i * 2] = tempSumTB[13][i * 2 + 1] = tempSumTB[13][i * 2] / (resultCount * 1.0);
                        tbResult.Rows[27][i * 2] = tempMinMax[13][i * 2];
                        tbResult.Rows[27][i * 2 + 1] = tempMinMax[13][i * 2 + 1];
                        tempSumTB[13][i * 2] = 0;

                        tbResult.Rows[28][i * 2] = tempSumTB[14][i * 2 + 1] = tempSumTB[14][i * 2] / (resultCount * 1.0);
                        tbResult.Rows[29][i * 2] = tempMinMax[14][i * 2];
                        tbResult.Rows[29][i * 2 + 1] = tempMinMax[14][i * 2 + 1];
                        tempSumTB[14][i * 2] = 0;

                        tbResult.Rows[30][i * 2] = tempSumTB[15][i * 2 + 1] = tempSumTB[15][i * 2] / (resultCount * 1.0);
                        tbResult.Rows[31][i * 2] = tempMinMax[15][i * 2];
                        tbResult.Rows[31][i * 2 + 1] = tempMinMax[15][i * 2 + 1];
                        tempSumTB[15][i * 2] = 0;
                    }
                    catch (Exception ex)
                    {
                        log.Error("(2)Inner: for (int i = 0; i < 7; i++). Current value i = " + i.ToString(), ex);
                        throw ex;
                    }
                }

                foreach (DataRow row in tbData.Rows)
                {
                    try
                    {
                        int R073 = (Int16)row["R073_ëeèoë§â∑ìx_ÇqÇTÇcÇs_è„ñ "];
                        tempSumTB[0][0] += Math.Pow(R073 - tempSumTB[0][1], 2);
                        int R0073 = (Int16)row["R0073_édè„ì¸ë§â∑ìx_FET"];
                        tempSumTB[0][2] += Math.Pow(R0073 - tempSumTB[0][3], 2);
                        int R0071 = (Int16)row["R0071_édè„é¿ê—â∑ìx_FDT"];
                        tempSumTB[0][4] += Math.Pow(R0071 - tempSumTB[0][5], 2);

                        for (int i = 0; i < 7; i++)
                        {
                            try
                            {
                                int T800_I2_07_01_F = (Int16)row["T800_I2_07_01_F" + (i + 1).ToString()];
                                tempSumTB[1][i * 2] += Math.Pow(T800_I2_07_01_F - tempSumTB[1][i * 2 + 1], 2);

                                int T1800_I2_07_01_F = (Int16)row["T1800_I2_07_01_F" + (i + 1).ToString()];
                                tempSumTB[2][i * 2] += Math.Pow(T1800_I2_07_01_F - tempSumTB[2][i * 2 + 1], 2);

                                int T800_I2_07_02_F = (Int16)row["T800_I2_07_02_F" + (i + 1).ToString()];
                                tempSumTB[3][i * 2] += Math.Pow(T800_I2_07_02_F - tempSumTB[3][i * 2 + 1], 2);

                                int T1800_I2_14_01_F = (Int16)row["T1800_I2_14_01_F" + (i + 1).ToString()];
                                tempSumTB[4][i * 2] += Math.Pow(T1800_I2_14_01_F - tempSumTB[4][i * 2 + 1], 2);
                                if (i < 6)
                                {
                                    int T800_I2_06_01_F = (Int16)row["T800_I2_06_01_F" + (i + 1).ToString() + "F" + (i + 2).ToString()];
                                    tempSumTB[5][i * 2] += Math.Pow(T800_I2_06_01_F - tempSumTB[5][i * 2 + 1], 2);
                                }

                                int T800_I2_07_03_F = (Int16)row["T800_I2_07_03_F" + (i + 1).ToString()];
                                tempSumTB[6][i * 2] += Math.Pow(T800_I2_07_03_F - tempSumTB[6][i * 2 + 1], 2);

                                int T1800_I2_14_02_F = (Int16)row["T1800_I2_14_02_F" + (i + 1).ToString()];
                                tempSumTB[7][i * 2] += Math.Pow(T1800_I2_14_02_F - tempSumTB[7][i * 2 + 1], 2);

                                int T800_I2_07_04_F = (Int16)row["T800_I2_07_04_F" + (i + 1).ToString()];
                                tempSumTB[8][i * 2] += Math.Pow(T800_I2_07_04_F - tempSumTB[8][i * 2 + 1], 2);

                                int T1800_I2_07_02_F = (Int16)row["T1800_I2_07_02_F" + (i + 1).ToString()];
                                tempSumTB[9][i * 2] += Math.Pow(T1800_I2_07_02_F - tempSumTB[9][i * 2 + 1], 2);

                                int T800_I2_07_05_F = (Int16)row["T800_I2_07_05_F" + (i + 1).ToString()];
                                tempSumTB[10][i * 2] += Math.Pow(T800_I2_07_05_F - tempSumTB[10][i * 2 + 1], 2);

                                int T1800_I2_07_03_F = (Int16)row["T1800_I2_07_03_F" + (i + 1).ToString()];
                                tempSumTB[11][i * 2] += Math.Pow(T1800_I2_07_03_F - tempSumTB[11][i * 2 + 1], 2);

                                int T800_I2_07_06_F = (Int16)row["T800_I2_07_06_F" + (i + 1).ToString()];
                                tempSumTB[12][i * 2] += Math.Pow(T800_I2_07_06_F - tempSumTB[12][i * 2 + 1], 2);

                                int T1800_I2_07_04_F = (Int16)row["T1800_I2_07_04_F" + (i + 1).ToString()];
                                tempSumTB[13][i * 2] += Math.Pow(T1800_I2_07_04_F - tempSumTB[13][i * 2 + 1], 2);

                                int T800_I2_07_07_F = (Int16)row["T800_I2_07_07_F" + (i + 1).ToString()];
                                tempSumTB[14][i * 2] += Math.Pow(T800_I2_07_07_F - tempSumTB[14][i * 2 + 1], 2);

                                int T1800_I2_14_03_F = (Int16)row["T1800_I2_14_03_F" + (i + 1).ToString()];
                                tempSumTB[15][i * 2] += Math.Pow(T1800_I2_14_03_F - tempSumTB[15][i * 2 + 1], 2);
                            }
                            catch (Exception ex)
                            {
                                log.Error("(3)Inner: for (int i = 0; i < 7; i++). Current value i = " + i.ToString(), ex);
                                throw ex;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error("(1)Inner: foreach (DataRow row in tbData.Rows). Current value row[0] = " + row[0], ex);
                        throw ex;
                    }
                }
                tbResult.Rows[0][1] = tempSumTB[0][0] / (resultCount * 1.0);
                tbResult.Rows[0][3] = tempSumTB[0][2] / (resultCount * 1.0);
                tbResult.Rows[0][5] = tempSumTB[0][4] / (resultCount * 1.0);

                for (int i = 0; i < 7; i++)
                {
                    try
                    {
                        tbResult.Rows[2][i * 2 + 1] = tempSumTB[1][i * 2] / (resultCount * 1.0);
                        tbResult.Rows[4][i * 2 + 1] = tempSumTB[2][i * 2] / (resultCount * 1.0);
                        tbResult.Rows[6][i * 2 + 1] = tempSumTB[3][i * 2] / (resultCount * 1.0);
                        tbResult.Rows[8][i * 2 + 1] = tempSumTB[4][i * 2] / (resultCount * 1.0);
                        if (i < 6)
                        {
                            tbResult.Rows[10][i * 2 + 1] = tempSumTB[5][i * 2] / (resultCount * 1.0);
                        }
                        tbResult.Rows[12][i * 2 + 1] = tempSumTB[6][i * 2] / (resultCount * 1.0);
                        tbResult.Rows[14][i * 2 + 1] = tempSumTB[7][i * 2] / (resultCount * 1.0);
                        tbResult.Rows[16][i * 2 + 1] = tempSumTB[8][i * 2] / (resultCount * 1.0);
                        tbResult.Rows[18][i * 2 + 1] = tempSumTB[9][i * 2] / (resultCount * 1.0);
                        tbResult.Rows[20][i * 2 + 1] = tempSumTB[10][i * 2] / (resultCount * 1.0);
                        tbResult.Rows[22][i * 2 + 1] = tempSumTB[11][i * 2] / (resultCount * 1.0);
                        tbResult.Rows[24][i * 2 + 1] = tempSumTB[12][i * 2] / (resultCount * 1.0);
                        tbResult.Rows[26][i * 2 + 1] = tempSumTB[13][i * 2] / (resultCount * 1.0);
                        tbResult.Rows[28][i * 2 + 1] = tempSumTB[14][i * 2] / (resultCount * 1.0);
                        tbResult.Rows[30][i * 2 + 1] = tempSumTB[15][i * 2] / (resultCount * 1.0);
                    }
                    catch (Exception ex)
                    {
                        log.Error("(4)Inner: for (int i = 0; i < 7; i++). Current value i = " + i.ToString(), ex);
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("End of CalculateRollingTotal.", ex);
                return null;
            }

            return tbResult;
        }
    }
}