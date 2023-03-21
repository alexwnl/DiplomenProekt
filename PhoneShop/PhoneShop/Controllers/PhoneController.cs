using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneShop.Abstraction;
using PhoneShop.Domain;
using PhoneShop.Models.Brand;
using PhoneShop.Models.Category;
using PhoneShop.Models.Phone;
using PhoneShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneShop.Controllers
{
    [Authorize(Roles = "Administrator")]
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
                var createId = _phoneService.Create(phone.Model, phone.BrandId,
                                                    phone.CategoryId, phone.Picture, phone.Description, phone.Color,
                                                    phone.Quantity, phone.Price, phone.Discount); ;
                if (createId)
                {
                    return RedirectToAction(nameof(Index));
                }
                
            }
            return View();
        }
        public IActionResult CreateSuccess()
        { return this.View(); }
        [AllowAnonymous]
        public ActionResult Index(string searchStringCategoryName, string searchStringBrandName)
        {
            List<PhoneIndexVM> phones = _phoneService.GetPhones(searchStringCategoryName, searchStringBrandName).Select(phone => new PhoneIndexVM
            {
                Id = phone.Id,
                Model=phone.Model,
                BrandId=phone.BrandId,
                BrandName = phone.Brand.BrandName,
                CategoryId = phone.CategoryId,
                CategoryName = phone.Category.CategoryName,
                Picture = phone.Picture,
                Description= phone.Description,
                Color = phone.Color,
                Quantity = phone.Quantity,
                Price = phone.Price,
                Discount=phone.Discount
            }).ToList();
            return this.View(phones);
        }
        public ActionResult Edit(int id)
        {
            Phone phone = _phoneService.GetPhoneById(id);
            if (phone == null)
            { return NotFound(); }

            PhoneEditVM updatedPhone = new PhoneEditVM()
            {

                Id = phone.Id,
                Model = phone.Model,
                BrandId = phone.BrandId,
               // BrandName = phone.Brand.BrandName,
                CategoryId = phone.CategoryId,
               // CategoryName = phone.Category.CategoryName,
                Picture = phone.Picture,
                Quantity = phone.Quantity,
                Description = phone.Description,
                Color = phone.Color,
                Price = phone.Price,
                Discount = phone.Discount
            };

            updatedPhone.Brands = _brandService.GetBrands()
                .Select(b => new BrandPairVM()
                {
                    Id = b.Id,
                    Name = b.BrandName
                }).ToList();

            updatedPhone.Categories = _categoryService.GetCategories()
                .Select(c => new CategoryPairVM
                {
                    Id = c.Id,
                    Name = c.CategoryName
                }).ToList();

            return View(updatedPhone);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(int id, PhoneEditVM phone)
        {
            if (ModelState.IsValid)
            {
                var updated = _phoneService.Update(id, phone.Model, phone.BrandId,
                    phone.CategoryId, phone.Picture, phone.Description, phone.Color,
                    phone.Quantity, phone.Price, phone.Discount);

                if (updated)
                { 
                    return this.RedirectToAction("Index");
                }

            }
            return View(phone);
        }
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Phone item = _phoneService.GetPhoneById(id);
            if (item == null)
            { return NotFound(); }

            PhoneDetailsVM phone = new PhoneDetailsVM()
            {
                Id = item.Id,
                Model = item.Model,
                BrandId = item.BrandId,
                BrandName = item.Brand.BrandName,
                CategoryId = item.CategoryId,
                CategoryName = item.Category.CategoryName,
                Picture = item.Picture,
                Description = item.Description,
                Color = item.Color,
                Quantity = item.Quantity,
                Price = item.Price,
                Discount = item.Discount
            };
            return View(phone);
        }
        public ActionResult Delete(int id)
        {
            Phone item = _phoneService.GetPhoneById(id);
            if (item == null)
            { return NotFound(); }

            PhoneDeleteVM phone = new PhoneDeleteVM()
            {
                Id = item.Id,
                Model = item.Model,
                BrandId = item.BrandId,
                BrandName = item.Brand.BrandName,
                CategoryId = item.CategoryId,
                CategoryName = item.Category.CategoryName,
                Picture = item.Picture,
                Description = item.Description,
                Color = item.Color,
                Quantity = item.Quantity,
                Price = item.Price,
                Discount = item.Discount
            };
            return View(phone);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete (int id, IFormCollection collection)
        {
            var deleted = _phoneService.RemoveById(id);
            if (deleted)
            {
                return this.RedirectToAction("DeleteSucces");
            }
            else
            {
                return View();
            }
        }
        public IActionResult DeleteSucces()
        {
            return View();
        }

    }
}
