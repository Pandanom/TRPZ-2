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

namespace SocketServer
{
    class Program
    {

        public static void Main(String[] args)
        {
            Task.Run( () => {
                while (true)
                {
                    var str = Console.ReadLine();
                    Broadcast.BroadcastMessage(str);
                }
            });
            var serv = new Server();
          
        }
        
    }
}
