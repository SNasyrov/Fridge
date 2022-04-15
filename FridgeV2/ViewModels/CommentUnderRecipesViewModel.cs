using FridgeV2.Data;
using FridgeV2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FridgeV2.ViewModels
{
    public class CommentUnderRecipesAndRecipes 
    {
        public IEnumerable<CommentsUnderRecipes> Comments { get; set; }
        public IEnumerable<RecipeList> Recipes { get; set; }
    }
}
