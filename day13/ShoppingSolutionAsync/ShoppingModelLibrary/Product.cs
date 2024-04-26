using System.Diagnostics.CodeAnalysis;

namespace ShoppingModelLibrary
{
    public class Product : IEquatable<Product>
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; } = string.Empty;
        public int stock { get; set; }

        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return "Id : " + Id +
                "\nName : " + Name +
                "\nPrice : $" + Price;  
        }
        [ExcludeFromCodeCoverage]
        public bool Equals(Product? other)
        {
            return this.Id.Equals(other.Id);
        }
        [ExcludeFromCodeCoverage]
        public Product()
        {
            
        }
        [ExcludeFromCodeCoverage]
        public Product(int id, double price, string name,  int stock)
        {
            Id = id;
            Price = price;
            Name = name;
            this.stock = stock;
        }
        [ExcludeFromCodeCoverage]
        public Product(int id, double price, string name, string? image, int quantityInHand)
        {
            Id = id;
            Price = price;
            Name = name;
        }
    }
}
