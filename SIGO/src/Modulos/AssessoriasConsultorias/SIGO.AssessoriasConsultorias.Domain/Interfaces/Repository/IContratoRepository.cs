using SIGO.AssessoriasConsultorias.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.AssessoriasConsultorias.Domain.Interfaces.Repository
{
    public interface IContratoRepository
    {
        Task Salvar(Contrato contrato);
        void Atualizar(Contrato contrato);
        Task Excluir(string guid);
        Task<Contrato> ObterContrato(string guid);
        Task<List<Contrato>> ObterContratos();
    }
}