using EShop.Product.Core.Domain.RequestModel;
using EShop.Product.Core.Domain.ResponseModel;

namespace EShop.Product.Core.Contract;

public interface IOrderService
{
    Task<OrderResponse> AddOrder(OrderRequest request);
}

