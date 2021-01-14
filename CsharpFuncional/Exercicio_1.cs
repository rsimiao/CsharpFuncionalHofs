using System;
using System.Data;
using System.Data.SqlClient;

namespace CsharpFuncional
{
    //Utilizamos HOFS para encapsular o using.
    public static class ConnHelper
    {
        public static R Connect<R>(string connString, Func<IDbConnection, R> f)
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                return f(conn);
            }
        }
    }
}
