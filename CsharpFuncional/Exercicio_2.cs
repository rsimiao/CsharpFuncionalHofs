using System;
using System.Data;
using System.Data.SqlClient;

namespace CsharpFuncional
{
    //Aqui deixamos o próprio using de forma abstrata utilizando HOF.
    public static class F
    {
        public static R Using<TDisp, R>(TDisp disposable, Func<TDisp, R> f) where TDisp : IDisposable
        {
            using (disposable) return f(disposable);
        }
    }

    //Helper utilizando o using genérico;
    public static class ConnectionHelperNovo
    {
        public static R Connect<R>(string connStr, Func<IDbConnection, R> f)
                   => F.Using(new SqlConnection(connStr), conn => { conn.Open(); return f(conn); });
    }

}
