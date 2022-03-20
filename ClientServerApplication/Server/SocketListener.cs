using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public class SocketListener
    {
        private readonly IPHostEntry _host;
        private readonly int _port;

        public SocketListener(IPHostEntry host, int port)
        {
            _host = host;
            _port = port;
        }
        public void StartServer()
        {
            // Get Host IP Address that is used to establish a connection
            IPAddress ipAddress = _host.AddressList[0];
            //Console.WriteLine($"listening on {ipAddress.MapToIPv4()}");

            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, _port);
            try
            {
                // Create a Socket that will use Tcp protocol
                Socket socketListener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                // A Socket must be associated with an endpoint using the Bind method
                socketListener.Bind(ipEndPoint);

                // Specify how many requests a Socket can listen before it gives Server busy response.
                // We will listen 10 requests at a time
                socketListener.Listen(10);

                Console.WriteLine("Waiting for a connection...");
                Socket handler = socketListener.Accept();

                // Incoming data from the client.
                string data = null;
                byte[] bytes = null;
                while (true)
                {
                    bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    Console.WriteLine($"{data}");

                    if (data.IndexOf("*") > -1)
                    {
                        break;
                    }
                }
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
            }

            Console.WriteLine("\n Terminated Socket Listener...");
        }
    }
}
