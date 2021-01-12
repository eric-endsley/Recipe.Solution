using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class Category
  {
    public Category()
    {
      this.Recipes = new HashSet<CategoryRecipe>();
    }

    public int CategoryId { get; set; }
    public string Name { get; set; }

    public ICollection<CategoryRecipe> Recipes { get; }
  }
}