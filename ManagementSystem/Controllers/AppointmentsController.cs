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
    }
}
