using EShop.Infra.Contract;
using EShop.Infra.Domain;
using EShop.Infra.Repository;
using EShop.Product.Core.Contract;
using EShop.Product.Core.Service;
using EShop.Product.Core.Service.AutoMapperProfile;
using EShop.Product.Core.Service.EventBus;
using Microsoft.EntityFrameworkCore;

namespace EShop.Product.Configuration
{
    public static class DependancyConfiguration
    {
        public static void ConfigureDependancy(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddTransient(typeof(ServiceBusHelper));

            services.AddDbContext<EshopContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("productSqlConnection"),
                    sqlBuilder => sqlBuilder.MigrationsAssembly("EShop.Product"))
            );

            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IServiceManager, ServiceManager>();
        }
    }
}
