using Microsoft.Extensions.Logging;
using Serilog.Context;
using SIGO.Bus.EventBus.Abstractions;
using SIGO.GestaoNormas.API.IntegrationEvents.Events;
using SIGO.GestaoNormas.Infra.Context;
using System.Threading.Tasks;

namespace SIGO.GestaoNormas.API.IntegrationEvents.EventHandling
{
    public class OrderStatusChangedToPaidIntegrationEventHandler :
         IIntegrationEventHandler<ProductPriceChangedIntegrationEvent>
    {
        private readonly GestaoNormasDbContext _gestaoNormasDbContext;
        private readonly ILogger<OrderStatusChangedToPaidIntegrationEventHandler> _logger;

        public OrderStatusChangedToPaidIntegrationEventHandler(
            GestaoNormasDbContext gestaoNormasDbContext,
            ILogger<OrderStatusChangedToPaidIntegrationEventHandler> logger)
        {
            _gestaoNormasDbContext = gestaoNormasDbContext;
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }

        public async Task Handle(ProductPriceChangedIntegrationEvent @event)
        {
            using (LogContext.PushProperty("IntegrationEventContext", $"{@event.Id}-{Program.AppName}"))
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