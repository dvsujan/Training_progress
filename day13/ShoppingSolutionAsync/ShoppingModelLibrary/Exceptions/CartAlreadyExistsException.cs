using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace ShoppingModelLibrary.Exceptions 
{
    [ExcludeFromCodeCoverage]
    public class CartAlreadyExistsException : Exception
    {
        string msg; 
        public CartAlreadyExistsException()
        {
            msg = "Cart already exists";
        }
        public CartAlreadyExistsException(string msg)
        {
            this.msg = msg;
        }
    }
}