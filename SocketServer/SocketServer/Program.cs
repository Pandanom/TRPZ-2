using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using ModelsForWpf;
using System.Threading;
using System.IO;
using SocketWrapper;

namespace SocketServer
{
    class Program
    {
     
        public static void Main(String[] args)
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 8005);
            IPAddress ipAddress2 = IPAddress.Parse("127.254.255.255");
            IPEndPoint remoteEndPoint = new IPEndPoint(ipAddress2, 8005);
            //UDPSocket uDP = new UDPSocket(localEndPoint,remoteEndPoint);
            //UDPSocket.ToDo td = (q, w) => Task.Run(()=>Console.WriteLine(ASCIIEncoding.ASCII.GetString(w)));
            //uDP.StartListening(td);

            Task.Run( () => {
                var str = "Server is running"; //= Console.ReadLine();
                    Broadcast.Bind(remoteEndPoint, remoteEndPoint);
                  var t = Broadcast.BroadcastMessage(str);
                
            });
           
            var serv = new Server(localEndPoint, localEndPoint);
            Task.Delay(-1).Wait();     
                 
        }
        
    }
}
