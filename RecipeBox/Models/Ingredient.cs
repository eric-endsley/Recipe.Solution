using System.Collections.Generic;
using System.Linq;

namespace RecipeBox.Models
{
   public class Ingredient
  {
    public Ingredient()
    {

    }

    public int IngredientId { get; set; }
    public int RecipeId { get; set; }
    public string IngredientName { get; set; }
    public virtual Recipe Recipe { get; set; }
  }
}