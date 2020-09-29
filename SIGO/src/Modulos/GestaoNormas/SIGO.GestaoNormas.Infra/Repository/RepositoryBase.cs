using SIGO.GestaoNormas.Domain.Interfaces.Repository;
using SIGO.GestaoNormas.Infra.Connection;
using SIGO.GestaoNormas.Infra.Context;
using System.Data.SqlClient;

namespace SIGO.GestaoNormas.Infra.Repository
{
    public abstract class RepositoryBase
    {
        protected SqlConnection DapperConnection = null;
        protected SqlConnection DapperReportConnection = null;
        protected GestaoNormasDbContext Context = null;

        public RepositoryBase(IDapperDbConnection dapperDbConnection)
        {
            DapperConnection = ((DapperDbConnection)dapperDbConnection).GetConnection();
            DapperReportConnection = ((DapperDbConnection)dapperDbConnection).GetReportConnection();
        }

        public RepositoryBase(GestaoNormasDbContext context, IDapperDbConnection dapperDbConnection)
        {
            DapperConnection = ((DapperDbConnection)dapperDbConnection).GetConnection();
            DapperReportConnection = ((DapperDbConnection)dapperDbConnection).GetReportConnection();
            Context = context;
        }      
    }
}
