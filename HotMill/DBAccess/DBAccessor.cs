//////////////////////////////////////////////////////////////////////////
// Copyright @ 2007 Nguyen Thanh Thao									//
// thaonguyenbanggia@yahoo.com											//
//////////////////////////////////////////////////////////////////////////


using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Text;
using System.IO;


using log4net;
using log4net.Config;
using Kvics.PInvoke;

//[assembly: log4net.Config.DOMConfigurator(ConfigFile = "DBAccess.log4net", ConfigFileExtension = "log4net", Watch = true)]

namespace Kvics.DBAccess
{
    public class Log
    {
        static Log _Instance = null;
        static readonly object _Sync = new Object();

        private Log()
        {
            // Using DBAccess.log4net file
            XmlConfigurator.Configure(new FileInfo("DBAccess.log4net"));
        }

        public static Log Instance
        {
            get
            {
                lock (_Sync)
                {
                    if (_Instance == null)
                    {
                        _Instance = new Log();
                    }
                    return _Instance;
                }
            }
        }

        public ILog GetLogger(Type log)
        {
            return LogManager.GetLogger(log);
        }
    }

	public class DBAccessor : IDisposable
	{
        protected static string ConfigConnectionString
        {
            get
            {
                if (System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"] != null)
                {
                    StringBuilder pass = new StringBuilder("kvics.com.vn");
                    string encryptText = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    StringBuilder decrypt = CryptUtil.DecryptString(new StringBuilder(encryptText), pass, CryptUtil.CALG_3DES);
                    return decrypt.ToString();
                }

                return null;
            }
        }

        protected static string _DefaultConnectionString = null;
        public static string DefaultConnectionString
        {
            get
            {
                if (_DefaultConnectionString == null)
                {
                    _DefaultConnectionString = ConfigConnectionString;
                }
                return _DefaultConnectionString;
            }
            set
            {
                _DefaultConnectionString = value;
            }
        }

        private static readonly ILog log = Log.Instance.GetLogger(typeof(DBAccessor));

		private string _ConnectionString = "";

        private SqlConnection _Connection = null;

        private SqlTransaction _Transaction = null;

        public DBAccessor()
        {
            if (DefaultConnectionString != null && DefaultConnectionString.Trim().Length > 0)
            {
                this.ConnectionString = DefaultConnectionString;
            }
            else
            {
                string connectionString = DBAccessor.ConfigConnectionString;
                if (connectionString != null)
                {
                    this.ConnectionString = connectionString;
                }
                else
                {
                    log.Error(Constant.SQL_CONNECTION_NOT_FOUND);
                    throw new Exception(Constant.SQL_CONNECTION_NOT_FOUND);
                }
            }
        }

        public DBAccessor(String ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        protected void Finalize()
        {
            this.Dispose();
            GC.SuppressFinalize(this); 
        }

        public void Dispose()
        {
            if (_Connection != null && _Connection.State == ConnectionState.Open)
            {
                try
                {
                    _Connection.Close();
                }
                catch (Exception ex)
                {
                    log.Error(Constant.SQL_CLOSE_CONNECTION_ERROR, ex);
                }
            }
            _Connection = null;
        }

		public string			ConnectionString
		{
			get
			{
				return _ConnectionString;
			}
			set
			{
				_ConnectionString = value;
                _Connection = GetConnection();
			}
		}

        protected SqlConnection GetConnection()
        {
            try
            {
                SqlConnection m_Connection = new SqlConnection(_ConnectionString);
                m_Connection.Open();
                return m_Connection;
            }
            catch (Exception ex)
            {
                log.Error(Constant.DB_CONNECT_ERROR, ex);
                throw ex;
            }
        }

		public SqlConnection	Connection
		{
			get
			{
                if (_Connection.State == ConnectionState.Closed)
                {
                    _Connection.Open();
                }
                return _Connection;
			}            
		}

        public void BeginTransaction()
        {
            this._Transaction = this._Connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (this._Transaction != null)
            {
                this._Transaction.Commit();
                this._Transaction = null;
            }
        }

        public void RollbackTransaction()
        {
            if (this._Transaction != null)
            {
                this._Transaction.Rollback();
                this._Transaction = null;
            }
        }

        public SqlTransaction Transaction
        {
            get
            {
                return this._Transaction;
            }
        }

		public  bool		FindValue(string strTableName, string columnsName, object objValue)
		{
            SqlCommand myCommand = this.Connection.CreateCommand();
            if (this._Transaction != null)
            {
                myCommand.Transaction = this._Transaction;
            }
			try
			{
				DataSet ds = new DataSet();
				myCommand.CommandText = "select * from [" + strTableName + "] where [" + columnsName + "]=@param1";
				myCommand.Parameters.AddWithValue("@param1", objValue);
				myCommand.CommandType = CommandType.Text;

                if (log.IsDebugEnabled)
                {
                    log.Debug(Constant.SQL_QUERY + myCommand.CommandText);
                }
				
				SqlDataAdapter adap = new SqlDataAdapter(myCommand);
				adap.Fill(ds);
				if (ds.Tables[0].Rows.Count > 0)
				{
					return true;
				}
				return false;
			}
			catch(Exception ex)
			{
                log.Error(Constant.SQL_ERROR, ex);
                log.Error(Constant.SQL_QUERY_ERROR + myCommand.CommandText);
				throw ex;
			}
		}

        public  DataSet     GetTable(string strTableName)
        {
            return GetTable(strTableName, null, null);
        }

        public  DataSet     GetTable(string strTableName, SortParameterCollection sortColl)
        {
            return GetTable(strTableName, null, sortColl);
        }

        public  DataSet     GetTable(string strTableName, WhereParameterCollection whereColl)
        {
            return GetTable(strTableName, whereColl, null);
        }

        public  DataSet     GetTable(string strTableName, 
                WhereParameterCollection whereColl,
                SortParameterCollection sortColl)
		{
            SqlCommand myCommand = this.Connection.CreateCommand();
            if (this._Transaction != null)
            {
                myCommand.Transaction = this._Transaction;
            }
			try
			{
				DataSet ds = new DataSet();
				string strSQL = "select * from [" + strTableName + "]";

                if (whereColl != null && whereColl.Count > 0)
                {
                    strSQL += " where ";
                    for (int i = 0; i < whereColl.Count; i++)
                    {
                        if (i > 0)
                        {
                            strSQL += " and ";
                        }
                        strSQL += "[" + whereColl[i].Name + "]" 
                            + whereColl[i].CompareString 
                            + "@" + whereColl[i].Name;
                    }
                }

                if (sortColl!= null && sortColl.Count > 0)
				{
					strSQL += " order by ";
					for (int i = 0; i < sortColl.Count; i++)
					{
                        if (i > 0)
                        {
                            strSQL += " , ";
                        }
                        strSQL += "[" + sortColl[i].Name 
                            + "] " + sortColl[i].SortString;
					}
				}
				
				myCommand.CommandText = strSQL;
				myCommand.CommandType = CommandType.Text;

                if (whereColl != null && whereColl.Count > 0)
                {
                    for (int i = 0; i < whereColl.Count; i++)
                    {
                        myCommand.Parameters.AddWithValue("@" + whereColl[i].Name,
                            whereColl[i].Value);
                    }
                }

                if (log.IsDebugEnabled)
                {
                    log.Debug(Constant.SQL_QUERY + myCommand.CommandText);
                }
				
				SqlDataAdapter adap = new SqlDataAdapter(myCommand);
				adap.Fill(ds);
				return ds;
			}
			catch(Exception ex)
			{
                log.Error(Constant.SQL_ERROR, ex);
                log.Error(Constant.SQL_QUERY_ERROR + myCommand.CommandText);
                throw ex;
			}
		}

        public  DataSet     GetColumns(string strTableName,
                string[] columnsName,
                WhereParameterCollection whereColl,
                SortParameterCollection sortColl)
        {
            SqlCommand myCommand = this.Connection.CreateCommand();
            if (this._Transaction != null)
            {
                myCommand.Transaction = this._Transaction;
            }
            try
            {
                DataSet ds = new DataSet();
                string strSQL = "select ";
                if (columnsName == null || columnsName.Length < 1)
                {
                    strSQL += " * ";
                }
                else
                {
                    for (int i = 0; i < columnsName.Length; i++)
                    {
                        if (i > 0)
                        {
                            strSQL += " , ";
                        }
                        strSQL += "[" + columnsName[i] + "]";
                    }
                }
                strSQL += " from [" + strTableName + "]";

                if (whereColl != null && whereColl.Count > 0)
                {
                    strSQL += " where ";
                    for (int i = 0; i < whereColl.Count; i++)
                    {
                        if (i > 0)
                        {
                            strSQL += " and ";
                        }
                        strSQL += "[" + whereColl[i].Name + "]"
                            + whereColl[i].CompareString
                            + "@" + whereColl[i].Name;
                    }
                }

                if (sortColl != null && sortColl.Count > 0)
                {
                    strSQL += " order by ";
                    for (int i = 0; i < sortColl.Count; i++)
                    {
                        if (i > 0)
                        {
                            strSQL += " , ";
                        }
                        strSQL += "[" + sortColl[i].Name
                            + "] " + sortColl[i].SortString;
                    }
                }

                myCommand.CommandText = strSQL;
                myCommand.CommandType = CommandType.Text;

                if (whereColl != null && whereColl.Count > 0)
                {
                    for (int i = 0; i < whereColl.Count; i++)
                    {
                        myCommand.Parameters.AddWithValue("@" + whereColl[i].Name,
                            whereColl[i].Value);
                    }
                }

                if (log.IsDebugEnabled)
                {
                    log.Debug(Constant.SQL_QUERY + myCommand.CommandText);
                }

                SqlDataAdapter adap = new SqlDataAdapter(myCommand);
                adap.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                log.Error(Constant.SQL_ERROR, ex);
                log.Error(Constant.SQL_QUERY_ERROR + myCommand.CommandText);
                throw ex;
            }
        }

        public  DataSet     GetColumns(string strTableName,
                string[] columnsName)
        {
            return GetColumns(strTableName, columnsName, null, null);
        }

        public  DataSet     GetColumns(string strTableName,
                string[] columnsName,
                WhereParameterCollection whereColl)
        {
            return GetColumns(strTableName, columnsName, whereColl, null);
        }

        public  DataSet     GetColumns(string strTableName,
                string[] columnsName,
                SortParameterCollection sortColl)
        {
            return GetColumns(strTableName, columnsName, null, sortColl);
        }

		public  object	    GetValue(string strTableName, 
                WhereParameterCollection whereColl, 
                string columnsName)
		{
            string strSQL = "select [" + columnsName + "] from [" + strTableName + "]";
            if (whereColl != null && whereColl.Count > 0)
            {
                strSQL += " where ";
                for (int i = 0; i < whereColl.Count; i++)
                {
                    if (i > 0)
                    {
                        strSQL += " and ";
                    }
                    strSQL += "[" + whereColl[i].Name + "]" + whereColl[i].CompareString
                        + "@" + whereColl[i].Name;
                }
            }
            SqlCommand myCommand = this.Connection.CreateCommand();
            if (this._Transaction != null)
            {
                myCommand.Transaction = this._Transaction;
            }
			try
			{
				myCommand.CommandText = strSQL;
				myCommand.CommandType = CommandType.Text;

                if (log.IsDebugEnabled)
                {
                    log.Debug(Constant.SQL_QUERY + myCommand.CommandText);
                }

                if (whereColl != null && whereColl.Count > 0)
                {
                    for (int i = 0; i < whereColl.Count; i++)
                    {
                        myCommand.Parameters.AddWithValue("@" + whereColl[i].Name,
                            whereColl[i].Value);
                    }
                }
				
				return myCommand.ExecuteScalar();
			}
			catch(Exception ex)
			{
                log.Error(Constant.SQL_ERROR, ex);
                log.Error(Constant.SQL_QUERY_ERROR + myCommand.CommandText);
                throw ex;
			}
			finally
			{
				if(myCommand != null 
						&& myCommand.Connection != null 
						&& myCommand.Connection.State == ConnectionState.Open)
					myCommand.Connection.Close();
			}
		}

        public  DataSet     GetPage(string strTableName, 
                SortParameterCollection sortCollection, 
                int PageNo, int PageSize)
        {
            return GetPage(strTableName, null, sortCollection, PageNo, PageSize);
        }

        public  DataSet     GetPage(string strTableName, 
                WhereParameterCollection whereColl, 
                SortParameterCollection sortColl, 
                int PageNo, int PageSize)
        {
            if (sortColl == null || sortColl.Count < 1)
            {
                throw new Exception("Invalid function call. Function \"DataAccess.DataAccessor.GetPage()\" must have at least one sort column. ");
            }

            string strSQL = "select ROW_NUMBER() OVER (ORDER BY ";
            
            for (int i = 0; i < sortColl.Count; i++)
            {
                if (i > 0)
                {
                    strSQL += " , ";
                }
                strSQL += "[" + sortColl[i].Name + "] " 
                    + sortColl[i].SortString;
            }

            strSQL += " ) as row_number_temp, * from [" + strTableName + "]";

            if (whereColl != null && whereColl.Count > 0)
            {
                strSQL += " where ";
                for (int i = 0; i < whereColl.Count; i++)
                {
                    if (i > 0)
                    {
                        strSQL += " and ";
                    }
                    strSQL += "[" + whereColl[i].Name + "]"
                        + whereColl[i].CompareString
                        + "@" + whereColl[i].Name;
                }
            }

            strSQL = " select * from ( " + strSQL + " ) as Result where row_number_temp between " 
                + ((int)((PageNo - 1) * PageSize + 1)).ToString() 
                + " and " + ((int)((PageNo) * PageSize)).ToString();

            SqlCommand myCommand = this.Connection.CreateCommand();
            if (this._Transaction != null)
            {
                myCommand.Transaction = this._Transaction;
            }
            try
            {
                myCommand.CommandText = strSQL;
                myCommand.CommandType = CommandType.Text;

                if (log.IsDebugEnabled)
                {
                    log.Debug(Constant.SQL_QUERY + myCommand.CommandText);
                }

                if (whereColl != null && whereColl.Count > 0)
                {
                    for (int i = 0; i < whereColl.Count; i++)
                    {
                        myCommand.Parameters.AddWithValue("@" + whereColl[i].Name,
                            whereColl[i].Value);
                    }
                }

                SqlDataAdapter adap = new SqlDataAdapter(myCommand);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                log.Error(Constant.SQL_ERROR, ex);
                log.Error(Constant.SQL_QUERY_ERROR + myCommand.CommandText);
                throw ex;
            }
        }

        public DataSet GetPageOfSQLString(string sqlString,
                SortParameterCollection sortColl,
                int PageNo, int PageSize)
        {
            return GetPageOfSQLString(sqlString, null, sortColl, PageNo, PageSize);
        }

        public DataSet GetPageOfSQLString(string sqlString,
                WhereParameterCollection whereColl, 
                SortParameterCollection sortColl,
                int PageNo, int PageSize)
        {
            if (sortColl == null || sortColl.Count < 1)
            {
                throw new Exception("Invalid function call. Function \"DataAccess.DataAccessor.GetPage()\" must have at least one sort column. ");
            }

            string strSQL = "select ROW_NUMBER() OVER (ORDER BY ";

            for (int i = 0; i < sortColl.Count; i++)
            {
                if (i > 0)
                {
                    strSQL += " , ";
                }
                strSQL += "table_temp_getpage.[" + sortColl[i].Name + "] "
                    + sortColl[i].SortString;
            }

            strSQL += " ) as row_number_temp, table_temp_getpage.* from (" + sqlString + ") as table_temp_getpage ";

            strSQL = " select * from ( " + strSQL + " ) as table_temp_getpage_result where row_number_temp between "
                + ((int)((PageNo - 1) * PageSize + 1)).ToString()
                + " and " + ((int)((PageNo) * PageSize)).ToString();

            SqlCommand myCommand = this.Connection.CreateCommand();
            if (this._Transaction != null)
            {
                myCommand.Transaction = this._Transaction;
            }
            try
            {
                myCommand.CommandText = strSQL;
                myCommand.CommandType = CommandType.Text;

                if (log.IsDebugEnabled)
                {
                    log.Debug(Constant.SQL_QUERY + myCommand.CommandText);
                }

                if (whereColl != null && whereColl.Count > 0)
                {
                    for (int i = 0; i < whereColl.Count; i++)
                    {
                        myCommand.Parameters.AddWithValue("@" + whereColl[i].Name,
                            whereColl[i].Value);
                    }
                }

                SqlDataAdapter adap = new SqlDataAdapter(myCommand);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                log.Error(Constant.SQL_ERROR, ex);
                log.Error(Constant.SQL_QUERY_ERROR + myCommand.CommandText);
                throw ex;
            }
        }

        public  long        RecordCount(string strTableName)
        {
            return RecordCount(strTableName, null);
        }
        public  long        RecordCount(string strTableName, WhereParameterCollection whereColl)
        {
            string strSQL = " select count(*) from [" + strTableName + "]";
            ParameterCollection paramsColl = new ParameterCollection();
            if (whereColl != null && whereColl.Count > 0)
            {
                strSQL += " where ";
                for (int i = 0; i < whereColl.Count; i++)
                {
                    if (i > 0)
                    {
                        strSQL += " and ";
                    }
                    strSQL += "[" + whereColl[i].Name + "]"
                        + whereColl[i].CompareString
                        + "@" + whereColl[i].Name;

                    paramsColl.Add(whereColl[i].Name, whereColl[i].Value);
                }
            }
            
            try
            {
                return Int64.Parse(ExecuteScalaString(strSQL, paramsColl).ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public  long        RecordCountOfSQLString(string sqlString)
        {
            return RecordCountOfSQLString(sqlString, null);
        }
        public  long        RecordCountOfSQLString(string sqlString, WhereParameterCollection whereColl)
        {
            string strSQL = " select count(*) from (" + sqlString + ") as table_temp_recordcount";
            ParameterCollection paramsColl = new ParameterCollection();
            if (whereColl != null && whereColl.Count > 0)
            {
                for (int i = 0; i < whereColl.Count; i++)
                {
                    paramsColl.Add(whereColl[i].Name, whereColl[i].Value);
                }
            }

            try
            {
                return Int64.Parse(ExecuteScalaString(strSQL, paramsColl).ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  object      MaxValue(string strTableName, 
                string columnsName, 
                WhereParameterCollection whereColl)
		{
			string strSQL = " select max([" + columnsName + "]) from " + strTableName;
            ParameterCollection paramsColl = new ParameterCollection();
            if (whereColl != null && whereColl.Count > 0)
            {
                strSQL += " where ";
                for (int i = 0; i < whereColl.Count; i++)
                {
                    if (i > 0)
                    {
                        strSQL += " and ";
                    }
                    strSQL += "[" + whereColl[i].Name + "]"
                        + whereColl[i].CompareString
                        + "@" + whereColl[i].Name;

                    paramsColl.Add(whereColl[i].Name, whereColl[i].Value);
                }
            }
			try
			{
                return ExecuteScalaString(strSQL, paramsColl);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
        public  object      MaxValue(string strTableName, string columnsName)
        {
            return MaxValue(strTableName, columnsName, null);
        }
        public  object      MinValue(string strTableName,
                string columnsName,
                WhereParameterCollection whereColl)
        {
            string strSQL = " select min([" + columnsName + "]) from " + strTableName;
            ParameterCollection paramsColl = new ParameterCollection();
            if (whereColl != null && whereColl.Count > 0)
            {
                strSQL += " where ";
                for (int i = 0; i < whereColl.Count; i++)
                {
                    if (i > 0)
                    {
                        strSQL += " and ";
                    }
                    strSQL += "[" + whereColl[i].Name + "]"
                        + whereColl[i].CompareString
                        + "@" + whereColl[i].Name;

                    paramsColl.Add(whereColl[i].Name, whereColl[i].Value);
                }
            }
            try
            {
                return ExecuteScalaString(strSQL, paramsColl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public  object	    MinValue(string strTableName, string columnsName)
		{
            return MinValue(strTableName, columnsName, null);
		}
		public  int		    GetNewID(string strTableName, string columnsName)
		{
			object obj = MaxValue(strTableName, columnsName);
			if (obj == null || obj == DBNull.Value)
			{
				return 1;
			}
			return ((int)(obj)) + 1;
		}
		
        public  DataSet	    GetTop(string strTableName,
                string[] columnsName,
                int iTop, 
                WhereParameterCollection whereColl, 
                SortParameterCollection sortColl)
		{
            SqlCommand myCommand = this.Connection.CreateCommand();
            if (this._Transaction != null)
            {
                myCommand.Transaction = this._Transaction;
            }
            try
            {
                DataSet ds = new DataSet();
                string strSQL = "select top " + iTop.ToString() + " ";
                if (columnsName == null || columnsName.Length < 1)
                {
                    strSQL += " * ";
                }
                else
                {
                    for (int i = 0; i < columnsName.Length; i++)
                    {
                        if (i > 0)
                        {
                            strSQL += " , ";
                        }
                        strSQL += "[" + columnsName[i] + "]";
                    }
                }
                strSQL += " from [" + strTableName + "]";

                if (whereColl != null && whereColl.Count > 0)
                {
                    strSQL += " where ";
                    for (int i = 0; i < whereColl.Count; i++)
                    {
                        if (i > 0)
                        {
                            strSQL += " and ";
                        }
                        strSQL += "[" + whereColl[i].Name + "]"
                            + whereColl[i].CompareString
                            + "@" + whereColl[i].Name;
                    }
                }

                if (sortColl != null && sortColl.Count > 0)
                {
                    strSQL += " order by ";
                    for (int i = 0; i < sortColl.Count; i++)
                    {
                        if (i > 0)
                        {
                            strSQL += " , ";
                        }
                        strSQL += "[" + sortColl[i].Name
                            + "] " + sortColl[i].SortString;
                    }
                }

                myCommand.CommandText = strSQL;
                myCommand.CommandType = CommandType.Text;

                if (whereColl != null && whereColl.Count > 0)
                {
                    for (int i = 0; i < whereColl.Count; i++)
                    {
                        myCommand.Parameters.AddWithValue("@" + whereColl[i].Name,
                            whereColl[i].Value);
                    }
                }

                if (log.IsDebugEnabled)
                {
                    log.Debug(Constant.SQL_QUERY + myCommand.CommandText);
                }

                SqlDataAdapter adap = new SqlDataAdapter(myCommand);
                adap.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                log.Error(Constant.SQL_ERROR, ex);
                log.Error(Constant.SQL_QUERY_ERROR + myCommand.CommandText);
                throw ex;
            }
		}

        public  DataSet     GetTop(string strTableName,
                int iTop,
                WhereParameterCollection whereColl,
                SortParameterCollection sortColl)
        {
            return GetTop(strTableName, null, iTop, whereColl, sortColl);
        }

        public  DataSet     GetTop(string strTableName,
                int iTop,
                WhereParameterCollection whereColl)
        {
            return GetTop(strTableName, null, iTop, whereColl, null);
        }

        public  DataSet     GetTop(string strTableName,
                int iTop,
                SortParameterCollection sortColl)
        {
            return GetTop(strTableName, null, iTop, null, sortColl);
        }

        public  DataSet     GetTop(string strTableName,
                int iTop)
        {
            return GetTop(strTableName, null, iTop, null, null);
        }

        public  DataSet     GetTop(string strTableName,
                string[] columnsName,
                int iTop,
                SortParameterCollection sortColl)
        {
            return GetTop(strTableName, columnsName, iTop, null, sortColl);
        }

        public  DataSet     GetTop(string strTableName,
                string[] columnsName,
                int iTop,
                WhereParameterCollection whereColl)
        {
            return GetTop(strTableName, columnsName, iTop, whereColl, null);
        }

        public  DataSet     GetTop(string strTableName,
                string[] columnsName,
                int iTop)
        {
            return GetTop(strTableName, columnsName, iTop, null, null);
        }
		
		public  DataSet	    ExecuteQueryProcedure(string strProcedureName,ParameterCollection paramColl)
		{
            SqlCommand myCommand = this.Connection.CreateCommand();
            if (this._Transaction != null)
            {
                myCommand.Transaction = this._Transaction;
            }
			try
			{
				DataSet ds = new DataSet();
				myCommand.CommandText = strProcedureName;
				myCommand.CommandType = CommandType.StoredProcedure;
				for (int i=0; i<paramColl.Count; i++)
				{
					myCommand.Parameters.AddWithValue(paramColl[i].Name, paramColl[i].Value);
				}
				SqlDataAdapter adap = new SqlDataAdapter(myCommand);
				adap.Fill(ds);
				return ds;
			}
			catch(Exception ex)
			{
                log.Error(Constant.SQL_ERROR, ex);
                log.Error(Constant.SQL_QUERY_ERROR + myCommand.CommandText);
                throw ex;
			}
		}

		public  int         ExecuteNonQueryProcedure(string strProcedureName,ParameterCollection paramColl)
		{
            SqlCommand myCommand = this.Connection.CreateCommand();
            if (this._Transaction != null)
            {
                myCommand.Transaction = this._Transaction;
            }
			try
			{
				DataSet ds = new DataSet();
				myCommand.CommandText = strProcedureName;
				myCommand.CommandType = CommandType.StoredProcedure;
				for (int i=0; i<paramColl.Count; i++)
				{
					myCommand.Parameters.AddWithValue(paramColl[i].Name, paramColl[i].Value);
				}
				return myCommand.ExecuteNonQuery();
			}
			catch(Exception ex)
			{
                log.Error(Constant.SQL_ERROR, ex);
                log.Error(Constant.SQL_QUERY_ERROR + myCommand.CommandText);
                throw ex;
			}
		}

		public  object      ExecuteScalaProcedure(string strProcedureName,ParameterCollection paramColl)
		{
            SqlCommand myCommand = this.Connection.CreateCommand();
            if (this._Transaction != null)
            {
                myCommand.Transaction = this._Transaction;
            }
			try
			{
				DataSet ds = new DataSet();
				myCommand.CommandText = strProcedureName;
				myCommand.CommandType = CommandType.StoredProcedure;
				for (int i=0; i<paramColl.Count; i++)
				{
					myCommand.Parameters.AddWithValue(paramColl[i].Name, paramColl[i].Value);
				}
                return myCommand.ExecuteScalar();
			}
			catch(Exception ex)
			{
                log.Error(Constant.SQL_ERROR, ex);
                log.Error(Constant.SQL_QUERY_ERROR + myCommand.CommandText);
                throw ex;
			}
		}

		public  DataSet	    ExecuteQueryString(string strSQL)
		{
            return ExecuteQueryString(strSQL, null);
		}

        public  DataSet     ExecuteQueryString(string strSQL, ParameterCollection paramsColl)
        {
            SqlDataAdapter adap = new SqlDataAdapter();
            SqlCommand myCommand = this.Connection.CreateCommand();
            if (this._Transaction != null)
            {
                myCommand.Transaction = this._Transaction;
            }
            try
            {
                DataSet ds = new DataSet();

                myCommand.CommandText = strSQL;
                myCommand.CommandType = CommandType.Text;

                if (log.IsDebugEnabled)
                {
                    log.Debug(Constant.SQL_QUERY + myCommand.CommandText);
                }
                if (paramsColl != null)
                {
                    for (int i = 0; i < paramsColl.Count; i++)
                    {
                        myCommand.Parameters.AddWithValue(
                            "@" + paramsColl[i].Name, 
                            paramsColl[i].Value);
                    }
                }
                adap.SelectCommand = myCommand;
                adap.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                log.Error(Constant.SQL_ERROR, ex);
                log.Error(Constant.SQL_QUERY_ERROR + myCommand.CommandText);
                throw ex;
            }
        }
        
		public  int		    ExecuteNonQueryString(string strSQL)
		{
            return ExecuteNonQueryString(strSQL, null);
		}

        public  int         ExecuteNonQueryString(string strSQL, ParameterCollection paramsColl)
        {
            SqlCommand myCommand = this.Connection.CreateCommand();
            if (this._Transaction != null)
            {
                myCommand.Transaction = this._Transaction;
            }
            try
            {
                myCommand.CommandText = strSQL;
                myCommand.CommandType = CommandType.Text;

                if (paramsColl != null)
                {
                    for (int i = 0; i < paramsColl.Count; i++)
                    {
                        myCommand.Parameters.AddWithValue(
                                "@" + paramsColl[i].Name,
                                paramsColl[i].Value);
                    }
                }

                if (log.IsDebugEnabled)
                {
                    log.Debug(Constant.SQL_QUERY + myCommand.CommandText);
                }

                int iRowCount = myCommand.ExecuteNonQuery();
                return iRowCount;
            }
            catch (Exception ex)
            {
                log.Error(Constant.SQL_ERROR, ex);
                log.Error(Constant.SQL_QUERY_ERROR + myCommand.CommandText);
                throw ex;
            }
        }

        public  object	    ExecuteScalaString(string strSQL)
		{
            return ExecuteScalaString(strSQL, null);
		}

        public  object	    ExecuteScalaString(string strSQL, ParameterCollection paramsColl)
		{
            SqlCommand myCommand = this.Connection.CreateCommand();
            if (this._Transaction != null)
            {
                myCommand.Transaction = this._Transaction;
            }

			try
			{
				myCommand.CommandText = strSQL;
				myCommand.CommandType = CommandType.Text;

                if (paramsColl != null)
                {
                    for (int i = 0; i < paramsColl.Count; i++)
                    {
                        myCommand.Parameters.AddWithValue(
                                "@" + paramsColl[i].Name, 
                                paramsColl[i].Value);
                    }
                }

                if (log.IsDebugEnabled)
                {
                    log.Debug(Constant.SQL_QUERY + myCommand.CommandText);
                }

				object obj = myCommand.ExecuteScalar();
				return obj;
			}
			catch(Exception ex)
			{
                log.Error(Constant.SQL_ERROR, ex);
                log.Error(Constant.SQL_QUERY_ERROR + myCommand.CommandText);
                throw ex;
			}
		}

		public  int         Insert(string strTableName, ParameterCollection paramsColl)
        {
            if (paramsColl == null || paramsColl.Count < 1)
            {
                return 0;
            }

            SqlCommand myCommand = this.Connection.CreateCommand();
            if (this._Transaction != null)
            {
                myCommand.Transaction = this._Transaction;
            }
            try
            {
                string strSQL = " INSERT INTO [" + strTableName + "] ( ";
                string values = " VALUES (";

                for (int i = 0; i < paramsColl.Count; i++)
                {
                    if (i > 0)
                    {
                        strSQL += ", ";
                        values += ", ";
                    }
                    strSQL += "["
                            + paramsColl[i].Name + "]";
                    values += "@" + paramsColl[i].Name;
                }

                values += " ) ";
                strSQL += " ) " + values;

                myCommand.CommandText = strSQL;
                myCommand.CommandType = CommandType.Text;

                for (int i = 0; i < paramsColl.Count; i++)
                {
                    myCommand.Parameters.AddWithValue(
                            "@" + paramsColl[i].Name,
                            paramsColl[i].Value);
                }

                if (log.IsDebugEnabled)
                {
                    log.Debug(Constant.SQL_QUERY + myCommand.CommandText);
                }

                return myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                log.Error(Constant.SQL_ERROR, ex);
                log.Error(Constant.SQL_QUERY_ERROR + myCommand.CommandText);
                throw ex;
            }
        }

        public  object      InsertWithIdentity(string strTableName, ParameterCollection paramsColl)
        {
            if (paramsColl == null || paramsColl.Count < 1)
            {
                return 0;
            }

            SqlCommand myCommand = this.Connection.CreateCommand();
            if (this._Transaction != null)
            {
                myCommand.Transaction = this._Transaction;
            }
            try
            {
                string strSQL = " INSERT INTO [" + strTableName + "] ( ";
                string values = " VALUES (";

                for (int i = 0; i < paramsColl.Count; i++)
                {
                    if (i > 0)
                    {
                        strSQL += ", ";
                        values += ", ";
                    }
                    strSQL += "["
                            + paramsColl[i].Name + "]";
                    values += "@" + paramsColl[i].Name;
                }

                values += " ) ";
                strSQL += " ) " + values;

                strSQL += "; SELECT @@IDENTITY AS 'Identity';";

                myCommand.CommandText = strSQL;
                myCommand.CommandType = CommandType.Text;

                for (int i = 0; i < paramsColl.Count; i++)
                {
                    myCommand.Parameters.AddWithValue(
                            "@" + paramsColl[i].Name,
                            paramsColl[i].Value);
                }

                if (log.IsDebugEnabled)
                {
                    log.Debug(Constant.SQL_QUERY + myCommand.CommandText);
                }

                return myCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                log.Error(Constant.SQL_ERROR, ex);
                log.Error(Constant.SQL_QUERY_ERROR + myCommand.CommandText);
                throw ex;
            }
        }

        public  int         Update(string strTableName, ParameterCollection paramsColl, WhereParameterCollection whereColl)
        {
            if (paramsColl == null || paramsColl.Count < 1)
            {
                return 0;
            }

            SqlCommand myCommand = this.Connection.CreateCommand();
            if (this._Transaction != null)
            {
                myCommand.Transaction = this._Transaction;
            }
            try
            {
                string strSQL = " UPDATE [" + strTableName + "] SET ";

                for (int i = 0; i < paramsColl.Count; i++)
                {
                    if (i > 0)
                    {
                        strSQL += ", ";
                    }
                    strSQL += "["
                            + paramsColl[i].Name + "]"
                            + " = @" + paramsColl[i].Name;
                }

                if (whereColl != null && whereColl.Count > 0)
                {
                    strSQL += " where ";
                    for (int i = 0; i < whereColl.Count; i++)
                    {
                        if (i > 0)
                        {
                            strSQL += " and ";
                        }
                        strSQL += "[" + whereColl[i].Name + "]"
                            + whereColl[i].CompareString
                            + "@" + whereColl[i].Name;
                    }
                }

                myCommand.CommandText = strSQL;
                myCommand.CommandType = CommandType.Text;

                for (int i = 0; i < paramsColl.Count; i++)
                {
                    myCommand.Parameters.AddWithValue(
                            "@" + paramsColl[i].Name,
                            paramsColl[i].Value);
                }

                if (whereColl != null && whereColl.Count > 0)
                {
                    for (int i = 0; i < whereColl.Count; i++)
                    {
                        myCommand.Parameters.AddWithValue("@" + whereColl[i].Name,
                            whereColl[i].Value);
                    }
                }

                if (log.IsDebugEnabled)
                {
                    log.Debug(Constant.SQL_QUERY + myCommand.CommandText);
                }

                return myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                log.Error(Constant.SQL_ERROR, ex);
                log.Error(Constant.SQL_QUERY_ERROR + myCommand.CommandText);
                throw ex;
            }
        }

        public  int         Delete(string strTableName, WhereParameterCollection whereColl)
        {
            SqlCommand myCommand = this.Connection.CreateCommand();
            if (this._Transaction != null)
            {
                myCommand.Transaction = this._Transaction;
            }
            try
            {
                string strSQL = " DELETE FROM [" + strTableName + "]";

                if (whereColl != null && whereColl.Count > 0)
                {
                    strSQL += " WHERE ";
                    for (int i = 0; i < whereColl.Count; i++)
                    {
                        if (i > 0)
                        {
                            strSQL += " AND ";
                        }
                        strSQL += "[" + whereColl[i].Name + "]"
                            + whereColl[i].CompareString
                            + "@" + whereColl[i].Name;
                    }
                }

                myCommand.CommandText = strSQL;
                myCommand.CommandType = CommandType.Text;

                if (whereColl != null && whereColl.Count > 0)
                {
                    for (int i = 0; i < whereColl.Count; i++)
                    {
                        myCommand.Parameters.AddWithValue("@" + whereColl[i].Name,
                            whereColl[i].Value);
                    }
                }

                if (log.IsDebugEnabled)
                {
                    log.Debug(Constant.SQL_QUERY + myCommand.CommandText);
                }

                return myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                log.Error(Constant.SQL_ERROR, ex);
                log.Error(Constant.SQL_QUERY_ERROR + myCommand.CommandText);
                throw ex;
            }
        }
	}
}
