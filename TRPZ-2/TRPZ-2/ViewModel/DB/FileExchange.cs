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

            int packageSize = 16384;          
            var data = new byte[packageSize];
            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                int iter = (int)((length) / packageSize);
                for (int i = 0; i < iter; i++)
                {
                    while (socket.Available < packageSize)
                       await Task.Delay(1);
                    data = new byte[packageSize];
                    do
                    {
                        socket.Receive(data, data.Length, 0);

                    }
                    while (socket.Available > 0);

                    await file.WriteAsync(data, 0, packageSize);
                    socket.Send(new byte[] { 255 });
                }
                while (socket.Available < 1)
                    await Task.Delay(1);
                int bytes = 0;
                do
                {
                    bytes =  socket.Receive(data, data.Length, 0);

                }
                while (socket.Available > 0);                
                await file.WriteAsync(data, 0, bytes);
            }



            //});
        }
    }
}
