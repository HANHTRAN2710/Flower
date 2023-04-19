using Microsoft.AspNetCore.Mvc;

namespace Flower.Controllers
{
    [Route("contactus")]
    public class ContactUsController : Controller
    {
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
