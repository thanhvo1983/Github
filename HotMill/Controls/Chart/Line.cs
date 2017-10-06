using System.Drawing;
using System.Windows.Forms;

namespace Kvics.Controls.Chart
{
    public class Line
    {
        private int _Size;

        public int Size
        {
            get { return _Size; }
            set { _Size = value; }
        }
        private Color _Color;

        public Color Color
        {
            get { return _Color; }
            set { _Color = value; }
        }

        public Line()
        {
            _Size = 2;
            _Color = Color.Yellow;
        }

        public Line(int size, Color color)
        {
            _Size = size;
            _Color = color;
        }

        public void Draw(Point pos1, Point pos2, PaintEventArgs e)
        {
            if (e == null || pos1 == null || pos2 == null)
            {
                return;
            }

            if (e.Graphics == null)
            {
                return;
            }

            Pen linePen = new Pen(_Color, _Size);
            e.Graphics.DrawLine(linePen, pos1, pos2);
            linePen.Dispose();
        }
    }
}
