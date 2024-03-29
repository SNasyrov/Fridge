﻿using FridgeV2.Data;
using FridgeV2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FridgeV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ProductsController : Controller
    {
        private ApplicationContext db;

        public ProductsController(ApplicationContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Manufacturer> manufacturer = await db.Manufacturers.ToListAsync();
            return View(await db.Products.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<Manufacturer> manufacturer = await db.Manufacturers.ToListAsync();
            ViewBag.manufacturer = new SelectList(manufacturer, "Id", "Name");
            List<Category> categories = await db.Categories.ToListAsync();
            ViewBag.categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Confirm")]
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

        [HttpGet]
        [ActionName("Delete")]
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
