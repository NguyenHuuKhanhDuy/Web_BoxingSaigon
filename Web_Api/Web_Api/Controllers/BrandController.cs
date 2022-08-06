using Microsoft.AspNetCore.Mvc;

namespace Web_Api.Controllers
{
    public class BrandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
