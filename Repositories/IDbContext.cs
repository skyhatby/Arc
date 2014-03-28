using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace Repositories
{
    public interface IDbContext : IDisposable
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
    }

    public static class DbContextExtensions
    {
        public static EntityContext GetObjectContext(this IDbContext dbContext)
        {
            return (EntityContext)dbContext;
        }
    }
}
