using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FridgeV2.Data;
using FridgeV2.Models;
using FridgeV2.ViewModels.Recipes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            var currentUserId = _userManager.GetUserId(User);
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

            var currentUserId = _userManager.GetUserId(User);
            ViewBag.UserId = currentUserId;

            var recipe = await _db.RecipesLists.FirstOrDefaultAsync(x => x.Id == id);
            if (recipe == null)
                return NotFound();

            var comments = await _db.CommentsUnderRecipes
                                    .Where(c => c.RecipeId == id)
                                    .ToListAsync();

            var productInTheRecipe = await _db.ProductInTheRecipes
                                    .Where(c => c.RecipeId == id)
                                    .Select(c => new ProductViewModel 
                                    { 
                                        Name = c.Product.Name,
                                        Amount = c.Amount,
                                        Measure = c.Mesure
                                    })
                                    .ToListAsync();
            ViewBag.CountProduct = productInTheRecipe.Count;

            var productList = new List<Product>();

            var howToCook = await _db.HowToCook.FirstOrDefaultAsync(x => x.RecipeId == id);

            var productsCheckboxes = await _db.Products
                                              .Select(p => new EditProductsInRecipeViewModel.RecipeCheckBoxViewModel
                                               {
                                                   Name = p.Name,
                                                   ProductId = p.Id,
                                                   Selected = false
                                               })
                                              .ToListAsync();

            var modelRecipesAndComments = new CommentUnderRecipesAndRecipesViewModel
            {
                Recipe = recipe,
                Comments = comments,
                HowToCook = howToCook,
                Products = productInTheRecipe,
                NewComment = new CommentsUnderRecipes
                {
                    RecipeId = recipe.Id
                },
                NewHowToCook = new HowToCook
                {
                    RecipeId = recipe.Id
                },
                EditProductsInRecipe = new EditProductsInRecipeViewModel
                {
                    RecipeId = recipe.Id,
                    Checkboxes = productsCheckboxes
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

            return RedirectToAction("Show", new { id = newComment.RecipeId });
        }

        [HttpPost] 
        public async Task<IActionResult> HowToCookAdd(HowToCook newHowToCook)
        {
            await _db.HowToCook.AddAsync(newHowToCook);
            await _db.SaveChangesAsync();

            return RedirectToAction("Show", new { id = newHowToCook.RecipeId });
        }

        [HttpPost]
        public async Task<IActionResult> ProductToRecipeAdd(EditProductsInRecipeViewModel model)
        {
            var currentUserId = _userManager.GetUserId(User);

            var recipe = await _db.RecipesLists.SingleOrDefaultAsync(x => x.Id == model.RecipeId
                                                                   && x.UserId == currentUserId);

            if (recipe == null)
                return NotFound();

            var productInTheRecipe = new List<ProductInTheRecipe>();

            foreach (var item in model.ProductsIds)
            {
                var product = await _db.Products.SingleOrDefaultAsync(x => x.Id == item);

                productInTheRecipe.Add(new ProductInTheRecipe
                {
                    ProductId = item,
                    RecipeId = model.RecipeId,
                    Product = product,
                    Mesure = model.Mesure,
                    Amount = model.Amount
                });
            }


            await _db.ProductInTheRecipes.AddRangeAsync(productInTheRecipe);
            await _db.SaveChangesAsync();

            return RedirectToAction("Show", new { id = model.RecipeId });
        }

        [HttpPost]
        public IActionResult AddProductToShoppingList()
        {
            return View();
        }
    }
}
