using System.Collections.Generic;
using System.ComponentModel;

namespace FridgeV2.ViewModels.Recipes;

public class EditProductsInRecipeViewModel
{
    /// <summary>
    /// Идентификатор рецепта
    /// </summary>
    public int RecipeId { get; set; }

    /// <summary>
    /// Список идентификаторов выбранных продуктов
    /// </summary>
    public List<int> ProductsIds { get; set; } = new List<int>();

    [DisplayName("Продукты")]
    public List<RecipeCheckBoxViewModel> Checkboxes { get; set; }

    /// <summary>
    /// Мера
    /// </summary>
    public string Mesure { get; set; }

    /// <summary>
    /// Кол-во продукта
    /// </summary>
    public string Amount { get; set; }

    public class RecipeCheckBoxViewModel
    {
        public string Name { get; set; }
        public int ProductId { get; set; }
        public bool Selected { get; set; }
    }
}
