using AutoMapper;
using EShop.Infra.Domain.Entity;
using EShop.Product.Core.Domain.ResponseModel;

namespace EShop.Product.Core.Service.AutoMapperProfile;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<EShop.Infra.Domain.Entity.Product, ProductResponse>()
            .ForMember(x => x.ProductBrandName, opt => opt.MapFrom(x => x.ProductBrand.Name))
            .ForMember(x => x.ProductTypeName, opt => opt.MapFrom(x => x.ProductType.Name));

        CreateMap<Order, OrderResponse>();
    }
}
