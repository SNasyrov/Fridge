using FridgeV2.Data;
using FridgeV2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FridgeV2.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private ApplicationContext db;

        public ProductsController(ApplicationContext context)
        {
            db = context;
        }
        public IActionResult OnCheck()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateCustomProductAsync()
        {
            List<Manufacturer> manufacturer = await db.Manufacturers.ToListAsync();
            ViewBag.manufacturer = new SelectList(manufacturer, "Id", "Name");
            List<Category> categories = await db.Categories.ToListAsync();
            ViewBag.categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomProduct(Product product)
        {
            product.IsConfirmed = false;
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return RedirectToAction("OnCheck");
        }
    }
}
