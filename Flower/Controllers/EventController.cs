using Microsoft.AspNetCore.Mvc;

namespace Flower.Controllers
{
    [Route("event")]
    public class EventController : Controller
    {
        [Route("")]
        [Route("eventdecoration")]
        public IActionResult EventDecoration()
        {
            return View();
        }
        [Route("")]
        [Route("yachtdecoration")]
        public IActionResult YachtDecoration()
        {
            return View();
        }
        [Route("")]
        [Route("birthdaydecoration")]
        public IActionResult BirthdayDecoration()
        {
            return View();
        }
        [Route("")]
        [Route("weddingdecoration")]
        public IActionResult WeddingDecoration()
        {
            return View();
        }
    }
}
