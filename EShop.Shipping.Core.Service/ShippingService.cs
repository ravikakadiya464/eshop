using EShop.Common.Enums;
using EShop.Core.Domain.RequestModel;
using EShop.Infra.Contract;
using EShop.Shipping.Core.Contract;

namespace EShop.Shipping.Core.Service
{
    public class ShippingService : IShippingService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ShippingService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }


        public async Task ShipOrder(ShippingRequest request)
        {
            try
            {
                var order = await _repositoryManager.Order.GetOrder(request.OrderId);
                order.UpdateStatus(OrderStatus.Shipped);

                if (order == null) throw new Exception("Invalid Order");

                await _repositoryManager.ExecuteAsync(async () =>
                {
                    _repositoryManager.Order.UpdateOrder(order);
                    await _repositoryManager.SaveAsync();
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}