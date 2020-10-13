using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGO.Domain;
using SIGO.GestaoNormas.API.IntegrationEvents;
using SIGO.GestaoNormas.Domain.DTOs;
using SIGO.GestaoNormas.Domain.Interfaces.Service;
using System.Threading.Tasks;

namespace SIGO.GestaoNormas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = Autorizacao.Grupo.ADMINISTRADOR)]
    [AllowAnonymous]
    public class NormaController : ControllerBase
    {
        private readonly INormaService _normaService;

        public NormaController(INormaService normaService)
        {
            _normaService = normaService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] NormaDTO normaDTO)
        {
            try
            {
                var norma = await _normaService.Salvar(normaDTO.ToNorma());

                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
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