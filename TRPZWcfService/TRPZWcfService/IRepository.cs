using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TRPZWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserRepository" in both code and config file together.
    [ServiceContract]
    public interface IRepository<T>:IDisposable
    {
        [OperationContract]
        IEnumerable<T> GetItems();
        [OperationContract]
        T GetItem(int id);
        [OperationContract]
        Task Create(T item);
        [OperationContract]
        Task Update(T item);
        [OperationContract]
        Task Delete(int id);
        [OperationContract]
        Task Save();
    }
}
