using System.Text;

namespace SIGO.Domain
{
    public static class Autorizacao
    {
        public static byte[] Chave = Encoding.ASCII.GetBytes("aljhdlfakjdbvçaskjvb_kajb-nkjabkds");

        public class Grupo
        {
            public const string ADMINISTRADOR = nameof(ADMINISTRADOR);
            public static string DIRETOR = nameof(DIRETOR);
            public static string GERENTE = nameof(GERENTE);
        }
    }
}
