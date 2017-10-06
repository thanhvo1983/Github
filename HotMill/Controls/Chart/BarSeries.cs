using System.Collections;
using System.Drawing;
using System;

namespace Kvics.Controls.Chart
{
	public class BarSeries : Series
	{

        protected Bar _Sample;

        public Bar Sample
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

        public int BorderSize
        {
            get { return _Sample.BorderSize; }
            set { _Sample.BorderSize = value; }
        }

        public Color BorderColor
        {
            get { return _Sample.BorderColor; }
            set { _Sample.BorderColor = value; }
        }

        public BarSeries()
            : base()
        {
            _Sample = new Bar();
        }

        public BarSeries(string name)
            : base(name)
        {
            _Sample = new Bar();
        }
	}


	public class BarSeriesCollection : CollectionBase
	{
		public BarSeriesCollection()
			: base()
		{
        }

        public event EventHandler OnValueUpdated;

		public int Add(BarSeries value)
        {
            int rt = List.Add(value);
            if (OnValueUpdated != null)
            {
                OnValueUpdated(this, new EventArgs());
            }
			return rt;
		}

		public void Insert(int index, BarSeries value)
		{
            List.Insert(index, value);
            if (OnValueUpdated != null)
            {
                OnValueUpdated(this, new EventArgs());
            }
		}

		public int IndexOf(BarSeries value)
		{
			return List.IndexOf(value);
		}

		public bool Contains(BarSeries value)
		{
			return List.Contains(value);
		}

		public void CopyTo(BarSeries[] value, int index)
		{
			List.CopyTo(value, index);
		}

		public void Remove(BarSeries value)
		{
            List.Remove(value);
            if (OnValueUpdated != null)
            {
                OnValueUpdated(this, new EventArgs());
            }
		}

		public BarSeries[] ToArray()
		{
			BarSeries[] array = new BarSeries[List.Count];
			List.CopyTo(array, 0);
			return array;
		}

		public BarSeries this[int index]
		{
			get
			{
				return (BarSeries)List[index];
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
			return "BarSeriesCollection";
		}

	}
}
