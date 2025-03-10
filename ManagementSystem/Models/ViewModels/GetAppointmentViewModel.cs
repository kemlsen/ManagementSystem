using ManagementSystem.Models.Entities;

namespace ManagementSystem.Models.ViewModels
{
    public class GetAppointmentViewModel
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public string ServiceName { get; set; }
        public int ServiceId { get; set; }
        public string UserName { get; set; }
    }
}
