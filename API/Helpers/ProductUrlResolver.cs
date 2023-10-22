using API.Core.DbModels;
using API.Core.Dtos;
using AutoMapper;

namespace API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _configuration;
        public ProductUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            return string.IsNullOrEmpty(source.PictureUrl) ? null : _configuration["ApiUrl"] + source.PictureUrl;
        }
    }
}
