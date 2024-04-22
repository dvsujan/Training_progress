using System.Runtime.Serialization;

namespace SimpleBankingBL.Exceptions
{
    [Serializable]
    internal class UserNotFloundException : Exception
    {
        string message = string.Empty;
        public UserNotFloundException()
        {
            message = "User not found";
        }
        public override string Message => message;
    }
}