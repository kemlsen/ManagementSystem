using ManagementSystem.Extentions;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.Controllers
{
    public class UserDashboardController : Controller
    {
        [CustomAuthorize("User")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
