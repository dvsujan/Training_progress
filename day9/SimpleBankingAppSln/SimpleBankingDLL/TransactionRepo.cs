using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBankingAppModels;

namespace SimpleBankingDLL
{
    internal class TransactionRepo: IRepo<int, Transaction>
    {
        readonly Dictionary<int, Transaction> _transactions;
        public TransactionRepo()
        {
            _transactions = new Dictionary<int, Transaction>();
        }
        public int GenerateId()
        {
            int id = 0; 
            do
            {
                id = new System.Random().Next(1000, 9999);
            } while (_transactions.ContainsKey(id));
            return id;
        }
        
        public Transaction? Add(Transaction t)
        {
            if (_transactions.ContainsValue(t))
            {
                return null;
            }
            
            t.id = GenerateId();
            _transactions.Add(t.id, t);
            return t;
        }

        public Transaction? Delete(int key)
        {
            if (_transactions.ContainsKey(key))
            {
                Transaction? transaction = _transactions[key];
                _transactions.Remove(key);
                return transaction;
            }
            return null;
        }

        public Transaction? Get(int key)
        {
            if (_transactions.ContainsKey(key))
            {
                return _transactions[key];
            }
            return null;
        }

        public List<Transaction> GetAll()
        {
            return _transactions.Values.ToList();
        }

        public Transaction? Update(Transaction item)
        {
            if (_transactions.ContainsKey(item.id))
            {
                _transactions[item.id] = item;
                return item;
            }
            return null;
        }
    }
}
