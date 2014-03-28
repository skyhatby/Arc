using System;
using System.Security.Principal;

namespace Services.Identity
{
    public class UserIdIdentity : IIdentity
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public string AuthenticationType { get { return "UserIdIdentity"; } }
        public bool IsAuthenticated { get; set; }
    }
}
