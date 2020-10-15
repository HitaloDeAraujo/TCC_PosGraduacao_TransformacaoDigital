using Microsoft.Extensions.Logging;
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
    public class NormaCadastradaIntegrationEventHandler : IIntegrationEventHandler<NormaCadastradaIntegrationEvent>
    {
        private readonly ILogger<NormaCadastradaIntegrationEventHandler> _logger;
        private readonly IEventoService _eventoService;

        public NormaCadastradaIntegrationEventHandler(IEventoService eventoService, ILogger<NormaCadastradaIntegrationEventHandler> logger)
        {
            _eventoService = eventoService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Handle(NormaCadastradaIntegrationEvent @event)
        {
            using (LogContext.PushProperty(LogContextUtils.IntegrationEventContext, $"{@event.Id}-{Program.AppName}"))
            {
                _logger.LogInformation("----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})", @event.Id, Program.AppName, @event);

                await _eventoService.Salvar(new Evento()
                {
                    GUID = Guid.NewGuid(),
                    Nome = "Norma cadastrada",
                    Descricao = string.Concat("Norma: ", @event.Id, " - Nome: ", @event.Nome),
                    Grau = 2,
                    TipoEventoID = 3
                });
            }
        }
    }
}
