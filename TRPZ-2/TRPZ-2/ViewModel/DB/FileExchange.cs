using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TRPZ_2.ViewModel.DB
{
    static class FileExchange
    {
        public static async Task GetFile(string path, string filename)
        {
           
            using (var socket =  new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {              
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ConfigurationManager.AppSettings["Ip"].ToString()),
                    int.Parse(ConfigurationManager.AppSettings["Port"].ToString()));
                
                socket.Connect(ipPoint);
                var bytePath = ASCIIEncoding.ASCII.GetBytes(filename.ToArray());
                var toSend = new byte[bytePath.Length + 1];
                toSend[0] = 77;
                for (int i = 0; i < bytePath.Length; i++)
                    toSend[i + 1] = bytePath[i];
                socket.Send(toSend);


                var temp = new byte[12];
                do
                {
                    socket.Receive(temp, temp.Length, 0);
                }
                while (socket.Available > 0);
                var length = BitConverter.ToInt64(temp, 0);
                if (length == 0)
                {
                    MessageBox.Show("File doesn't exist");
                    return;
                }
                int packageSize = BitConverter.ToInt32(temp, 8);
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
                        bytes = socket.Receive(data, data.Length, 0);

                    }
                    while (socket.Available > 0);
                    await file.WriteAsync(data, 0, bytes);
                }
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
        }


        public static async Task GetWCFFile(string path,string filename)
        {
           await Task.Run(async () =>
            {
                var ser = new FileService.DataServiceClient();
                var id = ser.GetFileFSId(filename);
                using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    while (true)
                    {
                        var data = await ser.GetFilePartAsync(id);
                        if (data == null)
                            break;
                        await file.WriteAsync(data, 0, data.Length);


                    }
                }
            });
        
        }


    }
}
