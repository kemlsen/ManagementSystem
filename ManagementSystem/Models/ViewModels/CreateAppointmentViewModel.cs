using ManagementSystem.Models.Entities;

namespace ManagementSystem.Models.ViewModels
{
    public class CreateAppointmentViewModel
    {
        public DateTime AppointmentDate { get; set; }
        public int ServiceId { get; set; }
        public List<Service> Services { get; set; } 
    }
}
