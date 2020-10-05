using System.Security.Principal;

namespace SIGO.Bus.EventBus.Events.SIGO
{
    public class MaterialInconsistenteIntegrationEvent : IntegrationEvent
    {
        public int MaterialID { get; set; }
        public string Descricao { get; set; }
    }
}