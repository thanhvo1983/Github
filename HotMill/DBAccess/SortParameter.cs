using System;
using System.Collections.Generic;
using System.Text;

namespace Kvics.DBAccess
{
    public class SortParameter
    {
        private string _Name;
        private SortType _SortType;

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        public SortType SortType
        {
            get
            {
                return _SortType;
            }
            set
            {
                _SortType = value;
            }
        }

		public SortParameter()
		{
			_Name = "";
			_SortType = SortType.Increase;
		}
		public SortParameter(string strName, SortType sortType)
		{
			_Name = strName;
			_SortType = sortType;
		}
		public string SortString
		{
			get
			{
				if (_SortType == SortType.Decrease)
				{
					return "DESC";
				}
				return "ASC";
			}
		}
    }
}
