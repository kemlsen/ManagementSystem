using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.Controllers
{
    public class UserDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
