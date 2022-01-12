
using CustomerServices.CommandRequestModels;
using CustomerServices.RequestModels.CommandRequestModels;
using ProductServices.Context;
using ProductServices.Contracts.CommandHandler;
using ProductServices.Models;
using System;
using System.Threading.Tasks;

namespace ProductServices.Handlers.CommandHandlers
{
    public class ProductCommandHandler : IProductCommandHandler
    {
        private ProductServicesDbContext _db;

        public ProductCommandHandler(ProductServicesDbContext db)
        {
            _db = db;
        }



        public async Task<Product> Save(ProductRequestModel requestModel)
        {

            var Product = new Product()
            {
                Name = requestModel.Name,
                Description = requestModel.Description,
                Price = requestModel.Price,
                TypeId = requestModel.TypeId,
                ImageUrl = requestModel.ImageUrl,
                CreatedDate = DateTime.Now,
                IsRemoved = false,
                UpdatedDate = DateTime.Now
            };


            _db.Product.Add(Product);
            await _db.SaveChangesAsync();

            return Product;
        }

        public async Task<Product> UpdateProduct(ProductUpdateRequestModel ProductUpdateRequestModel)
        {
            var product = _db.Product.Find(ProductUpdateRequestModel.Id);
            product.Name = ProductUpdateRequestModel.Product.Name;
            product.Description = ProductUpdateRequestModel.Product.Description;
            product.Price = ProductUpdateRequestModel.Product.Price;
            product.TypeId = ProductUpdateRequestModel.Product.TypeId;
            product.ImageUrl = ProductUpdateRequestModel.Product.ImageUrl;
            product.UpdatedDate = DateTime.Now;

            await _db.SaveChangesAsync();

            return product;
        }
    }
}
