using System.Runtime.Serialization;

namespace PizzaShopApi.Exceptions
{
    [Serializable]
    internal class UnauthorizedUserException : Exception
    {
        string message;

        public UnauthorizedUserException()
        {
            message = "Unauthorized User";
        }

        public override string Message => message;



    }
}