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
            Connection = new MySqlConnection("Server=localhost;DataBase=AssessoriasConsultorias;Uid=root;Pwd=Sigo@28786Ms");
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
