using ManagementSystem.Models;
using ManagementSystem.Models.Entities;
using ManagementSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly ManagementContext _context;

        public AppointmentsController(ManagementContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var appointments = await _context.Appointments.Include(x => x.Service).Include(x => x.User).ToListAsync();
            return View(appointments);
        }

        public async Task<IActionResult> GetAppointmentsByUserId()
        {
            var appointments = await _context.Appointments.Include(x => x.Service).Include(x => x.User).ToListAsync();
            return View(appointments);
        }

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

        [HttpPost]
        public IActionResult UpdateAppointment([FromBody] UpdateAppointmentViewModel model)
        {
            var appointment = _context.Appointments.FirstOrDefault(x => x.Id == model.Id);

            appointment.ServiceId = model.ServiceId;
            appointment.AppointmentDate = model.AppointmentDate;

            _context.SaveChanges();

            return RedirectToAction("Index", "Appointments");
        }

        [HttpGet]
        public IActionResult CreateAppointment()
        {
            var services = _context.Services.ToList();
            var model = new CreateAppointmentViewModel
            {
                Services = services  
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateAppointment(CreateAppointmentViewModel model)
        {
            var appointment = new Appointment
            {
                ServiceId = model.ServiceId,
                AppointmentDate = model.AppointmentDate,
                UserId = 1,
                Status = Status.Approved,
            };

            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            return RedirectToAction("Index", "Appointments");
        }
    }
}
