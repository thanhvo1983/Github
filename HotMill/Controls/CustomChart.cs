using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Kvics.Controls.Chart;

namespace Kvics.Controls
{
	public partial class CustomChart : UserControl
	{
		#region Members
		protected string _Title = "";

		protected Color _BorderColor = Color.Lime;
		protected int _BorderSize = 2;

		protected Legend _Legend = new Legend();
		protected CategoryAxis _CategoryAxis1 = new CategoryAxis();
		protected ValueAxis _ValueAxis1 = new ValueAxis(ValueAxisLocation.LEFT);
		protected CategoryAxis _CategoryAxis2 = new CategoryAxis();
		protected ValueAxis _ValueAxis2 = new ValueAxis(ValueAxisLocation.RIGHT);
        protected CategoryAxis _CategoryAxis = new CategoryAxis();
		#endregion

		#region Chart Properties
		public string Title
		{
			get { return _Title; }
			set
			{
				_Title = value;
				Refresh();
			}
		}

		public Color BorderColor
		{
			get { return _BorderColor; }
			set
			{
				_BorderColor = value;
				Refresh();
			}
		}

        public int BorderSize
        {
            get { return _BorderSize; }
            set
            {
                _BorderSize = value;
                Refresh();
            }
        }

		public bool AxisY1
		{
			get
			{
				return _ValueAxis1.Enable;
			}
			set
			{
				_ValueAxis1.Enable = value;
				Refresh();
			}
		}

		public string Title1
		{
			get
			{
				return _ValueAxis1.Title.Text;
			}
			set
			{
				_ValueAxis1.Title.Text = value;
				Refresh();
			}
		}

		public bool ShowTitle1
		{
			get
			{
				return _ValueAxis1.IsShowTitle;
			}
			set
			{
				_ValueAxis1.IsShowTitle = value;
				Refresh();
			}
		}

        public bool GridLine1
        {
            get
            {
                return _ValueAxis1.GridLine;
            }
            set
            {
                _ValueAxis1.GridLine = value;
                Refresh();
            }
        }

        public int GridLineSize1
        {
            get
            {
                return _ValueAxis1.GridLineSize;
            }
            set
            {
                _ValueAxis1.GridLineSize = value;
                Refresh();
            }
        }

        public System.Drawing.Drawing2D.DashStyle GridLine1_DashStyle
        {
            get
            {
                return this._ValueAxis1.GridDashStyle;
            }
            set
            {
                this._ValueAxis1.GridDashStyle = value;
                this.Refresh();
            }
        }

        public System.Drawing.Drawing2D.DashStyle GridLine2_DashStyle
        {
            get
            {
                return this._ValueAxis2.GridDashStyle;
            }
            set
            {
                this._ValueAxis2.GridDashStyle = value;
                this.Refresh();
            }
        }

        public bool VerticalMajorGrid
        {
            get
            {
                return this._CategoryAxis.VerticalMajorGrid;
            }
            set
            {
                this._CategoryAxis.VerticalMajorGrid = value;
                this.Refresh();
            }
        }

        public int VerticalMajorGridSize
        {
            get
            {
                return this._CategoryAxis.VerticalMajorGridSize;
            }
            set
            {
                this._CategoryAxis.VerticalMajorGridSize = value;
                this.Refresh();
            }
        }

        public System.Drawing.Drawing2D.DashStyle VerticalMajorGridStyle
        {
            get
            {
                return this._CategoryAxis.VerticalMajorGridStyle;
            }
            set
            {
                this._CategoryAxis.VerticalMajorGridStyle = value;
                this.Refresh();
            }
        }

        public bool VerticalMinorGrid
        {
            get
            {
                return this._CategoryAxis.VerticalMinorGrid;
            }
            set
            {
                this._CategoryAxis.VerticalMinorGrid = value;
                this.Refresh();
            }
        }

        public int VerticalMinorGridSize
        {
            get
            {
                return this._CategoryAxis.VerticalMinorGridSize;
            }
            set
            {
                this._CategoryAxis.VerticalMinorGridSize = value;
                this.Refresh();
            }
        }

        public System.Drawing.Drawing2D.DashStyle VerticalMinorGridStyle
        {
            get
            {
                return this._CategoryAxis.VerticalMinorGridStyle;
            }
            set
            {
                this._CategoryAxis.VerticalMinorGridStyle = value;
                this.Refresh();
            }
        }

        public int TickMarkMajorSizeY1
        {
            get
            {
                return _ValueAxis1.MajorTick.Size;
            }
            set
            {
                _ValueAxis1.MajorTick.Size = value;
                Refresh();
            }
        }

		public bool AxisY2
		{
			get
			{
				return _ValueAxis2.Enable;
			}
			set
			{
				_ValueAxis2.Enable = value;
				Refresh();
			}
		}

		public string Title2
		{
			get
			{
				return _ValueAxis2.Title.Text;
			}
			set
			{
				_ValueAxis2.Title.Text = value;
				Refresh();
			}
		}

		public bool ShowTitle2
		{
			get
			{
				return _ValueAxis2.IsShowTitle;
			}
			set
			{
				_ValueAxis2.IsShowTitle = value;
				Refresh();
			}
		}

        public bool GridLine2
        {
            get
            {
                return _ValueAxis2.GridLine;
            }
            set
            {
                _ValueAxis2.GridLine = value;
                Refresh();
            }
        }

        public int GridLineSize2
        {
            get
            {
                return _ValueAxis2.GridLineSize;
            }
            set
            {
                _ValueAxis2.GridLineSize = value;
                Refresh();
            }
        }

        public int TickMarkMajorSizeY2
        {
            get
            {
                return _ValueAxis2.MajorTick.Size;
            }
            set
            {
                _ValueAxis2.MajorTick.Size = value;
                Refresh();
            }
        }

		public Font TitleFont
		{
			get
			{
				return _ValueAxis1.Title.Font;
			}
			set
			{
				_ValueAxis1.Title.Font = value;
				_ValueAxis2.Title.Font = value;
				Refresh();
			}
		}

		public Font ValueFont
		{
			get
			{
				return _ValueAxis1.TextFormat.Font;
			}
			set
			{
                _ValueAxis1.TextFormat.Font = value;
                _ValueAxis2.TextFormat.Font = value;
				Refresh();
			}
		}

		public bool AxisX1
		{
			get
			{
				return _CategoryAxis1.Enable;
			}
			set
			{
				_CategoryAxis1.Enable = value;
				Refresh();
			}
		}

        public TickMarkType TickMarkMajorTypeX1
        {
            get
            {
                return _CategoryAxis1.MajorTick.Type;
            }
            set
            {
                _CategoryAxis1.MajorTick.Type = value;
                Refresh();
            }
        }

        public int TickMarkMajorSizeX1
        {
            get
            {
                return _CategoryAxis1.MajorTick.Size;
            }
            set
            {
                _CategoryAxis1.MajorTick.Size = value;
                Refresh();
            }
        }

        public TickMarkType TickMarkMinorTypeX1
        {
            get
            {
                return _CategoryAxis1.MinorTick.Type;
            }
            set
            {
                _CategoryAxis1.MinorTick.Type = value;
                Refresh();
            }
        }

        public int TickMarkMinorSizeX1
        {
            get
            {
                return _CategoryAxis1.MinorTick.Size;
            }
            set
            {
                _CategoryAxis1.MinorTick.Size = value;
                Refresh();
            }
        }

		public bool AxisX2
		{
			get
			{
				return _CategoryAxis2.Enable;
			}
			set
			{
				_CategoryAxis2.Enable = value;
				Refresh();
			}
		}

        public TickMarkType TickMarkMajorTypeX2
        {
            get
            {
                return _CategoryAxis2.MajorTick.Type;
            }
            set
            {
                _CategoryAxis2.MajorTick.Type = value;
                Refresh();
            }
        }

        public int TickMarkMajorSizeX2
        {
            get
            {
                return _CategoryAxis2.MajorTick.Size;
            }
            set
            {
                _CategoryAxis2.MajorTick.Size = value;
                Refresh();
            }
        }

        public TickMarkType TickMarkMinorTypeX2
        {
            get
            {
                return _CategoryAxis2.MinorTick.Type;
            }
            set
            {
                _CategoryAxis2.MinorTick.Type = value;
                Refresh();
            }
        }

        public int TickMarkMinorSizeX2
        {
            get
            {
                return _CategoryAxis2.MinorTick.Size;
            }
            set
            {
                _CategoryAxis2.MinorTick.Size = value;
                Refresh();
            }
        }
        
        public int TickMarkStep
        {
            get
            {
                return (int)(_CategoryAxis.MajorTick.Unit);
            }
            set
            {
                _CategoryAxis.MajorTick.Unit = value;
                _CategoryAxis.MinorTick.Unit = value;
                _CategoryAxis1.MajorTick.Unit = value;
                _CategoryAxis1.MinorTick.Unit = value;
                _CategoryAxis2.MajorTick.Unit = value;
                _CategoryAxis2.MinorTick.Unit = value;
                Refresh();
            }
        }

        public bool SkipFirstTickMark
        {
            get
            {
                return _CategoryAxis.SkipFirstTickMark;
            }
            set
            {
                _CategoryAxis.SkipFirstTickMark = value;
                _CategoryAxis1.SkipFirstTickMark = value;
                _CategoryAxis2.SkipFirstTickMark = value;
                Refresh();
            }
        }

        public bool SkipLastTickMark
        {
            get
            {
                return _CategoryAxis.SkipLastTickMark;
            }
            set
            {
                _CategoryAxis.SkipLastTickMark = value;
                _CategoryAxis1.SkipLastTickMark = value;
                _CategoryAxis2.SkipLastTickMark = value;
                Refresh();
            }
        }

        public string CategoryTitle
        {
            get { return _CategoryAxis.Title.Text; }
            set { _CategoryAxis.Title.Text = value; }
        }

        public string[] Category
		{
			get
			{
				return _CategoryAxis.Labels;
			}
			set
			{
                _CategoryAxis.Labels = value;
				_CategoryAxis1.Labels = value;
                _ValueAxis1.ValueCategory = value.Length;
				_CategoryAxis2.Labels = value;				
				_ValueAxis2.ValueCategory = value.Length;
				Refresh();
			}
		}

        public Font CategoryFont
        {
            get
            {
                return _CategoryAxis.TextFormat.Font;
            }
            set
            {
                _CategoryAxis.TextFormat.Font = value;
                _CategoryAxis1.TextFormat.Font = value;
                _CategoryAxis2.TextFormat.Font = value;
                Refresh();
            }
        }

		public Color CategoryColor
		{
			get
			{
				return _CategoryAxis.TextFormat.Color;
			}
			set
			{
                _CategoryAxis.TextFormat.Color = value;
                _CategoryAxis1.TextFormat.Color = value;
                _CategoryAxis2.TextFormat.Color = value;
				Refresh();
			}
		}

        public bool ShowCategoryLabel
        {
            get { return _CategoryAxis.IsShowLabel; }
            set
            {
                _CategoryAxis.IsShowLabel = value;
                Refresh();
            }
        }

        public int CategoryMajorTickMarkSize
        {
            get { return _CategoryAxis.MajorTick.Size; }
            set
            {
                _CategoryAxis.MajorTick.Size = value;
                Refresh();
            }
        }

        public int CategoryMinorTickMarkSize
        {
            get { return _CategoryAxis.MinorTick.Size; }
            set
            { 
                _CategoryAxis.MinorTick.Size = value;
                Refresh();
            }
        }

        public int MarginControls
        {
            get { return _CategoryAxis.Margin; }
            set
            {
                _CategoryAxis.Margin = value;
                _CategoryAxis1.Margin = value;
                _CategoryAxis2.Margin = value;
                _ValueAxis1.Margin = value;
                _ValueAxis2.Margin = value;
                Refresh();
            }
        }

		public double Min1
		{
			get
			{
				return _ValueAxis1.MinValue;
			}
			set
			{
				_ValueAxis1.Min = value;
				Refresh();
			}
		}

		public double Max1
		{
			get
			{
				return _ValueAxis1.MaxValue;
			}
			set
			{
				_ValueAxis1.Max = value;
				Refresh();
			}
		}

		public double Min2
		{
			get
			{
				return _ValueAxis2.MinValue;
			}
			set
			{
				_ValueAxis2.Min = value;
				Refresh();
			}
		}

		public double Max2
		{
			get
			{
				return ValueAxis2.MaxValue;
			}
			set
			{
				_ValueAxis2.Max = value;
				Refresh();
			}
		}

		public double Ranger1
		{
			get
			{ 
				return _ValueAxis1.MajorTick.Unit;
			}
			set
			{
				_ValueAxis1.MajorTick.Unit = value;
				Refresh();
			}
		}

		public double Ranger2
		{
			get
			{
				return _ValueAxis2.MajorTick.Unit;
			}
			set
			{
				_ValueAxis2.MajorTick.Unit = value;
				Refresh();
			}
		}

        public bool ShowValueY1
        {
            get { return _ValueAxis1.IsShowValue; }
            set
            {
                _ValueAxis1.IsShowValue = value;
                Refresh();
            }
        }

        public bool ShowValueY2
        {
                get { return _ValueAxis2.IsShowValue; }
            set
            {
                _ValueAxis2.IsShowValue = value;
                Refresh();
            }
        }
                
        public string ValueFormat1
        {
            get
            {
                return _ValueAxis1.TextFormat.Text;
            }
            set
            {
                _ValueAxis1.TextFormat.Text = value;
                Refresh();
            }
        }

        public string ValueFormat2
        {
            get
            {
                return _ValueAxis2.TextFormat.Text;
            }
            set
            {
                _ValueAxis2.TextFormat.Text = value;
                Refresh();
            }
        }

        public int CrossLineSize1
        {
            get { return this._CategoryAxis1.Size; }
            set { this._CategoryAxis1.Size = value; Refresh(); }
        }

        public int CrossLineSize2
        {
            get { return this._CategoryAxis2.Size; }
            set { this._CategoryAxis2.Size = value; Refresh(); }
        }

        [System.ComponentModel.Browsable(false)]
        public Legend Legend
        {
            get { return _Legend; }
            set { _Legend = value; }
        }

        public bool ShowLegend
        {
            get { return _Legend.Enable; }
            set { _Legend.Enable = value; }
        }

        public bool ShowLegendBar
        {
            get { return _Legend.ShowBar; }
            set { _Legend.ShowBar = value; }
        }

        public bool ShowLegendUpdateBar
        {
            get { return _Legend.ShowUpdateBar; }
            set { _Legend.ShowUpdateBar = value; }
        }

        public bool ShowLegendLine
        {
            get { return _Legend.ShowLine; }
            set { _Legend.ShowLine = value; }
        }

        public Padding LegendMargin
        {
            get { return _Legend.Margin; }
            set { _Legend.Margin = value; }
        }

        public Font LegendFont
        {
            get
            {
                return _Legend.SampleText.Font;
            }
            set
            {
                _Legend.SampleText.Font = value;
                Refresh();
            }
        }

        public bool AutoPadding
        {
            get
            {
                return _CategoryAxis.AutoPadding;
            }
            set
            {
                _CategoryAxis.AutoPadding = value;
                _CategoryAxis1.AutoPadding = value;
                _CategoryAxis2.AutoPadding = value;
                _ValueAxis1.AutoPadding = value;
                _ValueAxis2.AutoPadding = value;
                Refresh();
            }
        }
        #endregion

		#region Axis Properties

        [System.ComponentModel.Browsable(false)]
        public CategoryAxis CategoryAxis
        {
            get { return _CategoryAxis; }
            set { _CategoryAxis = value; }
        }

		[System.ComponentModel.Browsable(false)]
		public CategoryAxis CategoryAxis1
		{
			get { return _CategoryAxis1; }
			set { _CategoryAxis1 = value; }
		}

		[System.ComponentModel.Browsable(false)]
		public ValueAxis ValueAxis1
		{
			get { return _ValueAxis1; }
            set { _ValueAxis1 = value; }
		}

		[System.ComponentModel.Browsable(false)]
		public CategoryAxis CategoryAxis2
		{
			get { return _CategoryAxis2; }
			set { _CategoryAxis2 = value; }
		}

		[System.ComponentModel.Browsable(false)]
		public ValueAxis ValueAxis2
		{
			get { return _ValueAxis2; }
            set { _ValueAxis2 = value; }
		}

		#endregion

		protected Rectangle LegendRectangle(PaintEventArgs e)
		{
			Rectangle legendRect = new Rectangle();
            if (e == null)
            {
                return legendRect;
            }

            if (e.Graphics == null)
            {
                return legendRect;
            }

			if (_Legend.Enable == false || _Legend.Position == LegendPosition.NONE)
			{
				return legendRect;
			}

            if (_Legend.ShowBar == false && _Legend.ShowUpdateBar &&
                _Legend.ShowLine == false)
            {
                return legendRect;
            }

            SizeF legendSize = new SizeF(0, _Legend.SampeSize.Height);
            
            if (_Legend.ShowUpdateBar == true)
            {
                SizeF textSizeName = new SizeF();
                if (_ValueAxis1.Enable == true)
                {
                    foreach (BarSeries bar in _ValueAxis1.UpdateBarSeries)
                    {
                        legendSize.Width += _Legend.SampeSize.Width;
                        legendSize.Width += _Legend.Margin.Left + 5;

                        textSizeName = e.Graphics.MeasureString(bar.Name,
                            _Legend.SampleText.Font);

                        legendSize.Height = legendSize.Height > textSizeName.Height ?
                            legendSize.Height : textSizeName.Height;
                        legendSize.Width += textSizeName.Width;
                        legendSize.Width += _Legend.Margin.Right;
                    }
                }

                if (_ValueAxis2.Enable == true)
                {
                    foreach (BarSeries bar in _ValueAxis2.UpdateBarSeries)
                    {
                        legendSize.Width += _Legend.SampeSize.Width;
                        legendSize.Width += _Legend.Margin.Left + 5;

                        textSizeName = e.Graphics.MeasureString(bar.Name,
                            _Legend.SampleText.Font);

                        legendSize.Height = legendSize.Height > textSizeName.Height ?
                            legendSize.Height : textSizeName.Height;
                        legendSize.Width += textSizeName.Width;
                        legendSize.Width += _Legend.Margin.Right;
                    }
                }
            }

            if (_Legend.ShowBar == true)
            {
                SizeF textSizeName = new SizeF();
                if (_ValueAxis1.Enable == true)
                {
                    foreach (BarSeries bar in _ValueAxis1.BarSeries)
                    {
                        legendSize.Width += _Legend.SampeSize.Width;
                        legendSize.Width += _Legend.Margin.Left + 5;

                        textSizeName = e.Graphics.MeasureString(bar.Name,
                            _Legend.SampleText.Font);

                        legendSize.Height = legendSize.Height > textSizeName.Height ?
                            legendSize.Height : textSizeName.Height;
                        legendSize.Width += textSizeName.Width;
                        legendSize.Width += _Legend.Margin.Right;
                    }
                }

                if (_ValueAxis2.Enable == true)
                {
                    foreach (BarSeries bar in _ValueAxis2.BarSeries)
                    {
                        legendSize.Width += _Legend.SampeSize.Width;
                        legendSize.Width += _Legend.Margin.Left + 5;

                        textSizeName = e.Graphics.MeasureString(bar.Name,
                            _Legend.SampleText.Font);

                        legendSize.Height = legendSize.Height > textSizeName.Height ?
                            legendSize.Height : textSizeName.Height;
                        legendSize.Width += textSizeName.Width;
                        legendSize.Width += _Legend.Margin.Right;
                    }
                }
            }

            if (_Legend.ShowLine == true)
            {
                SizeF textSizeName = new SizeF();
                if (_ValueAxis1.Enable == true)
                {
                    foreach (LineSeries line in _ValueAxis1.LineSeries)
                    {
                        legendSize.Width += _Legend.SampeSize.Width;
                        legendSize.Width += _Legend.Margin.Left + 5;

                        textSizeName = e.Graphics.MeasureString(line.Name,
                            _Legend.SampleText.Font);

                        legendSize.Height = legendSize.Height > textSizeName.Height ?
                            legendSize.Height : textSizeName.Height;
                        legendSize.Width += textSizeName.Width;
                        legendSize.Width += _Legend.Margin.Right;
                    }
                }

                if (_ValueAxis2.Enable == true)
                {
                    foreach (LineSeries line in _ValueAxis2.LineSeries)
                    {
                        legendSize.Width += _Legend.SampeSize.Width;
                        legendSize.Width += _Legend.Margin.Left + 5;

                        textSizeName = e.Graphics.MeasureString(line.Name,
                            _Legend.SampleText.Font);

                        legendSize.Height = legendSize.Height > textSizeName.Height ?
                            legendSize.Height : textSizeName.Height;
                        legendSize.Width += textSizeName.Width;
                        legendSize.Width += _Legend.Margin.Right;
                    }
                }
            }

            legendSize.Height += _Legend.Margin.Top + _Legend.Margin.Bottom;

            legendRect.Height = (int)legendSize.Height;
            legendRect.Width = (int)legendSize.Width;

			// return legend rectangle
			return legendRect;
		}

        protected void DrawLegend(Rectangle rect, PaintEventArgs e)
        {
            if (e == null)
            {
                return;
            }

            if (e.Graphics == null)
            {
                return;
            }

            if (_Legend.Enable == false || _Legend.Position == LegendPosition.NONE)
            {
                return;
            }

            if (_Legend.ShowBar == false && _Legend.ShowUpdateBar &&
                _Legend.ShowLine == false)
            {
                return;
            }

            int leftPointer = rect.X;
            SolidBrush textBrush = new SolidBrush(_Legend.SampleText.Color);
            if (_Legend.ShowUpdateBar == true)
            {
                SizeF textSizeName = new SizeF();
                if (_ValueAxis1.Enable == true)
                {
                    foreach (BarSeries bar in _ValueAxis1.UpdateBarSeries)
                    {
                        //Bar sample = bar.Sample;
                        Bar sample = new Bar(bar.Sample.Size, bar.Sample.Color, bar.Sample.BorderSize, bar.Sample.BorderColor);
                        leftPointer += _Legend.Margin.Left;
                        sample.Size = _Legend.SampeSize.Width;
                        Rectangle sampleRect = new Rectangle();                        
                        sampleRect.X = leftPointer;
                        sampleRect.Y = rect.Y + (rect.Height - _Legend.SampeSize.Height) / 2;
                        sampleRect.Height = _Legend.SampeSize.Height;
                        sampleRect.Width = _Legend.SampeSize.Width;
                        sample.DrawBorder(sampleRect, e);
                        leftPointer += _Legend.SampeSize.Width + 5;

                        textSizeName = e.Graphics.MeasureString(bar.Name, _Legend.SampleText.Font);
                        Point textPos = new Point(leftPointer, rect.Y + (rect.Height - (int)textSizeName.Height) / 2);
                        e.Graphics.DrawString(bar.Name, _Legend.SampleText.Font, textBrush, textPos);
                        leftPointer += (int)(textSizeName.Width) + _Legend.Margin.Right;
                    }
                }

                if (_ValueAxis2.Enable == true)
                {
                    foreach (BarSeries bar in _ValueAxis2.UpdateBarSeries)
                    {
                        //Bar sample = bar.Sample;
                        Bar sample = new Bar(bar.Sample.Size, bar.Sample.Color, bar.Sample.BorderSize, bar.Sample.BorderColor);
                        leftPointer += _Legend.Margin.Left;
                        sample.Size = _Legend.SampeSize.Width;
                        Rectangle sampleRect = new Rectangle();
                        sampleRect.X = leftPointer;
                        sampleRect.Y = rect.Y + (rect.Height - _Legend.SampeSize.Height) / 2;
                        sampleRect.Height = _Legend.SampeSize.Height;
                        sampleRect.Width = _Legend.SampeSize.Width;
                        sample.DrawBorder(sampleRect, e);
                        leftPointer += _Legend.SampeSize.Width + 5;

                        textSizeName = e.Graphics.MeasureString(bar.Name,
                            _Legend.SampleText.Font);
                        Point textPos = new Point(leftPointer, rect.Y + (rect.Height - (int)textSizeName.Height) / 2);
                        e.Graphics.DrawString(bar.Name, _Legend.SampleText.Font, textBrush, textPos);
                        leftPointer += (int)(textSizeName.Width) + _Legend.Margin.Right;
                    }
                }
            }

            if (_Legend.ShowBar == true)
            {
                SizeF textSizeName = new SizeF();
                if (_ValueAxis1.Enable == true)
                {
                    foreach (BarSeries bar in _ValueAxis1.BarSeries)
                    {
                        //Bar sample = bar.Sample;
                        Bar sample = new Bar(bar.Sample.Size, bar.Sample.Color, bar.Sample.BorderSize, bar.Sample.BorderColor);
                        leftPointer += _Legend.Margin.Left;
                        sample.Size = _Legend.SampeSize.Width;
                        Rectangle sampleRect = new Rectangle();
                        sampleRect.X = leftPointer;
                        sampleRect.Y = rect.Y + (rect.Height - _Legend.SampeSize.Height) / 2;
                        sampleRect.Height = _Legend.SampeSize.Height;
                        sampleRect.Width = _Legend.SampeSize.Width;
                        sample.Draw(sampleRect, e);
                        leftPointer += _Legend.SampeSize.Width + 5;

                        textSizeName = e.Graphics.MeasureString(bar.Name,
                            _Legend.SampleText.Font);
                        Point textPos = new Point(leftPointer, rect.Y + (rect.Height - (int)textSizeName.Height) / 2);
                        e.Graphics.DrawString(bar.Name, _Legend.SampleText.Font, textBrush, textPos);
                        leftPointer += (int)(textSizeName.Width) + _Legend.Margin.Right;
                    }
                }

                if (_ValueAxis2.Enable == true)
                {
                    foreach (BarSeries bar in _ValueAxis2.BarSeries)
                    {
                        //Bar sample = bar.Sample;
                        Bar sample = new Bar(bar.Sample.Size, bar.Sample.Color, bar.Sample.BorderSize, bar.Sample.BorderColor);
                        leftPointer += _Legend.Margin.Left;
                        sample.Size = _Legend.SampeSize.Width;
                        Rectangle sampleRect = new Rectangle();
                        sampleRect.X = leftPointer;
                        sampleRect.Y = rect.Y + (rect.Height - _Legend.SampeSize.Height) / 2;
                        sampleRect.Height = _Legend.SampeSize.Height;
                        sampleRect.Width = _Legend.SampeSize.Width;
                        sample.Draw(sampleRect, e);
                        leftPointer += _Legend.SampeSize.Width + 5;

                        textSizeName = e.Graphics.MeasureString(bar.Name,
                            _Legend.SampleText.Font);
                        Point textPos = new Point(leftPointer, rect.Y + (rect.Height - (int)textSizeName.Height) / 2);
                        e.Graphics.DrawString(bar.Name, _Legend.SampleText.Font, textBrush, textPos);
                        leftPointer += (int)(textSizeName.Width) + _Legend.Margin.Right;
                    }
                }
            }

            if (_Legend.ShowLine == true)
            {
                SizeF textSizeName = new SizeF();
                if (_ValueAxis1.Enable == true)
                {
                    foreach (LineSeries line in _ValueAxis1.LineSeries)
                    {
                        Line sample = line.Sample;
                        leftPointer += _Legend.Margin.Left;
                        Point pos1 = new Point(leftPointer, rect.Y + rect.Height / 2);
                        Point pos2 = new Point(leftPointer + _Legend.SampeSize.Width,
                            rect.Y + rect.Height / 2);
                        sample.Draw(pos1, pos2, e);
                        Point markerPos = new Point(leftPointer + _Legend.SampeSize.Width / 2,
                            rect.Y + rect.Height / 2);
                        line.Marker.Draw(markerPos, e);
                        leftPointer += _Legend.SampeSize.Width + 5;

                        textSizeName = e.Graphics.MeasureString(line.Name,
                            _Legend.SampleText.Font);
                        Point textPos = new Point(leftPointer, rect.Y + (rect.Height - (int)textSizeName.Height) / 2);
                        e.Graphics.DrawString(line.Name, _Legend.SampleText.Font, textBrush, textPos);
                        leftPointer += (int)(textSizeName.Width) + _Legend.Margin.Right;
                    }
                }

                if (_ValueAxis2.Enable == true)
                {
                    foreach (LineSeries line in _ValueAxis2.LineSeries)
                    {
                        Line sample = line.Sample;
                        leftPointer += _Legend.Margin.Left;
                        Point pos1 = new Point(leftPointer, rect.Y + rect.Height / 2);
                        Point pos2 = new Point(leftPointer + _Legend.SampeSize.Width,
                            rect.Y + rect.Height / 2);
                        sample.Draw(pos1, pos2, e);
                        Point markerPos = new Point(leftPointer + _Legend.SampeSize.Width / 2,
                            rect.Y + rect.Height / 2);
                        line.Marker.Draw(markerPos, e);
                        leftPointer += _Legend.SampeSize.Width + 5;

                        textSizeName = e.Graphics.MeasureString(line.Name,
                            _Legend.SampleText.Font);
                        Point textPos = new Point(leftPointer, rect.Y + (rect.Height - (int)textSizeName.Height) / 2);
                        e.Graphics.DrawString(line.Name, _Legend.SampleText.Font, textBrush, textPos);
                        leftPointer += (int)(textSizeName.Width) + _Legend.Margin.Right;
                    }
                }
            }
        }

		public CustomChart()
		{
			InitializeComponent();

            _CategoryAxis.IsShowLabel = true;

            _ValueAxis1.OnValueUpdated += new EventHandler(OnValues_Updated);
            _ValueAxis2.OnValueUpdated += new EventHandler(OnValues_Updated);            

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			// calculate plot area
			Rectangle plotArea = new Rectangle();
			plotArea.X = Padding.Left;
			plotArea.Y = Padding.Top;
			plotArea.Width = this.Width - (Padding.Left + Padding.Right);
			plotArea.Height = this.Height - (Padding.Bottom + Padding.Top);

			int reserveTop = 0;
            int reserveBottom = 0;

			int reserveTextTopLeft = 0;
			int reserveTextBottomLeft = 0;
			int reserveTextTopRight = 0;
			int reserveTextBottomRight = 0;

			if (_ValueAxis1.Enable == true)
			{
                if (_ValueAxis1.IsShowValue == true)
                {
                    SizeF textSizeLabel = e.Graphics.MeasureString(
                        _ValueAxis1.MaxValue.ToString(), _ValueAxis1.TextFormat.Font);

                    reserveTextTopLeft += (int)(textSizeLabel.Height) / 2 +
                        (int)(textSizeLabel.Height) % 2 + _ValueAxis1.Margin;

                    textSizeLabel = e.Graphics.MeasureString(
                        _ValueAxis1.MinValue.ToString(), _ValueAxis1.TextFormat.Font);

                    reserveTextBottomLeft += (int)(textSizeLabel.Height) / 2 +
                        (int)(textSizeLabel.Height) % 2 + _ValueAxis1.Margin;
                }

				if (_ValueAxis1.IsShowTitle == true)
				{
					SizeF textSizeTitle = e.Graphics.MeasureString(
						_ValueAxis1.Title.Text, _ValueAxis1.Title.Font);

					reserveTextTopLeft += ((int)(textSizeTitle.Height) + _ValueAxis1.Margin);
				}

                plotArea.Width -= _ValueAxis1.MaxTextWidth(e) +
                    _ValueAxis1.MajorTick.Size + _ValueAxis1.Margin;

                plotArea.X += _ValueAxis1.MaxTextWidth(e) +
                    _ValueAxis1.MajorTick.Size + _ValueAxis1.Margin;
			}

			if (_ValueAxis2.Enable == true)
			{
                if (_ValueAxis2.IsShowValue == true)
                {
                    SizeF textSizeLabel = e.Graphics.MeasureString(
                        _ValueAxis2.MaxValue.ToString(), _ValueAxis2.TextFormat.Font);

                    reserveTextTopRight += (int)(textSizeLabel.Height) / 2 +
                        (int)(textSizeLabel.Height) % 2 + _ValueAxis2.Margin;

                    textSizeLabel = e.Graphics.MeasureString(
                        _ValueAxis2.MinValue.ToString(), _ValueAxis2.TextFormat.Font);

                    reserveTextBottomRight += (int)(textSizeLabel.Height) / 2 +
                        (int)(textSizeLabel.Height) % 2 + _ValueAxis2.Margin;
                }

				if (_ValueAxis2.IsShowTitle == true)
				{
					SizeF textSizeTitle = e.Graphics.MeasureString(
						_ValueAxis2.Title.Text, _ValueAxis2.Title.Font);

                    reserveTextTopRight += (int)(textSizeTitle.Height) + _ValueAxis2.Margin;
				}

                plotArea.Width -= _ValueAxis2.MaxTextWidth(e) +
                    _ValueAxis2.MajorTick.Size + _ValueAxis2.Margin;
			}

			reserveBottom += _CategoryAxis.MaxTextHeight(e) +
                _CategoryAxis.MajorTick.Size + _CategoryAxis.Margin;

			Rectangle legendRect = this.LegendRectangle(e);
			if (_Legend.Enable == true)
			{
				switch (_Legend.Position)
				{
					case LegendPosition.TOP:
                        reserveTop += legendRect.Height;
						break;
					case LegendPosition.BOTTOM:
						reserveBottom += legendRect.Height;
						break;
					default:
						break;
				}
			}

			int reserveMax = (reserveTextTopLeft > reserveTextTopRight) ?
				reserveTextTopLeft : reserveTextTopRight;
			reserveMax = (reserveTop > reserveMax) ? reserveTop : reserveMax;

			plotArea.Y += reserveMax;
			plotArea.Height -= reserveMax;

			reserveMax = (reserveTextBottomLeft > reserveTextBottomRight) ?
				reserveTextBottomLeft : reserveTextBottomRight;
			reserveMax = (reserveBottom > reserveMax) ? reserveBottom : reserveMax;

			plotArea.Height -= reserveMax;

			// draw plot area border
			Pen plotAreaBorderPen = new Pen(_BorderColor, _BorderSize);
			e.Graphics.DrawRectangle(plotAreaBorderPen, plotArea);

			// draw primary value axis
			if (_ValueAxis1.Enable == true)
			{
				_ValueAxis1.DrawAxis(plotArea, e);
			}

			// draw secondary value axis
			if (_ValueAxis2.Enable == true)
			{
				_ValueAxis2.DrawAxis(plotArea, e);
			}

			// draw primary category axis
			if (_CategoryAxis1.Enable == true)
			{
				double valueRange = _ValueAxis1.Max - _ValueAxis1.Min;
				int crossPoint = plotArea.Y + (int)(plotArea.Height * (
					_ValueAxis1.Max - _ValueAxis1.CrossValue) / valueRange);
                _CategoryAxis1.DrawAxis(plotArea, crossPoint, e);
			}
            
			// draw secondary category axis
			if (_CategoryAxis2.Enable == true)
			{
				double valueRange = _ValueAxis2.Max - _ValueAxis2.Min;
				int crossPoint = plotArea.Y + (int)(plotArea.Height * (
					_ValueAxis2.Max - _ValueAxis2.CrossValue) / valueRange);
				_CategoryAxis2.DrawAxis(plotArea, crossPoint, e);
			}

			// draw main category axis
			_CategoryAxis.DrawAxis(plotArea, plotArea.Y + plotArea.Height, e);

            // draw grid line
            if (_ValueAxis1.Enable == true && _ValueAxis1.GridLine == true)
            {
                _ValueAxis1.DrawGrid(plotArea, e);
            }
            if (_ValueAxis2.Enable == true && _ValueAxis2.GridLine == true)
            {
                _ValueAxis2.DrawGrid(plotArea, e);
            }

            // draw area graph
            if (_ValueAxis1.Enable == true)
            {
                _ValueAxis1.DrawTetragonSeries(plotArea, e);
            }
            if (_ValueAxis2.Enable == true)
            {
                _ValueAxis2.DrawTetragonSeries(plotArea, e);
            }

            // draw area graph custom
            if (_ValueAxis1.Enable == true)
            {
                _ValueAxis1.DrawTetragonCustomSeries(plotArea, e);
            }
            if (_ValueAxis2.Enable == true)
            {
                _ValueAxis2.DrawTetragonCustomSeries(plotArea, e);
            }

            // draw multi-layer bar graph
            if (_ValueAxis1.Enable == true)
            {
                _ValueAxis1.Draw_MultiLayerBarSeries(plotArea, e);
            }

            if (_ValueAxis2.Enable == true)
            {
                _ValueAxis2.Draw_MultiLayerBarSeries(plotArea, e);
            }

            // draw bar graph
            if (_ValueAxis1.Enable == true)
            {
                _ValueAxis1.DrawBarSeries(plotArea, e);
                _ValueAxis1.DrawUpdateBarSeries(plotArea, e);
            }

            if (_ValueAxis2.Enable == true)
            {
                _ValueAxis2.DrawBarSeries(plotArea, e);
                _ValueAxis2.DrawUpdateBarSeries(plotArea, e);
            }

			// draw line graph
			if (_ValueAxis1.Enable == true)
			{
				_ValueAxis1.DrawLineSeries(plotArea, e);
			}
			if (_ValueAxis2.Enable == true)
			{
				_ValueAxis2.DrawLineSeries(plotArea, e);
			}

            switch (_Legend.Position)
            {
                case LegendPosition.TOP:
                    legendRect.X = plotArea.X + (plotArea.Width - legendRect.Width) / 2;
                    legendRect.Y = plotArea.Y - legendRect.Height;
                    break;
                case LegendPosition.BOTTOM:
                    legendRect.X = plotArea.X + (plotArea.Width - legendRect.Width) / 2;
                    legendRect.Y = Height - (Padding.Bottom + legendRect.Height);
                    break;
            }

            // draw legend
            if (_Legend.Enable == true && _Legend.Position != LegendPosition.NONE)
            {
                DrawLegend(legendRect, e);
            }
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			Refresh();
		}

        public void OnValues_Updated(object sender, EventArgs e)
        {
            Refresh();
        }
	}
}
