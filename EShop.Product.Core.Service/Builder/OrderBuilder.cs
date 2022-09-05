using EShop.Infra.Domain.Entity;
using EShop.Product.Core.Domain.RequestModel;

namespace EShop.Product.Core.Service.Builder
{
    internal class OrderBuilder
    {
        public static Order Build(OrderRequest request, decimal productPrice, Guid userId)
        {
            return new Order(request.ProductId, userId, request.Quantity, request.Quantity * productPrice);
        }
    }
}
