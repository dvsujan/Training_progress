using System.Runtime.Serialization;

namespace SimpleBankingBL.Exceptions
{
    [Serializable]
    internal class AccountNotFoundException : Exception
    {
        string message = string.Empty;
        public AccountNotFoundException()
        {
            message = "Account not found";
        }
        public override string Message => message;
    }
}