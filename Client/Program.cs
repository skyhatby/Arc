using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using Entities;
using Entities.Entities.Membership;
using Repositories;
using Repositories.Repositories.Membership;

namespace Client
{
    class Program
    {
        static void Main()
        {
            Tuple<bool, string> auth = null;
            while (true)
            {
                var ur = new UserRepo();
                var rr = new RoleRepo();
                int i;
                Console.WriteLine();
                if (auth != null) Console.WriteLine("Hi " + auth.Item2);
                Console.WriteLine("Enter 0 to authorize");
                Console.WriteLine("Enter 1 to create user");
                Console.WriteLine("Enter 2 to create role");
                Console.WriteLine("Enter 3 to view all users");
                Console.WriteLine("Enter 4 to view all roles");
                Console.WriteLine("Enter 5 to Set User In Role");
                Console.WriteLine("Enter 6 to Delete User");
                Console.WriteLine("Enter 7 to Delete Role" + Environment.NewLine + "Or nothing to exit");
                try
                {
                    i = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    break;
                }

                switch (i)
                {
                    case 0:
                        Console.Write("Enter User Name: ");
                        var user = ur.Find(Console.ReadLine());
                        Console.Write("Enter User Password: ");
                        if (user.Password ==
                            (Console.ReadLine() + Infrastructure.Helpers.UsersHelper.GetHash("asd",user.PasswordSault)))
                        {
                            auth = new Tuple<bool, string>(true, user.UserName);
                            Console.WriteLine("You have been authorized!");
                            break;
                        }
                        Console.WriteLine("Authorization Failed!");
                        break;
                    case 1:
                        CreateUser();
                        break;
                    case 2:
                        CreateRole();
                        break;
                    case 3:
                        ViewAllUsers();
                        break;
                    case 4:
                        ViewAllRoles();
                        break;
                    case 5:
                        SetUserInRole();
                        break;
                    case 6:
                        DeleteUser();
                        break;
                    case 7:
                        DeleteRole();
                        break;
                }
            }
        }

        private static void DeleteRole()
        {
            Console.WriteLine("Enter Role name");
            try
            {
                RoleRepo.DeliteRoleByName(Console.ReadLine());
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            Console.WriteLine("Succes!");
        }

        private static void DeleteUser()
        {
            Console.WriteLine("Enter User name to delete");
            try
            {
                var ur = new UserRepo();
                ur.DeleteUserByName(Console.ReadLine());
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            Console.WriteLine("Succes!" + Environment.NewLine);
        }

        private static void ViewAllRoles()
        {
            foreach (var roles in RoleRepo.GetAll())
            {
                Console.Write("Role " + roles + Environment.NewLine);
            }
        }

        private static void SetUserInRole()
        {
            Console.Write("Enter User Name: ");
            var userName = Console.ReadLine();
            Console.Write("Enter Role: ");
            var roleName = Console.ReadLine();
            try
            {
                var ur = new UserRepo();
                ur.SetUserInRole(userName, roleName);
            }
            catch (NoNullAllowedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Succes!");
            }
        }

        private static void ViewAllUsers()
        {
            var ur = new UserRepo();
            foreach (var allUser in ur.GetAll())
            {
                Console.Write(allUser);
            }
        }

        private static void CreateRole()
        {
            Console.Write("Enter Role: ");
            var role = new Roles(Console.ReadLine());
            try
            {
                RoleRepo.Create(role);
            }
            catch (DbUpdateException)
            {
                Console.WriteLine("Such Role already exists");
                return;
            }
            Console.WriteLine("You have created role {0}", role.RoleName);
        }

        private static void CreateUser()
        {
            var user = new User();
            user.UserName = Console.ReadLine();
            user.Password = Console.ReadLine();
            try
            {
                var ur = new UserRepo();
                ur.Create(user);
            }
            catch (NoNullAllowedException ex)
            {
            }
            catch (DbUpdateException ex)
            {
                return;
            }
        }
    }
}
