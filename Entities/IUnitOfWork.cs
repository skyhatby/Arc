using System;

namespace Entities
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        void Rollback();
    }
}
