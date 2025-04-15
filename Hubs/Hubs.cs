using Microsoft.AspNetCore.SignalR;

namespace RentalSystem.Hubs
{
    public class Hubs :Hub
    {
        public async Task SendClient()
        {
            await Clients.All.SendAsync("client");
        }

    }
}
