using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Recipe.Models;

namespace RecipeBox.Controllers
{
  public class RecipesController : Controller
  {
    private readonly RecipeContext _db;

    public RecipesController(RecipeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Recipe> recipeList = _db.Recipes.ToList();
      // recipeList.Sort((x, y) => string.Compare(x.TODO, y.TODO));
      return View(recipeList);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Recipe recipe)
    {
      _db.Recipes.Add(recipe);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisRecipe = _db.Recipes
          .Include(recipe => recipe.Categories)
          .ThenInclude(join => join.Category)
          .FirstOrDefault(recipe => recipe.RecipeId == id);
      return View(thisRecipe);
    }

    public ActionResult AddCategory(int id)
    {
      var thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
      ViewBag.CategoryId = new SelectList(_db.Categorys, "CategoryId", "CategoryName");
      return View(thisRecipe);
    }

    [HttpPost]
    public ActionResult AddCategory
    (Recipe recipe, int CategoryId)
    {
      if (CategoryId != 0)
      {
        var returnedJoin = _db.RecipeCategory
            .Any(join => join.CategoryId == CategoryId && join.RecipeId == recipe.RecipeId);
        if (!returnedJoin)
        {
          _db.RecipeCategory.Add(new RecipeCategory() { CategoryId = CategoryId, RecipeId = Recipe.RecipeId });
        }
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = recipe.RecipeId });
    }
  }
}