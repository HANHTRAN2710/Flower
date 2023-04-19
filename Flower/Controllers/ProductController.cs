using Microsoft.AspNetCore.Mvc;

namespace Flower.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        [Route("")]
        [Route("birthday")]
        public IActionResult Birthday()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            return View();
        }
        [Route("")]
        [Route("grandopen")]
        public IActionResult GrandOpen()
        {
            return View();
        }
        [Route("")]
        [Route("design")]
        public IActionResult Design()
        {
            return View();
        }
        [Route("")]
        [Route("fresh")]
        public IActionResult Fresh()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            return View();
        }
    }
}
