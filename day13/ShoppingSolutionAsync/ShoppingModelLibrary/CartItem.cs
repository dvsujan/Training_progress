using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    public class CartItem
    {
        public int CartId { get; set; }//Navigation property
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public DateTime PriceExpiryDate { get; set; }
        public CartItem()
        {
            CartId = 0;
            ProductId = 0;
            Quantity = 0;
            Price = 0;
            Discount = 1;
            PriceExpiryDate = DateTime.Now.AddMonths(1);
        }
        

        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return "CartId : " + CartId +
                "\nProductId : " + ProductId +
                "\nQuantity : " + Quantity +
                "\nPrice : $" + Price; 
        }
    }
}
