using System.Data.Entity.ModelConfiguration;
using Entities;

namespace Repositories
{
    class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(c => c.Id);
            Property(c => c.UserName).IsRequired().HasMaxLength(128);
            Property(c => c.Password).IsRequired().HasMaxLength(128);
            HasOptional(c => c.Roles);
        }
    }
}
