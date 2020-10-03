using SIGO.AssessoriasConsultorias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SIGO.AssessoriasConsultorias.Domain.Interfaces.Repository
{
    public interface IParceiroRepository
    {
        Task Salvar(Parceiro parceiro);
        void Atualizar(Parceiro parceiro);
        Task Excluir(string guid);
        Task<Parceiro> ObterParceiro(string guid);
        Task<List<Parceiro>> ObterParceiros();
    }
}