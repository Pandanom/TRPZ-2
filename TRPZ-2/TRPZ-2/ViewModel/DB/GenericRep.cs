using ModelsForWpf;
using SocketWrapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TRPZ_2.ViewModel.DB
{
    class GenericRep<T> : IRepository<T> where T : BDMember
    {
        TCPSocket socket;
        byte first;

      
        public GenericRep()
        {
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ConfigurationManager.AppSettings["Ip"].ToString()),
                  int.Parse(ConfigurationManager.AppSettings["Port"].ToString()));
                socket = new TCPSocket(StaticData.MyAddress, ipPoint);
                socket.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            switch (typeof(T).Name)
            {
                case "Car":
                    first = 2;
                    break;
                case "User":
                    first = 1;
                    break;
                case "Parking":
                    first =5 ;
                    break;
                case "Slot":
                    first =4 ;
                    break;
                case "Talon":
                    first = 3;
                    break;
               
            }


        }

        public async Task Create(T item)
        {
            //3
            await Task.Run(async () => {
                byte[] data = new Converter<T>().ObjectToByteArray(item);
                var toSend = new byte[data.Length + 1];
                toSend[0] = (byte)(first + 30);
                for (int i = 0; i < data.Length; i++)
                    toSend[i + 1] = data[i];
                await socket.SendData(toSend);
            });
        }

        public async Task Delete(int id)
        {//5
            await Task.Run(async () => {
                var item = new BDMember();
                item.Id = id;
                byte[] data = new Converter<T>().ObjectToByteArray((T)item);
                var toSend = new byte[data.Length + 1];
                toSend[0] = (byte)(first + 50);
                for (int i = 0; i < data.Length; i++)
                    toSend[i + 1] = data[i];
                await socket.SendData(toSend);
            });
        }

        public async Task<T> GetItem(int id)
        {//2
            return await Task.Run(async () => {
                var item = new BDMember();
                item.Id = id;
                byte[] data = new Converter<T>().ObjectToByteArray((T)item);
                var toSend = new byte[data.Length + 1];
                toSend[0] = (byte)(first + 20);
                for (int i = 0; i < data.Length; i++)
                    toSend[i + 1] = data[i];
                await socket.SendData(toSend);

                data = new byte[1024];

                await socket.ReceiveData(data);


                try
                {
                    var ret = new Converter<T>().ByteArrayToObject(data);
                    return ret;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return null;
            });
        }

        public async Task<IEnumerable<T>> GetItems()
        {//1
            return await Task.Run(async () => {

                var toSend = new byte[1];
                toSend[0] = (byte)(first + 10);

                await socket.SendData(toSend);

                byte[] data = new byte[10240];


                await socket.ReceiveData(data);

                try
                {
                    var ret = new Converter<List<T>>().ByteArrayToObject(data);
                    return ret;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return null;
            });
        }

        public async Task Update(T item)
        {//4
            await Task.Run(async () => {
                byte[] data = new Converter<T>().ObjectToByteArray(item);
                var toSend = new byte[data.Length + 1];
                toSend[0] = (byte)(first + 40);
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
