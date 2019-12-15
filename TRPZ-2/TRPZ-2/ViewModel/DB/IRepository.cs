using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPZ_2.ViewModel.DB
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        Task<IEnumerable<T>> GetItems(); 
        Task<T> GetItem(int id);
        Task Create(T item);
        Task Update(T item);
        Task Delete(int id); 
      
    }
}
