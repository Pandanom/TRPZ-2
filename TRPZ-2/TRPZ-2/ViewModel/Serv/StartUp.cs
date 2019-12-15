using ModelsForWpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using SocketWrapper;
namespace TRPZ_2.ViewModel.Serv
{
    static class StartUp
    {
        public static async Task Start()
        {
           await Task.Run(() => { 
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ConfigurationManager.AppSettings["Ip"].ToString()),
                 int.Parse(ConfigurationManager.AppSettings["Port"].ToString()));
            StaticData.MyAddress = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
            StaticData.ServerAddress = ipPoint;
            StaticData.IsServerRunning = false;
            ListenBroadcast();
            });
        }
        static UDPSocket.ToDo toDo = RecieveMessage;
        static void ListenBroadcast()
        {
            IPAddress ipAddress2 = IPAddress.Parse("127.254.255.255");
            IPEndPoint remoteEndPoint = new IPEndPoint(ipAddress2, 8005);
            UDPSocket socket = new UDPSocket(StaticData.MyAddress, remoteEndPoint);
            var t = socket.StartListening(toDo);
        }

        static async Task RecieveMessage(UDPSocket s,byte[] data)
        {
           ASCIIEncoding.ASCII.GetString(data);
        }

    }
}
