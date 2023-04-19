using Microsoft.AspNetCore.Mvc;

namespace Flower.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/category")]
    public class CategoryController : Controller
    {
       
        [Route("addcategory")]
        public IActionResult Addcategory()
        {
            return View();
        }
    
        [Route("Viewcategory")]
        public IActionResult Viewcategory()
        {
            return View();
        }
    }
}
