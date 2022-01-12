using CustomerServices.CommandRequestModels;
using CustomerServices.RequestModels.CommandRequestModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductServices.Contracts.CommandHandler;
using ProductServices.Contracts.QueryHandlers;
using ProductServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductServices.Controllers
{
    [ApiController]
    [Route("api/v1/product")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        private readonly IProductCommandHandler _productCommandHandler;
        private readonly IProductQueryHandler _productQueryHandler;

        public ProductController(ILogger<ProductController> logger, IProductCommandHandler productCommandHandler, IProductQueryHandler productQueryHandler)
        {
            _logger = logger;
            _productCommandHandler = productCommandHandler;
            _productQueryHandler = productQueryHandler;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _productQueryHandler.GetProducts();
        }

        [HttpGet("detail")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var Product = await _productQueryHandler.GetProduct(id);
            return Product != null ? new JsonResult(Product) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> SaveProduct(ProductRequestModel product)
        {
            _logger.LogDebug("Add New Product", new JsonResult(product));

            var newProduct = await _productCommandHandler.Save(product);

            _logger.LogDebug("Success Add New Product", new JsonResult(newProduct));

            return new JsonResult(newProduct);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductUpdateRequestModel productUpdateRequestModel)
        {
            _logger.LogDebug("Update Product", new JsonResult(productUpdateRequestModel.Product));

            var updatedProduct = await _productCommandHandler.UpdateProduct(productUpdateRequestModel);


            _logger.LogDebug("Success Update Product", new JsonResult(updatedProduct));

            return new JsonResult(updatedProduct);
        }
    }
}
