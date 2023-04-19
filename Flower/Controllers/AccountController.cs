using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Flower.Models;
using Flower.Services;
namespace Flower.Controllers
{
    [Route("account")]

    public class AccountController : Controller
    {

        private AccountService accountService;
        private HomeService homeService;
        public AccountController(AccountService _accountService, HomeService _homeService)
        {
            accountService = _accountService;
            homeService = _homeService;
        }
        //log in 
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
            if (accountService.Login(username, password))
            {

                HttpContext.Session.SetString("username", username);
                TempData["msg"] = "Success";

                return RedirectToAction("index","Home");

            }
            else
            {
                TempData["msg"] = "Check Please";
                return RedirectToAction("Login");
            }

        }


        //REGISTER
        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            return View("register", new Account());
        }
        [HttpPost]
        [Route("register")]

        public IActionResult Register(Account account)
        {
            //custom validation
            if (account.Username != null && accountService.CheckUsername(account.Username))
            {
                ModelState.AddModelError("Username", "Username da ton tai");
            }

            account.Status = true;
            if (ModelState.IsValid)
            {
                account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
                if (accountService.Create(account))
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    TempData["msg"] = "Failed";
                    return RedirectToAction("register");
                }
            }
            else
            {
                return View("register");
            }

        }
        //welcome
        [Route("welcome")]
        public IActionResult WelcomeAccount()
        {
            ViewBag.products = homeService.FindAll();
            ViewBag.username = HttpContext.Session.GetString("username");
            return View("WelcomeAccount");
        }
        //log out 
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Login");
        }
        //view account
        [Route("viewaccount")]
        public IActionResult Viewaccount()
        {
            ViewBag.accounts = accountService.findAll();
            return View("viewaccount");
        }
        //[Route("sum/{id}")]
        //public IActionResult Sumaccount(int id)
        //{
         
        //    return View("viewaccount");
        //}
    }
}
