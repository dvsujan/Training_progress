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
        public Account CreateAccount(Account ac);
        public Account DeleteAccount(int accountId);
        public Account Deposit(int accountId, float amount);
        public Account Withdraw(int accountId, float amount);
        public Account Transfer(int fromAccountId, int toAccountId, float amount);
        public List<Transaction> TransactionsOfUser(int userId); 
        public Account? GetAccount(int accountId);
    }
}
