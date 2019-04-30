using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface ICRUD<T> where T: class
    {
        Task<T> GetAsync(ID id);
        Task<List<T>> GetAsync();
        Task<ID> InsertAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(ID id);            

    }
}
