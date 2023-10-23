using API.Core.Interfaces;
using API.Helpers;
using API.Infrastructure.DataContext;
using API.Infrastructure.Implements;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, WebApplicationBuilder builder)
        {

            //AddController
            services.AddControllers();

            //Dependency Injection
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();

            //AutoMapper
            services.AddAutoMapper(typeof(MappingProfile));

            //AddDbContext
            services.AddDbContext<StoreContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
