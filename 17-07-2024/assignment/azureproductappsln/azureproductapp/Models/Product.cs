using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace azureproductapp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set;  }
        public string Piclink { get; set; } = string.Empty; 
    }
}
