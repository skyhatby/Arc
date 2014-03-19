using System;
using System.Collections.Generic;

namespace Entities
{
    public class Roles
    {
        private ICollection<User> _users;

        public Roles(string name)
            : this()
        {
            RoleName = name;
        }

        public Roles()
        {
            _users = new List<User>();
        }

        public string RoleName { get; set; }
        public virtual ICollection<User> Users
        {
            get { return _users; }
            set { _users = value; }
        }

        public override string ToString()
        {
            return RoleName + Environment.NewLine;
        }
    }
}
