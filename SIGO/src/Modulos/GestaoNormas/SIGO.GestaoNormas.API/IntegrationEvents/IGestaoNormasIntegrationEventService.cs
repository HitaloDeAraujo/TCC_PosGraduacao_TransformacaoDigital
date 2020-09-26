using SIGO.Bus.EventBus.Events;
using System.Threading.Tasks;

namespace SIGO.GestaoNormas.API.IntegrationEvents
{
    public interface IGestaoNormasIntegrationEventService
    {
        Task SaveEventAndCatalogContextChangesAsync(IntegrationEvent evt);
        Task PublishThroughEventBusAsync(IntegrationEvent evt);
    }
}