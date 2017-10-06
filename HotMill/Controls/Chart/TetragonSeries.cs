using System.Collections;
using System.Drawing;
using System;

namespace Kvics.Controls.Chart
{
    public class TetragonSeries : Series
    {
        protected Tetragon _Tetragon;
        protected MinMaxCollection _Value;

        public Tetragon Tetragon
        {
            get { return this._Tetragon; }
            set { this._Tetragon = value; }
        }

        public Color Color
        {
            get { return _Tetragon.Color; }
            set { _Tetragon.Color = value; }
        }

        public TetragonSeries()
            : base()
        {
            this._Tetragon = new Tetragon();
            this._Value = new MinMaxCollection();
        }

        public TetragonSeries(string name)
            : base(name)
        {
            this._Tetragon = new Tetragon();
            this._Value = new MinMaxCollection();
        }

        public TetragonSeries(string name, MinMaxCollection value)
            : base(name)
        {
            this._Tetragon = new Tetragon();
            this._Value = value;
            if (this._Value == null)
            {
                this._Value = new MinMaxCollection();
            }
        }

        public new MinMaxCollection Values
        {
            get
            {
                return this._Value;
            }
            set
            {
                this._Value = value;
            }
        }
    }

    public class TetragonSeriesCollection : CollectionBase
    {
        public TetragonSeriesCollection()
            : base()
        {
        }

        public event EventHandler OnValueUpdated;

        public int Add(TetragonSeries value)
        {
            int rt = List.Add(value);
            if (OnValueUpdated != null)
            {
                OnValueUpdated(this, new EventArgs());
            }
            return rt;
        }

        public void Insert(int index, TetragonSeries value)
        {
            List.Insert(index, value);
            if (OnValueUpdated != null)
            {
                OnValueUpdated(this, new EventArgs());
            }
        }

        public int IndexOf(TetragonSeries value)
        {
            return List.IndexOf(value);
        }

        public bool Contains(TetragonSeries value)
        {
            return List.Contains(value);
        }

        public void CopyTo(TetragonSeries[] value, int index)
        {
            List.CopyTo(value, index);
        }

        public void Remove(TetragonSeries value)
        {
            List.Remove(value);
            if (OnValueUpdated != null)
            {
                OnValueUpdated(this, new EventArgs());
            }
        }

        public TetragonSeries[] ToArray()
        {
            TetragonSeries[] array = new TetragonSeries[List.Count];
            List.CopyTo(array, 0);
            return array;
        }

        public TetragonSeries this[int index]
        {
            get
            {
                return (TetragonSeries)List[index];
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
            return "TetragonSeriesCollection";
        }

    }
}
