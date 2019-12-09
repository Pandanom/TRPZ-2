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

namespace TRPZ_2.ViewModel.Serv
{
    static class StartUp
    {
        public static void  Start()
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ConfigurationManager.AppSettings["Ip"].ToString()),
                 int.Parse(ConfigurationManager.AppSettings["Port"].ToString()));
           
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                socket.Connect(ipPoint);
                
                
                StaticData.MyAddress = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);

                byte[] data = new Converter<UserIp>().ObjectToByteArray(
                        new UserIp() { User = StaticData.CurUser, Address = StaticData.MyAddress });
                    var toSend = new byte[data.Length + 1];
                    toSend[0] = 66;
                    for (int i = 0; i < data.Length; i++)
                        toSend[i + 1] = data[i];
                    socket.Send(toSend);
                //});
            }

        }
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        public static void ListenBroadcast()
        {
            Socket listener = new Socket(StaticData.MyAddress.Address.AddressFamily,
                  SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint localEndPoint = new IPEndPoint(StaticData.MyAddress.Address, 8000);
            listener.Bind(localEndPoint);

            listener.Listen(100);
            Task.Run(() => {
               while (true)
               {
                   allDone.Reset();
                   listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                   allDone.WaitOne();
               }
            });

        }

        static void AcceptCallback(IAsyncResult ar)
        {

            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);
            var buff = new byte[1024];
            do
            {
                handler.Receive(buff);
            }
            while (handler.Available > 0);
            MessageBox.Show(new string(ASCIIEncoding.ASCII.GetChars(buff)));
            allDone.Set();
        }


    }
}
