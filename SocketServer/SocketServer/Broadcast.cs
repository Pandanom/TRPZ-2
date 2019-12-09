using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer
{
   static class Broadcast
    {
        public static void BroadcastMessage(string message)
        {
            foreach (var c in Client.clients)
               c.SendMessage(message);
        }
    }
}
