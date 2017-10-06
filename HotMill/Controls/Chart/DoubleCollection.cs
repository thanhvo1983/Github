using System;
using System.Collections;

namespace Kvics.Controls.Chart
{
	public class DoubleCollection : CollectionBase
	{
		public DoubleCollection()
			: base()
		{
		}

		public int Add(double value)
		{
			return List.Add(value);
		}

		public void Insert(int index, double value)
		{
			List.Insert(index, value);
		}

		public int IndexOf(double value)
		{
			return List.IndexOf(value);
		}

		public bool Contains(double value)
		{
			return List.Contains(value);
		}

		public void CopyTo(double[] value, int index)
		{
			List.CopyTo(value, index);
		}

		public void Remove(double value)
		{
			List.Remove(value);
		}

		public double[] ToArray()
		{
			double[] array = new double[List.Count];
			List.CopyTo(array, 0);
			return array;
		}

		public double this[int index]
		{
			get
			{
				return (double)List[index];
			}
			set
			{
				List[index] = value;
			}
		}

		public override string ToString()
		{
			return "DoubleCollection";
		}

	}
}
