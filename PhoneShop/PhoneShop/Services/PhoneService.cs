using PhoneShop.Abstraction;
using PhoneShop.Data;
using PhoneShop.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;

namespace PhoneShop.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly ApplicationDbContext _context;
        public PhoneService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(string model, int brandId, int categoryId, string picture,string description, string color, int quantity, decimal price, decimal discount)
        {
            Phone item = new Phone
            {
                Model = model,
                Brand = _context.Brands.Find(brandId),
                Category = _context.Categories.Find(categoryId),
                Description = description,
                Color = color,
                Picture = picture,
                Quantity = quantity,
                Price = price,
                Discount = discount
            };
            _context.Phones.Add(item);
            return _context.SaveChanges() != 0;
        }
        public Phone GetPhoneById(int phoneid)
        {
            return _context.Phones.Find(phoneid);
        }
        public List<Phone> GetPhones()
        {
            List<Phone> phones = _context.Phones.ToList();
            return _context.Phones.ToList();
        }
        public bool RemoveById(int phoneId)
        {
            var phone = GetPhoneById(phoneId);
            if (phone == default(Phone))
            {
                return false;
            }
            _context.Remove(phone);
            return _context.SaveChanges() != 0;
        }
        public List<Phone> GetPhones(string searchStringCategoryName, string searchStringBrandName)
        {
            List<Phone> phones = _context.Phones.ToList();
            if (!String.IsNullOrEmpty(searchStringCategoryName) && !String.IsNullOrEmpty(searchStringBrandName))
            {
                phones = phones.Where(x => x.Category.CategoryName.ToLower().Contains(searchStringCategoryName.ToLower())
                && x.Brand.BrandName.ToLower().Contains(searchStringBrandName.ToLower())).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringCategoryName))
            {
                phones = phones.Where(x => x.Category.CategoryName.ToLower().Contains(searchStringCategoryName.ToLower())).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringBrandName))
            {
                phones = phones.Where(x => x.Brand.BrandName.ToLower().Contains(searchStringBrandName.ToLower())).ToList();
            }
            return phones;
        }
        public bool Update(int phoneId,string model,int brandId,int categoryId,string picture, string description,string color, int quantity,decimal price,decimal discount)
        {
            var phone = GetPhoneById(phoneId);
            if (phone == default(Phone))
            {
                return false;
            }
            //phone.PhoneName= name
            phone.Model = model;
            phone.BrandId= brandId;
            phone.CategoryId= categoryId;
            phone.Brand = _context.Brands.Find(brandId);
            phone.Category = _context.Categories.Find(categoryId);
            phone.Picture = picture;
            phone.Description = description;
            phone.Color = color;
            phone.Quantity = quantity;
            phone.Price = price;
            phone.Discount = discount;
            _context.Update(phone);
            return _context.SaveChanges() != 0;
        }

       
    
    }
}

