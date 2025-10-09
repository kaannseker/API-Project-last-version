using ECommerceApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerceApi.Application.Interfaces
{
    public interface IShoppingService
    {
        Task<Basket> GetBasketAsync(int userId);
        Task AddToBasketAsync(int userId, int productId, int quantity);
        Task RemoveFromBasketAsync(int userId, int productId);
        Task<Order> CheckoutAsync(int userId);
        Task<Order> CreateOrderAsync(int userId);
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<Order>> GetUserOrdersAsync(int userId);
    }
}
