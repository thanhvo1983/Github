using System;
using System.Drawing;
using System.Collections;

namespace Kvics.Controls.Chart
{
    public class LineF
    {
        #region Protected
        protected PointF _Point1;
        protected PointF _Point2;
        #endregion

        #region Property
        public PointF Point1
        {
            get
            {
                return _Point1;
            }
            set
            {
                _Point1 = value;
            }
        }

        public PointF Point2
        {
            get
            {
                return _Point2;
            }
            set
            {
                _Point2 = value;
            }
        }

        #endregion

        #region Constructors
        public LineF(PointF point1, PointF point2)
        {
            _Point1 = point1;
            _Point2 = point2;
        }
        #endregion
    }

    public class LineFCollection : CollectionBase
    {
        public LineFCollection()
            : base()
        {
        }

        public int Add(LineF value)
        {
            return List.Add(value);
        }

        public void Insert(int index, LineF value)
        {
            List.Insert(index, value);
        }

        public int IndexOf(LineF value)
        {
            return List.IndexOf(value);
        }

        public bool Contains(LineF value)
        {
            return List.Contains(value);
        }

        public void CopyTo(LineF[] value, int index)
        {
            List.CopyTo(value, index);
        }

        public void Remove(LineF value)
        {
            List.Remove(value);
        }
        public LineF[] ToArray()
        {
            LineF[] array = new LineF[List.Count];
            List.CopyTo(array, 0);
            return array;
        }
        public LineF this[int index]
        {
            get
            {
                return (LineF)List[index];
            }
            set
            {
                List[index] = value;
            }
        }
        public override string ToString()
        {
            return "LineFCollection";
        }

    }
}
