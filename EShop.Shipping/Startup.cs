using EShop.Infra.Contract;
using EShop.Infra.Domain;
using EShop.Infra.Repository;
using EShop.Shipping;
using EShop.Shipping.Core.Contract;
using EShop.Shipping.Core.Service;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]

namespace EShop.Shipping
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContext<EshopContext>((option) =>
                option.UseSqlServer(builder.GetContext().Configuration["productSqlConnection"]));

            builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
            builder.Services.AddScoped<IServiceManager, ServiceManager>();
        }
    }
}