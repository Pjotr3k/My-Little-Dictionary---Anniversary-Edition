using Microsoft.EntityFrameworkCore;
using My_Little_Dictionary___Anniversary_Edition.Model;

namespace My_Little_Dictionary___Anniversary_Edition.Data
{
    public static class DBContextExtensions
    {
        public static TResult? GetById<TResult>(this DbSet<TResult> dbSet, Guid id) where TResult : BaseModel
            => dbSet.FirstOrDefault(item => item.ID == id);
    }
}
