using Microsoft.AspNetCore.Mvc;

namespace FridgeV2.Controllers
{
    public class RecipesList : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
