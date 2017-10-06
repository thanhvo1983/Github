using System;
using System.Collections;

namespace Kvics.DBAccess
{
    public class WhereParameterCollection : CollectionBase
    {
        public WhereParameterCollection()
			: base()
		{
		}

		public int Add(string strName, object objValue, CompareType compType)
		{
			return List.Add(new WhereParameter(strName, objValue, compType));
		}

		public int Add(WhereParameter value)
		{
			return List.Add(value);
		}

		public void Insert(int index, WhereParameter value)
		{
			List.Insert(index, value);
		}

		public int IndexOf(WhereParameter value)
		{
			return List.IndexOf(value);
		}

		public bool Contains(WhereParameter value)
		{
			return List.Contains(value);
		}

		public void CopyTo(WhereParameter[] value, int index)
		{
			List.CopyTo(value, index);
		}

		public void Remove(WhereParameter value)
		{
			List.Remove(value);
		}
		public WhereParameter[] ToArray()
		{
			WhereParameter[] array = new WhereParameter[List.Count];
			List.CopyTo(array, 0);
			return array;
		}
		public WhereParameter this[int index]
		{
			get
			{
				return (WhereParameter)List[index];
			}
			set
			{
				List[index] = value;
			}
		}
		public override string ToString()
		{
			return "WhereParameterCollection";
		}
    }
}
