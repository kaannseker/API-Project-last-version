using ECommerceApi.Domain.Entities;
using ECommerceApi.Infrastructure.Repositories.GenericRepository;

namespace ECommerceApi.Application.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetActiveProductsAsync();
        Task<Product?> GetProductWithDetailsAsync(int id);
        Task<bool> IsProductInStockAsync(int productId, int quantity);
    }
}
