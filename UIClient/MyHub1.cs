using System;
using System.Web;
using Microsoft.AspNet.SignalR;
namespace SignalRChat
{
    public class ChatHub : Hub
    {
        public void Send(string titlsd, string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(titlsd, name, message);
        }
    }
}