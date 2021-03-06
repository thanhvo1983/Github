using System;
using System.Data;
using Kvics.DBAccess;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Specialized;

namespace Kvics.HotMill.BL
{
	/// <summary>
	/// Summary description for TUser.
	/// </summary>
	public class TUser : BaseBL
	{
		#region Static	
		public static readonly string	TABLE_NAME = "TUser";
		public static readonly string	ID__COLUMN_NAME = "ID";
		public static readonly string	WORKERID__COLUMN_NAME = "WorkerID";
		public static readonly string	USERNAME__COLUMN_NAME = "Username";
		public static readonly string	PASSWORD__COLUMN_NAME = "Password";
		public static readonly string	ISADMIN__COLUMN_NAME = "IsAdmin";
		public static readonly string	ACTIVE__COLUMN_NAME = "Active";
		#endregion
        
		#region Protected	
		protected int	_ID;
		protected int	_WorkerID;
		protected string	_Username;
		protected string	_Password;
		protected int	_IsAdmin;
		protected int	_Active;
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

		public int WorkerID
		{
			get
			{
				return _WorkerID;
			}
			set
			{
				_WorkerID = value;
			}
		}

		public string Username
		{
			get
			{
				return _Username;
			}
			set
			{
				_Username = value;
			}
		}

		public string Password
		{
			get
			{
				return _Password;
			}
			set
			{
				_Password = value;
			}
		}

		public int IsAdmin
		{
			get
			{
				return _IsAdmin;
			}
			set
			{
				_IsAdmin = value;
			}
		}

		public int Active
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
		public TUser()
		{
		}
        public TUser(string username)
        {
            WhereParameterCollection whereColl = new WhereParameterCollection();
            whereColl.Add(USERNAME__COLUMN_NAME, username, CompareType.Like);

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
			coll.Add(WORKERID__COLUMN_NAME, _WorkerID);
			coll.Add(USERNAME__COLUMN_NAME, _Username);
			coll.Add(PASSWORD__COLUMN_NAME, _Password);
			coll.Add(ISADMIN__COLUMN_NAME, _IsAdmin);
			coll.Add(ACTIVE__COLUMN_NAME, _Active);

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
			catch(Exception)
			{
				return -1;
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
			coll.Add(WORKERID__COLUMN_NAME, _WorkerID);
			coll.Add(USERNAME__COLUMN_NAME, _Username);
			coll.Add(PASSWORD__COLUMN_NAME, _Password);
			coll.Add(ISADMIN__COLUMN_NAME, _IsAdmin);
			coll.Add(ACTIVE__COLUMN_NAME, _Active);

			WhereParameterCollection whereColl = new WhereParameterCollection();
			whereColl.Add(ID__COLUMN_NAME, _ID, CompareType.Equal);

			try 
			{
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                return _DBAccessor.Update(TABLE_NAME, coll, whereColl);  
			}
			catch(Exception)
			{
				return -1;
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
			whereColl.Add(ID__COLUMN_NAME, _ID, CompareType.Equal);

			try 
			{
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                return _DBAccessor.Delete(TABLE_NAME, whereColl); 
			}
			catch(Exception)
			{
				return -1;
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

        public DataSet GetAll()
        {
            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }
                return _DBAccessor.GetTable(TABLE_NAME);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (!this.db_Set)
                {
                    _DBAccessor.Dispose();
                }
            }
        }

        protected void FromDataRow(DataRow row)
        {
            _ID = (int)row[ID__COLUMN_NAME];
            _WorkerID = row[WORKERID__COLUMN_NAME] == DBNull.Value ? (int)0 : (int)(row[WORKERID__COLUMN_NAME]);
            _Username = row[USERNAME__COLUMN_NAME] == DBNull.Value ? "" : (string)(row[USERNAME__COLUMN_NAME]);
            _Password = row[PASSWORD__COLUMN_NAME] == DBNull.Value ? "" : (string)(row[PASSWORD__COLUMN_NAME]);
            _IsAdmin = row[ISADMIN__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[ISADMIN__COLUMN_NAME]);
            _Active = row[ACTIVE__COLUMN_NAME] == DBNull.Value ? (Int16)0 : (Int16)(row[ACTIVE__COLUMN_NAME]);
        }

        public bool Login(string username, string password)
        {
            try
            {
                if (!this.db_Set)
                {
                    _DBAccessor = new DBAccessor();
                }

                TUser user = new TUser(username);
                if (user != null && user.ID > 0 && user.Active == 1)
                {
                    string md5Pass = EncodePassword(password);

                    return user.Password.CompareTo(md5Pass) == 0 ? true : false;
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                if (!this.db_Set)
                {
                    _DBAccessor.Dispose();
                }
            }
            return false;
        }

        private string EncodePassword(string pass)
        {
            byte[] hashedDataBytes;
            UTF8Encoding encoder = new UTF8Encoding();
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

            StringBuilder sBuilder = new StringBuilder();

            hashedDataBytes = md5Hasher.ComputeHash(encoder.GetBytes(pass));

            for (int i = 0; i < hashedDataBytes.Length; i++)
            {
                sBuilder.Append(hashedDataBytes[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
	}
}
