using Entities.Entities.Membership;

namespace Entities.Repositories.Membership
{
    public interface IUserRepo : IRepo<User>
    {
        void SetUserInRole(User user, Roles roles);
        void UpdateUserName(string oldName, string newName);
        void UpdateUserPass(User user, string newPass);
        void DeleteUserByName(string userName);
        User Find(string name);

    }
}
