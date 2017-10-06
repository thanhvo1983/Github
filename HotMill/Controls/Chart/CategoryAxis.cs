using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Kvics.Controls.Chart
{
	public class CategoryAxis : ChartAxis
    {
        protected bool _SkipFirstTickMark = false;
        protected bool _SkipLastTickMark = false;
        protected bool _VerticalMajorGrid = false;
        protected int _VerticalMajorGridSize = 1;
        protected System.Drawing.Drawing2D.DashStyle _VerticalMajorGridStyle = System.Drawing.Drawing2D.DashStyle.Dash;
        protected bool _VerticalMinorGrid = false;
        protected int _VerticalMinorGridSize = 1;
        protected System.Drawing.Drawing2D.DashStyle _VerticalMinorGridStyle = System.Drawing.Drawing2D.DashStyle.Dash;

		protected string[] _Labels = { };

		public string[] Labels
		{
			get { return _Labels; }
			set { _Labels = value; }
		}

        protected bool _IsShowLabel;

        public bool IsShowLabel
        {
            get { return _IsShowLabel; }
            set { _IsShowLabel = value; }
        }

        public bool SkipFirstTickMark
        {
            get
            {
                return _SkipFirstTickMark;
            }
            set
            {
                _SkipFirstTickMark = value;
            }
        }

        public bool SkipLastTickMark
        {
            get
            {
                return _SkipLastTickMark;
            }
            set
            {
                _SkipLastTickMark = value;
            }
        }

        public bool VerticalMajorGrid
        {
            get
            {
                return _VerticalMajorGrid;
            }
            set
            {
                _VerticalMajorGrid = value;
            }
        }

        public int VerticalMajorGridSize
        {
            get
            {
                return _VerticalMajorGridSize;
            }
            set
            {
                _VerticalMajorGridSize = value;
            }
        }

        public System.Drawing.Drawing2D.DashStyle VerticalMajorGridStyle
        {
            get
            {
                return _VerticalMajorGridStyle;
            }
            set
            {
                if (value != System.Drawing.Drawing2D.DashStyle.Custom)
                {
                    _VerticalMajorGridStyle = value;
                }
            }
        }

        public bool VerticalMinorGrid
        {
            get
            {
                return _VerticalMinorGrid;
            }
            set
            {
                _VerticalMinorGrid = value;
            }
        }

        public int VerticalMinorGridSize
        {
            get
            {
                return _VerticalMinorGridSize;
            }
            set
            {
                _VerticalMinorGridSize = value;
            }
        }

        public System.Drawing.Drawing2D.DashStyle VerticalMinorGridStyle
        {
            get
            {
                return _VerticalMinorGridStyle;
            }
            set
            {
                if (value != System.Drawing.Drawing2D.DashStyle.Custom)
                {
                    _VerticalMinorGridStyle = value;
                }
            }
        }
        
        public CategoryAxis()
            : base()
		{
            _IsShowLabel = false;
            _MajorTick = new TickMark(true, 4, TickMarkType.INSIDE, 1);
            _MajorTick.Direction = TickMarkDirection.TOP;

            _MinorTick = new TickMark(true, 2, TickMarkType.INSIDE, 1);
            _MinorTick.Direction = TickMarkDirection.TOP;
		}

        public CategoryAxis(string title)
            : base(title)
        {
            _IsShowLabel = false;
            _MajorTick = new TickMark(true, 4, TickMarkType.INSIDE, 1);
            _MajorTick.Direction = TickMarkDirection.TOP;

            _MinorTick = new TickMark(true, 2, TickMarkType.INSIDE, 1);
            _MinorTick.Direction = TickMarkDirection.TOP;
        }

		public int MaxTextHeight(PaintEventArgs e)
		{            
			SizeF textSizeMax = new SizeF(0, 0);

            if (e == null)
            {
                return (int)(textSizeMax.Height);
            }

            if (e.Graphics == null)
            {
                return (int)(textSizeMax.Height);
            }

            if (_IsShowLabel == false)
            {
                return (int)(textSizeMax.Height);
            }

			if (_Labels != null)
			{
				for (int i = 0; i < _Labels.Length; i++)
				{
					SizeF textSizeLabel = e.Graphics.MeasureString(_Labels[i], _TextFormat.Font);

					textSizeMax.Height = (textSizeMax.Height > textSizeLabel.Height) ?
						textSizeMax.Height : textSizeLabel.Height;
					textSizeMax.Width = (textSizeMax.Width > textSizeLabel.Width) ?
						textSizeMax.Width : textSizeLabel.Width;
				}
			}

            if (_IsShowTitle == true)
            {
                SizeF textSizeTitle = e.Graphics.MeasureString(_Title.Text, _Title.Font);

                textSizeMax.Height = (textSizeMax.Height > textSizeTitle.Height) ?
                    textSizeMax.Height : textSizeTitle.Height;
                textSizeMax.Width = (textSizeMax.Width > textSizeTitle.Width) ?
                    textSizeMax.Width : textSizeTitle.Width;
            }

			return (int)(textSizeMax.Height);
		}

		public void DrawAxis(Rectangle rect, int crossPoint, PaintEventArgs e)
        {
            if (e == null || rect == null)
            {
                return;
            }

            if (e.Graphics == null)
            {
                return;
            }

            if (_Enable == false)
            {
                return;
            }

            SolidBrush textBrush = new SolidBrush(_TextFormat.Color);

            if (_Size > 0)
            {
                Pen axisPen = new Pen(_Color, _Size);
                e.Graphics.DrawLine(axisPen, new Point(rect.X, crossPoint), new Point(rect.X + rect.Width, crossPoint));
            }

            if (_Labels.Length == 0)
            {
                return;
            }

            if (_IsShowTitle == true)
            {
                SizeF titleSize = e.Graphics.MeasureString(_Title.Text, _Title.Font);
                Point titlePos = new Point();
                titlePos.X = rect.X + rect.Width - ((int)titleSize.Width + _Margin);
                titlePos.Y = crossPoint + _MajorTick.Size + _Margin;
                SolidBrush titleBrush = new SolidBrush(_Title.Color);
                if (_IsShowLabel == true)
                {
                    e.Graphics.DrawString(_Title.Text, _Title.Font, titleBrush, titlePos);
                }
            }

            for (int i = 0; i < _Labels.Length; i++)
            {
                int leftPointer = 0;
                int nextPointer = 0;
                int deltaX = 0;

                if (_AutoPadding || _Labels.Length == 1)
                {
                    leftPointer = rect.X + (int)(i * (double)rect.Width / _Labels.Length);
                    nextPointer = rect.X + (int)((i + 1) * (double)rect.Width / _Labels.Length);
                    deltaX = nextPointer - leftPointer;
                }
                else
                {
                    leftPointer = rect.X + (int)(i * (double)rect.Width / (_Labels.Length - 1));
                    nextPointer = rect.X + (int)((i + 1) * (double)rect.Width / (_Labels.Length - 1));
                    deltaX = 0;
                }

                if (i % (int)(_MajorTick.Unit) == 0)
                {
                    int majorPos = leftPointer + deltaX / 2;
                    if ((i / (int)(_MajorTick.Unit) == 0))
                    {
                        if (!_SkipFirstTickMark)
                        {
                            _MajorTick.Draw(new Point(majorPos, crossPoint), e);
                        }
                    }
                    else if ((i / (int)(_MajorTick.Unit)) >= ((_Labels.Length - 1) / (int)(_MajorTick.Unit)))
                    {
                        if (!_SkipLastTickMark)
                        {
                            _MajorTick.Draw(new Point(majorPos, crossPoint), e);
                        }
                    }
                    else
                    {
                        _MajorTick.Draw(new Point(majorPos, crossPoint), e);
                    }

                    if (_IsShowLabel == true)
                    {
                        SizeF sizeTextLabel = e.Graphics.MeasureString(_Labels[i], _TextFormat.Font);
                        int textX = majorPos - (int)(sizeTextLabel.Width / 2);
                        int textY = crossPoint + _MajorTick.Size + _Margin;
                        e.Graphics.DrawString(_Labels[i], _TextFormat.Font, textBrush,
                            new Point(textX, textY));
                    }

                    // draw vertical grid
                    if (this._VerticalMajorGrid == true)
                    {
                        Pen gridPen = new Pen(this._Color, this._VerticalMajorGridSize);
                        gridPen.DashStyle = this._VerticalMajorGridStyle;
                        e.Graphics.DrawLine(gridPen, new Point(majorPos, crossPoint), new Point(majorPos, crossPoint - rect.Height));
                    }
                }

                if (i % (int)(_MinorTick.Unit) == (int)(_MinorTick.Unit) / 2)
                {
                    int minorPos = leftPointer;
                    if ((int)(_MajorTick.Unit) % 2 == 0)
                    {
                        minorPos += deltaX / 2;
                    }
                    else
                    {
                        minorPos += deltaX;
                    }

                    if ((i / (int)(_MinorTick.Unit) == 0))
                    {
                        if (!_SkipFirstTickMark)
                        {
                            _MinorTick.Draw(new Point(minorPos, crossPoint), e);
                        }
                    }
                    else if ((i + (int)(_MinorTick.Unit) >= _Labels.Length - 1))
                    {
                        if (!_SkipLastTickMark)
                        {
                            _MinorTick.Draw(new Point(minorPos, crossPoint), e);
                        }
                    }
                    else
                    {
                        _MinorTick.Draw(new Point(minorPos, crossPoint), e);
                    }

                    // draw vertical grid
                    if (this._VerticalMinorGrid == true)
                    {
                        Pen gridPen = new Pen(this._Color, this._VerticalMinorGridSize);
                        gridPen.DashStyle = this._VerticalMinorGridStyle;
                        e.Graphics.DrawLine(gridPen, new Point(minorPos, crossPoint), new Point(minorPos, crossPoint - rect.Height));
                    }
                }
            }
        }
	}
}
