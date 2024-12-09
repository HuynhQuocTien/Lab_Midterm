using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Catalogue
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public bool IsActive { get; set; } = false;
        //nav
        public List<BookCatalogue> BookCatalogues { get; set; } = [];
    }
}
