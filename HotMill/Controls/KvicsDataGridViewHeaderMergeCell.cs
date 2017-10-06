using System.Drawing;
using System.Windows.Forms;

namespace Kvics.Controls
{
    public enum H_Align { Left, Center, Right }
    public enum V_Align { Top, Middle, Bottom }
    /// <summary>
    /// This class represents a TextBoxCell that spans multiple columns.
    /// </summary>
    public class KvicsDataGridViewHeaderMergeCell : DataGridViewTextBoxCell
    {
        #region Fields

        private int rowSpan;
        private int columnSpan;
        private Color backColor = System.Drawing.SystemColors.Control;
        private Color foreColor = System.Drawing.SystemColors.ControlText;
        private H_Align hAlign = H_Align.Left;
        private V_Align vAlign = V_Align.Middle;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the number of columns this DataGridViewCell spans.
        /// </summary>
        public int ColumnSpan
        {
            get { return this.columnSpan; }
            set { this.columnSpan = value; }
        }

        /// <summary>
        /// Gets or sets the number of rows this DataGridViewCell spans.
        /// </summary>
        public int RowSpan
        {
            get { return this.rowSpan; }
            set { this.rowSpan = value; }
        }

        /// <summary>
        /// Gets or sets the horizontal of text in this DataGridViewCell.
        /// </summary>
        public H_Align HAlign
        {
            get { return this.hAlign; }
            set { this.hAlign = value; }
        }

        /// <summary>
        /// Gets or sets the vertical of text in this DataGridViewCell.
        /// </summary>
        public V_Align VAlign
        {
            get { return this.vAlign; }
            set { this.vAlign = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public KvicsDataGridViewHeaderMergeCell()
            : base()
        {
            this.columnSpan = 1;
            this.rowSpan = 1;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="rowSpan">The number of rows this DataGridViewCell spans.</param>
        /// <param name="columnSpan">The number of columns this DataGridViewCell spans.</param>
        public KvicsDataGridViewHeaderMergeCell(int rowSpan, int columnSpan, Color backColor, Color foreColor)
            : base()
        {
            this.rowSpan = rowSpan;
            this.columnSpan = columnSpan;
            this.backColor = backColor;
            this.foreColor = foreColor;
        }

        public KvicsDataGridViewHeaderMergeCell(int rowSpan, int columnSpan, Color backColor, Color foreColor, H_Align hAlign, V_Align vAlign)
            : base()
        {
            this.rowSpan = rowSpan;
            this.columnSpan = columnSpan;
            this.backColor = backColor;
            this.foreColor = foreColor;
            this.hAlign = hAlign;
            this.vAlign = vAlign;
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

        public override void PositionEditingControl(bool setLocation, bool setSize, Rectangle cellBounds, Rectangle cellClip, DataGridViewCellStyle cellStyle, bool singleVerticalBorderAdded, bool singleHorizontalBorderAdded, bool isFirstDisplayedColumn, bool isFirstDisplayedRow)
        {
            cellBounds.Width = cellBounds.Width * this.columnSpan;
            cellBounds.Height = cellBounds.Height * this.rowSpan;
            cellClip.Width = cellClip.Width * this.columnSpan;
            cellClip.Height = cellClip.Height * this.rowSpan;
            base.PositionEditingControl(setLocation, setSize, cellBounds, cellClip, cellStyle, singleVerticalBorderAdded, singleHorizontalBorderAdded, isFirstDisplayedColumn, isFirstDisplayedRow);
        }

        public override void DetachEditingControl()
        {
            base.DetachEditingControl();
            this.DataGridView.InvalidateCell(this);
        }

        #endregion

        #region EventHandlers

        protected virtual void DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= this.RowIndex && e.RowIndex < this.RowIndex + this.rowSpan)
            {
                if (e.ColumnIndex >= this.ColumnIndex && e.ColumnIndex < this.ColumnIndex + this.columnSpan)
                {
                    int widthTrue = 0;
                    int heightTrue = 0;
                    int heightTop = 0;
                    int widthLeft = 0;

                    for (int i = 0; i < rowSpan && (i + this.RowIndex) < this.DataGridView.RowCount; i++)
                    {
                        heightTrue += this.DataGridView.Rows[this.RowIndex + i].Height;
                    }

                    for (int i = 0; i < columnSpan && (i + this.ColumnIndex) < this.DataGridView.ColumnCount; i++)
                    {
                        widthTrue += this.DataGridView.Columns[this.ColumnIndex + i].Width;
                    }

                    for (int i = e.RowIndex - 1; i >= this.RowIndex; i--)
                    {
                        heightTop += this.DataGridView.Rows[i].Height;
                    }

                    for (int i = e.ColumnIndex - 1; i >= this.ColumnIndex; i--)
                    {
                        widthLeft += this.DataGridView.Columns[i].Width;
                    }

                    Rectangle displayRectangle = this.DataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                    displayRectangle.X -= widthLeft;
                    displayRectangle.Y -= heightTop;

                    displayRectangle.Width = widthTrue;
                    displayRectangle.Height = heightTrue;
                    
                    int stringX = displayRectangle.X + 1;
                    int stringY = displayRectangle.Y + 1;// ((heightTrue - this.DataGridView.ColumnHeadersDefaultCellStyle.Font.Height) / 2);

                    switch (this.hAlign)
                    {
                        case H_Align.Left:
                            stringX = displayRectangle.X + 1;
                            break;
                        case H_Align.Center:
                            stringX = System.Convert.ToInt32(displayRectangle.X
                                + ((widthTrue - e.Graphics.MeasureString(
                                (this.Value == null ? "" : this.Value).ToString(), this.DataGridView.ColumnHeadersDefaultCellStyle.Font).Width) / 2));
                            break;
                        case H_Align.Right:
                            stringX = System.Convert.ToInt32(displayRectangle.X
                                + ((widthTrue - e.Graphics.MeasureString(
                                (this.Value == null ? "" : this.Value).ToString(), this.DataGridView.ColumnHeadersDefaultCellStyle.Font).Width))) - 1;
                            break;
                        default:
                            stringX = displayRectangle.X + 1;
                            break;
                    }
                    switch (this.vAlign)
                    {
                        case V_Align.Top:
                            stringY = displayRectangle.Y + 1;
                            break;
                        case V_Align.Middle:
                            stringY = displayRectangle.Y + ((heightTrue - this.DataGridView.ColumnHeadersDefaultCellStyle.Font.Height) / 2);
                            break;
                        case V_Align.Bottom:
                            stringY = displayRectangle.Y + ((heightTrue - this.DataGridView.ColumnHeadersDefaultCellStyle.Font.Height)) - 1;
                            break;
                        default:
                            stringY = displayRectangle.Y + ((heightTrue - this.DataGridView.ColumnHeadersDefaultCellStyle.Font.Height) / 2);
                            break;
                    }

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
                    //e.Graphics.SetClip(displayRectangle);

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
                        /*
                        e.Graphics.DrawLine(gridPen, displayRectangle.X, displayRectangle.Top - 1, displayRectangle.Right - 1, displayRectangle.Top - 1);
                        e.Graphics.DrawLine(gridPen, displayRectangle.Left - 1, displayRectangle.Y - 1, displayRectangle.Left - 1, displayRectangle.Bottom - 1);

                        e.Graphics.DrawLine(gridBorderPen, displayRectangle.X, displayRectangle.Top, displayRectangle.Right - 1, displayRectangle.Top);
                        e.Graphics.DrawLine(gridBorderPen, displayRectangle.Left, displayRectangle.Y, displayRectangle.Left, displayRectangle.Bottom - 1);

                        e.Graphics.DrawLine(gridPen, displayRectangle.X, displayRectangle.Bottom - 1, displayRectangle.Right - 1, displayRectangle.Bottom - 1);
                        e.Graphics.DrawLine(gridPen, displayRectangle.Right - 1, displayRectangle.Y - 1, displayRectangle.Right - 1, displayRectangle.Bottom - 1);
                        */
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
        }

        #endregion
    }
}
