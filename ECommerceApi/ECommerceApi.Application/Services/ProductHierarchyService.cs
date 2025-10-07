using ECommerceApi.Application.Interfaces;

namespace ECommerceApi.Application.Services
{
    public class ProductHierarchyService : IProductHierarchyService
    {
        public string GetHierarchyName(int id)
        {
            return $"Hierarchy_{id}";
        }
    }
}
