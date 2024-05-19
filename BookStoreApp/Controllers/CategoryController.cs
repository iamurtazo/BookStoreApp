using BookStoreApp.Models;
using BookStorreApp.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryRepository _repo;

    public CategoryController(ICategoryRepository repo)
    {
        _repo = repo;
    }

    #region Index
    public IActionResult Index()
    {      
        return View(_repo.GetAll());
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
            _repo.Add(category);
            TempData["success"] = "Category has been added successfully!";
            return RedirectToAction("Index");
        }
        return View();
    }
    #endregion

    #region Edit
    public IActionResult Edit(int? id)
    {
        Category category = _repo.GetById(id);

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
            _repo.Update(category);
            TempData["success"] = "Category has been updated successfully!";
            return RedirectToAction("Index");
        }

        return View();
    }
    #endregion

    #region Details
    public IActionResult Details(int? id)
    {
        Category category = _repo.GetById(id);

        if (category == null)
            return NotFound();

        return View(category);
    }
    #endregion

    #region Delete
    public IActionResult Delete(int? id)
    {
        Category category = _repo.GetById(id);

        if (category == null)
            return NotFound();

        return View(category);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int? id)
    {
        Category category = _repo.GetById(id);

        if(category == null)
            return NotFound();

        _repo.Remove(category);
        TempData["success"] = "Category has been deleted successfully!";
        return RedirectToAction("Index");
    }
    #endregion
}
