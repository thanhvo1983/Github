using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Kvics.Controls.Chart
{
    public class Tetragon
    {
        private Color _Color;

        public Color Color
        {
            get { return _Color; }
            set { _Color = value; }
        }

        private Point _Point1 = new Point(0, 0);

        public Point Point1
        {
            get { return _Point1; }
            set { this._Point1 = value; }
        }

        private Point _Point2 = new Point(0, 0);

        public Point Point2
        {
            get { return _Point2; }
            set { this._Point2 = value; }
        }

        private Point _Point3 = new Point(0, 0);

        public Point Point3
        {
            get { return _Point3; }
            set { this._Point3 = value; }
        }

        private Point _Point4 = new Point(0, 0);

        public Point Point4
        {
            get { return _Point4; }
            set { this._Point4 = value; }
        }

        public Tetragon()
        {
            this._Color = Color.Red;
        }

        public Tetragon(Color color, Point point1, Point point2, Point point3, Point point4)
        {
            this._Color = color;
            this._Point1 = point1;
            this._Point2 = point2;
            this._Point3 = point3;
            this._Point4 = point4;
        }

        public void Draw(PaintEventArgs e, Rectangle drawArea)
        {

            if (e == null || drawArea == null)
            {
                return;
            }

            if (e.Graphics == null)
            {
                return;
            }

            //HatchBrush brush = new HatchBrush(HatchStyle.Percent50, _Color, System.Drawing.Color.Transparent);
            Color transparentColor = Color.FromArgb(192, _Color);
            Brush transparentBrush = new SolidBrush(transparentColor);

            e.Graphics.FillPolygon(transparentBrush, new Point[] { this._Point1, this._Point2, this._Point3, this._Point4 });
        }
    }
}
