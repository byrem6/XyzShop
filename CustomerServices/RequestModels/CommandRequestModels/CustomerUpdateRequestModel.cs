using CustomerServices.RequestModels.CommandRequestModels;

namespace CustomerServices.CommandRequestModels
{
    public class CustomerUpdateRequestModel
    {
        public int Id { get; set; }
        public CustomerRequestModel Customer { get; set; }
    }
}
