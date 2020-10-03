using SIGO.GestaoProcessoIndustrial.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.GestaoProcessoIndustrial.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        Task Salvar(Usuario usuario);
        void Atualizar(Usuario usuario);
        Task Excluir(string guid);
        Task<Usuario> ObterUsuario(string guid);
        Task<Usuario> ObterUsuarioPorMatricula(string matricula);
        Task<List<Usuario>> ObterUsuarios();
    }
}
