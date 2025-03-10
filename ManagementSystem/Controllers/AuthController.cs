using ManagementSystem.Extentions;
using ManagementSystem.Hubs;
using ManagementSystem.Models;
using ManagementSystem.Models.Entities;
using ManagementSystem.Models.Helpers;
using ManagementSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Controllers
{
    public class AuthController : Controller
    {
        private readonly ManagementContext _context;
        private readonly CookieHelper _cookieHelper;
        private readonly IHubContext<NotificationHub> _hubContext;
        public AuthController(ManagementContext context, CookieHelper cookieHelper, IHubContext<NotificationHub> hubContext)
        {
            _context = context;
            _cookieHelper = cookieHelper;
            _hubContext = hubContext;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(x => x.UserName == model.UserName);

                if (user == null || !HashingHelper.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
                {
                    TempData["Error"] = "Kullanıcı adı veya şifre hatalı!";
                    return View(model);
                }
                _cookieHelper.SetCookie("userId", user.Id.ToString());
                _cookieHelper.SetCookie("role", ((int)user.UserType).ToString());
                TempData["Success"] = "Giriş başarılı";
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

        [CustomAuthorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (_context.Users.Any(u => u.UserName == model.UserName))
            {
                TempData["Error"] = "Bu kullanıcı adı zaten alınmış!";
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
            TempData["Success"] = "Kullanıcı başarıyla eklendi";
            return RedirectToAction("Index", "Auth");
        }

        [CustomAuthorize("Admin")]
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

        [CustomAuthorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserViewModel model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == model.Id);

            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.UserName;
                user.UserType = (UserType)model.UserType;

                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                _hubContext.Clients.All.SendAsync("ReceiveUserUpdate");
                return Ok();
            }
            return NotFound();
        }

        [CustomAuthorize("Admin")]
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        [CustomAuthorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            _context.Users.Remove(user);
            _context.SaveChanges();
            _hubContext.Clients.All.SendAsync("ReceiveUserUpdate");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Logout()
        {
            _cookieHelper.DeleteCookie("userId");
            _cookieHelper.DeleteCookie("role");
            TempData["Success"] = "Çıkış yapıldı";
            return RedirectToAction("Login", "Auth");
        }
        public List<GetUserViewModel> GetUsers()
        {
            var users = _context.Users.ToList();

            var result = users.Select(u => new GetUserViewModel
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.UserName,
                UserType = u.UserType.ToString()
            }).ToList();

            return result;
        }
    }
}
