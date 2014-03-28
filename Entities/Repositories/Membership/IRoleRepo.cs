using Entities.Entities.Membership;

namespace Entities.Repositories.Membership
{
    public interface IRoleRepo:IRepo<Roles>
    {
        void Create(string name);
        Roles FindRoles(string roleName);
        void DeliteRoleByName(string roleName);
    }
}
