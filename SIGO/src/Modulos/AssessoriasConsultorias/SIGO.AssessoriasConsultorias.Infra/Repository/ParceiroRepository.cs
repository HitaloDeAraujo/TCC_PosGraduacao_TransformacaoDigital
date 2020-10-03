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
    public class ParceiroRepository : RepositoryBase, IParceiroRepository
    {
        private readonly AssessoriasConsultoriasDbContext _context;

        public ParceiroRepository(AssessoriasConsultoriasDbContext context, IDapperDbConnection dbConnection) : base(dbConnection)
        {
            _context = context;
        }

        public async Task Salvar(Parceiro parceiro)
        {
            try
            {
                await _context.Parceiros.AddAsync(parceiro);
            }
            catch
            {
                throw;
            }
        }

        public void Atualizar(Parceiro parceiro)
        {
            try
            {
                _context.Entry(parceiro).State = EntityState.Modified;
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
                var parceiro = await ObterParceiro(guid);

                if (parceiro == null)
                    throw new Exception();

                parceiro.DataExclusao = DateTime.Now;

                Atualizar(parceiro);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Parceiro> ObterParceiro(string guid)
        {
            try
            {
                return await _context.Parceiros.SingleOrDefaultAsync(x => x.GUID.ToString().Equals(guid) && x.DataExclusao != null);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Parceiro>> ObterParceiros()
        {
            try
            {
                return await _context.Parceiros.Where(x => x.DataExclusao != null).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
