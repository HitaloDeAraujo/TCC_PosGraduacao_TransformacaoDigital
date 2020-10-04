using SIGO.Domain.Entities;
using System;

namespace SIGO.GestaoProcessoIndustrial.Domain.Entities
{
    public class Usuario : EntidadeBase
    {
        public Guid GUID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Grupos { get; set; } = string.Empty;

        public void AdicionarGrupo(string grupo)
        {
            Grupos = Grupos.Length > 0 ? Grupos + ", " + grupo : grupo;
        }
    }
}