namespace EShop.Shipping.Core.Contract;

public interface IServiceManager
{
    /// <summary>
    /// IOrderService
    /// </summary>
    IShippingService Order { get; }
}
