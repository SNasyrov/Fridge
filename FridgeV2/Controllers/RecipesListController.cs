using FridgeV2.Data;
using FridgeV2.Models;
using FridgeV2.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using FridgeV2.ViewModels;
using System.Collections.Generic;

namespace FridgeV2.Controllers
{
    public class RecipesListController : Controller
    {
        private ApplicationContext db;
        private UserManager<User> UserManager;

        public RecipesListController(ApplicationContext context, UserManager<User> userManager)
        {
            db = context;
            UserManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.RecipesLists.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecipeList recipeList)
        {
            db.RecipesLists.Add(recipeList);
            await db.SaveChangesAsync();
            return Redirect("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Show(int? id)
        {
            if (id != null)
            {
                TempData["recipeList"] = id;
                RecipeList recipeList = await db.RecipesLists.FirstOrDefaultAsync(x => x.Id == id);
                List<CommentsUnderRecipes> comments = await db.CommentsUnderRecipes
                                                             .Where(c => c.RecipeId == id)
                                                             .ToListAsync();
                if (recipeList != null)
                {
                    
                    var modelRecipesAndComments = new CommentUnderRecipesAndRecipes();
                    List<RecipeList> recipe = new List<RecipeList>();
                    recipe.Add(recipeList);
                    if (comments.Count != 0)
                    {
                        modelRecipesAndComments.Comments = comments;
                    }
                    else
                    {
                        modelRecipesAndComments.Comments = null;
                    }
                    modelRecipesAndComments.Recipes = recipe;
                    return View(modelRecipesAndComments);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Show(CommentsUnderRecipes commentsUnderRecipes)
        {
            var CommentsId = 0;
            int ProductId = Convert.ToInt32(TempData["ProductId"]);
            int RecipeId = Convert.ToInt32(TempData["recipeList"]);
            string currentUserId = UserManager.GetUserId(User);

            CommentsId = CommentsId++;

            User user = await db.Users.FirstOrDefaultAsync(x => x.Id == currentUserId);

            commentsUnderRecipes.Username = user.FirstName;
            commentsUnderRecipes.RecipeId = RecipeId;
            commentsUnderRecipes.Id = CommentsId;

            db.CommentsUnderRecipes.Add(commentsUnderRecipes);
            await db.SaveChangesAsync();

            return RedirectToAction("ThanksToAddComments", "RecipesList");
        }

        public IActionResult ThanksToAddComments()
        { 
            return View();
        }
    }
}
