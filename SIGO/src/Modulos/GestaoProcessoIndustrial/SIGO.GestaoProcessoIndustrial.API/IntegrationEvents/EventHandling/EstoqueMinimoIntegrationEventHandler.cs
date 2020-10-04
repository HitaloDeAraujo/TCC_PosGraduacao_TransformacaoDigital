using Microsoft.Extensions.Logging;
using Serilog.Context;
using SIGO.Bus.EventBus.Abstractions;
using SIGO.Bus.EventBus.Events.SIGO;
using SIGO.GestaoProcessoIndustrial.Infra.Context;
using System.Threading.Tasks;
using static SIGO.Utils.Configuration;

namespace SIGO.GestaoProcessoIndustrial.API.IntegrationEvents.EventHandling
{
    public class EstoqueMinimoIntegrationEventHandler : IIntegrationEventHandler<EstoqueMinimoIntegrationEvent>
    {
        private readonly GestaoProcessoIndustrialDbContext _gestaoProcessoIndustrialDbContext;
        private readonly ILogger<IIntegrationEventHandler> _logger;

        public EstoqueMinimoIntegrationEventHandler(
            GestaoProcessoIndustrialDbContext gestaoProcessoIndustrialDbContext, ILogger<IIntegrationEventHandler> logger)
        {
            _gestaoProcessoIndustrialDbContext = gestaoProcessoIndustrialDbContext;
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }

        public async Task Handle(EstoqueMinimoIntegrationEvent @event)
        {
            using (LogContext.PushProperty(LogContextUtils.IntegrationEventContext, $"{@event.Id}-{Program.AppName}"))
            {
                _logger.LogInformation("----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})", @event.Id, Program.AppName, @event);

                //salvar
            }
        }
    }
}
