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
using SocketWrapper;

namespace TRPZ_2.ViewModel.DB.Services
{
    public  static class FileExchange
    {
        public static async Task GetFile(string path, string filename)
        {
            path += filename;
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ConfigurationManager.AppSettings["Ip"].ToString()),
                   int.Parse(ConfigurationManager.AppSettings["Port"].ToString()));
            using (var socket =  new TCPSocket(StaticData.MyAddress, ipPoint))
            {              
               
                
               await socket.Connect();
                var bytePath = ASCIIEncoding.ASCII.GetBytes(filename.ToArray());
                var toSend = new byte[bytePath.Length + 1];
                toSend[0] = 77;
                for (int i = 0; i < bytePath.Length; i++)
                    toSend[i + 1] = bytePath[i];
                await socket.SendData(toSend);


                var temp = new byte[12];
               
                   await socket.ReceiveData(temp);
              
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

                        data = new byte[packageSize];

                        await socket.ReceiveData(data);


                        await file.WriteAsync(data, 0, packageSize);
                        await socket.SendData(new byte[] { 255 });
                    }

                    var bytes = await socket.ReceiveData(data);

                    await file.WriteAsync(data, 0, bytes);
                }
                
            }
        }


        public static async Task GetWCFFile(string path,string filename)
        {
           await Task.Run(async () =>
            {
                path += filename;
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
