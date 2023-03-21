using PhoneShop.Domain;
using System.Collections.Generic;

namespace PhoneShop.Abstraction
{
    public interface IPhoneService
    {
        bool Create(string model, int brandId, int categoryId, string description, string color, string picture, int quantity, decimal price, decimal discount);
        bool Update(int phoneId, string model, int brandId, int categoryId, string description, string color, string picture, int quantity, decimal price, decimal discount);
        List<Phone> GetPhones();
        Phone GetPhoneById(int phoneId);
        bool RemoveById(int phoneId);
        List<Phone> GetPhones(string searchStringCategoryName, string searchStringBrandName);
    }
}
