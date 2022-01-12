using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductServices.Models
{
    [Table("Tbl_Product")]
    public class Product : BaseProduct
    {
        [Key]
        public int Id { get; set; }

        public string ImageUrl { get; set; }
    }
}
