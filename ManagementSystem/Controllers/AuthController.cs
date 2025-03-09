using ManagementSystem.Models;
using ManagementSystem.Models.Entities;
using ManagementSystem.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Controllers
{
    public class AuthController : Controller
    {
        private readonly ManagementContext _context;

        public AuthController(ManagementContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(x => x.UserName == model.UserName);

                if (user == null || !HashingHelper.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
                {
                    ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı");
                    return View(model);
                }
                switch (user.UserType)
                {
                    case UserType.User:
                        return RedirectToAction("Index", "UserDashboard");

                    case UserType.Admin:
                        return RedirectToAction("Index", "AdminDashboard");
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (_context.Users.Any(u => u.UserName == model.UserName))
            {
                ModelState.AddModelError("UserName", "Bu kullanıcı adı zaten alınmış.");
                return View(model);
            }
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(model.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                UserType = model.UserType,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Auth");
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.UserTypes = Enum.GetValues(typeof(UserType))
                                    .Cast<UserType>()
                                    .Select(e => new SelectListItem
                                    {
                                        Value = e.ToString(),
                                        Text = e.ToString()
                                    }).ToList();

            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> UpdateUser([FromBody]UpdateUserViewModel model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == model.Id);

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.UserName = model.UserName;
            user.UserType = (UserType)model.UserType;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Auth");
        }

        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }
        
        [HttpPost]
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
