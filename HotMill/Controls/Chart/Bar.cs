using System.Drawing;
using System.Windows.Forms;

namespace Kvics.Controls.Chart
{
    public class Bar
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

        private int _BorderSize;

        public int BorderSize
        {
            get { return _BorderSize; }
            set { _BorderSize = value; }
        }

        private Color _BorderColor;

        public Color BorderColor
        {
            get { return _BorderColor; }
            set { _BorderColor = value; }
        }

        public Bar()
        {
            _Size = 15;
            _Color = Color.Red;

            _BorderSize = 1;
            _BorderColor = Color.Yellow;
        }

        public Bar(int size, Color color, int borderSize, Color borderColor)
        {
            _Size = size;
            _Color = color;

            _BorderSize = borderSize;
            _BorderColor = borderColor;
        }

        public void Draw(Rectangle rect, PaintEventArgs e)
        {
            if (e == null || rect == null )
            {
                return;
            }

            if (e.Graphics == null)
            {
                return;
            }

            SolidBrush barBrush = new SolidBrush(_Color);
            SolidBrush borderBrush = new SolidBrush(_BorderColor);

            int height = rect.Height;
            int width = rect.Width;

            if (rect.Width > _Size + _BorderSize * 2)
            {
                rect.X = rect.X + rect.Width / 2 - _Size / 2;
                rect.Width = _Size + _BorderSize * 2;
            }

            e.Graphics.FillRectangle(borderBrush, rect);
            rect.X += _BorderSize;
            rect.Y += _BorderSize;
            rect.Height -= _BorderSize * 2;
            rect.Width -= _BorderSize * 2;
            e.Graphics.FillRectangle(barBrush, rect);
        }

        public void DrawBorder(Rectangle rect, PaintEventArgs e)
        {
            if (e == null || rect == null)
            {
                return;
            }

            if (e.Graphics == null)
            {
                return;
            }

            Pen borderPen = new Pen(_BorderColor, _BorderSize);

            rect.X += _BorderSize / 2;
            rect.Y += _BorderSize / 2;
            rect.Height -= _BorderSize;
            rect.Width -= _BorderSize;
            e.Graphics.DrawRectangle(borderPen, rect);
        }
    }
}
