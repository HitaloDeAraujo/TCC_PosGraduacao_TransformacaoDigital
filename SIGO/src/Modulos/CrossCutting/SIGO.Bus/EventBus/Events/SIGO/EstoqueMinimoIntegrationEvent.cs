namespace SIGO.Bus.EventBus.Events.SIGO
{
    public class EstoqueMinimoIntegrationEvent : IntegrationEvent
    {
        public int ProdutoID { get; set; }
        public int Quantidade { get; set; }
        public int EstoqueMinimo { get; set; }
    }
}