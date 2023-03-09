using Castle.Components.DictionaryAdapter;
using PhoneShop.Abstraction;
using PhoneShop.Domain;
using PhoneShop.Models.Brand;
using PhoneShop.Models.Category;
using PhoneShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;


namespace PhoneShop.Models.Phone
{
    public class PhoneCreateVM
    {
        public PhoneCreateVM()
        {
            Brands = new List<BrandPairVM>();
            Categories = new List<CategoryPairVM>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "PhoneBrand")]
        public string PhoneBrand { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public int BrandId { get; set; }
        public virtual List<BrandPairVM> Brands { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public virtual List<CategoryPairVM> Categories { get; set; }
        [Display(Name = "Picture")]
        public string Picture { get; set; }
        [Required]
        [Range(0, 5000)]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Display(Name = "Discount")]
        public decimal Discount { get; set; }
        [Display(Name = "Color")]
        public string Color { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
    
}
