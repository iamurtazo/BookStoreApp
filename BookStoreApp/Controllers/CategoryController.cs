using BookStoreApp.DataAccess;
using BookStoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _context;

    public CategoryController(ApplicationDbContext context)
    {
        _context = context;
    }

    #region Index
    public IActionResult Index()
    {
        List<Category> categories = _context.Categories.ToList();
        return View(categories);
    }
    #endregion

    #region Create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category category) 
    {
        if (ModelState.IsValid)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            TempData["success"] = "Category has been added successfully!";
            return RedirectToAction("Index");
        }
        return View();
    }
    #endregion

    #region Edit
    public IActionResult Edit(int? id)
    {
        Category category = _context.Categories.Find(id);

        if (category == null)
            return NotFound();

        return View(category);
    }

    [HttpPost]
    public IActionResult Edit(int id, Category category)
    {
        if(id != category.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            TempData["success"] = "Category has been updated successfully!";
            return RedirectToAction("Index");
        }

        return View();
    }
    #endregion

    #region Details
    public IActionResult Details(int? id)
    {
        Category category = _context.Categories.Find(id);

        if (category == null)
            return NotFound();

        return View(category);
    }
    #endregion

    #region Delete
    public IActionResult Delete(int? id)
    {
        Category category = _context.Categories.Find(id);

        if (category == null)
            return NotFound();

        return View(category);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int? id)
    {
        Category category = _context.Categories.Find(id);

        if(category == null)
            return NotFound();

        _context.Categories.Remove(category);
        _context.SaveChanges();
        TempData["success"] = "Category has been deleted successfully!";
        return RedirectToAction("Index");
    }
    #endregion
}
