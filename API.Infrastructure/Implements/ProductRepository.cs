using API.Core.DbModels;
using API.Core.Interfaces;
using API.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Implements
{

    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly StoreContext _storeContext;
        public ProductRepository(StoreContext storeContext)
        {
            this._storeContext = storeContext;
        }

        public async Task<Product> GetProductByIdAsync(int id) => await _storeContext.Products.Include(p => p.ProductBrand).Include(p => p.ProductType).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IReadOnlyList<Product>> GetProductsAsync() => await _storeContext.Products.Include(p => p.ProductBrand).Include(p => p.ProductType).ToListAsync();

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync() => await _storeContext.ProductTypes.ToListAsync();

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync() => await _storeContext.ProductBrands.ToListAsync();

    }
}
