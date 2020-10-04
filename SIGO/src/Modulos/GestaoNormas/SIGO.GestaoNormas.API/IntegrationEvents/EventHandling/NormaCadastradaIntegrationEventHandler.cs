using Microsoft.Extensions.Logging;
using Serilog.Context;
using SIGO.Bus.EventBus.Abstractions;
using SIGO.Bus.EventBus.Events.SIGO;
using SIGO.GestaoNormas.Infra.Context;
using System.Threading.Tasks;
using static SIGO.Utils.Configuration;

namespace SIGO.GestaoNormas.API.IntegrationEvents.EventHandling
{
    public class NormaCadastradaIntegrationEventHandler : IIntegrationEventHandler<NormaCadastradaIntegrationEvent>
    {
        private readonly GestaoNormasDbContext _gestaoNormasDbContext;
        private readonly ILogger<NormaCadastradaIntegrationEventHandler> _logger;

        public NormaCadastradaIntegrationEventHandler(
            GestaoNormasDbContext gestaoNormasDbContext, ILogger<NormaCadastradaIntegrationEventHandler> logger)
        {
            _gestaoNormasDbContext = gestaoNormasDbContext;
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }

        public async Task Handle(NormaCadastradaIntegrationEvent @event)
        {
            using (LogContext.PushProperty(LogContextUtils.IntegrationEventContext, $"{@event.Id}-{Program.AppName}"))
            {
                _logger.LogInformation("----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})", @event.Id, Program.AppName, @event);

                //foreach (var orderStockItem in @event.OrderStockItems)
                //{
                //    var catalogItem = _gestaoNormasDbContext.CatalogItems.Find(orderStockItem.ProductId);

                //    catalogItem.RemoveStock(orderStockItem.Units);
                //}

                //await _gestaoNormasDbContext.SaveChangesAsync();
            }
        }
    }
}