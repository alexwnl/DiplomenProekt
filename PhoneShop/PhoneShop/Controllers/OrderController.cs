using Microsoft.AspNetCore.Mvc;
using PhoneShop.Data;
using PhoneShop.Domain;
using PhoneShop.Models.Order;
using System.Collections.Generic;
using System.Security.Claims;
using System;
using System.Linq;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace PhoneShop.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class OrderController : Controller

    {
        private readonly ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context)
        { this._context = context; }

        public IActionResult Index()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.SingleOrDefault(u => u.Id == userId);
            List<OrderIndexVM> orders = _context.Orders
                .Select(x => new OrderIndexVM
                {
                    Id = x.Id,
                    OrderDate = x.OrderDate.ToString("dd-MMM,yyyy hh:mm", CultureInfo.InvariantCulture),
                    UserId = x.UserId,
                    User = x.User.UserName,
                    PhoneId = x.PhoneId,
                    Model = x.Model.Model,
                    
                    Picture = x.Model.Picture,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    Discount = x.Discount,
                    TotalPrice = x.TotalPrice
                }).ToList();
            return View(orders);
        }
        [AllowAnonymous]
        public IActionResult MyOrders(string searchString)
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = this._context.Users.SingleOrDefault(u => u.Id == currentUserId);
            if (user == null)
            { return null; }

            List<OrderIndexVM> orders = _context.Orders.Where(x => x.UserId == user.Id)
                .Select(x => new OrderIndexVM
                {
                    Id = x.Id,
                    OrderDate = x.OrderDate.ToString("dd-MMM,yyyy hh:mm", CultureInfo.InvariantCulture),
                    UserId = x.UserId,
                    User = x.User.UserName,
                    PhoneId = x.PhoneId,
                    Model = x.Model.Model,
                    Picture = x.Model.Picture,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    Discount = x.Discount,
                    TotalPrice = x.TotalPrice
                }).ToList();

            if (!String.IsNullOrEmpty(searchString))
            { orders = orders.Where(o => o.Model.ToLower().Contains(searchString.ToLower())).ToList(); }
            return this.View(orders);

        }
        [AllowAnonymous]
        public ActionResult Create(int phoneId, int quantity)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.SingleOrDefault(u => u.Id == userId);
            var phone = this._context.Phones.SingleOrDefault(x => x.Id == phoneId);

            if (user == null || phone == null || phone.Quantity < quantity)
            { return this.RedirectToAction("Index", "Phone"); }

            OrderConfirmVM orderForDb = new OrderConfirmVM
            {
                UserId = userId,
                User = user.UserName,
                PhoneId = phoneId,
                Model = phone.Model,
                Picture = phone.Picture,
                Quantity = quantity,
                Price = phone.Price,
                Discount = phone.Discount,
                TotalPrice = quantity * phone.Price - quantity * phone.Price * phone.Discount / 100
            };
            return View(orderForDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderConfirmVM bindingModel)
        {
            if (this.ModelState.IsValid)
            {
                string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = _context.Users.SingleOrDefault(u => u.Id == userId);
                var phone = this._context.Phones.SingleOrDefault(x => x.Id == bindingModel.PhoneId);

                if (user == null || phone == null || phone.Quantity < bindingModel.Quantity || bindingModel.Quantity == 0)
                { return this.RedirectToAction("Index", "Phone"); }

                Order orderForDb = new Order
                {
                    OrderDate = DateTime.UtcNow,
                    PhoneId = bindingModel.PhoneId,
                    UserId = userId,
                    Quantity = bindingModel.Quantity,
                    Price = phone.Price,
                    Discount = phone.Discount
                };
                phone.Quantity -= bindingModel.Quantity;

                this._context.Phones.Update(phone);
                this._context.Orders.Add(orderForDb);
                this._context.SaveChanges();
            }
            return this.RedirectToAction("Index", "Phone");
        }
    }
}
