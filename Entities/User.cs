using System;
using System.Globalization;

namespace Entities
{
    public class User
    {
        private string _password;

        public User()
        {
            Id = Guid.NewGuid();
            PasswordSault = UsersHelper.GeneratePassword();
        }

        public User(string name)
            : this()
        {
            UserName = name;
        }

        public User(string name, string pass)
            : this()
        {
            UserName = name;
            Password = pass;
        }

        public Guid Id { get; private set; }
        public string UserName { get; set; }

        public string Password
        {
            get { return _password; }
            set { _password = (value + PasswordSault).GetHashCode().ToString(CultureInfo.InvariantCulture); }
        }
        public string PasswordSault { get; private set; }

        public string RoleName { get; set; }
        public virtual Roles Roles { get; set; }

        public override string ToString()
        {
            return UserName + Environment.NewLine;
        }
    }
}
