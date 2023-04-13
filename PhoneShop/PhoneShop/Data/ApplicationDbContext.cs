using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhoneShop.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using PhoneShop.Models.Phone;
using PhoneShop.Models.Order;
using PhoneShop.Models.Client;

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
        public DbSet<PhoneShop.Models.Phone.PhoneIndexVM> PhoneIndexVM { get; set; }
        public DbSet<PhoneShop.Models.Phone.PhoneEditVM> PhoneEditVM { get; set; }
        public DbSet<PhoneShop.Models.Phone.PhoneDetailsVM> PhoneDetailsVM { get; set; }
        public DbSet<PhoneShop.Models.Phone.PhoneDeleteVM> PhoneDeleteVM { get; set; }
        public DbSet<PhoneShop.Models.Order.OrderConfirmVM> OrderConfirmVM { get; set; }
        public DbSet<PhoneShop.Models.Order.OrderIndexVM> OrderIndexVM { get; set; }
        public DbSet<PhoneShop.Models.Client.ClientIndexVM> ClientIndexVM { get; set; }
    }
}
