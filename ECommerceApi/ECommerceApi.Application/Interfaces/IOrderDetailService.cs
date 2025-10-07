using ECommerceApi.Domain.Entities;

namespace ECommerceApi.Application.Services
{
    public interface IOrderDetailService
    {
        Task<List<OrderDetail>> GetAllAsync();
        Task<OrderDetail?> GetByIdAsync(int id);
        Task<OrderDetail> AddAsync(OrderDetail detail);
        Task<bool> UpdateAsync(OrderDetail detail);
        Task<bool> DeleteAsync(int id);
    }
}
