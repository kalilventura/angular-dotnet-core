namespace API.Domain.Models
{
    public class SellerProducts
    {
        public SellerProducts(int productId, int sellerId)
        {
            ProductId = productId;
            SellerId = sellerId;
        }
        
        public int ProductId { get; set; }
        public int SellerId { get; set; }
        public Product Product { get; set; }
        public Seller Seller { get; set; }
    }
}
