using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBankingAppModels
{
    public class Transaction
    {
        public enum TransactionType
        {
            Deposit=1,
            Withdraw,
            Transfer
        }
        public int id { get; set;}
        public DateTime timestamp { get; set; }
        public float amount { get; set; }   
        public int toId { get; set;  }
        public int fromId { get; set; }
        public TransactionType transactionType { get; set; }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Transaction()
        {
            id = -1;
            timestamp = DateTime.Now;
            amount = 0;
            toId = -1;
            fromId = -1;
        }

        /// <summary>
        /// parameterized constructor 
        /// </summary>
        /// <param name="timestamp">timestamp of the user</param>
        /// <param name="amount">amount to be initally added </param>
        /// <param name="toId"> to the user account </param>
        /// <param name="fromId"> from user account </param>
        /// <param name="type"> type of transactoin </param>
        public Transaction(DateTime timestamp, float amount, int toId, int fromId, TransactionType type)
        {
            this.timestamp = timestamp;
            this.amount = amount;
            this.toId = toId;
            this.fromId = fromId;
            this.transactionType = type;
        }
        /// <summary>
        /// overrides the equals method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            return this.id.Equals(((Transaction)obj).id) ;
        }

        /// <summary>
        /// returns the object as string 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Transaction Id: {id}, Timestamp: {timestamp}, Amount: {amount}, To Id: {toId}, From Id: {fromId}, Transaction Type: {transactionType}";
        }

    }
}
