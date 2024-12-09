using System.Linq.Expressions;

namespace Application
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        Task<T?> GetAsync(Expression<Func<T, bool>> expression, bool tracked = false);
        void Remove(T entity);
        void Update(T entity);
    }
}
