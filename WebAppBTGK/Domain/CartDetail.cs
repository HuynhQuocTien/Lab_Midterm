using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CartDetail
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        //nav
        public int BookId { get; set; }
        public int CartId { get; set; }
        public Book? Book { get; set; }
        public Cart? Cart { get; set; }
    }
}
