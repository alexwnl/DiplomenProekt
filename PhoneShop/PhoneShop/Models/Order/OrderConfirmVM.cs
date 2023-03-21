using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneShop.Models.Order
{
    public class OrderConfirmVM
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public string User { get; set; }
        [Required]
        public int PhoneId { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Picture { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
