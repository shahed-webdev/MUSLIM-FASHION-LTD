using System;

namespace MuslimFashion.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
    }
}