using SIGO.AssessoriasConsultorias.Domain.Interfaces.Repository;
using System;
using System.Threading.Tasks;

namespace SIGO.AssessoriasConsultorias.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
        Task<int> CommitAsync();

        IContratoRepository Contratos { get; }
        IParceiroRepository Parceiros { get; }
    }
}