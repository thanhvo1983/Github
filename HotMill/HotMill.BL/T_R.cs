using System;
using Kvics.DBAccess;

namespace Kvics.HotMill.BL
{
    public class T_R : BaseBL
    {
        public static readonly string ID__COLUMN_NAME = "ID";
        public static readonly string PARENTID__COLUMN_NAME = "ParentID";
        public static readonly string ROWID__COLUMN_NAME = "RowID";

        protected int _ID;
        protected int _ParentID;
        protected int _RowID;

        protected T_R()
        {
            _ID = -1;
        }

        protected T_R(DBAccessor dbAccessor)
        {
            this.DBAccessor = dbAccessor;
        }

        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        public int ParentID
        {
            get
            {
                return _ParentID;
            }
            set
            {
                _ParentID = value;
            }
        }

        public int RowID
        {
            get
            {
                return _RowID;
            }
            set
            {
                _RowID = value;
            }
        }

        public virtual int Insert()
        {
            return 0;
        }

        public virtual int Update()
        {
            return 0;
        }

        public virtual int Delete()
        {
            return 0;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
