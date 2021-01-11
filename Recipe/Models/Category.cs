using System.Collections.Generic;

namespace Recipe.Models
{
  public class Category
  {
    public Catgory()
    {
      this.Recipes = new HashSet<CategoryRecipe>();
    }

    public int CategoryId { get; set; }
    public string Name { get; set; }

    public ICollection<CategoryRecipe> Recipes { get; }
  }

}