using SIGO.GestaoNormas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SIGO.GestaoNormas.Domain.Interfaces.Service
{
    public interface IRepositorioService
    {
        Task<Repositorio> Salvar(Repositorio repositorio);
        Task Atualizar(Repositorio repositorio);
        Task Excluir(string guid);
        Task<Repositorio> ObterRepositorio(string guid);
        Task<List<Repositorio>> ObterRepositorios();
    }
}