using Server;
using System.Net;

var socketListener = new SocketListener(Dns.GetHostEntry("localhost"), 4000);
socketListener.StartServer();
