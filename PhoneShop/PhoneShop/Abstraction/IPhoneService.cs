using PhoneShop.Domain;
using System.Collections.Generic;

namespace PhoneShop.Abstraction
{
    public interface IPhoneService
    {
        bool Create(string name, int brandId, int categoryId, string color ,string description,string picture, int quantity, decimal price, decimal discount);
        bool Update(int phoneId,string name, int brandId,int categoryId, string color, string description,string picture,int quantity, decimal price, decimal discount);
        List<Phone> GetProducts();
            Phone GetPhoneById(int phoneId);
        bool RemoveById(int phoneId);
        List<Phone> GetPhones(string searchStringCategoryName, string searchStringBrandName);
    }
}
