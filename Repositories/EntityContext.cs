using System.Data.Entity;
using Entities;

namespace Repositories
{
    public class EntityContext : DbContext
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
    }
}
