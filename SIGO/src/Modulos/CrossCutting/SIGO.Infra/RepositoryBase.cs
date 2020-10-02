using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace SIGO.Infra
{
    public abstract class RepositoryBase
    {
        protected SqlConnection DapperConnection = null;
        protected SqlConnection DapperReportConnection = null;
        protected DbContext Context = null;

        public RepositoryBase(IDapperDbConnection dapperDbConnection)
        {
            DapperConnection = ((DapperDbConnection)dapperDbConnection).GetConnection();
            DapperReportConnection = ((DapperDbConnection)dapperDbConnection).GetReportConnection();
        }

        public RepositoryBase(DbContext context, IDapperDbConnection dapperDbConnection)
        {
            DapperConnection = ((DapperDbConnection)dapperDbConnection).GetConnection();
            DapperReportConnection = ((DapperDbConnection)dapperDbConnection).GetReportConnection();
            Context = context;
        }
    }
}
