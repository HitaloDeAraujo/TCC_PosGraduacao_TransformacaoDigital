﻿using SIGO.GestaoProcessoIndustrial.Domain.Interfaces;
using SIGO.GestaoProcessoIndustrial.Domain.Interfaces.Repository;
using SIGO.GestaoProcessoIndustrial.Infra.Context;
using SIGO.GestaoProcessoIndustrial.Infra.Repository;
using SIGO.Infra;
using System;
using System.Threading.Tasks;

namespace SIGO.GestaoProcessoIndustrial.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GestaoProcessoIndustrialDbContext _context;
        private readonly IDapperDbConnection _dapperDbConnection;

        public IEventoRepository Eventos { get; set; }
        public IUsuarioRepository Usuarios { get; set; }

        public UnitOfWork(GestaoProcessoIndustrialDbContext context, IDapperDbConnection dapperDbConnection)
        {
            _context = context;
            _dapperDbConnection = dapperDbConnection;

            Eventos = new EventoRepository(_context, _dapperDbConnection);
            Usuarios = new UsuarioRepository(_context, _dapperDbConnection);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
