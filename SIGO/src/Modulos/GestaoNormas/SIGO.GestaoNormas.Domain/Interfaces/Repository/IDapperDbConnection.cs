using System;

namespace SIGO.GestaoNormas.Domain.Interfaces.Repository
{
    public interface IDapperDbConnection : IDisposable
    {
        void OpenConnection();
    }
}
