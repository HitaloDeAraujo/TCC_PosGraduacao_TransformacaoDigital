using SIGO.Domain.Entities;
using System;

namespace SIGO.GestaoNormas.Domain.Entities
{
    public class Norma : EntidadeBase
    {
        public Guid GUID { get; set; }
        public string URL { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int RepositorioID { get; set; }
    }
}
