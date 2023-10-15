using Microsoft.AspNetCore.Identity;

namespace bnm.Models
{
    public class Seller:UserApp
    {
        public virtual ICollection<Product> Products { get; set; }

    }
}
