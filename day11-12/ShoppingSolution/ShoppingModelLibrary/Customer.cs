using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    public class Customer : IEquatable<Customer>
    {
        public int Id { get; set; }
        public string Phone { get; set; } = String.Empty;
        public int Age { get; set; }
        [ExcludeFromCodeCoverage]
        public bool Equals(Customer? other)
        {
            return this.Id.Equals(other.Id);
        }
    }
}
