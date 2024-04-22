using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBankingAppModels;

namespace SimpleBankingBL
{
    public interface IAccountService
    {
        public Account CreateAccount(int userId, float balance, string accountType);
        public Account DeleteAccount(int accountId);
        public Account Deposit(int accountId, float amount);
        public bool Withdraw(int accountId, float amount);
        public Account Transfer(int fromAccountId, int toAccountId, float amount);
        public List<Account> GetAllAccounts();
        public Account? GetAccount(int accountId);
    }
}
