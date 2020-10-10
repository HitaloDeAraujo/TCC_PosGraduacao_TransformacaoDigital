using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace SIGO.Infra
{
    public class DapperDbConnection : IDapperDbConnection
    {
        private MySqlConnection Connection = null;

        public DapperDbConnection(IConfiguration configuration)
        {
            var dapperConnection = configuration["ConnectionStrings:DapperConnection"];
            Connection = new MySqlConnection(dapperConnection);
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

        public MySqlConnection GetConnection()
        {
            return Connection;
        }
    }
}
