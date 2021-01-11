using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class Recipe
  {
    public Recipe()
    {
      this.Categories = new HashSet<CategoryRecipe>();
    }

    public int RecipeId { get; set; }
    public string Name { get; set; }

    public ICollection<CategoryRecipe> Categories { get; }
  }

}