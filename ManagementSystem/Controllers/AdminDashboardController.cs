using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.Controllers
{
    public class AdminDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
