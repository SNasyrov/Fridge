using FridgeV2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using FridgeV2.Models;
using Microsoft.AspNetCore.Authorization;

namespace FridgeV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ShopsController : Controller
    {
        private ApplicationContext db;

        public ShopsController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await db.Shops.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Shop Shop)
        {
            db.Shops.Add(Shop);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
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
