using FridgeV2.Data;
using FridgeV2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FridgeV2.Controllers
{
    [Authorize]
    public class FavoriteProductsController : Controller
    {
        private ApplicationContext db;

        private UserManager<User> UserManager;

        public FavoriteProductsController(ApplicationContext context, UserManager<User> userManager)
        {
            db = context;
            UserManager = userManager;
        }

        /// <summary>
        /// Доавить в любимый продукт
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ConfirmToAddFavoriteProductConfirm(int? id)
        {
            string currentUserId = UserManager.GetUserId(User);

            if (id != null)
            {
                Product product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                    TempData["currentUserId"] = currentUserId;
                    TempData["ProductId"] = product.Id;
                return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmToAddFavoriteProduct(FavoriteProduct favoriteProduct)
        {
            int ProductId = Convert.ToInt32(TempData["ProductId"]);
            Product product = await db.Products.FirstOrDefaultAsync(p => p.Id == ProductId);
            Manufacturer manufacturer = await db.Manufacturers.FirstOrDefaultAsync(m => m.Id == product.ManufacturerId);
            string manufacturerName = manufacturer.Name;
            string currentUserId = UserManager.GetUserId(User);

            favoriteProduct.UserId = currentUserId;
            favoriteProduct.ProductName = product.Name;
            favoriteProduct.ManufacturerName = manufacturerName;


            if (ProductId != 0)
            {
                db.FavoriteProducts.Update(favoriteProduct);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "FavoriteProducts");
            }
            return NotFound();
        }

        public async Task<IActionResult> Index()
        {
            string currentUserId = UserManager.GetUserId(User);
            List<FavoriteProduct> favoriteProducts = await db.FavoriteProducts.Where(p => p.UserId == currentUserId).ToListAsync();

            return View(favoriteProducts);
        }
    }
}
