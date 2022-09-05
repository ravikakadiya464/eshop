using AutoMapper;
using EShop.Infra.Contract;
using EShop.Shipping.Core.Contract;
using Microsoft.AspNetCore.Http;

namespace EShop.Shipping.Core.Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IShippingService> _orderService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _orderService = new Lazy<IShippingService>(() => new ShippingService(repositoryManager));
        }

        public IShippingService Order => _orderService.Value;
    }
}