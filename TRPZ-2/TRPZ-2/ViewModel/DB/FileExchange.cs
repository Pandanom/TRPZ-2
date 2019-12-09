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
          

            var temp = new byte[8];
            do
            {
                socket.Receive(temp, temp.Length, 0);
            }
            while (socket.Available > 0);
            var length = BitConverter.ToInt64(temp, 0);

          
            byte[] last = new byte[length % 16384];
            var data = new byte[16384];
            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                int iter = (int)((length) / 16384);
                for (int i = 0; i < iter; i++)
                {
                    while (socket.Available < 16384)
                       await Task.Delay(10);
                    data = new byte[16384];
                    do
                    {
                        socket.Receive(data, data.Length, 0);

                    }
                    while (socket.Available > 0);

                    await file.WriteAsync(data, 0, 16384);
                    socket.Send(new byte[] { 255 });
                }
                while (socket.Available < length % 16384)
                    await Task.Delay(10);
                do
                {
                    socket.Receive(last, last.Length, 0);

                }
                while (socket.Available > 0);
                await file.WriteAsync(data, 0, last.Length);
            }



            //});
        }
    }
}
