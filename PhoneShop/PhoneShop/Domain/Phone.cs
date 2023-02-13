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
        public string PhoneName { get; set; }
        public int ModelId { get; set; }
        public virtual Model Model { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string Picture { get; set; }

        [Required]
        [Range(0,5000)]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();

    }
}
