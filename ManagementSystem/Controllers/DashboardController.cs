using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
