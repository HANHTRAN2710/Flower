using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Flower.Areas.Admin.Helpers;
using Flower.Controllers;
using Flower.Areas.Admin.Services;
using Flower.Models;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Flower.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/product")]

    public class ProductController : Controller
    {
        private IWebHostEnvironment webHostEnvironment;
        private ProductService productService;
        private CategoryService categoryService;

        public ProductController(IWebHostEnvironment _webHostEnvironment, ProductService _productService, CategoryService _categoryService)
        {
            webHostEnvironment = _webHostEnvironment;
            productService = _productService;
            categoryService = _categoryService;
        }
        [Route("viewproduct")]
        public IActionResult Viewproduct()
        {
            ViewBag.products = productService.findAll();
            ViewBag.categories = categoryService.findAll();
            return View();
        }
        [Route("addproduct")]
        public IActionResult Addproduct()
        {
            var product = new Product()
            {
                Created = DateTime.Now,
            };
            ViewBag.categories = categoryService.findAll();
            return View("Addproduct", product);
        }
        [HttpPost]
        [Route("addproduct")]
        public IActionResult Add(Product product, IFormFile photo)
        {
            if (photo != null)
            {
                product.Photo = FileHelper.generateFileName(photo.FileName);

                var path = Path.Combine(webHostEnvironment.WebRootPath, "upload", product.Photo);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    photo.CopyTo(fileStream);
                }
            }
            else
            {
                product.Photo = "noimage.png";
            }
            if (productService.Create(product))
            {
                TempData["msg"] = "Success";
            }
            else
            {
                TempData["msg"] = "Failed";
            }

            return RedirectToAction("Addproduct");
        }
        [Route("SearchByKeyword")]
        public IActionResult SearchByKeyword(string keyword)
        {
            ViewBag.products = productService.searchBykeyword(keyword);
            ViewBag.keyword = keyword;
            return View("Viewproduct");
        }
        [Route("SearchByCategory")]
        public IActionResult SearchByCategory(int categoryId)
        {
            if (categoryId == -1)
            {
                ViewBag.products = productService.findAll();
            }
            else
            {
                ViewBag.products = productService.searchBykeyCategoryId(categoryId);
            }
            ViewBag.categories = categoryService.findAll();
            ViewBag.categoryId = categoryId;

            return View("Viewproduct");
        }

        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var product = productService.findById(id);
            ViewBag.categories = categoryService.findAll();
            return View("EditProduct", product);
        }
        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, Product product, IFormFile photo)
        {
            if (photo == null)
            {
                product.Photo = productService.findByIdNoTracking(id).Photo;
            }
            else
            {
                product.Photo = FileHelper.generateFileName(photo.FileName);

                var path = Path.Combine(webHostEnvironment.WebRootPath, "upload", product.Photo);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    photo.CopyTo(fileStream);
                }
            }
            if (productService.Update(product))
            {
                TempData["msg"] = "Done";
            }
            else
            {
                TempData["msg"] = "Failed";
            }
            return RedirectToAction("Viewproduct");
        }
       // [Route("sumproduct")]
        //public IActionResult Sumproduct()
        //{
            
        //    return RedirectToAction("dashboard", "index");
        //}

    }
    }

