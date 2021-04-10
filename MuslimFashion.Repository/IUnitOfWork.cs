using System;

namespace MuslimFashion.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IBasicSettingRepository BasicSetting { get; }
        ICustomerRepository Customer { get; }
        IHomeMenuRepository HomeMenu { get; }
        IMenuRepository Menu { get; }
        IOrderRepository Order { get; }
        IProductRepository product { get; }
        IRegistrationRepository Registration { get; }
        ISubMenuRepository SubMenu { get; }
        ISizeRepository Size { get; }
        ISliderRepository Slider { get; }
        int SaveChanges();
    }
}