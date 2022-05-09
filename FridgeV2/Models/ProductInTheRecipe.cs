using System.Collections.Generic;
using System.ComponentModel;

namespace FridgeV2.Models
{
    /// <summary>
    /// Модель продукта в рецепте
    /// </summary>
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

        /// <summary>
        /// Мера
        /// </summary>
        public string Mesure { get; set; }

        /// <summary>
        /// Кол-во продукта
        /// </summary>
        public string Amount { get; set; }
    }
}
