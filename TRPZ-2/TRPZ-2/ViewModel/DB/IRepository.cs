using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPZ_2.ViewModel.DB
{
    interface IRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> GetItems(); 
        T GetItem(int id);
        Task Create(T item);
        Task Update(T item);
        Task Delete(int id); 
        Task Save();  
    }
}
