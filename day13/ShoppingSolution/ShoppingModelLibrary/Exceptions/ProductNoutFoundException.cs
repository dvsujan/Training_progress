using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
namespace ShoppingModelLibrary.Exceptions 
{
    [ExcludeFromCodeCoverage]
    public class ProductNoutFoundException : Exception
    {
        string msg = String.Empty; 
        public ProductNoutFoundException()
        {
            msg = "Product not found";
        }
        public override string Message => msg;
    }
}