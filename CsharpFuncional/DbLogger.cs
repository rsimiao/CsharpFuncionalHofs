using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;

namespace CsharpFuncional
{
    public class DbLogger
    {
        string connString;


        public void QuantoTempo()
        {
            Thread.Sleep(2000);
        }

        public void Log(LogMessage msg)
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                int affectedRows = conn.Execute("sp_create_log", msg, commandType: CommandType.StoredProcedure);
            }
        }

        public void LogNew(LogMessage msg) =>
            ConnectionHelperNovo.Connect(connString, c => c.Execute("sp_create_log", msg, commandType: CommandType.StoredProcedure));

        public IEnumerable<LogMessage> GetLogs(DateTime since)
        {
            var sqlGetLogs = "SELECT * FROM [Logs] WHERE {Timestamp} > @since";
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                return conn.Query<LogMessage>(sqlGetLogs, new { since = since });
            }
        }

        public void GetLogsNew(DateTime since) =>
         ConnectionHelperNovo.Connect(connString, c => c.Query<LogMessage>(@"SELECT * FROM [Logs] WHERE {Timestamp} > @since",
             new { since = since }));

    }
}
