using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Kvics.HotMill.BL;

namespace Kvics.HotMill.Forms
{
    public partial class FormWorker : SubFormFullScreen
    {
        #region Static
        private static readonly int MAX_ACTIVED_WORKERS = 24;
        #endregion

        #region Private
        private bool _IsEditMode = false;
        private bool _IsCreateMode = false;
        private TWorker _TWrkr = new TWorker();
        private int _ActivedWorkers = 0;
        #endregion

        public event EventHandler OnWorker_Changed;

        public FormWorker()
        {
            InitializeComponent();
        }

        private void DisableSortMode()
        {
            this.grdWorker.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.grdWorker.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.grdWorker.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.grdWorker.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.grdWorker.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.ClearControls();

            this._IsEditMode = false;
            this._IsCreateMode = true;
            this.txtName.ReadOnly = false;
            this.ckbActive.Enabled = true;

            this.txtName.Focus();

        }

        private void grdWorker_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                this.txtName.ReadOnly = false;
                this.ckbActive.Enabled = true;
                this._IsEditMode = true;
                this.txtName.Focus();
            }
        }

        private void ReloadList()
        {
            try
            {
                this.grdWorker.RowCount = 0;
                this._ActivedWorkers = 0;
                DataSet dtSet = _TWrkr.GetAll();
                this.grdWorker.RowCount = dtSet.Tables[0].Rows.Count;
                for (int i = 0; i < dtSet.Tables[0].Rows.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        this.grdWorker.Rows[i].DefaultCellStyle.ForeColor = Color.Lime;
                    }
                    else
                    {
                        this.grdWorker.Rows[i].DefaultCellStyle.ForeColor = Color.Yellow;
                    }
                    this.grdWorker[3, i].Style.BackColor = Color.Silver;
                    this.grdWorker[3, i].Style.ForeColor = Color.Black;
                    DataRow r = dtSet.Tables[0].Rows[i];
                    this.grdWorker[0, i].Value = i + 1;
                    this.grdWorker[1, i].Value = r[TWorker.NAME__COLUMN_NAME];
                    this.grdWorker[4, i].Value = r[TWorker.ID__COLUMN_NAME];

                    // checking actived and counting
                    if ((Int16)r[TWorker.ACTIVE__COLUMN_NAME] == 1)
                    {
                        this.grdWorker[2, i].Value = true;
                        this._ActivedWorkers++;
                    }
                    else
                    {
                        this.grdWorker[2, i].Value = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this._IsEditMode)
            {
                if ((bool)this.grdWorker.SelectedRows[0].Cells[2].Value == true && !this.ckbActive.Checked)
                {
                    this._ActivedWorkers--;
                }

                if ((bool)this.grdWorker.SelectedRows[0].Cells[2].Value == false && this.ckbActive.Checked)
                {
                    if (this._ActivedWorkers >= MAX_ACTIVED_WORKERS)
                    {
                        MessageBox.Show("圧下士数は24名を超えます。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    this._ActivedWorkers++;
                }


                _TWrkr.ID = (int)this.grdWorker.SelectedRows[0].Cells[4].Value;
                _TWrkr.Name = this.txtName.Text;
                if (this.ckbActive.Checked)
                {
                    _TWrkr.Active = 1;
                }
                else
                {
                    _TWrkr.Active = 0;
                }
                

                _TWrkr.Update();

                //Rebuild grid
                this.grdWorker.SelectedRows[0].Cells[1].Value = this.txtName.Text;

                if (_TWrkr.Active == 1)
                {
                    this.grdWorker.SelectedRows[0].Cells[2].Value = true;
                }
                else
                {
                    this.grdWorker.SelectedRows[0].Cells[2].Value = false;
                }
                
                //Clear Controls
                this.ClearControls();
            }
            else if (this._IsCreateMode)
            {
                if (this._ActivedWorkers >= MAX_ACTIVED_WORKERS && this.ckbActive.Checked)
                {
                    MessageBox.Show("圧下士数は24名を超えます。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _TWrkr.Name = this.txtName.Text;


                if (this.ckbActive.Checked)
                {
                    _TWrkr.Active = 1;
                    this._ActivedWorkers++;
                }
                else
                {
                    _TWrkr.Active = 0;
                }


                _TWrkr.Insert();

                this.ReloadList();
                
                // Clear controls
                this.ClearControls();
                
            }
            grdWorker_SelectionChanged(grdWorker, null);

            if (this.OnWorker_Changed != null)
            {
                this.OnWorker_Changed(this, e);
            }
        }
        private void ClearControls()
        {
            // Clear controls
            this.txtName.Text = string.Empty;
            this.ckbActive.Checked = true;
            this.txtName.ReadOnly = true;
            this.ckbActive.Enabled = false;

            this._IsCreateMode = false;
            this._IsEditMode = false;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ClearControls();
            grdWorker_SelectionChanged(grdWorker, null);
        }

        private void grdWorker_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < this.grdWorker.Rows.Count; i++)
            {
                this.grdWorker[0, i].Value = i + 1;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdWorker_Paint(object sender, PaintEventArgs e)
        {
            Point topleft = new Point(0, 0);
            Point topright = new Point(this.grdWorker.Width - 1, 0);
            Point bottomleft = new Point(0, this.grdWorker.Height - 1);
            Point bottomfight = new Point(this.grdWorker.Width - 1, this.grdWorker.Height - 1);

            e.Graphics.DrawLines(new Pen(this.grdWorker.GridColor), new Point[] { topleft, topright, bottomfight, bottomleft, topleft });
        }

        private void grdWorker_SelectionChanged(object sender, EventArgs e)
        {
            if (grdWorker.SelectedRows.Count > 0)
            {
                int rowIndex = grdWorker.SelectedRows[0].Index;
                if (rowIndex >= 0 && this.grdWorker[1, rowIndex].Value != null)
                {
                    this.txtName.ReadOnly = true;
                    this.ckbActive.Enabled = false;

                    this.txtName.Text = this.grdWorker[1, rowIndex].Value.ToString();
                    this.ckbActive.Checked = (bool)this.grdWorker[2, rowIndex].Value;

                    this._IsCreateMode = false;
                    this._IsEditMode = false;
                }
            }
        }

        private void grdWorker_Resize(object sender, EventArgs e)
        {
            if (this.grdWorker.ColumnCount < 1 || this.Width < 100)
            {
                return;
            }
            this.grdWorker.SuspendLayout();
            this.SuspendLayout();

            int verticalScrollBarWidth = 0;
            int innerGridHeight = this.grdWorker.ColumnHeadersHeight;
            int innerGridWidth = 0;

            for (int i = 0, length = this.grdWorker.RowCount; i < length; i++)
            {
                innerGridHeight += this.grdWorker.Rows[i].Height;
            }
            for (int i = 0, length = this.grdWorker.ColumnCount - 1; i < length; i++)
            {
                innerGridWidth += this.grdWorker.Columns[i].Width;
            }

            if (innerGridHeight > this.grdWorker.Height - 2)
            {
                verticalScrollBarWidth = System.Windows.Forms.SystemInformation.VerticalScrollBarWidth;
            }

            if (innerGridWidth < 1 || innerGridHeight < 1)
            {
                return;
            }

            double scaleWidth = 0;
            scaleWidth = ((this.grdWorker.Width - verticalScrollBarWidth - 2) * 1.0) / ((innerGridWidth) * 1.0);

            double tempWidthDouble = 0;
            int tempWidthInt = 0;
            innerGridWidth = 0;// this.grdWorker.RowHeadersWidth;

            for (int i = 0; i < this.grdWorker.ColumnCount - 2; i++)
            {
                tempWidthDouble = this.grdWorker.Columns[i].Width * scaleWidth;
                tempWidthInt = Convert.ToInt32(tempWidthDouble);
                if (tempWidthInt > tempWidthDouble)
                {
                    tempWidthInt--;
                }
                innerGridWidth += tempWidthInt;
                this.grdWorker.Columns[i].Width = tempWidthInt;
            }
            grdWorker.Columns[this.grdWorker.ColumnCount - 2].Width = grdWorker.Width - 3 - innerGridWidth - verticalScrollBarWidth;// +tempWidthInt;

            this.grdWorker.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void FormWorker_Load(object sender, EventArgs e)
        {
            try
            {
                this.DisableSortMode();

                this.ReloadList();
                this.ClearControls();
                if (this.grdWorker.RowCount > 0)
                {
                    this.grdWorker.Rows[0].Selected = true;
                    this.grdWorker_SelectionChanged(this.grdWorker, null);
                }
            }
            catch (Exception)
            {
                MainForm.ShowError(HotMillErrorType.DATABASE_ERROR);
                this.Close();
            }
        }
    }
}