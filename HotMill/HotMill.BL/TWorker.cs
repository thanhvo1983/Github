using System;
using System.Data;

using Kvics.DBAccess;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Specialized;
using System.Collections;

namespace Kvics.HotMill.BL
{
    public class WorkerParameter
    {
        protected int _ID;
        protected string _Name;

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

        public override string ToString()
        {
            return _Name == null ? "" : _Name;
        }

        public WorkerParameter(int id, string name)
        {
            _ID = id;
            _Name = name;
        }
    }

    public class WorkerCollection : CollectionBase
    {
        public WorkerCollection()
            : base()
        {
        }

        public int Add(WorkerParameter value)
        {
            return List.Add(value);
        }

        public int Add(int id, string name)
        {
            return List.Add(new WorkerParameter(id, name));
        }

        public void Insert(int index, WorkerParameter value)
        {
            List.Insert(index, value);
        }

        public int IndexOf(WorkerParameter value)
        {
            return List.IndexOf(value);
        }

        public bool Contains(WorkerParameter value)
        {
            return List.Contains(value);
        }

        public void CopyTo(WorkerParameter[] value, int index)
        {
            List.CopyTo(value, index);
        }

        public void Remove(WorkerParameter value)
        {
            List.Remove(value);
        }
        public WorkerParameter[] ToArray()
        {
            WorkerParameter[] array = new WorkerParameter[List.Count];
            List.CopyTo(array, 0);
            return array;
        }
        public WorkerParameter this[int index]
        {
            get
            {
                return (WorkerParameter)List[index];
            }
            set
            {
                List[index] = value;
            }
        }
        public override string ToString()
        {
            return "WorkerCollection";
        }
    }
    public class TWorker : BaseBL
    {
        #region Static
        public static readonly string TABLE_NAME = "TWorker";
        public static readonly string ID__COLUMN_NAME = "ID";
        public static readonly string NAME__COLUMN_NAME = "Name";
        public static readonly string ACTIVE__COLUMN_NAME = "Active";
        #endregion

        #region Protected
        protected int _ID;
        protected string _Name;
        protected Int16 _Active;
        #endregion

        #region Property
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

        public Int16 Active
        {
            get
            {
                return _Active;
            }
            set
            {
                _Active = value;
            }
        }
        #endregion

        #region Constructors
        public TWorker()
        {
            _ID = 0;
        }

        public TWorker(int iD)
        {
            WhereParameterCollection whereColl = new WhereParameterCollection();
            whereColl.Add(ID__COLUMN_NAME, iD, CompareType.Like);

            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                DataSet ds = _DBAccessor.GetTable(TABLE_NAME, whereColl);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    FromDataRow(row);
                }
                else
                {
                    _ID = -1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!this.db_Set)
                {
                    _DBAccessor.Dispose();
                }
            }
        }
        #endregion

        #region Insert/Update/Delete
        public int Insert()
        {
            ParameterCollection coll = new ParameterCollection();
            coll.Add(new Parameter(NAME__COLUMN_NAME, _Name));
            coll.Add(new Parameter(ACTIVE__COLUMN_NAME, _Active));

            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                object obj = _DBAccessor.InsertWithIdentity(TABLE_NAME, coll);
                _ID = Int32.Parse(obj.ToString());
                return _ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!this.db_Set)
                {
                    _DBAccessor.Dispose();
                }
            }
        }

        public int Update()
        {
            ParameterCollection coll = new ParameterCollection();
            coll.Add(new Parameter(NAME__COLUMN_NAME, _Name));
            coll.Add(new Parameter(ACTIVE__COLUMN_NAME, _Active));

            WhereParameterCollection whereColl = new WhereParameterCollection();
            whereColl.Add(new WhereParameter(ID__COLUMN_NAME, _ID, CompareType.Equal));

            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                return _DBAccessor.Update(TABLE_NAME, coll, whereColl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!this.db_Set)
                {
                    _DBAccessor.Dispose();
                }
            }
        }

        public int Delete()
        {
            WhereParameterCollection whereColl = new WhereParameterCollection();
            whereColl.Add(new WhereParameter(ID__COLUMN_NAME, _ID, CompareType.Equal));

            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                return _DBAccessor.Delete(TABLE_NAME, whereColl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!this.db_Set)
                {
                    _DBAccessor.Dispose();
                }
            }
        }
        #endregion

        protected void FromDataRow(DataRow row)
        {
            _ID = (int)row[ID__COLUMN_NAME];
            _Name = row[NAME__COLUMN_NAME] == DBNull.Value ? "" : (string)(row[NAME__COLUMN_NAME]);
            _Active = row[ACTIVE__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[ACTIVE__COLUMN_NAME]);
        }

        public DataSet GetAll()
        {
            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }

                SortParameterCollection sortColl = new SortParameterCollection();
                sortColl.Add(ID__COLUMN_NAME, SortType.Increase);

                return _DBAccessor.GetTable(TABLE_NAME, sortColl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!this.db_Set)
                {
                    _DBAccessor.Dispose();
                }
            }
        }

        public DataSet GetAllActived()
        {
            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }

                WhereParameterCollection whereColl = new WhereParameterCollection();
                whereColl.Add(ACTIVE__COLUMN_NAME, 1, CompareType.Equal);

                SortParameterCollection sortColl = new SortParameterCollection();
                sortColl.Add(ID__COLUMN_NAME, SortType.Increase);

                return _DBAccessor.GetTable(TABLE_NAME, whereColl, sortColl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!this.db_Set)
                {
                    _DBAccessor.Dispose();
                }
            }
        }

        public WorkerCollection GetWorkerCollection()
        {
            WorkerCollection coll = new WorkerCollection();
            DataSet ds = GetAllActived();

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if ((short)row[ACTIVE__COLUMN_NAME] == 1)
                    {
                        coll.Add((int)row[ID__COLUMN_NAME], row[NAME__COLUMN_NAME].ToString());
                    }
                }
            }

            return coll;
        }

        public Byte[] GetBytes()
        {
            Byte[] data = new Byte[10];

            try
            {
                Buffer.BlockCopy(Common.GetBytes(_ID), 0, data, 0, 4);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            return data;
        }

        public static TWorker Parse(Byte[] data)
        {
            if (data == null || data.Length != 10)
            {
                return null;
            }

            int id = Common.ToInt32(data, 0);

            TWorker worker = new TWorker(id);

            if (worker.ID > 0)
            {
                return worker;
            }

            return null;
        }
    }
}
