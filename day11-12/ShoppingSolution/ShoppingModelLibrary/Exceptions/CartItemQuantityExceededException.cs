using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class CartItemQuantityExceededException:Exception
    {
        string msg; 
        public CartItemQuantityExceededException()
        {
            msg = "Cart item quantity exceeded";
        }
        public CartItemQuantityExceededException(string msg)
        {
            this.msg = msg;
        }
    }
}
