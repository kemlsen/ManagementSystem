using ManagementSystem.Models.Entities;

namespace ManagementSystem.Models.ViewModels
{
    public class UpdateAppointmentViewModel
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int ServiceId { get; set; }
    }
}
