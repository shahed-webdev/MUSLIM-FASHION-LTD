﻿using Microsoft.Extensions.DependencyInjection;
using MuslimFashion.BusinessLogic.Menu;
using MuslimFashion.Repository;

namespace MuslimFashion.BusinessLogic
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IColorCore, ColorCore>();
            services.AddTransient<ICustomerCore, CustomerCore>();
            services.AddTransient<IMenuCore, MenuCore>();
            services.AddTransient<ISubMenuCore, SubMenuCore>();
            services.AddTransient<ISizeCore, SizeCore>();
            services.AddTransient<IProductCore, ProductCore>();
            return services;
        }
    }
}