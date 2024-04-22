using System.Runtime.Serialization;

namespace SimpleBankingBL.Exceptions
{
    internal class AccountAlreadyExistsException : Exception
    {
        string message = string.Empty;
        public AccountAlreadyExistsException()
        {
            message = "Account already exists";
        }
        public override string Message => message;
    }
}