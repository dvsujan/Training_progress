using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDALLibrary 
{
    public interface IRepo<K, T> where T:class
    {
        T Get(K key);
        T Insert(T item);
        T Update(T item);
        T Delete(K key);
        List<T> GetAll();
    }
}
