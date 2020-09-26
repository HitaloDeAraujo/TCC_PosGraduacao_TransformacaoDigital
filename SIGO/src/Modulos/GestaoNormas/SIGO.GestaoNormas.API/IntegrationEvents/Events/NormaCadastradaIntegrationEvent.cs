using SIGO.Bus.EventBus.Events;

namespace SIGO.GestaoNormas.API.IntegrationEvents.Events
{
    public class NormaCadastradaIntegrationEvent : IntegrationEvent
    {
        public int Id { get; private set; }

        public string Nome { get; private set; }

        public NormaCadastradaIntegrationEvent(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
