using EShop.Infra.Contract;
using EShop.Infra.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EShop.Infra.Repository;

public class ProductRepository : RepositoryBase<EShop.Infra.Domain.Entity.Product>, IProductRepository
{
    public ProductRepository(EshopContext eshopContext) : base(eshopContext)
    {
    }

    public async Task<IList<EShop.Infra.Domain.Entity.Product>> GetProducts(string? searchTerm, int pageNumber, int pageSize)
    {
        var products = FindAll(false)
            .Include(x => x.ProductBrand)
            .Include(x => x.ProductType)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

        if (string.IsNullOrEmpty(searchTerm))
        {
            products = products.Where(x => EF.Functions.Like(x.Name, $"%{searchTerm}%") ||
                                        EF.Functions.Like(x.Description, $"%{searchTerm}%"));
        }

        return await products.ToListAsync();
    }

    public async Task<EShop.Infra.Domain.Entity.Product> GetProduct(int id)
    {
        var product = await FindByCondition(x => x.Id == id, false)
            .FirstOrDefaultAsync();

        return product;
    }
}