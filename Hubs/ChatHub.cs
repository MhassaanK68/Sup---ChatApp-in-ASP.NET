using Microsoft.AspNetCore.SignalR;
using Sup_ChatApp.Models;

namespace Sup_ChatApp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessageToAll(MessagePackage msg)
        {
            if (msg.message != "")
            {
                await Clients.Others.SendAsync("ReceiveMessage", msg);
            }
        }

        public async Task SendToSpecific(MessagePackage msg)
        {
            await Clients.Client(Context.ConnectionId).SendAsync("ReceiveMessage", msg);
        }

    }
}
