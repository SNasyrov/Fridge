using FridgeV2.Data;
using FridgeV2.Models;
using FridgeV2.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FridgeV2.Controllers
{
    public class RecipesListController : Controller
    {
        private readonly ApplicationContext _db;
        private readonly UserManager<User> _userManager;

        public RecipesListController(ApplicationContext context, UserManager<User> userManager)
        {
            _db = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.RecipesLists.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecipeList recipeList)
        {
            string currentUserId = _userManager.GetUserId(User);
            recipeList.UserId = currentUserId;

            _db.RecipesLists.Add(recipeList);
            await _db.SaveChangesAsync();
            return Redirect("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Show(int? id)
        {
            if (id == null)
                return NotFound();

            string currentUserId = _userManager.GetUserId(User);
            ViewBag.UserId = currentUserId;

            var recipe = await _db.RecipesLists.FirstOrDefaultAsync(x => x.Id == id);
            if (recipe == null)
                return NotFound();

            var comments = await _db.CommentsUnderRecipes
                                   .Where(c => c.RecipeId == id)
                                   .ToListAsync();

            var howToCook = await _db.HowToCook.FirstOrDefaultAsync(x => x.RecipeId == id);

            var modelRecipesAndComments = new CommentUnderRecipesAndRecipes
            {
                Recipe = recipe,
                Comments = comments,
                HowToCook = howToCook,
                NewComment = new CommentsUnderRecipes
                {
                    RecipeId = recipe.Id
                },
                NewHowToCook = new HowToCook
                { 
                    RecipeId = recipe.Id
                }
            };

            return View(modelRecipesAndComments);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CommentsUnderRecipes newComment)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            newComment.Username = currentUser.FirstName;

            await _db.CommentsUnderRecipes.AddAsync(newComment);
            await _db.SaveChangesAsync();

            return RedirectToAction("Show", new { id = newComment.RecipeId});
        }

        [HttpPost]
        public async Task<IActionResult> HowToCookAdd(HowToCook newHowToCook)
        {
            await _db.HowToCook.AddAsync(newHowToCook);
            await _db.SaveChangesAsync();

            return RedirectToAction("Show", new { id = newHowToCook.RecipeId });
        }
    }
}
