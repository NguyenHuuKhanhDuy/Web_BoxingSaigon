using Microsoft.AspNetCore.Mvc;

namespace Web_Api.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
