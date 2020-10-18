using Microsoft.Extensions.Logging;
using SIGO.Bus.EventBus.Abstractions;
using SIGO.Bus.EventBus.Events;
using System;
using System.Threading.Tasks;

namespace SIGO.Simuladores.ESB.Mule.IntegrationEvents
{
    public class ESBMuleIntegrationEventService : IESBMuleIntegrationEventService
    {
        private readonly IEventBus _eventBus;
        private readonly ILogger<ESBMuleIntegrationEventService> _logger;

        public ESBMuleIntegrationEventService(ILogger<ESBMuleIntegrationEventService> logger, IEventBus eventBus)
        {
            _eventBus = eventBus;
            _logger = logger;
        }

        public async Task PublicarEvento(IntegrationEvent evt)
        {
            try
            {
                _logger.LogInformation("----- Publicando evento de integração: {IntegrationEventId_published} from {AppName} - ({@IntegrationEvent})", evt.Id, Program.AppName, evt);

                _eventBus.Publish(evt);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERRO ao publicar evento: {IntegrationEventId} from {AppName} - ({@IntegrationEvent})", evt.Id, Program.AppName, evt);
            }
        }
    }
}