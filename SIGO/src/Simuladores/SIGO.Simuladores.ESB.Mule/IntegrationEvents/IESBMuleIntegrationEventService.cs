using SIGO.Bus.EventBus.Events;
using System.Threading.Tasks;

namespace SIGO.Simuladores.ESB.Mule.IntegrationEvents
{
    public interface IESBMuleIntegrationEventService
    {
        Task PublicarEventoEventBusAsync(IntegrationEvent evt);
    }
}