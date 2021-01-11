using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using RecipeBox.Models;

namespace RecipeBox.Controllers
{
  public class CategoriesController : Controller
  {
    private readonly RecipeBoxContext _db;

    public CategoriesController(RecipeBoxContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Category> categoryList = _db.Categories.ToList();
      // categoryList.Sort((x, y) => int.Compare(x.Recipes.Count, y.Recipes.Count));
      return View(categoryList);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Category category)
    {
      _db.Categories.Add(category);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisCategory = _db.Categories
        .Include(category => category.Recipes)
        .ThenInclude(join => join.Recipe)
        .FirstOrDefault(category => category.CategoryId == id);
      return View(thisCategory);
    }

    public ActionResult AddRecipe(int id)
    {
      var thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      ViewBag.RecipeId = new SelectList(_db.Recipes, "RecipeId", "Name");
      return View(thisCategory);
    }

    [HttpPost]
    public ActionResult AddRecipe
    (Category category, int RecipeId)
    {
      if (RecipeId != 0)
      {
        var returnedJoin = _db.CategoryRecipe
            .Any(join => join.RecipeId == RecipeId && join.CategoryId == category.CategoryId);
        if (!returnedJoin)
        {
          _db.CategoryRecipe.Add(new CategoryRecipe() { RecipeId = RecipeId, CategoryId = category.CategoryId });
        }
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = category.CategoryId });
    }
  }
}