using System.Runtime.Serialization;

namespace SimpleBankingBL
{
    [Serializable]
    internal class UserNotFloundException : Exception
    {
        string message = String.Empty; 
        public UserNotFloundException()
        {
            message = "User not found";
        }
        public override string Message => message;
    }
}