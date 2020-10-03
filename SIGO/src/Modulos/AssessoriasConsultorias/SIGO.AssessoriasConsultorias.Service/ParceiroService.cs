using SIGO.AssessoriasConsultorias.Domain.Entities;
using SIGO.AssessoriasConsultorias.Domain.Interfaces;
using SIGO.AssessoriasConsultorias.Domain.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.AssessoriasConsultorias.Service
{
    public class ParceiroService : IParceiroService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ParceiroService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Parceiro> Salvar(Parceiro parceiro)
        {
            try
            {
                await _unitOfWork.Parceiros.Salvar(parceiro);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }

            return parceiro;
        }

        public async Task Atualizar(Parceiro parceiro)
        {
            try
            {
                _unitOfWork.Parceiros.Atualizar(parceiro);
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
                await _unitOfWork.Parceiros.Excluir(guid);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Parceiro> ObterParceiro(string guid)
        {
            var parceiro = new Parceiro();

            try
            {
                parceiro = await _unitOfWork.Parceiros.ObterParceiro(guid);
            }
            catch
            {
                throw;
            }

            return parceiro;
        }

        public async Task<List<Parceiro>> ObterParceiros()
        {
            try
            {
                return await _unitOfWork.Parceiros.ObterParceiros();
            }
            catch
            {
                throw;
            }
        }
    }
}
