using Microsoft.AspNetCore.Mvc;
using SIGO.GestaoProcessoIndustrial.Domain.Entidades;
using System.Threading.Tasks;

namespace SIGO.GestaoProcessoIndustrial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Get()
        {
            Evento evento = new Evento()
            {
                Nome = "Nome"
            };

            return Ok(evento);
        }
    }
}