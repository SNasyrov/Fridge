namespace FridgeV2.Models
{
    public class CommentsUnderRecipes
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Comment { get; set; }

        public int RecipeId { get; set; }
    }
}
