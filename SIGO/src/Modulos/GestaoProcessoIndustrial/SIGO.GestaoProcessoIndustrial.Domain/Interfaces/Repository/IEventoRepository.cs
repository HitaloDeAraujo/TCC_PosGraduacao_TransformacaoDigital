using SIGO.GestaoProcessoIndustrial.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.GestaoProcessoIndustrial.Domain.Interfaces.Repository
{
    public interface IEventoRepository
    {
        Task Salvar(Evento evento);
        void Atualizar(Evento evento);
        Task Excluir(string guid);
        Task<Evento> ObterEvento(string guid);
        Task<List<Evento>> ObterEventos();
    }
}
