using SocketServer.DB;
using SocketServer.DB.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.Commands
{
    class UserCommand:Command
    {
        public override async Task<byte[]> GetData(byte[] c)
        {

           await Exequte(c);
            return data;
        }


        protected override async Task Create(byte[] item)
        {
            using (var rep = new UserRep())
            {
                var conv = new ModelsForWpf.Converter<ModelsForWpf.User>();
                var us = new User(conv.ByteArrayToObject(item));
                await rep.Create(us);
                await rep.Save();
            }
        }

        protected override async Task Delete(byte[] id)
        {
            using (var rep = new UserRep())
            {
                var conv = new ModelsForWpf.Converter<ModelsForWpf.User>();
                var us = new User(conv.ByteArrayToObject(id));
                await rep.Delete(us.Id);
            }
        }

        protected override byte[] GetItem(byte[] id)
        {
            using (var rep = new UserRep())
            {
                var conv = new ModelsForWpf.Converter<ModelsForWpf.User>();
                var us = new User(conv.ByteArrayToObject(id));
                return conv.ObjectToByteArray(Converter.ToUser(rep.GetItem(us.Id)));
            }
        }

        protected override byte[] GetItems()
        {
            using (var rep = new UserRep())
            {
                var conv = new ModelsForWpf.Converter<List<ModelsForWpf.User>>();
                var lst = new List<ModelsForWpf.User>();
                foreach (var u in rep.GetItems())
                    lst.Add(Converter.ToUser(u));

                return conv.ObjectToByteArray(lst);
            }
        }

        protected override async Task Update(byte[] item)
        {
            using (var rep = new UserRep())
            {
                var conv = new ModelsForWpf.Converter<ModelsForWpf.User>();
                var us = new User(conv.ByteArrayToObject(item));
                await rep.Update(us);
                await rep.Save();
            }
        }
    }
}
