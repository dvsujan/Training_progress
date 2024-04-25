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
        public List<CartItem> Items { get; set; }
        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            string items = "";
            foreach (CartItem item in Items)
            {
                items += item.ToString() + "\n";
            }
            return "Id : " + Id +
                "\nCustomerId : " + CustomerId +
                "\nItems : \n" + items;
        }
    }
}
