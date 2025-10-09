using ECommerceApi.Domain.Entities;
using System.Collections.Generic;

namespace ECommerceApi.Application.Interfaces
{
    public interface IProductPriceService
    {
        Task<IEnumerable<ProductPrice>> GetAllPrices();
        Task<ProductPrice> GetPriceById(int id);
        Task AddPrice(ProductPrice price);
        void UpdatePrice(ProductPrice price);
        Task DeletePrice(int id);
    }
}
