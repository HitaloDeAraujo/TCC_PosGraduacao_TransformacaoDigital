using SIGO.AssessoriasConsultorias.Domain.Entities;
using SIGO.AssessoriasConsultorias.Domain.Interfaces;
using SIGO.AssessoriasConsultorias.Domain.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.AssessoriasConsultorias.Service
{
    public class ContratoService : IContratoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContratoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Contrato> Salvar(Contrato contrato)
        {
            try
            {
                await _unitOfWork.Contratos.Salvar(contrato);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }

            return contrato;
        }

        public async Task Atualizar(Contrato contrato)
        {
            try
            {
                _unitOfWork.Contratos.Atualizar(contrato);
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
                await _unitOfWork.Contratos.Excluir(guid);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Contrato> ObterContrato(string guid)
        {
            var contrato = new Contrato();

            try
            {
                contrato = await _unitOfWork.Contratos.ObterContrato(guid);
            }
            catch
            {
                throw;
            }

            return contrato;
        }

        public async Task<List<Contrato>> ObterContratos()
        {
            try
            {
                return await _unitOfWork.Contratos.ObterContratos();
            }
            catch
            {
                throw;
            }
        }
    }
}
