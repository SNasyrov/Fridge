using FridgeV2.Data;
using Microsoft.AspNetCore.Mvc;

namespace FridgeV2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
