using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class NoCartItemWithGivenIdException:Exception
    {
        string msg; 
        public NoCartItemWithGivenIdException()
        {
            msg = "No cart item with given id";
        }
        public override string Message => msg;


    }
}
