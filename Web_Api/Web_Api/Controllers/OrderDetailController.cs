using Microsoft.AspNetCore.Mvc;

namespace Web_Api.Controllers
{
    public class OrderDetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
