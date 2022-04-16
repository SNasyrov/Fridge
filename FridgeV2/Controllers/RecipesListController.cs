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
            _db.RecipesLists.Add(recipeList);
            await _db.SaveChangesAsync();
            return Redirect("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Show(int? id)
        {
            if (id == null)
                return NotFound();

            var recipe = await _db.RecipesLists.FirstOrDefaultAsync(x => x.Id == id);
            if (recipe == null)
                return NotFound();

            var comments = await _db.CommentsUnderRecipes
                                   .Where(c => c.RecipeId == id)
                                   .ToListAsync();

            var modelRecipesAndComments = new CommentUnderRecipesAndRecipes
            {
                Recipe = recipe,
                Comments = comments,
                NewComment = new CommentsUnderRecipes
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

        public IActionResult ThanksToAddComments()
        {
            return View();
        }
    }
}
