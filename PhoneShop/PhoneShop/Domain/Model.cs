using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneShop.Domain
{
    public class Model
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string ModelName { get; set; }
        public virtual IEnumerable<Phone> Phones { get; set; } = new List<Phone>();
    }
}
