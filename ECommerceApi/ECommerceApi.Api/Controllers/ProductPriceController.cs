using ECommerceApi.Application.Interfaces;
using ECommerceApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ECommerceApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductPriceController : ControllerBase
    {
        private readonly IProductPriceService _productPriceService;

        public ProductPriceController(IProductPriceService productPriceService)
        {
            _productPriceService = productPriceService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductPrice>> GetAll()
        {
            var prices = _productPriceService.GetAllPrices();
            return Ok(prices);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductPrice> GetById(int id)
        {
            var price = _productPriceService.GetPriceById(id);
            if (price == null)
                return NotFound();

            return Ok(price);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProductPrice price)
        {
            _productPriceService.AddPrice(price);
            return Ok("Fiyat baþarýyla eklendi.");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductPrice price)
        {
            if (id != price.ProductPriceId) 
                return BadRequest("ID uyuþmuyor.");

            _productPriceService.UpdatePrice(price);
            return Ok("Fiyat güncellendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productPriceService.DeletePrice(id);
            return Ok("Fiyat silindi.");
        }
    }
}
