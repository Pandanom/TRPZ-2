using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SocketWrapper;
namespace SocketServer
{
   static class Broadcast
    {
     static UDPSocket socket;
        public static void Bind(IPEndPoint localEndPoint, IPEndPoint remoteEndPoint)
        {
            socket = new UDPSocket(localEndPoint, remoteEndPoint);
        }
        public static async Task BroadcastMessage(string message)
        {
            while (true)
            {
                await socket.SendData(ASCIIEncoding.ASCII.GetBytes(message));
                await Task.Delay(100);
            }
        }
    }
}
