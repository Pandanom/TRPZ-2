﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketServer.DB.DBModel;

namespace SocketServer.DB
{
    class UserCarRep:IRepository<UserCars>
    {
        private class Context : DbContext
        {
            public Context() : base("DefaultConnection")
            { }
  
            public DbSet<UserCars> Items { get; set; }
        }

        Context db;

        public UserCarRep()
        {
            db = new Context();
        }

        public IEnumerable<UserCars> GetItems()
        {
            return db.Items.ToList();
        }

        public UserCars GetItem(int id)
        {
            foreach (var i in db.Items)
                if (i.Id == id)
                    return i;
            return null;
        }

        public async Task Create(UserCars item)
        {
            await Task.Run(() => db.Items.Add(item));
        }

        public async Task Update(UserCars item)
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
                        using (var c = new CarRep())
                        {
                            foreach (var j in c.GetItems())
                            {
                                if (j.Id == i.Car_Id)
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
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}

