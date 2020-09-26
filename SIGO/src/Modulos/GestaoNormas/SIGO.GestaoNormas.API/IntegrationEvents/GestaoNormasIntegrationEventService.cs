using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SIGO.Bus.EventBus.Abstractions;
using SIGO.Bus.EventBus.Events;
using SIGO.Bus.IntegrationEventLogEF.Services;
using SIGO.Bus.IntegrationEventLogEF.Utilities;
using SIGO.GestaoNormas.Infra.Context;
using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace SIGO.GestaoNormas.API.IntegrationEvents
{
    public class GestaoNormasIntegrationEventService : IGestaoNormasIntegrationEventService, IDisposable
    {
        private readonly Func<DbConnection, IIntegrationEventLogService> _integrationEventLogServiceFactory;
        private readonly IEventBus _eventBus;
        private readonly GestaoNormasDbContext _gestaoNormasDbContext;
        private readonly IIntegrationEventLogService _eventLogService;
        private readonly ILogger<GestaoNormasIntegrationEventService> _logger;
        private volatile bool disposedValue;

        public GestaoNormasIntegrationEventService(
            ILogger<GestaoNormasIntegrationEventService> logger,
            IEventBus eventBus,
            GestaoNormasDbContext gestaoNormasDbContext
            /*,Func<DbConnection, IIntegrationEventLogService> integrationEventLogServiceFactory*/)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _gestaoNormasDbContext = gestaoNormasDbContext ?? throw new ArgumentNullException(nameof(gestaoNormasDbContext));
          //  _integrationEventLogServiceFactory = integrationEventLogServiceFactory ?? throw new ArgumentNullException(nameof(integrationEventLogServiceFactory));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            //_eventLogService = _integrationEventLogServiceFactory(_gestaoNormasDbContext.Database.GetDbConnection());
        }

        public async Task PublishThroughEventBusAsync(IntegrationEvent evt)
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
                await _eventLogService.MarkEventAsFailedAsync(evt.Id);
            }
        }

        public async Task SaveEventAndCatalogContextChangesAsync(IntegrationEvent evt)
        {
            _logger.LogInformation("----- CatalogIntegrationEventService - Saving changes and integrationEvent: {IntegrationEventId}", evt.Id);

            //Use of an EF Core resiliency strategy when using multiple DbContexts within an explicit BeginTransaction():
            //See: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency            
            await ResilientTransaction.New(_gestaoNormasDbContext).ExecuteAsync(async () =>
            {
                // Achieving atomicity between original catalog database operation and the IntegrationEventLog thanks to a local transaction
                await _gestaoNormasDbContext.SaveChangesAsync();
                await _eventLogService.SaveEventAsync(evt, _gestaoNormasDbContext.Database.CurrentTransaction);
            });
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                    (_eventLogService as IDisposable)?.Dispose();

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
