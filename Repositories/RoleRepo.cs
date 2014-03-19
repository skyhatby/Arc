using System.Data.Entity.Infrastructure;
using System.Linq;
using Entities;

namespace Repositories
{
    public class RoleRepo : Repo
    {
        public static void CreateRole(string name)
        {
            CreateRole(new Roles(name));
        }

        public static IQueryable<Roles> GetAllRoles()
        {
            return Db.Roles.Select(c=>c);
        }

        public static void CreateRole(Roles role)
        {
            Db.Roles.Add(role);
            Db.SaveChanges();
        }

        public static Roles FindRoles(string roleName)
        {
            return Db.Set<Roles>().Find(roleName);
        }

        public static void DeleteRole(Roles role)
        {
            if (role == default(Roles)) throw new DbUpdateException("Such role doesn't exist");
            Db.Roles.Remove(role);
            Db.SaveChanges();
        }

        public static void DeliteRoleByName(string roleName)
        {
            DeleteRole(Db.Roles.Find(roleName));
        }
    }
}
