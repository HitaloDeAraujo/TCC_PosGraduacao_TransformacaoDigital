using System;

namespace SIGO.Bus.EventBus.Events.SIGO
{
    public class IndicativoInteligenciaNegocioIntegrationEvent : IntegrationEvent
    {
        public int PrevisaoVendas { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}