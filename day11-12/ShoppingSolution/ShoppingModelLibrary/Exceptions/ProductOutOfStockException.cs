using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class ProductOutOfStockException:Exception
    {
        string message;
        public ProductOutOfStockException()
        {
            message = "Product is out of stock";
        }
        public override string Message => message;
    }
}

