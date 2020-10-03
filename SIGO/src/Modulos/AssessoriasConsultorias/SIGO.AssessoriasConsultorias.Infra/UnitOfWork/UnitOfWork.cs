using SIGO.AssessoriasConsultorias.Domain.Interfaces;
using SIGO.AssessoriasConsultorias.Domain.Interfaces.Repository;
using SIGO.AssessoriasConsultorias.Infra.Context;
using SIGO.AssessoriasConsultorias.Infra.Repository;
using SIGO.Infra;
using System;
using System.Threading.Tasks;

namespace SIGO.AssessoriasConsultorias.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AssessoriasConsultoriasDbContext _context;
        private readonly IDapperDbConnection _dapperDbConnection;

        public IContratoRepository Contratos { get; set; }
        public IParceiroRepository Parceiros { get; set; }

        public UnitOfWork(AssessoriasConsultoriasDbContext context, IDapperDbConnection dapperDbConnection)
        {
            _context = context;
            _dapperDbConnection = dapperDbConnection;
            //_dapperDbConnection.OpenConnection();

            Contratos = new ContratoRepository(_context, _dapperDbConnection);
            Parceiros = new ParceiroRepository(_context, _dapperDbConnection);
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
