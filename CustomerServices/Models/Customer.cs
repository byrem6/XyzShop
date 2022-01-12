using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerServices.Models
{
    [Table("Tbl_Customer")]
    public class Customer : BaseModelObj
    {
        [Key]
        public int Id { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public string Address { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string PhoneNumber { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }

        public virtual City City { get; set; }
        public virtual Country Country { get; set; }

    }
}
