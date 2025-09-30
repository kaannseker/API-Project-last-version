using ECommerceApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Description = "Güçlü bir dizüstü bilgisayar", Price = 15000, Stock = 50 },
            new Product { Id = 2, Name = "Mouse", Description = "Kablosuz oyuncu mouse'u", Price = 250, Stock = 100 },
            new Product { Id = 3, Name = "Keyboard", Description = "Mekanik klavye", Price = 750, Stock = 75 }
        };

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_products);
        }
    }
}