using ECommerceApi.Application.Interfaces;
using ECommerceApi.Application.Services;
using ECommerceApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingController : ControllerBase
    {
        private readonly IShoppingService _shoppingService;

        public ShoppingController(IShoppingService shoppingService)
        {
            _shoppingService = shoppingService;
        }


        [HttpGet("basket/{userId}")]
        public async Task<IActionResult> GetBasket(int userId)
        {
            var basket = await _shoppingService.GetBasketAsync(userId);
            if (basket == null) return NotFound("Sepet bulunamadı.");
            return Ok(basket);
        }

        [HttpPost("basket/add")]
        public async Task<IActionResult> AddToBasket(int userId, int productId, int quantity)
        {
            await _shoppingService.AddToBasketAsync(userId, productId, quantity);
            return Ok("Ürün sepete eklendi.");
        }

        [HttpDelete("basket/remove")]
        public async Task<IActionResult> RemoveFromBasket(int userId, int productId)
        {
            await _shoppingService.RemoveFromBasketAsync(userId, productId);
            return Ok("Ürün sepetten silindi.");
        }


        [HttpPost("order/create")]
        public async Task<IActionResult> CreateOrder(int userId)
        {
            var order = await _shoppingService.CreateOrderAsync(userId);
            return Ok(order);
        }

        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            var order = await _shoppingService.GetOrderByIdAsync(orderId);
            if (order == null) return NotFound("Sipariş bulunamadı.");
            return Ok(order);
        }

        [HttpGet("orders/{userId}")]
        public async Task<IActionResult> GetUserOrders(int userId)
        {
            var orders = await _shoppingService.GetUserOrdersAsync(userId);
            return Ok(orders);
        }
    }
}
