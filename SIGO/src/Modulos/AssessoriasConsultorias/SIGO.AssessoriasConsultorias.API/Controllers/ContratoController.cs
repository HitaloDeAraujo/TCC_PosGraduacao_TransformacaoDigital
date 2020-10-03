using Microsoft.AspNetCore.Mvc;
using SIGO.AssessoriasConsultorias.Domain.Interfaces.Service;
using System.Threading.Tasks;

namespace SIGO.AssessoriasConsultorias.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ContratoController : ControllerBase
    {
        private readonly IContratoService _contratoService;

        public ContratoController(IContratoService contratoService)
        {
            _contratoService = contratoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var contratos = await _contratoService.ObterContratos();

            return Ok(contratos);
        }
    }
}