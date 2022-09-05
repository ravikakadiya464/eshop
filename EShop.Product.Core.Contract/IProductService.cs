using EShop.Product.Core.Domain.ResponseModel;

namespace EShop.Product.Core.Contract;

public interface IProductService
{
    Task<IList<ProductResponse>> GetProducts(string? searchTerm, int pageNumber, int pageSize);
}

