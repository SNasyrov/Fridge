using FridgeV2.Data;
using FridgeV2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FridgeV2.Controllers
{
    [Authorize]
    public class GeneralFridgeController : Controller
    {
        private ApplicationContext _db;

        private UserManager<User> _userManager;
        public GeneralFridgeController(ApplicationContext context, UserManager<User> userManager)
        {
            _db = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        // TODO : SharedFridge
        
        [HttpGet]
        public async Task<IActionResult> SharedFridge()
        {
            string currentUserId = _userManager.GetUserId(User);

            var users = _userManager.Users.ToList();
            ViewBag.Users = new SelectList(users);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SharedFridgeAdd(GeneralFridge generalFridge)
        {
            return RedirectToAction("Index");
        }
    }
}
