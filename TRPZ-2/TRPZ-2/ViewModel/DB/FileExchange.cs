using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TRPZ_2.ViewModel.DB
{
    class FileExchange
    {
        public async Task GetFile(string path)
        {
            //await Task.Run(() =>
            //{
         
            Socket socket;
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ConfigurationManager.AppSettings["Ip"].ToString()),
                int.Parse(ConfigurationManager.AppSettings["Port"].ToString()));
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ipPoint);

            var toSend = new byte[] {66};
                socket.Send(toSend);
            var flag = true;
            int i = 0;
            using (FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                do
                {
                    var data = new byte[16384];
                    do
                    {
                        socket.Receive(data, data.Length, 0);

                    }
                    while (socket.Available > 0);
                    
                    await file.WriteAsync(data, i* 16384, 16384);
                    i++;
                }
                while (i<1000);
            }



            //});
        }
    }
}
