using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SIGO.Infra
{
    public class DapperDbConnection : IDapperDbConnection
    {
        private SqlConnection Connection = null;

        public DapperDbConnection(IConfiguration configuration)
        {
            Connection = new SqlConnection(configuration[""]);
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
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

        public SqlConnection GetConnection()
        {
            return Connection;
        }
    }
}
