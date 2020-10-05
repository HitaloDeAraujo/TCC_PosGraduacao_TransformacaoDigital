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
        private volatile bool disposedValue;

        public ESBMuleIntegrationEventService(ILogger<ESBMuleIntegrationEventService> logger, IEventBus eventBus)
        {
            _eventBus = eventBus;
            _logger = logger;
        }

        public async Task PublicarEvento(IntegrationEvent evt)
        {
            try
            {
                _logger.LogInformation("----- Publishing integration event: {IntegrationEventId_published} from {AppName} - ({@IntegrationEvent})", evt.Id, Program.AppName, evt);

                // await _eventLogService.MarkEventAsInProgressAsync(evt.Id);
                _eventBus.Publish(evt);
                // await _eventLogService.MarkEventAsPublishedAsync(evt.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR Publishing integration event: {IntegrationEventId} from {AppName} - ({@IntegrationEvent})", evt.Id, Program.AppName, evt);
                //await _eventLogService.MarkEventAsFailedAsync(evt.Id);
            }
        }
    }
}