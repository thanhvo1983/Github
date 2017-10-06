using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Kvics.Controls.Chart
{
    public class MultiLayerBar
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

        private int _Transparentcy;

        /// <summary>
        /// 0 -> 100(%)
        /// </summary>
        public int Transparentcy
        {
            get 
            {
                return _Transparentcy * 255 / 100;
            }
            set 
            {
                if (value > 100)
                {
                    value = 100;
                }
                if (value < 0)
                {
                    value = 0;
                }
                _Transparentcy = (100 - value);
            }
        }

        public MultiLayerBar()
        {
            _Size = 15;
            _Color = Color.Red;

            _BorderSize = 0;
            _BorderColor = Color.Yellow;
        }

        public MultiLayerBar(int size, Color color, int borderSize, Color borderColor)
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

            int height = rect.Height;
            int width = rect.Width;

            if (rect.Width > _Size + _BorderSize * 2)
            {
                rect.X = rect.X + rect.Width / 2 - _Size / 2;
                rect.Width = _Size + _BorderSize * 2;
            }

            if (_BorderSize > 0)
            {
                Pen borderPen = new Pen(_BorderColor, _BorderSize);
                e.Graphics.DrawRectangle(borderPen, rect);
            }

            Color transparentColor = Color.FromArgb(Transparentcy, _Color);
            Brush transparentBrush = new SolidBrush(transparentColor);
            
            rect.X += _BorderSize;
            rect.Y += _BorderSize;
            rect.Height -= _BorderSize * 2;
            rect.Width -= _BorderSize * 2;
            e.Graphics.FillRectangle(transparentBrush, rect);
        }

    }
}
