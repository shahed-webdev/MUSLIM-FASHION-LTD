using Microsoft.Extensions.DependencyInjection;
using MuslimFashion.BusinessLogic.Menu;
using MuslimFashion.Repository;

namespace MuslimFashion.BusinessLogic
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IMenuCore, MenuCore>();
            services.AddTransient<ISubMenuCore, SubMenuCore>();
            return services;
        }
    }
}