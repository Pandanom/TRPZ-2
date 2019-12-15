using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLib.DBModel;

namespace DBLib
{
    public class TalonRep : IRepository<Talon>
    {
        private class Context : DbContext
        {
            public Context() : base(@"Data Source=.\MYSQL;Initial Catalog=TRPZ_2;Integrated Security=True")
            { }

            public DbSet<Talon> Items { get; set; }
        }

        Context db;

        public TalonRep()
        {
            db = new Context();
        }

        public IEnumerable<Talon> GetItems()
        {
            return db.Items.ToList();
        }

        public Talon GetItem(int id)
        {
            foreach (var i in db.Items)
                if (i.Id == id)
                    return i;
            return null;
        }

        public async Task Create(Talon item)
        {
            await Task.Run(() => db.Items.Add(item));
        }

        public async Task Update(Talon item)
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
            await Task.Run(() =>
            {
                foreach (var i in db.Items)
                    if (i.Id == id)
                    {
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
                    db.SaveChangesAsync();
                    db.Dispose();

                }



                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~TalonRep() {
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
