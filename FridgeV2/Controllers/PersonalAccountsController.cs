using FridgeV2.Data;
using FridgeV2.Models;
using FridgeV2.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FridgeV2.Controllers
{
    public class PersonalAccountsController : Controller
    {
        private UserManager<User> _userManager;

        private ApplicationContext db;


        public PersonalAccountsController(ApplicationContext context, UserManager<User> userManager)
        {
            db = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Users.ToListAsync());
        }

        public async Task<IActionResult> AccountSetup()
        {
            User currentUser = await _userManager.GetUserAsync(User);
            return View(currentUser);
        }

        public async Task<IActionResult> ChangePassword()
        {

            User currentUser = await _userManager.GetUserAsync(User);
            ChangePasswordViewModel model = new ChangePasswordViewModel { Id = currentUser.Id, Email = currentUser.Email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    IdentityResult result =
                        await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Пользователь не найден");
                }
            }
            return View(model);
        }
    }
}
