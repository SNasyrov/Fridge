using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FridgeV2.Models
{
    /// <summary>
    /// Модель магазина
    /// </summary>
    public class RecipeList
    {
        /// <summary>
        /// Идентификатор рецепта
        /// </summary>
        [DisplayName("Идентификатор")]
        public int Id { get; set; }

        /// <summary>
        /// Название рецепта
        /// </summary>
        [DisplayName("Название рецепта")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Название продукта
        /// </summary>
        [DisplayName("Название продукта")]
        public string Product { get; set; }

        /// <summary>
        /// Количество продукта
        /// </summary>
        [DisplayName("Количество продукта")]
        public int QuantityProduct { get; set; }

        /// <summary>
        /// Идентификатор комментария
        /// </summary>
        public CommentsUnderRecipes CommentsId { get; set; }
    }
}