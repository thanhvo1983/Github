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
    public partial class FormCoilDetailView : SubFormFullScreen
    {
        private static readonly ILog log = Log.Instance.GetLogger(typeof(FormCoilDetailView));

        public FormCoilDetailView()
        {
            //PresetGrid();
        }
        public FormCoilDetailView(string coilNo, int year)
        {
            InitializeComponent();
            PresetGrid(coilNo, year);
        
        }
        private void PresetGrid(string coilNo, int year)
        {
            try
            {
                this.grdData.ColumnCount = 10;
                this.grdData.RowCount = 18;

                Color backColor = Color.Black;
                Color foreColor = Color.White;
                Color selectionBackColor = Color.DimGray;
                Color selectionForeColor = Color.Black;

                for (int i = 0, size = this.grdData.ColumnCount; i < size; i++)
                {
                    this.grdData[i, 0] = new KvicsDataGridViewHeaderCell();
                }
                this.grdData[2, 0].Value = "F１";
                this.grdData[3, 0].Value = "F２";
                this.grdData[4, 0].Value = "F３";
                this.grdData[5, 0].Value = "F４";
                this.grdData[6, 0].Value = "F５";
                this.grdData[7, 0].Value = "F６";
                this.grdData[8, 0].Value = "F７";

                this.grdData[0, 0] = new KvicsDataGridViewHeaderMergeCell(1, 1, backColor, foreColor);
                this.grdData[0, 1] = new KvicsDataGridViewHeaderMergeCell(1, 1, backColor, foreColor);
                this.grdData[9, 1] = new KvicsDataGridViewHeaderMergeCell(2, 1, backColor, foreColor);
                for (int i = 2, size = this.grdData.RowCount; i < size; i += 2)
                {
                    this.grdData[0, i] = new KvicsDataGridViewHeaderMergeCell(2, 1, backColor, foreColor);
                    this.grdData[9, i] = new KvicsDataGridViewHeaderMergeCell(2, 1, backColor, foreColor);
                }

                for (int i = 0, size = this.grdData.RowCount; i < size; i++)
                {
                    this.grdData[1, i] = new KvicsDataGridViewHeaderCell();
                }

                this.grdData[0, 1].Value = "ロール種";
                this.grdData[0, 2].Value = "出側温度";
                this.grdData[0, 4].Value = "圧下位置";
                this.grdData[0, 6].Value = "板厚";
                this.grdData[0, 8].Value = "ロール速度";
                this.grdData[0, 10].Value = "シフト量";
                this.grdData[0, 12].Value = "ＨＣδ";
                this.grdData[0, 14].Value = "ベンダー力";
                this.grdData[0, 16].Value = "圧下位置差";

                for (int i = 2, size = this.grdData.RowCount - 2; i < size; i += 2)
                {
                    this.grdData[1, i].Value = "設定";
                    this.grdData[1, i + 1].Value = "同一1";
                }

                this.grdData[1, 16].Value = "";
                this.grdData[1, 17].Value = "設定";

                for (int i = 2, size = this.grdData.ColumnCount - 1; i < size; i++)
                {
                    this.grdData.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.grdData[i, 16] = new KvicsDataGridViewHeaderCell();
                }
                this.grdData[2, 16].Value = "F１-F２";
                this.grdData[3, 16].Value = "F２-F３";
                this.grdData[4, 16].Value = "F３-F４";
                this.grdData[5, 16].Value = "F４-F５";
                this.grdData[6, 16].Value = "F５-F６";
                this.grdData[7, 16].Value = "F６-F７";

                this.grdData[9, 2].Value = "℃";
                this.grdData[9, 4].Value = "ｍｍ";
                this.grdData[9, 6].Value = "ｍｍ";
                this.grdData[9, 8].Value = "ｍｐｍ";
                this.grdData[9, 10].Value = "ｍｍ";
                this.grdData[9, 12].Value = "ｍｍ";
                this.grdData[9, 14].Value = "Ton/CHOCK";
                this.grdData[9, 16].Value = "ｍｍ";

                this.grdData.Columns[0].Width = 200;
                this.grdData.Columns[1].Width = 100;
                this.grdData.Columns[9].Width = 220;

                this.grdData.Rows[0].Height = 50;
                this.grdData.Rows[16].Height = 50;

                for (int i = 1; i < this.grdData.RowCount; i += 2)
                {
                    this.grdData.Rows[i - 1].DefaultCellStyle.ForeColor = Color.Lime;
                    this.grdData.Rows[i - 1].DefaultCellStyle.SelectionForeColor = Color.Black;
                    this.grdData.Rows[i].DefaultCellStyle.ForeColor = Color.Yellow;
                    this.grdData.Rows[i].DefaultCellStyle.SelectionForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                log.Error("Repair grid error", ex);
                MessageBox.Show("データ出力の時にエラーが発生しました。管理者に通知して下さい。", "通知");
                return;
            }

            #region Data
            T1800 t1800;
            T900 t900;
            T800 t800;
            TWorker tWorker;

            T900_C2_07 t900_C2_07_543;
            T800_I2_07 t800_I2_07_97;
            T1800_I2_07 t1800_I2_07_75;
            T800_I2_07 t800_I2_07_343;
            T1800_I2_14 t1800_I2_14_195;
            T800_I2_07 t800_I2_07_121;
            T1800_I2_14 t1800_I2_14_97;
            T800_I2_07 t800_I2_07_149;
            T1800_I2_07 t1800_I2_07_125;
            T800_I2_07 t800_I2_07_385;
            T1800_I2_07 t1800_I2_07_223;
            T800_I2_07 t800_I2_07_399;
            T1800_I2_07 t1800_I2_07_227;
            T800_I2_07 t800_I2_07_413;
            T1800_I2_14 t1800_I2_14_251;
            T800_I2_06 t800_I2_06_319;

            try
            {
                t1800 = T1800.GetCoilDetailOfYear(coilNo, year);
                t900 = T900.GetCoilDetailOfYear(coilNo, year);
                t800 = T800.GetCoilDetailOfYear(coilNo, year);
                tWorker = t1800 == null ? null : (new TWorker(t1800.Worker_ID));

                if (t1800 == null || t900 == null || t800 == null || tWorker == null)
                {
                    string nullData = t1800 == null ? "T1800" : (t900 == null ? "T900" : ( t800 == null ? "T800" : (tWorker == null ? "TWorker" : "Nothing")));
                    log.Error("Data not valid. Null value of " + nullData);
                    log.Debug("CoilNo: " + coilNo + ". Year: " + year);
                }

                t900_C2_07_543 = t900 == null ? null : t900.R543;
                t800_I2_07_97 = t800 == null ? null : t800.R097;
                t1800_I2_07_75 = t1800 == null ? null : t1800.R0075;
                t800_I2_07_343 = t800 == null ? null : t800.R343;
                t1800_I2_14_195 = t1800 == null ? null : t1800.R0195;
                t800_I2_07_121 = t800 == null ? null : t800.R121;
                t1800_I2_14_97 = t1800 == null ? null : t1800.R0097;
                t800_I2_07_149 = t800 == null ? null : t800.R149;
                t1800_I2_07_125 = t1800 == null ? null : t1800.R0125;
                t800_I2_07_385 = t800 == null ? null : t800.R385;
                t1800_I2_07_223 = t1800 == null ? null : t1800.R0223;
                t800_I2_07_399 = t800 == null ? null : t800.R399;
                t1800_I2_07_227 = t1800 == null ? null : t1800.R0237;
                t800_I2_07_413 = t800 == null ? null : t800.R413;
                t1800_I2_14_251 = t1800 == null ? null : t1800.R0251;
                t800_I2_06_319 = t800 == null ? null : t800.R319;
            }
            catch (Exception ex)
            {
                log.Error("Get data error", ex);
                MessageBox.Show("データ出力の時にエラーが発生しました。管理者に通知して下さい。", "通知");
                log.Debug("CoilNo: " + coilNo + ". Year: " + year);
                return;
            }
            #endregion

            ///////////////////////
            // fill data
            try
            {
                this.lblCoilNo.Text = t1800.R0025;
                this.lblDate.Text = new DateTime(t1800.R0033, t1800.R0035, t1800.R0037).ToString("yyyy/MM/dd");
                this.lblThickRafuba.Text = (t1800.R0091 * 0.01).ToString("0.00");
                this.lblThick.Text = (t1800.R0095 * 0.01).ToString("0.00");
                this.lblWidth.Text = t1800.R0093.ToString();
                this.lblFET.Text = (t1800.R0073_1 * 0.1).ToString("0.0");
                this.lblFDT.Text = (t1800.R0071 * 0.1).ToString("0.0");
                this.lblShift.Text = t1800.R0039.ToString();
                this.lblGroup.Text = t1800.R0041;
                this.lblWorkerName.Text = tWorker.Name;
                this.lblSteelType.Text = t900.R071;
                this.lblHeat.Text = (t900.R079).ToString();
                this.lblRDT.Text = (t800.R073_1 * 0.1).ToString("0.0");


                for (int i = 2, size = this.grdData.ColumnCount - 1; i < size; i++)
                {
                    if (t900_C2_07_543 != null)
                    {
                        string rollType = String.Empty;
                        switch (t900_C2_07_543.Rows[i - 2])
                        {
                            case "02":
                                rollType = "クロム";
                                break;
                            case "03":
                                rollType = "アダマ";
                                break;
                            case "04":
                            case "09":
                                rollType = "ハイス";
                                break;
                            case "08":
                                rollType = "グレン";
                                break;
                            default:
                                rollType = "その他";
                                break;
                        }
                        this.grdData[i, 1].Value = rollType;
                    }
                    else
                    {
                        this.grdData[i, 1].Value = string.Empty;
                    }
                    //this.grdData[i, 1].Value = t900_C2_07_543 != null ? t900_C2_07_543.Rows[i - 2] : string.Empty;
                    this.grdData[i, 2].Value = t800_I2_07_97 != null ? (t800_I2_07_97.Rows[i - 2] * 0.1).ToString("0.0;-0.0;0.0") : string.Empty;
                    this.grdData[i, 3].Value = t1800_I2_07_75 != null ? (t1800_I2_07_75.Rows[i - 2] * 0.1).ToString("0.0;-0.0;0.0") : string.Empty;
                    this.grdData[i, 4].Value = t800_I2_07_343 != null ? (t800_I2_07_343.Rows[i - 2] * 0.01).ToString("0.00;-0.00;0.00") : string.Empty;
                    this.grdData[i, 5].Value = t1800_I2_14_195 != null ? (t1800_I2_14_195.Rows[(i - 2) * 2] * 0.01).ToString("0.00;-0.00;0.00") : string.Empty;
                    this.grdData[i, 6].Value = t800_I2_07_121 != null ? (t800_I2_07_121.Rows[i - 2] * 0.01).ToString("0.00;-0.00;0.00") : string.Empty;
                    this.grdData[i, 7].Value = t1800_I2_14_97 != null ? (t1800_I2_14_97.Rows[(i - 2) * 2] * 0.01).ToString("0.00;-0.00;0.00") : string.Empty;
                    this.grdData[i, 8].Value = t800_I2_07_149 != null ? (t800_I2_07_149.Rows[i - 2] * 0.1).ToString("0.0;-0.0;0.0") : string.Empty;
                    this.grdData[i, 9].Value = t1800_I2_07_125 != null ? (t1800_I2_07_125.Rows[i - 2] * 0.1).ToString("0.0;-0.0;0.0") : string.Empty;
                    this.grdData[i, 10].Value = t800_I2_07_385 != null ? t800_I2_07_385.Rows[i - 2].ToString() : string.Empty;
                    this.grdData[i, 11].Value = t1800_I2_07_223 != null ? t1800_I2_07_223.Rows[i - 2].ToString() : string.Empty;
                    this.grdData[i, 12].Value = t800_I2_07_399 != null ? t800_I2_07_399.Rows[i - 2].ToString() : string.Empty;
                    this.grdData[i, 13].Value = t1800_I2_07_227 != null ? t1800_I2_07_227.Rows[i - 2].ToString() : string.Empty;
                    this.grdData[i, 14].Value = t800_I2_07_413 != null ? t800_I2_07_413.Rows[i - 2].ToString() : string.Empty;
                    this.grdData[i, 15].Value = t1800_I2_14_251 != null ? t1800_I2_14_251.Rows[(i - 2) * 2].ToString() : string.Empty;
                    if (i < size - 1)
                        this.grdData[i, 17].Value = t800_I2_06_319 != null ? (t800_I2_06_319.Rows[i - 2] * 0.01).ToString("0.00;-0.00;0.00") : string.Empty;
                }
                this.grdData[8, 17].Value = "";
            }
            catch (Exception ex)
            {
                log.Error("showing data error", ex);
                MessageBox.Show("データ出力の時にエラーが発生しました。管理者に通知して下さい。", "通知");
                log.Debug("CoilNo: " + coilNo + ". Year: " + year);
                return;
            }
            // end fill data
            ///////////////////////

            dataGridView1_SizeChanged(null, null);
        }

        private void dataGridView1_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width < 200 || this.grdData.RowCount < 18)
            {
                return;
            }

            try
            {
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
                    - this.grdData.Columns[9].Width
                    - verticalScrollBarWidth;

                cellWidth = Convert.ToInt32(cellWidth / 7);

                if (cellWidth * 7
                    + this.grdData.Columns[0].Width
                    + this.grdData.Columns[1].Width
                    + this.grdData.Columns[9].Width
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
            catch (Exception ex)
            {
                log.Error("Resize grid error", ex);
                MessageBox.Show("データ出力の時にエラーが発生しました。管理者に通知して下さい。", "通知");
                return;
            }
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            Point topleft = new Point(0, 0);
            Point topright = new Point(this.grdData.Width - 1, 0);
            Point bottomleft = new Point(0, this.grdData.Height - 1);
            Point bottomfight = new Point(this.grdData.Width - 1, this.grdData.Height - 1);

            e.Graphics.DrawLines(new Pen(this.grdData.GridColor), new Point[] { topleft, topright, bottomfight, bottomleft, topleft });
        }
    }
}