using Microsoft.EntityFrameworkCore;
using Domain;
using System.Linq.Expressions;

namespace Data
{
    public static class DBContextExtensions
    {
        public static TResult? GetById<TResult>(this DbSet<TResult> dbSet, Guid id, params Expression<Func<TResult, object>>[] includeFuncs) where TResult : BaseModel
        {
            IQueryable<TResult> query = dbSet;

            foreach(var func in includeFuncs)
            {
                query = dbSet.Include(func);
            }

            return query.FirstOrDefault(item => item.ID == id);
        }

        public static IQueryable<TResult> GetByIds<TResult>(this DbSet<TResult> dbSet, IEnumerable<Guid> ids, params Expression<Func<TResult, object>>[] includeFuncs) where TResult : BaseModel
        {
            IQueryable<TResult> query = dbSet;

            foreach (var func in includeFuncs)
            {
                query = dbSet.Include(func);
            }

            return query.Where(item => ids.Contains(item.ID));
        }
    }
}
