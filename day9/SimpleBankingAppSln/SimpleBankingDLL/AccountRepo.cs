using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBankingAppModels;

namespace SimpleBankingDLL
{
    public class AccountRepo : IRepo<int, Account>
    {
        readonly Dictionary<int, Account> _accounts;
        /// <summary>
        ///  constructor
        /// </summary>
        public AccountRepo()
        {
            _accounts = new Dictionary<int, Account>();
        }
        /// <summary>
        /// generates a random id for the account
        /// </summary>
        /// <returns>account no</returns>
        public int GenerateId()
        {
            int id = 0; 
            do
            {
                id = new System.Random().Next(1000, 9999);
            } while (_accounts.ContainsKey(id));
            return id;
        }

        /// <summary>
        /// create a new account 
        /// </summary>
        /// <param name="t">account object</param>
        /// <returns>account object</returns>
        
        public Account? Add(Account t)
        {
            if (_accounts.ContainsValue(t))
            {
                return null;
            }
            
            t.id = GenerateId();
            _accounts.Add(t.id, t);
            return t;
        }
        /// <summary>
        /// delete account 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Account? Delete(int key)
        {
            if (_accounts.ContainsKey(key))
            {
                Account? account = _accounts[key];
                _accounts.Remove(key);
                return account;
            }
            return null;
        }
        /// <summary>
        /// get account by id
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>

        public Account? Get(int key)
        {
            if (_accounts.ContainsKey(key))
            {
                return _accounts[key];
            }
            return null;
        }
        /// <summary>
        /// returns a list of all accounts
        /// </summary>
        /// <returns></returns>
        public List<Account> GetAll()
        {
            return _accounts.Values.ToList();
        }
        /// <summary>
        /// updates the account detsils
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Account? Update(Account item)
        {
            if (_accounts.ContainsKey(item.id))
            {
                _accounts[item.id] = item;
                return item;
            }
            return null;
        }
    }
}
