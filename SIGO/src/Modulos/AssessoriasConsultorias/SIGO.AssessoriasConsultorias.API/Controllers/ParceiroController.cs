using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGO.AssessoriasConsultorias.Domain.Interfaces.Service;
using SIGO.Domain;
using System.Threading.Tasks;

namespace SIGO.AssessoriasConsultorias.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = Autorizacao.Grupo.ADMINISTRADOR)]
    public class ParceiroController : ControllerBase
    {
        private readonly IParceiroService _parceiroService;

        public ParceiroController(IParceiroService parceiroService)
        {
            _parceiroService = parceiroService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var parceiros = await _parceiroService.ObterParceiros();

            return Ok(parceiros);
        }
    }
}