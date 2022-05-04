using System.Collections.Generic;
using System.ComponentModel;

namespace FridgeV2.ViewModels.Recipes;

public class ShowProductViewModel
{
    public List<Product> Products { get; set; } = new List<Product>();

    public class Product
    {
        public string Name { get; set; }
    }
}