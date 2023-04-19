using Flower.Areas.Admin.Helpers;
using Flower.Areas.Admin.Services;
using Flower.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;

namespace Flower.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/category")]
    public class CategoryController : Controller
    {
       private CategoryService categoryService;
        public CategoryController(CategoryService _categoryService)
        {
            categoryService = _categoryService;
        }
        [Route("addcategory")]
        public IActionResult Addcategory()
        {
            ViewBag.categories = categoryService.findAll();

            return View("Addcategory");


        }
        [HttpPost]
        [Route("addcategory")]
        public IActionResult Addcategory(Category category)
        {
            if (categoryService.Create(category))
            {
                TempData["msg"] = "Success";
            }
            else
            {
                TempData["msg"] = "Faild";
            }
            return RedirectToAction("Addcategory");
        }
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var category = categoryService.findById(id);
            ViewBag.categories = categoryService.findAll();
            return View("EditCategory", category);
        }
        
        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, Category category)
        {
           
            if (categoryService.Update(category))
            {
                TempData["msg"] = "Done";
            }
            else
            {
                TempData["msg"] = "Failed";
            }
            return RedirectToAction("Viewcategory");
        }
        [Route("index")]
        public IActionResult Index3()
        {
            ViewBag.categories = categoryService.findAll();

            return View("Index");
        }
        [Route("searchByKeywordPagination")]
        public IActionResult SearchByKeywordPagination(string keyword, int page = 1, int pageSize = 10)
        {
            PagedList<Category> pagedList = new PagedList<Category>(categoryService.searchBykeyword(keyword).AsQueryable(), page, pageSize);
            ViewBag.keyword = keyword;
            return View("index", pagedList);
        }
    }
}
