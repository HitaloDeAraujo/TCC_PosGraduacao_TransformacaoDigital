using SIGO.GestaoProcessoIndustrial.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SIGO.GestaoProcessoIndustrial.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
        Task<int> CommitAsync();

        IEventoRepository Eventos { get; }
    }
}
