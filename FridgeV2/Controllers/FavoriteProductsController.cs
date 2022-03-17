using FridgeV2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FridgeV2.Controllers
{
    [Authorize]
    public class FavoriteProductsController : Controller
    {
        private ApplicationContext db;

        public FavoriteProductsController(ApplicationContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Products.ToListAsync());
        }
    }
}
