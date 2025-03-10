using ManagementSystem.Extentions;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.Controllers
{
    public class AdminDashboardController : Controller
    {
        [CustomAuthorize("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
