using System;

namespace Kvics.DBAccess
{
    public class Parameter
    {
        private string _Name;
        private object _Value;

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

        public Parameter(string strName, object objValue)
        {
            _Name = strName;
            _Value = objValue;
        }
    }
}
