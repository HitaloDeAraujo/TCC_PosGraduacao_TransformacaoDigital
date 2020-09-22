using SIGO.Domain.Entidades;
using System;

namespace SIGO.AssessoriasConsultorias.Domain.Entidades
{
    public class Contrato : EntidadeBase
    {
        public Guid GUID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string URL { get; set; }
    }
}