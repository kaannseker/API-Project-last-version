using ECommerceApi.Domain.Entities;
using ECommerceApi.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApi.Application.Services
{
    public class OrderDetailService
    {
        private readonly AppDbContext _context;

        public OrderDetailService(AppDbContext context)
        {
            _context = context;
        }

  
        public async Task<List<OrderDetail>> GetAllAsync()
        {
            return await _context.OrderDetails
                .Include(od => od.Product)
                .Include(od => od.Order)
                .ToListAsync();
        }


        public async Task<OrderDetail?> GetByIdAsync(int id)
        {
            return await _context.OrderDetails
                .Include(od => od.Product)
                .Include(od => od.Order)
                .FirstOrDefaultAsync(od => od.OrderDetailId == id);
        }

    
        public async Task<OrderDetail> AddAsync(OrderDetail detail)
        {
            _context.OrderDetails.Add(detail);
            await _context.SaveChangesAsync();
            return detail;
        }

        public async Task<bool> UpdateAsync(OrderDetail detail)
        {
            var existing = await _context.OrderDetails.FindAsync(detail.OrderDetailId);
            if (existing == null)
                return false;

            existing.ProductId = detail.ProductId;
            existing.Quantity = detail.Quantity;
            existing.UnitPrice = detail.UnitPrice;
            existing.OrderId = detail.OrderId;

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
