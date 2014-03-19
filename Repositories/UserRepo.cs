using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Entities;

namespace Repositories
{
    public class UserRepo : Repo
    {
        public static void CreateUser(User user)
        {
            if (user.UserName == null || user.Password == null || user.Password == "" || user.UserName == "") throw new NoNullAllowedException("User name and password must be nom null");
            if(FindUser(user.UserName).Count()!=0)throw new DbUpdateException("Such user name already exists");
            Db.Users.Add(user);
            Db.SaveChanges();
        }

        public static void SetUserInRole(string userName, string rolesName)
        {
            var user = Db.Users.FirstOrDefault(c => c.UserName == userName);
            var roles = RoleRepo.FindRoles(rolesName);
            SetUserInRole(user, roles);
        }

        public static void SetUserInRole(User user, Roles roles)
        {
            if (user == null || roles == null) throw new NoNullAllowedException("Such user or role doesn't exists");
            user.RoleName = roles.RoleName;
            Db.SaveChanges();
        }

        public static IQueryable<User> GetAllUsers()
        {
            return Db.Users;
        }

        private static IQueryable<User> FindUser(string name)
        {
            return Db.Users.Where(c=>c.UserName==name);
        }

        public static User FindUserByName(string name)
        {
            return Db.Users.FirstOrDefault(c => c.UserName==name);
        }

        public static void UpdateUserName(string oldName, string newName)
        {
            var user=Db.Users.FirstOrDefault(c => c.UserName == oldName);
            if (user==null) throw new DbUpdateException("Can't update, because such user doesn't exist");
            user.UserName = newName;
            Db.SaveChanges();
        }

        public static void UpdateUserPass(User user, string newPass)
        {
            if (user == null) throw new DbUpdateException("Can't update, because such user doesn't exist");
            user.Password = newPass;
            Db.SaveChanges();
        }

        public static void DeleteUser(User user)
        {
            if (user == default(User)) throw new DbUpdateException("Such user doesn't exist");
            Db.Users.Remove(user);
            Db.SaveChanges();
        }

        public static void DeleteUserByName(string userName)
        {
            DeleteUser(Db.Users.FirstOrDefault(c=>c.UserName==userName));
        }
    }
}
