using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FridgeV2.Models;

namespace FridgeV2.ViewModels.Recipes
{
    public class CommentUnderRecipesAndRecipesViewModel
    {
        public RecipeList Recipe { get; set; }

        /// <summary>
        /// Список отзывов
        /// </summary>
        [DisplayFormat(NullDisplayText = "Пока отзывов нет!")]
        public List<CommentsUnderRecipes> Comments { get; set; }

        /// <summary>
        /// Новый отзыв
        /// </summary>
        public CommentsUnderRecipes NewComment { get; set; }

        /// <summary>
        /// Как приготовить рецепт
        /// </summary>
        public HowToCook HowToCook { get; set; }

        /// <summary>
        /// Добавление инструкции готовки
        /// </summary>
        public HowToCook NewHowToCook { get; set; }

        /// <summary>
        /// Список продуктов в рецепте
        /// </summary>
        public List<ProductInTheRecipe> ProductInTheRecipe { get; set; }

        public EditProductsInRecipeViewModel EditProductsInRecipe { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}
