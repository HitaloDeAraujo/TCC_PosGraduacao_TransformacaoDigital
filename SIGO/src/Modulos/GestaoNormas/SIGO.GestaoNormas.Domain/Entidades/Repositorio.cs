using SIGO.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace SIGO.GestaoNormas.Domain.Entidades
{
    public class Repositorio : EntidadeBase
    {
        public Guid GUID { get; set; }
        public string URL { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<Norma> Normas { get; set; }
    }
}
