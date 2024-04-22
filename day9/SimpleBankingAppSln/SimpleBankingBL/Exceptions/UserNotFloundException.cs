using System.Runtime.Serialization;

namespace SimpleBankingBL.Exceptions
{
    public class UserNotFloundException : Exception
    {
        string message = string.Empty;
        public UserNotFloundException()
        {
            message = "User not found";
        }
        public override string Message => message;
    }
}