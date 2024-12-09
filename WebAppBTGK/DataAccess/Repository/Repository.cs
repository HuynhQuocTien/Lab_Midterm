using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BookContext _context;
        public Repository(BookContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }


        public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> expression, bool tracked = false)
        {
            if (tracked)
            {
                var entityTracked = await _context.Set<T>().FirstOrDefaultAsync(expression);
                return entityTracked;
            }

            var entity = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression);
            return entity;
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
