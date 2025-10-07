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

        public IEnumerable<ProductPrice> GetAllPrices()
        {
            return _priceRepository.GetAll();
        }

        public ProductPrice GetPriceById(int id)
        {
            return _priceRepository.GetById(id);
        }

        public void AddPrice(ProductPrice price)
        {
            _priceRepository.Add(price);
        }

        public void UpdatePrice(ProductPrice price)
        {
            _priceRepository.Update(price);
        }

        public void DeletePrice(int id)
        {
            var entity = _priceRepository.GetById(id);
            if (entity != null)
            {
                _priceRepository.Delete(entity);
            }
        }
    }
}
