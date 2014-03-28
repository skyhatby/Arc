using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using Entities.Entities.Membership;

namespace Repositories
{
    public class EntityContext : DbContext, IDbContext
    {
        public EntityContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new UserMap());
            base.OnModelCreating(modelBuilder);
        }

       

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public new int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
