using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Kvics.Controls.Chart
{
    public enum ValueAxisLocation
    {
        LEFT,
        RIGHT
    }

    public class ValueAxis : ChartAxis
    {
        public event EventHandler OnValueUpdated;

        protected double _Min;

        public double Min
        {
            get { return _Min; }
            set
            {
                if (value > _Max)
                {
                    return;
                }
                _Min = value;
                _MinValue = value;
                if (_CrossValue < _MinValue)
                {
                    _CrossValue = _MinValue;
                }
            }
        }

        protected double _MinValue;

        public double MinValue
        {
            get { return _MinValue; }
        }

        protected double _Max;

        public double Max
        {
            get { return _Max; }
            set
            {
                if (value < _Min)
                {
                    return;
                }
                _Max = value;
                _MaxValue = value;
                if (_CrossValue > _MaxValue)
                {
                    _CrossValue = _MaxValue;
                }
            }
        }

        protected double _MaxValue;

        public double MaxValue
        {
            get { return _MaxValue; }
        }

        protected double _CrossValue;

        public double CrossValue
        {
            get { return _CrossValue; }
            set
            {
                _CrossValue = value;

                if (_CrossValue > _Max)
                {
                    _Max = _CrossValue;
                    _MaxValue = _CrossValue;
                }
                else if (_CrossValue < _Min)
                {
                    _Min = _CrossValue;
                    _MinValue = _CrossValue;
                }
            }
        }

        private ValueAxisLocation _Location;

        public ValueAxisLocation Location
        {
            get { return _Location; }
            set { _Location = value; }
        }

        protected LineSeriesCollection _LineSeries;

        public LineSeriesCollection LineSeries
        {
            get { return _LineSeries; }
            set { _LineSeries = value; }
        }

        protected BarSeriesCollection _BarSeries;

        public BarSeriesCollection BarSeries
        {
            get { return _BarSeries; }
            set { _BarSeries = value; }
        }

        protected BarSeriesCollection _UpdateBarSeries;

        public Kvics.Controls.Chart.BarSeriesCollection UpdateBarSeries
        {
            get { return _UpdateBarSeries; }
            set { _UpdateBarSeries = value; }
        }

        protected MultiLayerBarSeriesCollection _MultiLayerBarSeries;

        public MultiLayerBarSeriesCollection MultiLayerBarSeries
        {
            get { return _MultiLayerBarSeries; }
            set { _MultiLayerBarSeries = value; }
        }

        protected TetragonSeriesCollection _TetragonSeries;

        public Kvics.Controls.Chart.TetragonSeriesCollection TetragonSeries
        {
            get { return this._TetragonSeries; }
            set { this._TetragonSeries = value; }
        }

        protected TetragonCustomSeriesCollection _TetragonCustomSeries;

        public Kvics.Controls.Chart.TetragonCustomSeriesCollection TetragonCustomSeries
        {
            get { return this._TetragonCustomSeries; }
            set { this._TetragonCustomSeries = value; }
        }
        
        protected int _BarPadding;

        protected int BarPadding
        {
            get { return _BarPadding; }
            set { _BarPadding = value; }
        }

        protected int _ValueCategory;

        public int ValueCategory
        {
            get { return _ValueCategory; }
            set { _ValueCategory = value; }
        }

        protected bool _IsShowValue;

        public bool IsShowValue
        {
            get { return _IsShowValue; }
            set { _IsShowValue = value; }
        }

        protected bool _GridLine;

        public bool GridLine
        {
            get { return _GridLine; }
            set { _GridLine = value; }
        }

        protected int _GridLineSize;

        public int GridLineSize
        {
            get { return _GridLineSize; }
            set { _GridLineSize = value; }
        }

        protected System.Drawing.Drawing2D.DashStyle _GridDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

        public System.Drawing.Drawing2D.DashStyle GridDashStyle
        {
            get
            {
                return this._GridDashStyle;
            }
            set
            {
                if (value != System.Drawing.Drawing2D.DashStyle.Custom)
                {
                    this._GridDashStyle = value;
                }
            }
        }

        protected int _UpdateBarPos;

        public int UpdateBarPos
        {
            get { return _UpdateBarPos; }
            set { _UpdateBarPos = value; }
        }

        public void OnValues_Updated(object sender, EventArgs e)
        {
            if (OnValueUpdated != null)
            {
                OnValueUpdated(this, e);
            }
        }

        public ValueAxis(ValueAxisLocation location)
            : base()
        {
            _Min = -50;
            _MinValue = -50;
            _Max = 50;
            _MaxValue = 50;
            _CrossValue = 0;

            _LineSeries = new LineSeriesCollection();
            _BarSeries = new BarSeriesCollection();
            _UpdateBarSeries = new BarSeriesCollection();
            _TetragonSeries = new TetragonSeriesCollection();
            _TetragonCustomSeries = new TetragonCustomSeriesCollection();
            _MultiLayerBarSeries = new MultiLayerBarSeriesCollection();

            _LineSeries.OnValueUpdated += new EventHandler(OnValues_Updated);
            _BarSeries.OnValueUpdated += new EventHandler(OnValues_Updated);
            _UpdateBarSeries.OnValueUpdated += new EventHandler(OnValues_Updated);
            _TetragonSeries.OnValueUpdated += new EventHandler(OnValues_Updated);
            _TetragonCustomSeries.OnValueUpdated += new EventHandler(OnValues_Updated);
            _MultiLayerBarSeries.OnValueUpdated += new EventHandler(OnValues_Updated);

            _BarPadding = 2;
            _ValueCategory = 0;
            _IsShowValue = true;
            _GridLine = false;
            _GridLineSize = 2;
            _UpdateBarPos = 2;

            _Location = location;
            _MajorTick = new TickMark(true, 4, TickMarkType.INSIDE, 10);
            _MinorTick = new TickMark(false, 2, TickMarkType.INSIDE, 5);
            switch (_Location)
            {
                case ValueAxisLocation.LEFT:
                    _MajorTick.Direction = TickMarkDirection.RIGHT;
                    _MinorTick.Direction = TickMarkDirection.RIGHT;
                    break;
                case ValueAxisLocation.RIGHT:
                    _MajorTick.Direction = TickMarkDirection.LEFT;
                    _MinorTick.Direction = TickMarkDirection.LEFT;
                    break;
                default:
                    break;
            }
        }

        protected int UpdateMaxCategory()
        {
            for (int i = 0; i < _BarSeries.Count; i++)
            {
                _ValueCategory = (_ValueCategory > _BarSeries[i].Values.Count) ?
                    _ValueCategory : _BarSeries[i].Values.Count;
            }

            for (int i = 0; i < _LineSeries.Count; i++)
            {
                _ValueCategory = (_ValueCategory > _LineSeries[i].Values.Count) ?
                    _ValueCategory : _LineSeries[i].Values.Count;
            }

            for (int i = 0; i < _UpdateBarSeries.Count; i++)
            {
                _ValueCategory = (_ValueCategory > _UpdateBarSeries[i].Values.Count) ?
                    _ValueCategory : _LineSeries[i].Values.Count;
            }

            return _ValueCategory;
        }

        public int MaxTextWidth(PaintEventArgs e)
        {
            SizeF textSizeMax = new SizeF(0, 0);

            if (_Enable == true && _IsShowTitle == true)
            {
                SizeF textSizeTitle = e.Graphics.MeasureString(_Title.Text, _Title.Font);
                textSizeMax.Height = (textSizeMax.Height > textSizeTitle.Height) ?
                    textSizeMax.Height : textSizeTitle.Height;
                textSizeMax.Width = (textSizeMax.Width > textSizeTitle.Width / 2) ?
                    textSizeMax.Width : textSizeTitle.Width / 2;
            }

            if (_Enable == true && _IsShowValue == true)
            {
                SizeF textSizeMaxValue = e.Graphics.MeasureString(
                    _MaxValue.ToString(_TextFormat.Text), _TextFormat.Font);
                textSizeMax.Height = (textSizeMax.Height > textSizeMaxValue.Height) ?
                    textSizeMax.Height : textSizeMaxValue.Height;
                textSizeMax.Width = (textSizeMax.Width > textSizeMaxValue.Width) ?
                    textSizeMax.Width : textSizeMaxValue.Width;

                SizeF textSizeMinValue = e.Graphics.MeasureString(
                    _MinValue.ToString(_TextFormat.Text), _TextFormat.Font);
                textSizeMax.Height = (textSizeMax.Height > textSizeMinValue.Height) ?
                    textSizeMax.Height : textSizeMinValue.Height;
                textSizeMax.Width = (textSizeMax.Width > textSizeMinValue.Width) ?
                    textSizeMax.Width : textSizeMinValue.Width;
            }
            return (int)(textSizeMax.Width);
        }

        public void DrawBarSeries(Rectangle rect, PaintEventArgs e)
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

            //UpdateMaxCategory();
            if (_ValueCategory <= 0)
            {
                return;
            }

            double valueRange = _Max - _Min;
            int crossPoint = rect.Y + (int)(rect.Height * ((_Max - _CrossValue) / valueRange));

            int totalBarWidth = 0;
            for (int i = 0; i < _BarSeries.Count; i++)
            {
                totalBarWidth += _BarSeries[i].Size +
                    _BarSeries[i].BorderSize * 2;
            }

            int categoryWidth = rect.Width / _ValueCategory;
            float scale = 1.0f;
            if (totalBarWidth + _BarPadding * 2 > categoryWidth)
            {
                scale = (float)(categoryWidth) / (totalBarWidth + _BarPadding * 2);
                totalBarWidth = categoryWidth - _BarPadding * 2;
            }

            int barsWidth = 0;
            Rectangle barRect = new Rectangle();
            for (int i = 0; i < _BarSeries.Count; i++)
            {
                BarSeries series = _BarSeries[i];
                barRect.Width = (int)((series.Size + series.BorderSize * 2) * scale);
                int maxCount = (_ValueCategory > series.Values.Count) ?
                    series.Values.Count : _ValueCategory;

                for (int j = 0; j < maxCount; j++)
                {

                    int leftPointer = 0;
                    int nextPointer = 0;
                    int deltaX = 0;

                    if (_AutoPadding || _ValueCategory == 1)
                    {
                        leftPointer = rect.X + (int)(j * (double)rect.Width / _ValueCategory);
                        nextPointer = rect.X + (int)((j + 1) * (double)rect.Width / _ValueCategory);
                        deltaX = nextPointer - leftPointer;
                    }
                    else
                    {
                        leftPointer = rect.X + (int)(j * (double)rect.Width / (_ValueCategory - 1));
                        nextPointer = rect.X + (int)((j + 1) * (double)rect.Width / (_ValueCategory - 1));
                        deltaX = 0;
                    }
                    /*
                    int leftPointer = rect.X + (int)(j * (double)rect.Width / _ValueCategory);
                    int nextPointer = rect.X + (int)((j + 1) * (double)rect.Width / _ValueCategory);
                    int deltaX = nextPointer - leftPointer;
                    */
                    barRect.X = leftPointer + barsWidth + (categoryWidth - totalBarWidth) / 2;

                    if (series.Values[j] > _CrossValue)
                    {
                        if (series.Values[j] >= _Max)
                        {
                            barRect.Y = rect.Y;
                        }
                        else
                        {
                            barRect.Y = rect.Y + (int)(rect.Height * (_Max - series.Values[j]) / valueRange);
                        }
                        barRect.Height = crossPoint - barRect.Y;
                    }
                    else
                    {
                        barRect.Y = crossPoint;
                        if (series.Values[j] <= _Min)
                        {
                            barRect.Height = rect.Y + rect.Height - crossPoint;
                        }
                        else
                        {
                            barRect.Height = rect.Y + (int)(rect.Height * (_Max - series.Values[j]) / valueRange) - crossPoint + 1;
                        }
                    }

                    if (series.Values[j] != _CrossValue)
                    {
                        series.Sample.Draw(barRect, e);
                    }
                }

                barsWidth += barRect.Width;
            }
        }

        public void DrawUpdateBarSeries(Rectangle rect, PaintEventArgs e)
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

            //UpdateMaxCategory();
            if (_ValueCategory <= 0)
            {
                return;
            }

            double valueRange = _Max - _Min;
            int crossPoint = rect.Y + (int)(rect.Height * ((_Max - _CrossValue) / valueRange));

            int totalBarWidth = 0;
            for (int i = 0; i < _UpdateBarSeries.Count; i++)
            {
                totalBarWidth += _UpdateBarSeries[i].Size +
                    _UpdateBarSeries[i].BorderSize * 2;
            }

            int categoryWidth = rect.Width / _ValueCategory;
            float scale = 1.0f;
            if (totalBarWidth + _BarPadding * 2 > categoryWidth)
            {
                scale = (float)(categoryWidth) / (totalBarWidth + _BarPadding * 2);
                totalBarWidth = categoryWidth - _BarPadding * 2;
            }

            int barsWidth = 0;
            Rectangle barRect = new Rectangle();
            for (int i = 0; i < _UpdateBarSeries.Count; i++)
            {                
                BarSeries series = _UpdateBarSeries[i];
                Pen borderPen = new Pen(series.BorderColor);
                barRect.Width = (int)((series.Size + series.BorderSize * 2) * scale);
                int maxCount = (_ValueCategory > series.Values.Count) ?
                    series.Values.Count : _ValueCategory;

                for (int j = 0; j < maxCount; j++)
                {

                    int leftPointer = 0;
                    int nextPointer = 0;
                    int deltaX = 0;

                    if (_AutoPadding || _ValueCategory == 1)
                    {
                        leftPointer = rect.X + (int)(j * (double)rect.Width / _ValueCategory);
                        nextPointer = rect.X + (int)((j + 1) * (double)rect.Width / _ValueCategory);
                        deltaX = nextPointer - leftPointer;
                    }
                    else
                    {
                        leftPointer = rect.X + (int)(j * (double)rect.Width / (_ValueCategory - 1));
                        nextPointer = rect.X + (int)((j + 1) * (double)rect.Width / (_ValueCategory - 1));
                        deltaX = 0;
                    }
                    /*
                    int leftPointer = rect.X + (int)(j * (double)rect.Width / _ValueCategory);
                    int nextPointer = rect.X + (int)((j + 1) * (double)rect.Width / _ValueCategory);
                    int deltaX = nextPointer - leftPointer;
                    */
                    barRect.X = leftPointer + barsWidth + (categoryWidth - totalBarWidth) / 2;
                    barRect.X -= _UpdateBarPos;

                    if (series.Values[j] > _CrossValue)
                    {
                        if (series.Values[j] >= _Max)
                        {
                            barRect.Y = rect.Y;
                        }
                        else
                        {
                            barRect.Y = rect.Y + (int)(rect.Height * (_Max - series.Values[j]) / valueRange);
                        }
                        barRect.Height = crossPoint - barRect.Y;
                    }
                    else
                    {
                        barRect.Y = crossPoint + _Size / 2;
                        if (series.Values[j] <= _Min)
                        {
                            barRect.Height = rect.Y + rect.Height - crossPoint;
                        }
                        else
                        {
                            barRect.Height = rect.Y + (int)(rect.Height * (_Max - series.Values[j]) / valueRange) - crossPoint + 1;
                        }
                    }

                    if (series.Values[j] != _CrossValue)
                    {
                        series.Sample.DrawBorder(barRect, e);
                    }
                }

                barsWidth += barRect.Width;
            }
        }

        public void Draw_MultiLayerBarSeries(Rectangle rect, PaintEventArgs e)
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

            if (_ValueCategory <= 0)
            {
                return;
            }

            double valueRange = _Max - _Min;
            int categoryWidth = rect.Width / _ValueCategory;

            int barsWidth = 0;
            Rectangle barRect = new Rectangle();
            for (int i = 0; i < _MultiLayerBarSeries.Count; i++)
            {
                MultiLayerBarSeries series = _MultiLayerBarSeries[i];
                barsWidth = (int)(series.Size + series.BorderSize * 2);
                barRect.Width = barsWidth;
                int maxCount = (_ValueCategory > series.Values.Count) ? series.Values.Count : _ValueCategory;

                for (int j = 0; j < maxCount; j++)
                {
                    int leftPointer = 0;
                    double maxValue = series.Values[j].Max > series.Values[j].Min ? series.Values[j].Max : series.Values[j].Min;
                    double minValue = series.Values[j].Min < series.Values[j].Max ? series.Values[j].Min : series.Values[j].Max;

                    if (_AutoPadding || _ValueCategory == 1)
                    {
                        leftPointer = rect.X + (int)(j * (double)rect.Width / _ValueCategory);
                    }
                    else
                    {
                        leftPointer = rect.X + (int)(j * (double)rect.Width / (_ValueCategory - 1));
                    }

                    barRect.X = leftPointer + (categoryWidth - barsWidth) / 2;

                    if (maxValue >= _Max)
                    {
                        maxValue = _Max;
                    }
                    if (minValue <= _Min)
                    {
                        minValue = _Min;
                    }

                    barRect.Y = rect.Y + (int)(rect.Height * (_Max - maxValue) / valueRange);
                    barRect.Height = (int)((rect.Height * (maxValue - minValue) / valueRange) + 0.5);
                    series.Sample.Draw(barRect, e);
                }
            }
        }

        public void DrawLineSeries(Rectangle rect, PaintEventArgs e)
        {
            if (_Enable == false)
            {
                return;
            }

            //UpdateMaxCategory();
            if (_ValueCategory <= 0)
            {
                return;
            }

            double valueRange = _Max - _Min;            
            int crossPoint = rect.Y + (int)(rect.Height * ((_Max - _CrossValue) / valueRange));

            for (int i = 0; i < _LineSeries.Count; i++)
            {
                LineSeries series = _LineSeries[i];
                if (series.Values.Count <= 0)
                {
                    continue;
                }

                Pen linePen = new Pen(series.Color, series.Size);
                switch (series.LineStyle)
                {
                    case LineStyle.Solid:
                        linePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                        break;
                    case LineStyle.Dash:
                        linePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        break;
                    case LineStyle.Dot:
                    case LineStyle.LongDash:
                        linePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                        break;
                    case LineStyle.DashDot:
                    case LineStyle.LongDashDot:
                        linePen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                        break;
                    case LineStyle.DashDotDot:
                    case LineStyle.LongDashDotDot:
                        linePen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
                        break;
                    default:
                        break;
                }
                if (series.LineStyle != LineStyle.Solid)
                {
                    linePen.DashPattern = series.DashPattern;
                }
                Marker marker = series.Marker;                
                
                Point curPoint = new Point(int.MinValue, int.MinValue);
                Point prevPoint = new Point();

                Point beginPoint = new Point();
                Point endPoint = new Point();

                int lastValue = 0;
                int maxCount = (_ValueCategory > series.Values.Count) ?
                    series.Values.Count : _ValueCategory;

                for (int j = 0; j < maxCount; j++)
                {
                    if (series.Values[j] == Double.MinValue)
                    {
                        continue;
                    }

                    int leftPointer = 0;
                    int nextPointer = 0;
                    int deltaX = 0;

                    if (_AutoPadding || _ValueCategory == 1)
                    {
                        leftPointer = rect.X + (int)(j * (double)rect.Width / _ValueCategory);
                        nextPointer = rect.X + (int)((j + 1) * (double)rect.Width / _ValueCategory);
                        deltaX = nextPointer - leftPointer;
                    }
                    else
                    {
                        leftPointer = rect.X + (int)(j * (double)rect.Width / (_ValueCategory - 1));
                        nextPointer = rect.X + (int)((j + 1) * (double)rect.Width / (_ValueCategory - 1));
                        deltaX = 0;
                    }
                    /*
                    int leftPointer = rect.X + (int)(j * (double)rect.Width / _ValueCategory);
                    int nextPointer = rect.X + (int)((j + 1) * (double)rect.Width / _ValueCategory);
                    int deltaX = nextPointer - leftPointer;
                    */
                    int curX = leftPointer + deltaX / 2;
                    int curY = rect.Y + (int)(rect.Height * (_Max - series.Values[j]) / valueRange);

                    if (curPoint.X == int.MinValue && curPoint.Y == int.MinValue)
                    {
                        curPoint = new Point(curX, curY);
                        lastValue = j;
                        continue;
                    }
                    else
                    {
                        prevPoint = curPoint;
                        curPoint = new Point(curX, curY);
                    }
                    if (curPoint.X == prevPoint.X)
                    {
                        if (series.Values[j] > _Max)
                        {
                            if (series.Values[lastValue] > _Max)
                            {
                                lastValue = j;
                                continue;
                            }

                            if (series.Values[lastValue] < _Min)
                            {
                                beginPoint = new Point(prevPoint.X, rect.Y + rect.Height);
                                endPoint = new Point(curPoint.X, rect.Y);
                            }
                            else
                            {
                                beginPoint = prevPoint;
                                endPoint = new Point(curPoint.X, rect.Y);
                            }
                        }
                        else if (series.Values[j] < _Min)
                        {
                            if (series.Values[lastValue] < _Min)
                            {
                                lastValue = j;
                                continue;
                            }

                            if (series.Values[lastValue] > _Max)
                            {
                                beginPoint = new Point(prevPoint.X, rect.Y);
                                endPoint = new Point(curPoint.X, rect.Y + rect.Height);
                            }
	                        else
                            {
                                beginPoint = prevPoint;
                                endPoint = new Point(curPoint.X, rect.Y + rect.Height);
                            }
                        }
                        else
                        {
                            if (series.Values[lastValue] > _Max)
                            {
                                beginPoint = new Point(prevPoint.X, rect.Y);
                                endPoint = curPoint;
                            }
                            else if (series.Values[lastValue] < _Min)
                            {
                                beginPoint = new Point(prevPoint.X, rect.Y + rect.Height);
                                endPoint = curPoint;
                            }
                            else
                            {
                                beginPoint = prevPoint;
                                endPoint = curPoint;
                            }
                        }
                    }
                    else
                    {
                        double slope = (double)(curPoint.Y - prevPoint.Y) / (curPoint.X - prevPoint.X);
                        if (series.Values[j] > _Max)
                        {							
                            if (series.Values[lastValue] > _Max)
                            {
                                lastValue = j;
                                continue;
                            }

                            if (series.Values[lastValue] < _Min)
                            {
                                int cutPointX1 = prevPoint.X + (int)((rect.Y + rect.Height - prevPoint.Y) / slope);
                                int cutPointX2 = prevPoint.X + (int)((rect.Y - prevPoint.Y) / slope);
                                beginPoint = new Point(cutPointX1, rect.Y + rect.Height);
                                endPoint = new Point(cutPointX2, rect.Y);
                            }
							else if (slope == 0)
							{
								beginPoint = prevPoint;
								endPoint = new Point(curPoint.X, rect.Y);
							}
                            else
                            {
                                int cutPointX = prevPoint.X + (int)((rect.Y - prevPoint.Y) / slope);
                                beginPoint = prevPoint;
                                endPoint = new Point(cutPointX, rect.Y);
                            }
                        }
                        else if (series.Values[j] < _Min)
                        {
                            if (series.Values[lastValue] < _Min)
                            {
                                lastValue = j;
                                continue;
                            }

                            if (series.Values[lastValue] > _Max)
                            {
                                int cutPointX1 = prevPoint.X + (int)((rect.Y - prevPoint.Y) / slope);
                                int cutPointX2 = prevPoint.X + (int)((rect.Y + rect.Height - prevPoint.Y) / slope);
                                beginPoint = new Point(cutPointX1, rect.Y);
                                endPoint = new Point(cutPointX2, rect.Y + rect.Height);
                            }
							else if (slope == 0)
							{
								beginPoint = prevPoint;
								endPoint = new Point(curPoint.X, rect.Y + rect.Height);
							}
                            else
                            {
                                int cutPointX = prevPoint.X + (int)((rect.Y + rect.Height - prevPoint.Y) / slope);
                                beginPoint = prevPoint;
                                endPoint = new Point(cutPointX, rect.Y + rect.Height);
                            }
                        }
                        else
                        {
                            if (series.Values[lastValue] > _Max)
                            {
								int cutPointX = 0;
								if (slope == 0)
								{
									cutPointX = prevPoint.X;
								}
								else
								{
									cutPointX = prevPoint.X + (int)((rect.Y - prevPoint.Y) / slope);
								}                                
                                beginPoint = new Point(cutPointX, rect.Y);
                                endPoint = curPoint;
                            }
                            else if (series.Values[lastValue] < _Min)
                            {
								int cutPointX = 0;
								if (slope == 0)
								{
									cutPointX = prevPoint.X;
								}
								else
								{
									cutPointX = prevPoint.X + (int)((rect.Y + rect.Height - prevPoint.Y) / slope);
								}                                
                                beginPoint = new Point(cutPointX, rect.Y + rect.Height);
                                endPoint = curPoint;
                            }
                            else
                            {
                                beginPoint = prevPoint;
                                endPoint = curPoint;
                            }
                        }
                    }

                    if (series.IsSolidLine)
                    {
                        e.Graphics.DrawLine(linePen, beginPoint, endPoint);
                    }

                    if (series.Values[lastValue] <= _Max && series.Values[lastValue] >= _Min)
                    {
                        if (prevPoint.Y >= rect.Y && prevPoint.Y <= rect.Y + rect.Height)
                        {
                            marker.Draw(prevPoint, e);
                        }
                    }

                    lastValue = j;
                }

                if (series.Values[lastValue] <= _Max && series.Values[lastValue] >= _Min)
                {
                    if (curPoint.Y >= rect.Y && curPoint.Y <= rect.Y + rect.Height)
                    {
                        marker.Draw(curPoint, e);
                    }
                }
            }
        }

        public void DrawTetragonSeries(Rectangle rect, PaintEventArgs e)
        {
            if (e == null || rect == null
                || e.Graphics == null
                || !_Enable
                || _ValueCategory <= 0)
            {
                return;
            }
            
            double valueRange = _Max - _Min;
            int crossPoint = rect.Y + (int)(rect.Height * ((_Max - _CrossValue) / valueRange));

            for (int i = 0; i < _TetragonSeries.Count; i++)
            {
                TetragonSeries series = _TetragonSeries[i];
                if (series.Values.Count <= 0)
                {
                    continue;
                }

                Point curPoint1 = new Point(int.MinValue, int.MinValue);
                Point curPoint2 = new Point(int.MinValue, int.MinValue);
                Point prevPoint1 = new Point();
                Point prevPoint2 = new Point();

                int lastValue = 0;
                int maxCount = (_ValueCategory > series.Values.Count) ?
                    series.Values.Count : _ValueCategory;

                for (int j = 0; j < maxCount; j++)
                {
                    if (series.Values[j] == null || series.Values[j].Min == Double.MinValue || series.Values[j].Max == Double.MaxValue)
                    {
                        continue;
                    }

                    int leftPointer = 0;
                    int nextPointer = 0;
                    int deltaX = 0;

                    if (_AutoPadding || _ValueCategory == 1)
                    {
                        leftPointer = rect.X + (int)(j * (double)rect.Width / _ValueCategory);
                        nextPointer = rect.X + (int)((j + 1) * (double)rect.Width / _ValueCategory);
                        deltaX = nextPointer - leftPointer;
                    }
                    else
                    {
                        leftPointer = rect.X + (int)(j * (double)rect.Width / (_ValueCategory - 1));
                        nextPointer = rect.X + (int)((j + 1) * (double)rect.Width / (_ValueCategory - 1));
                        deltaX = 0;
                    }

                    int curX = leftPointer + deltaX / 2;
                    int curY1 = rect.Y + (int)(rect.Height * (_Max - series.Values[j].Min) / valueRange);
                    int curY2 = rect.Y + (int)(rect.Height * (_Max - series.Values[j].Max) / valueRange);

                    if (curPoint1.X == int.MinValue && curPoint1.Y == int.MinValue)
                    {
                        curPoint1 = new Point(curX, curY1);
                        curPoint2 = new Point(curX, curY2);
                        lastValue = j;
                        continue;
                    }
                    else
                    {
                        prevPoint1 = curPoint1;
                        prevPoint2 = curPoint2;
                        curPoint1 = new Point(curX, curY1);
                        curPoint2 = new Point(curX, curY2);
                    }

                    series.Tetragon.Point1 = prevPoint1;
                    series.Tetragon.Point2 = prevPoint2;
                    series.Tetragon.Point3 = curPoint2;
                    series.Tetragon.Point4 = curPoint1;

                    series.Tetragon.Draw(e, rect);

                    lastValue = j;
                }
            }
        }

        public void DrawTetragonCustomSeries(Rectangle rect, PaintEventArgs e)
        {
            if (e == null || rect == null
                || e.Graphics == null
                || !_Enable
                || _ValueCategory <= 0)
            {
                return;
            }

            double valueRange = _Max - _Min;
            int crossPoint = rect.Y + (int)(rect.Height * ((_Max - _CrossValue) / valueRange));

            for (int i = 0; i < _TetragonCustomSeries.Count; i++)
            {
                TetragonCustomSeries series = _TetragonCustomSeries[i];
                if (series.Values.Count <= 0)
                {
                    continue;
                }

                Point curPoint1 = new Point(int.MinValue, int.MinValue);
                Point curPoint2 = new Point(int.MinValue, int.MinValue);
                Point prevPoint1 = new Point();
                Point prevPoint2 = new Point();

                int maxCount = series.Values.Count;

                double scaleX = (rect.Width * 1.0) / (series.MaxX - series.MinX);
                double scaleY = (rect.Height * 1.0) / (_Max - _Min);

                for (int j = 0; j < maxCount; j++)
                {
                    if (series.Values[j] == null || series.Values[j].Point1 == null || series.Values[j].Point2 == null)
                    {
                        continue;
                    }

                    LineF line = series.Values[j];

                    int curX1, curX2, curY1, curY2;
                    if (!series.TransposeX)
                    {
                        curX1 = (int)Math.Round(rect.X + line.Point1.X * scaleX, 0, MidpointRounding.ToEven);
                        curX2 = (int)Math.Round(rect.X + line.Point2.X * scaleX, 0, MidpointRounding.ToEven);
                    }
                    else
                    {
                        curX1 = (int)Math.Round(rect.X + rect.Width - line.Point1.X * scaleX, 0, MidpointRounding.ToEven);
                        curX2 = (int)Math.Round(rect.X + rect.Width - line.Point2.X * scaleX, 0, MidpointRounding.ToEven);
                    }
                    curY1 = (int)Math.Round(rect.Y + rect.Height + _Min * scaleY - line.Point1.Y * scaleY, 0, MidpointRounding.ToEven);
                    curY2 = (int)Math.Round(rect.Y + rect.Height + _Min * scaleY - line.Point2.Y * scaleY, 0, MidpointRounding.ToEven);

                    if (curPoint1.X == int.MinValue && curPoint1.Y == int.MinValue)
                    {
                        curPoint1 = new Point(curX1, curY1);
                        curPoint2 = new Point(curX2, curY2);
                        continue;
                    }
                    else
                    {
                        prevPoint1 = curPoint1;
                        prevPoint2 = curPoint2;
                        curPoint1 = new Point(curX1, curY1);
                        curPoint2 = new Point(curX2, curY2);
                    }

                    series.Tetragon.Point1 = prevPoint1;
                    series.Tetragon.Point2 = prevPoint2;
                    series.Tetragon.Point3 = curPoint2;
                    series.Tetragon.Point4 = curPoint1;

                    series.Tetragon.Draw(e, rect);
                }
            }
        }

        public void DrawGrid(Rectangle rect, PaintEventArgs e)
        {
            if (_Enable == false || GridLine == false)
            {
                return;
            }

            Pen gridPen = new Pen(_Color, _GridLineSize);
            gridPen.DashStyle = this._GridDashStyle;

            double valueRange = _Max - _Min;
            int crossPoint = rect.Y + (int)(rect.Height * ((_Max - _CrossValue) / valueRange));

            int posY = 0;

            switch (_Location)
            {
                case ValueAxisLocation.LEFT:
                    double value = _CrossValue + _MajorTick.Unit;
                    while (value <= _Max)
                    {
                        posY = rect.Y + (int)(rect.Height * (_Max - value) / valueRange);
                        e.Graphics.DrawLine(gridPen, new Point(rect.X, posY),
                            new Point(rect.X + rect.Width, posY));

                        value += _MajorTick.Unit;
                    }

                    value = _CrossValue - _MajorTick.Unit;
                    while (value >= _Min)
                    {
                        posY = rect.Y + (int)(rect.Height * (_Max - value) / valueRange);
                        e.Graphics.DrawLine(gridPen, new Point(rect.X + rect.Width, posY),
                            new Point(rect.X, posY));

                        value -= _MajorTick.Unit;
                    }
                    break;
                case ValueAxisLocation.RIGHT:
                    value = _CrossValue + _MajorTick.Unit;
                    while (value <= _Max)
                    {
                        posY = rect.Y + (int)(rect.Height * (_Max - value) / valueRange);
                        e.Graphics.DrawLine(gridPen, new Point(rect.X + rect.Width, posY),
                            new Point(rect.X, posY));

                        value += _MajorTick.Unit;
                    }

                    value = _CrossValue - _MajorTick.Unit;
                    while (value >= _Min)
                    {
                        posY = rect.Y + (int)(rect.Height * (_Max - value) / valueRange);
                        e.Graphics.DrawLine(gridPen, new Point(rect.X + rect.Width, posY),
                            new Point(rect.X, posY));

                        value -= _MajorTick.Unit;
                    }
                    break;
                default:
                    break;
            }
        }

        public void DrawAxis(Rectangle rect, PaintEventArgs e)
        {
            if (_Enable == false)
            {
                return;
            }

            Pen axisPen = new Pen(_Color, _Size);
            //Pen gridPen = new Pen(_Color, _GridLineSize);
            SolidBrush textBrush = new SolidBrush(_TextFormat.Color);
            //e.Graphics.DrawLine(new Pen(
            double valueRange = _Max - _Min;
            int crossPoint = rect.Y + (int)(rect.Height * ((_Max - _CrossValue) / valueRange));

            switch (_Location)
            {
                case ValueAxisLocation.LEFT:
                    e.Graphics.DrawLine(axisPen, new Point(rect.X, rect.Y),
                        new Point(rect.X, rect.Y + rect.Height));
                    _MajorTick.Draw(new Point(rect.X, crossPoint), e);

                    SizeF labelSize = e.Graphics.MeasureString(_CrossValue.ToString(_TextFormat.Text), _TextFormat.Font);
                    int posX = rect.X - ((int)(labelSize.Width) + _MajorTick.Size + _Margin);
                    int posY = crossPoint - (int)(labelSize.Height / 2);
                    if (_IsShowValue == true)
                    {
                        e.Graphics.DrawString(_CrossValue.ToString(_TextFormat.Text), _TextFormat.Font,
                            textBrush, new Point(posX, posY));
                    }

                    double value = _CrossValue + _MajorTick.Unit;
                    while (value <= _Max)
                    {
                        labelSize = e.Graphics.MeasureString(value.ToString(_TextFormat.Text), _TextFormat.Font);
                        posX = rect.X - ((int)(labelSize.Width) + _MajorTick.Size + _Margin);
                        posY = rect.Y + (int)(rect.Height * (_Max - value) / valueRange);
                        if (posY - rect.Y > _Size)
                        {
                            _MajorTick.Draw(new Point(rect.X, posY), e);
                        }

                        posY -= (int)(labelSize.Height / 2);
                        if (_IsShowValue == true)
                        {
                            e.Graphics.DrawString(value.ToString(_TextFormat.Text), _TextFormat.Font,
                                textBrush, new Point(posX, posY));
                        }

                        value += _MajorTick.Unit;
                    }

                    value = _CrossValue - _MajorTick.Unit;
                    while (value >= _Min)
                    {
                        labelSize = e.Graphics.MeasureString(value.ToString(_TextFormat.Text), _TextFormat.Font);
                        posX = rect.X - ((int)(labelSize.Width) + _MajorTick.Size + _Margin);
                        posY = rect.Y + (int)(rect.Height * (_Max - value) / valueRange);
                        if (rect.Y + rect.Height - posY > _Size)
                        {
                            _MajorTick.Draw(new Point(rect.X, posY), e);
                        }

                        posY -= (int)(labelSize.Height / 2);
                        if (_IsShowValue == true)
                        {
                            e.Graphics.DrawString(value.ToString(_TextFormat.Text), _TextFormat.Font,
                                textBrush, new Point(posX, posY));
                        }

                        value -= _MajorTick.Unit;
                    }

                    if (_IsShowTitle == true)
                    {
                        Point titlePoint = new Point();
                        SizeF textSizeMax = e.Graphics.MeasureString(_Max.ToString(_TextFormat.Text), _TextFormat.Font);
                        SizeF titleSize = e.Graphics.MeasureString(_Title.Text, _Title.Font);

                        titlePoint.X = rect.X - (int)(titleSize.Width / 2);
                        titlePoint.Y = rect.Y - ((int)(titleSize.Height +
                            textSizeMax.Height / 2) + _Margin);

                        SolidBrush brush = new SolidBrush(_Color);
                        e.Graphics.DrawString(_Title.Text, _Title.Font, brush, titlePoint);
                    }
                    break;
                case ValueAxisLocation.RIGHT:
                    e.Graphics.DrawLine(axisPen, new Point(rect.X + rect.Width, rect.Y),
                        new Point(rect.X + rect.Width, rect.Y + rect.Height));
                    _MajorTick.Draw(new Point(rect.X + rect.Width, crossPoint), e);

                    labelSize = e.Graphics.MeasureString(_CrossValue.ToString(_TextFormat.Text), _TextFormat.Font);
                    posX = rect.X + rect.Width + _MajorTick.Size + _Margin;
                    posY = crossPoint - (int)(labelSize.Height / 2);
                    if (_IsShowValue == true)
                    {
                        e.Graphics.DrawString(_CrossValue.ToString(_TextFormat.Text), _TextFormat.Font,
                            textBrush, new Point(posX, posY));
                    }

                    value = _CrossValue + _MajorTick.Unit;
                    while (value <= _Max)
                    {
                        labelSize = e.Graphics.MeasureString(value.ToString(_TextFormat.Text), _TextFormat.Font);
                        posX = rect.X + rect.Width + _MajorTick.Size + _Margin;
                        posY = rect.Y + (int)(rect.Height * (_Max - value) / valueRange);
                        if (posY - rect.Y > _Size)
                        {
                            _MajorTick.Draw(new Point(rect.X + rect.Width, posY), e);
                        }

                        posY -= (int)(labelSize.Height / 2);
                        if (_IsShowValue == true)
                        {
                            e.Graphics.DrawString(value.ToString(_TextFormat.Text), _TextFormat.Font,
                                textBrush, new Point(posX, posY));
                        }

                        value += _MajorTick.Unit;
                    }

                    value = _CrossValue - _MajorTick.Unit;
                    while (value >= _Min)
                    {
                        labelSize = e.Graphics.MeasureString(value.ToString(_TextFormat.Text), _TextFormat.Font);
                        posX = rect.X + rect.Width + _MajorTick.Size + _Margin;
                        posY = rect.Y + (int)(rect.Height * (_Max - value) / valueRange);
                        if (rect.Y + rect.Height - posY > _Size)
                        {
                            _MajorTick.Draw(new Point(rect.X + rect.Width, posY), e);
                        }

                        posY -= (int)(labelSize.Height / 2);
                        if (_IsShowValue == true)
                        {
                            e.Graphics.DrawString(value.ToString(_TextFormat.Text), _TextFormat.Font,
                                textBrush, new Point(posX, posY));
                        }

                        value -= _MajorTick.Unit;
                    }

                    if (_IsShowTitle == true)
                    {
                        Point titlePoint = new Point();
                        SizeF textSizeMax = e.Graphics.MeasureString(_Max.ToString(_TextFormat.Text), _TextFormat.Font);
                        SizeF titleSize = e.Graphics.MeasureString(_Title.Text, _Title.Font);
                        titlePoint.X = rect.X + rect.Width - (int)(titleSize.Width / 2);
                        titlePoint.Y = rect.Y - ((int)(titleSize.Height +
                            textSizeMax.Height / 2) + _Margin);
                        SolidBrush brush = new SolidBrush(_Color);
                        e.Graphics.DrawString(_Title.Text, _Title.Font, brush, titlePoint);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
