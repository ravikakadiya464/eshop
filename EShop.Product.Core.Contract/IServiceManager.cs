namespace EShop.Product.Core.Contract;

public interface IServiceManager
{
    /// <summary>
    /// IProductService
    /// </summary>
    IProductService Product { get; }

    /// <summary>
    /// IOrderService
    /// </summary>
    IOrderService Order { get; }
}
