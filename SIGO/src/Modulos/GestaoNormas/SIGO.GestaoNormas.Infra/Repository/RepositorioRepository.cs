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
    public class RepositorioRepository : RepositoryBase, IRepositorioRepository
    {
        private readonly GestaoNormasDbContext _context;

        public RepositorioRepository(GestaoNormasDbContext context, IDapperDbConnection dbConnection) : base(dbConnection)
        {
            _context = context;
        }

        public async Task Salvar(Repositorio repositorio)
        {
            try
            {
                await _context.Repositorios.AddAsync(repositorio);
            }
            catch
            {
                throw;
            }
        }

        public void Atualizar(Repositorio repositorio)
        {
            try
            {
                _context.Entry(repositorio).State = EntityState.Modified;
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
                var repositorio = await ObterRepositorio(guid);

                if (repositorio == null)
                    throw new Exception();

                repositorio.DataExclusao = DateTime.Now;

                Atualizar(repositorio);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Repositorio> ObterRepositorio(string guid)
        {
            try
            {
                return await _context.Repositorios.SingleOrDefaultAsync(x => x.GUID.ToString().Equals(guid) && x.DataExclusao == null);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Repositorio>> ObterRepositorios()
        {
            try
            {
                return await _context.Repositorios.Where(x => x.DataExclusao == null).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
