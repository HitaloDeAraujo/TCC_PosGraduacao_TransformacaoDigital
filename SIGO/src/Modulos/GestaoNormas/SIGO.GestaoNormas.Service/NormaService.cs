﻿using SIGO.GestaoNormas.Domain.Entities;
using SIGO.GestaoNormas.Domain.Interfaces;
using SIGO.GestaoNormas.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.GestaoNormas.Service
{
    public class NormaService : INormaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NormaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Norma> Salvar(Norma norma)
        {
            try
            {
                await _unitOfWork.Normas.Salvar(norma);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }

            return norma;
        }

        public async Task Atualizar(Norma norma)
        {
            try
            {
                _unitOfWork.Normas.Atualizar(norma);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task Excluir(string guid)
        {
            try
            {
                await _unitOfWork.Normas.Excluir(guid);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Norma> ObterNorma(string guid)
        {
            var norma = new Norma();

            try
            {
                norma = await _unitOfWork.Normas.ObterNorma(guid);
            }
            catch
            {
                throw;
            }

            return norma;
        }

        public async Task<List<Norma>> ObterNormas()
        {
            try
            {
                return await _unitOfWork.Normas.ObterNormas();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Norma>> ObterNormasExternas(Repositorio repositorio)
        {
            var ultimaNorma = (await ObterNormas()).OrderBy(x => x.ID).LastOrDefault();
            int id = ultimaNorma != null ? ultimaNorma.ID + 1 : 1;

            List<Norma> normas = new List<Norma>();

            Random random = new Random();

            int quantNormas = random.Next(10, 20);

            for (int i = 0; i < quantNormas; i++)
            {
                Norma norma = new Norma()
                {
                    ID = id++,
                    DataCriacao = DateTime.Now,
                    GUID = Guid.NewGuid(),
                    URL = "https://github.com/HitaloDeAraujo/pag_teste_tcc_pos/blob/master/pag%20(" + random.Next(1, 61) + ").pdf",
                    Titulo = string.Concat("Norma numero", id),
                    Descricao = string.Concat("Norma numero", id, " do repositório ", repositorio.Nome),
                    RepositorioID = repositorio.ID
                };

                await Salvar(norma);

                normas.Add(norma);
            }

            return normas;
        }
    }
}
