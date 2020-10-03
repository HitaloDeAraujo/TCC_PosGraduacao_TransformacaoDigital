using SIGO.AssessoriasConsultorias.Domain.Enums;
using SIGO.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SIGO.AssessoriasConsultorias.Domain.Entities
{
    public class Parceiro : EntidadeBase
    {
        public Guid GUID { get; set; }
        public TipoParceiro Tipo { get; set; } = TipoParceiro.Outro;
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<Contrato> Contratos { get; set; }
    }
}
