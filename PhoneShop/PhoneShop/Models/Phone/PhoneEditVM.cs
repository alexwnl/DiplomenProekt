using PhoneShop.Models.Brand;
using PhoneShop.Models.Category;
using PhoneShop.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PhoneShop.Models.Phone
{
    public class PhoneEditVM
    {
        public PhoneEditVM()
        {
            Brands = new List<BrandPairVM>();
            Categories = new List<CategoryPairVM>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "Model")]
        public string Model { get; set; }
        [Required]
        public int BrandId { get; set; }
        [Display(Name = "Brand")]
        public virtual List<BrandPairVM> Brands { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public virtual List<CategoryPairVM> Categories { get; set; }

        [Display(Name = "Picture")]
        public string Picture { get; set; }
   
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Color")]
        public string Color { get; set; }
        [Required]
        [Range(0, 5000)]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Discount")]
        public decimal Discount { get; set; }
    }
}
