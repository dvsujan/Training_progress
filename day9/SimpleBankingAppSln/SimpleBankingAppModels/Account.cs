using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankingAppModels
{
    public class Account
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public float Balance { get; set; }
        public string? AccountType { get; set; }

        public Account()
        {
            id = -1;
            UserId = -1;
            Balance = 0;
            AccountType = String.Empty;
        }

        public Account(int userId , float balance, string accountType)
        {
            UserId = userId;
            Balance = balance;
            AccountType = accountType;
        }
        public override bool Equals(object? obj)
        {
            return this.id.Equals(((Account)obj).id);
        }
        public override string ToString()
        {
            return $"Account Id: {id}, User Id: {UserId}, Balance: {Balance}, Account Type: {AccountType}";
        }
    }
}
