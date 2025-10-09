using ECommerceApi.Domain.Entities;
using ECommerceApi.Infrastructure.Repositories.GenericRepository;

namespace ECommerceApi.Application.Services
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<Order>> GetUserOrdersAsync(int userId);
        Task<Order?> GetOrderWithDetailsAsync(int orderId);
    }
}
