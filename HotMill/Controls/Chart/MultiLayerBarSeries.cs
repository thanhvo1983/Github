using System.Collections;
using System.Drawing;
using System;

namespace Kvics.Controls.Chart
{
	public class MultiLayerBarSeries : Series
	{
        protected MultiLayerBar _Sample;

        public MultiLayerBar Sample
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

        /// <summary>
        /// 0 -> 100
        /// </summary>
        public int Transparentcy
        {
            get { return _Sample.Transparentcy; }
            set { _Sample.Transparentcy = value; }
        }

        protected MinMaxCollection _MinMaxValues;

        public new MinMaxCollection Values
        {
            get
            {
                return this._MinMaxValues;
            }
            set
            {
                this._MinMaxValues = value;
            }
        }

        public MultiLayerBarSeries()
            : base()
        {
            _Sample = new MultiLayerBar();
            this._MinMaxValues = new MinMaxCollection();
        }

        public MultiLayerBarSeries(string name)
            : base(name)
        {
            _Sample = new MultiLayerBar();
            this._MinMaxValues = new MinMaxCollection();
        }

        public MultiLayerBarSeries(string name, MinMaxCollection value)
            : base(name)
        {
            _Sample = new MultiLayerBar();
            this._MinMaxValues = value;
        }
	}


	public class MultiLayerBarSeriesCollection : CollectionBase
	{
        public MultiLayerBarSeriesCollection()
			: base()
		{
        }

        public event EventHandler OnValueUpdated;

        public int Add(MultiLayerBarSeries value)
        {
            int rt = List.Add(value);
            if (OnValueUpdated != null)
            {
                OnValueUpdated(this, new EventArgs());
            }
			return rt;
		}

        public void Insert(int index, MultiLayerBarSeries value)
		{
            List.Insert(index, value);
            if (OnValueUpdated != null)
            {
                OnValueUpdated(this, new EventArgs());
            }
		}

        public int IndexOf(MultiLayerBarSeries value)
		{
			return List.IndexOf(value);
		}

        public bool Contains(MultiLayerBarSeries value)
		{
			return List.Contains(value);
		}

        public void CopyTo(MultiLayerBarSeries[] value, int index)
		{
			List.CopyTo(value, index);
		}

        public void Remove(MultiLayerBarSeries value)
		{
            List.Remove(value);
            if (OnValueUpdated != null)
            {
                OnValueUpdated(this, new EventArgs());
            }
		}

        public MultiLayerBarSeries[] ToArray()
		{
            MultiLayerBarSeries[] array = new MultiLayerBarSeries[List.Count];
			List.CopyTo(array, 0);
			return array;
		}

        public MultiLayerBarSeries this[int index]
		{
			get
			{
                return (MultiLayerBarSeries)List[index];
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
            return "MultiLayerBarSeriesCollection";
		}

	}
}
