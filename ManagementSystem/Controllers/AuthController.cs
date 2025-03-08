using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.Controllers
{
    public class AuthController : Controller
    {
        private readonly EmployeeContext _context;

        public AuthController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(x => x.UserName == model.UserName);

                switch (user.UserType)
                {
                    case UserType.User:
                        return RedirectToAction("Index", "Home");

                    case UserType.Admin:
                        return RedirectToAction("Appointment", "Home");

                    default:
                        ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı tipi");
                        return View(model);
                }
            }

            return View(model);
        }
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Kullanıcı başarıyla silindi!";
            }
            else
            {
                TempData["ErrorMessage"] = "Kullanıcı bulunamadı!";
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }
    }
}
