using System.Runtime.Serialization;

namespace SimpleBankingBL.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        string message = string.Empty;
        public UserAlreadyExistsException()
        {
            message = "User already exists";
        }
        public override string Message => message;
    }
}