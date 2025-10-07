using ECommerceApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductHierarchyController : ControllerBase
    {
        private readonly IProductHierarchyService _hierarchyService;

        public ProductHierarchyController(IProductHierarchyService hierarchyService)
        {
            _hierarchyService = hierarchyService;
        }

        [HttpGet("{id}")]
        public IActionResult GetHierarchy(int id)
        {
            var name = _hierarchyService.GetHierarchyName(id);
            return Ok(name);
        }
    }
}
