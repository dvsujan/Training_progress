using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ShoppingModelLibrary.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class CartItemAlreadyExistsException:Exception
    {
        string msg; 
        public CartItemAlreadyExistsException()
        {
            msg = "Cart item already exists";
        }
        public CartItemAlreadyExistsException(string msg)
        {
            this.msg = msg;
        }
    }
}
