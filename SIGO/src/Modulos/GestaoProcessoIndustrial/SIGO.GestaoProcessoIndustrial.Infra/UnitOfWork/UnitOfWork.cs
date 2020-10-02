using SIGO.GestaoProcessoIndustrial.Domain.Interfaces;
using SIGO.GestaoProcessoIndustrial.Domain.Interfaces.Repository;
using SIGO.GestaoProcessoIndustrial.Infra.Context;
using SIGO.GestaoProcessoIndustrial.Infra.Repository;
using SIGO.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SIGO.GestaoProcessoIndustrial.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GestaoProcessoIndustrialDbContext _context;
        private readonly IDapperDbConnection _dapperDbConnection;

        public IEventoRepository Eventos { get; set; }

        public UnitOfWork(GestaoProcessoIndustrialDbContext context, IDapperDbConnection dapperDbConnection)
        {
            _context = context;
            _dapperDbConnection = dapperDbConnection;
            //_dapperDbConnection.OpenConnection();

            Eventos = new EventoRepository(_context, _dapperDbConnection);
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
