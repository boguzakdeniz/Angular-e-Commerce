using API.Core.DbModels;
using API.Core.Interfaces;
using API.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Implements
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _storeContext;
        public GenericRepository(StoreContext storeContext)
        {
            this._storeContext = storeContext;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync() => await _storeContext.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _storeContext.Set<T>().FindAsync(id);
    }
}
