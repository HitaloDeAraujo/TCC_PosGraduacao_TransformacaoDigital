﻿using SIGO.GestaoProcessoIndustrial.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.GestaoProcessoIndustrial.Domain.Interfaces.Service
{
    public interface IEventoService
    {
        Task<Evento> Salvar(Evento evento);
        Task Atualizar(Evento evento);
        Task Excluir(string guid);
        Task<Evento> ObterEvento(string guid);
        Task<List<Evento>> ObterEventos();
    }
}
