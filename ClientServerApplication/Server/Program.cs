using Server;
using System.Net;

var socketListener = new SocketListener(Dns.GetHostEntry("server_container"), 4000);
socketListener.StartServer();
