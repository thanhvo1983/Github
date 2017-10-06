using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Kvics.HotMill.BL;
using Kvics.DBAccess;
using Kvics.Controls;


using log4net;
using log4net.Config;


namespace Kvics.HotMill.Forms
{
    public partial class FormSearchCoilResult : SubFormFullScreen
    {
        private static readonly ILog log = Log.Instance.GetLogger(typeof(FormSearchCoilResult));

        #region Static
        public static readonly string COLUMN_NAME_1 = "Date";
        public static readonly string COLUMN_NAME_2 = "R0039_勤";
        public static readonly string COLUMN_NAME_3 = "R0041_班";
        public static readonly string COLUMN_NAME_4 = "R0043_圧延順";
        public static readonly string COLUMN_NAME_5 = "name";
        public static readonly string COLUMN_NAME_6 = "R0025_コイルＮｏ";
        public static readonly string COLUMN_NAME_7 = "R0095_ＨＣ厚";
        public static readonly string COLUMN_NAME_8 = "R0093_ＨＣ幅";
        public static readonly string COLUMN_NAME_9 = "R079_熱間強度";
        public static readonly string COLUMN_NAME_10 = "R071_鋼種名";

        public static int ItemPerPage = 20;

        #endregion

        public string currentColumnName = COLUMN_NAME_6;
        public string currentSortType = "ASC";
        public int currentColumnHeaderIndex = 5;
        private CoilSearchStructure _SearchStructure = null;
        private CoilSearchResultStructure _SearchResultStructure = null;

        private T1800 t1800 = new T1800();


        public CoilSearchStructure SearchStructure
        {
            get
            {
                return _SearchStructure;
            }
            set
            {
                this._SearchStructure = value;
            }
        }

        public CoilSearchResultStructure SearchResultStructure
        {
            get
            {
                return _SearchResultStructure;
            }
            set
            {
                this._SearchResultStructure = value;
            }
        }

        public FormSearchCoilResult()
        {
            InitializeComponent();
        }

        public FormSearchCoilResult(CoilSearchStructure searchStructure)
        {
            InitializeComponent();

            this._SearchStructure = searchStructure;
        }

        private void SearchCoilResultForm_Load(object sender, EventArgs e)
        {
            if (this._SearchStructure == null)
            {
                throw new Exception("SearchCoilResultForm must have a CoilSearchStructure");
            }

            this._SearchStructure.PageNo = 1;

            this._SearchStructure.PageSize = ItemPerPage;


            Search(currentColumnName + " " + currentSortType);

        }

        private void Search(string ColumnName)
        {
            Cursor = Cursors.WaitCursor;
            int itemsCount = 0;
            try
            {
                DataSet data_Set = t1800.GetCoilSearchData(_SearchStructure, ColumnName, out itemsCount);
                _SearchResultStructure = new CoilSearchResultStructure(data_Set, itemsCount, this._SearchStructure.PageNo, this._SearchStructure.PageSize);
            }
            catch (Exception)
            {
                MessageBox.Show("データベースに接続出来ません。若しくはデータベースは異常です。データベース又はデータベース構成を確認して下さい。");
                this.Close();
                return;
            }
            FillData(_SearchResultStructure);
            Cursor = Cursors.Default;
        }
        
        private void FillData(CoilSearchResultStructure result)
        {
            if (result == null)
            {
                throw new Exception("Function FillData(CoilSearchResultStructure) do not run with a null CoilSearchResultStructure value.");
            }

            int currentPage = result.PageNo;
            int maxPage = Convert.ToInt32(Math.Ceiling((result.ItemsCount * 1.0) / (result.PageSize * 1.0)));

            lblCoilCount.Text = result.ItemsCount.ToString();

            maxPage = maxPage < 1 ? 1 : maxPage;

            this.lblPage.Text = currentPage.ToString() + "/" + maxPage.ToString();

            if (result.ResultData == null)
            {
                grdData.RowCount = 5;
                grdData.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdData.RowHeadersVisible = true;
                

                for (int i = 0; i < 5; i++)
                {
                    grdData.Rows[i].HeaderCell.Value = (i + 1).ToString();                    
                }
            }
            else
            {
                DataTable tb = result.ResultData.Tables[0];

                //grdData.DataSource = tb;
                grdData.RowCount = tb.Rows.Count;
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    grdData.Rows[i].HeaderCell.Value = (i + 1).ToString();
                    if (i % 2 == 0)
                    {
                        grdData.Rows[i].DefaultCellStyle.BackColor = Color.Black;
                        grdData.Rows[i].DefaultCellStyle.ForeColor = Color.Lime;
                        grdData.Rows[i].DefaultCellStyle.SelectionForeColor = Color.Black;

                    }
                    else
                    {
                        grdData.Rows[i].DefaultCellStyle.BackColor = Color.Black;
                        grdData.Rows[i].DefaultCellStyle.ForeColor = Color.Yellow;
                        grdData.Rows[i].DefaultCellStyle.SelectionForeColor = Color.Black;
                    }
                    for (int j = 0; j < grdData.ColumnCount; j++)
                    {
                        if (tb.Columns[j].ColumnName.Equals(COLUMN_NAME_7, StringComparison.OrdinalIgnoreCase))
                        {
                            object obj = tb.Rows[i][j];
                            if (obj != null)
                            {
                                grdData[j, i].Value = (Convert.ToInt16(obj) * 0.01).ToString("0.00;-0.00;0.00");
                            }
                            else
                            {
                                grdData[j, i].Value = 0.00;
                            }
                        }
                        else
                        {
                            grdData[j, i].Value = tb.Rows[i][j];
                        }
                    }
                }
            }

            if (currentPage < maxPage)
            {
                this.btnNext.Enabled = true;
                this.btnLast.Enabled = true;
            }
            else
            {
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
            }

            if (currentPage > 1)
            {
                this.btnPre.Enabled = true;
                this.btnFirst.Enabled = true;
            }
            else
            {
                this.btnFirst.Enabled = false;
                this.btnPre.Enabled = false;
            }

            grdData_Resize(null, null);
        }

        private void BuildHeader()
        {
            
        }
        
        private void btnPre_Click(object sender, EventArgs e)
        {
            this._SearchStructure.PageNo--;
            Search(currentColumnName + " " + currentSortType);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this._SearchStructure.PageNo++;
            Search(currentColumnName + " " + currentSortType);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.PageDown && btnNext.Enabled)
            {
                this.btnNext_Click(btnNext, null);
            }
            else if (keyData == Keys.PageUp && btnPre.Enabled)
            {
                this.btnPre_Click(this.btnPre, null);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void grdData_Sorted(object sender, EventArgs e)
        {
            DataGridView grd = sender as DataGridView;
            string lastColumnName = currentColumnName;
            switch(currentColumnHeaderIndex)
            {
                case 0:
                    {
                        currentColumnName = COLUMN_NAME_1;
                        break;
                    }
                case 1:
                    {
                        currentColumnName = COLUMN_NAME_2;
                        break;
                    }
                case 2:
                    {
                        currentColumnName = COLUMN_NAME_3;
                        break;
                    }
                case 3:
                    {
                        currentColumnName = COLUMN_NAME_4;
                        break;
                    }
                case 4:
                    {
                        currentColumnName = COLUMN_NAME_5;
                        break;
                    }
                case 5:
                    {
                        currentColumnName = COLUMN_NAME_6;
                        break;
                    }
                case 6:
                    {
                        currentColumnName = COLUMN_NAME_7;
                        break;
                    }
                case 7:
                    {
                        currentColumnName = COLUMN_NAME_8;
                        break;
                    }
                case 8:
                    {
                        currentColumnName = COLUMN_NAME_9;
                        break;
                    }
                case 9:
                    {
                        currentColumnName = COLUMN_NAME_10;
                        break;
                    }

            }
            if (lastColumnName.Equals(currentColumnName, StringComparison.OrdinalIgnoreCase))
            {
                currentSortType = currentSortType.Equals("ASC", StringComparison.OrdinalIgnoreCase) ? "DESC" : "ASC";
            }
            else
            {
                currentSortType = "ASC";
            }
            Search(currentColumnName + " " + currentSortType);
        }

        private void grdData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                currentColumnHeaderIndex = e.ColumnIndex;
            }
        }

        private void grdData_Paint(object sender, PaintEventArgs e)
        {
            Point topleft = new Point(0, 0);
            Point topright = new Point(this.grdData.Width - 1, 0);
            Point bottomleft = new Point(0, this.grdData.Height - 1);
            Point bottomfight = new Point(this.grdData.Width - 1, this.grdData.Height - 1);

            e.Graphics.DrawLines(new Pen(this.grdData.GridColor), new Point[] { topleft, topright, bottomfight, bottomleft, topleft });
        }

        private void grdData_Resize(object sender, EventArgs e)
        {
            if (this.grdData.ColumnCount < 1 || this.Width < 200)
            {
                return;
            }
            this.grdData.SuspendLayout();
            this.SuspendLayout();

            int verticalScrollBarWidth = 0;
            int innerGridHeight = 0;
            int innerGridWidth = 0;

            for (int i = 0, length = this.grdData.RowCount; i < length; i++)
            {
                innerGridHeight += this.grdData.Rows[i].Height;
            }
            for (int i = 0, length = this.grdData.ColumnCount; i < length; i++)
            {
                innerGridWidth += this.grdData.Columns[i].Width;
            }

            if (innerGridHeight > this.grdData.Height - 2)
            {
                verticalScrollBarWidth = System.Windows.Forms.SystemInformation.VerticalScrollBarWidth;
            }

            if (!(innerGridWidth < 1 /* || innerGridHeight < 1*/))
            {

                double scaleWidth = 0;
                scaleWidth = ((this.grdData.Width - verticalScrollBarWidth - this.grdData.RowHeadersWidth) * 1.0) / ((innerGridWidth) * 1.0);

                double tempWidthDouble = 0;
                int tempWidthInt = 0;
                innerGridWidth = this.grdData.RowHeadersWidth;

                for (int i = 0; i < this.grdData.ColumnCount; i++)
                {
                    tempWidthDouble = this.grdData.Columns[i].Width * scaleWidth;
                    tempWidthInt = Convert.ToInt32(tempWidthDouble);
                    if (tempWidthInt > tempWidthDouble)
                    {
                        tempWidthInt--;
                    }
                    innerGridWidth += tempWidthInt;
                    this.grdData.Columns[i].Width = tempWidthInt;
                }
                grdData.Columns[this.grdData.ColumnCount - 1].Width = grdData.Width - 2 - innerGridWidth - verticalScrollBarWidth + tempWidthInt;
            }
            
            this.grdData.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            this._SearchStructure.PageNo = 1;
            Search(currentColumnName + " " + currentSortType);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                this._SearchStructure.PageNo = Convert.ToInt32(Math.Ceiling((_SearchResultStructure.ItemsCount * 1.0) / (_SearchResultStructure.PageSize * 1.0)));
                Search(currentColumnName + " " + currentSortType);
            }
            catch (Exception)
            {
            }
        }

        private void grdData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                ViewCoilDetail(e.RowIndex);
            }
        }

        public void ViewCoilDetail(int rowIndex)
        {
            log.Debug("Begin show coil detail.");
            DateTime date;
            string coilNo = "";
            try
            {
                date = Convert.ToDateTime(grdData[0, rowIndex].Value);
                coilNo = grdData[5, rowIndex].Value.ToString();
            }
            catch (Exception ex)
            {
                log.Error("DateTime date = Convert.ToDateTime(grdData[0, e.RowIndex].Value);string coilNo = grdData[5, e.RowIndex].Value.ToString();", ex);
                MessageBox.Show("データ出力の時にエラーが発生しました。管理者に通知して下さい。", "通知");
                log.Debug("Terminal show coil detail.");
                return;
            }
            FormCoilDetailView formCoilDetailView = new FormCoilDetailView(coilNo, date.Year);
            formCoilDetailView.Show();
            log.Debug("End show coil detail.");
        }

    }
}