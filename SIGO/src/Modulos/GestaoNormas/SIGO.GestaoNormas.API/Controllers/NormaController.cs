using Microsoft.AspNetCore.Mvc;
using SIGO.GestaoNormas.API.IntegrationEvents;
using SIGO.GestaoNormas.API.IntegrationEvents.Events;
using SIGO.GestaoNormas.Domain.Entities;
using System.Threading.Tasks;

namespace SIGO.GestaoNormas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NormaController : ControllerBase
    {
        public NormaController(IGestaoNormasIntegrationEventService gestaoNormasIntegrationEventService)
        {
            gestaoNormasIntegrationEventService.PublishThroughEventBusAsync(new ProductPriceChangedIntegrationEvent(1, 2, 3));
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Get()
        {
            Norma norma = null;
            norma = new Norma()
            {
                Descricao = "Teste"
            };

            receive();

            return Ok(norma);
        }

        private static void receive()
        {
        }
    }
}