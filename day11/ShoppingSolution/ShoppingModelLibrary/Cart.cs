using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    public class Cart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [ExcludeFromCodeCoverage]
        public Customer Customer { get; set; }//Navigation property
        [ExcludeFromCodeCoverage]
        public List<CartItem> CartItems { get; set; }//Navigation property
    }
}
