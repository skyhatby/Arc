using System.Data.Entity.ModelConfiguration;
using Entities.Entities.Membership;

namespace Repositories
{
    class RoleMap : EntityTypeConfiguration<Roles>
    {
        public RoleMap()
        {
            HasKey(c => c.RoleName);
            HasMany(c => c.Users);
            Property(c => c.RoleName).HasMaxLength(128);
        }
    }
}
