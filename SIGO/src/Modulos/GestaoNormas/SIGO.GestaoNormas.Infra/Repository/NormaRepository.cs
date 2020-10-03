using Microsoft.EntityFrameworkCore;
using SIGO.GestaoNormas.Domain.Entities;
using SIGO.GestaoNormas.Domain.Interfaces.Repository;
using SIGO.GestaoNormas.Infra.Context;
using SIGO.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.GestaoNormas.Infra.Repository
{
    public class NormaRepository : RepositoryBase, INormaRepository
    {
        private readonly GestaoNormasDbContext _context;

        public NormaRepository(GestaoNormasDbContext context, IDapperDbConnection dapperDbConnection) : base(dapperDbConnection)
        {
            _context = context;
        }

        public async Task Salvar(Norma norma)
        {
            try
            {
                await _context.Normas.AddAsync(norma);
            }
            catch
            {
                throw;
            }
        }

        public void Atualizar(Norma norma)
        {
            try
            {
                _context.Entry(norma).State = EntityState.Modified;
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
                var norma = await ObterNorma(guid);

                if (norma == null)
                    throw new Exception();

                norma.DataExclusao = DateTime.Now;

                Atualizar(norma);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Norma> ObterNorma(string guid)
        {
            try
            {
                return await _context.Normas.SingleOrDefaultAsync(x => x.GUID.ToString().Equals(guid) && x.DataExclusao != null);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Norma>> ObterNormas()
        {
            try
            {
                return await _context.Normas.Where(x => x.DataExclusao != null).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
