using ECommerceApi.Application.Services;
using ECommerceApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailController : ControllerBase
    {
        private readonly OrderDetailService _service;

        public OrderDetailController(OrderDetailService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var detail = await _service.GetByIdAsync(id);
            if (detail == null) return NotFound();
            return Ok(detail);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderDetail detail)
        {
            var created = await _service.AddAsync(detail);
            return CreatedAtAction(nameof(Get), new { id = created.OrderDetailId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrderDetail detail)
        {
            if (id != detail.OrderDetailId) return BadRequest();
            var success = await _service.UpdateAsync(detail);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
