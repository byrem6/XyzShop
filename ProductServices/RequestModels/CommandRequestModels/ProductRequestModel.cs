namespace CustomerServices.RequestModels.CommandRequestModels
{
    public class ProductRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int TypeId { get; set; }

        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
