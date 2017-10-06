using System.Drawing;
using System.Windows.Forms;

namespace Kvics.Controls.Chart
{
    public enum TickMarkType
	{
		NONE,
		INSIDE,
		OUTSIDE,
		CROSS
	}

	public enum TickMarkDirection
	{
		LEFT,
		RIGHT,
		TOP,
		BOTTOM
	}

	public class TickMark
	{
		protected bool _Enable;

		public bool Enable
		{
			get { return _Enable; }
			set { _Enable = value; }
		}

		protected int _Size;

		public int Size
		{
			get { return _Size; }
			set { _Size = value; }
		}

		protected int _Thick;

		public int Thick
		{
			get { return _Thick; }
			set { _Thick = value; }
		}

		protected Color _Color;

		public Color Color
		{
			get { return _Color; }
			set { _Color = value; }
		}

		protected TickMarkType _Type;

		public TickMarkType Type
		{
			get { return _Type; }
			set { _Type = value; }
		}

		protected TickMarkDirection _Direction;

		public TickMarkDirection Direction
		{
			get { return _Direction; }
			set { _Direction = value; }
		}

		protected double _Unit;

		public double Unit
		{
			get { return _Unit; }
			set { _Unit = value; }
		}

		public TickMark()
		{
            _Enable = true;
            _Type = TickMarkType.INSIDE;
            _Direction = TickMarkDirection.TOP;
            _Unit = 10.0;

            _Size = 5;
            _Thick = 2;
            _Color = Color.Lime;
		}

		public TickMark(bool enable, int size, TickMarkType type, double unit)
		{
			_Enable = enable;
            _Type = type;
            _Direction = TickMarkDirection.TOP;
            _Unit = unit;

			_Size = size;
            _Thick = 2;
            _Color = Color.Lime;
		}

		public void Draw(Point pos, PaintEventArgs e)
		{
            if (e == null || pos == null)
            {
                return;
            }

            if (e.Graphics == null)
            {
                return;
            }

			Pen pen = new Pen(_Color, _Thick);
			Point nextPoint = new Point(pos.X, pos.Y);
			switch (_Type)
			{
				case TickMarkType.INSIDE:
					switch (_Direction)
					{
						case TickMarkDirection.LEFT:
							nextPoint.X = pos.X - _Size;
							break;
						case TickMarkDirection.RIGHT:
							nextPoint.X = pos.X + _Size;
							break;
						case TickMarkDirection.TOP:
							nextPoint.Y = pos.Y - _Size;
							break;
						case TickMarkDirection.BOTTOM:
							nextPoint.Y = pos.Y + _Size;
							break;
					}
					e.Graphics.DrawLine(pen, pos, nextPoint);
					break;
				case TickMarkType.OUTSIDE:
					switch (_Direction)
					{
						case TickMarkDirection.LEFT:
							nextPoint.X = pos.X + _Size;
							break;
						case TickMarkDirection.RIGHT:
							nextPoint.X = pos.X - _Size;
							break;
						case TickMarkDirection.TOP:
							nextPoint.Y = pos.Y + _Size;
							break;
						case TickMarkDirection.BOTTOM:
							nextPoint.Y = pos.Y - _Size;
							break;
						default:
							break;
					}
					e.Graphics.DrawLine(pen, pos, nextPoint);
					break;
				case TickMarkType.CROSS:
					switch (_Direction)
					{
						case TickMarkDirection.LEFT:
							nextPoint.X = pos.X - _Size;
							break;
						case TickMarkDirection.RIGHT:
							nextPoint.X = pos.X + _Size;
							break;
						case TickMarkDirection.TOP:
							nextPoint.Y = pos.Y - _Size;
							break;
						case TickMarkDirection.BOTTOM:
							nextPoint.Y = pos.Y + _Size;
							break;
					}
					e.Graphics.DrawLine(pen, pos, nextPoint);

					switch (_Direction)
					{
						case TickMarkDirection.LEFT:
							nextPoint.X = pos.X + _Size;
							break;
						case TickMarkDirection.RIGHT:
							nextPoint.X = pos.X - _Size;
							break;
						case TickMarkDirection.TOP:
							nextPoint.Y = pos.Y + _Size;
							break;
						case TickMarkDirection.BOTTOM:
							nextPoint.Y = pos.Y - _Size;
							break;
						default:
							break;
					}
					e.Graphics.DrawLine(pen, pos, nextPoint);
					break;
				default:
					break;
			}

		}
	}
}
