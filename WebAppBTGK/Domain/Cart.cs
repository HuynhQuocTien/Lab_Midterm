using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Cart
    {
        public int Id { get; set; }
        public DateTime CreatedDay { get; set; } = DateTime.Now;
        //nav
        public required string UserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
