namespace CustomerServices.RequestModels.CommandRequestModels
{
    public class CustomerRequestModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
    }
}
