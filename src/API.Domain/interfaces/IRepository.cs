using System;
using System.Collections;
using System.Threading.Tasks;
using API.Domain.entities;

namespace API.Domain.interfaces
{
    public interface IRepository<T> where T:BaseEntity
    {
        Task<T> InsertAsync (T item);
        Task<T> UpdateAsync (T item);
        Task<bool> ExistAsync (Guid id);
        Task<bool> DeleteAsync (Guid id);
        Task<T> SelectAsync (Guid id);
        Task<IEnumerable> SelectAsync ();
    }
}
