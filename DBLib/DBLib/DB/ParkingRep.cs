﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLib.DBModel;
using System.Configuration;

namespace DBLib
{
    class ParkingRep : IRepository<Parking>
    {
        private class Context : DbContext
        {
            public Context() : base(@"Data Source =.\MYSQL; Initial Catalog = TRPZ_2; Integrated Security = True")
            { }
            
            public DbSet<Parking> Items { get; set; }
        }

        Context db;

        public ParkingRep()
        {
            db = new Context();
        }

        public IEnumerable<Parking> GetItems()
        {
            return db.Items.ToList();
        }

        public Parking GetItem(int id)
        {
            foreach (var i in db.Items)
                if (i.Id == id)
                    return i;
            return null;
        }

        public async Task Create(Parking item)
        {
            await Task.Run(() => db.Items.Add(item));
        }

        public async Task Update(Parking item)
        {
            for (int i = 0; i < db.Items.ToArray().Length; i++)
            {
                if (db.Items.ToArray()[i].Id == item.Id)
                {
                    db.Items.ToArray()[i] = item;
                    await Task.Run(() => db.Entry(item).State = EntityState.Modified);
                    return;
                }
            }
        }

        public async Task Delete(int id)
        {
            await Task.Run(async () =>
            {
                foreach (var i in db.Items)
                    if (i.Id == id)
                    {
                        using (var c = new SlotRep())
                        {
                            foreach (var j in c.GetItems())
                            {
                                if (j.Parking_Id == id)
                                    await c.Delete(j.Id);
                            }
                            await c.Save();
                        }

                        db.Items.Remove(i);
                        return;
                    }
            }
            );
        }

        public async Task Save()
        {
            await db.SaveChangesAsync();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();

                }



                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ParkingRep() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
