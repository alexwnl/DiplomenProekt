using PhoneShop.Abstraction;
using PhoneShop.Data;
using PhoneShop.Domain;
using System.Collections.Generic;
using System.Linq;

namespace PhoneShop.Services
{
    public class BrandService : IBrandService

    {
        private readonly ApplicationDbContext _context;
        public BrandService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Brand GetBrandById(int brandId)
        {
            return _context.Brands.Find(brandId);
        }

        public List<Brand> GetBrands()
        {
            List<Brand> brands = _context.Brands.ToList();
            return brands;
        }

        public List<Phone> GetProductsByBrand(int brandId)
        {
            return _context.Phones
                .Where(x => x.BrandId == brandId)   
                .ToList();
        }
    }
}
