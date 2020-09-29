using SIGO.GestaoNormas.Domain.Entities;
using SIGO.GestaoNormas.Domain.Interfaces;
using SIGO.GestaoNormas.Domain.Interfaces.Service;
using System.Collections.Generic;
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
            var normas = new Norma();

            try
            {
                normas = await _unitOfWork.Normas.ObterNorma(guid);
            }
            catch
            {
                throw;
            }

            return normas;
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
    }
}
