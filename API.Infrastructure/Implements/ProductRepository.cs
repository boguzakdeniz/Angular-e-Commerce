using API.Core.DbModels;
using API.Core.Interfaces;
using API.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Implements
{

    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _storeContext;
        public ProductRepository(StoreContext storeContext)
        {
            this._storeContext = storeContext;
        }
        public async Task<Product> GetProductByIdAsync(int id) => await _storeContext.Products.FindAsync(id);

        public async Task<IReadOnlyList<Product>> GetProductsAsync() => await _storeContext.Products.ToListAsync();
      
    }
}
