using System.Runtime.Serialization;

namespace SimpleBankingBL.Exceptions
{
    [Serializable]
    internal class InsufficientBalanceException : Exception
    {
        string message = string.Empty;
        public InsufficientBalanceException()
        {
            message = "Insufficient balance";
        }
        public override string Message => message;
    }
}