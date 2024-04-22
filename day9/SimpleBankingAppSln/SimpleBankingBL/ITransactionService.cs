using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBankingAppModels; 

namespace SimpleBankingBL
{
    internal interface ITransactionService
    {
        public Transaction Transfer(int fromAccountId, int toAccountId, float amount);
        public List<Transaction> GetAllTransactionsOfUser(int userId);
    }
}
