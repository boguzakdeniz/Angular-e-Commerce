using API.Core.DbModels;
using API.Core.Interfaces;
using API.Core.Specifications;
using API.Infrastructure.Data;
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

        public async Task<T> GetEntityWithSpecification(ISpecification<T> specification) => await ApplySpecification(specification).FirstOrDefaultAsync();

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification) => await ApplySpecification(specification).ToListAsync();

        private IQueryable<T> ApplySpecification(ISpecification<T> specification) => SpecificationEvaluator<T>.GetQuery(_storeContext.Set<T>(), specification);
    }
}
