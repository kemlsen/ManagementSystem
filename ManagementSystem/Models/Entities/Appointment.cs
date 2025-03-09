using System.ComponentModel;

namespace ManagementSystem.Models.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public Status Status { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
    public enum Status
    {
        [Description("Onaylandı")]
        Approved = 1,

        [Description("İptal Edildi")]
        Canceled,

        [Description("Tamamlandı")]
        Completed
    }
}
