using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.Commands
{
    interface ICommand
    {
        Task<byte[]> GetData(byte[] data);
    }
}
