using Microsoft.AspNetCore.Mvc;
using Flower.Services;
using System.Diagnostics;
namespace Flower.Controllers
{
    [Route("demo")]
    public class DemoController : Controller
    {
        private IConfiguration configuration;
        public DemoController(IConfiguration _configuration)
        {
            configuration = _configuration;
           
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            var values1 = configuration["ConnectionStrings:DefaultConnection"].ToString();
            Debug.WriteLine(values1);
            var values2 = configuration["Logging:LogLevel:Default"].ToString();
            Debug.WriteLine(values2);


            return View();
        }
    }
}
