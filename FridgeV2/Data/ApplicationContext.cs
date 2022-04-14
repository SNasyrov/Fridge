using FridgeV2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FridgeV2.Data
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<ProductInFridge> ProductsInFridge { get; set; }

        public DbSet<Shop> Shops { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ShoppingListItem> ShoppingListItems { get; set; }

        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<RecipeList> RecipesLists { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }
    }
}

