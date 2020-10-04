using SIGO.GestaoProcessoIndustrial.Domain.DTOs;
using SIGO.GestaoProcessoIndustrial.Domain.Entities;
using SIGO.GestaoProcessoIndustrial.Domain.Interfaces;
using SIGO.GestaoProcessoIndustrial.Domain.Interfaces.Service;
using SIGO.Simuladores.AD;
using SIGO.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.GestaoProcessoIndustrial.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Usuario> Salvar(Usuario usuario)
        {
            try
            {
                await _unitOfWork.Usuarios.Salvar(usuario);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }

            return usuario;
        }

        public async Task Atualizar(Usuario usuario)
        {
            try
            {
                _unitOfWork.Usuarios.Atualizar(usuario);
                await _unitOfWork.CommitAsync();
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
                await _unitOfWork.Usuarios.Excluir(guid);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Usuario> ObterUsuario(string guid)
        {
            var usuario = new Usuario();

            try
            {
                usuario = await _unitOfWork.Usuarios.ObterUsuario(guid);
            }
            catch
            {
                throw;
            }

            return usuario;
        }

        public async Task<List<Usuario>> ObterUsuarios()
        {
            try
            {
                return await _unitOfWork.Usuarios.ObterUsuarios();
            }
            catch
            {
                throw;
            }
        }

        public async Task<UsuarioDTO> Autenticar(string email, string senha)
        {
            var usuario = await _unitOfWork.Usuarios.ObterUsuarioPorEmail(email);

            UsuarioDTO usuarioDTO = null;

            if (usuario != null)
            {
                UsuarioAD usuarioAD = new UsuarioAD()
                {
                    Email = email,
                    Senha = Seguranca.Encriptar(senha),
                    Nome = usuario.Nome,
                    Grupos = usuario.Grupos
                };

                if (usuarioAD.AutenticarComAD())
                {
                    usuarioDTO = new UsuarioDTO()
                    {
                        Email = email,
                        Nome = usuario.Nome,
                        Grupos = usuario.Grupos
                    };
                }
            }

            return usuarioDTO;
        }
    }
}
