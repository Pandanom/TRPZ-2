using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketWrapper
{
    public class TCPSocket:IDisposable
    {
        Socket socket;
        bool listenFlag = true;
        public delegate Task ToDo(TCPSocket handler);
        IPEndPoint localEndPoint, remoteEndPoint;
        public TCPSocket(IPEndPoint localEndPoint, IPEndPoint remoteEndPoint)
        {
            this.localEndPoint = localEndPoint;
            this.remoteEndPoint = remoteEndPoint;
            this.socket = new Socket(localEndPoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);        
        }

        public TCPSocket(Socket s)
        {
            this.socket = s;
        }

        public void StopListening()
        {
            listenFlag = false;
            socket.Disconnect(true);
        }
        public void ContinueListening()
        {
            listenFlag = true;            
        }

        public async Task StartListening(ToDo toDo)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            if (listenFlag)
                await Task.Run(async () =>
                {
                   
                    socket.Bind(localEndPoint);
                    socket.Listen(100);
                    while (true)
                    {

                        Console.WriteLine("Waiting for connection...");
                        var handler = await Task.Factory.FromAsync(socket.BeginAccept, socket.EndAccept, null);
                        Console.WriteLine("Connection created with " + handler.RemoteEndPoint);
                        watch.Reset();
                        watch.Start();
                        await toDo(new TCPSocket(handler));
                        watch.Stop();
                        Console.WriteLine("Connection ended, connection time :" +watch.ElapsedMilliseconds+"ms");
                        if (!listenFlag)
                            return;
                    }
               });
        }

        public async Task Connect()
        {
            await Task.Factory.FromAsync(
           (c, s) => socket.BeginConnect(remoteEndPoint, c, s),
           socket.EndConnect, null);
        }
        public async Task<int> ReceiveData(byte[] buff)
        {
            if (socket.Connected)
                return await Task.Factory.FromAsync(
                    (c, s) => { return socket.BeginReceive(buff, 0, buff.Length, 0, c, s); },
                    socket.EndReceive, null);
            else
                return -1;
        }

        public async Task<int> SendData(byte[] data)
        {
            if(socket.Connected)
          return await Task.Factory.FromAsync(
              (c, s) => socket.BeginSend(data, 0, data.Length, 0, c, s), 
              socket.EndSend, null);
            return -1;
        }

        public void Dispose()
        {
            socket.Disconnect(false);
            socket.Dispose();
        }

    }
}
