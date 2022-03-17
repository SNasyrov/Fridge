using FridgeV2.Data;
using FridgeV2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FridgeV2.Controllers
{
    [Authorize]
    public class ShopsController : Controller
    {
        private ApplicationContext db;

        public ShopsController(ApplicationContext context)
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
            return View(await db.Shops.ToListAsync());
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(Shop Shop)
        {
            db.Shops.Add(Shop);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateCustomShop()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomShop(Shop Shop)
        {
            Shop.IsConfirmed = false;
            db.Shops.Add(Shop);
            await db.SaveChangesAsync();
            return RedirectToAction("OnCheck");
        }

        [HttpGet]
        [ActionName("Delete")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Shop Shop = await db.Shops.FirstOrDefaultAsync(p => p.Id == id);
                if (Shop != null)
                    return View(Shop);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Shop Shop = await db.Shops.FirstOrDefaultAsync(p => p.Id == id);
                if (Shop != null)
                {
                    db.Shops.Remove(Shop);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        [HttpGet]
        [ActionName("Confirm")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> ConfirmConfirm(int? id)
        {
            if (id != null)
            {
                Shop Shop = await db.Shops.FirstOrDefaultAsync(p => p.Id == id);
                if (Shop != null)
                    return View(Shop);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Confirm(int? id)
        {
            if (id != null)
            {
                Shop Shop = await db.Shops.FirstOrDefaultAsync(p => p.Id == id);
                if (Shop != null)
                {
                    Shop.IsConfirmed = true;
                    db.Shops.Update(Shop);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
