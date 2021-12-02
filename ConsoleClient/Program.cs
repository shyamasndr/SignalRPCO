using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
             Console.WriteLine("Press Ctrl + C to close application");
            using (var hubConnection = new HubConnection("https://localhost:44335"))
            {
                IHubProxy ChatHub = hubConnection.CreateHubProxy("ChatHub");
                await hubConnection.Start();
                while (true)
                {
                    Console.WriteLine("enter your message");
                    string message = Console.ReadLine();

                    await ChatHub.Invoke("Send", "titls", "shyam", message);
                    Console.WriteLine();

                }
            }

        }
    }
}
