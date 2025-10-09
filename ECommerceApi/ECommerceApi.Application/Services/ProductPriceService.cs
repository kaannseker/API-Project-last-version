using ECommerceApi.Application.Interfaces;
using ECommerceApi.Domain.Entities;
using ECommerceApi.Infrastructure.Repositories.GenericRepository;
using System.Collections.Generic;

namespace ECommerceApi.Application.Services
{
    public class ProductPriceService : IProductPriceService
    {
        private readonly IGenericRepository<ProductPrice> _priceRepository;

        public ProductPriceService(IGenericRepository<ProductPrice> priceRepository)
        {
            _priceRepository = priceRepository;
        }

        public async Task<IEnumerable<ProductPrice>> GetAllPrices()
        {
            return await _priceRepository.GetAllAsync();
        }

        public async Task<ProductPrice> GetPriceById(int id)
        {
            return await _priceRepository.GetByIdAsync(id);
        }

        public async Task AddPrice(ProductPrice price)
        {
            await _priceRepository.AddAsync(price);
        }

        public void UpdatePrice(ProductPrice price)
        {
            _priceRepository.Update(price);
        }

        public async Task DeletePrice(int id)
        {
            var entity = await _priceRepository.GetByIdAsync(id);
            if (entity != null)
            {
                _priceRepository.Delete(entity);
            }
        }
    }
}
