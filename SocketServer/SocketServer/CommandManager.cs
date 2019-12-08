using SocketServer.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SocketServer.DB.DBModel;
using static SocketServer.Server;
using SocketServer.Commands;

namespace SocketServer
{
    class CommandManager
    {
        static Command[] commands = new Command[5];
        public static void SetUp()
        {
            
            commands[0] = new UserCommand();
            commands[1]=new CarCommand();
            commands[2]= new TalonCommand();
            commands[3]= new SlotCommand();
            commands[4]= new ParkingCommand();
        }
        public CommandManager()
        {
         
        }

        public async Task Execute(Socket handler, StateObject state)
        {
           
           await Respond( await GetData(state.buffer),handler);
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
            Server.AsynchronousSocketListener.allDone.Set();
        }


        async Task<byte[]> GetData(byte[] data)
        {
            int first = 0;
              first = data[0] % 10;
             if (first <= 5 )
                try
                {
                    return await commands[first - 1].GetData(data);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
                }
            else
                return null;
            return null;
        }

        async Task Respond(byte[] data,Socket handler)
        {
            
            await Task.Run(() =>
            {
                if (data != null)
                    handler.Send(data);
                else
                    handler.Send(new byte[] { 1 });
               
            }
             );
        }

    }
}
