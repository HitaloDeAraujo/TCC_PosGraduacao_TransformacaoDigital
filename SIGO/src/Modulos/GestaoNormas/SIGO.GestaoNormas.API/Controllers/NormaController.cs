using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGO.Domain;
using SIGO.GestaoNormas.API.IntegrationEvents;
using SIGO.GestaoNormas.Domain.Interfaces.Service;
using System.Threading.Tasks;

namespace SIGO.GestaoNormas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = Autorizacao.Grupo.ADMINISTRADOR)]
    public class NormaController : ControllerBase
    {
        private readonly INormaService _normaService;

        public NormaController(IGestaoNormasIntegrationEventService gestaoNormasIntegrationEventService,
            INormaService normaService)
        {
            _normaService = normaService;

            //gestaoNormasIntegrationEventService.PublishThroughEventBusAsync(new NormaCadastradaIntegrationEvent(1, "Norma 1"));
            //gestaoNormasIntegrationEventService.PublishThroughEventBusAsync(new NormaCadastradaIntegrationEvent(2, "Norma 2"));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var normas = await _normaService.ObterNormas();

            return Ok(normas);
        }

        [HttpGet]
        [Route("{guid}")]
        public async Task<IActionResult> Get(string guid)
        {
            var norma = await _normaService.ObterNorma(guid);

            return Ok(norma);
        }
    }
}