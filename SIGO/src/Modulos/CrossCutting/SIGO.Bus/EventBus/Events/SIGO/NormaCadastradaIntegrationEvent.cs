namespace SIGO.Bus.EventBus.Events.SIGO
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
