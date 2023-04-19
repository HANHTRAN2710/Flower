using Microsoft.AspNetCore.Mvc;

namespace Flower.Controllers
{
    [Route("about")]
    public class AboutController : Controller
    {
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
