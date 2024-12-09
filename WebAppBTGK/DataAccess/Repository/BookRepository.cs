using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly BookContext _context;
        public BookRepository(BookContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var query = _context.Books.AsQueryable();
            return await query.ToListAsync();
        }
    }
}
