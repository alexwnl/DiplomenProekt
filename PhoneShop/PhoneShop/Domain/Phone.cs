using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneShop.Domain
{
    public class Phone
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string PhoneBrand { get; set; }
        public int BrandId { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public virtual Brand Brand { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string Picture { get; set; }

        [Required]
        [Range(0,5000)]
        public int Quantity { get; set; }
        [Required]
        [Range(300, 3000)]
        public decimal Price { get; set; }
        [Range(0,15)]
        public decimal Discount { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();

    }
}
