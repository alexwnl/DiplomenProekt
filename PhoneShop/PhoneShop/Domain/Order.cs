using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneShop.Domain
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public int PhoneId { get; set; }
        public virtual Phone Phone { get; set; }
        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [Range(300,3000)]
        public decimal Price { get; set; }
        [Range(0, 15)]//ot 0 do 15% otstupka
        public decimal Discount { get; set; }
        public decimal TotalPrice
        {
            get
            {
return Quantity * Price - Quantity * Price * Discount / 100;
            }
        }
    }
}
