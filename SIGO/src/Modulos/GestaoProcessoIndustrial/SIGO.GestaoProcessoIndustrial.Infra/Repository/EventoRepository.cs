using Microsoft.EntityFrameworkCore;
using SIGO.GestaoProcessoIndustrial.Domain.Entities;
using SIGO.GestaoProcessoIndustrial.Domain.Interfaces.Repository;
using SIGO.GestaoProcessoIndustrial.Infra.Context;
using SIGO.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.GestaoProcessoIndustrial.Infra.Repository
{
    public class EventoRepository : RepositoryBase, IEventoRepository
    {
        private readonly GestaoProcessoIndustrialDbContext _context;

        public EventoRepository(GestaoProcessoIndustrialDbContext context, IDapperDbConnection dapperDbConnection) : base(dapperDbConnection)
        {
            _context = context;
        }

        public async Task Salvar(Evento evento)
        {
            try
            {
                await _context.Eventos.AddAsync(evento);
            }
            catch
            {
                throw;
            }
        }

        public void Atualizar(Evento evento)
        {
            try
            {
                _context.Entry(evento).State = EntityState.Modified;
            }
            catch
            {
                throw;
            }
        }

        public async Task Excluir(string guid)
        {
            try
            {
                var evento = await ObterEvento(guid);

                if (evento == null)
                    throw new Exception();

                evento.DataExclusao = DateTime.Now;

                Atualizar(evento);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Evento> ObterEvento(string guid)
        {
            try
            {
                return await _context.Eventos.SingleOrDefaultAsync(x => x.GUID.ToString().Equals(guid) && x.DataExclusao == null);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Evento> ObterEventoMaisRecente(int tipoEventoId)
        {
            try
            {
                //LastOrDefault nao esta funcionando
                return await _context.Eventos.Where(x => x.DataExclusao == null && x.TipoEventoID == tipoEventoId).OrderByDescending(x => x.DataCriacao).FirstAsync();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Evento>> ObterEventos()
        {
            try
            {
                return await _context.Eventos.Where(x => x.DataExclusao == null).Include(x => x.TipoEvento).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Evento>> ObterEventos(int tipoEventoId)
        {
            try
            {
                return await _context.Eventos.Where(x => x.DataExclusao == null && x.TipoEventoID == tipoEventoId)
                                             .Include(x => x.TipoEvento)
                                             .ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
