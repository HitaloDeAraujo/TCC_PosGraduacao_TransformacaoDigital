using Microsoft.IdentityModel.Tokens;
using SIGO.Domain;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SIGO.Simuladores.AD
{
    public static class TokenService
    {
        public static string GerarToken(UsuarioAD usuarioAD)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuarioAD.Email.ToString()),
                    new Claim(ClaimTypes.Role, usuarioAD.Grupos.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Autorizacao.Chave), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);

            return jwtSecurityTokenHandler.WriteToken(token);
        }
    }
}