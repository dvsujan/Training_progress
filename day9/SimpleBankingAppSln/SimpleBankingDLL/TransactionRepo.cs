using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBankingAppModels;

namespace SimpleBankingDLL
{
    public class TransactionRepo: IRepo<int, Transaction>
    {
        readonly Dictionary<int, Transaction> _transactions;
        /// <summary>
        /// default constructor
        /// </summary>
        public TransactionRepo()
        {
            _transactions = new Dictionary<int, Transaction>();
        }
        /// <summary>
        /// generates a random id  for the transaction
        /// </summary>
        /// <returns></returns>
        public int GenerateId()
        {
            int id = 0; 
            do
            {
                id = new System.Random().Next(1000, 9999);
            } while (_transactions.ContainsKey(id));
            return id;
        }
        /// <summary>
        /// addes a new transaction to the dictionary
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>        
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
        /// <summary>
        /// deletes a tranasction from the dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>

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
        /// <summary>
        /// gets an account from the dict
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Transaction? Get(int key)
        {
            if (_transactions.ContainsKey(key))
            {
                return _transactions[key];
            }
            return null;
        }
        /// <summary>
        ///  gets all transactions fom the dictionary
        /// </summary>
        /// <returns></returns>
        public List<Transaction> GetAll()
        {
            return _transactions.Values.ToList();
        }
        /// <summary>
        /// updates a transaction
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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
