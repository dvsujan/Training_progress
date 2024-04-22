using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankingDLL
{
    public interface IRepo<K, T> where T:class
    {
        List<T> GetAll();
        T? Get(K key); 
        T? Add(T t);
        T? Update(T item);
        T? Delete(K key); 
    }
}
