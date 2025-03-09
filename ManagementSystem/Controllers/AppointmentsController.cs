using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.Controllers
{
    public class AppointmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
