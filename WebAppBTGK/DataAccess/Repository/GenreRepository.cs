using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using Domain;

namespace DataAccess.Repository
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        private readonly BookContext _context;
        public GenreRepository(BookContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            var query = _context.Genres.AsQueryable();
            return await query.ToListAsync();
        }
    }
}
