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
        public AccountRepo()
        {
            _accounts = new Dictionary<int, Account>();
        }
        public int GenerateId()
        {
            int id = 0; 
            do
            {
                id = new System.Random().Next(1000, 9999);
            } while (_accounts.ContainsKey(id));
            return id;
        }
        
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

        public Account? Get(int key)
        {
            if (_accounts.ContainsKey(key))
            {
                return _accounts[key];
            }
            return null;
        }

        public List<Account> GetAll()
        {
            return _accounts.Values.ToList();
        }

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
