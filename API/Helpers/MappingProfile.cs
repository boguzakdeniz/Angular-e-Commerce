using API.Core.DbModels;
using API.Core.Dtos;
using AutoMapper;

namespace API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductToReturnDto>().
                ForMember(x => x.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name)).
                ForMember(x => x.ProductType, o => o.MapFrom(s => s.ProductType.Name)).
                ForMember(x => x.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}
