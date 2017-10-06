using System.Drawing;
using System.Windows.Forms;

namespace Kvics.Controls
{
    /// <summary>
    /// This class represents a TextBoxCell that spans multiple columns.
    /// </summary>
    public class KvicsDataGridViewHeaderCell : DataGridViewTextBoxCell
    {
        #region Fields

        private Color backColor = Color.Black;//System.Drawing.SystemColors.Control;
        private Color foreColor = Color.White;//System.Drawing.SystemColors.ControlText;

        #endregion

        #region Properties

        /// <summary>
        /// Gets and sets the number of columns this DataGridViewCell spans.
        /// </summary>
        public Color BackColor
        {
            get { return this.backColor; }
            set { this.backColor = value; }
        }

        /// <summary>
        /// Gets and sets the number of rows this DataGridViewCell spans.
        /// </summary>
        public Color ForeColor
        {
            get { return this.foreColor; }
            set { this.foreColor = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public KvicsDataGridViewHeaderCell()
            : base()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="rowSpan">The number of rows this DataGridViewCell spans.</param>
        /// <param name="columnSpan">The number of columns this DataGridViewCell spans.</param>
        public KvicsDataGridViewHeaderCell(Color backColor, Color foreColor)
            : base()
        {
            this.backColor = backColor;
            this.foreColor = foreColor;
        }

        #endregion

        #region overrides

        protected override void OnDataGridViewChanged()
        {
            base.OnDataGridViewChanged();
            if (this.DataGridView != null)
            {
                this.DataGridView.CellPainting += this.DataGridView_CellPainting;
            }
        }

        #endregion

        #region EventHandlers

        protected virtual void DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == this.RowIndex && e.ColumnIndex == this.ColumnIndex)
            {
                Rectangle displayRectangle = this.DataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                
                //int stringX = displayRectangle.X + 1;
                int stringX = System.Convert.ToInt32(displayRectangle.X 
                    + ((this.OwningColumn.Width - e.Graphics.MeasureString(
                    (this.Value == null ? "" : this.Value).ToString(), this.DataGridView.ColumnHeadersDefaultCellStyle.Font).Width) / 2));
                int stringY = displayRectangle.Y + ((this.OwningRow.Height - this.DataGridView.ColumnHeadersDefaultCellStyle.Font.Height) / 2);

                if (this.DataGridView.RowHeadersVisible)
                {
                    if (displayRectangle.X < this.DataGridView.RowHeadersWidth)
                    {
                        displayRectangle.Width -= (this.DataGridView.RowHeadersWidth - displayRectangle.X);
                        displayRectangle.X = this.DataGridView.RowHeadersWidth + 1;
                    }
                }
                else
                {
                    if (displayRectangle.X < 0)
                    {
                        displayRectangle.Width -= (0 - displayRectangle.X);
                        displayRectangle.X = 1;
                    }
                }
                RectangleF oldClip = e.Graphics.ClipBounds;

                Rectangle clipRectangle = new Rectangle(displayRectangle.X - 1, displayRectangle.Y - 1, displayRectangle.Width + 2, displayRectangle.Height + 2);

                e.Graphics.SetClip(clipRectangle);

                Brush foreBrush = null;
                Brush backBrush = null;
                Pen gridPen = null;
                Pen gridBorderPen = null;

                try
                {
                    gridPen = new Pen(this.DataGridView.GridColor);
                    gridBorderPen = new Pen(Color.White);
                    foreBrush = new SolidBrush(this.foreColor);
                    backBrush = new SolidBrush(this.backColor);

                    e.Graphics.FillRectangle(backBrush, displayRectangle);
                    e.Graphics.DrawString(this.FormattedValue.ToString(), this.DataGridView.ColumnHeadersDefaultCellStyle.Font, foreBrush, stringX, stringY);

                    //e.Graphics.DrawLine(gridPen, displayRectangle.X, displayRectangle.Top - 1, displayRectangle.Right - 1, displayRectangle.Top - 1);
                    //e.Graphics.DrawLine(gridPen, displayRectangle.Left - 1, displayRectangle.Y - 1, displayRectangle.Left - 1, displayRectangle.Bottom - 1);

                    //e.Graphics.DrawLine(gridBorderPen, displayRectangle.X, displayRectangle.Top, displayRectangle.Right - 1, displayRectangle.Top);
                    //e.Graphics.DrawLine(gridBorderPen, displayRectangle.Left, displayRectangle.Y, displayRectangle.Left, displayRectangle.Bottom - 1);

                    //e.Graphics.DrawLine(gridPen, displayRectangle.X, displayRectangle.Bottom - 1, displayRectangle.Right - 1, displayRectangle.Bottom - 1);
                    //e.Graphics.DrawLine(gridPen, displayRectangle.Right - 1, displayRectangle.Y - 1, displayRectangle.Right - 1, displayRectangle.Bottom - 1);
                }
                finally
                {
                    if (foreBrush != null)
                    {
                        foreBrush.Dispose();
                    }
                    if (backBrush != null)
                    {
                        backBrush.Dispose();
                    }
                    if (gridPen != null)
                    {
                        gridPen.Dispose();
                    }
                }

                e.Graphics.SetClip(oldClip);

                e.Handled = true;
            }
        }

        #endregion
    }
}
