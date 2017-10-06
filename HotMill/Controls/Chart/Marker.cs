using System.Drawing;
using System.Windows.Forms;

namespace Kvics.Controls.Chart
{
    public enum MarkerStyle
    {
        VUONG,
        THOI,
        TAM_GIAC,
        THANG,
        TRON
    }

    public class Marker
	{
		private MarkerStyle _Style;

		public MarkerStyle Style
		{
			get { return _Style; }
			set { _Style = value; }
		}

        private int _Size;

		public int Size
		{
			get { return _Size; }
			set { _Size = value; }
		}

        private int _BorderSize;

        public int BorderSize
        {
            get { return _BorderSize; }
            set { _BorderSize = value; }
        }
        private Color _BackColor;

		public Color BackColor
		{
			get { return _BackColor; }
			set { _BackColor = value; }
		}

        private Color _ForeColor;

		public Color ForeColor
		{
			get { return _ForeColor; }
			set { _ForeColor = value; }
		}

		public Marker()
		{
            _Style = MarkerStyle.VUONG;
            _Size = 7;
            _BorderSize = 1;
            _BackColor = Color.Pink;
            _ForeColor = Color.Blue;
		}

        public Marker(MarkerStyle style, int size)
        {
            _Style = style;
            _Size = size;
            _BorderSize = 1;
            _BackColor = Color.Pink;
            _ForeColor = Color.Blue;
        }

		public Marker(MarkerStyle style, int size, int borderSize,
            Color backColor, Color foreColor)
		{
			_Style = style;
			_Size = size;
            _BorderSize = borderSize;
			_BackColor = backColor;
			_ForeColor = foreColor;
		}

		public void Draw(Point pos, PaintEventArgs e)
		{
			Pen pen = new Pen(_ForeColor);
			SolidBrush brush = new SolidBrush(_BackColor);
			int sizeHaft = _Size / 2;

			switch (_Style)
			{
				case MarkerStyle.VUONG:
					Rectangle recVuong = new Rectangle(
                        pos.X - sizeHaft, pos.Y - sizeHaft, _Size, _Size);
					e.Graphics.FillRectangle(brush, recVuong);
                    recVuong.Height--;
                    recVuong.Width--;
					e.Graphics.DrawRectangle(pen, recVuong);
                    recVuong.Height++;
                    recVuong.Width++;
					break;

				case MarkerStyle.THOI:
					Point[] pointsThoi = new Point[] {
                        new Point(pos.X, pos.Y - sizeHaft),
                        new Point(pos.X - sizeHaft, pos.Y),
                        new Point(pos.X, pos.Y + sizeHaft),
                        new Point(pos.X + sizeHaft, pos.Y)
                    };

					e.Graphics.FillPolygon(brush, pointsThoi);
					e.Graphics.DrawPolygon(pen, pointsThoi);
					break;

				case MarkerStyle.TAM_GIAC:
					Point[] pointsTamGiac = new Point[] {
                        new Point(pos.X, pos.Y - sizeHaft), 
                        new Point(pos.X - sizeHaft, pos.Y + sizeHaft),
                        new Point(pos.X + sizeHaft, pos.Y + sizeHaft)
                    };

					e.Graphics.FillPolygon(brush, pointsTamGiac);
					e.Graphics.DrawPolygon(pen, pointsTamGiac);
					break;

				case MarkerStyle.THANG:
					pen.Width = 2;
                    e.Graphics.DrawLine(pen, pos.X - sizeHaft + _Size % 2, pos.Y,
                        pos.X + sizeHaft + _Size % 2, pos.Y);
					break;

				case MarkerStyle.TRON:
					Rectangle recTron = new Rectangle(pos.X - sizeHaft,
                        pos.Y - sizeHaft, _Size, _Size);
					e.Graphics.FillEllipse(brush, recTron);
					e.Graphics.DrawEllipse(pen, recTron);
					break;

				default:
					break;
			}
		}
	}
}
