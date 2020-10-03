using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace SIGO.Infra
{
    public abstract class RepositoryBase
    {
        protected MySqlConnection DapperConnection = null;
        protected DbContext Context = null;

        public RepositoryBase(IDapperDbConnection dapperDbConnection)
        {
            DapperConnection = ((DapperDbConnection)dapperDbConnection).GetConnection();
        }

        public RepositoryBase(DbContext context, IDapperDbConnection dapperDbConnection)
        {
            DapperConnection = ((DapperDbConnection)dapperDbConnection).GetConnection();
            Context = context;
        }
    }
}
