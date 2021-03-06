﻿using Microsoft.Extensions.Logging;
using Serilog.Context;
using SIGO.Bus.EventBus.Abstractions;
using SIGO.Bus.EventBus.Events.SIGO;
using SIGO.GestaoProcessoIndustrial.Domain.Entities;
using SIGO.GestaoProcessoIndustrial.Domain.Interfaces.Service;
using System;
using System.Threading.Tasks;
using static SIGO.Utils.Configuration;

namespace SIGO.GestaoProcessoIndustrial.API.IntegrationEvents.EventHandling
{
    public class EstoqueMinimoIntegrationEventHandler : IIntegrationEventHandler<EstoqueMinimoIntegrationEvent>
    {
        private readonly ILogger<IIntegrationEventHandler> _logger;
        private readonly IEventoService _eventoService;

        public EstoqueMinimoIntegrationEventHandler(IEventoService eventoService, ILogger<IIntegrationEventHandler> logger)
        {
            _eventoService = eventoService;
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }

        public async Task Handle(EstoqueMinimoIntegrationEvent @event)
        {
            using (LogContext.PushProperty(LogContextUtils.IntegrationEventContext, $"{@event.Id}-{Program.AppName}"))
            {
                _logger.LogInformation("----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})", @event.Id, Program.AppName, @event);

                await _eventoService.Salvar(new Evento()
                {
                    GUID = Guid.NewGuid(),
                    Nome = "Estoque Minimo",
                    Descricao = string.Concat("Produto: ", @event.ProdutoID, " - Estoque Mínimo: ", @event.EstoqueMinimo, " - Quantidade: ", @event.Quantidade),
                    Grau = 2,
                    TipoEventoID = 3
                });
            }
        }
    }
}
