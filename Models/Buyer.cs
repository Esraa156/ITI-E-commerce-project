
using Microsoft.AspNetCore.Identity;

namespace bnm.Models
{
    public class Buyer:UserApp
    {
        public virtual ICollection<ORDER> Orders { get; set; }

    }
}
