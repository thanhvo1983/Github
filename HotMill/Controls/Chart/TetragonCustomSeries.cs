using System.Collections;
using System.Drawing;
using System;

namespace Kvics.Controls.Chart
{
    public class TetragonCustomSeries : Series
    {
        protected Tetragon _Tetragon;
        protected LineFCollection _Value;
        protected double _MinX = 0;
        protected double _MaxX = 0;
        protected bool _TransposeX = false;

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

        public double MinX
        {
            get { return _MinX; }
            set { _MinX = value; }
        }

        public double MaxX
        {
            get { return _MaxX; }
            set { _MaxX = value; }
        }

        public bool TransposeX
        {
            get { return _TransposeX; }
            set { _TransposeX = value; }
        }

        public TetragonCustomSeries()
            : base()
        {
            this._Tetragon = new Tetragon();
            this._Value = new LineFCollection();
        }

        public TetragonCustomSeries(string name)
            : base(name)
        {
            this._Tetragon = new Tetragon();
            this._Value = new LineFCollection();
        }

        public TetragonCustomSeries(string name, LineFCollection value, double minX, double maxX)
            : base(name)
        {
            this._Tetragon = new Tetragon();
            this._MinX = minX;
            this._MaxX = maxX;
            this._Value = value;
            if (this._Value == null)
            {
                this._Value = new LineFCollection();
            }
        }

        public new LineFCollection Values
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

    public class TetragonCustomSeriesCollection : CollectionBase
    {
        public TetragonCustomSeriesCollection()
            : base()
        {
        }

        public event EventHandler OnValueUpdated;

        public int Add(TetragonCustomSeries value)
        {
            int rt = List.Add(value);
            if (OnValueUpdated != null)
            {
                OnValueUpdated(this, new EventArgs());
            }
            return rt;
        }

        public void Insert(int index, TetragonCustomSeries value)
        {
            List.Insert(index, value);
            if (OnValueUpdated != null)
            {
                OnValueUpdated(this, new EventArgs());
            }
        }

        public int IndexOf(TetragonCustomSeries value)
        {
            return List.IndexOf(value);
        }

        public bool Contains(TetragonCustomSeries value)
        {
            return List.Contains(value);
        }

        public void CopyTo(TetragonCustomSeries[] value, int index)
        {
            List.CopyTo(value, index);
        }

        public void Remove(TetragonCustomSeries value)
        {
            List.Remove(value);
            if (OnValueUpdated != null)
            {
                OnValueUpdated(this, new EventArgs());
            }
        }

        public TetragonCustomSeries[] ToArray()
        {
            TetragonCustomSeries[] array = new TetragonCustomSeries[List.Count];
            List.CopyTo(array, 0);
            return array;
        }

        public TetragonCustomSeries this[int index]
        {
            get
            {
                return (TetragonCustomSeries)List[index];
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
            return "TetragonCustomSeriesCollection";
        }

    }
}
