using SIGO.GestaoNormas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.GestaoNormas.Domain.Interfaces.Repository
{
    public interface INormaRepository
    {
        Task Salvar(Norma norma);
        void Atualizar(Norma norma);
        Task Excluir(string guid);
        Task<Norma> ObterNorma(string guid);
        Task<List<Norma>> ObterNormas();
    }
}
