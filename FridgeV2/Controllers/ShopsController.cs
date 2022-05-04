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
    }
}
