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
    public class ShoppingListItemsController : Controller
    {
        private ApplicationContext db;
        private UserManager<User> _userManager;

        public ShoppingListItemsController(ApplicationContext context, UserManager<User> userManager)
        {
            db = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            string currentUserId = _userManager.GetUserId(User);

            List<ProductInFridge> productInFridges = await db.ProductsInFridge.Include(p => p.Product).ToListAsync();

            List<ShoppingListItem> shoppingListItems = await db.ShoppingListItems
                                                             .Include(p => p.Product)
                                                             .Where(p => p.UserId == currentUserId)
                                                             .ToListAsync();
            return View(shoppingListItems);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? productId, string returnUrl)
        {
            List<Product> products = await db.Products.ToListAsync();
            ViewBag.Products = new SelectList(products, "Id", "Name");
            ShoppingListItem shoppingListItem = new ShoppingListItem();
            if (productId != null)
            {
                shoppingListItem.ProductId = productId.Value;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShoppingListItem ShoppingList, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            string currentUserId = _userManager.GetUserId(User);

            ShoppingList.UserId = currentUserId;

            db.ShoppingListItems.Add(ShoppingList);
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

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                ShoppingListItem ShoppingList = await db.ShoppingListItems.FirstOrDefaultAsync(p => p.Id == id);
                if (ShoppingList != null)
                    return View(ShoppingList);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                ShoppingListItem ShoppingList = await db.ShoppingListItems.FirstOrDefaultAsync(p => p.Id == id);
                if (ShoppingList != null)
                {
                    db.ShoppingListItems.Remove(ShoppingList);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

    }
}
