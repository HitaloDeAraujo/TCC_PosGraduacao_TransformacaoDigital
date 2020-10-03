using SIGO.AssessoriasConsultorias.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.AssessoriasConsultorias.Domain.Interfaces.Service
{
    public interface IContratoService
    {
        Task<Contrato> Salvar(Contrato contrato);
        Task Atualizar(Contrato contrato);
        Task Excluir(string guid);
        Task<Contrato> ObterContrato(string guid);
        Task<List<Contrato>> ObterContratos();
    }
}
