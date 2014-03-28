using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Entities.Entities.Membership;
using Entities.Repositories.Membership;

namespace Repositories.Repositories.Membership
{
    public class UserRepo : Repo<User>, IUserRepo
    {
        public UserRepo(IDatabaseFactory db)
            : base(db)
        {
        }

        public void Create(User user)
        {
            if (user.UserName == null || user.Password == null || user.Password == "" || user.UserName == "") throw new NoNullAllowedException("User name and password must be nom null");
            if (Find(user.UserName) != null) throw new DbUpdateException("Such user name already exists");
            DataContext.Set<User>().Add(user);
            DataContext.SaveChanges();
        }

        //public void SetUserInRole(string userName, string rolesName)
        //{
        //    var rr = new RoleRepo(DataContext);
        //    var user = DataContext.Set<User>().FirstOrDefault(c => c.UserName == userName);
        //    var roles = rr.FindRoles(rolesName);
        //    SetUserInRole(user, roles);
        //}

        public void SetUserInRole(User user, Roles roles)
        {
            if (user == null || roles == null) throw new NoNullAllowedException("Such user or role doesn't exists");
            user.RoleName = roles.RoleName;
            DataContext.SaveChanges();
        }

        public IQueryable<User> GetAll()
        {
            return DataContext.Set<User>();
        }

        public User Find(string name)
        {
            return DataContext.Set<User>().FirstOrDefault(c => c.UserName == name);
        }

        public void UpdateUserName(string oldName, string newName)
        {
            var user = DataContext.Set<User>().FirstOrDefault(c => c.UserName == oldName);
            if (user == null) throw new DbUpdateException("Can't update, because such user doesn't exist");
            user.UserName = newName;
            DataContext.SaveChanges();
        }

        public void UpdateUserPass(User user, string newPass)
        {
            if (user == null) throw new DbUpdateException("Can't update, because such user doesn't exist");
            user.Password = newPass;
            DataContext.SaveChanges();
        }

        public void Delete(User user)
        {
            if (user == default(User)) throw new DbUpdateException("Such user doesn't exist");
            DataContext.Set<User>().Remove(user);
            DataContext.SaveChanges();
        }

        public void DeleteUserByName(string userName)
        {
            Delete(DataContext.Set<User>().FirstOrDefault(c => c.UserName == userName));
        }


    }
}
