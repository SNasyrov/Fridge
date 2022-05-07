namespace FridgeV2.Models
{
    /// <summary>
    /// Модель приготовления рецепта
    /// </summary>
    public class HowToCook
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Рецепт
        /// </summary>
        public string Recipe { get; set; }

        /// <summary>
        /// Идентификатор рецепта
        /// </summary>
        public int RecipeId { get; set; }

    }
}
