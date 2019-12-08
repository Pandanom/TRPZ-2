using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.Commands
{
    public abstract class Command:ICommand
    {
        public abstract Task<byte[]> GetData(byte[] data);
        protected byte[] data;
        protected async Task Exequte(byte[] inp)
        {
            var num = (byte)(inp[0] / 10);
            var item = new byte[inp.Length -1];
            for (int i = 1; i < inp.Length; i++)
                item[i - 1] = inp[i];
            switch (num)
            {
                case 1 :
                  data =  GetItems();
                    break;
                case 2:
                    data =  GetItem(item);
                    break;
                case 3:
                    await Create(item);
                    break;
                case 4:
                   await Update(item);
                    break;
                case 5:
                   await Delete(item);
                    break;
            }
        }

        protected abstract byte[] GetItems();
        protected abstract byte[] GetItem(byte[] id);
        protected abstract Task Create(byte[] item);
        protected abstract Task Update(byte[] item);
        protected abstract Task Delete(byte[] id);




    }
}
