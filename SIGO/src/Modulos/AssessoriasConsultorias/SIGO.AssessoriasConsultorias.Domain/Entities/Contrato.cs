using SIGO.Domain.Entities;
using System;

namespace SIGO.AssessoriasConsultorias.Domain.Entities
{
    public class Contrato : EntidadeBase
    {
        public Guid GUID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string URL { get; set; }
        public int ParceiroID { get; set; }
        public Parceiro Parceiro { get; set; }
    }
}