using System;


namespace Kvics.DBAccess
{
    public class Constant
    {
        public static readonly string DB_CONNECT_ERROR = "データベース接続エラー発生";
        public static readonly string SQL_ERROR = "SQLエラー発生";
        public static readonly string SQL_QUERY_ERROR = "最終実行SQL文：";
        public static readonly string SQL_QUERY = "ユーザー情報取得SQL：";
        public static readonly string SQL_CONNECTION_NOT_FOUND = "Connection string not found.";
        public static readonly string SQL_CLOSE_CONNECTION_ERROR = "Cannot close connection.";
    }
}
