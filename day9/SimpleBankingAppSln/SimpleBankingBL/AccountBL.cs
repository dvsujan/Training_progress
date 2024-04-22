using SimpleBankingAppModels;
using SimpleBankingDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBankingBL.Exceptions; 

namespace SimpleBankingBL
{
    public class AccountBL : IAccountService
    {
        readonly IRepo<int, Account> _accountRepo;
        readonly IRepo<int, Transaction> _transactionRepo; 
        public AccountBL()
        {
            _accountRepo = new AccountRepo();
            _transactionRepo = new TransactionRepo();
        }
        public Account CreateAccount(Account ac)
        {
             
            var a = _accountRepo.Add(ac);
            if (a != null)
            {
                _transactionRepo.Add(new Transaction(DateTime.Now, ac.Balance, a.id, a.id, Transaction.TransactionType.Deposit));
                return a;  
            }
             throw new AccountAlreadyExistsException();
        }

        public Account DeleteAccount(int accountId)
        {
            var a = _accountRepo.Delete(accountId);
            if (a != null)
            {
                return a;
            }
            throw new AccountNotFoundException();
        }

        public Account Deposit(int accountId, float amount)
        {
            List<Account> accounts = _accountRepo.GetAll();
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].id == accountId)
                {
                    accounts[i].Balance += amount;
                    _transactionRepo.Add(new Transaction(DateTime.Now ,  amount, accountId , accountId , Transaction.TransactionType.Deposit));
                    return accounts[i];
                }
            }
            throw new AccountNotFoundException();
            
        }

        public Account? GetAccount(int accountId)
        {
            List<Account> accounts = _accountRepo.GetAll();
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].id == accountId)
                {
                    return accounts[i];
                }
            }
            throw new AccountNotFoundException(); 
        }

        public List<Transaction> getAllTransactions()
        {
            return _transactionRepo.GetAll();
        }

        public List<Transaction>TransactionsOfUser(int userId)
        {
            List<Transaction> accounts = _transactionRepo.GetAll();
            List<Transaction> usertransactions = new List<Transaction>();
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].fromId == userId)
                {
                    usertransactions.Add(accounts[i]);
                }
            }
            return usertransactions;
        }

        public Account Transfer(int fromAccountId, int toAccountId, float amount)
        {
            List<Account> accounts = _accountRepo.GetAll();
            Account fromAccount = null;
            Account toAccount = null;
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].id == fromAccountId)
                {
                    fromAccount = accounts[i];
                }
                if (accounts[i].id == toAccountId)
                {
                    toAccount = accounts[i];
                }
            }
            if (fromAccount == null || toAccount == null)
            {
                throw new AccountNotFoundException();
            }
            if (fromAccount.Balance < amount)
            {
                throw new InsufficientBalanceException();
            }
            fromAccount.Balance -= amount;
            toAccount.Balance += amount;
            _accountRepo.Update(fromAccount);
            _accountRepo.Update(toAccount);
            _transactionRepo.Add(new Transaction(DateTime.Now, amount, toAccountId, fromAccountId, Transaction.TransactionType.Transfer));
            return fromAccount;
        }

        public Account Withdraw(int accountId, float amount)
        {
            List<Account> accounts = _accountRepo.GetAll();
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].id == accountId)
                {
                    accounts[i].Balance -= amount;
                    _transactionRepo.Add(new Transaction(DateTime.Now, amount, accountId, accountId, Transaction.TransactionType.Withdraw));
                    return accounts[i];
                }
            }
            throw new AccountNotFoundException();
        }
    }
}
