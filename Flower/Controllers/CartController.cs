using Flower.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Flower.Models;
using System.Diagnostics;
using Flower.Paypal;

namespace Flower.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {
        private HomeService homeService;
        private IConfiguration configuration;
        public CartController(HomeService _homeService, IConfiguration _configuration)
        {
            homeService = _homeService;
            configuration = _configuration;
        }
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("cart") != null  && HttpContext.Session.GetString("username")!=null) 
            {
                var cart = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));
                //lamda tinh tong gio hang 
                ViewBag.total = cart.Sum(i => i.Price * i.Quantity);
                ViewBag.cart = cart;
            }
            else
            {
                return RedirectToAction("login", "account");
            }
            ViewBag.postUrl = configuration["PayPal:PostUrl"];
            ViewBag.ReturnUrl = configuration["PayPal:ReturnUrl"];
            ViewBag.Business = configuration["PayPal:Business"];
            return View();
        }
        [Route("paid")]
        public IActionResult Paid(string tx)
        {
            var result = PDTHolder.Success(tx, configuration, Request);
            result.PayerFirstName = ViewBag.payerfirstname;

            result.PayerLastName = ViewBag.payerlastname;
            result.PayerEmail = ViewBag.payeremail;
           
            
            Debug.WriteLine("Transaction Info: ");
            Debug.WriteLine("First Name: " + result.PayerFirstName);
            Debug.WriteLine("PayerLastName: " + result.PayerLastName);
            Debug.WriteLine("PayerEmail: " + result.PayerEmail);
            Debug.WriteLine("InvoiceNumber: " + result.InvoiceNumber);
            //luu hoa don chi tiet

            //huy gio hang

            //gui email bao cho khach hang ve hoa don vua dat
            return View("Paid");
        }

        [Route("buy/{id}")]
        public IActionResult Buy(int id)
        {
            var product = homeService.Find(id);
            if (HttpContext.Session.GetString("cart") == null)
            {
                var cart = new List<Item>();
                cart.Add(new Item
                {
                    ProductName = product.Name,
                    Price = product.Price,
                    Id = product.Id,
                    Photo = product.Photo,
                    Quantity = 1
                });
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
            }
            else
            {
                var cart = JsonConvert.DeserializeObject<List<Item>>
                    (HttpContext.Session.GetString("cart"));
                var index = Exists(id, cart);

                if (index == -1)
                {
                    cart.Add(new Item
                    {
                        ProductName = product.Name,
                        Price = product.Price,
                        Id = product.Id,
                        Photo = product.Photo,
                        Quantity = 1
                    });
                    HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
                }
                else
                {
                    cart[index].Quantity++;
                    HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));

                }

            }

            return RedirectToAction("index");
        }
        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            var cart = JsonConvert.DeserializeObject<List<Item>>
                    (HttpContext.Session.GetString("cart"));
            var index = Exists(id, cart);
            cart.RemoveAt(index);
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
            return RedirectToAction("index");
        }
        //Lay id de tang so luong trong cart 
        private int Exists(int id, List<Item> cart)
        {
            for (var i = 0; i < cart.Count; i++)
            {
                if (cart[i].Id == id)
                {
                    return i;
                }
            }
            return -1;
        }
        [HttpPost]
        [Route("update")]
        public IActionResult Update(int[] quantities)
        {
            //Doc cai gio hang 
            var cart = JsonConvert.DeserializeObject<List<Item>>
                   (HttpContext.Session.GetString("cart"));
            for (int i = 0; i < cart.Count; i++)
            {
                cart[i].Quantity = quantities[i];
            }
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
            return RedirectToAction("index");
        }
        //[Route("")]
        // xac nhan don hang 
        //[Route("xndh")]
        //public IActionResult Xndh()
        //{
        //    if (HttpContext.Session.GetString("username") == null)
        //    {
        //        return RedirectToAction("login", "account");
        //    }
        //    else
        //    {
        //        var cart = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));
        //        //lamda tinh tong gio hang 
        //        ViewBag.total = cart.Sum(i => i.Price * i.Quantity);
        //        ViewBag.cart = cart;
        //        ViewBag.postUrl = configuration["PayPal:PostUrl"];
        //        ViewBag.ReturnUrl = configuration["PayPal:ReturnUrl"];
        //        ViewBag.Business = configuration["PayPal:Business"];
        //        return View("paid");
        //    }
            
        //}
    }
}
