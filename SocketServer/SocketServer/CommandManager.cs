using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketServer.Commands;
using System.IO;
using SocketWrapper;

namespace SocketServer
{
    class CommandManager
    {
        static ICommand[] commands = new ICommand[5];
        TCPSocket handler;
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

        public async Task Execute(TCPSocket h)
        {
            this.handler = h;
            var buff = new byte[1024];
           await handler.ReceiveData(buff);
           await Respond( await GetData(buff));        
            handler.Dispose();

        }


        async Task<byte[]> GetData(byte[] data)
        {
            int first = 0;
            first = data[0] % 10;
            if (first <= 5)
                return await commands[first - 1].GetData(data);          
            else if (first == 7)
            {
                
                await Task.Run(async () =>
                {
                    var path = new string(ASCIIEncoding.ASCII.GetChars(data, 1, data.Length - 1));
                    var cleaned = path.Replace("\0", string.Empty);
                    Console.WriteLine(cleaned);
                    if (File.Exists(cleaned))
                        using (FileStream file = new FileStream(cleaned, FileMode.Open, FileAccess.ReadWrite))
                        {
                            //max 65535 
                            int packageSize = 16384 * 4;
                            byte[] buff = new byte[packageSize];

                            var info = new byte[12];
                            var arr1 = BitConverter.GetBytes(file.Length);
                            var arr2 = BitConverter.GetBytes(packageSize);
                            for (int i = 0; i < 8; i++)
                                info[i] = arr1[i];
                            for (int i = 8; i < 12; i++)
                                info[i] = arr2[i - 8];

                            await handler.SendData(info);
                            long persent = 0;
                            int iter = (int)((file.Length) / packageSize);
                            for (int i = 0; i < iter; i++)
                            {
                                await file.ReadAsync(buff, 0, packageSize);
                                if ((int)((file.Position * 100) / file.Length) > persent)
                                {
                                    persent = (file.Position * 100) / file.Length;
                                    Console.WriteLine(file.Position / 1024 + "kb " + persent + "% done");
                                }
                                await handler.SendData(buff);

                               
                                await handler.ReceiveData(new byte[10]);
                            }

                            int bytes = await file.ReadAsync(buff, 0, packageSize);
                            
                            await handler.SendData(buff.Take(bytes).ToArray());

                            Console.WriteLine(file.Position / 1024 + "kb " + ++persent + "% done");
                        }
                    else
                    {
                       await handler.SendData(BitConverter.GetBytes((long)0));
                    }
                });
                return null;
            }
            else
                return null;

          
        }






        async Task Respond(byte[] data)
        {
            if (data != null)
                Console.WriteLine(await handler.SendData(data) + "Bytes responded");
            else
               await handler.SendData(new byte[] { 1 });

        }

    }
}
