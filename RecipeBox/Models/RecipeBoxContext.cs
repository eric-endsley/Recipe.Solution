using System.Diagnostics;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RecipeBox.Models
{
  public class RecipeBoxContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Recipe> Recipes { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public DbSet<CategoryRecipe> CategoryRecipe { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }

    public RecipeBoxContext(DbContextOptions options) : base(options) { }
  }
}