﻿using Microsoft.Extensions.Logging;
using SIGO.Bus.EventBus.Abstractions;
using SIGO.Bus.EventBus.Events;
using SIGO.Bus.IntegrationEventLogEF.Services;
using SIGO.Bus.IntegrationEventLogEF.Utilities;
using SIGO.AssessoriasConsultorias.Infra.Context;
using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace SIGO.AssessoriasConsultorias.API.IntegrationEvents
{
    public class AssessoriasConsultoriasIntegrationEventService : IAssessoriasConsultoriasIntegrationEventService
    {
        private readonly Func<DbConnection, IIntegrationEventLogService> _integrationEventLogServiceFactory;
        private readonly IEventBus _eventBus;
        private readonly AssessoriasConsultoriasDbContext _assessoriasConsultoriasDbContext;
        private readonly IIntegrationEventLogService _eventLogService;
        private readonly ILogger<AssessoriasConsultoriasIntegrationEventService> _logger;
        private volatile bool disposedValue;

        public AssessoriasConsultoriasIntegrationEventService(
            ILogger<AssessoriasConsultoriasIntegrationEventService> logger,
            IEventBus eventBus,
            AssessoriasConsultoriasDbContext assessoriasConsultoriasDbContext
            /*,Func<DbConnection, IIntegrationEventLogService> integrationEventLogServiceFactory*/)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _assessoriasConsultoriasDbContext = assessoriasConsultoriasDbContext ?? throw new ArgumentNullException(nameof(assessoriasConsultoriasDbContext));
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

            await ResilientTransaction.New(_assessoriasConsultoriasDbContext).ExecuteAsync(async () =>
            {
                await _assessoriasConsultoriasDbContext.SaveChangesAsync();
                await _eventLogService.SaveEventAsync(evt, _assessoriasConsultoriasDbContext.Database.CurrentTransaction);
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
