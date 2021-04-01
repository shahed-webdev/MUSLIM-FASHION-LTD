using System;

namespace MuslimFashion.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customer { get; }
        IHomeMenuRepository HomeMenu { get; }
        IMenuRepository Menu { get; }
        IProductRepository product { get; }
        IRegistrationRepository Registration { get; }
        ISubMenuRepository SubMenu { get; }
        ISizeRepository Size { get; }
        int SaveChanges();
    }
}