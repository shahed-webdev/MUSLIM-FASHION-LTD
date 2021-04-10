using Microsoft.Extensions.DependencyInjection;
using MuslimFashion.BusinessLogic.Menu;
using MuslimFashion.BusinessLogic.Registration;
using MuslimFashion.Repository;
using MuslimFashion.ViewModel;

namespace MuslimFashion.BusinessLogic
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IBasicSettingCore, BasicSettingCore>();
            services.AddTransient<ICustomerCore, CustomerCore>();
            services.AddTransient<IHomeMenuCore, HomeMenuCore>();
            services.AddTransient<IMenuCore, MenuCore>();
            services.AddTransient<IOrderCore, OrderCore>();
            services.AddTransient<ISubMenuCore, SubMenuCore>();
            services.AddTransient<IRegistrationCore, RegistrationCore>();
            services.AddTransient<ISizeCore, SizeCore>();
            services.AddTransient<IProductCore, ProductCore>();
            services.AddTransient<ISliderCore, SliderCore>();
            return services;
        }
    }
}