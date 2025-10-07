using ECommerceApi.Domain.Entities;
using System.Collections.Generic;

namespace ECommerceApi.Application.Interfaces
{
    public interface IProductPriceService
    {
        IEnumerable<ProductPrice> GetAllPrices();
        ProductPrice GetPriceById(int id);
        void AddPrice(ProductPrice price);
        void UpdatePrice(ProductPrice price);
        void DeletePrice(int id);
    }
}
