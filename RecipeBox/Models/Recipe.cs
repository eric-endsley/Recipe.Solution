using System.Collections.Generic;
using System.Linq;

namespace RecipeBox.Models
{
  public class Recipe
  {
    public Recipe()
    {
      this.Categories = new HashSet<CategoryRecipe>();
      this.Ingredients = new HashSet<Ingredient>();
    }

    public int RecipeId { get; set; }

    public string Name { get; set; }
    public virtual ApplicationUser User { get; set; }

    public virtual ICollection<Ingredient> Ingredients { get; set; }
    public ICollection<CategoryRecipe> Categories { get; }
  }

}