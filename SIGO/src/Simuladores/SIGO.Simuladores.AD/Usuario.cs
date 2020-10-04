using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SIGO.Simuladores.AD
{
    public class UsuarioAD
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Role { get; set; } = "Principal";

        public bool AutenticarComAD(string email, string senha)
        {
            return true;
        }

        public bool VerificarEmail(string email)
        {
            return true;
        }
    }

    public static class TokenService
    {
        public static string GenerateToken(UsuarioAD usuarioAD, string key)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuarioAD.Email.ToString()),
                    new Claim(ClaimTypes.Role, usuarioAD.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
