using SIGO.GestaoNormas.Domain.Interfaces.Repository;
using System;
using System.Threading.Tasks;

namespace SIGO.GestaoNormas.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    { 
        int Commit();
        Task<int> CommitAsync();

        INormaRepository Normas { get; }
    }
}