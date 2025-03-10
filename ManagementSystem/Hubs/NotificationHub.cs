using ManagementSystem.Models.Entities;
using Microsoft.AspNetCore.SignalR;

namespace ManagementSystem.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendUserUpdate(User updatedUser)
        {
            await Clients.All.SendAsync("ReceiveUserUpdate", updatedUser);
        }
    }
}
