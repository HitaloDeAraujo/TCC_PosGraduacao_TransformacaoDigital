using System;

namespace SIGO.Utils
{
    public static class Seguranca
    {
        public static string Encriptar(string senha)
        {
            return senha;
        }

        public static string Decriptar(string senha)
        {
            return senha;
        }

        public class UsuarioToken
        {
            public string Token { get; set; }
            public DateTime Expiracao { get; set; }
        }
    }
}
