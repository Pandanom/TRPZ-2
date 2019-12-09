using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.Commands
{
    class LogIn : ICommand
    {
        public async Task<byte[]> GetData(byte[] data)
        {
            var item = new byte[data.Length - 1];
            for (int i = 1; i < data.Length; i++)
                item[i - 1] = data[i];
            await Task.Run(() => { 
            Client.clients.Add( new Client(item));
            });
            return new byte[] {0};
        }
    }
}
