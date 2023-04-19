using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Flower.Areas.Admin.Models;

namespace Flower.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/account")]
    public class AccountController : Controller
    {

       [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(string username, string password)
        {
            if (username == "aaa" && password == "123")
            {
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.alert = "Please check ";
                return View("Login");
            }
        }





        //REGISTER
        [Route("")]
        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            var emloyee = new Emloyee();
            return View("Register", emloyee);
        }
        [HttpPost]
        [Route("register")]

        public IActionResult Register(Emloyee emloyee)
        {
            //custom validation
            if (emloyee.Username != null && emloyee.Username == "abc")
            {
                ModelState.AddModelError("Username", "Usename da ton tai");
            }
            //
            if (ModelState.IsValid)
            {
                Debug.WriteLine("username:" + emloyee.Username);
                return View("Login");

            }
            else
            {
                return View("Register");
            }

        }
    }
}
