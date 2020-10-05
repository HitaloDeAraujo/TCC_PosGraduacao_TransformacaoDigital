namespace SIGO.Bus.EventBus.Events.SIGO
{
    public class RelacaoOrcamentoVendasIntegrationEvent : IntegrationEvent
    {
        public int Orcamentos { get; set; }
        public int Vendas { get; set; }
    }
}