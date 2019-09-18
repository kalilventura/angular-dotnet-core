using System.Collections.Generic;

namespace API.Domain.Models
{
    public class Product
    {
        public Product() {}

        public Product(string barCode, string name, string description, decimal price)
        {
            BarCode = barCode;
            Name = name;
            Description = description;
            Price = price;
        }

        public int? ProductId { get; set; }
        public string BarCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        //1xN
        public ICollection<SellerProducts> SellerProducts { get; set; }
    }
}
