namespace bnm.Models
{
    public class ORDER
    {
        
        public int Id { get; set; }

        public DateTime date { get; set; }
       
        public List<Cart>carts { get; set; }
        public string UserAppId { get; set; }
        public UserApp UserApp { get; set; }
        public int total { get; set; }
    }
}
