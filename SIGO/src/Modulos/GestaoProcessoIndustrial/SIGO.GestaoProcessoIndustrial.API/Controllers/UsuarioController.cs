using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGO.GestaoProcessoIndustrial.Domain.Entities;
using SIGO.GestaoProcessoIndustrial.Domain.Interfaces.Service;
using System.Security.Claims;
using System.Threading.Tasks;
using static SIGO.Utils.Seguranca;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace SIGO.GestaoProcessoIndustrial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
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
        public async Task<IActionResult> Post(string matricula, string senha)
        {
            var result = await _usuarioService.Autenticar(matricula, senha);

            BuildToken(new Usuario()
            {
                Matricula = matricula
            });

            return Ok(result);
        }

        private UsuarioToken BuildToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Matricula),
                new Claim("meuValor", "oque voce quiser"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
            var expiracao = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiracao,
               signingCredentials: creds);

            return new UsuarioToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiracao = expiracao
            };
        }
    }
}