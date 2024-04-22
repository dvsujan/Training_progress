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
        /// <summary>
        /// default constructor
        /// </summary>
        public AccountBL()
        {
            _accountRepo = new AccountRepo();
            _transactionRepo = new TransactionRepo();
        }
        /// <summary>
        /// create a new account for the user in db
        /// </summary>
        /// <param name="ac"></param>
        /// <returns></returns>
        /// <exception cref="AccountAlreadyExistsException"></exception>
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
        /// <summary>
        /// deletes the user accoutn
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        /// <exception cref="AccountNotFoundException"></exception>

        public Account DeleteAccount(int accountId)
        {
            var a = _accountRepo.Delete(accountId);
            if (a != null)
            {
                return a;
            }
            throw new AccountNotFoundException();
        }

        /// <summary>
        /// deposits money to account
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        /// <exception cref="AccountNotFoundException"></exception>

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

        /// <summary>
        /// gets the account details
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        /// <exception cref="AccountNotFoundException"></exception>

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
        /// <summary>
        /// gets all the transactions 
        /// </summary>
        /// <returns></returns>

        public List<Transaction> getAllTransactions()
        {
            return _transactionRepo.GetAll();
        }

        /// <summary>
        /// get all the transactions of the user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>

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
        /// <summary>
        /// transfter money from one user to other based on id
        /// </summary>
        /// <param name="fromAccountId"></param>
        /// <param name="toAccountId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        /// <exception cref="AccountNotFoundException"></exception>
        /// <exception cref="InsufficientBalanceException"></exception>

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
        /// <summary>
        /// used to withdraw money from the account
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        /// <exception cref="AccountNotFoundException"></exception>
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
