using SIGO.GestaoNormas.Domain.Entities;
using System;

namespace SIGO.GestaoNormas.Domain.DTOs
{
    public class RepositorioDTO
    {
        public string URL { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public Repositorio ToRepositorio()
        {
            return new Repositorio()
            {
                GUID = Guid.NewGuid(),
                URL = URL,
                Nome = Nome,
                Descricao = Descricao
            };
        }
    }
}
