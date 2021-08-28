using DTI.Data;
using DTI.Data.Repositories;
using DTI.Domain.Common.Contracts.Persistance;
using DTI.Domain.Product;
using DTI.Domain.Product.Commands.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTI.Api._Config
{
    public static class IoCConfig
    {
        public static IServiceCollection AppAddIoCServices(this IServiceCollection services, IConfiguration config, IHostEnvironment env)
        {



            services.AddScoped<DbContext, DataContext>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
        public static IConfiguration ConfigureEnvVariables<T>(this IConfiguration config,
                            IServiceCollection services)
                            where T : class
        {
            var instance = (T)Activator.CreateInstance(typeof(T));
            if (instance == null) return config;
            config.Bind(instance?.GetType().Name, instance);
            services.AddSingleton(instance);
            return config;
        }
    }
}
