using ECommerceApi.Domain.Entities;
using ECommerceApi.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApi.Application.Services
{
    public class OrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

  
        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(od => od.OrderDetails)
                .Include(od => od.User)
                .ToListAsync();
        }


        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders.Include(od=> od.OrderDetails)
                .ThenInclude(og => og.Product)
                .Include(od => od.User)
                .FirstOrDefaultAsync(od => od.OrderId == id);
        }

    
        public async Task<Order> AddAsync(Order detail)
        {
            _context.Orders.Add(detail);
            await _context.SaveChangesAsync();
            return detail;
        }

        public async Task<bool> UpdateAsync(Order detail)
        {
            var existing = await _context.Orders.FindAsync(detail.OrderId);
            if (existing == null)
                return false;

            existing.OrderDate = detail.OrderDate;
            existing.User = detail.User;
            existing.TotalAmount = detail.TotalAmount;
            existing.UserId = detail.UserId;
            existing.OrderDetails = detail.OrderDetails;

            await _context.SaveChangesAsync();
            return true;
        }

    
        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.OrderDetails.FindAsync(id);
            if (existing == null)
                return false;

            _context.OrderDetails.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
