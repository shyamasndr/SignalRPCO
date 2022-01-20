using System;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
namespace SignalRChat
{
    public class ChatHub : Hub
    {

        public void Send(string dealid, string message)
        {
          
            base.Clients.Group(dealid).broadcastMessage($"Message: {message} sent from {Environment.MachineName}");
        }

        public Task SubscribeToDealAlert(string dealid)
        {
            return base.Groups.Add(base.Context.ConnectionId, dealid);
        }

        public Task UnbscribeToDealAlert(string dealid)
        {
            return base.Groups.Remove(base.Context.ConnectionId, dealid);
        }
    }
}