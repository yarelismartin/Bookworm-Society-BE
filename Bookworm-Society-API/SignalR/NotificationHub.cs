using Microsoft.AspNetCore.SignalR;

namespace Bookworm_Society_API.SignalR
{
    public sealed class NotificationHub : Hub
    {
        // Called by clients to join a book club group
        public async Task JoinBookClubGroup(string bookClubId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, bookClubId);
        }



    }
}
