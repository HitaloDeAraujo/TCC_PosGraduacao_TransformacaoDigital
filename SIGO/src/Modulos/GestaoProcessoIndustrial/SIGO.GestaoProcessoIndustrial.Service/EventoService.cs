using SIGO.GestaoProcessoIndustrial.Domain.Entities;
using SIGO.GestaoProcessoIndustrial.Domain.Interfaces;
using SIGO.GestaoProcessoIndustrial.Domain.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.GestaoProcessoIndustrial.Service
{
    public class EventoService : IEventoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Evento> Salvar(Evento evento)
        {
            try
            {
                await _unitOfWork.Eventos.Salvar(evento);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }

            return evento;
        }

        public async Task Atualizar(Evento evento)
        {
            try
            {
                _unitOfWork.Eventos.Atualizar(evento);
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
                await _unitOfWork.Eventos.Excluir(guid);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Evento> ObterEvento(string guid)
        {
            var evento = new Evento();

            try
            {
                evento = await _unitOfWork.Eventos.ObterEvento(guid);
            }
            catch
            {
                throw;
            }

            return evento;
        }

        public async Task<Evento> ObterEventoMaisRecente(int tipoEventoId)
        {
            var evento = new Evento();

            try
            {
                evento = await _unitOfWork.Eventos.ObterEventoMaisRecente(tipoEventoId);
            }
            catch
            {
                throw;
            }

            return evento;
        }

        public async Task<List<Evento>> ObterEventos()
        {
            try
            {
                return await _unitOfWork.Eventos.ObterEventos();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Evento>> ObterEventos(int tipoEventoId)
        {
            try
            {
                return await _unitOfWork.Eventos.ObterEventos(tipoEventoId);
            }
            catch
            {
                throw;
            }
        }
    }
}
