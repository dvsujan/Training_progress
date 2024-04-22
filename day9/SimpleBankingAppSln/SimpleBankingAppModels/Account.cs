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
        /// <summary>
        /// default constructor
        /// </summary>
        public Account()
        {
            id = -1;
            UserId = -1;
            Balance = 0;
            AccountType = String.Empty;
        }
        /// <summary>
        /// paramaterizzed constructor
        /// </summary>
        /// <param name="userId"> id of the user</param>
        /// <param name="balance"> balance of account </param>
        /// <param name="accountType"> type of the account for now only savings account is avalable</param>

        public Account(int userId , float balance, string accountType)
        {
            UserId = userId;
            Balance = balance;
            AccountType = accountType;
        }
        /// <summary>
        /// overrides the Equals method so that it can be used 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            return this.id.Equals(((Account)obj).id);
        }
        /// <summary>
        /// converts the object to string
        /// </summary>
        /// <returns> string </returns>
        public override string ToString()
        {
            return $"Account Id: {id}, User Id: {UserId}, Balance: {Balance}, Account Type: {AccountType}";
        }
    }
}
