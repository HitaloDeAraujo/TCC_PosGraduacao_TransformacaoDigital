using System;

namespace SIGO.Infra
{
    public interface IDapperDbConnection : IDisposable
    {
        void OpenConnection();
    }
}
