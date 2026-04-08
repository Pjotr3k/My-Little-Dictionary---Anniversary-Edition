using Microsoft.EntityFrameworkCore;
using My_Little_Dictionary___Anniversary_Edition.Model;
using System.Linq.Expressions;

namespace My_Little_Dictionary___Anniversary_Edition.Data
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
    }
}
