using PhoneShop.Domain;
using System.Collections.Generic;

namespace PhoneShop.Abstraction
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        Category GetCategoryById(int categoryId);
        List<Phone> GetProductsByCategory(int categoryId);
    }
}
