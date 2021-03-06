using System;
using System.Windows.Forms;
using System.Collections;

namespace Kvics.HotMill.Forms
{
	/// <summary>
	/// Summary description for FormCollection.
	/// </summary>
	public class HotMillFormCollection : CollectionBase
	{
		public HotMillFormCollection()
			: base()
		{
		}

		public int Add(Form value)
		{
			return List.Add(value);
		}

		public void Insert(int index, Form value)
		{
			List.Insert(index, value);
		}

		public int IndexOf(Form value)
		{
			return List.IndexOf(value);
		}

		public bool Contains(Form value)
		{
			return List.Contains(value);
		}

		public void CopyTo(Form[] value, int index)
		{
			List.CopyTo(value, index);
		}

		public void Remove(Form value)
		{
			List.Remove(value);
		}
		public Form[] ToArray()
		{
			Form[] array = new Form[List.Count];
			List.CopyTo(array, 0);
			return array;
		}
		public Form this[int index]
		{
			get
			{
				return (Form)List[index];
			}
			set
			{
				List[index] = value;
			}
		}
		public override string ToString()
		{
			return "FormCollection";
		}

	}
}
