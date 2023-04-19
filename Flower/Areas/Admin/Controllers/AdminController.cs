using Flower.Areas.Admin.Services;
using Microsoft.AspNetCore.Mvc;
using Flower.Models;

namespace Flower.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/login")]
    public class AdminController : Controller
    {
       
        [Route("index")]
        public IActionResult Loginadmin()
        {
            return View("Loginadmin");
        }
        [HttpPost]
        [Route("index")]
        public IActionResult Loginadmin(string username, string password)
        {
            if (username == "admin" && password == "123")
            {
                return RedirectToAction("index", "dashboard");
            }
            else
            {
                ViewBag.alert = "pass not true";
                return View("Loginadmin");
            }
;

        }
    }
}
