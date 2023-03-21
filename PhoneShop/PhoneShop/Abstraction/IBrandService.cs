using PhoneShop.Domain;
using System.Collections.Generic;

namespace PhoneShop.Abstraction
{
    public interface IBrandService
    {
        List<Brand> GetBrands();
        Brand GetBrandById(int brandId);
        List<Phone> GetPhonesByBrand(int brandId);
    }
}
