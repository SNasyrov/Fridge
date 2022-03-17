using FridgeV2.Data;
using FridgeV2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FridgeV2.Controllers
{
    [Authorize]
    public class ProductsInFridgeController : Controller
    {
        private ApplicationContext db;

        private UserManager<User> UserManager;
        public ProductsInFridgeController(ApplicationContext context, UserManager<User> userManager)
        {
            db = context;
            UserManager = userManager;
        }

        public async Task<IActionResult> Index(SortState sortOrder = SortState.NameAsc)
        {
            string currentUserId = UserManager.GetUserId(User);

            IQueryable<ProductInFridge> productInFridges = db.ProductsInFridge.Include(x => x.Product);

            List<ProductInFridge> productsInFridge = await db.ProductsInFridge
                                                             .Include(p => p.Product)
                                                             .Where(p => p.UserId == currentUserId)
                                                             .ToListAsync();

            ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            ViewData["AgeSort"] = sortOrder == SortState.AgeAsc ? SortState.AgeDesc : SortState.AgeAsc;

            productInFridges = sortOrder switch
            {
                SortState.NameDesc => productInFridges.OrderByDescending(s => s.Product.Name),
                SortState.AgeAsc => productInFridges.OrderBy(s => s.ExpirationDate),
                SortState.AgeDesc => productInFridges.OrderByDescending(s => s.ExpirationDate),
                _ => productInFridges.OrderBy(s => s.Product.Name),
            };

            return View(await productInFridges.AsNoTracking().ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? productId, string returnUrl)
        {
            List<Product> products = await db.Products.Where(shop => shop.IsConfirmed == true).Include(p => p.Manufacturer).ToListAsync();
            ViewBag.Products = new SelectList(products, "Id", "Name");
            List<Shop> shops = await db.Shops.Where(shop => shop.IsConfirmed == true).ToListAsync();
            ViewBag.Shops = new SelectList(shops, "Id", "Name");
            ProductInFridge productInFridge = new ProductInFridge();
            if (productId != null)
            {
                productInFridge.ProductId = productId.Value;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductInFridge Prod, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            string currentUserId = UserManager.GetUserId(User);

            Prod.UserId = currentUserId;

            db.ProductsInFridge.Add(Prod);
            await db.SaveChangesAsync();
            if (string.IsNullOrWhiteSpace(returnUrl) == false)
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                ProductInFridge product = await db.ProductsInFridge.Include(p => p.Product).FirstOrDefaultAsync(p => p.Id == id);
                ProductInFridge prod = await db.ProductsInFridge.Include(p => p.Shop).FirstOrDefaultAsync(p => p.Id == id);
                if (prod != null)
                    return View(prod);
            }
            return NotFound();
        }

        /// <summary>
        /// Подробнее
        /// </summary>
        /// <param name="id">Идентификатор товара</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                List<Product> products = await db.Products.ToListAsync();
                ViewBag.Products = new SelectList(products, "Id", "Name");
                List<Shop> shops = await db.Shops.Where(shop => shop.IsConfirmed == true).ToListAsync();
                ViewBag.Shops = new SelectList(shops, "Id", "Name");
                ProductInFridge prod = await db.ProductsInFridge.FirstOrDefaultAsync(p => p.Id == id);
                if (prod != null)
                    return View(prod);
            }
            return NotFound();
        }

        /// <summary>
        /// Изменение
        /// </summary>
        /// <param name="prod">Продукт</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(ProductInFridge prod)
        {
            db.ProductsInFridge.Update(prod);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                ProductInFridge prod = await db.ProductsInFridge.Include(p => p.Product).FirstOrDefaultAsync(p => p.Id == id);
                if (prod != null)
                    return View(prod);
            }
            return NotFound();
        }

        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                ProductInFridge prod = await db.ProductsInFridge.FirstOrDefaultAsync(p => p.Id == id);
                if (prod != null)
                {
                    db.ProductsInFridge.Remove(prod);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
