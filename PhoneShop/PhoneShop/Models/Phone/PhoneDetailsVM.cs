using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PhoneShop.Models.Phone
{
    public class PhoneDetailsVM
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Model")]
        public string Model { get; set; }
        public int BrandId { get; set; }
        [Display(Name = "Brand")]
        public string BrandName { get; set; }

        public int CategoryId { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [Display(Name = "Picture")]
        public string Picture { get; set; }
        [Display(Name = "Color")]
        public string Color { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Discount")]
        public decimal Discount { get; set; }
    }
}
