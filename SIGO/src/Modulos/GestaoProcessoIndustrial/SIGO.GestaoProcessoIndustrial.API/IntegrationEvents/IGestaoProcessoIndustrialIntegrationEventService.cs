using SIGO.Bus.EventBus.Events;
using System.Threading.Tasks;

namespace SIGO.GestaoProcessoIndustrial.API.IntegrationEvents
{
    public interface IGestaoProcessoIndustrialIntegrationEventService
    {
        Task SaveEventAndCatalogContextChangesAsync(IntegrationEvent evt);
        Task PublishThroughEventBusAsync(IntegrationEvent evt);
    }
}
