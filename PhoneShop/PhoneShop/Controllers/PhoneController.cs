using Microsoft.AspNetCore.Mvc;
using PhoneShop.Abstraction;
using PhoneShop.Domain;
using PhoneShop.Models.Brand;
using PhoneShop.Models.Category;
using PhoneShop.Models.Phone;
using PhoneShop.Services;
using System;
using System.Linq;

namespace PhoneShop.Controllers
{
    public class PhoneController : Controller
    {
        private readonly IPhoneService _phoneService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;    
         
        public PhoneController(IPhoneService phoneService, ICategoryService categoryService, IBrandService brandService)
        {
            this._phoneService = phoneService;
            this._categoryService = categoryService;
            this._brandService = brandService;
        }
        public ActionResult Create() 
        {
            var phone = new PhoneCreateVM();
            phone.Brands = _brandService.GetBrands()
            .Select(x => new BrandPairVM()
            {
                Id= x.Id,
                Name= x.BrandName,   
            }).ToList();
            phone.Categories = _categoryService.GetCategories()
                .Select(x => new CategoryPairVM()
                {
                    Id = x.Id,
                    Name = x.CategoryName,
                }).ToList();
            return View(phone);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm]PhoneCreateVM phone)
        {
            if (ModelState.IsValid)
            {
                var createId = _phoneService.Create(phone.PhoneBrand, phone.BrandId,
                                                    phone.CategoryId, phone.Picture,phone.Color,phone.Description,
                                                    phone.Quantity, phone.Price, phone.Discount);
                if (createId)
                {
                    return RedirectToAction(nameof(Index));
                }
                
            }
            return View();
        }
    }
}
