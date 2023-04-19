using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Flower.Areas.Admin.Helpers;
using Flower.Controllers;
using Flower.Areas.Admin.Services;

namespace Flower.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/product")]

    public class ProductController : Controller
    {
        private IWebHostEnvironment webHostEnvironment;
        private ProductService productService;
        public ProductController(IWebHostEnvironment _webHostEnvironment)
        {
            webHostEnvironment = _webHostEnvironment;
        }

        [Route("addproduct")]
        public IActionResult Addproduct()
        {
            return View();
        }
      
        [Route("viewproduct")]
        public IActionResult Viewproduct()
        {
            ViewBag.products = productService.findAll();
            return View();
        }
        [HttpPost]
        [Route("upload")]
        public IActionResult Upload(IFormFile file) //ten trung voi input ben view
        {
            Debug.WriteLine("name: " + file.Name);
            Debug.WriteLine("filename: " + file.FileName);
            Debug.WriteLine("length: " + file.Length);
            Debug.WriteLine("type: " + file.ContentType);

            //upload img 
            var path = Path.Combine(webHostEnvironment.WebRootPath, "upload", FileHelper.generateFileName(file.FileName));
            using (var filestream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(filestream);
            }

            return RedirectToAction("addproduct", "product");
        }
        [Route("SearchByKeyword")]
        public IActionResult SearchByKeyword(string keyword)
        {
            ViewBag.products = productService.findByKeyword(keyword);
            ViewBag.keyword = keyword;
            return View("Viewproduct");
        }
    }
}
