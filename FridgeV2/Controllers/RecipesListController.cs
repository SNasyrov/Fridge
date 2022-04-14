using FridgeV2.Data;
using FridgeV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FridgeV2.Controllers
{
    public class RecipesListController : Controller
    {
        private ApplicationContext db;

        public RecipesListController(ApplicationContext context)
        {
            db = context;
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

        public async Task<IActionResult> Show(int? id)
        {
            if (id != null)
            { 
                RecipeList recipeList = await db.RecipesLists.FirstOrDefaultAsync(x => x.Id == id);
                if (recipeList != null)
                {
                    return View(recipeList);
                }
            }

            return NotFound();
        }
    }
}
