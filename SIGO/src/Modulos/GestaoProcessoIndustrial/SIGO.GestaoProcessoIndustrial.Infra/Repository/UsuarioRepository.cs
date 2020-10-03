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
    public class UsuarioRepository : RepositoryBase, IUsuarioRepository
    {
        private readonly GestaoProcessoIndustrialDbContext _context;

        public UsuarioRepository(GestaoProcessoIndustrialDbContext context, IDapperDbConnection dapperDbConnection) : base(dapperDbConnection)
        {
            _context = context;
        }

        public async Task Salvar(Usuario usuario)
        {
            try
            {
                await _context.Usuarios.AddAsync(usuario);
            }
            catch
            {
                throw;
            }
        }

        public void Atualizar(Usuario usuario)
        {
            try
            {
                _context.Entry(usuario).State = EntityState.Modified;
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
                var usuario = await ObterUsuario(guid);

                if (usuario == null)
                    throw new Exception();

                usuario.DataExclusao = DateTime.Now;

                Atualizar(usuario);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Usuario> ObterUsuario(string guid)
        {
            try
            {
                return await _context.Usuarios.SingleOrDefaultAsync(x => x.GUID.ToString().Equals(guid) && x.DataExclusao == null);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Usuario> ObterUsuarioPorMatricula(string matricula)
        {
            try
            {
                return await _context.Usuarios.SingleOrDefaultAsync(x => x.Matricula.ToString().Equals(matricula) && x.DataExclusao == null);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Usuario>> ObterUsuarios()
        {
            try
            {
                return await _context.Usuarios.Where(x => x.DataExclusao == null).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Autenticar(string nome, string senha)
        {
            throw new NotImplementedException();
        }

       
    }
}
