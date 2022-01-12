using Microsoft.Extensions.Caching.Memory;
using ProductServices.Context;
using ProductServices.Contracts.QueryHandlers;
using ProductServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices.Handlers.QueryHandlers
{
    public class ProductQueryHandler : IProductQueryHandler
    {

        private ProductServicesDbContext _db;
        private readonly IMemoryCache _memoryCache;

        public ProductQueryHandler(ProductServicesDbContext db, IMemoryCache memoryCache)
        {
            _db = db;
            _memoryCache = memoryCache;
        }

        public async Task<Product?> GetProduct(int id)
        {
            return await _db.Product.FindAsync(id);
        }

        public List<Product> GetProducts()
        {
            var cacheKey = "productList";
            if (!_memoryCache.TryGetValue(cacheKey, out List<Product> productList))
            {
                productList = _db.Product.ToList();

                var cacheExpiryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(50),
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromSeconds(20)
                };
                _memoryCache.Set(cacheKey, productList, cacheExpiryOptions);
            }


            return productList;
        }
    }
}
