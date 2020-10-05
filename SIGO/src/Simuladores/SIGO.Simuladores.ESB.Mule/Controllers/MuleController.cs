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
        [Route("PublicarEvento/EstoqueMinimo")]
        public async Task<IActionResult> PublicarEvento([FromBody] EstoqueMinimoIntegrationEvent estoqueMinimoIntegrationEvent)
        {
            await _esbMuleIntegrationEventService.PublicarEvento(estoqueMinimoIntegrationEvent);

            return Ok();
        }

        [HttpPost]
        [Route("PublicarEvento/MaterialInconsistente")]
        public async Task<IActionResult> PublicarEvento([FromBody] MaterialInconsistenteIntegrationEvent materialInconsistenteIntegrationEvent)
        {
            await _esbMuleIntegrationEventService.PublicarEvento(materialInconsistenteIntegrationEvent);

            return Ok();
        }

        [HttpPost]
        [Route("PublicarEvento/RelacaoOrcamentoVendas")]
        public async Task<IActionResult> PublicarEvento([FromBody] RelacaoOrcamentoVendasIntegrationEvent relacaoOrcamentoVendasIntegrationEvent)
        {
            await _esbMuleIntegrationEventService.PublicarEvento(relacaoOrcamentoVendasIntegrationEvent);

            return Ok();
        }

        [HttpPost]
        [Route("PublicarEvento/InteligenciaNegocio")]
        public async Task<IActionResult> PublicarEvento([FromBody] IndicativoInteligenciaNegocioIntegrationEvent indicativoInteligenciaNegocioIntegrationEvent)
        {
            await _esbMuleIntegrationEventService.PublicarEvento(indicativoInteligenciaNegocioIntegrationEvent);

            return Ok();
        }
    }
}
