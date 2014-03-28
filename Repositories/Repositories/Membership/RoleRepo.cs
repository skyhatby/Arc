using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Entities.Entities.Membership;
using Entities.Repositories.Membership;

namespace Repositories.Repositories.Membership
{
    public class RoleRepo : Repo<Roles>, IRoleRepo
    {
        public RoleRepo(IDatabaseFactory db)
            : base(db)
        {
        }

        public void Create(string name)
        {
            Create(new Roles(name));
        }

        public IQueryable<Roles> GetAll()
        {
            return DataContext.Set<Roles>().Select(c => c);
        }

        public void Create(Roles role)
        {
            DataContext.Set<Roles>().Add(role);
            DataContext.SaveChanges();
        }

        public Roles FindRoles(string roleName)
        {
            return DataContext.Set<Roles>().Find(roleName);
        }

        public void Delete(Roles role)
        {
            if (role == default(Roles)) throw new DbUpdateException("Such role doesn't exist");
            DataContext.Set<Roles>().Remove(role);
            DataContext.SaveChanges();
        }

        public void DeliteRoleByName(string roleName)
        {
            Delete(DataContext.Set<Roles>().Find(roleName));
        }
    }
}
