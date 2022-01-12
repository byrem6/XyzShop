using Microsoft.Extensions.Caching.Memory;
using OrderServices.Context;
using OrderServices.Contracts.QueryHandlers;
using OrderServices.Models;
using OrderServices.RequestModels.QueryRequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderServices.Handlers.QueryHandlers
{
    public class OrderQueryHandler : IOrderQueryHandler
    {

        private OrderServicesDbContext _db;
        private readonly IMemoryCache _memoryCache;

        public OrderQueryHandler(OrderServicesDbContext db, IMemoryCache memoryCache)
        {
            _db = db;
            _memoryCache = memoryCache;
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _db.Order.FindAsync(id);
        }

        public List<Order> GetOrders()
        {
            var cacheKey = "customerList";
            if (!_memoryCache.TryGetValue(cacheKey, out List<Order> orderList))
            {
                orderList = _db.Order.ToList();

                var cacheExpiryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(50),
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromSeconds(20)
                };
                _memoryCache.Set(cacheKey, orderList, cacheExpiryOptions);
            }


            return orderList;
        }

        public List<Order> GetOrdersByDateBetween(OrderRequestByDateModel request)
        {
            return _db.Order.Where(n => n.CreatedDate >= request.startDate && n.CreatedDate <= request.endDate).ToList();
        }
    }
}
