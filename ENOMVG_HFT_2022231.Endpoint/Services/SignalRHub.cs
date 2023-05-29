using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace ENOMVG_HFT_2022231.Endpoint.Services
{
    public class SignalRHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Clients.Caller.SendAsync("Connected", Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Clients.Caller.SendAsync("Diconnected", Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
