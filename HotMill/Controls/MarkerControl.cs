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
    public partial class MarkerControl : UserControl
    {
        protected Marker _Marker = new Marker();
        protected int _LineWidth = 2;
        protected LineStyle _LineStyle = LineStyle.Solid;
        protected bool _MarkerVisible = true;

        public int LineWidth
        {
            get { return this._LineWidth; }
            set { this._LineWidth = value; }
        }

        public int MarkerSize
        {
            get { return this._Marker.Size; }
            set { this._Marker.Size = value; }
        }

        public int MarkerBorderSize
        {
            get { return this._Marker.BorderSize; }
            set { this._Marker.BorderSize = value; }
        }

        public Color MarkerBackColor
        {
            get { return _Marker.BackColor; }
            set { _Marker.BackColor = value; }
        }
        public Color MarkerForeColor
        {
            get { return _Marker.ForeColor; }
            set { _Marker.ForeColor = value; }
        }

        public MarkerStyle MarkerStyle
        {
            get { return _Marker.Style; }
            set { _Marker.Style = value; }
        }

        public LineStyle LineStyle
        {
            get { return _LineStyle; }
            set { this._LineStyle = value; }
        }

        public bool MarkerVisible
        {
            get { return _MarkerVisible; }
            set { _MarkerVisible = value; }
        }

        public float[] DashPattern
        {
            get
            {
                switch (_LineStyle)
                {
                    case LineStyle.Dot:
                        return new float[] { 1, 1 };
                    case LineStyle.Dash:
                        return new float[] { 4, 2 };
                    case LineStyle.DashDot:
                        return new float[] { 4, 2, 1, 2 };
                    case LineStyle.DashDotDot:
                        return new float[] { 4, 2, 1, 2, 1, 2 };
                    case LineStyle.LongDash:
                        return new float[] { 6, 2 };
                    case LineStyle.LongDashDot:
                        return new float[] { 6, 2, 1, 2 };
                    case LineStyle.LongDashDotDot:
                        return new float[] { 6, 2, 1, 2, 1, 2 };
                    default:
                        return null;
                }
            }
        }

        public MarkerControl()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            try
            {
                Pen linePen = new Pen(_Marker.BackColor, _LineWidth);
                switch (_LineStyle)
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
                if (_LineStyle != LineStyle.Solid)
                {
                    linePen.DashPattern = this.DashPattern;
                }
                e.Graphics.DrawLine(linePen, new Point(0, this.Height / 2), new Point(this.Width, this.Height / 2));

                if (_MarkerVisible)
                {
                    int markerTop = (this.Height) / 2;
                    int markerLeft = (this.Width) / 2;

                    _Marker.Draw(new Point(markerLeft, markerTop), e);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
