using System;
using System.Data;

using Kvics.DBAccess;

namespace Kvics.HotMill.BL
{
    public class BaseBL
    {
        #region DBAccessor
        protected DBAccessor _DBAccessor;
        protected bool db_Set = false;
        public DBAccessor DBAccessor
        {
            get
            {
                return _DBAccessor;
            }
            set
            {
                _DBAccessor = value;
                if (value != null)
                    db_Set = true;
                else
                    db_Set = false;
            }
        }
        #endregion
    }
}
