using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Recipe.Models
{
  public class RecipeContext : DbContext
  {
    public DbSet<Recipe> Recipes { get; set; }
    public virtual DbSet<Category> Categories { get; set; }

    public DbSet<CategoryRecipe> CategoryRecipe { get; set; }

    public RecipeContext(DbContextOptions options) : base(options) { }
  }
}