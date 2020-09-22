using SIGO.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGO.GestaoProcessoIndustrial.Domain.Entidades
{
    public class Evento : EntidadeBase
    {
        public Guid GUID { get; set; }
        public int Tipo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Grau { get; set; }
    }
}