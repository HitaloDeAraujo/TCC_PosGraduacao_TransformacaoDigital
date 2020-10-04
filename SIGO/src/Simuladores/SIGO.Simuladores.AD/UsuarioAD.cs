namespace SIGO.Simuladores.AD
{
    public class UsuarioAD
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Grupos { get; set; }

        public bool AutenticarComAD()
        {
            return true;
        }
    }
}