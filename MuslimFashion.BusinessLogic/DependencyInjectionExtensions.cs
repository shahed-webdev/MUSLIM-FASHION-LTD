using Microsoft.Extensions.DependencyInjection;

namespace MuslimFashion.BusinessLogic
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            // services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}