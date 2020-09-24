using Microsoft.AspNetCore.Mvc;
using SIGO.AssessoriasConsultorias.Domain.Entities;
using System.Threading.Tasks;

namespace SIGO.AssessoriasConsultorias.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Get()
        {
            Contrato contrato = new Contrato()
            {
                Nome = "Cont",
                Parceiro = new Parceiro()
                {
                    Nome = "JP Morgan"
                }
            };

            return Ok(contrato);
        }
    }
}