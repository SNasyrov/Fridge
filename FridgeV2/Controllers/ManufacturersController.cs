using FridgeV2.Data;
using FridgeV2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FridgeV2.Controllers
{
    [Authorize(Roles = "admin")]
    public class ManufacturersController : Controller
    {
        private ApplicationContext db;

        public ManufacturersController(ApplicationContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Manufacturers.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            db.Manufacturers.Add(manufacturer);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            if (id != null)
            {
                Manufacturer manufacturer = await db.Manufacturers.FirstOrDefaultAsync(p => p.Id == id);
                if (manufacturer != null)
                    return View(manufacturer);
            }
            return NotFound();
        }

        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Manufacturer manufacturer = await db.Manufacturers.FirstOrDefaultAsync(p => p.Id == id);
                if (manufacturer != null)
                {
                    db.Manufacturers.Remove(manufacturer);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
