using Client;
using System.Net;

if (args.Length<1)
{
    while (true)
    {
        Thread.Sleep(3000);
    }
}

Console.WriteLine("Hello from SocketClient");
var socketClient = new SocketClient(Dns.GetHostEntry("server_container"), 4000);
await socketClient.StartClient();