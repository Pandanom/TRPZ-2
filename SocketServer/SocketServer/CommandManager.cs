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
using System.IO;

namespace SocketServer
{
    class CommandManager
    {
        static ICommand[] commands = new ICommand[5];
        Socket handler;
        static CommandManager()
        {
            commands[0] = new UserCommand();
            commands[1] = new CarCommand();
            commands[2] = new TalonCommand();
            commands[3] = new SlotCommand();
            commands[4] = new ParkingCommand();
        }
        public CommandManager()
        {
         
        }

        public async Task Execute(Socket h, StateObject state)
        {
            this.handler = h;  
           await Respond( await GetData(state.buffer));
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
            else if(first ==6)
            {
           
                await  Task.Run(async () => { 
                using (FileStream file = new FileStream("1.zip", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    int packageSize = 16384;
                    byte[] buff = new byte[packageSize];
                   
                   
                    handler.Send( BitConverter.GetBytes(file.Length));
                    long persent = 0;
                    int iter = (int)((file.Length) / packageSize);
                    for (int i = 0; i < iter; i++)
                    {
                        await file.ReadAsync(buff,0, packageSize);
                        if ((int)((file.Position * 100) / file.Length) > persent)
                        {
                            persent = (file.Position * 100) / file.Length;
                            Console.WriteLine(file.Position/1024+"kb "+ persent + "% done");
                        }
                        handler.Send(buff);

                        while (handler.Available < 1)
                            await Task.Delay(1);
                        handler.Receive(new byte[10]);
                    }

                    int bytes = await file.ReadAsync(buff, 0, packageSize);
                    handler.Send(buff,bytes,0);

                    Console.WriteLine(file.Position / 1024 + "kb " + ++persent + "% done");
                }
                });
                return null;
            }
            else
                return null;

            return null;
        }






        async Task Respond(byte[] data)
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
