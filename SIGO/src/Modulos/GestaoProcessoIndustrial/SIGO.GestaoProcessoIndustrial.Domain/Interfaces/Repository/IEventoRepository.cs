﻿using SIGO.GestaoProcessoIndustrial.Domain.Entities;
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
        Task<Evento> ObterEventoMaisRecente(int tipoEventoId);
        Task<List<Evento>> ObterEventos();
        Task<List<Evento>> ObterEventos(int tipoEventoId);
    }
}
