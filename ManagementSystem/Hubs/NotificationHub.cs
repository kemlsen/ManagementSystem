using ManagementSystem.Models.Entities;
using Microsoft.AspNetCore.SignalR;

namespace ManagementSystem.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendUserUpdate()
        {
            await Clients.All.SendAsync("ReceiveUserUpdate");
        }
        public async Task SendAppointmentUpdate()
        {
            await Clients.All.SendAsync("ReceiveAppointmentUpdate");
        }
    }
}
