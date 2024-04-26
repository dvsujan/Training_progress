using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
        [ExcludeFromCodeCoverage]
    public class ProductAlreadyExistsException:Exception
    {
        string msg; 
        public ProductAlreadyExistsException()
        {
            msg = "Product already exists";
        }
        public override string Message => msg;

    }
}
