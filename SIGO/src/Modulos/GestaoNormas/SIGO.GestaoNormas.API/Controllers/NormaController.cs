using Microsoft.AspNetCore.Mvc;
using SIGO.GestaoNormas.Domain.Entities;
using System.Threading.Tasks;

namespace SIGO.GestaoNormas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NormaController : ControllerBase
    {
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Get()
        {
            Norma norma = null;
            norma = new Norma()
            {
                Descricao = "Teste"
            };

            return Ok(norma);
        }
    }
}