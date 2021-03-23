using System;

namespace MuslimFashion.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IMenuRepository Menu { get; }
        int SaveChanges();
    }
}