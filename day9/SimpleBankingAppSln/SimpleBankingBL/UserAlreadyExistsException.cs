using System.Runtime.Serialization;

namespace SimpleBankingBL
{
    internal class UserAlreadyExistsException : Exception
    {
        string message = String.Empty; 
        public UserAlreadyExistsException()
        {
            message = "User already exists";
        }
        public override string Message => message;
    }
}