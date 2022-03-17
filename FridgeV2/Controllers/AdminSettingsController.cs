using Microsoft.AspNetCore.Mvc;

namespace FridgeV2.Controllers
{
    public class AdminSettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
