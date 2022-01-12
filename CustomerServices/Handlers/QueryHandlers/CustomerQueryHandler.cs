using CustomerServices.Context;
using CustomerServices.Contracts.QueryHandlers;
using CustomerServices.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerServices.Handlers.QueryHandlers
{
    public class CustomerQueryHandler : ICustomerQueryHandler
    {

        private readonly CustomerServicesDbContext _db;
        private readonly IMemoryCache _memoryCache;

        public CustomerQueryHandler(CustomerServicesDbContext db, IMemoryCache memoryCache)
        {
            _db = db;
            _memoryCache = memoryCache;
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await _db.Customer.FindAsync(id);
        }

        public List<Customer> GetCustomers()
        {
            var cacheKey = "customerList";
            if (!_memoryCache.TryGetValue(cacheKey, out List<Customer> customerList))
            {
                customerList = _db.Customer.ToList();

                var cacheExpiryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(50),
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromSeconds(20)
                };
                _memoryCache.Set(cacheKey, customerList, cacheExpiryOptions);
            }


            return customerList;
        }
    }
}
