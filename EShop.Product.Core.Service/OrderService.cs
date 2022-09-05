using AutoMapper;
using EShop.Common.Extensions;
using EShop.Core.Domain.RequestModel;
using EShop.Infra.Contract;
using EShop.Product.Core.Contract;
using EShop.Product.Core.Domain.RequestModel;
using EShop.Product.Core.Domain.ResponseModel;
using EShop.Product.Core.Service.Builder;
using EShop.Product.Core.Service.EventBus;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace EShop.Product.Core.Service
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly  ServiceBusHelper _serviceBusHelper;

        public OrderService(IRepositoryManager repositoryManager, IMapper mapper, IHttpContextAccessor contextAccessor, ServiceBusHelper serviceBusHelper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _serviceBusHelper = serviceBusHelper;
        }

        public async Task<OrderResponse> AddOrder(OrderRequest request)
        {
            try
            {
                var userId = _contextAccessor.GetUserId();

                var product = await _repositoryManager.Product.GetProduct(request.ProductId);

                if (product == null) throw new Exception("Invalid Product");

                var order = OrderBuilder.Build(request, product.Price, userId);

                await _repositoryManager.ExecuteAsync(async () =>
                {
                    await _repositoryManager.Order.AddOrder(order);
                    await _repositoryManager.SaveAsync();
                });

                var partitionKey = $"{userId}:{order.Id}";

                // Store the event before send to queue
                var payload = new ShippingRequest()
                {
                    OrderId = order.Id
                };

                await _serviceBusHelper.SendTopicMessageAsync(ServiceBusConstant.ShippingTopic,
                    JsonConvert.SerializeObject(payload), partitionKey, userId.ToString());

                order = await _repositoryManager.Order.GetOrder(order.Id);

                var response = _mapper.Map<OrderResponse>(order);
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}