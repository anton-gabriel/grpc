using GreetingServer.Utils.Configuration;
using System;

namespace GreetingServer
{
    internal sealed class Program
    {
        static void Main(string[] args)
        {
            using (Server server = new Server(Configuration.Instance.Settings.ServerData))
            {
                server.CloseServerAction = () => Console.ReadKey();
                server.Start();
            }
        }
    }
}
