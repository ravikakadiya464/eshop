namespace EShop.Infra.Contract;

public interface IRepositoryManager
{
    /// <summary>
    /// Save Database Changes
    /// </summary>
    /// <returns></returns>
    Task<int> SaveAsync();

    /// <summary>
    /// ExecuteAsync
    /// </summary>
    /// <param name="action">Func<Task></param>
    /// <returns></returns>
    Task ExecuteAsync(Func<Task> action);

    /// <summary>
    /// IClaimRepository
    /// </summary>
    IProductRepository Product { get; }

    IOrderRepository Order { get; }
}