using SIGO.Domain.Entidades;
using System;

namespace SIGO.GestaoNormas.Domain.Entidades
{
    public class Norma : EntidadeBase
    {
        public Guid GUID { get; set; }
        public string URL { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
    }
}
