using ManagementSystem.Models;
using ManagementSystem.Models.Entities;
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
            var appointments = await _context.Appointments.Include(x=>x.Service).Include(x => x.User).ToListAsync();
            return View(appointments);
        }

        [HttpPost]
        public IActionResult UpdateStatus([FromBody] Appointment model)
        {
            var appointment = _context.Appointments.FirstOrDefault(x => x.Id == model.Id);
            if (appointment == null)
                return NotFound();

            appointment.Status = model.Status;
            _context.SaveChanges();

            return RedirectToAction("Index", "Appointments");
        }
    }
}
