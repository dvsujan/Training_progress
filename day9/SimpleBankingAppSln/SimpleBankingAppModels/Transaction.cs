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
        public int id { get; set;}
        public DateTime timestamp { get; set; }
        public float amount { get; set; }   
        public int toId { get; set;  }
        public int fromId { get; set; }

        public Transaction()
        {
            id = -1;
            timestamp = DateTime.Now;
            amount = 0;
            toId = -1;
            fromId = -1;
        }
        
        public Transaction(DateTime timestamp, float amount, int toId, int fromId)
        {
            this.timestamp = timestamp;
            this.amount = amount;
            this.toId = toId;
            this.fromId = fromId;
        }
         
    }
}
