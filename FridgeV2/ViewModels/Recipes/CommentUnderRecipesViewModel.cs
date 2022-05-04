using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FridgeV2.Models;

namespace FridgeV2.ViewModels.Recipes
{
    public class CommentUnderRecipesAndRecipesViewModel
    {
        public RecipeList Recipe { get; set; }

        [DisplayFormat(NullDisplayText = "Пока отзывов нет!")]
        public List<CommentsUnderRecipes> Comments { get; set; }

        public CommentsUnderRecipes NewComment { get; set; }

        public HowToCook HowToCook { get; set; }

        public HowToCook NewHowToCook { get; set; }

        public List<ProductInTheRecipe> ProductInTheRecipe { get; set; }

        public EditProductsInRecipeViewModel EditProductsInRecipe { get; set; }

        public ShowProductViewModel ShowProduct { get; set; }
    }
}
