using SIGO.Domain.Entidades;
using System;

namespace SIGO.GestaoProcessoIndustrial.Domain.Entidades
{
    public class Usuario : EntidadeBase
    {
        public Guid GUID { get; set; }
        public string Nome { get; set; }
    }
}
