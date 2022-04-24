using System.ComponentModel;

namespace FridgeV2.Models
{
    public class ProductInTheRecipe
    {
        /// <summary>
        /// Идентификатор рецепта
        /// </summary>
        [DisplayName("Идентификатор")]
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор продукта
        /// </summary>
        [DisplayName("Пользователь")]
        public int ProductId { get; set; }

        /// <summary>
        /// Продукт
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Идентификатор рецепта
        /// </summary>
        public int RecipeId { get; set; }
    }
}
