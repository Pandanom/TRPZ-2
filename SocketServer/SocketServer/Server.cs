using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using ModelsForWpf;
using System.Threading;

namespace SocketServer
{
    class Server
    {
        public Server()
        {
            var listener = new AsynchronousSocketListener();
      
        }

        public  class StateObject
        {
            // Client  socket.  
            public  Socket workSocket = null;
            // Size of receive buffer.  
            public const int BufferSize = 1024;
            // Receive buffer.  
            public  byte[] buffer = new byte[BufferSize];
       
        }
        

        public class AsynchronousSocketListener
        {
           
            public static ManualResetEvent allDone = new ManualResetEvent(false);

            public AsynchronousSocketListener()
            {
                StartListening();
            }

            public static void StartListening()
            {
                // Establish the local endpoint for the socket.  
                // The DNS name of the computer  
                // running the listener is "host.contoso.com".  
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");//ipHostInfo.AddressList[0];


                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 8005);

                // Create a TCP/IP socket.  
                Socket listener = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Bind the socket to the local endpoint and listen for incoming connections.  
                try
                {
                    listener.Bind(localEndPoint);
                    listener.Listen(100);

                    while (true)
                    {
                        // Set the event to nonsignaled state.  
                        allDone.Reset();

                        // Start an asynchronous socket to listen for connections.  
                        Console.WriteLine("Waiting for a connection...");
                        listener.BeginAccept(
                            new AsyncCallback(AcceptCallback),
                            listener);

                        // Wait until a connection is made before continuing.  
                        allDone.WaitOne();
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                Console.WriteLine("\nPress ENTER to continue...");
                Console.Read();

            }
           static StateObject state;
            public static void AcceptCallback(IAsyncResult ar)
            {
                
                Socket listener = (Socket)ar.AsyncState;
                Socket handler = listener.EndAccept(ar);
                
               state = new StateObject();
                state.workSocket = handler;
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                   CallBack, state);

            }

            static public async void CallBack(IAsyncResult ar)
            {
                await new CommandManager().Execute(state.workSocket, state);
            }
           
        }

    }
}