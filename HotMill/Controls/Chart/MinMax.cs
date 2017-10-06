using System;
using System.Collections;

namespace Kvics.Controls.Chart
{
    public class MinMax
    {
        protected double _Min = Double.MinValue;
        protected double _Max = Double.MaxValue;

        public double Min
        {
            get { return _Min; }
            set { _Min = value; }
        }

        public double Max
        {
            get { return _Max; }
            set { _Max = value; }
        }

        public MinMax() { }
        public MinMax(double min, double max)
        {
            this._Min = min;
            this._Max = max;
        }
    }

    public class MinMaxCollection : CollectionBase
    {
        public MinMaxCollection()
            : base()
        {
        }

        public int Add(MinMax value)
        {
            return List.Add(value);
        }

        public void Insert(int index, MinMax value)
        {
            List.Insert(index, value);
        }

        public int IndexOf(MinMax value)
        {
            return List.IndexOf(value);
        }

        public bool Contains(MinMax value)
        {
            return List.Contains(value);
        }

        public void CopyTo(MinMax[] value, int index)
        {
            List.CopyTo(value, index);
        }

        public void Remove(MinMax value)
        {
            List.Remove(value);
        }
        public MinMax[] ToArray()
        {
            MinMax[] array = new MinMax[List.Count];
            List.CopyTo(array, 0);
            return array;
        }
        public MinMax this[int index]
        {
            get
            {
                return (MinMax)List[index];
            }
            set
            {
                List[index] = value;
            }
        }
        public override string ToString()
        {
            return "MinMaxCollection";
        }

    }
}
