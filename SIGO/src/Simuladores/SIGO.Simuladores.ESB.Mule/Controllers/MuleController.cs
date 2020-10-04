using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIGO.Bus.EventBus.Events.SIGO;
using SIGO.Simuladores.ESB.Mule.IntegrationEvents;

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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _esbMuleIntegrationEventService.PublicarEventoEventBusAsync(new EstoqueMinimoIntegrationEvent()
            {
                ProdutoID = 864,
                Quantidade = 100,
                EstoqueMinimo = 100
            });

            return Ok();
        }
    }
}
