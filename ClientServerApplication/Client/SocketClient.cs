using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public class SocketClient
    {
        private readonly IPHostEntry _host;
        private readonly int _port;

        public SocketClient(IPHostEntry host, int port)
        {
            _host = host;
            _port = port;
        }

        public async Task StartClient()
        {
            byte[] bytes = new byte[1024];

            try
            {
                // Connect to a Remote server
                // Host IP Address that is used to establish a connection
                IPAddress ipAddress = _host.AddressList[0];
                //Console.WriteLine($"sending on {ipAddress.MapToIPv4()}");

                IPEndPoint remoteEP = new IPEndPoint(ipAddress, _port);

                // Create a TCP/IP  socket.
                Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.
                try
                {
                    // Connect to Remote EndPoint
                    sender.Connect(remoteEP);
                    //Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());

                    // Encode the data string into a byte array.
                    while (true)
                    {
                        var input = Console.ReadKey();
                        //var chinput = Convert.ToChar(input.KeyChar);
                        //var text = chinput.ToString();
                        var text = input.KeyChar;

                        byte[] msg = Encoding.ASCII.GetBytes(text.ToString());
                        int bytesSent = sender.Send(msg);

                        // will terminate the Socket Client if user type *
                        if (text == '*')
                        {
                            break;
                        }
                    }


                    // Release the socket.
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\n Terminated Socket Client...");
        }
    }
}
