using System;

namespace SIGO.Domain.Entities
{
    public class EntidadeBase
    {
        public int ID { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataExclusao { get; set; }
    }
}