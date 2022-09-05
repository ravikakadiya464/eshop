using AutoMapper;
using EShop.Infra.Contract;
using EShop.Product.Core.Contract;
using EShop.Product.Core.Domain;
using EShop.Product.Core.Service.EventBus;
using Microsoft.AspNetCore.Http;

namespace EShop.Product.Core.Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IOrderService> _orderService;

        public ServiceManager(IHttpContextAccessor contextAccessor, IRepositoryManager repositoryManager, IMapper mapper, ServiceBusHelper serviceBusHelper)
        {
            _productService = new Lazy<IProductService>(() => new ProductService(repositoryManager, mapper));
            _orderService = new Lazy<IOrderService>(() => new OrderService(repositoryManager, mapper, contextAccessor, serviceBusHelper));
        }

        public IProductService Product => _productService.Value;

        public IOrderService Order => _orderService.Value;
    }
}