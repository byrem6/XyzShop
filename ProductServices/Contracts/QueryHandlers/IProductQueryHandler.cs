
using ProductServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductServices.Contracts.QueryHandlers
{
    public interface IProductQueryHandler
    {
        List<Product> GetProducts();
        Task<Product> GetProduct(int id);
    }
}
