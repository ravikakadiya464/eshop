namespace EShop.Infra.Contract;
 
public interface IProductRepository
{
    public Task<IList<Domain.Entity.Product>> GetProducts(string? searchTerm, int pageNumber, int pageSize);

    public Task<Domain.Entity.Product> GetProduct(int id);
}
