using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ModelsForWpf;
using SocketWrapper;

namespace TRPZ_2.ViewModel.DB
{
    public class CarRep : IRepository<Car>
    {
        TCPSocket socket;
        public CarRep()
        {
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ConfigurationManager.AppSettings["Ip"].ToString()),
                  int.Parse( ConfigurationManager.AppSettings["Port"].ToString()));
                socket = new TCPSocket(StaticData.MyAddress,ipPoint);
                socket.Connect().Wait();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

   
        public async Task Create(Car item)
        {
            //3
            await Task.Run(async () => {
                byte[] data = new Converter<ModelsForWpf.Car>().ObjectToByteArray(item);
                var toSend = new byte[data.Length + 1];
                toSend[0] = 32;
                for (int i = 0; i < data.Length; i++)
                    toSend[i + 1] = data[i];
               await socket.SendData(toSend);
            });
        }

        public async Task Delete(int id)
        {//5
            await Task.Run(async () => {
                var item = new Car();
                item.Id = id;
                byte[] data = new Converter<ModelsForWpf.Car>().ObjectToByteArray(item);
                var toSend = new byte[data.Length + 1];
                toSend[0] = 52;
                for (int i = 0; i < data.Length; i++)
                    toSend[i + 1] = data[i];
                await socket.SendData(toSend);
            });
        }

        public async Task<Car> GetItem(int id)
        {//2
          return  await Task.Run(async () => {
                var item = new Car();
                item.Id = id;
                byte[] data = new Converter<Car>().ObjectToByteArray(item);
                var toSend = new byte[data.Length + 1];
                toSend[0] = 32;
                for (int i = 0; i < data.Length; i++)
                    toSend[i + 1] = data[i];
               await socket.SendData(toSend);

                data = new byte[1024];
               
                   await socket.ReceiveData(data);

               
                try
                {
                    var ret = new Converter<Car>().ByteArrayToObject(data);
                    return ret;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return null;
            });
        }

        public async Task<IEnumerable<Car>> GetItems()
        {//1
            return await Task.Run(async () => {
                
                var toSend = new byte[1];
                toSend[0] = 12;

              await  socket.SendData(toSend);

                byte[] data = new byte[10240];
                
               
                   await socket.ReceiveData(data);
               
                try
                {
                    var ret = new Converter<List<Car>>().ByteArrayToObject(data);
                    return ret;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return null;
            });
        }

        public async Task Update(Car item)
        {//4
            await Task.Run(async () => {
                byte[] data = new Converter<ModelsForWpf.Car>().ObjectToByteArray(item);
                var toSend = new byte[data.Length + 1];
                toSend[0] = 42;
                for (int i = 0; i < data.Length; i++)
                    toSend[i + 1] = data[i];
               await socket.SendData(toSend);
            });
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).

                    socket.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CarRep() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion


    }
}

