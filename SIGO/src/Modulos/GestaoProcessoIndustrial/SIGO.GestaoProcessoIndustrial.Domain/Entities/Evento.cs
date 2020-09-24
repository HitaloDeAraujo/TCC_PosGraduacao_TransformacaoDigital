using SIGO.Domain.Entities;
using System;

namespace SIGO.GestaoProcessoIndustrial.Domain.Entities
{
    public class Evento : EntidadeBase
    {
        public Guid GUID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Grau { get; set; }
        public int TipoEventoID { get; set; }
        public TipoEvento TipoEvento { get; set; }
    }
}