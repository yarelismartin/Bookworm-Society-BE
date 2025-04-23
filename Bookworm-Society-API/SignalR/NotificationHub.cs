using Microsoft.AspNetCore.SignalR;

namespace Bookworm_Society_API.SignalR
{
    public sealed class NotificationHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("ReceivedMessage", $"{Context.ConnectionId} has joined");
        }
    }
}
