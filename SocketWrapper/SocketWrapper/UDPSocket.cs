using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketWrapper
{
   public class UDPSocket:IDisposable
    {
        
        Socket socket;   
        bool listenFlag = true;
        public delegate Task ToDo(UDPSocket handler,byte[] data);
        IPEndPoint localEndPoint, remoteEndPoint;
        public UDPSocket(IPEndPoint localEndPoint, IPEndPoint remoteEndPoint)
        {
            this.localEndPoint = localEndPoint;
            this.remoteEndPoint = remoteEndPoint;
            this.socket = new Socket(localEndPoint.Address.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
     
        }
        

        public async Task StartListening(ToDo toDo)
        {
            if (listenFlag)
                await Task.Run(async () =>
                {
                    socket.Bind(remoteEndPoint);                  
                    EndPoint remoteIp = new IPEndPoint(IPAddress.Any, 0);
                    byte[] data = new byte[256];
                    while (true)
                    {
                        var q = await Task.Factory.FromAsync(
                            (c,s)=>socket.BeginReceiveFrom(data,0,data.Length, 0, ref remoteIp,c,s),
                           (ar)=>socket.EndReceiveFrom(ar,ref remoteIp), null);
                        
                        await toDo(this, data);

                    }
                });
        }

        public async Task<int> SendData(byte[] data)
        {
           return await Task.Factory.FromAsync(
                (c, s) => socket.BeginSendTo(data, 0, data.Length, 0, remoteEndPoint, c, s),
                socket.EndSendTo, null);
        }

        public void Dispose()
        {
            socket.Disconnect(false);
            socket.Dispose();
          
        }
    }
}
