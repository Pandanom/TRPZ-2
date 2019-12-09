using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ModelsForWpf;

namespace SocketServer
{
    class Client
    {
        public static List<Client> clients;

        IPEndPoint address;
        User user;
        static Client()
        {
            clients = new List<Client>();
        }
        public Client(byte[] data)
        {
            var c = new Converter<UserIp>().ByteArrayToObject(data);
            address = c.Address;
            user = c.User;
         
        }
        public void SendMessage(string message)
        {
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    socket.Connect(address);
                    socket.Send(ASCIIEncoding.ASCII.GetBytes(message.ToArray()));
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
                }
            }
        }
    }
}
