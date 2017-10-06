using System;
using System.Collections;

namespace Kvics.DBAccess
{
    public class SortParameterCollection : CollectionBase
    {
        public SortParameterCollection()
			: base()
		{
		}

		public int Add(string strName, SortType sortType)
		{
			return List.Add(new SortParameter(strName, sortType));
		}

		public int Add(SortParameter value)
		{
			return List.Add(value);
		}

		public void Insert(int index, SortParameter value)
		{
			List.Insert(index, value);
		}

		public int IndexOf(SortParameter value)
		{
			return List.IndexOf(value);
		}

		public bool Contains(SortParameter value)
		{
			return List.Contains(value);
		}

		public void CopyTo(SortParameter[] value, int index)
		{
			List.CopyTo(value, index);
		}

		public void Remove(SortParameter value)
		{
			List.Remove(value);
		}
		public SortParameter[] ToArray()
		{
			SortParameter[] array = new SortParameter[List.Count];
			List.CopyTo(array, 0);
			return array;
		}
		public SortParameter this[int index]
		{
			get
			{
				return (SortParameter)List[index];
			}
			set
			{
				List[index] = value;
			}
		}
		public override string ToString()
		{
			return "SortParameterCollection";
		}

    }
}
