using SIGO.GestaoNormas.Domain.Entities;
using System;

namespace SIGO.GestaoNormas.Domain.DTOs
{
    public class NormaDTO
    {
        public string URL { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int RepositorioID { get; set; }

        public Norma ToNorma()
        {
            return new Norma()
            {
                GUID = Guid.NewGuid(),
                URL = URL,
                Titulo = Titulo,
                Descricao = Descricao,
                RepositorioID = RepositorioID
            };
        }
    }
}
