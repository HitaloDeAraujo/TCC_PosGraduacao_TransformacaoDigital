using SIGO.Domain.Entities;
using System;

namespace SIGO.AssessoriasConsultorias.Domain.Entities
{
    public class Parceiro : EntidadeBase
    {
        public Guid GUID { get; set; }
        public short Tipo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
