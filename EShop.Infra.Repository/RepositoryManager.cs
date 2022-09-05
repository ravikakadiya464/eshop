using EShop.Infra.Contract;
using EShop.Infra.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EShop.Infra.Repository;

public class RepositoryManager : IRepositoryManager, IDisposable
{
    private readonly EshopContext _repositoryContext;
    private readonly Lazy<IProductRepository> _productRepository;
    private Lazy<IOrderRepository> _orderRepository;

    /// <summary>
    /// RepositoryManager constructor
    /// </summary>
    /// <param name="repositoryContext">RepositoryContext</param>
    public RepositoryManager(EshopContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(repositoryContext));
        _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(repositoryContext));
    }

    /// <summary>
    /// IProductRepository
    /// </summary>
    public IProductRepository Product => _productRepository.Value;

    /// <summary>
    /// IOrderRepository
    /// </summary>
    public IOrderRepository Order => _orderRepository.Value;

    public void Dispose()
    {
        _repositoryContext.Dispose();
    }

    /// <summary>
    /// SaveAsync
    /// </summary>
    /// <returns></returns>
    public Task<int> SaveAsync() => _repositoryContext.SaveChangesAsync();

    /// <summary>
    /// ExecuteAsync
    /// </summary>
    /// <param name="action">Func<Task></param>
    /// <returns></returns>
    public async Task ExecuteAsync(Func<Task> action)
    {
        try
        {
            if (_repositoryContext.Database.CurrentTransaction != null)
            {
                await action();
                return;
            }

            var strategy = _repositoryContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                await using IDbContextTransaction transaction = _repositoryContext.Database.BeginTransaction();
                try
                {
                    await action();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            });
        }
        catch (Exception)
        {
            _repositoryContext.ChangeTracker.Clear();
            throw;
        }
    }
}