using Microsoft.AspNetCore.Mvc;
using SIGO.Bus.EventBus.Events.SIGO;
using SIGO.Simuladores.ESB.Mule.IntegrationEvents;
using System.Threading.Tasks;

namespace SIGO.Simuladores.ESB.Mule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuleController : ControllerBase
    {
        private readonly IESBMuleIntegrationEventService _esbMuleIntegrationEventService;
        public MuleController(IESBMuleIntegrationEventService esbMuleIntegrationEventService)
        {
            _esbMuleIntegrationEventService = esbMuleIntegrationEventService;
        }

        [HttpPost]
        [Route("EstoqueMinimo/PublicarEvento")]
        public async Task<IActionResult> PublicarEvento([FromBody] EstoqueMinimoIntegrationEvent estoqueMinimoIntegrationEvent)
        {
            await _esbMuleIntegrationEventService.PublicarEvento(estoqueMinimoIntegrationEvent);

            return Ok();
        }
    }
}
