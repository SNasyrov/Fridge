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

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            List<Manufacturer> manufacturer = await db.Manufacturers.ToListAsync();
            return View(await db.Products.ToListAsync());
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create()
        {
            List<Manufacturer> manufacturer = await db.Manufacturers.ToListAsync();
            ViewBag.manufacturer = new SelectList(manufacturer, "Id", "Name");
            List<Category> categories = await db.Categories.ToListAsync();
            ViewBag.categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(Product product)
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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

        [HttpGet]
        [ActionName("Confirm")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> ConfirmConfirm(int? id)
        {
            if (id != null)
            {
                Product product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                    return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Confirm(int? id)
        {
            if (id != null)
            {
                Product Product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (Product != null)
                {
                    Product.IsConfirmed = true;
                    db.Products.Update(Product);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        /// <summary>
        /// Доавить в любимый продукт
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ConfirmToAddFavoriteProductConfirm(int? id)
        {
            if (id != null)
            {
                Product product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                    TempData["Id"] = product.Id;
                    return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmToAddFavoriteProduct()
        {
            int id = Convert.ToInt32(TempData["Id"]);

            if (id != 0)
            {
                Product Product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (Product != null)
                {
                    Product.LikeTheProduct = true;
                    db.Products.Update(Product);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index", "FavoriteProducts");
                }
            }
            return NotFound();
        }

        [HttpGet]
        [ActionName("Delete")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Product Product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (Product != null)
                    return View(Product);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Product Product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (Product != null)
                {
                    db.Products.Remove(Product);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                List<Manufacturer> manufacturer = await db.Manufacturers.ToListAsync();
                ViewBag.manufacturer = new SelectList(manufacturer, "Id", "Name");
                List<Category> categories = await db.Categories.ToListAsync();
                ViewBag.categories = new SelectList(categories, "Id", "Name");
                Product prod = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (prod != null)
                    return View(prod);
            }
            return NotFound();
        }

        /// <summary>
        /// Изменение
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Edit(Product prod)
        {
            db.Products.Update(prod);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
