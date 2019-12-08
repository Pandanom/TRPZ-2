using SocketServer.DB;
using SocketServer.DB.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SocketServer.Commands
{
    class CarCommand : Command
    {
        public override async Task<byte[]> GetData(byte[] c)
        {

            await Exequte(c);
            return data;
        }


        protected override async Task Create(byte[] item)
        {
            using (var uc = new UserCarRep())
            using (var rep = new CarRep())
            {
                var conv = new ModelsForWpf.Converter<ModelsForWpf.Car>();
                var temp = conv.ByteArrayToObject(item);
                var us = new Car(temp);
                await rep.Create(us);
                await rep.Save();
                foreach (var c in rep.GetItems())
                    if (c.RegNum == us.RegNum)
                        await uc.Create(new UserCars(0, temp.Owner.Id, c.Id));
                
            }
        }

        protected override async Task Delete(byte[] id)
        {
            using (var rep = new CarRep())
            {
                var conv = new ModelsForWpf.Converter<ModelsForWpf.Car>();
                var us = new Car(conv.ByteArrayToObject(id));
                await rep.Delete(us.Id);
            }
        }

        protected override byte[] GetItem(byte[] id)
        {
            using (var rep = new CarRep())
            {
                var conv = new ModelsForWpf.Converter<ModelsForWpf.Car>();
                var us = new Car(conv.ByteArrayToObject(id));
                return conv.ObjectToByteArray(Converter.ToCar(rep.GetItem(us.Id)));
            }
        }

        protected override byte[] GetItems()
        {
            using (var rep = new CarRep())
            {
                var conv = new ModelsForWpf.Converter<List<ModelsForWpf.Car>>();
                var lst = new List<ModelsForWpf.Car>();
                foreach (var u in rep.GetItems())
                    lst.Add(Converter.ToCar(u));

                return conv.ObjectToByteArray(lst);
            }
        }

        protected override async Task Update(byte[] item)
        {
            using (var rep = new CarRep())
            {
                var conv = new ModelsForWpf.Converter<ModelsForWpf.Car>();
                var us = new Car(conv.ByteArrayToObject(item));
                await rep.Update(us);
                await rep.Save();
            }
        }
    }
}

