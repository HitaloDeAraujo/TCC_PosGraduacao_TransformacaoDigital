using Microsoft.EntityFrameworkCore;
using SIGO.GestaoNormas.Domain.Entities;
using SIGO.GestaoNormas.Domain.Interfaces.Repository;
using SIGO.GestaoNormas.Infra.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.GestaoNormas.Infra.Repository
{
    public class NormaRepository : RepositoryBase, INormaRepository
    {
        private readonly GestaoNormasDbContext _context;

        public NormaRepository(GestaoNormasDbContext context, IDapperDbConnection dbConnection) : base(dbConnection)
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
                return await _context.Normas.SingleOrDefaultAsync(x => x.GUID.Equals(guid));
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
                List<Norma> normas = new List<Norma>();

                Norma norma = new Norma()
                {
                    GUID = Guid.NewGuid(),
                    Descricao = "Teste"
                };

                normas.Add(norma);

                norma = new Norma()
                {
                    GUID = Guid.NewGuid(),
                    Descricao = "Teste2"
                };

                normas.Add(norma);

                return normas;

                //return await _context.Normas.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
