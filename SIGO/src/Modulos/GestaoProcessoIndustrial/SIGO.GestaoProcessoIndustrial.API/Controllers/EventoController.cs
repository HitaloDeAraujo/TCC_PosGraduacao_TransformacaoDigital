using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGO.Domain;
using SIGO.GestaoProcessoIndustrial.Domain.Interfaces.Service;
using System.Threading.Tasks;

namespace SIGO.GestaoProcessoIndustrial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize (Roles = Autorizacao.Grupo.ADMINISTRADOR)]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventoController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var eventos = await _eventoService.ObterEventos();

            return Ok(eventos);
        }

        [HttpGet]
        [Route("guid")]
        public async Task<IActionResult> Get(string guid)
        {
            var evento = await _eventoService.ObterEvento(guid);

            return Ok(evento);
        }

        [HttpGet]
        [Route("TipoEvento/MaisRecente/{tipoEvento}")]
        public async Task<IActionResult> Get_EventoMaisRecente(int tipoEvento)
        {
            var evento = await _eventoService.ObterEventoMaisRecente(tipoEvento);

            return Ok(evento);
        }
    }
}