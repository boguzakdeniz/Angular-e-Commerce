using API.Core.DbModels;
using System.Diagnostics.CodeAnalysis;

namespace API.Core.Interfaces
{
    public interface IProductRepository
    {
        /// <summary>
        /// Gönderilen id numarasına göre ürünü getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Product> GetProductByIdAsync(int id);

        /// <summary>
        /// All products list.
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<Product>> GetProductsAsync();

    }
}
