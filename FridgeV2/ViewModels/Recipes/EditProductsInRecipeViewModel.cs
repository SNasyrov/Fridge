using System.Collections.Generic;
using System.ComponentModel;

namespace FridgeV2.ViewModels.Recipes;

public class EditProductsInRecipeViewModel
{
    public int RecipeId { get; set; }

    public List<int> ProductsIds { get; set; } = new List<int>();

    [DisplayName("Продукты")]
    public List<RecipeCheckBoxViewModel> Checkboxes { get; set; }

    public class RecipeCheckBoxViewModel
    {
        public string Name { get; set; }
        public int ProductId { get; set; }
        public bool Selected { get; set; }
    }
}
