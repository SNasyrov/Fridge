namespace FridgeV2.Models
{
    /// <summary>
    /// Модель комментариев под рецептом
    /// </summary>
    public class CommentsUnderRecipes
    {
        /// <summary>
        /// Идентификатор комментария
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>        
        public string Username { get; set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Идентификатор рецепта
        /// </summary>
        public int RecipeId { get; set; }
    }
}
