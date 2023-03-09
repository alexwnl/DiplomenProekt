using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhoneShop.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using PhoneShop.Models.Phone;

namespace PhoneShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public IEnumerable<object> Products { get; internal set; }
        public DbSet<PhoneShop.Models.Phone.PhoneCreateVM> PhoneCreateVM { get; set; }
    }
}
