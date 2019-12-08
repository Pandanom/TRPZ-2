﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ModelsForWpf;

namespace TRPZ_2.ViewModel.DB
{
    class SlotRep : IRepository<Slot>
    {
        Socket socket;
        public SlotRep()
        {
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ConfigurationManager.AppSettings["Ip"].ToString()),
                  int.Parse(ConfigurationManager.AppSettings["Port"].ToString()));
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipPoint);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public async Task Create(Slot item)
        {
            //3
            await Task.Run(() => {
                byte[] data = new Converter<ModelsForWpf.Slot>().ObjectToByteArray(item);
                var toSend = new byte[data.Length + 1];
                toSend[0] = 34;
                for (int i = 0; i < data.Length; i++)
                    toSend[i + 1] = data[i];
                socket.Send(toSend);
            });
        }

        public async Task Delete(int id)
        {//5
            await Task.Run(() => {
                var item = new Slot();
                item.Id = id;
                byte[] data = new Converter<ModelsForWpf.Slot>().ObjectToByteArray(item);
                var toSend = new byte[data.Length + 1];
                toSend[0] = 54;
                for (int i = 0; i < data.Length; i++)
                    toSend[i + 1] = data[i];
                socket.Send(toSend);
            });
        }

        public async Task<Slot> GetItem(int id)
        {//2
            return await Task.Run(() => {
                var item = new Slot();
                item.Id = id;
                byte[] data = new Converter<Slot>().ObjectToByteArray(item);
                var toSend = new byte[data.Length + 1];
                toSend[0] = 34;
                for (int i = 0; i < data.Length; i++)
                    toSend[i + 1] = data[i];
                socket.Send(toSend);

                data = new byte[1024];
                do
                {
                    socket.Receive(data, data.Length, 0);

                }
                while (socket.Available > 0);
                try
                {
                    var ret = new Converter<Slot>().ByteArrayToObject(data);
                    return ret;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return null;
            });
        }

        public async Task<IEnumerable<Slot>> GetItems()
        {//1
            return await Task.Run(() => {

                var toSend = new byte[1];
                toSend[0] = 14;

                socket.Send(toSend);

                byte[] data = new byte[10240];
                do
                {
                    socket.Receive(data, data.Length, 0);
                }
                while (socket.Available > 0);
                try
                {
                    var ret = new Converter<List<Slot>>().ByteArrayToObject(data);
                    return ret;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return null;
            });
        }

        public async Task Update(Slot item)
        {//4
            await Task.Run(() => {
                byte[] data = new Converter<ModelsForWpf.Slot>().ObjectToByteArray(item);
                var toSend = new byte[data.Length + 1];
                toSend[0] = 44;
                for (int i = 0; i < data.Length; i++)
                    toSend[i + 1] = data[i];
                socket.Send(toSend);
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
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SlotRep() {
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
