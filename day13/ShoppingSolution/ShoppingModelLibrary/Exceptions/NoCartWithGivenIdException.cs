using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class NoCartWithGivenIdException:Exception
    {
        string msg = String.Empty; 
        public NoCartWithGivenIdException() 
        {             
            msg = "No cart with given id found";
        }
        public override string Message => msg;

    }
}
