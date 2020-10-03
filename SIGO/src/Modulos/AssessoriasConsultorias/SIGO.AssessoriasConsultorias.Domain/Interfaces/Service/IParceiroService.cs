using SIGO.AssessoriasConsultorias.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.AssessoriasConsultorias.Domain.Interfaces.Service
{
    public interface IParceiroService
    {
        Task<Parceiro> Salvar(Parceiro parceiro);
        Task Atualizar(Parceiro parceiro);
        Task Excluir(string guid);
        Task<Parceiro> ObterParceiro(string guid);
        Task<List<Parceiro>> ObterParceiros();
    }
}