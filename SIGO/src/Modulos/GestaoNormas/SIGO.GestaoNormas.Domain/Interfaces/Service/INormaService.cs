using SIGO.GestaoNormas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.GestaoNormas.Domain.Interfaces.Service
{
    public interface INormaService
    {
        Task<Norma> Salvar(Norma norma);
        Task Atualizar(Norma norma);
        Task Excluir(string guid);
        Task<Norma> ObterNorma(string guid);
        Task<List<Norma>> ObterNormas();
        Task<List<Norma>> ObterNormasExternas(Repositorio repositorio);
    }
}
