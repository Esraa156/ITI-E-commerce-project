namespace bnm.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ? oRDERId { get; set; }
        public string ? UserAppId { get; set; }

        public UserApp UserApp { get; set; }

        public ORDER oRDER { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
