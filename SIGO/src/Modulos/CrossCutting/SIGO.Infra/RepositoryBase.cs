using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace SIGO.Infra
{
    public abstract class RepositoryBase
    {
        protected SqlConnection DapperConnection = null;
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
