using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    public interface ICRUD<T> where T: class
    {
        T Get(ID id);
        List<T> Get();
        ID Insert(T item);
        void Update(T item);
        void Delete(ID id);            

    }
}
