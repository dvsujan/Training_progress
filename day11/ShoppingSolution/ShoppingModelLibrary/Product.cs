using System.Diagnostics.CodeAnalysis;

namespace ShoppingModelLibrary
{
    public class Product : IEquatable<Product>
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; } = string.Empty;

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
        public Product(int id, double price, string name,  int quantityInHand)
        {
            Id = id;
            Price = price;
            Name = name;
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
