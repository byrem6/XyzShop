using CustomerServices.CommandRequestModels;
using CustomerServices.RequestModels.CommandRequestModels;
using ProductServices.Models;
using System.Threading.Tasks;

namespace ProductServices.Contracts.CommandHandler
{
    public interface IProductCommandHandler
    {
        Task<Product> Save(ProductRequestModel requestModel);
        Task<Product> UpdateProduct(ProductUpdateRequestModel productUpdateRequestModel);

    }
}
