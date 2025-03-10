using ManagementSystem.Extentions;
using ManagementSystem.Hubs;
using ManagementSystem.Models;
using ManagementSystem.Models.Entities;
using ManagementSystem.Models.Helpers;
using ManagementSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly ManagementContext _context;
        private readonly CookieHelper _cookieHelper;
        private readonly IHubContext<NotificationHub> _hubContext;

        public AppointmentsController(ManagementContext context, CookieHelper cookieHelper, IHubContext<NotificationHub> hubContext)
        {
            _context = context;
            _cookieHelper = cookieHelper;
            _hubContext = hubContext;
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

            var services = _context.Services.ToList();
            ViewBag.Services = services.Select(x => new { x.Id, x.Name }).ToList();

            return View(appointments);
        }

        [CustomAuthorize("Admin")]
        [HttpPost]
        public IActionResult UpdateStatus([FromBody] UpdateAppointmentStatusViewModel model)
        {
            var appointment = _context.Appointments.FirstOrDefault(x => x.Id == model.Id);

            appointment.Status = (Status)model.Status;
            _context.SaveChanges();
            TempData["Success"] = "Güncelleme başarılı";

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
            TempData["Success"] = "Güncelleme başarılı";
            _hubContext.Clients.All.SendAsync("ReceiveAppointmentUpdate");
            return Ok();
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
            TempData["Success"] = "Randevu başarıyla eklendi";

            return RedirectToAction("GetAppointmentsByUserId", "Appointments");
        }

        [CustomAuthorize("User")]
        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var appointment = await _context.Appointments.FirstOrDefaultAsync(x => x.Id == id);

            if (appointment == null)
                return NotFound();

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            await _hubContext.Clients.All.SendAsync("ReceiveAppointmentUpdate");
            return RedirectToAction("GetAppointmentsByUserId"); 
        }

        public List<GetAppointmentViewModel> GetAppointments()
        {
            var appointments = _context.Appointments.Include(x => x.User).Include(x => x.Service).ToList();

            var result = appointments.Select(u => new GetAppointmentViewModel
            {
                Id = u.Id,
                AppointmentDate = u.AppointmentDate,
                ServiceName = u.Service.Name,
                ServiceId = u.Service.Id,
                Status = EnumHelper.GetEnumDescription(u.Status),
                UserName = u.User.UserName
            }).ToList();

            return result;
        }
    }
}
