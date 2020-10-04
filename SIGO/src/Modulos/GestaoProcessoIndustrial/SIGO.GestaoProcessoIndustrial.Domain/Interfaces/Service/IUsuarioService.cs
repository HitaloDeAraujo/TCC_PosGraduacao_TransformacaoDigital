using SIGO.GestaoProcessoIndustrial.Domain.DTOs;
using SIGO.GestaoProcessoIndustrial.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.GestaoProcessoIndustrial.Domain.Interfaces.Service
{
    public interface IUsuarioService
    {
        Task<Usuario> Salvar(Usuario usuario);
        Task Atualizar(Usuario usuario);
        Task Excluir(string guid);
        Task<Usuario> ObterUsuario(string guid);
        Task<List<Usuario>> ObterUsuarios();
        Task<UsuarioDTO> Autenticar(string email, string senha);
    }
}
