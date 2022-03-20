
using Client;
using System.Net;


Console.WriteLine("Hello from SocketClient");
var socketClient = new SocketClient(Dns.GetHostEntry("localhost"), 4000);
await socketClient.StartClient();