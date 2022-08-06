using Microsoft.AspNetCore.Mvc;

namespace Web_Api.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
