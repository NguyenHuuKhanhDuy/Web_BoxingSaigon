using Microsoft.AspNetCore.Mvc;

namespace Web_Api.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
