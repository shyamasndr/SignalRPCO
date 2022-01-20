using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.AspNet.SignalR.Configuration;
using Owin;
[assembly: OwinStartup(typeof(SignalRChat.Startup))]
namespace SignalRChat
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            GlobalHost.DependencyResolver.UseSqlServer("Database=VSSDATA_T53;Server=.;Integrated Security=True;");
            GlobalHost.Configuration.DefaultMessageBufferSize = 5;
            app.MapSignalR();
        }
    }
}