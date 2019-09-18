using System.Collections.Generic;

namespace API.Domain.Models
{
    public class Seller
    {
        public Seller() {}

        public Seller(string name, string telephone, decimal comissionValue)
        {
            Name = name;
            Telephone = telephone;
            CommissionValue = comissionValue;
        }

        public int? SellerId { get; set; }

        public string Name { get; set; }

        public string Telephone { get; set; }

        public decimal CommissionValue { get; set; }

        //1xN
        public ICollection<SellerProducts> SellerProducts { get; set; }
    }
}
