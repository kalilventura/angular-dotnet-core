using Microsoft.AspNetCore.SignalR;
using RealTimeChat.Interfaces;

namespace RealTimeChat.Hub
{
    public class NotifyHub : Hub<ITypedHubClient>
    {

    }
}
