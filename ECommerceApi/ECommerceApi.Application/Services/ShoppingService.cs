using ECommerceApi.Application.Interfaces;
using ECommerceApi.Domain.Entities;
using ECommerceApi.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerceApi.Application.Services
{
    public class ShoppingService : IShoppingService
    {
        private readonly AppDbContext _context;

        public ShoppingService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Basket> GetBasketAsync(int userId)
        {
            return await _context.Baskets
                .Include(b => b.Items)
                .FirstOrDefaultAsync(b => b.UserId == userId);
        }

        public async Task AddToBasketAsync(int userId, int productId, int quantity)
        {
            var basket = await _context.Baskets
                .Include(b => b.Items)
                .FirstOrDefaultAsync(b => b.UserId == userId);

            if (basket == null)
            {
                basket = new Basket { UserId = userId };
                _context.Baskets.Add(basket);
            }

            var item = basket.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item == null)
            {
                basket.Items.Add(new BasketItem
                {
                    ProductId = productId,
                    Quantity = quantity
                });
            }
            else
            {
                item.Quantity += quantity;
            }

            await _context.SaveChangesAsync();
        }

        public async Task RemoveFromBasketAsync(int userId, int productId)
        {
            var basket = await _context.Baskets
                .Include(b => b.Items)
                .FirstOrDefaultAsync(b => b.UserId == userId);

            if (basket == null)
                throw new Exception("Sepet bulunamadı.");

            var item = basket.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item == null)
                throw new Exception("Ürün sepette bulunamadı.");

            basket.Items.Remove(item);
            await _context.SaveChangesAsync();
        }


        public async Task<Order> CheckoutAsync(int userId)
        {
            return await CreateOrderAsync(userId);
        }

        public async Task<Order> CreateOrderAsync(int userId)
        {
            var basket = await _context.Baskets
                .Include(b => b.Items)
                .FirstOrDefaultAsync(b => b.UserId == userId);

            if (basket == null || !basket.Items.Any())
                throw new Exception("Sepet boş.");

            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                OrderDetails = basket.Items.Select(i => new OrderDetail
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity
                }).ToList()
            };

            _context.Orders.Add(order);
            _context.Baskets.Remove(basket);

            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task<IEnumerable<Order>> GetUserOrdersAsync(int userId)
        {
            return await _context.Orders
                .Include(o => o.OrderDetails)
                .Where(o => o.UserId == userId)
                .ToListAsync();
        }
    }
}
