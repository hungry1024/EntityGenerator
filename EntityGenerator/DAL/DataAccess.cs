using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace EntityGenerator.DAL
{
    public static class DataAccess
    {
        public static IDbConnection GetConnection(string connString, SqlType sqlType)
        {
            switch (sqlType)
            {
                case SqlType.MSSql:
                    return new SqlConnection(connString);

                case SqlType.MySql:
                    return new MySqlConnection(connString);

                default:
                    throw new Exception("不支持的数据库类型");
            }
        }
    }

    public enum SqlType
    {
        MSSql = 1,
        MySql = 2
    }
}
