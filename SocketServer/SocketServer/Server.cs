using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using ModelsForWpf;
using System.Threading;
using SocketWrapper;

namespace SocketServer
{
    class Server
    {
        TCPSocket socket;
        public Server(IPEndPoint localEndPoint, IPEndPoint remoteEndPoint)
        {
            socket = new TCPSocket(localEndPoint, remoteEndPoint);
           var t = Start();
            
        }
        
        async Task Start()
        {
            try
            {
                TCPSocket.ToDo t = new CommandManager().Execute;
                await socket.StartListening(t);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
            }
        }

    }
}