using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class CustomerAlreadyExistsException:Exception
    {
        string msg; 
        public CustomerAlreadyExistsException()
        {
            msg = "Customer already exists";
        }
        public override string Message => msg;
    }
}
