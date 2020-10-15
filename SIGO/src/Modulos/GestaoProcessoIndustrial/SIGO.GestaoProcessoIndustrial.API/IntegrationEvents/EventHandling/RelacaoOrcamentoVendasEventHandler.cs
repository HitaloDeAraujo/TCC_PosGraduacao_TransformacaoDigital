using Microsoft.Extensions.Logging;
using Serilog.Context;
using SIGO.Bus.EventBus.Abstractions;
using SIGO.Bus.EventBus.Events.SIGO;
using SIGO.GestaoProcessoIndustrial.Domain.DTOs;
using SIGO.GestaoProcessoIndustrial.Domain.Entities;
using SIGO.GestaoProcessoIndustrial.Domain.Interfaces.Service;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using static SIGO.Utils.Configuration;

namespace SIGO.GestaoProcessoIndustrial.API.IntegrationEvents.EventHandling
{
    public class RelacaoOrcamentoVendasEventHandler : IIntegrationEventHandler<RelacaoOrcamentoVendasIntegrationEvent>
    {
        private readonly ILogger<RelacaoOrcamentoVendasEventHandler> _logger;
        private readonly IEventoService _eventoService;

        public RelacaoOrcamentoVendasEventHandler(IEventoService eventoService, ILogger<RelacaoOrcamentoVendasEventHandler> logger)
        {
            _eventoService = eventoService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Handle(RelacaoOrcamentoVendasIntegrationEvent @event)
        {
            using (LogContext.PushProperty(LogContextUtils.IntegrationEventContext, $"{@event.Id}-{Program.AppName}"))
            {
                _logger.LogInformation("----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})", @event.Id, Program.AppName, @event);

                OrcamentosVendasDTO orcamentosVendasDTO = new OrcamentosVendasDTO()
                {
                    Orcamentos = @event.Orcamentos,
                    Vendas = @event.Vendas
                };

                await _eventoService.Salvar(new Evento()
                {
                    GUID = Guid.NewGuid(),
                    Nome = "Relação Orçamentos Vendas",
                    Descricao = JsonSerializer.Serialize(orcamentosVendasDTO),
                    Grau = 2,
                    TipoEventoID = 4
                });
            }
        }
    }
}
