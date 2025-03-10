using ManagementSystem.Extentions;
using ManagementSystem.Models;
using ManagementSystem.Models.Entities;
using ManagementSystem.Models.Helpers;
using ManagementSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly ManagementContext _context;
        private readonly CookieHelper _cookieHelper;

        public AppointmentsController(ManagementContext context, CookieHelper cookieHelper)
        {
            _context = context;
            _cookieHelper = cookieHelper;
        }

        [CustomAuthorize("Admin")]
        public async Task<IActionResult> Index()
        {
            var appointments = await _context.Appointments.Include(x => x.Service).Include(x => x.User).ToListAsync();
            return View(appointments);
        }

        [CustomAuthorize("User")]
        public async Task<IActionResult> GetAppointmentsByUserId()
        {
            var cookieUserId = _cookieHelper.GetCookie("userId");
            var appointments = await _context.Appointments.Include(x => x.Service).Include(x => x.User).Where(x => x.UserId == Convert.ToInt32(cookieUserId)).ToListAsync();
            return View(appointments);
        }

        [CustomAuthorize("Admin")]
        [HttpPost]
        public IActionResult UpdateStatus([FromBody] UpdateAppointmentStatusViewModel model)
        {
            var appointment = _context.Appointments.FirstOrDefault(x => x.Id == model.Id);
            if (appointment == null)
                return NotFound();

            appointment.Status = (Status)model.Status;
            _context.SaveChanges();

            return RedirectToAction("Index", "Appointments");
        }

        [CustomAuthorize("User")]
        [HttpPost]
        public IActionResult UpdateAppointment([FromBody] UpdateAppointmentViewModel model)
        {
            var appointment = _context.Appointments.FirstOrDefault(x => x.Id == model.Id);

            appointment.ServiceId = model.ServiceId;
            appointment.AppointmentDate = model.AppointmentDate;

            _context.SaveChanges();

            return RedirectToAction("Index", "Appointments");
        }

        [CustomAuthorize("User")]
        [HttpGet]
        public IActionResult CreateAppointment()
        {
            var services = _context.Services.ToList();
            ViewBag.Services = services.Select(x => new { x.Id, x.Name }).ToList();
            return View();
        }


        [CustomAuthorize("User")]
        [HttpPost]
        public IActionResult CreateAppointment(CreateAppointmentViewModel model)
        {
            var userId = _cookieHelper.GetCookie("userId");
            var appointment = new Appointment
            {
                ServiceId = model.ServiceId,
                AppointmentDate = model.AppointmentDate,
                UserId = Convert.ToInt32(userId),
                Status = Status.Approved,
            };

            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            return RedirectToAction("GetAppointmentsByUserId", "Appointments");
        }
    }
}
