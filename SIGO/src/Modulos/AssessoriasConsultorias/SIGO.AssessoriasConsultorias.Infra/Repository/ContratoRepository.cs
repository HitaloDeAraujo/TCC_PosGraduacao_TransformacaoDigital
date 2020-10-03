using Microsoft.EntityFrameworkCore;
using SIGO.AssessoriasConsultorias.Domain.Entities;
using SIGO.AssessoriasConsultorias.Domain.Interfaces.Repository;
using SIGO.AssessoriasConsultorias.Infra.Context;
using SIGO.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.AssessoriasConsultorias.Infra.Repository
{
    public class ContratoRepository : RepositoryBase, IContratoRepository
    {
        private readonly AssessoriasConsultoriasDbContext _context;

        public ContratoRepository(AssessoriasConsultoriasDbContext context, IDapperDbConnection dapperDbConnection) : base(dapperDbConnection)
        {
            _context = context;
        }

        public async Task Salvar(Contrato contrato)
        {
            try
            {
                await _context.Contratos.AddAsync(contrato);
            }
            catch
            {
                throw;
            }
        }

        public void Atualizar(Contrato contrato)
        {
            try
            {
                _context.Entry(contrato).State = EntityState.Modified;
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
                var contrato = await ObterContrato(guid);

                if (contrato == null)
                    throw new Exception();

                contrato.DataExclusao = DateTime.Now;

                Atualizar(contrato);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Contrato> ObterContrato(string guid)
        {
            try
            {
                return await _context.Contratos.SingleOrDefaultAsync(x => x.GUID.ToString().Equals(guid) && x.DataExclusao == null);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Contrato>> ObterContratos()
        {
            try
            {
                return await _context.Contratos.Where(x => x.DataExclusao == null).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}