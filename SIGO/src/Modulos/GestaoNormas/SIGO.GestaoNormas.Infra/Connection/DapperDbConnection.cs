using Microsoft.Extensions.Configuration;
using SIGO.GestaoNormas.Domain.Interfaces.Repository;
using System.Data;
using System.Data.SqlClient;

namespace SIGO.GestaoNormas.Infra.Connection
{
    public class DapperDbConnection : IDapperDbConnection
    {
        private SqlConnection Connection = null;
        private SqlConnection ReportConnection = null;

        public DapperDbConnection(IConfiguration configuration)
        {
            Connection = new SqlConnection(configuration[""]);
            ReportConnection = new SqlConnection(configuration[""]);
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();

            if (ReportConnection.State != ConnectionState.Closed)
                ReportConnection.Close();
        }

        public void OpenConnection()
        {
            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
            }
            catch
            {
                throw;
            }
        }

        public void OpenReportConnection()
        {
            try
            {
                if (ReportConnection.State != ConnectionState.Open)
                    ReportConnection.Open();
            }
            catch
            {
                throw;
            }
        }

        public SqlConnection GetConnection()
        {
            return Connection;
        }

        public SqlConnection GetReportConnection()
        {
            return ReportConnection;
        }
    }
}
