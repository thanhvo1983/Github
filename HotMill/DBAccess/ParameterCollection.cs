using System;
using System.Collections;

namespace Kvics.DBAccess
{
    public class ParameterCollection : CollectionBase
    {
        public ParameterCollection()
			: base()
		{
		}

		public int Add(string strName, object objValue)
		{
			return List.Add(new Parameter(strName, objValue));
		}

		public int Add(Parameter value)
		{
			return List.Add(value);
		}

		public void Insert(int index, Parameter value)
		{
			List.Insert(index, value);
		}

		public int IndexOf(Parameter value)
		{
			return List.IndexOf(value);
		}

		public bool Contains(Parameter value)
		{
			return List.Contains(value);
		}

		public void CopyTo(Parameter[] value, int index)
		{
			List.CopyTo(value, index);
		}

		public void Remove(Parameter value)
		{
			List.Remove(value);
		}
		public Parameter[] ToArray()
		{
			Parameter[] array = new Parameter[List.Count];
			List.CopyTo(array, 0);
			return array;
		}
		public Parameter this[int index]
		{
			get
			{
				return (Parameter)List[index];
			}
			set
			{
				List[index] = value;
			}
		}
		public override string ToString()
		{
			return "ParameterCollection";
		}

		public int	FindName(string strName)
		{
			for (int i=0; i<List.Count; i++)
			{
				Parameter param = (Parameter)List[i];
				if ( string.Compare(param.Name, strName, true) == 0)
				{
					return i;
				}
			}
			return -1;
		}
		public int	FindValue(object objValue)
		{
			string strValue = objValue.ToString();
			for (int i=0; i<List.Count; i++)
			{
				Parameter param = (Parameter)List[i];
				if (string.Compare(param.Value.ToString(), strValue, true) == 0)
				{
					return i;
				}
			}
			return -1;
		}
    }
}
