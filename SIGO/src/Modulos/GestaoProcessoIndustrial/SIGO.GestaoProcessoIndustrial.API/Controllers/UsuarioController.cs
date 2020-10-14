using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SIGO.GestaoProcessoIndustrial.Domain.DTOs;
using SIGO.GestaoProcessoIndustrial.Domain.Interfaces.Service;
using SIGO.Simuladores.AD;
using System.Threading.Tasks;

namespace SIGO.GestaoProcessoIndustrial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public IConfiguration _configuration { get; }

        public UsuarioController(IUsuarioService usuarioService, IConfiguration configuration)
        {
            _usuarioService = usuarioService;
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] LoginDTO loginDTO)
        {
            var result = await _usuarioService.Autenticar(loginDTO.Email, loginDTO.Senha);

            if (result != null)
            {
                var token = TokenService.GerarToken(new UsuarioAD(){ 
                    Email = result.Email,
                    Nome = result.Nome,
                    Grupos = result.Grupos
                });

                TokenDTO tokenDTO = new TokenDTO()
                {
                    NomeUsuario = result.Nome,
                    Token = token
                };

                return Ok(tokenDTO);
            }

            return Unauthorized();
        }
    }
}