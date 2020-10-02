using SIGO.GestaoNormas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.GestaoNormas.Domain.Interfaces.Repository
{
    public interface IRepositorioRepository
    {
        Task Salvar(Repositorio repositorio);
        void Atualizar(Repositorio repositorio);
        Task Excluir(string guid);
        Task<Repositorio> ObterRepositorio(string guid);
        Task<List<Repositorio>> ObterRepositorios();
    }
}