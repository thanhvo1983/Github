using System;
using System.Collections.Generic;


namespace Kvics.DBAccess
{
    public class WhereParameter
    {
        private string _Name;
		private object _Value;
		private CompareType _CompareType;

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

        public object Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
            }
        }

        public CompareType CompareType
        {
            get
            {
                return _CompareType;
            }
            set
            {
                _CompareType = value;
            }
        }

		public WhereParameter()
		{
			_Name = "";
			_Value = (Int16)0;
			_CompareType = CompareType.Equal;
		}
		public WhereParameter(string strName, object objValue, CompareType compType)
		{
			_Name = strName;
			_Value = objValue;
			_CompareType = compType;
		}
		
		/// <summary>
		/// Get Compare string
		/// </summary>
		public string CompareString
		{
			get
			{
				string strReturn = " = ";
				switch(_CompareType)
				{
					case CompareType.Equal:
						strReturn =  " = ";
						break;
					case CompareType.NotEqual:
						strReturn =  " <> ";
						break;
					case CompareType.EqualOrLess:
						strReturn =  " <= ";
						break;
					case CompareType.EqualOrThan:
						strReturn =  " >= ";
						break;
					case CompareType.Less:
						strReturn =  " < ";
						break;
					case CompareType.Than:
						strReturn =  " > ";
						break;
                    case CompareType.Like:
                        strReturn = " LIKE ";
                        break;
                    case CompareType.NotLike:
                        strReturn = " NOT LIKE ";
                        break;
					default:
						break;
				}
				return strReturn;
			}
		}
    }
}
