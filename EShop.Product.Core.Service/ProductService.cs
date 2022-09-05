using AutoMapper;
using EShop.Infra.Contract;
using EShop.Product.Core.Contract;
using EShop.Product.Core.Domain.ResponseModel;

namespace EShop.Product.Core.Service
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<IList<ProductResponse>> GetProducts(string? searchTerm, int pageNumber, int pageSize)
        {
            try
            {
                var products = await _repositoryManager.Product.GetProducts(searchTerm, pageNumber, pageSize);

                var response = _mapper.Map<List<ProductResponse>>(products);

                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}