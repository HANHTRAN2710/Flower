using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Flower.Services;
using Flower.Areas.Admin.Services;
using Microsoft.EntityFrameworkCore;
using Flower.Models;
using PagedList.Core;

namespace Flower.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private IConfiguration configuration;
        private HomeService homeService;

        public HomeController(IConfiguration _configuration, HomeService _homeService)
        {
            configuration = _configuration;
           homeService = _homeService;

        }
        [Route("~/")]
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.products = homeService.FindAll();
            return View();
        }

        [Route("details/{id}")]
        public IActionResult Details(int id)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            ViewBag.product =homeService.Findid(id);
            return View("Details");
        }

        [HttpGet]
        [Route("SearchByKeyword")]
        public IActionResult SearchByKeyword(string keyword)
        {
            ViewBag.products = homeService.searchBykeyword(keyword);
            ViewBag.keyword = keyword;
            return View("Index");
        }
        //[Route("phantrang")]
        //public IActionResult Index3(int page = 1, int pageSize = 2)
        //{
        //    PagedList<Product> pagedList = new PagedList<Product>(hom.findAll().AsQueryable(), page, pageSize);
        //    return View("Index3", pagedList);
        //}

    }
}
