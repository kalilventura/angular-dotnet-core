using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealTimeChat.Hub;
using RealTimeChat.Interfaces;
using RealTimeChat.Model;
using System;

namespace RealTimeChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private IHubContext<NotifyHub, ITypedHubClient> _hubContext;

        public ChatController(IHubContext<NotifyHub, ITypedHubClient> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public string Post([FromBody] Message message)
        {
            string returnMessage;
            try
            {
                _hubContext.Clients.All.BroadcastMessage(message.Type, message.Payload);
                returnMessage = "Success";
            }
            catch (Exception ex)
            {
                returnMessage = ex.Message.ToString();
            }

            return returnMessage;
        }
    }
}