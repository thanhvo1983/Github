using System.Collections;
using System.Drawing;
using System;

namespace Kvics.Controls.Chart
{
	public class LineSeries : Series
	{
        protected Line _Sample;

        public Line Sample
        {
            get { return _Sample; }
            set { _Sample = value; }
        }

        public int Size
        {
            get { return _Sample.Size; }
            set { _Sample.Size = value; }
        }

        public Color Color
        {
            get { return _Sample.Color; }
            set { _Sample.Color = value; }
        }

        protected Marker _Marker;

        public Marker Marker
        {
            get { return _Marker; }
            set { _Marker = value; }
        }

        protected bool _IsSolidLine = true;

        public bool IsSolidLine
        {
            get { return _IsSolidLine; }
            set { _IsSolidLine = value; }
        }

        protected LineStyle _LineStyle = LineStyle.Solid;

        public LineStyle LineStyle
        {
            get { return _LineStyle; }
            set { this._LineStyle = value; }
        }

        public LineSeries() : base()
        {
            _Sample = new Line();
            _Marker = new Marker();
        }

        public LineSeries(string name)
            : base(name)
        {
            _Sample = new Line();
            _Marker = new Marker();
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
	}

	public class LineSeriesCollection : CollectionBase
	{
		public LineSeriesCollection()
			: base()
		{
		}

        public event EventHandler OnValueUpdated;

		public int Add(LineSeries value)
        {
            int rt = List.Add(value);
            if (OnValueUpdated != null)
            {
                OnValueUpdated(this, new EventArgs());
            }
            return rt;
		}

		public void Insert(int index, LineSeries value)
        {
            List.Insert(index, value);
            if (OnValueUpdated != null)
            {
                OnValueUpdated(this, new EventArgs());
            }
		}

		public int IndexOf(LineSeries value)
		{
			return List.IndexOf(value);
		}

		public bool Contains(LineSeries value)
		{
			return List.Contains(value);
		}

		public void CopyTo(LineSeries[] value, int index)
		{
			List.CopyTo(value, index);
		}

		public void Remove(LineSeries value)
        {
            List.Remove(value);
            if (OnValueUpdated != null)
            {
                OnValueUpdated(this, new EventArgs());
            }
		}

		public LineSeries[] ToArray()
		{
			LineSeries[] array = new LineSeries[List.Count];
			List.CopyTo(array, 0);
			return array;
		}

		public LineSeries this[int index]
		{
			get
			{
				return (LineSeries)List[index];
			}
			set
			{
                List[index] = value;
                if (OnValueUpdated != null)
                {
                    OnValueUpdated(this, new EventArgs());
                }
			}
        }

        protected override void OnClear()
        {
            base.OnClear();
            if (OnValueUpdated != null)
            {
                OnValueUpdated(this, new EventArgs());
            }
        }

		public override string ToString()
		{
			return "LineSeriesCollection";
		}
	}
}
