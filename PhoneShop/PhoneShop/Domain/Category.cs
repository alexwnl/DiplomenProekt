using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneShop.Domain
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string CategoryName { get; set; }
        public virtual IEnumerable<Phone> Phones { get; set; } = new List<Phone>();
    }
}
