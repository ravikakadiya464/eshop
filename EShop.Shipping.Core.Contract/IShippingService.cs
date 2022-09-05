using EShop.Core.Domain.RequestModel;

namespace EShop.Shipping.Core.Contract;

public interface IShippingService
{
    Task ShipOrder(ShippingRequest request);
}

