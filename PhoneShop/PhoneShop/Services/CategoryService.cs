using PhoneShop.Abstraction;
using PhoneShop.Data;
using PhoneShop.Domain;
using System.Collections.Generic;
using System.Linq;

namespace PhoneShop.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Category> GetCategories()
        {
            List<Category> categories= _context.Categories.ToList();
            return categories;
        }

        public Category GetCategoryById(int categoryId)
        {
            return _context.Categories.Find(categoryId);
        }

        public List<Phone> GetPhonesByCategory(int categoryId)
        {
            return _context.Phones
               .Where(x => x.BrandId == categoryId)
               .ToList();
        }
    }
}
