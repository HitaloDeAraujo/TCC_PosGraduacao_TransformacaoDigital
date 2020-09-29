using SIGO.Bus.EventBus.Events;
using System.Threading.Tasks;

namespace SIGO.AssessoriasConsultorias.API.IntegrationEvents
{
    public interface IAssessoriasConsultoriasIntegrationEventService
    {
        Task SaveEventAndCatalogContextChangesAsync(IntegrationEvent evt);
        Task PublishThroughEventBusAsync(IntegrationEvent evt);
    }
}
