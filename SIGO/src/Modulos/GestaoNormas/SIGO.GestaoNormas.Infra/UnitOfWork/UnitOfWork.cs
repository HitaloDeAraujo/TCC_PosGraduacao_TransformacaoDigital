using SIGO.GestaoNormas.Domain.Interfaces;
using SIGO.GestaoNormas.Domain.Interfaces.Repository;
using SIGO.GestaoNormas.Infra.Context;
using SIGO.GestaoNormas.Infra.Repository;
using SIGO.Infra;
using System;
using System.Threading.Tasks;

namespace SIGO.GestaoNormas.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GestaoNormasDbContext _context;
        private readonly IDapperDbConnection _dapperDbConnection;

        public INormaRepository Normas { get; set; }
        public IRepositorioRepository Repositorios { get; set; }

        public UnitOfWork(GestaoNormasDbContext context, IDapperDbConnection dapperDbConnection)
        {
            _context = context;
            _dapperDbConnection = dapperDbConnection;
            //_dapperDbConnection.OpenConnection();

            Normas = new NormaRepository(_context, _dapperDbConnection);
            Repositorios = new RepositorioRepository(_context, _dapperDbConnection);
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public Task<int> CommitAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}